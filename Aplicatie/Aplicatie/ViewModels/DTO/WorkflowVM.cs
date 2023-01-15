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
    public bool usbWatcher;

    [ObservableProperty]
    public bool aVUserInput;


    [ObservableProperty]
    public bool classificationUserInput;


    [ObservableProperty]
    public bool containerUserInput;

    public WorkflowVM()
    {

    }

    public Workflow ToModel()
    {
        Workflow model = new();
        model.AVUserInput = aVUserInput;
        model.ContainerUserInput = containerUserInput;
        model.ClassificationUserInput = classificationUserInput;
        model.UsbWatcher= usbWatcher;
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
