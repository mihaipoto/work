using System.Windows.Input;

namespace Aplicatie.Controls;

public partial class AcceptCancelControl : ContentView
{

  

    public static BindableProperty AcceptCommandProperty = BindableProperty.Create(nameof(AcceptCommand),
        typeof(ICommand), typeof(AcceptCancelControl));

    public static BindableProperty CancelCommandProperty = BindableProperty.Create(nameof(CancelCommand),
        typeof(ICommand), typeof(AcceptCancelControl));




    public ICommand AcceptCommand
    {
        get => (ICommand)GetValue(AcceptCommandProperty);
        set => SetValue(AcceptCommandProperty, value);
    }

    public ICommand CancelCommand
    {
        get => (ICommand)GetValue(CancelCommandProperty);
        set => SetValue(CancelCommandProperty, value);
    }



    public AcceptCancelControl()
	{
		InitializeComponent();
	}
}