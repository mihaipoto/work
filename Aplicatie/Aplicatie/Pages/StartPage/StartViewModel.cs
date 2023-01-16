using Aplicatie.Core.Models;
using Aplicatie.Core.Services;
using Aplicatie.Services;
using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Options;
using System.Collections.ObjectModel;
using Windows.Storage.Provider;


namespace Aplicatie.ViewModels;

public partial class StartViewModel : ObservableObject
{

    private readonly IDialogService _dialogService;
    private readonly INavigationService _navigationService;
    private readonly FluxManager _flowManagerService;

    [ObservableProperty]
    AppConfigVM appConfigObject;

    [ObservableProperty]
    bool isBusy = false;

    [ObservableProperty]
    FlowVM currentFlow;

    public StartViewModel(
        IDialogService dialogService,
        INavigationService navigationService,
        IOptionsMonitor<AppConfig> appConfigOptionsMonitor
        )
    {

        _dialogService = dialogService;
        _navigationService = navigationService;
        
        AppConfigObject = new( appConfigOptionsMonitor.CurrentValue);
        
        //FluxManager.LogErrorString += _flowManagerService_LogErrorString;
        //FluxManager.FluxStarted += _flowManagerService_FluxStarted1;
        //FluxManager.UsbDeviceInserted += _flowManagerService_UsbDeviceInserted;
        //FluxManager.UsbDeviceRemoved += _flowManagerService_UsbDeviceRemoved;
        //FluxManager.FlowScanned += _flowManagerService_FlowScanned1;
        //FluxManager.FlowClassified += _flowManagerService_FlowClassified;
        //FluxManager.FlowContainerCreated += _flowManagerService_FlowContainerCreated;
        FluxManager.Notificare += FluxManager_Notificare;



    }

    private void FluxManager_Notificare(string obj)
    {
        MainThread.BeginInvokeOnMainThread( () =>
        {

            Evenimente.Add("inserted");
            
        });
    }

    private void _flowManagerService_FlowScanned1(ScanResult arg1, Action<bool> arg2)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            
            Evenimente.Add("Flux scanned");
            bool rezultat = await _dialogService.ShowConfirmationAsync(
                title: "Confirmare utilizator",
                message: $"rezultatul este {arg1}. Doriti sa continuati?");
            arg2?.Invoke( rezultat );
        });
    }

    private void _flowManagerService_FluxStarted1(Flow obj)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            CurrentFlow = new FlowVM(obj);
            Evenimente.Add("Flux started");
        });
    }

   

    private void _flowManagerService_FlowContainerCreated(object sender, FlowContainerCreatedEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() => { Evenimente.Add("conteiner created"); });
    }

    private void _flowManagerService_FlowClassified(object sender, FlowClassifiedEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() => { Evenimente.Add("classified"); });
    }

   

    private void _flowManagerService_UsbDeviceRemoved(object sender, UsbDeviceEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() => { Evenimente.Add("removed"); });
    }

    [ObservableProperty]
    ObservableCollection<string> evenimente = new();

    private void _flowManagerService_UsbDeviceInserted(object sender, UsbDeviceEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() => { Evenimente.Add("inserted"); });


    }


    private void _flowManagerService_FluxStarted(object sender, FlowEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            CurrentFlow = new FlowVM(e.CurrentFlow);
            Evenimente.Add("Flux started");
        });

    }

    private void _flowManagerService_LogErrorString(object sender, LogMessageEventArgs<string> e)
    {

        MainThread.BeginInvokeOnMainThread(() =>
        {
            Evenimente.Add("eroare");
        });
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
