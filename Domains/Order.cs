using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class Order
    {
        public int IdOrder { get; set; }
        public string PaymentTransactionId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }
        public string Status { get; set; }
        public string TrakingNumber { get; set; }
        public string CustomerId { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
        public Order()
        {
            OrderDate = new DateTime();
            OrderItems = new List<OrderItem>();

        }
    }
}
