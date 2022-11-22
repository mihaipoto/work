using Aplicatie.Core.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie.Core.Mesaje;

public abstract class BaseResponse
{
    public bool Rezultat { get; set; } = true;
    public List<Exception> ListaExceptii { get; set; } = new();

}

public class RaspunsListeazaFisiereleDinDirector : BaseResponse
{
    public List<FileModel> ListaFisiere { get; set; } = new();
}
