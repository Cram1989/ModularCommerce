namespace ModularCommerce.Domain.ValueObjects;

public class Money
{
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency ?? throw new ArgumentNullException(nameof(currency));
    }

    private Money()
    {
        Currency = string.Empty;
    }

    public static Money Eur(decimal amount) => new Money(amount, "EUR");
    public static Money Usd(decimal amount) => new Money(amount, "USD");
}
