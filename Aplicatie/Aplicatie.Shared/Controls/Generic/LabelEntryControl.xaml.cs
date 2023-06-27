namespace Aplicatie.Controls;

public partial class LabelEntryControl : ContentView
{

    public static readonly BindableProperty CheieProperty = BindableProperty.Create(nameof(Cheie),
    typeof(string), typeof(LabelEntryControl));

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder),
       typeof(string), typeof(LabelEntryControl));

    public static readonly BindableProperty ValoareCompletataProperty = BindableProperty.Create(nameof(ValoareCompletata),
      typeof(string), typeof(LabelEntryControl));

    public string Cheie
    {
        get => (string)GetValue(CheieProperty);
        set => SetValue(CheieProperty, value);
    }

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public string ValoareCompletata
    {
        get => (string)GetValue(ValoareCompletataProperty);
        set => SetValue(ValoareCompletataProperty, value);
    }

    public LabelEntryControl()
	{
		InitializeComponent();
	}
}