namespace Aplicatie.Core.Modele;

public class FileModel : IConfiguratieObiect
{
    public string NumeFisier { get; set; } = string.Empty;
    public string Extensie { get; set; } = string.Empty;
    public long Dimensiune { get; set; } = long.MinValue;
    public DateTime LastModified { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string FilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void SaveConfiguration()
    {
        throw new NotImplementedException();
    }
}