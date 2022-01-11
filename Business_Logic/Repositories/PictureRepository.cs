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
    public class PictureRepository : Repository<Picture>, IPictureRepository
    {
        private AppDbContext Context
        {
            get { return db as AppDbContext; }
        }
        public PictureRepository(AppDbContext context) :base(context)
        {

        }
        public async Task<Picture> GetByName(string Name)
        {
            return await  db.TbPictures.FirstOrDefaultAsync(a=>a.Name == Name);
             
        }
    }
}
