using Aplicatie.Core.Enums;
using Aplicatie.Core.Models;
using Microsoft.Extensions.Options;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Management;

namespace Aplicatie.Infrastructure;
#pragma warning disable CA1416 // Validate platform compatibility

public class UsbService : IDisposable, IUsbService
{
    public bool IsWatcherRunning { get; set; }

    private List<USBDevice> _USBDevices = new List<USBDevice>();

    private ManagementEventWatcher _watcher = new();
    private WqlEventQuery _query;
    private ManagementObjectSearcher _managementObjectSearcher;

    public UsbService()
    {
    }



    public void InitializeUSBService(UsbServiceSettings usbServiceConfiguration)
    {
        _query = new WqlEventQuery(usbServiceConfiguration.WqlEventQuery);
        _watcher.Query = _query;
        _watcher.EventArrived += _watcher_EventArrived;
        _managementObjectSearcher = new(usbServiceConfiguration.ManagementObjectSearcher);
    }



    private void _watcher_EventArrived(object sender, EventArrivedEventArgs e)
    {
        var driveEvent = new USBDeviceEvent();
        driveEvent.DriveLetter = e.NewEvent.Properties["DriveName"].Value.ToString();
        driveEvent.Tip = (EventType)(Convert.ToInt16(e.NewEvent.Properties["EventType"].Value));

        var listaNoua = UpdateListOfConnectedUSBDevices();
        if (driveEvent.Tip is EventType.Inserted)
        {
            driveEvent.USBDevice = listaNoua.Except(_USBDevices).FirstOrDefault()!;
            
            OnUsbDriveInserted(driveEvent);

        }

        else if (driveEvent.Tip is EventType.Removed)
        {
            driveEvent.USBDevice = _USBDevices.Except(listaNoua).FirstOrDefault()!;
            OnUsbDriveRemoved(driveEvent);


        }
        _USBDevices = listaNoua;       
    }

    private void OnUsbDriveInserted(USBDeviceEvent uSBDeviceEvent)
    {
        UsbDeviceInserted?.Invoke(uSBDeviceEvent);
        
    }

    private void OnUsbDriveRemoved(USBDeviceEvent uSBDeviceEvent)
    {
        UsbDeviceRemoved?.Invoke(uSBDeviceEvent);
    }




    public event Action<USBDeviceEvent> UsbDeviceInserted;

    public event Action<USBDeviceEvent> UsbDeviceRemoved;



    public List<USBDevice> UpdateListOfConnectedUSBDevices()
    {
        var listaNoua = new List<USBDevice>();

        foreach (ManagementObject drive in _managementObjectSearcher.Get())
        {
            listaNoua.Add(new USBDevice(
               deviceId: (string)drive.GetPropertyValue("DeviceID"),
               pnpDeviceId: (string)drive.GetPropertyValue("PNPDeviceID")
                ));

        }
        return listaNoua;
    }

    public void StartUsbListener()
    {
        if (IsWatcherRunning)
            throw new Exception("S-a incercat pornirea Listenerului USB insa acesta era deja pornit");
        _watcher.Start();
        _USBDevices = UpdateListOfConnectedUSBDevices();

    }

    public void StopUsbListener()
    {
        if (!IsWatcherRunning)
            throw new Exception("S-a incercat oprirea Listenerului USB insa acesta era deja oprit");

        _watcher.Stop();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}


#pragma warning restore CA1416 // Validate platform compatibility

