using Domain.ValueObjects;

namespace Domain.Abstractions
{
    public abstract class Asset : Entity, IMoneytisable
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public Money Value { get; private set; }

        public Money MonthlyIncome => Calculate();

        public DateTime DateAcquired { get; set; }

        protected Asset(string name, Money value, DateTime dateAcquired)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }
            if (value.Amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value cannot be negative.");
            }
            if (dateAcquired > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException(nameof(dateAcquired), "Date acquired cannot be in the future.");
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
                throw new ArgumentOutOfRangeException(nameof(newValue), "New value cannot be negative.");
            }
            Value = new Money(newValue, Value.Currency);
        }
    }
}
