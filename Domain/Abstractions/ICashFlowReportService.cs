using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface ICashFlowReportService
    {
        Task<CashFlow> GetMonthlyReportAsync(int year, int month);
        Task<IEnumerable<CashFlow>> GetReportForRangeAsync(DateTime startDate, DateTime endDate);
        Task<Money> GetAverageNetCashFlowAsync(int year);
        Task<IEnumerable<CashFlow>> GetTopNetMonthsAsync(int count);
    }
}
