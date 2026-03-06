using ModularCommerce.Domain.Common;
using ModularCommerce.Domain.ValueObjects;

namespace ModularCommerce.Domain.Entities;

public class Product : Entity
{
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public Money Price { get; private set; }
    public int Stock { get; private set; }

    private Product() { }

    public Product(string name, string description, Money price, int stock)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }

    public void ReduceStock(int quantity)
    {
        if (Stock < quantity)
            throw new InvalidOperationException("Not enough stock");

        Stock -= quantity;
    }
}