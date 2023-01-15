
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicatie.Core.Models;
using Aplicatie.Core.Models.Messages;

namespace Aplicatie.Core.Contracts;

public interface IFlowHandler
{
    event EventHandler<FlowCreatedEventArgs> FlowCreated;

    event EventHandler<FlowScannedEventArgs> FlowScanned;

    event EventHandler<FlowClassifiedEventArgs> FlowClassified;

    event EventHandler<FlowContainerCreatedEventArgs> FlowContainerCreated;


}
