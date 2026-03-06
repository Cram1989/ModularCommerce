using ModularCommerce.Domain.ValueObjects;

namespace ModularCommerce.Domain.Entities;

public class OrderItem
{
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public Money UnitPrice { get; private set; } = new Money(0, "EUR");

    private OrderItem() { }

    public OrderItem(Guid productId, int quantity, Money unitPrice)
    {
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}