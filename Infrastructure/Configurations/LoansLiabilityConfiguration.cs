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
    public class LoansLiabilityConfiguration : IEntityTypeConfiguration<Domain.Entities.Liabilitys.LoansLiability>
    {
        public void Configure(EntityTypeBuilder<LoansLiability> builder)
        {
            builder.Property(e => e.InterestRate)
                .HasColumnName("InterestRate")
                .IsRequired();
            builder.Property(e => e.MonthsToPay)
                .HasColumnName("Month to Pay")
                .IsRequired();
        }
    }
}
