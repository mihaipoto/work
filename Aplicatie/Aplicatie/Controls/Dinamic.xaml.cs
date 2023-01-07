

using Aplicatie.Core.Modele;
using Aplicatie.ViewModels;
using Aplicatie.Views;
using CommunityToolkit.Maui.Markup;
using Microsoft.Extensions.Options;

namespace Aplicatie.Controls;


public partial class Dinamic : ContentView
{
    public static readonly BindableProperty ViewModelProperty = BindableProperty.Create("ViewModel",
typeof(AppConfigVM), typeof(Dinamic));

    public AppConfigVM ViewModel
    {
        get => (AppConfigVM)GetValue(Dinamic.ViewModelProperty);
        set => SetValue(Dinamic.ViewModelProperty, value);
    }

    public Dinamic()
    {
        InitializeComponent();
        ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        Content = new VerticalStackLayout
        {
            new Label()
            .Bind(Label.TextProperty, nameof(ViewModel.ModDeLucru))
            .TextColor(Colors.Red)
            
        };
	}

    private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        throw new NotImplementedException();
    }

    
}