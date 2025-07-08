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
    public class RealStateAssetConfiguration : IEntityTypeConfiguration<Domain.Entities.Assets.RealStateAsset>
    {
        public void Configure(EntityTypeBuilder<RealStateAsset> builder)
        {
            builder.OwnsOne(e => e.RentPrice, rentalIncome =>
            {
                rentalIncome.Property(r => r.Amount)
                             .HasColumnName("RentalIncomeAmount")
                             .IsRequired();
                rentalIncome.Property(r => r.Currency)
                             .HasColumnName("RentalIncomeCurrency")
                             .IsRequired();
            });
            builder.OwnsOne(e => e.ChoreExpenses, tax =>
            {
                tax.Property(t => t.Amount)
                    .HasColumnName("ChoreExpensesAmount")
                    .IsRequired();
                tax.Property(t => t.Currency)
                    .HasColumnName("ChoreExpensesCurrency")
                    .IsRequired();
            });
        }
    }
}
