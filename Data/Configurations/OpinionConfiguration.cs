using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class OpinionConfiguration : IEntityTypeConfiguration<Opinion>
    {
        public void Configure(EntityTypeBuilder<Opinion> builder)
        {
            builder.ToTable("TbOpinions");
            builder.HasKey(a => a.IdOpinion);
            builder.Property(a => a.Commentaire);
            builder.Property(a => a.Note);
            builder.Property(a => a.UserName);
            builder.HasOne(a => a.Product).WithMany(a=>a.Opinions).HasForeignKey(a=>a.IdProduct_Fk);
        }
    }
}
