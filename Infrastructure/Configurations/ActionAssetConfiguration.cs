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
    public class ActionAssetConfiguration : IEntityTypeConfiguration<ActionAsset>
    {
        public void Configure(EntityTypeBuilder<ActionAsset> builder)
        {
            builder.Property(a => a.DividendYield)
                   .IsRequired();
        }
    }
}
