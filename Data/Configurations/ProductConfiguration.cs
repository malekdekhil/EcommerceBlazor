using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("TbProducts");
            builder.HasKey(a => a.IdProduct);
            builder.Property(a => a.ImageUrl);
            builder.Property(a => a.InPromo);
            builder.Property(a => a.LongDescription);
            builder.Property(a => a.Name);
            builder.Property(a => a.SeoName);
            builder.Property(a => a.PurchasePrice);
            builder.Property(a => a.ShippingPrice);
            builder.Property(a => a.Tva);
            builder.Property(a => a.ShortDescription);
            builder.Property(a => a.Quantity);
            builder.Property(a => a.SalesPrice);
            builder.Property(a => a.CreationDate);
            builder.Property(a => a.IdCategory_Fk);
            builder.HasOne(a => a.Category).WithMany(a => a.Products).HasForeignKey(a=>a.IdCategory_Fk);
 
        }
    }
}
