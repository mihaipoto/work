using Aplicatie.Platforms.Windows;
using Aplicatie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Aplicatie.ViewModels;




public partial class ManualViewModel : ObservableValidator
{
    
    private readonly IDialogService _dialogService;
    private readonly INavigationService _navigationService;
    private readonly FolderPicker _folderPicker;
    private string _pickedFolder;

    [ObservableProperty]
    bool isBusy = false;


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
        IsBusy= true;
        PickedFolder = await _folderPicker.PickFolder();
        await Task.Delay(5000);
        IsBusy= false;

    }

    [RelayCommand]
    public async Task GoToConfig()
    {
        await _navigationService.NavigateToAsync("Config");
    }

   
}