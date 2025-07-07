using Domain.ValueObjects; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class TransactionNotValidException : Exception
    {
        public DateTime _date = DateTime.UtcNow;
        public Money Money { get; set; } = new Money(0, "USD");
        public TransactionNotValidException() : base("The transaction is not Valid")
        {

        }
        public TransactionNotValidException(DateTime date) : base($"The transaction date {date} is not valid")
        {
            _date = date;
        }
        public TransactionNotValidException(Money money) : base($"the mount {money.Amount} its not valid")
        {
            Money = money;
        }
    }
}
