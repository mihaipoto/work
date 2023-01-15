namespace Aplicatie.Controls;

public partial class MetadataGrupCheckbox : ContentView
{

    public static readonly BindableProperty CheieProperty = BindableProperty.Create(nameof(Cheie),
    typeof(string), typeof(MetadataGrupCheckbox));

    public static readonly BindableProperty ValoareProperty = BindableProperty.Create(nameof(Valoare),
       typeof(string), typeof(MetadataGrupCheckbox));

    public string Cheie
    {
        get => (string)GetValue(CheieProperty);
        set => SetValue(CheieProperty, value);
    }

    public string Valoare
    {
        get => (string)GetValue(CheieProperty);
        set => SetValue(CheieProperty, value);
    }

    public MetadataGrupCheckbox()
	{
		InitializeComponent();
	}
}