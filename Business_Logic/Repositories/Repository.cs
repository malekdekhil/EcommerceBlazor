using Business_Logic.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext db;

        public Repository(AppDbContext db)
        {
            this.db = db;   
        }
        public async Task AddAsync(TEntity entity)
        {
            await db.Set<TEntity>().AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
           return  await db.Set<TEntity>().ToListAsync();
        }

        public async ValueTask<TEntity> GetByIdAsync(int id)
        {
            return await db.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
        }
    }
}
