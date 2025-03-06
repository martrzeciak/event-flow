using EventFlow.API.ErrorHandling;

namespace EventFlow.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        // Add exception handlers
        services.AddExceptionHandler<ValidationExceptionHandler>();
        services.AddExceptionHandler<CustomExceptionHandler>();

        return services;
    }
}
