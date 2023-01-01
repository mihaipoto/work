using Aplicatie.Services;
using Aplicatie.Pages;
using Aplicatie.Core.Mesaje;
using CommunityToolkit.Mvvm.Messaging;
using Windows.System;

namespace Aplicatie;

public partial class AppShell : Shell
{
    private readonly INavigationService _navigationService;

    public AppShell(INavigationService navigationService)
	{
        _navigationService = navigationService;
        //AppShell.InitializeRouting();
        InitializeComponent();
       
    }

    


    protected override async void OnHandlerChanged()
    {
        base.OnHandlerChanged();

        if (Handler is not null)
        {
            await _navigationService.InitializeAsync();
        }
    }

    //private static void InitializeRouting()
    //{
    //    Routing.RegisterRoute("Config", typeof(ConfigurarePage));
        
       
    //}




}


//using Aplicatie.Services;

//namespace Aplicatie;

//public partial class AppShell : Shell
//{
//    private readonly INavigationService _navigationService;

//    public AppShell(INavigationService navigationService)
//    {
//        _navigationService = navigationService;
//        AppShell.InitializeRouting();
//        InitializeComponent();

//    }

//    protected override async void OnHandlerChanged()
//    {
//        base.OnHandlerChanged();

//        if (Handler is not null)
//        {
//            await _navigationService.InitializeAsync();
//        }
//    }

//    private static void InitializeRouting()
//    {
//        //Routing.RegisterRoute("Filter", typeof(FiltersView));

//    }
//}

