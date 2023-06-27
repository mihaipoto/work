using Aplicatie.Core.Contracts;
using Aplicatie.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Aplicatie.Core.Services;

public partial class FluxManager : ObservableObject

{
    private readonly IUsbService _usbService;
    private readonly IDateTimeProvider _timeProvider;
    private readonly ILogger _logger;
    private readonly IOptionsMonitor<AppConfig> _appConfigOptions;
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private FluxInLucru _fluxCurent;

    //public event Action<FluxInLucru, Action> FlowCreated;
    //public event Action FlowDistrus;
    //public event Action<USBDeviceEvent>? UsbDeviceRemoved;
    //public event Action<USBDeviceEvent>? UsbDeviceInserted;

    public FluxManager(
        IUsbService usbService,
        IDateTimeProvider timeProvider,
        ILogger<FluxManager> logger,
        IOptionsMonitor<AppConfig> appConfigOptionsMonitor,
        IServiceProvider serviceProvider

        )
    {
        _timeProvider = timeProvider;
        _logger = logger;
        _appConfigOptions = appConfigOptionsMonitor;
        _serviceProvider = serviceProvider;
        _usbService = usbService;
        InitializeUsbService();

        _appConfigOptions.OnChange(optiuniNoi =>
        {
            InitializeUsbService();
        });
    }

    private void InitializeUsbService()
    {
        _usbService.InitializeUSBService(_appConfigOptions.CurrentValue.UsbServiceConfiguration);
        _usbService.UsbDeviceInserted += _usbService_UsbDeviceInserted1;
        _usbService.UsbDeviceRemoved += _usbService_UsbDeviceRemoved1;
        InitUsbService(_appConfigOptions.CurrentValue.WorkflowConfiguration.UsbWatcher);
    }

    private void _usbService_UsbDeviceRemoved1(USBDeviceEvent obj)
    {
        //UsbDeviceRemoved?.Invoke(obj);

        //Debug.WriteLine($"Removed {obj.ToString()}");
        if (_fluxCurent is not null)
        {
            _logger.LogWarning("A fost scos stickul de flux.");

            OnFluxDistrus();
        }
    }

    //private void DisposeScopes()
    //{
    //    if (usbInsertedScope is not null)
    //    {
    //        usbInsertedScope.Dispose();
    //    }
    //    if (fluxCreatedScope is not null)
    //    {
    //        fluxCreatedScope.Dispose();
    //    }
    //}

    private void OnFluxDistrus()
    {
        //FlowDistrus?.Invoke();
        FluxCurent.Dispose();
        FluxCurent = null;
    }

    private void _usbService_UsbDeviceInserted1(USBDeviceEvent obj)
    {
        //UsbDeviceInserted?.Invoke(obj);

        if (FluxCurent is null)
        {
            CreateFlow(flowSettings: _appConfigOptions.CurrentValue.FlowListConfiguration.FirstOrDefault(), uSBDeviceEvent: obj);
            Task.Run(StartFlux);
        }
        else
        {
            _logger.LogWarning("A fost inserat un usb dar exista deja un flux");
        }
    }

    private void StartFlux()
    {
        FluxCurent.StartFlux();
        _logger.LogInformation("Flow started");
    }

    public void CreateFlow(FlowItemSettings flowSettings, USBDeviceEvent uSBDeviceEvent)
    {
        FluxCurent = new(_serviceProvider)
        {
            FlowConfig = flowSettings,
            EvenimentUSB = uSBDeviceEvent,
        };

        _logger.LogInformation("Flow created");
        //FlowCreated?.Invoke(_fluxCurent, StartFlux);
    }

    private void InitUsbService(bool usbWatcher)
    {
        if (usbWatcher) { _usbService.StartUsbListener(); }
        else { _usbService.StopUsbListener(); }
    }

    //public event Action<Flow>? FluxStarted;

    //public event Action<ScanResultModel, Action<bool>>? FlowScanned;

    //public event EventHandler<FlowClassifiedEventArgs>? FlowClassified;

    //public event EventHandler<FlowContainerCreatedEventArgs>? FlowContainerCreated;

    //private async Task OnFluxStarted(Flow flow)
    //{
    //    FluxStarted?.Invoke(flow);
    //    await ScanFlux();
    //}

    //private async Task FaContainere()
    //{
    //    for (int i = 0; i < 10; i++)
    //    {
    //        await Task.Delay(2000);
    //        FlowContainerCreated?.Invoke(this, new FlowContainerCreatedEventArgs(i.ToString()));
    //    }
    //}

    //private async Task ClasificaFlux()
    //{
    //    await Task.Delay(2000);
    //    FlowClassified?.Invoke(this, new FlowClassifiedEventArgs(new RezultatClasificare(true)));
    //}

    //private async Task ScanFlux()
    //{
    //    await Task.Delay(2000);
    //    var result = new ScanResultModel(Rezultat: true);
    //    OnFluxScanned(result);
    //}

    //private void OnFluxScanned(ScanResultModel result)
    //{
    //    if (CurrentWorkflowSettings.AVUserInput)

    //        FlowScanned?.Invoke(result, async (inputUtilizator) =>
    //        {
    //            if (CurrentWorkflowSettings.AVUserInput)
    //                if (inputUtilizator)
    //                {
    //                    await ClasificaFlux();
    //                }
    //                else
    //                {
    //                    //utilizatorul nu e ok
    //                }
    //            else await ClasificaFlux();
    //        });
    //}
}