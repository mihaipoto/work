using Aplicatie.Core.Enums;
using Aplicatie.Core.Models;

namespace Aplicatie.Core.Models.Messages;

public class FlowCreatedEventArgs : EventArgs
{


    public FlowCreatedEventArgs(FluxInLucru flow)
    {
        Flow = flow;
    }

    public FluxInLucru Flow { get; }
}