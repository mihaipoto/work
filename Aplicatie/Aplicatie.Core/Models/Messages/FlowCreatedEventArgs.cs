using Aplicatie.Core.Enums;
using Aplicatie.Core.Models;

namespace Aplicatie.Core.Models.Messages;

public class FlowCreatedEventArgs : EventArgs
{


    public FlowCreatedEventArgs(Flow flow)
    {
        Flow = flow;
    }

    public Flow Flow { get; }
}