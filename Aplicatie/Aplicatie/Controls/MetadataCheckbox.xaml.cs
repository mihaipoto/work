using Aplicatie.ViewModels;
using System.Diagnostics;

namespace Aplicatie.Controls;

public partial class MetadataCheckbox : ContentView
{

    public static readonly BindableProperty CheieProperty = BindableProperty.Create(nameof(Cheie),
        typeof(string), typeof(MetadataCheckbox));

    public static readonly BindableProperty ValoareProperty = BindableProperty.Create(nameof(Valoare),
       typeof(string), typeof(MetadataCheckbox));

    public string Cheie
    {
        get => (string)GetValue(MetadataCheckbox.CheieProperty);
        set => SetValue(MetadataCheckbox.CheieProperty, value);
    }

    public string Valoare
    {
        get => (string)GetValue(MetadataCheckbox.CheieProperty);
        set => SetValue(MetadataCheckbox.CheieProperty, value);
    }

    public MetadataCheckbox()
	{
		InitializeComponent();
	}
}