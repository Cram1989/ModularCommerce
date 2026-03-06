namespace ModularCommerce.Domain.Events;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}