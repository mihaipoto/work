using Aplicatie.Infrastructure;
using Aplicatie.Platforms.Windows;
using Aplicatie.Services;
using Aplicatie.Pages;
using Aplicatie.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Aplicatie.Core;

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
		builder.Services.AddInfrastructureService();
		builder.Services.AddCoreServices();

		return builder.Build();
	}
}
