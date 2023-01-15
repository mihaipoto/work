namespace Aplicatie.Core.Models;

public class FlowScannedEventArgs : EventArgs
{
    public ScanResult Value { get; init; }

	public FlowScannedEventArgs(ScanResult scanResult)
	{
		Value= scanResult;
	}
}