using Domain;
using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Abstractions;
public abstract class Liability : Entity, IMoneytisable
{
    public string Name { get; set; }
    public Money Value { get; protected set; }

    public Money MonthlyExpense => Calculate();

    public DateTime DateIncurred { get; set; }

    public Guid Id { get; protected set; }

    protected Liability(string name, Money Amount, DateTime incurred)
    {
        Id = Guid.NewGuid();
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }
        if (Amount.Amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(Amount), "Amount cannot be negative.");
        }
        if (incurred > DateTime.Now)
        {
            throw new ArgumentOutOfRangeException(nameof(incurred), "Date incurred cannot be in the future.");
        }
        DateIncurred = incurred;
        Name = name;
        Value = Amount;
    }

    public virtual void Amortize(decimal payment)
    {
        if (payment < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(payment), "Payment cannot be negative.");
        }
        Value = new Money(Math.Max(0, Value.Amount - payment), Value.Currency);
    }
    public abstract Money Calculate();
}