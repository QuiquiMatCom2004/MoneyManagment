using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Abstractions
{
    public abstract class Asset : Entity, IMoneytisable
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public Money Value { get; private set; } = new Money(0, "USD"); // Default value, can be changed later

        public Money MonthlyIncome => Calculate();

        public DateTime DateAcquired { get; set; } = DateTime.Now;

        public AssetCategorys Category { get; set; } = AssetCategorys.Other;
        protected Asset(string name, Money value, DateTime dateAcquired)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }
            if (dateAcquired > DateTime.Now)
            {
                throw new DateTimeNotValidException(dateAcquired);
            }
            Id = Guid.NewGuid();
            Name = name;
            Value = value;
            DateAcquired = dateAcquired;
        }

        public abstract Money Calculate();

        public virtual void Revalue(decimal newValue)
        {
            if (newValue < 0)
            {
                throw new MoneyNotValidException(new Money(newValue,Value.Currency));
            }
            Value = new Money(newValue, Value.Currency);
        }
    }
}
