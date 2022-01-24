using Domains;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class ClsShoppingCart : ICart
    {
        private Cart _Cart { get; set; }
        private CartItem _CartItem { get; set; }
        private readonly IProduct ProductServices;
        private readonly ProtectedLocalStorage LocalStorage;
        public ClsShoppingCart() { }
        public ClsShoppingCart(IProduct ProductServices, ProtectedLocalStorage LocalStorage)
        {
            this.ProductServices = ProductServices;
            this.LocalStorage = LocalStorage;
        }
        public ClsShoppingCart(Cart cart, CartItem cartItem)
        {
            _Cart = cart;
            _CartItem = cartItem;
        }
        public async Task<Cart> InitializeShoppingCart()
        {
            var result = await LocalStorage.GetAsync<Cart>("Cart");
            return _Cart = result.Success ? result.Value : null;
        }
        public async Task<Cart> AddCart(int id)
        {
            if (_Cart == null)
            {
                _Cart = new Cart();
            }
            var productById = await ProductServices.GetProductByIdAsync(id);
            _CartItem = _Cart.ListProducts.Where(a => a.ProductId == productById.IdProduct).FirstOrDefault();
            if (_CartItem != null && productById != null)
            {
                _Cart = await UpdateCart(_Cart, productById);
                if (productById.Quantity > _CartItem.ProductQuantity)
                {
                    _CartItem.ProductQuantity++;
                }
                _CartItem.TotalItem = _CartItem.ProductPrice * _CartItem.ProductQuantity;
            }
            else
            {
                _Cart.ListProducts.Add(
                new CartItem()
                {
                    ProductId = productById.IdProduct,
                    ProductName = productById.Name,
                    ProductPrice = productById.SalesPrice,
                    shippingPrice = productById.ShippingPrice,
                    TVA = productById.Tva,
                    ProductQuantity = 1,
                    TotalItem = productById.SalesPrice,
                    ProductUrlImage = productById.ImageUrl,
                });
            }
            _Cart.Total = _Cart.ListProducts.Sum(a => a.TotalItem);
            await LocalStorage.SetAsync("Cart", _Cart);
            return _Cart;
        }
        public async Task ClearCart()
        {
            if (_Cart != null && _Cart.ListProducts.Count() > 0)
            {
                foreach (var cartItem in _Cart.ListProducts.ToList())
                {
                    _Cart.ListProducts.Remove(cartItem);
                }
                _Cart.Total = _Cart.ListProducts.Sum(a => a.TotalItem);
                await LocalStorage.DeleteAsync("Cart");
                await LocalStorage.SetAsync("Cart", _Cart);
            }
        }
        public async Task DeleteCartItem(int id)
        {
            if (id > 0)
            {
                _CartItem = _Cart.ListProducts.FirstOrDefault(a => a.ProductId == id);
                if (_CartItem != null)
                {
                    _Cart.ListProducts.Remove(_CartItem);
                    _Cart.Total = _Cart.ListProducts.Sum(a => a.TotalItem);
                    await LocalStorage.DeleteAsync("Cart");
                    await LocalStorage.SetAsync("Cart", _Cart);
                }
            }
        }
        public async Task DeleteItem(int id)
        {
            _CartItem = _Cart.ListProducts.FirstOrDefault(a => a.ProductId == id);
            if (id > 0 && _CartItem != null)
            {
                _CartItem.ProductQuantity = _CartItem.ProductQuantity - 1;
                if (_CartItem.ProductQuantity <= 0)
                {
                    await DeleteCartItem(_CartItem.ProductId);
                }
                else
                {
                    _CartItem.TotalItem = _CartItem.TotalItem - _CartItem.ProductPrice;
                    _Cart.Total = _Cart.ListProducts.Sum(a => a.TotalItem);
                    await LocalStorage.SetAsync("Cart", _Cart);
                }
            }
        }
        public async Task CheckDisponibility()
        {
            var products = await ProductServices.GetAllProductsAsync();
            if (_Cart != null && _Cart.ListProducts.Count() > 0 && products != null)
            {
                foreach (var product in products.Select(a => new { a.IdProduct, a.Quantity }).ToList())
                {
                    foreach (var cartItem in _Cart.ListProducts.Where(c => c.ProductId == product.IdProduct).ToList())
                    {
                        if (product.Quantity <= 0)
                        {
                            await DeleteCartItem(cartItem.ProductId);
                        }
                        else if (product.Quantity < cartItem.ProductQuantity)
                        {
                            while (product.Quantity < cartItem.ProductQuantity)
                            {
                                await DeleteItem(cartItem.ProductId);
                            }
                        }
                    }
                }
            }
        }

        public async Task<Cart> UpdateCart(Cart cart, Product product)
        {
            if (cart != null)
            {
                if (product != null)
                {
                    foreach (var c in cart.ListProducts.Where(a => a.ProductId == product.IdProduct))
                    {
                        if (c.ProductPrice != product.SalesPrice)
                        {
                            c.ProductPrice = product.SalesPrice;
                            c.TotalItem = (c.ProductPrice * c.ProductQuantity);
                        }
                    }
                }
                else
                {
                    foreach (var p in await ProductServices.GetAllProductsIncludePicturesAsync())
                    {
                        foreach (var c in cart.ListProducts.Where(a => a.ProductId == p.IdProduct))
                        {
                            if (c.ProductPrice != p.SalesPrice)
                            {
                                c.ProductPrice = p.SalesPrice;
                                c.TotalItem = (c.ProductPrice * c.ProductQuantity);
                            }
                        }
                    }
                    cart.Total = _Cart.ListProducts.Sum(a => a.TotalItem);
                    await LocalStorage.SetAsync("Cart", cart);
                }
            }
            return cart;
        }
    }
}

