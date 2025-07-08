using Domain.Entities.Liabilitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class FixedExpensesLiabilityConfiguration : IEntityTypeConfiguration<Domain.Entities.Liabilitys.FixedExpensesLiability>
    {
        public void Configure(EntityTypeBuilder<FixedExpensesLiability> builder)
        {
            builder.OwnsOne(e => e.Beneficts, benefictsBuilder =>
            {
                benefictsBuilder.Property(m => m.Amount)
                    .HasColumnName("BenefictAmount")
                    .IsRequired();

                benefictsBuilder.Property(m => m.Currency)
                    .HasColumnName("BenefictCurrency")
                    .HasMaxLength(3)
                    .IsRequired();
            });
        }
    }
}
