using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noums_eCommerce.Areas.AdminNoums.ViewsModels
{
    public class PicturesVM
    {
        public Picture Picture { get; set; }
        public IEnumerable<Picture> Pictures { get; set; }
    }
}
