using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class Category
    {
        public int IdCategory { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }
 
        public string SeoNameCategory { get; set; }
        public IList<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
      
    }
}
