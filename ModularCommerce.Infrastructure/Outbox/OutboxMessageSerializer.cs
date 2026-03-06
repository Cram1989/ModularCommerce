using System.Text.Json;

namespace ModularCommerce.Infrastructure.Outbox;

public static class OutboxMessageSerializer
{
    public static OutboxMessage Serialize(object domainEvent)
    {
        return new OutboxMessage
        {
            Id = Guid.NewGuid(),
            Type = domainEvent.GetType().Name,
            Content = JsonSerializer.Serialize(domainEvent),
            OccurredOn = DateTime.UtcNow
        };
    }
}