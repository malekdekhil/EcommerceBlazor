using Domains;
using Microsoft.AspNetCore.Components;
 using Services.Interfaces;
using ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Noums_eCommerce_UI.Pages.Models;

namespace Noums_eCommerce_UI.Pages.Models
{
    public class ProductModelBase : ComponentBase
    {
        [Inject] protected IProduct ProductServices { get; set; }
        [Inject] private ICart CartService { get; set; }
        public IEnumerable<Product> ProductsIncludePictures { get; set; }
        public   Cart LocalCart { get; set; }
      
        protected override async Task OnInitializedAsync()
        {
            ProductsIncludePictures = await ProductServices.GetAllProductsIncludePicturesAsync();
            LocalCart = await CartService.InitializeShoppingCart();
 

            base.OnInitialized();
        }


        protected override void OnInitialized()
        {

            ProductsIncludePictures = new List<Product>();
            base.OnInitialized();
        }

        public void GetPicturePath(int idPicture, int idProduct)
        {
            foreach (var prod in ProductsIncludePictures.Where(a => a.IdProduct == idProduct))
            {
                foreach (var pics in prod.Pictures.Where(a => a.IdProduct_Fk == idProduct && a.IdPictures == idPicture))
                {
                    prod.ImageUrl = "Pictures/" + pics.UrlPicture;
                }
            }
        }




        //protected async Task<Cart> AddToCart(int id)
        //{
        //    return await CartService.AddCart(id); 
        //}

        //protected async Task RemoveCartItem(int id)
        //{
        //    await CartService.DeleteCartItem(id);

        //}
        //protected async Task RemoveItem(int id)
        //{
        //    await CartService.DeleteItem(id);

        //}
        //public async Task ClearBasket()
        //{

        //    await CartService.ClearCart();


        //}


        //public Cart GetAll()
        //{
        //    return LocalCart;
        //}

       public async Task CallAddToCart(int id)
        {
              await CartService.AddCart(id);
        }

        public async Task CallRemoveCartItem(int id)
        {
            await CartService.DeleteCartItem(id);
        }

        public async Task CallRemoveItem(int id)
        {
            await CartService.DeleteItem(id);
        }

        public async Task CallClearBasket()
        {
            await CartService.ClearCart();
        }

        public Cart CallGetAll()
        {
            return LocalCart;
        }

        public IEnumerable<Product> CallGetAllProductsIncludePicturesAsync()
        {
            return ProductsIncludePictures.ToList();
        }
    }
}
