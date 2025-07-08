using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class LiabilityDto :EntityDto
    {
        public string Name { get; set; } = string.Empty;
        public Money Value { get; set; } = new Money(0, "USD");
        public DateTime DateIncurred { get; set; } = DateTime.Now;
        public Money MonthlyExpense { get; set; } = new Money(0, "USD");
        public string Category { get; set; } = string.Empty;
    }
}
