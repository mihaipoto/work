using Aplicatie.Platforms.Windows;
using Aplicatie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Aplicatie.ViewModels;

public partial class ManualViewModel : ViewModelBase
{
    
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
        FolderPicker folderPicker):base(dialogService, navigationService)
    {
      
        _folderPicker = folderPicker;
    }

    [RelayCommand]
    public async Task PickFolder()
    {
        PickedFolder = await _folderPicker.PickFolder();
    }

    [RelayCommand]
    public async Task GoToConfig()
    {
        await NavigationService.NavigateToAsync("Config");
    }

   
}