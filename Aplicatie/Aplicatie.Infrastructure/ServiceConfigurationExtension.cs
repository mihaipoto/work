using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Aplicatie.Infrastructure.Services;

namespace Aplicatie.Infrastructure;

public static class ServiceConfigurationExtension
{
    public static IServiceCollection AddMyLibraryService(
      this IServiceCollection services)
    {


        services.AddSingleton<ConfigService>();

        return services;
    }
}