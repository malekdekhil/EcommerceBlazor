using Domains;
using ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noums_eCommerce_UI.Pages.ViewModels
{
    public class OrderVm
    {
        public UserTmp userTmp { get; set; }
        public IEnumerable<Product> ProductsIncludePictures { get; set; }
        public Cart LocalCart { get; set; }
        public bool dispoIsChanged = false;
    }
}
