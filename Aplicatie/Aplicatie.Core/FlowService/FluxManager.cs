using Aplicatie.Core.Contracts;
using Aplicatie.Core.Models;
using Aplicatie.Core.Models.Configuratie;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Aplicatie.Core.Services;

public sealed class FluxManager

{
    private readonly IUsbService _usbService;
    private readonly IDateTimeProvider _timeProvider;
    private readonly ILoggerService _loggerService;
    private readonly IOptionsMonitor<AppConfig> _appConfigOptions;

    Flow _fluxCurent;

    

    public Workflow CurrentWorkflowConfiguration => _appConfigOptions.CurrentValue.WorkflowConfiguration;

    public event Action<Flow, Action> FlowCreated;
    public event Action FlowDistrus;
    public event Action<USBDeviceEvent>? UsbDeviceRemoved;
    public event Action<USBDeviceEvent>? UsbDeviceInserted;
   


    public FluxManager(
        IUsbService usbService,
        IDateTimeProvider timeProvider,
        ILoggerService loggerService,
        IOptionsMonitor<AppConfig> appConfigOptionsMonitor
        
        )
    {
        
        _timeProvider = timeProvider;
        _loggerService = loggerService;
        _appConfigOptions = appConfigOptionsMonitor;
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
        OnUsbDriveRemoved(obj);
        //Debug.WriteLine($"Removed {obj.ToString()}");
        if (_fluxCurent is not null)
        {
            Debug.WriteLine("A sfost scos stickul de flux");

            OnFluxDistrus();
        }
    }

    private void OnFluxDistrus()
    {
        Debug.WriteLine("flow distrus" + Thread.CurrentThread.ManagedThreadId);
        FlowDistrus?.Invoke();
        _fluxCurent = null;
    }

    void _usbService_UsbDeviceInserted1(USBDeviceEvent obj)
    {
        OnUsbDriveInserted(obj);
        //Debug.WriteLine($"Inserted {obj.ToString()}");
        Debug.WriteLine("Inserted");
        if (_fluxCurent is null)
        {
            CreateFlow(flowSettings: _appConfigOptions.CurrentValue.FlowListConfiguration.FirstOrDefault(), uSBDeviceEvent: obj);
            
        }
        else
        {
            Debug.WriteLine("a fost inserat un usb dar exista deja un flux");
        }
    }

    private void OnFlowCreated()
    {
        Debug.WriteLine("flow created" + Thread.CurrentThread.ManagedThreadId);
        FlowCreated?.Invoke(_fluxCurent,StartFlux);
    }

    private void StartFlux()
    {
        _fluxCurent.StartFlux();
    }

    public void CreateFlow(FlowItemSettings flowSettings, USBDeviceEvent uSBDeviceEvent)
    {
        _fluxCurent = new()
        {
            FlowConfig = flowSettings,
            EvenimentUSB = uSBDeviceEvent,
        };
        OnFlowCreated();
    }



    void OnUsbDriveInserted(USBDeviceEvent obj)
    {
        UsbDeviceInserted?.Invoke(obj);
    }

    void OnUsbDriveRemoved(USBDeviceEvent obj)
    {
        UsbDeviceRemoved?.Invoke(obj);
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

    public Workflow CurrentWorkflowSettings => _appConfigOptions.CurrentValue.WorkflowConfiguration;

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