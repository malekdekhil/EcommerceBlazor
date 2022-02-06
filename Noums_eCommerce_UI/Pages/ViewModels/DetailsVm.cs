using Domains;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noums_eCommerce_UI.Pages.ViewModels
{
    public class DetailsVm
    {
        public Cart LocalCart { get; set; }
        public Product product { get; set; }
        public IEnumerable<Opinion> OpinionsByProduct { get; set; }
        public Opinion opinion { get; set; }
    }
}
