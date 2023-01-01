using Aplicatie.Platforms.Windows;
using Aplicatie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Aplicatie.ViewModels;

public partial class AutomatViewModel : ObservableValidator
{
    private readonly IDialogService _dialogService;
    private readonly INavigationService _navigationService;

    

    public AutomatViewModel(
        IDialogService dialogService,
        INavigationService navigationService)

    {
        _dialogService = dialogService;
        _navigationService = navigationService;
    }

    [ObservableProperty]
    bool isBusy = false;

    [RelayCommand]
    public async Task GoToConfig()
    {
        await _navigationService.NavigateToAsync("Config");
    }
}