using Aplicatie.Core.Modele;

namespace Aplicatie.Core.Mesaje;

//public abstract record BaseResponse(bool Rezultat, List<Exception> ListaExceptii);

public class RaspunsListeazaFisiereleDinDirector
{
    public bool Rezultat { get; set; }
    public List<Exception> ListaExceptii { get; set; } = new List<Exception>();
    public List<FileModel> ListaFisiere { get; set; } = new List<FileModel>();
}

public record RaspunsModDeLucruActualDinConfiguratie(string ModDeLucruActual);

public class RaspunsAppConfigDinConfiguratie
{
    public AppConfig AppConfig { get; set; }
}