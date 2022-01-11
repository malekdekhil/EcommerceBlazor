using Business_Logic.Interfaces;
using Data;
using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext Context
        {
            get { return db as AppDbContext; }
        }
        public ProductRepository(AppDbContext context) : base(context)
        { }
        public async Task<IEnumerable<Product>> GetAllInclude()
        {
            return await db.TbProducts.Include(a => a.Category).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllIncludeOpinions()
        {
            return await db.TbProducts.Include(a => a.Opinions).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllIncludePictures()
        {
            return await db.TbProducts.Include(a => a.Pictures).ToListAsync();
        }
        public async Task PicturePath(int idPicture, int idProduct)
        {
            var picture = await db.TbPictures.Where(a => a.IdProduct_Fk == idProduct && a.IdPictures == idPicture).FirstOrDefaultAsync();
            picture.Product.ImageUrl = "Pictures/" + picture.UrlPicture;

        }
    }
}
