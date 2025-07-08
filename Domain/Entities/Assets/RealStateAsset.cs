using Domain.Abstractions;
using Domain.ValueObjects;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Assets
{
    public class RealStateAsset : Asset
    {
        public Money RentPrice { get; set; } // Monthly rent price of the real estate asset
        public Money ChoreExpenses { get; set; } // Monthly expenses for maintenance and chores 

        public RealStateAsset(string name, Money value, DateTime dateAcquired, Money rentPrice, Money choreExpenses) 
            : base(name, value, dateAcquired)
        {
            RentPrice = rentPrice;
            ChoreExpenses = choreExpenses;
            Category = AssetCategorys.RealEstate;
        }

        public override Money Calculate()
        {
            if(RentPrice.Currency != ChoreExpenses.Currency)
            {
                throw new CurrencyNotValidOperationException(RentPrice.Currency, ChoreExpenses.Currency);
            }
            return RentPrice - ChoreExpenses; // Calculate monthly profit or loss by subtracting chore expenses from rent price
        }
    }
}
