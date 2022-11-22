using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Aplicatie.Infrastructure.Services;
using Aplicatie.Core.Contracts;

namespace Aplicatie.Infrastructure;

public static class ServiceConfigurationExtension
{
    public static IServiceCollection AddInfrastructureService(
      this IServiceCollection services)
    {


        services.AddSingleton<IConfigService,ConfigService>();
        services.AddSingleton<ILoggerService, LoggerService>();

        return services;
    }
}