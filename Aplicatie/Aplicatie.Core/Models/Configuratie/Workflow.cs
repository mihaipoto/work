using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie.Core.Models.Configuratie;

public class Workflow
{
    public bool UsbWatcher { get; set; }
    public bool AVUserInput { get; set; }

    public bool ClassificationUserInput { get; set; }

    public bool ContainerUserInput { get; set; }

    public Workflow()
    {

    }

    public Workflow(Workflow source)
    {
        UsbWatcher= source.UsbWatcher;
        AVUserInput= source.AVUserInput;
        ClassificationUserInput= source.ClassificationUserInput;
        ContainerUserInput= source.ContainerUserInput;
    }
}
