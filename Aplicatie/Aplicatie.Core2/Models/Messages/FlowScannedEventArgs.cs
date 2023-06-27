namespace Aplicatie.Core.Models;

public class FlowScannedEventArgs : EventArgs
{
    public ScanResultModel Value { get; init; }

	public FlowScannedEventArgs(ScanResultModel scanResult)
	{
		Value= scanResult;
	}
}