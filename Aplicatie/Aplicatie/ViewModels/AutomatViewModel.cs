using Aplicatie.Platforms.Windows;
using Aplicatie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Aplicatie.ViewModels;

public partial class AutomatViewModel : ObservableObject
{
    private readonly IDialogService _dialogService;
    private readonly INavigationService _navigationService;

    public AppTheme CurrentTheme => Application.Current.UserAppTheme;

    public AutomatViewModel(
        IDialogService dialogService,
        INavigationService navigationService,
        FolderPicker folderPicker)

    {
        _dialogService = dialogService;
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void ToggleDarkLight()
    {
        switch (Application.Current.UserAppTheme)
        {
            case AppTheme.Dark:
                Application.Current.UserAppTheme = AppTheme.Light;
                OnPropertyChanged(nameof(CurrentTheme));
                break;

            case AppTheme.Light:
                Application.Current.UserAppTheme = AppTheme.Unspecified;
                OnPropertyChanged(nameof(CurrentTheme));
                break;

            case AppTheme.Unspecified:
                Application.Current.UserAppTheme = AppTheme.Dark;
                OnPropertyChanged(nameof(CurrentTheme));
                break;

            default:
                break;
        }
    }
}