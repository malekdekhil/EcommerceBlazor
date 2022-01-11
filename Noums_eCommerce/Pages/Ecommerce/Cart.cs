using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Noums_eCommerce.Pages.Ecommerce
{
    public class Cart
    {
        public List<CartItem> ListProducts { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Total { get; set; }
      
        [Column(TypeName = "decimal(8,2)")]
        public decimal TotalAllItems { get; set; }
        public Cart()
        {
            ListProducts = new List<CartItem>();
        }
    }
}
