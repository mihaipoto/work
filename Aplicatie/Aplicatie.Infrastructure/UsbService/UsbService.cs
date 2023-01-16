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
    public bool IsWatcherRunning {get; set;}

    private List<USBDevice> _USBDevices = new List<USBDevice>();

    private ManagementEventWatcher _watcher = new();
    private WqlEventQuery _query;
    private ManagementObjectSearcher _managementObjectSearcher;

    public UsbService()
    {
    }

   

    public void InitializeUSBService(UsbServiceSettings usbServiceConfiguration)
    {
        _query= new WqlEventQuery(usbServiceConfiguration.WqlEventQuery);
        _watcher.Query = _query;
        _watcher.EventArrived += _watcher_EventArrived;
        _managementObjectSearcher = new(usbServiceConfiguration.ManagementObjectSearcher);
    }

   

    private void _watcher_EventArrived(object sender, EventArrivedEventArgs e)
    {
        UpdateListOfConnectedUSBDevices();

        string driveName = e.NewEvent.Properties["DriveName"].Value.ToString();

        EventType eventType = (EventType)(Convert.ToInt16(e.NewEvent.Properties["EventType"].Value));

        string eventName = Enum.GetName(typeof(EventType), eventType);
        var device = new USBDevice(deviceId: driveName, pnpDeviceId: eventType.ToString());
        
        File.AppendAllText(@"d:\fisier.txt", device.ToString());
        if (eventType is EventType.Inserted)
        {
            UsbDeviceInserted?.Invoke(this, new(device));
            //Debug.WriteLine( $"Inserted {device.ToString()}" );
        }
            
        else if (eventType is EventType.Removed)
        {
            UsbDeviceRemoved?.Invoke(this, new(device));
            //Debug.WriteLine($"Removed {device.ToString()}");
        }
            

    }

    

    public event EventHandler<ListOfUSBDevicesUpdatedEventArgs> ListOfConnectedUSBDevicesUpdated;

    public event EventHandler<UsbDeviceEventArgs> UsbDeviceInserted;

    public event EventHandler<UsbDeviceEventArgs> UsbDeviceRemoved;



    public void UpdateListOfConnectedUSBDevices()
    {
        _USBDevices.Clear();
        //File.AppendAllText(@"d:\fisier.txt", "LISTA USBDEVICES");
        //Debug.WriteLine($"Update device list {DateTime.UtcNow.ToShortTimeString()}");
        //File.AppendAllText(@"d:\fisier.txt", DateTime.UtcNow.ToShortTimeString());
        foreach (ManagementObject drive in _managementObjectSearcher.Get())
        {
            _USBDevices.Add(new USBDevice(
               deviceId: (string)drive.GetPropertyValue("DeviceID"),
               pnpDeviceId: (string)drive.GetPropertyValue("PNPDeviceID")
                ));
            
            

        }
        //_USBDevices.ForEach(device =>
        //{
        //    Debug.WriteLine($"Device: {device.ToString()}");
        //    File.AppendAllText(@"d:\fisier.txt", device.ToString());
        //    File.AppendAllText(@"d:\fisier.txt", Environment.NewLine);

        //});
        ListOfConnectedUSBDevicesUpdated?.Invoke(this,
            new ListOfUSBDevicesUpdatedEventArgs(uSBDevices: _USBDevices));

    }

    public void StartUsbListener()
    {
        if (IsWatcherRunning)
            throw new Exception("S-a incercat pornirea Listenerului USB insa acesta era deja pornit");
        _watcher.Start();

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

