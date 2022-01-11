using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("TbOrders");
            builder.HasKey(a => a.IdOrder);
            builder.Property(a => a.OrderDate);
            builder.Property(a => a.OrderTotal);
            builder.Property(a => a.Status);
            builder.Property(a => a.TrakingNumber);
            builder.Property(a => a.CustomerId);
         }
    }
}
