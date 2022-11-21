namespace MauiApp2;

public partial class App : Application
{
    public App()
    {
        //Register Syncfusion license
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NRAiBiAaIQQuGjN/V0Z+Xk9EaFtBVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdEVqWHhfcHVTQmJbV0Zw;NzE4NDk5QDMyMzAyZTMyMmUzMG1LNzVmNDNMbnluZHZNL2JjMFdTY1BZL1FGNkhyNTh3NzF2ZUpLajdCOGs9");

        InitializeComponent();

        MainPage = new AppShell();
    }
}