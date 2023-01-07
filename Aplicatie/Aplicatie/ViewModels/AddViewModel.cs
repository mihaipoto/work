using Aplicatie.Core.Modele;
using Aplicatie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Options;

namespace Aplicatie.ViewModels;

public partial class AddViewModel : ObservableValidator
{
    private readonly IDialogService _dialogService;
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private bool isBusy = false;

    [ObservableProperty]
    AppConfigVM appConfig;

    public AddViewModel(IOptionsMonitor<AppConfig> appConfigOptions,
        IDialogService dialogService,
        INavigationService navigationService)
    {
        _dialogService = dialogService;
        _navigationService = navigationService;
        AppConfig = new AppConfigVM(appConfigOptions.CurrentValue);
        appConfigOptions.OnChange(optiuniNoi =>
        {
            AppConfig = new AppConfigVM(optiuniNoi);
        });
    }
}