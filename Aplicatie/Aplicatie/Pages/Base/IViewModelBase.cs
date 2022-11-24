using Aplicatie.Services;
//using Aplicatie.Services.Settings;

namespace Aplicatie.ViewModels;

public interface IViewModelBase : IQueryAttributable
{
    public IDialogService DialogService { get; }
    public INavigationService NavigationService { get; }
    //public ISettingsService SettingsService { get; }

    public bool IsBusy { get; }

    public bool IsInitialized { get; set; }

    Task InitializeAsync();
}