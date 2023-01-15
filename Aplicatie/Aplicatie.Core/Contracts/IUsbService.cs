
using Aplicatie.Core.Models;

namespace Aplicatie.Core.Contracts;

public interface IUsbService
{
    event EventHandler<ListOfUSBDevicesUpdatedEventArgs> ListOfConnectedUSBDevicesUpdated;

    event EventHandler<UsbDeviceEventArgs> UsbDeviceInserted;

    event EventHandler<UsbDeviceEventArgs> UsbDeviceRemoved;
    void StartUsbListener();
    void StopUsbListener();

    void InitializeUSBService(UsbServiceSettings usbServiceConfiguration);
    bool IsWatcherRunning { get; set; }
}