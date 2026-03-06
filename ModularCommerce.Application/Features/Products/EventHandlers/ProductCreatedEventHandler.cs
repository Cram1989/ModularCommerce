using MediatR;
using ModularCommerce.Domain.Events;

namespace ModularCommerce.Application.Features.Products.EventHandlers;

public class ProductCreatedEventHandler : INotificationHandler<ProductCreatedEvent>
{
    public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
    {

        Console.WriteLine($"Product created: {notification.Product.Name}");

        return Task.CompletedTask;
    }
}