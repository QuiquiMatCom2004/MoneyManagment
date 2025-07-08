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
    public class LiabilityConfiguration : IEntityTypeConfiguration<Domain.Abstractions.Liability>
    {
        public void Configure(EntityTypeBuilder<Liability> builder)
        {
            builder.UseTphMappingStrategy();

            builder.HasKey(l => l.Id);
            builder.OwnsOne(l => l.Value,
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
