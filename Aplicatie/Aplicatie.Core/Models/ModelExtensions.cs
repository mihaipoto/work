using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Aplicatie.Core.Models;

public static class ModelExtensions
{
    public static List<TItemDest> MapList<TItemSursa, TItemDest>(this List<TItemDest> listaDestinatie, List<TItemSursa> listaSursa, Func<TItemSursa, TItemDest> creator)
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
    
    public static List<TItem> MapList<TItem>(this List<TItem> listaDestinatie, List<TItem> listaSursa)
    {
        try
        {
            listaDestinatie.AddRange(listaSursa);
            return listaDestinatie;
        }
        catch (Exception ex)
        {

            throw;
        }
        

        
    }

    public static readonly JsonSerializerOptions CustomJsonSerializerOptions = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin)
    };

    public static void SaveAppConfigConfiguration(this AppConfig configuratie)
    {
        StringBuilder json = new();

        json.Append(JsonSerializer.Serialize(
           new Dictionary<string, AppConfig>() { { nameof(AppConfig), (AppConfig)configuratie } }, CustomJsonSerializerOptions));

        File.WriteAllText(configuratie.GeneralConfiguration.ConfigFilePath, json.ToString());
        json.Clear();
    }


    public static string HashSHA512(this string toEncrypt)
    {
        byte[] toEncryptBytes = Encoding.UTF8.GetBytes(toEncrypt);
        byte[] encryptedBytes;

        using var hashAlgoritm = SHA512.Create();
        encryptedBytes = hashAlgoritm.ComputeHash(toEncryptBytes);

        return Convert.ToBase64String(encryptedBytes);
    }
}