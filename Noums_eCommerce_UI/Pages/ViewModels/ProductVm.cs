using Domains;
using ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noums_eCommerce_UI.Pages.ViewModels
{
    public class ProductVm
    {
        public IEnumerable<Opinion> opinions { get; set; }
        public Product product { get; set; }
        public Cart LocalCart { get; set; }
    }
}
