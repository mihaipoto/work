using Aplicatie.Core.Modele;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Aplicatie.Core.Mesaje;

public class CerereListeazaFisiereleDinDirector : AsyncRequestMessage<RaspunsListeazaFisiereleDinDirector>
{
    public string CaleDirector { get; set; } = string.Empty;
}

public class CerereModDeLucruActualDinConfiguratie : AsyncRequestMessage<string>
{
}

public class CerereAppConfigDinConfiguratie : RequestMessage<AppConfig>
{
}