using Aplicatie.Infrastructure;
using Aplicatie.Platforms.Windows;
using Aplicatie.Services;
using Aplicatie.ViewModels;
using Aplicatie.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;


namespace Aplicatie;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit(options =>
			{
				
			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


		builder.Logging.AddDebug();

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();

		builder.Services.AddSingleton<FolderPicker>();
		builder.Services.AddSingleton<DialogService>();
		builder.Services.AddMyLibraryService();

		return builder.Build();
	}
}
