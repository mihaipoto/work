using Aplicatie.Core;
using Aplicatie.Services;
using System.Diagnostics;

namespace Aplicatie;

public partial class App : Application
{

    public App(INavigationService navigationService)
    {
        try
        {
            InitializeComponent();

            MainPage = new AppShell(navigationService);
        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex);
        }
        
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        window.X = 1;
        window.Y = 1;

        //window.MaximumWidth = 1000;
        //window.MaximumHeight = 800;

        //window.MinimumWidth = 1000;
        //window.MinimumHeight = 800;

        window.Width = 1000;
        window.Height = 800;

        return window;
    }
}