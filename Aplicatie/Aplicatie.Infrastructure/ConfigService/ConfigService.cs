using Aplicatie.Core.Contracts;
using Aplicatie.Core.Modele;
using Microsoft.Extensions.Configuration;

namespace Aplicatie.Infrastructure.Services;

/*
       Clasa 
 */

/// <include file='documentatieCodInfrastructure.xml' path='docs/members[@name="math"]/Math/*'/>
public class ConfigService : IConfigService
{
    private SettingsConfig _settingsConfig = new();

    public SettingsConfig SettingsConfig { get { return _settingsConfig; } }

    private IConfiguration _loggingConfig;

    public IConfiguration LoggingConfig
    {
        get { return _loggingConfig; }
    }

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

            _loggingConfig = new ConfigurationBuilder()
                .AddJsonFile("LoggerServiceConfig.json", optional: false, reloadOnChange: true)
                .Build();

        }
        catch (Exception ex)
        {
            throw;
        }
    }
}