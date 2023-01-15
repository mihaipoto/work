using Aplicatie.Core.Contracts;
using Aplicatie.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Aplicatie.ViewModels;

public partial class UsbDeviceVM : ObservableValidator
{

    [ObservableProperty]
    string deviceId;

    [ObservableProperty]
    string pnpDeviceId;

    [ObservableProperty]
    string hash;

    public UsbDeviceVM()
    {

    }

    public UsbDeviceVM(USBDevice source)
    {
        DeviceId = source.DeviceId;
        PnpDeviceId = source.PnpDeviceId;
        Hash = source.Hash;
    }
    

}
