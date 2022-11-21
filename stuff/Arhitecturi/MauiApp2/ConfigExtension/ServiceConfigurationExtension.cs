using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigExtension;

public static class ServiceConfigurationExtension
{
    public static IServiceCollection AddMyLibraryService(
      this IServiceCollection services)
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddJsonFile("json1.json", optional: false, reloadOnChange: true)
            .Build();

        CevaService cevaService = new CevaService();
        services.AddSingleton(cevaService);

        //services.Configure<SettingsOptionsJson>(name:nameof(SettingsOptionsJson),config.GetSection(nameof(SettingsOptionsJson)));
        services.AddOptions<SettingsOptionsJson>(name: nameof(SettingsOptionsJson)).Configure(options =>
        {
        }).Bind(config.GetSection(nameof(SettingsOptionsJson)));
        // Register lib services here...
        // services.AddScoped<ILibraryService, DefaultLibraryService>();

        return services;
    }
}