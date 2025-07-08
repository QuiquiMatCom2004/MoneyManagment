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
    public class EmpresarialInvestmentAssetConfiguration : IEntityTypeConfiguration<Domain.Entities.Assets.EmpresarialInvestmentAsset>
    {
        public void Configure(EntityTypeBuilder<EmpresarialInvestmentAsset> builder)
        {
            builder.Property(e => e.PorcentageOfInvestment)
                   .IsRequired();
            builder.OwnsOne(e => e.AnualPerformace, anualPerformace =>
                {
                    anualPerformace.Property(a => a.Amount)
                                   .HasColumnName("AnualPerformaceAmount")
                                   .IsRequired();
                    anualPerformace.Property(a => a.Currency)
                                   .HasColumnName("AnualPerformaceCurrency")
                                   .IsRequired();
                });
        }
    }
}
