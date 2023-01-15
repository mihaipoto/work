using Aplicatie.Core.Models;
using Aplicatie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Aplicatie.ViewModels;

public partial class AppConfigVM : ObservableObject
{
    [ObservableProperty]
    GeneralSettingsVM generalConfiguration;

    [ObservableProperty]
    WorkflowVM workflowConfiguration;

    [ObservableProperty]
    List<FlowItemConfigurationVM> flowListConfiguration;

    [ObservableProperty]
    UsbServiceSettingsVM usbServiceConfiguration;


    public AppConfigVM()
    {

    }

    public AppConfigVM(AppConfig source)
    {
        GeneralConfiguration = new(source.GeneralConfiguration);
        WorkflowConfiguration= new(source.WorkflowConfiguration);
        FlowListConfiguration = new();
        FlowListConfiguration.MapList(
           listaSursa: source.FlowListConfiguration,
           creator: f => new(f));
        UsbServiceConfiguration = new(source.UsbServiceConfiguration);

    }

    

    
}