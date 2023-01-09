

using Aplicatie.Core.Mesaje;
using Aplicatie.Core.Modele;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Options;

namespace Aplicatie.Services;

public class NavigationService : INavigationService
{
    private AppConfig _appConfig;

    public NavigationService(IOptionsMonitor<AppConfig> appConfigOptions)
    {
        _appConfig = new AppConfig(appConfigOptions.CurrentValue);

        appConfigOptions.OnChange(optiuniNoi =>
        {
            _appConfig = new AppConfig(optiuniNoi);
        });
    }

    //public Task InitializeAsync() =>
    //    NavigateToAsync(
    //        string.IsNullOrEmpty(_settingsService.AuthAccessToken)
    //            ? "//Login"
    //            : "//Main/Catalog");

    public async Task InitializeAsync()
    {
        try
        {
            
            switch (_appConfig.GetNumeModDeLucruActual)
            {
                case "Automat":
                    await NavigateToAsync("//AutomatPage");
                    break;
                case "Manual":
                    await NavigateToAsync("//ManualPage");
                    break;
                default:
                    await NavigateToAsync("//ManualPage");
                    break;
            }
        }
        catch (Exception)
        {

            throw;
        }
        
           
    }   

    public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
    {
        var shellNavigation = new ShellNavigationState(route);

        return routeParameters != null
            ? Shell.Current.GoToAsync(shellNavigation, routeParameters)
            : Shell.Current.GoToAsync(shellNavigation);
    }

    public Task PopAsync() =>
        Shell.Current.GoToAsync("..");
}