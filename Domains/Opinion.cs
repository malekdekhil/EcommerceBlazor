using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class Opinion
    {
        public int IdOpinion { get; set; }

        public string Commentaire { get; set; }
        [Required(ErrorMessage = "champ requis")]
        public double Note { get; set; }
        public string UserName { get; set; }
        public Product Product { get; set; }
        public int IdProduct_Fk { get; set; }

    }
}
