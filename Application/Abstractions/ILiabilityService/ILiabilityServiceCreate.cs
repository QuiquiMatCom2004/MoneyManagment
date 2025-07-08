using Application.Features.Create.Liability;
using Domain.Entities.Liabilitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.ILiabilityService
{
    public interface ILiabilityServiceCreate
    {
        CreditCardLiability CreditCardLiability(LiabilityCommand command);
        LoansLiability LoanLiability(LiabilityCommand command);
        FixedExpensesLiability FixedExpensesLiability(LiabilityCommand command);
    }
}
