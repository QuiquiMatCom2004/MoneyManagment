using Domain.Abstractions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Assets
{
    public class EmpresarialInvestmentAsset : Asset
    {
        public decimal PorcentageOfInvestment { get; set; } // Percentage of the investment in the business
        public Money AnualPerformace { get; set; } // Annual performance of the investment
        public EmpresarialInvestmentAsset(string name, Money value, DateTime dateAcquired, decimal porcentageOfInvestment, Money anualPerformace) 
            : base(name, value, dateAcquired)
        {
            if (porcentageOfInvestment < 0 || porcentageOfInvestment > 100)
            {
                throw new ArgumentException("Percentage of investment must be between 0 and 100.", nameof(porcentageOfInvestment));
            }
            PorcentageOfInvestment = porcentageOfInvestment;
            AnualPerformace = anualPerformace;
            Category = AssetCategorys.Investment;
        }
        public override Money Calculate()
        {
            return new Money((AnualPerformace.Amount * PorcentageOfInvestment / 100) /12, AnualPerformace.Currency);
        }
    }
}
