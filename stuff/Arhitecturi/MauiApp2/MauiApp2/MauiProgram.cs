using CommunityToolkit.Maui;
using ConfigExtension;
using MauiApp2.Platforms.Windows;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.DataGrid.Hosting;

namespace MauiApp2;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .ConfigureSyncfusionDataGrid()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddMyLibraryService();
        builder.Services.AddTransient<IFolderPicker, FolderPicker>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<DialogService>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<OrderInfoRepository>();

        return builder.Build();
    }
}