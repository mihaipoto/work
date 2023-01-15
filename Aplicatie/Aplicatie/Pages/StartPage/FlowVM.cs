using Aplicatie.Core.Contracts;
using Aplicatie.Core.Enums;
using Aplicatie.Core.Models;
using Aplicatie.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;


namespace Aplicatie.ViewModels;

public partial class FlowVM : ObservableObject
{
   

    [ObservableProperty]
    Guid id;

    [ObservableProperty]
    UsbDeviceVM initiatorUsb;



    [ObservableProperty]
    FlowItemConfigurationVM flowSettings;

    public FlowVM(Flow source)
    {
        Id = source.Id;
        SetInitiator(source.Initiator);
        FlowSettings = new(source.FlowSettings);
        

    }

   

    void SetInitiator(IFluxInitiator fluxInitiator) 
    {
       if (fluxInitiator.GetType().Equals(typeof(USBDevice)))
        {
            InitiatorUsb = new((USBDevice)fluxInitiator);
        }
    }
   

    [ObservableProperty]
    ScanResult rezultatScanare;
   

   
}