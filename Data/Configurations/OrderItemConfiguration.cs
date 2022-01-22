using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("TbOrderItems");
            builder.HasKey(a => a.IdOrderItem);
            builder.Property(a => a.Price);
            builder.Property(a => a.Quantity);
            builder.Property(a => a.ProductName);
            builder.Property(a => a.OrderId);
            builder.Property(a => a.CustomerId);
            builder.Property(a => a.ProductId);
            builder.HasOne(a => a.Order).WithMany(a => a.OrderItems).HasForeignKey(a=>a.IdOrder_Fk);



        }
    }
}
