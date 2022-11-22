using Aplicatie.Core;
using Aplicatie.Infrastructure.Services;
using Aplicatie.Platforms.Windows;
using Aplicatie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Serilog;
using System.Text;


namespace Aplicatie.ViewModels;

public partial class MainViewModel : ObservableObject
{

    private DialogService _dialogService;
    private readonly FolderPicker _folderPicker;

    public MainViewModel(
        DialogService dialogService,
        FolderPicker folderPicker)
    {
        _dialogService= dialogService;
        _folderPicker = folderPicker;
    }



 
    [RelayCommand]
    public async Task Showpopup()
    {
        await _dialogService.ShowAlertAsync2("Alert", "You have been alerted", "OK", "Cancel");
    }

    [RelayCommand]
    public async Task PickFolder()
    {
        await _folderPicker.PickFolder();
    }



   

}