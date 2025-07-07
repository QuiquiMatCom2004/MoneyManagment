using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class DateTimeNotValidException : Exception
    {
        public DateTimeNotValidException() : base("the proporcionate date its not valid in this context") { }
        public DateTimeNotValidException(DateTime date)
            : base($"the proporcionate date {date} its not valid in this context") { }
        public DateTimeNotValidException(DateTime StartDate, DateTime EndDate) : base($"the date {EndDate} cant be less of {StartDate }") { }
        public DateTimeNotValidException(DateTime date, DateTime start, DateTime end)
            : base($"the proporcionate date {date} is not valid in the range between {start} and {end}")
        {
        }
    }
}
