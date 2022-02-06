using Domains;
using Microsoft.AspNetCore.Components;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noums_eCommerce_UI.Pages.ViewModels
{
    public class IndexVm
    {
        public IEnumerable<Product> ProductsIncludePictures { get; set; }
    }
}
