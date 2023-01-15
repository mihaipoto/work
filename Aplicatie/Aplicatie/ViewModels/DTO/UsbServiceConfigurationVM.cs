using Aplicatie.Core.Models;

namespace Aplicatie.ViewModels;

public class UsbServiceSettingsVM
{
    public string WqlEventQuery { get; set; }
    public string ManagementObjectSearcher { get; set; }

    public UsbServiceSettingsVM()
    {

    }

    public UsbServiceSettingsVM(UsbServiceSettings source)
    {
        WqlEventQuery = source.WqlEventQuery;
        ManagementObjectSearcher = source.ManagementObjectSearcher;
    }
}