using Aplicatie.Controls;
using Aplicatie.Core;
using Aplicatie.Core.Models;
using Aplicatie.Infrastructure;
using Aplicatie.Platforms.Windows;
using Aplicatie.Services;
using Aplicatie.ViewModels;
using Aplicatie.Views;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Aplicatie;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkitMarkup()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
        .AddUIServices()
        .AddConfiguration()
        .AddLogging();

        builder.Services.AddInfrastructureService(builder.Configuration);
        builder.Services.AddCoreServices();

        return builder.Build();
    }



    public static MauiAppBuilder AddUIServices(this MauiAppBuilder builder)
    {
        builder.Logging.AddDebug();

        builder.Services.AddSingleton<FolderPicker>();
        builder.Services.AddSingleton<IDialogService, DialogService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();

        builder.Services.AddTransientWithShellRoute<ConfigurarePage, ConfigurareViewModel>("Config");
        builder.Services.AddTransientWithShellRoute<AddPage, AddViewModel>("Add");
        builder.Services.AddSingletonWithShellRoute<StartPage, StartViewModel>("StartPage");
        builder.Services.AddTransient<Dinamic>();

        return builder;
    }

    public static MauiAppBuilder AddLogging(this MauiAppBuilder builder)
    {
        builder.Logging.ClearProviders();
        var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .WriteTo.SQLite("E:\\work\\Aplicatie\\stuff\\Loguri\\loguri.sqlite")
        .WriteTo.Seq("http://localhost:5341", apiKey: "QyA3cJkBvgSOgy3jExec")
        .WriteTo.Debug()
        .Enrich.WithProperty("Username", Environment.UserName)
        .CreateLogger();

        builder.Logging.AddSerilog(logger);



        return builder;
    }


    public static MauiAppBuilder AddConfiguration(this MauiAppBuilder builder)
    {
        builder.Configuration.Sources.Clear();
        builder.Configuration.AddJsonFile("""E:\work\Aplicatie\stuff\ConfigFiles\AppConfig.json""", optional: false, reloadOnChange: true);
        //builder.Configuration.AddJsonFile("""E:\work\Aplicatie\stuff\ConfigFiles\LoggerServiceConfig.json""", optional: false, reloadOnChange: true);

        builder.Services.AddOptions<AppConfig>().Bind(builder.Configuration.GetSection(nameof(AppConfig)));

        return builder;
    }

}
