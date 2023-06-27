namespace Aplicatie.Core.Models;

public class UsbServiceSettings
{
    public string WqlEventQuery { get; set; }
    public string ManagementObjectSearcher { get; set; }

    public UsbServiceSettings()
    {

    }

    public UsbServiceSettings(UsbServiceSettings source)
    {
        WqlEventQuery = source.WqlEventQuery;
        ManagementObjectSearcher = source.ManagementObjectSearcher;
    }

}