using Aplicatie.Core.Models;
using Aplicatie.Core.Services;
using Aplicatie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Aplicatie.ViewModels;

public partial class StartViewModel : ObservableObject
{
    readonly IDialogService _dialogService;
    readonly INavigationService _navigationService;
    readonly FluxManager _flowManagerService;

    [ObservableProperty]
    AppConfig _appConfigObject;

    [ObservableProperty]
    bool _isBusy = false;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsFluxInLucru))]
    FlowVM _currentFlow;

    [ObservableProperty]
    string _eveniment;

   
    public bool IsFluxInLucru => CurrentFlow is null ? false : true;


    [ObservableProperty]
    bool _isFluxExpanded;


    public StartViewModel(
        IDialogService dialogService,
        INavigationService navigationService,
        IOptionsMonitor<AppConfig> appConfigOptionsMonitor,
        FluxManager fluxManager
        )
    {
        _dialogService = dialogService;
        _navigationService = navigationService;
        _flowManagerService= fluxManager;
        AppConfigObject = appConfigOptionsMonitor.CurrentValue;

        appConfigOptionsMonitor.OnChange((optiuniNoi) =>
        {
            OnAppConfigObjectChanged(AppConfigObject);
        });
        SubscribeToEvents();

    }

    void SubscribeToEvents()
    {
        _flowManagerService.UsbDeviceInserted += _flowManagerService_UsbDeviceInserted;
        _flowManagerService.UsbDeviceRemoved += _flowManagerService_UsbDeviceRemoved;
        _flowManagerService.FlowCreated += _flowManagerService_FlowCreated1;
        _flowManagerService.FlowDistrus += _flowManagerService_FlowDistrus;
    }

    private void _flowManagerService_FlowCreated1(Flow arg1, Action arg2)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            Eveniment = "FlowCreated ";
            CurrentFlow = new(arg1);
            CurrentFlow.SubscribeEvents();
            Debug.WriteLine("flux creat in start VM" + Thread.CurrentThread.ManagedThreadId);
            
            
            arg2?.Invoke();

        });
    }

    private void _flowManagerService_FlowDistrus()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Debug.WriteLine("flow distrus startvm" + Thread.CurrentThread.ManagedThreadId);
            CurrentFlow.UnsubscribeEvents();
            CurrentFlow = null;

        });
        
    }

    

   

    

    private void _flowManagerService_UsbDeviceRemoved(USBDeviceEvent obj)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            Eveniment = "Removed : " + obj.ToString();
            Debug.WriteLine("USb removed start VM" + Thread.CurrentThread.ManagedThreadId);
            
            //OnEvenimentChanged("Removed : " + obj.ToString());

        });
    }

    private void _flowManagerService_UsbDeviceInserted(USBDeviceEvent obj)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            Eveniment = "Inserted : " + obj.ToString();
            Debug.WriteLine("usb inserted start VM" + Thread.CurrentThread.ManagedThreadId);
            
            //OnEvenimentChanged("Inserted : " + obj.ToString());
        });
    }




    [RelayCommand]
    public async Task ToggleFluxExpand()
    {
        IsFluxExpanded = !IsFluxExpanded;
    }




    [RelayCommand]
    public async Task GoToConfig()
    {
        await _navigationService.NavigateToAsync("Config");
    }

    [RelayCommand]
    public async Task GoToAdd()
    {
        await _navigationService.NavigateToAsync("Add");
    }
}