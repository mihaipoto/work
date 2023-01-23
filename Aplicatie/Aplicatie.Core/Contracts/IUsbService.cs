
using Aplicatie.Core.Models;

namespace Aplicatie.Core.Contracts;

public interface IUsbService
{
    

    event Action<USBDeviceEvent> UsbDeviceInserted;

    event Action<USBDeviceEvent> UsbDeviceRemoved;
    void StartUsbListener();
    void StopUsbListener();

    void InitializeUSBService(UsbServiceSettings usbServiceConfiguration);
    bool IsWatcherRunning { get; set; }
}