using Application.Mappers;
using Domain.Abstractions;
using Domain.Entities.Liabilitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Create.Liability
{
    public class LiabilityCommandHandler (ILiabilityServiceCreate service, IUnitOfWork work): ICommandHandler<LiabilityCommand, LiabilityDto>
    {
        private readonly ILiabilityServiceCreate _service = service;
        private readonly IUnitOfWork _work = work;
        async Task<LiabilityDto> ICommandHandler<LiabilityCommand, LiabilityDto>.ExecuteAsync(LiabilityCommand command, CancellationToken ct)
        {
            Domain.Abstractions.Liability liability = null;
            switch(command.Category.ToLiabilityCategory())
            {
                case LiabilityCategorys.CreditCard:
                    liability = _service.CreditCardLiability(command);
                    var repo1 = _work.GetRepository<CreditCardLiability>();
                    await repo1.AddAsync(liability as CreditCardLiability);
                    await _work.SaveChangesAsync();
                    return await Task.FromResult(liability.ToLiabilityDto());
                case LiabilityCategorys.Loan:
                    liability = _service.LoanLiability(command);
                    var repo2 = _work.GetRepository<LoansLiability>();
                    await repo2.AddAsync(liability as LoansLiability);
                    await _work.SaveChangesAsync();
                    return await Task.FromResult(liability.ToLiabilityDto());
                case LiabilityCategorys.FixedExpenses:
                    liability = _service.FixedExpensesLiability(command);
                    var repo3 = _work.GetRepository<FixedExpensesLiability>();
                    await repo3.AddAsync(liability as FixedExpensesLiability);
                    await _work.SaveChangesAsync();
                    return await Task.FromResult(liability.ToLiabilityDto());
                default:
                    throw new ArgumentException("Invalid liability category", nameof(command.Category));
            }
        }
    }
}
