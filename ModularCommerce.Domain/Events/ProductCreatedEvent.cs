using ModularCommerce.Domain.Entities;
using MediatR;

namespace ModularCommerce.Domain.Events;

public class ProductCreatedEvent : INotification, IDomainEvent
{
    public Product Product { get; }

    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public ProductCreatedEvent(Product product)
    {
        Product = product;
    }
}