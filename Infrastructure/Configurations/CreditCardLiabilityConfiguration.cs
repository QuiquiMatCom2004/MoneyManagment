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
    public class CreditCardLiabilityConfiguration : IEntityTypeConfiguration<Domain.Entities.Liabilitys.CreditCardLiability>
    {
        public void Configure(EntityTypeBuilder<CreditCardLiability> builder)
        {
            builder.Property(e => e.InterestRate)
                .HasColumnName("InterestRate")
                .IsRequired();
            builder.Property(e => e.MinimumPaymentPercentage)
                .HasColumnName("MinimumPaymentPercentage")
                .IsRequired();
        }
    }
}
