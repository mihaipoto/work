using Aplicatie.Platforms.Windows;
using Aplicatie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Aplicatie.ViewModels;



[INotifyPropertyChanged]
public partial class ManualViewModel
{
    private readonly IDialogService _dialogService;
    private readonly INavigationService _navigationService;
    private readonly FolderPicker _folderPicker;

    private string _pickedFolder;


    public string PickedFolder
    {
        get => _pickedFolder;
        set => SetProperty(ref _pickedFolder, value);
    }

    public ManualViewModel(
        IDialogService dialogService,
        INavigationService navigationService,
        FolderPicker folderPicker)
    {
        _dialogService = dialogService;
        _navigationService = navigationService;
        _folderPicker = folderPicker;
    }

    [RelayCommand]
    public async Task PickFolder()
    {
        //await IsBusyFor(async () =>
        //{
        //    PickedFolder = await _folderPicker.PickFolder();
        //    await Task.Delay(5000);
        //});
        PickedFolder = await _folderPicker.PickFolder();
        await Task.Delay(5000);

    }

    [RelayCommand]
    public async Task GoToConfig()
    {
        await _navigationService.NavigateToAsync("Config");
    }

   
}