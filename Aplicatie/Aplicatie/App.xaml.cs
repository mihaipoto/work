using Aplicatie.Core;

namespace Aplicatie;

public partial class App : Application
{
	public static IServiceProvider ServiceProvider { get; private set; }

	public App(IServiceProvider provider)
	{
		InitializeComponent();

        //Application.Current.UserAppTheme = AppTheme.Dark;
        ServiceProvider = provider;

        _ = ServiceProvider.GetServices(typeof(FlowControl));
        MainPage = new AppShell();

		
	}
}
