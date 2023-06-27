namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NRAiBiAaIQQuGjN/V0R+XU9HclRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31TcEdmWX1acndRT2JaVg==;Mgo+DSMBMAY9C3t2V1hhQlJAfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5VdEBjW3tcc3BcQmBb;MjUwNzEyMUAzMjMyMmUzMDJlMzBCNSsyRzUrbHlaVkE5dHIzNk50THgxcmZUMWM2VzZ1cCtLY3A2N0JzRUhRPQ==;MjUwNzEyMkAzMjMyMmUzMDJlMzBUTzFsT0JJS1RKWFd3UUsyVXVzZ0dUQUNDc2haVG9TK1JjSExpSmRuMjRnPQ==");
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}