using Aplicatie.Core.Modele;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.FileIO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Aplicatie.Infrastructure.Services;


public class ConfigService : IConfigService, IDisposable
{
    private StringBuilder _pathConfig = new StringBuilder();

    private static readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin)
    };
    private readonly IDateTimeProvider _dateTimeProvider;
    private AppConfig _appConfig; 

    public AppConfig AppConfig => _appConfig;

    private IConfiguration _loggingConfig;

    public IConfiguration LoggingConfig => _loggingConfig;




    public ConfigService(IDateTimeProvider dateTimeProvider)
    {
        
        CitesteConfiguratie();
        _dateTimeProvider = dateTimeProvider;
        _appConfig = new();
    }

    private  void CitesteConfiguratie()
    {
        try
        {
            _pathConfig.Append("""D:\work\Aplicatie\stuff\ConfigFiles\AppConfig.json""");
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile(_pathConfig.ToString(), optional: false, reloadOnChange: true)
                .Build();
            _pathConfig.Clear();

            config.GetSection(nameof(AppConfig)).Bind(_appConfig, config =>
            {
                //config.ErrorOnUnknownConfiguration = true;
            });

            _pathConfig.Append("""D:\work\Aplicatie\stuff\ConfigFiles\LoggerServiceConfig.json""");
            _loggingConfig = new ConfigurationBuilder()
                .AddJsonFile(_pathConfig.ToString(), optional: false, reloadOnChange: true)
                .Build();
            _pathConfig.Clear();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void SalveazaConfiguratie(IConfiguratieObiect configuratieObiect)
    {
        switch(configuratieObiect) 
        {
            case Core.Modele.AppConfig:
                var json = JsonSerializer.Serialize(
                    new Dictionary<string, AppConfig>() { { nameof(Core.Modele.AppConfig), (AppConfig)configuratieObiect } }, _options);
                File.WriteAllText("""D:\work\Aplicatie\stuff\ConfigFiles\AppConfig.json""", json);
                break;
            
            default:
                throw new ArgumentOutOfRangeException(nameof(configuratieObiect));
        };
    }

    public void Dispose()
    {
        _pathConfig.Clear();
        _pathConfig = null;
        System.GC.Collect();
        
    }
}