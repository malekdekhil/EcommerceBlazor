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
    public class OpinionRepository:Repository<Opinion>,IOpinionRepository
    {
        private AppDbContext Context
        {
            get { return db as AppDbContext; }
        }
        public OpinionRepository(AppDbContext context) : base(context){}

        public async Task<IEnumerable<Opinion>> GetOpinionsByProduct(int idProduct)
        {
            return await db.TbOpignions.Where(a=>a.IdProduct_Fk == idProduct).ToListAsync();
        }
    }
}
