using Aplicatie.Core.Modele;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie.Core.Mesaje;

public class CerereListeazaFisiereleDinDirector : AsyncRequestMessage<RaspunsListeazaFisiereleDinDirector>
{
    public string CaleDirector { get; set; }
}

