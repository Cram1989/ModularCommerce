namespace ModularCommerce.Domain.ValueObjects;

public record Money(decimal Amount, string Currency)
{
    public static Money Eur(decimal amount) => new(amount, "EUR");
}
