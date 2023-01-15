﻿using Aplicatie.Core.Contracts;
using Aplicatie.Core.Enums;
using Aplicatie.Core.Models;
using Aplicatie.Core.Models.Configuratie;
using Aplicatie.Core.Models.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Aplicatie.Core.Services;

public partial class FlowManagerService
{
    private readonly IUsbService _usbService;
    private readonly IDateTimeProvider _timeProvider;
    private readonly ILoggerService _loggerService;
    private readonly IOptionsMonitor<AppConfig> _appConfigOptions;


    Flow currentFlow;



    public AppConfig CurrentAppConfig
    {
        get
        {
            return _appConfigOptions.CurrentValue;
        }
    }

    public FlowManagerService(
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
        _usbService.UsbDeviceInserted += _usbService_UsbDeviceInserted;
        _usbService.UsbDeviceRemoved += _usbService_UsbDeviceRemoved;
        InitUsbService(_appConfigOptions.CurrentValue.WorkflowConfiguration.UsbWatcher);
    }


    private void InitUsbService(bool usbWatcher)
    {
        if (usbWatcher) { _usbService.StartUsbListener(); }
        else { _usbService.StopUsbListener(); }
    }

    private void _usbService_UsbDeviceRemoved(object? sender, UsbDeviceEventArgs e)
    {
        Debug.WriteLine("REMOVED");
        UsbDeviceRemoved?.Invoke(this, e);

    }

    public event Action<AppConfig> AppConfigChanged;
    public event Action<bool, Action<bool>> Eveniment;
    public event EventHandler<UsbDeviceEventArgs> UsbDeviceRemoved;
    public event EventHandler<UsbDeviceEventArgs> UsbDeviceInserted;
    public event EventHandler<LogMessageEventArgs<string>> LogErrorString;
    public event Action<Flow> FluxStarted;
    public event Action<ScanResult, Action<bool>> FlowScanned;
    public event EventHandler<FlowClassifiedEventArgs> FlowClassified;
    public event EventHandler<FlowContainerCreatedEventArgs> FlowContainerCreated;



    private async void _usbService_UsbDeviceInserted(object? sender, UsbDeviceEventArgs e)
    {

        UsbDeviceInserted?.Invoke(this, e);
        Eveniment?.Invoke(true, ProcesareRaspuns);
        Debug.WriteLine("Inserted");
        if (currentFlow is null)
        {
            currentFlow = new(
                flowItemSettings: _appConfigOptions.CurrentValue.FlowListConfiguration.FirstOrDefault(),
                initiator: e.UsbDevice);
            OnFluxStarted(currentFlow);


        }
        else
        {
            LogErrorString?.Invoke(this, new LogMessageEventArgs<string>("a fost inserat un usb dar exista deja un flux"));
        }
    }

    private void ProcesareRaspuns(bool raspuns)
    {
        Debug.WriteLine(raspuns.ToString());
    }



    private async Task StartFlux()
    {

    }

    public Workflow CurrentWorkflowSettings => _appConfigOptions.CurrentValue.WorkflowConfiguration;

    private async Task OnFluxStarted(Flow flow)
    {
        FluxStarted?.Invoke(flow);
        await ScanFlux();
    }



    private async Task FaContainere()
    {
        for (int i = 0; i < 10; i++)
        {

            await Task.Delay(2000);
            FlowContainerCreated?.Invoke(this, new FlowContainerCreatedEventArgs(i.ToString()));
        }


    }

    private async Task ClasificaFlux()
    {
        await Task.Delay(2000);
        FlowClassified?.Invoke(this, new FlowClassifiedEventArgs(new RezultatClasificare(true)));

    }

    private async Task ScanFlux()
    {
        await Task.Delay(2000);
        var result = new ScanResult(Rezultat: true);
        OnFluxScanned(result);
        
    }

    private void OnFluxScanned(ScanResult result)
    {
        if (CurrentWorkflowSettings.AVUserInput)

            FlowScanned?.Invoke(result, async (inputUtilizator) =>
            {
                if (CurrentWorkflowSettings.AVUserInput)
                    if (inputUtilizator)
                    {
                        await ClasificaFlux();
                    }
                    else
                    {
                        //utilizatorul nu e ok
                    }
                else await ClasificaFlux();
            });
    }
}

public class FlowEventArgs
{
    public Flow CurrentFlow { get; init; }

    public FlowEventArgs(Flow currentFlow)
    {
        CurrentFlow = currentFlow;
    }
}