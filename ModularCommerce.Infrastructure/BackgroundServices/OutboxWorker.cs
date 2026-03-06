using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModularCommerce.Infrastructure.Persistence;

namespace ModularCommerce.Infrastructure.BackgroundServices;

public class OutboxWorker : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public OutboxWorker(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var pendingEvents = await dbContext.OutboxMessages
                .Where(x => x.ProcessedOn == null)
                .OrderBy(x => x.OccurredOn)
                .ToListAsync(stoppingToken);

            foreach (var message in pendingEvents)
            {
                try
                {
                    Console.WriteLine($"Procesando evento {message.Type}: {message.Content}");

                    message.ProcessedOn = DateTime.UtcNow;
                }
                catch (Exception ex)
                {
                    message.Error = ex.Message;
                }
            }

            await dbContext.SaveChangesAsync(stoppingToken);

            await Task.Delay(5000, stoppingToken);
        }
    }
}