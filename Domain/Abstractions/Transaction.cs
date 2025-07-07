using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public abstract class Transaction : Entity, IValidable, IProcessable
    {
        public DateTime TransactionDate { get; protected set; } = DateTime.UtcNow;
        public Money Amount { get; set; } = new Money(0, "USD");
        public Guid RelatedEntityId { get; set; } = Guid.Empty;
        public string Description { get; set; } = string.Empty;
        public TransactionType Type { get; set; } = TransactionType.None;

        public abstract bool Process();

        public virtual bool Validate()
        {
            if(Amount.Amount < 0)
                return false;
            if(TransactionDate > DateTime.UtcNow)
                return false;
            return true;
        }
    }
}