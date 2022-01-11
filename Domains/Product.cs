using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class Product
    {
    
        public int IdProduct { get; set; }
        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Nom de l'article")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Nom de réferencement")]
        public string SeoName { get; set; }
        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Prix d'achat")]
        [Column(TypeName = "decimal(8,2)")]
        [Range(1, 99999.99, ErrorMessage = "Le champ {0} doit être compris entre 1 et 99999.99")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Non valide ex 123456.12")]
        public decimal PurchasePrice { get; set; }
        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Prix de vente")]
        [Column(TypeName = "decimal(8,2)")]
        [Range(1, 99999.99, ErrorMessage = "Le champ {0} doit être compris entre 1 et 99999.99")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Non valide ex 123456.12")]
        public decimal SalesPrice { get; set; }
        [Display(Name = "Promotion")]
        public bool InPromo { get; set; }
        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Courte description")]
        public string ShortDescription { get; set; }
        [Display(Name = "Longue description")]

        public string LongDescription { get; set; }
        [Display(Name = "lien de l'image")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Quantité")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "TVA")]
        public decimal Tva { get; set; }
         [Display(Name = "Prix d'envoi")]
        public decimal ShippingPrice{ get; set; }
         [Display(Name = "Date de création")]
        public DateTime CreationDate { get; set; }
        public Category Category { get; set; }
        public int IdCategory_Fk { get; set; }
        public IList<Picture> Pictures { get; set; }
        public IList<Opinion> Opinions { get; set; }
         public Product()
        {
            CreationDate = new DateTime();
            Opinions = new List<Opinion>();
            Pictures = new List<Picture>();
         }
    }
}
