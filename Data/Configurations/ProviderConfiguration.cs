using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("TbProviders");
            builder.HasKey(a => a.IdProvider);
            builder.Property(a => a.Adress);
            builder.Property(a => a.City);
            builder.Property(a => a.CodeZip);
            builder.Property(a => a.Country);
            builder.Property(a => a.DateOdPurchase);
            builder.Property(a => a.Email);
        }
    }
}
