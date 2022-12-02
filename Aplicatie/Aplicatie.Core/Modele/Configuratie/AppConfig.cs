using Aplicatie.Core.Contracts;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Aplicatie.Core.Modele;

public sealed class AppConfig : IConfiguratieObiect
{
    //public AppConfig(IDateTimeProvider dateTimeProvider)
    //{
    //    _dateTimeProvider = dateTimeProvider;
    //}
    public string ModDeLucru { get; set; }

    public IEnumerable<string> ModuriDeLucruPosibile { get; set; }
    public DateTime LastModified { get ; set ; }
    public string FilePath { get ; set ; }

   
    //private readonly IDateTimeProvider _dateTimeProvider;

   
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

