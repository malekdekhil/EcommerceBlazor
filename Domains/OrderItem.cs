using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class OrderItem
    {
        public int IdOrderItem { get; set; }
        public string CustomerId { get; set; }
        public int Quantity { get; set; }
        public string OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }
        public int IdOrder_Fk { get; set; }

    }
}
