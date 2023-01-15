namespace Aplicatie.Core.Models;

public class Enumerabil
{
    public string Nume { get; set; }

    public List<string> Valori { get; set; } = new();

    public string RegexValidator { get; set; }

    public Enumerabil()
    {
       
    }

    public Enumerabil(Enumerabil enumerabil)
    {
        try
        {
            Nume = enumerabil.Nume;
            Valori = new();
            Valori.MapList<string>(listaSursa: enumerabil.Valori);
            RegexValidator = enumerabil.RegexValidator;
        }
        catch (Exception ex)
        {

            throw;
        }
        
    }
}
