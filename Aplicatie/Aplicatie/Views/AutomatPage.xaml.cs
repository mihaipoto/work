

using Aplicatie.ViewModels;

namespace Aplicatie.Pages;


public partial class AutomatPage : ContentPage
{
    

    public AutomatPage(AutomatViewModel vm)
    {
      
        BindingContext = vm;

        InitializeComponent();

       
    }

  
}

