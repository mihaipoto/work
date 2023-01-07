using Aplicatie.Core.Modele;
using Microsoft.Extensions.Options;
using System.Management;

namespace Aplicatie.Infrastructure;


public class UsbService
{
    public enum EventType
    {
        Inserted = 2,
        Removed = 3
    }

    private ManagementEventWatcher watcher = new();
    private WqlEventQuery _query = new("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2 or EventType = 3");
    private AppConfig _appConfig;
    public UsbService(IOptionsMonitor<AppConfig> appConfigOptions)
    {
        _appConfig = new AppConfig(appConfigOptions.CurrentValue);

        //_query = new WqlEventQuery(_appConfig);

        appConfigOptions.OnChange(optiuniNoi =>
        {
            _appConfig = new AppConfig(optiuniNoi);
        });
    }


    void StartUsbListener()
    {
        //watcher.EventArrived += (s, e) =>
        //{
        //    string driveName = e.NewEvent.Properties["DriveName"].Value.ToString();
        //    EventType eventType = (EventType)(Convert.ToInt16(e.NewEvent.Properties["EventType"].Value));

        //    string eventName = Enum.GetName(typeof(EventType), eventType);

            
        //};

        //watcher.EventArrived += (s, e) =>
        //{
        //    using (ManagementObjectSearcher theSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'"))
        //    {
        //        foreach (ManagementObject currentObject in theSearcher.Get())
        //        {
        //            //foreach(PropertyData propertyData in currentObject.Properties)
        //            //{
        //            //    Console.WriteLine($"{propertyData.Name} : {propertyData.Value}");
        //            //}

        //            ManagementObject theSerialNumberObjectQuery = new ManagementObject("Win32_PhysicalMedia.Tag='" + currentObject["DeviceID"] + "'");
        //            string? sn = theSerialNumberObjectQuery["SerialNumber"].ToString();

        //            Console.WriteLine("Serialul este {0}", sn);
        //        }
        //    };

        //};

        //watcher.Query = query;
        //watcher.Start();
    }

    

}


   

