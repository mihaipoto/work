namespace Aplicatie.Core.Modele;

public class FileModel : ConfiguratieObiect
{
    public string NumeFisier { get; set; } = string.Empty;
    public string Extensie { get; set; } = string.Empty;
    public long Dimensiune { get; set; } = long.MinValue;
}