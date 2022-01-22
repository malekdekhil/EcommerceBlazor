using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class UserTmp
    {
        public int IdUserTmp { get; set; }
        [Required(ErrorMessage = "champ requis")]
        [Display(Name = "Nom")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "champ requis")]
        [Display(Name = "Prénom")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "champ requis")]
        [Display(Name = "Adresse")]
        public string Address { get; set; }
        [Required(ErrorMessage = "champ requis")]
        [Display(Name = "Ville")]
        public string City { get; set; }
        [Required(ErrorMessage = "champ requis")]
        [Display(Name = "Code postal")]
        public string CodeZip { get; set; }
        [Required(ErrorMessage = "champ requis")]
        [Display(Name = "Pays")]
        public string Country { get; set; }
        [Required(ErrorMessage = "champ requis")]
        [Display(Name = "Email")]
        public string EmailTmp { get; set; }

    }
}
