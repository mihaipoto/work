using Aplicatie.Core.Contracts;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Aplicatie.Core.Modele;

public sealed class AppConfig : IConfiguratieObiect
{
   
    public string ModDeLucru { get; set; } = string.Empty;

    public List<string> ModuriDeLucruPosibile { get; set; } = new List<string>();
    public DateTime LastModified { get ; set ; } = new DateTime();
    public string FilePath { get ; set ; } = string.Empty;  


    //private readonly IDateTimeProvider _dateTimeProvider;

    public AppConfig()
    {

    }
    public AppConfig(AppConfig appConfig)
    {
        ModDeLucru= appConfig.ModDeLucru;
        ModuriDeLucruPosibile.Clear();
        ModuriDeLucruPosibile.AddRange(appConfig.ModuriDeLucruPosibile);
        LastModified = appConfig.LastModified;
        FilePath= appConfig.FilePath;
    }
   
}


public static class ObiectConfiguratieExtension
{
    private static readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin)
    };
    public static void SaveConfiguration(this IConfiguratieObiect configuratie)
    {
        StringBuilder json = new();

        switch(configuratie)
        {
            case AppConfig:
                json.Append(JsonSerializer.Serialize(
                   new Dictionary<string, AppConfig>() { { nameof(AppConfig) , (AppConfig) configuratie } }, _options));
                break;

        }

      

        
        File.WriteAllText(configuratie.FilePath, json.ToString());
        json.Clear();
    }
}

