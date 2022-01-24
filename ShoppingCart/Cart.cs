using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ShoppingCart
{
    public class Cart
    {
        public List<CartItem> ListProducts { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Total { get; set; }
        public Cart()
        {
            ListProducts = new List<CartItem>();
        }
    }
}
