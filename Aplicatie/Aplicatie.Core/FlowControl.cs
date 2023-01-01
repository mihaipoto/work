
using Aplicatie.Core.Contracts;
using Aplicatie.Core.Mesaje;
using Aplicatie.Core.Modele;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Options;

namespace Aplicatie.Core;

public class FlowControl
{
    private readonly IDateTimeProvider _timeProvider;
    private readonly ILoggerService _loggerService;
    private AppConfig _appConfig;

    public FlowControl(
        IDateTimeProvider timeProvider,
        ILoggerService loggerService,
        IOptionsMonitor<AppConfig> optionsMonitor
        )
    {
        
        _timeProvider = timeProvider;
        _loggerService = loggerService;
        _appConfig = new AppConfig(optionsMonitor.CurrentValue);

        optionsMonitor.OnChange(optiuniNoi =>
        {
            _appConfig = new AppConfig(optiuniNoi);
        });
       
        //WeakReferenceMessenger.Default.RegisterAll(this);
        
    }




  
   

  
}

