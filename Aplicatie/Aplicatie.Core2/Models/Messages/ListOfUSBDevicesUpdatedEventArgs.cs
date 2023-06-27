

namespace Aplicatie.Core.Models;

public class ListOfUSBDevicesUpdatedEventArgs : EventArgs
{
    List<USBDevice> ListOfUpdatedUSBDevices { get; set; }

	public ListOfUSBDevicesUpdatedEventArgs(List<USBDevice> uSBDevices)
	{
		ListOfUpdatedUSBDevices = uSBDevices;
	}
}
