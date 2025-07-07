using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions;
public class CurrencyNotValidOperationException : Exception
{
    public string Currency1 { get; } = string.Empty;
    public string Currency2 { get; } = string.Empty;
    public CurrencyNotValidOperationException() : base("The currency is not valid for this operation.")
    {
    }
    public CurrencyNotValidOperationException(string message) : base(message)
    {

    }
    public CurrencyNotValidOperationException(string currency1, string currency2) : base($"The currencies '{currency1}' and '{currency2}' are not compatible for this operation.")
    {
        Currency1 = currency1;
        Currency2 = currency2;
    }
}
