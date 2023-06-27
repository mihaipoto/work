using Aplicatie.Core.Models;
using Aplicatie.Core.Services;
using Aplicatie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Options;

namespace Aplicatie.ViewModels;

public partial class StartViewModel : ObservableObject
{
    private readonly IDialogService _dialogService;
    private readonly INavigationService _navigationService;
    private readonly FluxManager _flowManagerService;

    [ObservableProperty]
    private AppConfig _appConfigObject;

    [ObservableProperty]
    private bool _isBusy = false;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsFluxInLucru))]
    private FlowVM _currentFlow;

    [ObservableProperty]
    private string _eveniment;

    public bool IsFluxInLucru => CurrentFlow is null ? false : true;

    [ObservableProperty]
    private bool _isFluxExpanded;

    public StartViewModel(
        IDialogService dialogService,
        INavigationService navigationService,
        IOptionsMonitor<AppConfig> appConfigOptionsMonitor,
        FluxManager fluxManager
        )
    {
        _dialogService = dialogService;
        _navigationService = navigationService;
        _flowManagerService = fluxManager;
        AppConfigObject = appConfigOptionsMonitor.CurrentValue;

        appConfigOptionsMonitor.OnChange((optiuniNoi) =>
        {
            AppConfigObject = optiuniNoi;

            OnPropertyChanged(nameof(AppConfigObject));
        });
        //SubscribeToEvents();
    }

    //private void SubscribeToEvents()
    //{
    //    _flowManagerService.UsbDeviceInserted += _flowManagerService_UsbDeviceInserted;
    //    _flowManagerService.UsbDeviceRemoved += _flowManagerService_UsbDeviceRemoved;
    //    _flowManagerService.FlowCreated += _flowManagerService_FlowCreated1;
    //    _flowManagerService.FlowDistrus += _flowManagerService_FlowDistrus;
    //}

    private void _flowManagerService_FlowCreated1(FluxInLucru arg1, Action arg2)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Eveniment = "FlowCreated ";
            CurrentFlow = new(arg1);
            CurrentFlow.SubscribeEvents();

            arg2?.Invoke();
        });
    }

    //private void _flowManagerService_FlowDistrus()
    //{
    //    MainThread.BeginInvokeOnMainThread(() =>
    //    {
    //        CurrentFlow.UnsubscribeEvents();
    //        CurrentFlow = null;
    //    });
    //}

    //private void _flowManagerService_UsbDeviceRemoved(USBDeviceEvent obj)
    //{
    //    MainThread.BeginInvokeOnMainThread(() =>
    //    {
    //        Eveniment = "Removed : " + obj.ToString();
    //    });
    //}

    //private void _flowManagerService_UsbDeviceInserted(USBDeviceEvent obj)
    //{
    //    MainThread.BeginInvokeOnMainThread(() =>
    //    {
    //        Eveniment = "Inserted : " + obj.ToString();
    //        Debug.WriteLine("usb inserted start VM" + Thread.CurrentThread.ManagedThreadId);
    //    });
    //}

    [RelayCommand]
    public void ToggleFluxExpand()
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