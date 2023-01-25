using Aplicatie.Core.Models;
using Aplicatie.Core.Services;
using Aplicatie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Aplicatie.ViewModels;



public partial class ConfigurareViewModel : ObservableObject
{

    private readonly IDialogService _dialogService;

    [ObservableProperty]
    bool _isBusy = false;

    [ObservableProperty]
    AppConfigVM _appConfigObject;

    public AppTheme CurrentTheme => Application.Current.UserAppTheme;

    public ConfigurareViewModel(
        IDialogService dialogService,
        IOptionsMonitor<AppConfig> optionsMonitor)
    {
        _dialogService = dialogService;
        AppConfigObject = new(optionsMonitor.CurrentValue);
             
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