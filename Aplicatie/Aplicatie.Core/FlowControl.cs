
using Aplicatie.Core.Contracts;
using Aplicatie.Core.Mesaje;
using Aplicatie.Core.Modele;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Options;

namespace Aplicatie.Core;

public class FlowControl: 
    IRecipient<CerereModDeLucruActualDinConfiguratie>,
    IRecipient<CerereAppConfigDinConfiguratie>
{
    private readonly IDateTimeProvider _timeProvider;
    //private readonly IConfigService _configService;
    private readonly ILoggerService _loggerService;
    private readonly IOptionsMonitor<AppConfig> _optionsMonitor;

    public FlowControl(
        IDateTimeProvider timeProvider,
        //IConfigService configService,
        ILoggerService loggerService,
        IOptionsMonitor<AppConfig> optionsMonitor
        )
    {
        
        _timeProvider = timeProvider;
        _loggerService = loggerService;
        _optionsMonitor = optionsMonitor;
        //InitServices();
        WeakReferenceMessenger.Default.RegisterAll(this);
        
    }




    public void Receive(CerereModDeLucruActualDinConfiguratie message)
    {
        message.Reply(_optionsMonitor.CurrentValue.ModDeLucru);
    }

    public void Receive(CerereAppConfigDinConfiguratie message)
    {
        //_optionsMonitor.CurrentValue.ModDeLucru = "lalala";
        //ObiectConfiguratieExtension.SaveConfiguration(_optionsMonitor.CurrentValue);
        message.Reply(_optionsMonitor.CurrentValue);
        
        _loggerService.Logheaza_INFO("A fost cerut obiectul {AppConfig} cu valoarea {@ValoareAppConfig}", nameof(AppConfig), _optionsMonitor.CurrentValue);
    }

    //private void InitServices()
    //{
    //    try
    //    {
    //        _loggerService.InitLoggerService(_configService.LoggingConfig);
    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
        
    //}
}

