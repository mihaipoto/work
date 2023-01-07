using Aplicatie.ViewModels;
using CommunityToolkit.Maui.Markup;
using System.Diagnostics;
using Windows.Foundation;

namespace Aplicatie.Controls;

public class Dinamic2 : ContentView
{
    public static readonly BindableProperty ViewModelProperty = BindableProperty.Create("ViewModel", 
        typeof(AppConfigVM), typeof(Dinamic2), propertyChanged: OnViewModelChanged);

    private static void OnViewModelChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var f = (Dinamic2)bindable;
        f.Afiseaza((AppConfigVM)newValue);
        Debug.WriteLine(newValue.ToString());
    }

    public AppConfigVM ViewModel
    {
        get => (AppConfigVM)GetValue(Dinamic2.ViewModelProperty);
        set => SetValue(Dinamic2.ViewModelProperty, value);
    }

    
    void Afiseaza(AppConfigVM vm)
    {
        Content = new VerticalStackLayout
        {
            new Label()
            .Bind(Label.TextProperty, nameof(AppConfigVM.ModDeLucru))
            .TextColor(Colors.Red)

        };
    }


  


  

    public Dinamic2()
    {
         
       
    }
}