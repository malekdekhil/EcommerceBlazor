using Business_Logic.Interfaces;
using Business_Logic.Repositories;
using Data;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkManager
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext db;
        private IProductRepository _Products;
        private IPictureRepository _Pictures;
        private IOpinionRepository _Opinions;
        private IRepository<Category> _Categories;
        private IRepository<Order> _Orders;
        private IRepository<OrderItem> _OrderItems;
        private IRepository<Provider> _Providers;
        private IRepository<UserTmp> _UserTmp;
        public UnitOfWork(AppDbContext db)
        {
            this.db = db;
        }
        
        public IProductRepository Products => _Products = _Products ?? new ProductRepository(db);
        public IRepository<Category> Categories => _Categories = _Categories ?? new Repository<Category>(db);
        public IOpinionRepository Opinions => _Opinions = _Opinions ?? new  OpinionRepository(db);
        public IRepository<Order> Orders => _Orders = _Orders ?? new Repository<Order>(db);
        public IRepository<OrderItem> OrderItems => _OrderItems = _OrderItems ?? new Repository<OrderItem>(db);
        public IPictureRepository Pictures => _Pictures = _Pictures ?? new PictureRepository(db);
        public IRepository<Provider> Providers => _Providers = _Providers ?? new Repository<Provider>(db);
        public IRepository<UserTmp> UserTmp => _UserTmp = _UserTmp ?? new Repository<UserTmp>(db);

        public async Task<int> CommitAsync()
        {
            return await db.SaveChangesAsync();
        }

        public void Dispose()
        {
          db.Dispose();
        }
    }
}
