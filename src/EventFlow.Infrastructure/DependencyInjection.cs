using EventFlow.Domain.Interfaces;
using EventFlow.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace EventFlow.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Add Redis
        services.AddSingleton<IConnectionMultiplexer>(config =>
        {
            var connString = configuration.GetConnectionString("Redis")
                ?? throw new Exception("Cannot get redis connection string");

            var redisConfig = ConfigurationOptions.Parse(connString, true);

            return ConnectionMultiplexer.Connect(redisConfig);
        });

        // add cart service
        services.AddSingleton<ICartService, CartService>();
        // add Stripe service
        services.AddScoped<IPaymentService, PaymentService>();

        return services;
    }
}
