using ModularCommerce.Domain.Entities;

namespace ModularCommerce.Domain.Repositories;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id);

    Task AddAsync(Order order);
}