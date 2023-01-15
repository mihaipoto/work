using Aplicatie.Core.Contracts;
using Aplicatie.Core.Enums;
using Aplicatie.Core.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie.Core.Models;

public class Flow
{
    public event EventHandler<FlowCreatedEventArgs> FlowCreated;
    public event EventHandler<FlowScannedEventArgs> FlowScanned;
    public event EventHandler<FlowClassifiedEventArgs> FlowClassified;
    public event EventHandler<FlowContainerCreatedEventArgs> FlowContainerCreated;

    public Guid Id { get; init; }

	

    public IFluxInitiator Initiator { get; set; }

    public FlowItemSettings FlowSettings { get; set; }

    public Flow(FlowItemSettings flowItemSettings,

        IFluxInitiator initiator)
    {
        Id = Guid.NewGuid();
        FlowSettings = flowItemSettings;
        Initiator = initiator;
    }

    public ScanResult RezultatScanare { get; set; }















}
