using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.UseTphMappingStrategy();

            builder.HasKey(a => a.Id);

            builder.OwnsOne(a => a.Value, 
                money => 
                {
                    money.Property(m => m.Amount)
                        .HasColumnName("ValueAmount")
                        .IsRequired();
                    money.Property(m => m.Currency)
                        .HasColumnName("ValueCurrency")
                        .IsRequired();
                }
                );
        }
    }
}
