using CommunityToolkit.Maui;
using MauiApp1.ViewModels;
using Microsoft.Extensions.Logging;
using Serilog;
using Syncfusion.Maui.Core.Hosting;

namespace MauiApp1;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .MyConfigureLogging()
            .MyAddPages();

        Log.Information("ok");

        return builder.Build();
    }

    public static MauiAppBuilder MyAddPages(this MauiAppBuilder builder)
    {
        builder.Services.AddSingletonWithShellRoute<MainPage, MainViewModel>("MainPage");
        builder.Services.AddDbContextFactory<LogDbContext>();
        return builder;
    }

    public static MauiAppBuilder MyConfigureLogging(this MauiAppBuilder builder)
    {
        builder.Logging.ClearProviders();
        var log = new LoggerConfiguration()
        .WriteTo.SQLite(sqliteDbPath: "E:\\work\\NewLogs\\loguri.sqlite", tableName: "Log", batchSize: 1, maxDatabaseSize: 10000)
        .CreateLogger();

        builder.Logging.AddSerilog(logger: log, dispose: true);
        //Task.Run(() =>
        //{
        //    for (int i = 0; i < 1000000; i++)
        //    {
        //        log.Information("Log {increment}, {increment2}", i, i + 1);
        //    }
        //});

        return builder;
    }


}