namespace Domain.ValueObjects;

public struct Money
{
    public decimal Amount { get; }
    public string Currency { get; }
    public Money(decimal amount, string currency)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be negative.");
        }
        if (string.IsNullOrWhiteSpace(currency))
        {
            throw new ArgumentException("Currency cannot be null or empty.", nameof(currency));
        }
        Amount = amount;
        Currency = currency;
    }
    public override string ToString()
    {
        return $"{Amount}: {Currency}";
    }
    public static Money operator +(Money m1, Money m2)
    {
        if (m1.Currency != m2.Currency)
        {
            throw new InvalidOperationException("Cannot add Money with different currencies.");
        }
        return new Money(m1.Amount + m2.Amount, m1.Currency);
    }
    public static Money operator -(Money m1, Money m2)
    {
        if (m1.Currency != m2.Currency)
        {
            throw new InvalidOperationException("Cannot add Money with different currencies.");
        }
        return new Money(m1.Amount - m2.Amount, m1.Currency);
    }
}