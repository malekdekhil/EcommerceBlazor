using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart
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
        public decimal TotalItem { get; set; }
    }
}
