﻿using Aplicatie.Infrastructure;
using Aplicatie.Platforms.Windows;
using Aplicatie.Services;
using Aplicatie.Pages;
using Aplicatie.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Aplicatie.Core;
using Aplicatie.Views;
using CommunityToolkit.Maui.Markup;
using Aplicatie.Controls;

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
        .AddUIServices();
       






        builder.Services.AddInfrastructureService(builder.Configuration);
		builder.Services.AddCoreServices();
		

		return builder.Build();
	}

    private static void MakeWindowZ(Microsoft.UI.Xaml.Window window)
    {
        
    }

    public static MauiAppBuilder AddUIServices(this MauiAppBuilder builder)
	{
        builder.Logging.AddDebug();

        
        builder.Services.AddTransient<GuidService>();

        builder.Services.AddSingleton<FolderPicker>();
        builder.Services.AddSingleton<IDialogService, DialogService>();
		builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingletonWithShellRoute<AutomatPage, AutomatViewModel>("AutomatPage");
        builder.Services.AddSingletonWithShellRoute<ManualPage, ManualViewModel>("ManualPage");
        builder.Services.AddTransientWithShellRoute<ConfigurarePage, ConfigurareViewModel>("Config");
        builder.Services.AddTransientWithShellRoute<AddPage, AddViewModel>("Add");
        builder.Services.AddTransient<Dinamic2, AppConfigVM>();
        //mauiAppBuilder.Services.AddSingleton<IAppEnvironmentService, AppEnvironmentService>(
        //   serviceProvider =>
        //   {
        //       var requestProvider = serviceProvider.GetService<IRequestProvider>();
        //       var fixUriService = serviceProvider.GetService<IFixUriService>();
        //       var settingsService = serviceProvider.GetService<ISettingsService>();

        //       var aes =
        //           new AppEnvironmentService(
        //               new BasketMockService(), new BasketService(requestProvider, fixUriService),
        //               new CampaignMockService(), new CampaignService(requestProvider, fixUriService),
        //               new CatalogMockService(), new CatalogService(requestProvider, fixUriService),
        //               new OrderMockService(), new OrderService(requestProvider),
        //               new UserMockService(), new UserService(requestProvider));

        //       aes.UpdateDependencies(settingsService.UseMocks);
        //       return aes;
        //   });


        //builder.Services.AddTransient<TestPage>();
        //builder.Services.AddTransient<TestPageViewModel>();
        //builder.Services.AddScoped<IValidator<TestPageViewModel>, TestPageValidation>();

        return builder;
	}

    
}
