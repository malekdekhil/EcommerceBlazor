using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noums_eCommerce_UI.Pages.ViewModels
{
    public class BoutiqueVm
    {
        public IEnumerable<Product> ProductsIncludePictures { get; set; }
        public IEnumerable<Category> categories { get; set; }
    }
}
