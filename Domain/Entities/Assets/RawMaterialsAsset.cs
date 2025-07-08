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
    public class RawMaterialsAsset : Asset
    {

        public Money SellPrice { get; set; } // Price at which the raw material can be sold
        public RawMaterialsAsset(string name, Money value, DateTime dateAcquired, Money sell) : base(name, value, dateAcquired)
        {
            SellPrice = sell;
            Category = AssetCategorys.RawMaterial;
        }
        
        public override Money Calculate()
        {
            if(SellPrice.Currency != Value.Currency)
            {
                throw new CurrencyNotValidOperationException(SellPrice.Currency, Value.Currency);
            }
            return SellPrice - Value; // Calculate profit or loss by subtracting the value from the sell price
        }
    }
}
