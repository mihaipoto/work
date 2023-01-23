using Aplicatie.Core.Models.Configuratie;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie.ViewModels;

public partial class WorkflowVM : ObservableObject
{
    [ObservableProperty]
    public bool _usbWatcher;

    [ObservableProperty]
    public bool _aVUserInput;


    [ObservableProperty]
    public bool _classificationUserInput;


    [ObservableProperty]
    public bool _containerUserInput;

    public WorkflowVM()
    {

    }

    public Workflow ToModel()
    {
        Workflow model = new();
        model.AVUserInput = AVUserInput;
        model.ContainerUserInput = ContainerUserInput;
        model.ClassificationUserInput = ClassificationUserInput;
        model.UsbWatcher= UsbWatcher;
        return model;
    }

    public WorkflowVM(Workflow source)
    {
        UsbWatcher = source.UsbWatcher;
        AVUserInput = source.AVUserInput;
        ClassificationUserInput = source.ClassificationUserInput;
        ContainerUserInput = source.ContainerUserInput;
    }
}

public static class MyClass
{

}
