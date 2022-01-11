using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class Provider
    {
        public int IdProvider { get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Info { get; set; }
        public string Adress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int CodeZip { get; set; }
        public DateTime DateOdPurchase { get; set; }
        public decimal Invoices { get; set; }
        public Provider()
        {
            DateOdPurchase = new DateTime();
        }
    }
}
