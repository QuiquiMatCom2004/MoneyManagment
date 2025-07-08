using Domain.Abstractions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Assets
{
    public class CriptoAsset : Asset
    {
        public decimal MarketCap { get; set; } // Market capitalization of the cryptocurrency

        public CriptoAsset(string name, Money value, DateTime dateAcquired, decimal marketCap) 
            : base(name, value, dateAcquired)
        {
            if (marketCap < 0)
            {
                throw new ArgumentException("Market cap cannot be negative.", nameof(marketCap));
            }
            MarketCap = marketCap;
            Category = AssetCategorys.CriptoCurrency;
        }
        public override Money Calculate()
        {
            return new Money(Value.Amount * MarketCap / 100, Value.Currency);
        }
    }
}
