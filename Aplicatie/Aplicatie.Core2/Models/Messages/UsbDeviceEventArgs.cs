

using Aplicatie.Core.Contracts;

namespace Aplicatie.Core.Models;


public class UsbDeviceEventArgs : EventArgs
{
    public USBDevice UsbDevice { get; init; }

	public UsbDeviceEventArgs(USBDevice uSBDevice)
	{
		UsbDevice= uSBDevice;
	}
}

