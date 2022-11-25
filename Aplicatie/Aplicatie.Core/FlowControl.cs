
using Aplicatie.Core.Contracts;
using Aplicatie.Core.Mesaje;
using Aplicatie.Core.Modele;
using CommunityToolkit.Mvvm.Messaging;

namespace Aplicatie.Core;

public class FlowControl: 
    IRecipient<CerereModDeLucruActualDinConfiguratie>,
    IRecipient<CerereAppConfigDinConfiguratie>
{
    private readonly IDateTimeProvider _timeProvider;
    private readonly IConfigService _configService;
    private readonly ILoggerService _loggerService;

    public FlowControl(
        IDateTimeProvider timeProvider,
        IConfigService configService,
        ILoggerService loggerService
        )
    {
        ArgumentNullException.ThrowIfNullOrEmpty( nameof( timeProvider ) );
        ArgumentNullException.ThrowIfNullOrEmpty( nameof( configService ) );
        ArgumentNullException.ThrowIfNullOrEmpty( nameof( loggerService ) );
        _timeProvider = timeProvider;
        _configService = configService;
        _loggerService = loggerService;
        InitServices();
        WeakReferenceMessenger.Default.RegisterAll(this);
        
    }

    public void Receive(CerereModDeLucruActualDinConfiguratie message)
    {
        message.Reply(_configService.AppConfig.ModDeLucru);
    }

    public void Receive(CerereAppConfigDinConfiguratie message)
    {
        message.Reply(_configService.AppConfig);
        _loggerService.Logheaza_INFO("A fost cerut obiectul {AppConfig} cu valoarea {ValoareAppConfig}", nameof(AppConfig), _configService.AppConfig.ToString());
    }

    private void InitServices()
    {
        try
        {
            _loggerService.InitLoggerService(_configService.LoggingConfig);
        }
        catch (Exception)
        {

            throw;
        }
        
    }
}

