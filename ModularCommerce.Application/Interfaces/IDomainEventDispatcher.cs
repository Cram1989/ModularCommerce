using ModularCommerce.Domain.Events;

namespace ModularCommerce.Application.Interfaces;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents);
}