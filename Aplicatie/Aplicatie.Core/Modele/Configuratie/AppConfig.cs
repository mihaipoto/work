using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Aplicatie.Core.Modele;

public record AppConfig
{
    public List<ModDeLucru> ModuriDeLucru { get; set; }

    
    public DateTime LastModified { get; set; }
    public string FilePath { get; set; }

    public List<FluxModel> Fluxuri { get; set; }

    public AppConfig()
    {
    }

    public AppConfig(AppConfig appConfig)
    {
        ModuriDeLucru = new();
        ModuriDeLucru.MapeazaLista<ModDeLucru, ModDeLucru>(appConfig.ModuriDeLucru, creator: m => new (m));
        Fluxuri= new();
        Fluxuri.MapeazaLista<FluxModel, FluxModel>(listaSursa: appConfig.Fluxuri, creator: f => new(f));
        LastModified = appConfig.LastModified;
        FilePath = appConfig.FilePath;
    }

    [JsonIgnore]
    public List<string> GetListaNumeModuriDeLucru => ModuriDeLucru.Select(m => m.Nume).ToList();

    [JsonIgnore]
    public string GetNumeModDeLucruActual => ModuriDeLucru.Where(m=> m.EsteActiv == true).Select(m => m.Nume).FirstOrDefault();
}

public class ModDeLucru
{
    public string Nume { get; set; }

    public bool EsteActiv { get; set; }

    public ModDeLucru()
    {

    }
    public ModDeLucru(ModDeLucru modDeLucru)
    {
        Nume= modDeLucru.Nume;
        EsteActiv = modDeLucru.EsteActiv;
    }

    public static ModDeLucru Create(ModDeLucru modDeLucru)
    {
        return new ModDeLucru(modDeLucru);
    }
}


    public class FluxModel
{
    public int IdFlux { get; set; }
    public List<Enumerabil> Enumerabile { get; set; }

    public FluxModel()
    {
    }

    public FluxModel(FluxModel flux)
    {
        IdFlux = flux.IdFlux;
        Enumerabile = new();
        Enumerabile.MapeazaLista<Enumerabil,Enumerabil>(
            listaSursa: flux.Enumerabile,
            creator: e => new Enumerabil(e));
    }
}

public class Enumerabil
{
    public string Nume { get; set; }

    public List<string> Valori { get; set; } 

    public Enumerabil()
    {
        Valori = new();
        Nume = string.Empty;
    }

    public Enumerabil(Enumerabil enumerabil)
    {
        Nume = enumerabil.Nume;
        Valori = new();
        Valori.MapeazaLista<string>(listaSursa: enumerabil.Valori);
    }
}

public static class ObiectConfiguratieExtension
{
    public static List<TItemDest> MapeazaLista<TItemSursa, TItemDest>(this List<TItemDest> listaDestinatie, List<TItemSursa> listaSursa, Func<TItemSursa, TItemDest> creator)
    {
        if (listaDestinatie is null)
            throw new ArgumentNullException(nameof(listaDestinatie));
        if (listaSursa is null)
            throw new ArgumentNullException(nameof(listaSursa));
        if (creator is null)
            throw new ArgumentNullException(nameof(creator));

        listaSursa.ForEach(enumerabil => listaDestinatie.Add(creator(enumerabil)));

        return listaDestinatie;
    }

    public static List<TItem> MapeazaLista<TItem>(this List<TItem> listaDestinatie, List<TItem> listaSursa)
    {
        if (listaDestinatie is null)
            throw new ArgumentNullException(nameof(listaDestinatie));
        if(listaSursa is null) 
            throw new ArgumentNullException(nameof(listaSursa));

        listaDestinatie.AddRange(listaSursa);
        return listaDestinatie;
    }

    private static readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin)
    };

    public static void SaveConfiguration(this AppConfig configuratie)
    {
        StringBuilder json = new();

        json.Append(JsonSerializer.Serialize(
           new Dictionary<string, AppConfig>() { { nameof(AppConfig), (AppConfig)configuratie } }, _options));

        File.WriteAllText(configuratie.FilePath, json.ToString());
        json.Clear();
    }
}