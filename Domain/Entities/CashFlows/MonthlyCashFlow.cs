using Domain.Abstractions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CashFlows
{
    public class MonthlyCashFlow : CashFlow
    {
        public MonthlyCashFlow(string Currency, DateTime StartDate, DateTime EndDate) : base(StartDate,EndDate)
        {
            TotalExpenses = new Money(0, Currency);
            TotalIncome = new Money(0, Currency);
        }
        public override Money Calculate()
        {
            TotalIncome = new Money(0, TotalIncome.Currency);
            TotalExpenses = new Money(0,TotalExpenses.Currency);
            foreach(var transaction in Transactions)
            {
                switch (transaction.Type)
                {
                    case TransactionType.Income:
                        TotalIncome += transaction.Amount;
                        break;
                    case TransactionType.Expense:
                    case TransactionType.Investment:
                    case TransactionType.Amotization:
                    case TransactionType.Withdrawal:
                        TotalExpenses += transaction.Amount;
                        break;
                    default: continue;
                }
            }
            return NetCashFlow;
        }
    }
}
