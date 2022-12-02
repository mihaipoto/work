namespace Aplicatie.Core.Modele;

public interface IConfiguratieObiect
{
    DateTime LastModified { get; set; }

    string FilePath { get; set; }
    
}