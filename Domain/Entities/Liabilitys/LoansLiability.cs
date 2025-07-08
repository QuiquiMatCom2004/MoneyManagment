using Domain.Abstractions;
using Domain.ValueObjects;
namespace Domain.Entities.Liabilitys
{
    public class LoansLiability : Liability
    {
        public decimal InterestRate { get; private set; } // Annual interest rate as a percentage
        public int MonthsToPay { get; private set; } // Total months to pay off the loan
        public LoansLiability(string name, Money value, DateTime dateIncurred, decimal interestRate, int monthsToPay) 
            : base(name, value, dateIncurred)
        {
            if (interestRate < 0 || interestRate > 100)
                throw new ArgumentOutOfRangeException(nameof(interestRate), "Interest rate must be between 0 and 100.");
            if (monthsToPay <= 0)
                throw new ArgumentOutOfRangeException(nameof(monthsToPay), "Months to pay must be greater than zero.");
            
            InterestRate = interestRate;
            MonthsToPay = monthsToPay;
            Categorys = LiabilityCategorys.Loan;
        }
        public override Money Calculate()
        {
            var factor = (decimal)Math.Pow(1 + (double)(InterestRate / 12m), MonthsToPay);
            return new Money(Value.Amount * (InterestRate / 12m) * factor / (factor - 1), Value.Currency);
        }
    }
}
