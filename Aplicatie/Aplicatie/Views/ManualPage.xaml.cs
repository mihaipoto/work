

using Aplicatie.ViewModels;

namespace Aplicatie.Pages;


public partial class ManualPage : ContentPage
{
    

    public ManualPage(ManualViewModel vm)
    {
      
        BindingContext = vm;

        InitializeComponent();

       
    }

  
}

