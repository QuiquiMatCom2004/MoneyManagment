using Domain.Exceptions;

namespace Domain.ValueObjects;

public class Money
{
    public decimal Amount { get; }
    public string Currency { get; }
    public Money(decimal amount, string currency)
    {
        if (string.IsNullOrWhiteSpace(currency))
        {
            throw new ArgumentException("Currency cannot be null or empty.", nameof(currency));
        }
        if (amount < 0)
        {
            throw new MoneyNotValidException(amount,currency);
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