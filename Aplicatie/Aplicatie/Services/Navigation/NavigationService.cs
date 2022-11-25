

using Aplicatie.Core.Mesaje;
using CommunityToolkit.Mvvm.Messaging;

namespace Aplicatie.Services;

public class NavigationService : INavigationService
{
    //private readonly ISettingsService _settingsService;

    public NavigationService()
    {
        
    }

    //public Task InitializeAsync() =>
    //    NavigateToAsync(
    //        string.IsNullOrEmpty(_settingsService.AuthAccessToken)
    //            ? "//Login"
    //            : "//Main/Catalog");

    public async Task InitializeAsync()
    {
        string ModDeLucruActual = await WeakReferenceMessenger.Default.Send<CerereModDeLucruActualDinConfiguratie>();
        switch(ModDeLucruActual)
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