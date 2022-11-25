using Aplicatie.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicatie.Infrastructure;

public static class ServiceConfigurationExtension
{
    public static IServiceCollection AddInfrastructureService(
      this IServiceCollection services)
    {
        services.AddSingleton<IConfigService, ConfigService>();
        services.AddSingleton<ILoggerService, LoggerService>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}