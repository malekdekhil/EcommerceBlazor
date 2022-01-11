using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Interfaces
{
   public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        ValueTask<TEntity> GetByIdAsync(int id);
        void Remove(TEntity entity);
        Task AddAsync(TEntity entity);
    
    
    }
}
