using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class MoneyNotValidException : Exception
    {
        public MoneyNotValidException() : base("The money value is not valid.")
        {
        }
        public MoneyNotValidException(string message) : base(message)
        {
        }
        public MoneyNotValidException(Money money)
            : base($"The money value '{money.Amount}' with currency '{money.Currency}' is not valid.")
        {
        }
        public MoneyNotValidException(decimal amount, string currency)
            : base($"The money value '{amount}' with currency '{currency}' is not valid.")
        {
        }
    }
}
