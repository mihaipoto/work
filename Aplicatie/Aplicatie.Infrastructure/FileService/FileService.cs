
namespace Aplicatie.Infrastructure.Services;

public class FileService 
{
   
}

//public static class FileServiceExtensions
//{
//    public static RaspunsListeazaFisiereleDinDirector GetFilesFromDirectory(this CerereListeazaFisiereleDinDirector cerere)
//    {
//        RaspunsListeazaFisiereleDinDirector rezultat = new();
//        try
//        {
//            DirectoryInfo directoryInfo = new DirectoryInfo(cerere.CaleDirector);
//            FileInfo[] fileInfoArray = directoryInfo.GetFiles();
//            foreach (FileInfo fisier in fileInfoArray)
//            {
//                rezultat.ListaFisiere.Add(new FileModel()
//                {
//                    NumeFisier = fisier.Name,
//                    Dimensiune = fisier.Length,
//                    Extensie = fisier.Extension
//                });
//            }
//        }
//        catch (Exception ex)
//        {
//            rezultat.ListaExceptii.Add(ex);
//            rezultat.Rezultat = false;
//            return rezultat;
//        }
//        return rezultat;
//    }
//}