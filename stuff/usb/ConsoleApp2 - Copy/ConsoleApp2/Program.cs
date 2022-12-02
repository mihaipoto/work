using System;
using System.Management;


internal class Program
{
    public enum EventType
    {
        Inserted = 2,
        Removed = 3
    }

    static void Main(string[] args)
    {
        ManagementEventWatcher watcher = new ManagementEventWatcher();
        WqlEventQuery query = new WqlEventQuery(@"SELECT * FROM \\Root\Microsoft\Windows\Defender:MSFT_MpComputerStatus");

        watcher.EventArrived += (s, e) =>
        {
            string driveName = e.NewEvent.Properties["DriveName"].Value.ToString();
            EventType eventType = (EventType)(Convert.ToInt16(e.NewEvent.Properties["EventType"].Value));

            string eventName = Enum.GetName(typeof(EventType), eventType);

            Console.WriteLine("{0}: {1} {2}", DateTime.Now, driveName, eventName);
        };

        watcher.EventArrived += (s, e) =>
        {
            using (ManagementObjectSearcher theSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'"))
            {
                foreach (ManagementObject currentObject in theSearcher.Get())
                {
                    //foreach(PropertyData propertyData in currentObject.Properties)
                    //{
                    //    Console.WriteLine($"{propertyData.Name} : {propertyData.Value}");
                    //}

                    ManagementObject theSerialNumberObjectQuery = new ManagementObject("Win32_PhysicalMedia.Tag='" + currentObject["DeviceID"] + "'");
                    string? sn = theSerialNumberObjectQuery["SerialNumber"].ToString();

                    Console.WriteLine("Serialul este {0}", sn);
                }
            };
            
        };

        watcher.Query = query;
        watcher.Start();

        Console.ReadKey();
    }
}