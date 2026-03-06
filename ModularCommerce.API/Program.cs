using ModularCommerce.Infrastructure.BackgroundServices;
using ModularCommerce.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' no está configurada.");
}

builder.Services.AddInfrastructure(connectionString);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddHostedService<OutboxWorker>();

builder.Services.AddApplication();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseSwagger();

app.UseSwaggerUI();

