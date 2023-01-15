namespace Aplicatie.Controls;

public partial class LabelLabelController : ContentView
{
    public static readonly BindableProperty CheieProperty = BindableProperty.Create(nameof(Cheie),
    typeof(string), typeof(LabelLabelController));

    public static readonly BindableProperty ValoareProperty = BindableProperty.Create(nameof(Valoare),
       typeof(string), typeof(LabelLabelController));

    public string Cheie
    {
        get => (string)GetValue(CheieProperty);
        set => SetValue(CheieProperty, value);
    }

    public string Valoare
    {
        get => (string)GetValue(ValoareProperty);
        set => SetValue(ValoareProperty, value);
    }

    public LabelLabelController()
	{
		InitializeComponent();
	}
}