using Aplicatie.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicatie.Infrastructure;

public static class ServiceConfigurationExtension
{
    public static IServiceCollection AddInfrastructureService(
      this IServiceCollection services, ConfigurationManager configuration)
    {

        services.AddSingleton<ILoggerService, LoggerService>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IUsbService, UsbService>();


        services.AddHostedService<Muncitor>();




        return services;
    }
}