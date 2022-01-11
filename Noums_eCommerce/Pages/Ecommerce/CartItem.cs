using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Noums_eCommerce.Pages.Ecommerce
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductUrlImage { get; set; }
        public int ProductQuantity { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal TotalWithTva { get; set; }
        public decimal TVA { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal shippingPrice { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal ProductPrice { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Total { get; set; }
    }
}
