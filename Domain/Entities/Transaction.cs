using Domain.Abstractions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transaction : Entity, IValidable
    {
        public DateTime TransactionDate { get; protected set; } = DateTime.UtcNow;
        public Money Amount { get; set; } = new Money(0, "USD");
        public Guid RelatedEntityId { get; set; } = Guid.Empty;
        public string Description { get; set; } = string.Empty;
        public TransactionType Type { get; set; } = TransactionType.None;

        public Transaction(DateTime transactionDate, Money amount, Guid relatedEntityId, string description, TransactionType type)
        {
            TransactionDate = transactionDate;
            Amount = amount;
            RelatedEntityId = relatedEntityId;
            Description = description;
            Type = type;
        }

        public virtual bool Validate()
        {
            if(TransactionDate > DateTime.UtcNow)
                return false;
            return true;
        }
    }
}