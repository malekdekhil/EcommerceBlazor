using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Interfaces
{
   public interface IProductRepository:IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllInclude();
        Task<IEnumerable<Product>> GetAllIncludePictures();
        Task<IEnumerable<Product>> GetAllIncludeOpinions();
        Task PicturePath(int idPicture, int idProduct);

    }
}
