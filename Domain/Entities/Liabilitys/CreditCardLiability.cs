using Domain.Abstractions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Liabilitys
{
    public class CreditCardLiability : Liability
    {
        public decimal InterestRate { get; private set; } // Annual interest rate as a percentage
        public decimal MinimumPaymentPercentage { get; private set; } // Minimum payment required each month 
        public CreditCardLiability(string name, Money value, DateTime dateAcquired, decimal interestRate, decimal minimumPaymentPercentage) 
            : base(name, value, dateAcquired)
        {
            if (interestRate < 0 || interestRate > 100)
                throw new ArgumentOutOfRangeException(nameof(interestRate), "Interest rate must be between 0 and 100.");
            if (minimumPaymentPercentage < 0 || minimumPaymentPercentage > 100)
                throw new ArgumentOutOfRangeException(nameof(minimumPaymentPercentage), "Minimum payment percentage must be between 0 and 100.");
            InterestRate = interestRate;
            MinimumPaymentPercentage = minimumPaymentPercentage;
            Categorys = LiabilityCategorys.CreditCard;
        }
        public override Money Calculate()
        {
            return new Money(Math.Round(Value.Amount * MinimumPaymentPercentage/100 + Value.Amount * InterestRate/100, 2) , Value.Currency);
        }
    }
}
