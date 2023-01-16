using Aplicatie.Core.Services;
using Microsoft.Extensions.DependencyInjection;


namespace Aplicatie.Core;

public static class ServiceConfigurationExtension
{
    public static IServiceCollection AddCoreServices(
      this IServiceCollection services)
    {

        services.AddSingleton<FluxManager>();
      

        return services;
    }
} 