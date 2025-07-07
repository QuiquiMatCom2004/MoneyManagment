using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain.Abstractions
{
    public abstract class CashFlow : Entity, IMoneytisable
    {
        public DateTime StartDate { get; protected set; } = DateTime.UtcNow;
        public DateTime EndDate { get; protected set; } = DateTime.UtcNow;
        public Money TotalIncome { get; protected set; } = new Money(0, "USD");
        public Money TotalExpenses { get; protected set; } = new Money(0, "USD");
        public Money NetCashFlow => TotalIncome - TotalExpenses;
        protected List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public virtual void AddTransaction(Transaction transaction)
        {
            if(transaction.TransactionDate > EndDate || transaction.TransactionDate < StartDate)
                throw new TransactionNotValidException(transaction.TransactionDate);
            if (transaction.Validate())
                throw new TransactionNotValidException(transaction.Amount);
            Transactions.Add(transaction);
        }
        public abstract Money Calculate();
    }
}
