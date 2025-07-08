using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class RawMaterialAssetConfiguration : IEntityTypeConfiguration<Domain.Entities.Assets.RawMaterialsAsset>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.Assets.RawMaterialsAsset> builder)
        {
            builder.OwnsOne(e => e.SellPrice, price =>
            {
                price.Property(p => p.Amount)
                     .HasColumnName("PriceAmount")
                     .IsRequired();
                price.Property(p => p.Currency)
                     .HasColumnName("PriceCurrency")
                     .IsRequired();
            });
        }
    }
}
