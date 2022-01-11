using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Interfaces
{
   public interface IPictureRepository: IRepository<Picture>
    {
        Task<Picture> GetByName(string Name); 
    }
}
