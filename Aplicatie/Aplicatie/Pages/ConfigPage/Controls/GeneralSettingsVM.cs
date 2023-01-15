using Aplicatie.Core.Enums;
using Aplicatie.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Aplicatie.ViewModels;

public partial class GeneralSettingsVM : ObservableObject
{
    [ObservableProperty]
    DateTime lastModified;

    [ObservableProperty]
    string configFilePath;

    

    [ObservableProperty]
    string outboxPath;

    [ObservableProperty]
    string inboxPath;

    public GeneralSettingsVM()
    {

    }

    public GeneralSettingsVM(GeneralSettings source)
    {
        LastModified = source.LastModified;
        ConfigFilePath = source.ConfigFilePath;
        
        OutboxPath = source.OutboxPath;
        InboxPath= source.InboxPath;
    }
}