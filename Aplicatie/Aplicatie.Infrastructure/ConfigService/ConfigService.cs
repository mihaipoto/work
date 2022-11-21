using Aplicatie.Core.Modele;
using Microsoft.Extensions.Configuration;

namespace Aplicatie.Infrastructure.Services;

/*
       The main Math class
       Contains all methods for performing basic math functions
 */

/// <include file='documentatieCodInfrastructure.xml' path='docs/members[@name="math"]/Math/*'/>
public class ConfigService
{
    private SettingsConfig _settingsConfig = new();

    public ConfigService()
    {
        CitesteConfiguratie();
    }

    private void CitesteConfiguratie()
    {
        try
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("Config.json", optional: false, reloadOnChange: true)
                .Build();

            config.GetSection(nameof(SettingsConfig)).Bind(_settingsConfig, config =>
            {
                //config.ErrorOnUnknownConfiguration = true;
            });
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}