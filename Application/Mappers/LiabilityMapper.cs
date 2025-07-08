using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class LiabilityMapper
    {
        public static LiabilityDto ToLiabilityDto(this Domain.Abstractions.Liability liability)
        {
            return new LiabilityDto
            {
                id = liability.Id,
                Name = liability.Name,
                Value = liability.Value,
                DateIncurred = liability.DateIncurred,
                MonthlyExpense = liability.MonthlyExpense,
                Category = liability.Categorys.LiabilityToString()
            };
        }
    }
}
