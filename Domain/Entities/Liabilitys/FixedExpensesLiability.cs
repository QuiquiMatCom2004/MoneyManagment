using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Entities.Liabilitys
{
    public class FixedExpensesLiability : Liability
    {
        public Money Beneficts { get; set; }// Monthly benefits or income from the liability
        public FixedExpensesLiability(string name, Money value, DateTime dateIncurred, Money beneficts) 
            : base(name, value, dateIncurred)
        {
            Beneficts = beneficts;
            Categorys = LiabilityCategorys.FixedExpenses;
        }
        public FixedExpensesLiability(string name, Money value, DateTime dateIncurred) 
            : base(name, value, dateIncurred)
        {
            Beneficts = new Money(0,value.Currency);
        }
        public override Money Calculate()
        {
            return Value - Beneficts; // Calculate the net liability by subtracting benefits from the value
        }
    }
}
