using Business_Logic.Interfaces;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkManager
{
   public interface IUnitOfWork:IDisposable
    {
        IRepository<Category> Categories { get; }
        IProductRepository Products { get; }
        IRepository<Opinion> Opinions { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderItem> OrderItems { get; }
        IPictureRepository Pictures { get; }
        IRepository<Provider> Providers { get; }
        IRepository<UserTmp> UserTmp { get; }
        Task<int> CommitAsync();

    }
}
