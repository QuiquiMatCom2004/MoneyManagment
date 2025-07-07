using Domain.Abstractions;
using Domain.Exceptions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ActionAsset : Asset
    {
        public decimal DividendYield { get; set; } // Percentage of dividend yield
        public ActionAsset(string name, Money value, DateTime dateAcquired, decimal dividendYield) : base(name, value, dateAcquired)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }
            if (value.Amount < 0)
            {
                throw new MoneyNotValidException(value);
            }
            if (dateAcquired > DateTime.Now)
            {
                throw new DateTimeNotValidException(dateAcquired);
            }
            if (dividendYield < 0)
            {
                throw new ArgumentException("Dividend yield cannot be negative.", nameof(dividendYield));
            }

            DividendYield = dividendYield;
        }

        public override Money Calculate()
        {
            return new Money(Value.Amount * DividendYield / 100, Value.Currency);
        }
    }
}
