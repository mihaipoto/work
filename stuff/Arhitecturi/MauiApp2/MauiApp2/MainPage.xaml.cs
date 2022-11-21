namespace MauiApp2;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _vm;

    public MainPage(MainViewModel vm)
    {
        _vm = vm;
        BindingContext = _vm;

        InitializeComponent();

        PopUpView pop = new();
    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
       
    }
}