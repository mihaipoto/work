
using Aplicatie.Core.Models;
using Aplicatie.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;

namespace Aplicatie.Infrastructure;

public static class ServiceConfigurationExtension
{
    public static IServiceCollection AddInfrastructureService(
      this IServiceCollection services, ConfigurationManager configuration)
    {
        
        services.AddSingleton<ILoggerService, LoggerService>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IUsbService, UsbService>();

        configuration.Sources.Clear();
        configuration.AddJsonFile("""D:\work\Aplicatie\stuff\ConfigFiles\AppConfig.json""", optional: true, reloadOnChange: true);
        configuration.AddJsonFile("""D:\work\Aplicatie\stuff\ConfigFiles\LoggerServiceConfig.json""", optional: true, reloadOnChange: true);

        services.AddOptions<AppConfig>().Bind(configuration.GetSection(nameof(AppConfig)));

        


        return services;
    }
}