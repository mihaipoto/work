using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace Aplicatie.Controls;


public partial class LabelLabelControl : ContentView
{
    public static readonly BindableProperty CheieProperty = BindableProperty.Create(nameof(Cheie),
    typeof(string), typeof(LabelLabelControl));

    public static readonly BindableProperty ValoareProperty = BindableProperty.Create(nameof(Valoare),
       typeof(string), typeof(LabelLabelControl));

    //public static readonly BindableProperty EsteExpandabilProperty = BindableProperty.Create(nameof(EsteExpandabil),
    //   typeof(bool), typeof(LabelLabelControl), defaultValue: false);

    public static BindableProperty ExpandCommandProperty =  BindableProperty.Create(nameof(ExpandCommand), 
        typeof(ICommand), typeof(LabelLabelControl));

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

    //public bool EsteExpandabil
    //{
    //    get =>(bool)GetValue(EsteExpandabilProperty);
    //    set => SetValue(EsteExpandabilProperty, value);
    //}






    //private static void OnExpandCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    //{
    //    var f = (LabelLabelControl)bindable;
    //    var comanda = (ICommand)newValue;
    //    if (comanda is null) { f.IsExpandable = false; }
    //    else { f.IsExpandable = true; }
    //}


    public ICommand ExpandCommand
    {
        get => (ICommand)GetValue(ExpandCommandProperty);
        set => SetValue(ExpandCommandProperty, value);
    }


    



    public LabelLabelControl()
    {
        InitializeComponent();
    }
}