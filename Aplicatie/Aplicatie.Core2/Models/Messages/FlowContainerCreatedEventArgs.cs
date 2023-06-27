using System.ComponentModel;

namespace Aplicatie.Core.Models;

public class FlowContainerCreatedEventArgs
{
    public string ContainerCreat { get; set; }

	public FlowContainerCreatedEventArgs(string container)
	{
		ContainerCreat= container;
	}
}