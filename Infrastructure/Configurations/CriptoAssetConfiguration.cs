using Domain.Entities.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class CriptoAssetConfiguration : IEntityTypeConfiguration<Domain.Entities.Assets.CriptoAsset>
    {
        public void Configure(EntityTypeBuilder<CriptoAsset> builder)
        {
            builder.Property(c => c.MarketCap)
                   .IsRequired();
        }
    }
}
