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
            var products = await ProductServices.GetAllProductsIncludePicturesAsync();
            var productById = products.ToList().Where(a => a.IdProduct == id).FirstOrDefault();
            _CartItem = _Cart.ListProducts.Where(a => a.ProductId == productById.IdProduct).FirstOrDefault();
            if (_CartItem != null)
            {
                foreach (var session in _Cart.ListProducts.ToList())
                {
                    if (session.ProductId == productById.IdProduct && session.ProductPrice != productById.SalesPrice)
                    {
                        session.ProductPrice = productById.SalesPrice;
                    }
                }
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
            _Cart.TotalAllItems = _Cart.ListProducts.Sum(t => t.TotalItem);
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
                _Cart.TotalAllItems = _Cart.ListProducts.Sum(a => a.TotalItem);
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
                if(_CartItem != null)
                {
                    _Cart.ListProducts.Remove(_CartItem);
                    _Cart.TotalAllItems = _Cart.ListProducts.Sum(a => a.TotalItem);
                    _Cart.Total = _Cart.ListProducts.Sum(a => a.TotalItem);
                    await LocalStorage.DeleteAsync("Cart");
                    await LocalStorage.SetAsync("Cart", _Cart);
                }
            }
        }
        public async Task DeleteItem(int id)
        {
            _CartItem = _Cart.ListProducts.FirstOrDefault(a => a.ProductId == id);
            if (id > 0 && _CartItem !=null)
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
                    _Cart.TotalAllItems = _Cart.ListProducts.Sum(t => t.TotalItem);
                    await LocalStorage.SetAsync("Cart", _Cart);
                }
            }
        }
        public async Task CheckDisponibility()
        {
            var products = await ProductServices.GetAllProductsAsync();
            if (_Cart != null && _Cart.ListProducts.Count() > 0 && products != null)
            {
                foreach (var product in products.Select(a => new { a.IdProduct, a.Quantity, a.SalesPrice }).ToList())
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
    }
}

