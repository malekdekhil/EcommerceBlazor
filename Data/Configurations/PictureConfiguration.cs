using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable("TbPictures");
            builder.HasKey(a=>a.IdPictures);
            builder.Property(a=>a.Name);
            builder.Property(a=>a.UrlPicture);
            builder.HasOne(a => a.Product).WithMany(a => a.Pictures).HasForeignKey(a=>a.IdProduct_Fk);

        }
    }
}
