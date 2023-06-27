using Aplicatie.Core;
using Aplicatie.Core.Models;
using Aplicatie.Core.Services;
using Aplicatie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;

namespace Aplicatie;


public partial class App : Application
{


    public IServiceProvider serviceProviderr;

    public App(FluxManager fm,
        INavigationService navigationService, IServiceProvider serviceProvider
        )
    {
        try
        {

            serviceProviderr = serviceProvider;
            InitializeComponent();
            MainPage = new AppShell(navigationService);
        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex);
        }
       
    }

    protected override void OnStart()
    {

        base.OnStart();
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