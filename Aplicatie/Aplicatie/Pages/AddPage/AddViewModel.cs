
using Aplicatie.Core.Models;
using Aplicatie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Options;

namespace Aplicatie.ViewModels;

public partial class AddViewModel : ObservableObject
{
    private readonly IDialogService _dialogService;
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private bool isBusy = false;

    [ObservableProperty]
    AppConfigVM appConfigObject;

    public AddViewModel(IOptionsMonitor<AppConfig> appConfigOptions,
        IDialogService dialogService,
        INavigationService navigationService)
    {
        _dialogService = dialogService;
        _navigationService = navigationService;
        AppConfigObject = new AppConfigVM(appConfigOptions.CurrentValue);
        appConfigOptions.OnChange(optiuniNoi =>
        {
            AppConfigObject= new AppConfigVM(optiuniNoi);
        });
    }
}