using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("TbCatgories");
            builder.HasKey(a => a.IdCategory);
            builder.Property(a => a.Description);
            builder.Property(a => a.SeoNameCategory);
            builder.Property(a => a.CategoryName);
             
        }
    }
}
