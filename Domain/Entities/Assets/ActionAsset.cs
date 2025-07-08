using Domain.Abstractions;
using Domain.Exceptions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Assets
{
    public class ActionAsset : Asset
    {
        public decimal DividendYield { get; set; } // Percentage of dividend yield

        private ActionAsset() : base(string.Empty, new Money(0, "USD"), DateTime.MinValue)
        {

        }
        public ActionAsset(string name, Money value, DateTime dateAcquired, decimal dividendYield) : base(name, value, dateAcquired)
        {
            if (dividendYield < 0)
            {
                throw new ArgumentException("Dividend yield cannot be negative.", nameof(dividendYield));
            }
            Category = AssetCategorys.Actions;

            DividendYield = dividendYield;
        }

        public override Money Calculate()
        {
            return new Money(Value.Amount * DividendYield / 100, Value.Currency);
        }
    }
}
