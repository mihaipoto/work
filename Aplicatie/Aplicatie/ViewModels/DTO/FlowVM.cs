using Aplicatie.Core.Contracts;
using Aplicatie.Core.Enums;
using Aplicatie.Core.Models;
using Aplicatie.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace Aplicatie.ViewModels;

public partial class FlowVM : ObservableObject
{
    private readonly FluxInLucru _flow;

    [ObservableProperty]
    Guid _id;

    [ObservableProperty]
    USBDeviceEvent _evenimentUSB;

    [ObservableProperty]
    FlowItemSettings _flowSettings;

    [ObservableProperty]
    ScanResultModel _rezultatScanare;

    [ObservableProperty]
    Etapa2ResultModel _rezultatEtapa2;


    [ObservableProperty]
    bool _isEtapa2;

    [ObservableProperty]
    bool _isEtapa2Expanded;

    public FlowVM(FluxInLucru flow)
    {
        _flow = flow;
        Id = flow.Id;
        EvenimentUSB= flow.EvenimentUSB;
        FlowSettings = flow.FlowConfig;
    }

    public void SubscribeEvents()
    {
        _flow.Etapa2Result += _flow_Etapa2Result1;
    }

    private void _flow_Etapa2Result1(Etapa2ResultModel arg1, Action arg2)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Debug.WriteLine("Etapa 2 in VM" + Thread.CurrentThread.ManagedThreadId);
            RezultatEtapa2 = arg1;
            OnPropertyChanged(nameof(RezultatEtapa2));
            IsEtapa2 = true;
            //arg2?.Invoke();
            _acceptareEtapa = arg2;

        });
    }

    private Action _acceptareEtapa;

    internal void UnsubscribeEvents()
    {
        _flow.Etapa2Result -= _flow_Etapa2Result1;
        Id = default(Guid);
        EvenimentUSB = null;
        FlowSettings = null;
        RezultatEtapa2= null;
        RezultatScanare= null;
        OnPropertyChanged(nameof(Id));
        OnPropertyChanged(nameof(EvenimentUSB));
        OnPropertyChanged(nameof(FlowSettings));
        OnPropertyChanged(nameof(RezultatScanare));
        OnPropertyChanged(nameof(RezultatEtapa2));
    }



    [RelayCommand]
    public void ExpandEtapa2()
    {
        IsEtapa2Expanded= !IsEtapa2Expanded;
        OnPropertyChanged();
    }


    [ObservableProperty]
    bool _isEtapa2Accepted;


    [RelayCommand]
    public void AcceptEtapa2()
    {
        IsEtapa2Accepted = true;
        _acceptareEtapa?.Invoke();

    }
   

}