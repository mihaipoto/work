
using Aplicatie.Core.Models;
using Aplicatie.ViewModels;
using Microsoft.Extensions.Options;

namespace Aplicatie.Repositories;

public class ConfigRepository
{
    public ConfigRepository(
       IOptionsMonitor<AppConfig> appConfigOptions
       )
    {
        _appConfigObject = new AppConfig(appConfigOptions.CurrentValue);
        appConfigOptions.OnChange(optiuniNoi =>
        {
            _appConfigObject = new AppConfig(optiuniNoi);
            AppConfigChanged?.Invoke(this, EventArgs.Empty);
        });
    }

    private AppConfig _appConfigObject;

    public AppConfig AppConfigObject => _appConfigObject;

    public event EventHandler AppConfigChanged;
}

public class AppConfigChangedEventArgs : EventArgs
{
    public AppConfigVM AppConfigVM { get; set; }
}