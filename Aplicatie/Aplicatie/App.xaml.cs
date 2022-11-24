using Aplicatie.Core;
using Aplicatie.Services;

namespace Aplicatie;

public partial class App : Application
{
   

    //public static IServiceProvider ServiceProvider { get; private set; }

    public App(FlowControl fc, INavigationService navigationService)
	{
		InitializeComponent();

        //Application.Current.UserAppTheme = AppTheme.Dark;
        //ServiceProvider = provider;

       // _ = ServiceProvider.GetServices(typeof(FlowControl));
        MainPage = new AppShell(navigationService);
       
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window =  base.CreateWindow(activationState);

        window.X = 1;
        window.Y = 1;
       
        window.MaximumWidth= 1000;
        window.MaximumHeight = 800;

        window.MinimumWidth= 1000;
        window.MinimumHeight= 800;


        window.Width= 1000;
        window.Height= 800;

        return window;
    }
}
