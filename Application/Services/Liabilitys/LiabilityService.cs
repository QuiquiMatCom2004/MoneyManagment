using Application.Features.Create.Liability;
using Domain.Entities.Liabilitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Liabilitys
{
    public class LiabilityService : ILiabilityServiceCreate
    {
        public CreditCardLiability CreditCardLiability(LiabilityCommand command)
        {
            return new CreditCardLiability(
                command.Name,
                new Domain.ValueObjects.Money(command.Amount, command.Currency),
                command.DueDate,
                command.InterestRate?? 0,
                command.MinimumPaymentPercentage ?? 0
                );
        }

        public FixedExpensesLiability FixedExpensesLiability(LiabilityCommand command)
        {
            if(command.Beneficts.HasValue)
            {
                return new FixedExpensesLiability(
                    command.Name,
                    new Domain.ValueObjects.Money(command.Amount, command.Currency),
                    command.DueDate,
                    new Domain.ValueObjects.Money(command.Beneficts.Value, command.Currency)
                );
            }
            return new FixedExpensesLiability(
                command.Name,
                new Domain.ValueObjects.Money(command.Amount, command.Currency),
                command.DueDate
            );
        }

        public LoansLiability LoanLiability(LiabilityCommand command)
        {
            return new LoansLiability(
                command.Name,
                new Domain.ValueObjects.Money(command.Amount, command.Currency),
                command.DueDate,
                command.InterestRate ?? 0,
                command.MonthToPay ?? 0
            );
        }
    }
}
