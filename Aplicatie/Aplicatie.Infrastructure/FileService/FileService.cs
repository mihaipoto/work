using Aplicatie.Core.Mesaje;
using Aplicatie.Core.Modele;
using CommunityToolkit.Mvvm.Messaging;

namespace Aplicatie.Infrastructure.FileService;

public class FileService : IRecipient<CerereListeazaFisiereleDinDirector>
{
    public void Receive(CerereListeazaFisiereleDinDirector message)
    {
        RaspunsListeazaFisiereleDinDirector rezultat = message.GetFilesFromDirectory();

        message.Reply(rezultat);
    }
}

public static class FileServiceExtensions
{
    public static RaspunsListeazaFisiereleDinDirector GetFilesFromDirectory(this CerereListeazaFisiereleDinDirector cerere)
    {
        RaspunsListeazaFisiereleDinDirector rezultat = new();
        try
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(cerere.CaleDirector);
            FileInfo[] fileInfoArray = directoryInfo.GetFiles();
            foreach (FileInfo fisier in fileInfoArray)
            {
                rezultat.ListaFisiere.Add(new FileModel()
                {
                    NumeFisier = fisier.Name,
                    Dimensiune = fisier.Length,
                    Extensie = fisier.Extension
                });
            }
        }
        catch (Exception ex)
        {
            rezultat.ListaExceptii.Add(ex);
            rezultat.Rezultat = false;
            return rezultat;
        }
        return rezultat;
    }
}