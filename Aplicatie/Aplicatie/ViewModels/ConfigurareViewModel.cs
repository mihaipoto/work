using Aplicatie.Core.Mesaje;
using Aplicatie.Core.Modele;
using Aplicatie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Aplicatie.ViewModels;

public partial class ConfigurareViewModel : ViewModelBase
{
    public AppTheme CurrentTheme => Application.Current.UserAppTheme;

    public ConfigurareViewModel(
        IDialogService dialogService,
        INavigationService navigationService):base(dialogService, navigationService)
    {
        
       // InitializeVM(); 
    }


    //private async Task InitializeVM()
    //{
    //    while(IsBusy)
    //    {
    //        Task.Delay(1000);
    //    }
        
    //    if(!IsBusy) 
    //    {
    //        this.IsBusyFor(async () => {
    //            _appConfigObj = WeakReferenceMessenger.Default.Send<CerereAppConfigDinConfiguratie>();
    //            Task.Delay(4000);
    //        });
    //    }
        
        
    //}



    
    private AppConfig _appConfigObj = WeakReferenceMessenger.Default.Send<CerereAppConfigDinConfiguratie>();

    public AppConfig AppConfigObj
    {
        get => _appConfigObj;
        set => SetProperty(ref _appConfigObj, value);
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