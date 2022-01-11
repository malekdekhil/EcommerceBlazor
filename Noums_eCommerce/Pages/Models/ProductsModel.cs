using Domains;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Noums_eCommerce.Pages.Ecommerce;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace Noums_eCommerce.Pages.Models
{
    public class ProductsModel : ComponentBase, IDisposable
    {
           

        [Inject] private IProduct ProductServices { get; set; }
        public IEnumerable<Product> ProductsIncludePictures { get; set; }
        public Cart _Cart { get; set; }
        protected CartItem _CartItem { get; set; }


        protected override async Task OnInitializedAsync()
        {

            ProductsIncludePictures = await ProductServices.GetAllProductsIncludePicturesAsync();

            base.OnInitialized();
        }


        protected override void OnInitialized()
        {
            _CartItem = new CartItem();
            _Cart = new Cart();
            ProductsIncludePictures = new List<Product>();
            base.OnInitialized();
        }




        public void Dispose()
        {
        }
    }
}
