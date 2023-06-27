using Aplicatie.Core.Models;

using CommunityToolkit.Mvvm.ComponentModel;

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
        model.UsbWatcher = UsbWatcher;
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