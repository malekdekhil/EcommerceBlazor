using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class UserTmpConfiguration : IEntityTypeConfiguration<UserTmp>
    {
        public void Configure(EntityTypeBuilder<UserTmp> builder)
        {
            builder.ToTable("TbUsersTmp");
            builder.HasKey(a => a.IdUserTmp);
            builder.Property(a => a.FirstName);
            builder.Property(a => a.LastName);
            builder.Property(a => a.EmailTmp);
            builder.Property(a => a.Address);
            builder.Property(a => a.City);
            builder.Property(a => a.CodeZip);
            builder.Property(a => a.Country);

        }
    }
}
