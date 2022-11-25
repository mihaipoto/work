namespace Aplicatie.Core.Modele;

public sealed class AppConfig : ConfiguratieObiect
{
    public string ModDeLucru { get; set; }

    public IEnumerable<string> ModuriDeLucruPosibile { get; set; }
}

