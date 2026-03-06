using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModularCommerce.Domain.Repositories;
using ModularCommerce.Infrastructure.Persistence;
using ModularCommerce.Infrastructure.Repositories;
using ModularCommerce.Infrastructure.BackgroundServices;

namespace ModularCommerce.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        // DbContext + SQL Server
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Repositorios
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        // Worker
        services.AddHostedService<OutboxWorker>();

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}