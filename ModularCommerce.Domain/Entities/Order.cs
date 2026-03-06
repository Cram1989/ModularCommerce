using ModularCommerce.Domain.Common;

namespace ModularCommerce.Domain.Entities;

public class Order : Entity
{
    public Guid CustomerId { get; private set; }

    private readonly List<OrderItem> _items = new();

    public IReadOnlyCollection<OrderItem> Items => _items;

    public DateTime CreatedAt { get; private set; }

    private Order() { }

    public Order(Guid customerId)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        CreatedAt = DateTime.UtcNow;
    }

    public void AddItem(OrderItem item)
    {
        _items.Add(item);
    }
}