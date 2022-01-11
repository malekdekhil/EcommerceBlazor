using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class Picture
    {
        public int IdPictures { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UrlPicture { get; set; }
        public Product Product { get; set; }
        public int IdProduct_Fk { get; set; }

       
    }
}
