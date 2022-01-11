using Data.Configurations;
using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace Data
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
    
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new OpinionConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());
            modelBuilder.ApplyConfiguration(new PictureConfiguration());
            base.OnModelCreating(modelBuilder);


        }
        public DbSet<Product> TbProducts { get; set; }
        public DbSet<Category> TbCategories { get; set; }
        public DbSet<Opinion> TbOpignions { get; set; }
        public DbSet<Order> TbOrders { get; set; }
        public DbSet<OrderItem> TbOrderItems { get; set; }
        public DbSet<Picture> TbPictures { get; set; }
        public DbSet<Provider> TbProviders { get; set; }
     }
}
