using Aplicatie.ViewModels;
using CommunityToolkit.Maui.Markup;
using System.Diagnostics;
using Windows.Foundation;

namespace Aplicatie.Controls;


public enum TipControl
{
    Label,
    Picker,
    Checkbox
}

public class Dinamic : ContentView
{

    public static readonly BindableProperty ViewModelProperty = BindableProperty.Create("ViewModel", 
        typeof(FluxModelVM), typeof(Dinamic), propertyChanged: OnViewModelChanged);

    private static void OnViewModelChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var f = (Dinamic)bindable;
        f.Afiseaza((FluxModelVM)newValue);
        Debug.WriteLine(newValue.ToString());
    }

    public FluxModelVM ViewModel
    {
        get => (FluxModelVM)GetValue(Dinamic.ViewModelProperty);
        set => SetValue(Dinamic.ViewModelProperty, value);
    }

    VerticalStackLayout parent;

    void Afiseaza(FluxModelVM vm)
    {
        parent = new VerticalStackLayout();
        vm.Enumerabile.ForEach(e => ConstruiesteController(e));
       
        Content= parent;
    }

    void ConstruiesteController(EnumerabilVM e)
    {
        if (e.Valori.Count == 0) ConstruiesteEntry(e);
        if (e.Valori.Count == 1) ConstruiesteLabel(e);
        if (e.Valori.Count == 2) ConstruiesteCheckbox(e);
        if (e.Valori.Count > 2) ConstruiesteGrupCheckbox(e);
        
    }

    private void ConstruiesteGrupCheckbox(EnumerabilVM e)
    {
        var grupCheckboxControl = new MetadataGrupCheckbox();
        grupCheckboxControl.BindingContext = e;
        parent.Children.Add(grupCheckboxControl);
    }

    private void ConstruiesteCheckbox(EnumerabilVM e)
    {
        var checkboxControl = new MetadataCheckbox();
        checkboxControl.BindingContext = e;
        parent.Children.Add(checkboxControl);

    }

    private void ConstruiesteLabel(EnumerabilVM e)
    {
        var labelControl = new MetadataLabel();
        labelControl.BindingContext = e;   
        parent.Children.Add(labelControl);
    }

    private void ConstruiesteEntry(EnumerabilVM e)
    {
        var entryControl = new MetadataEntry();
        entryControl.BindingContext = e;
        parent.Children.Add(entryControl);
    }

   
}

