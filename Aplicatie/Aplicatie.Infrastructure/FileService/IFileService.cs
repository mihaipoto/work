using Aplicatie.Core.Mesaje;

namespace Aplicatie.Infrastructure.FileService
{
    public interface IFileService
    {
        void Receive(CerereListeazaFisiereleDinDirector message);
    }
}