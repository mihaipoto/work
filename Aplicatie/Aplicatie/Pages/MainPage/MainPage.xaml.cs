

using Aplicatie.ViewModels;

namespace Aplicatie.Pages;


public partial class MainPage : ContentPage
{
    

    public MainPage(MainViewModel vm)
    {
      
        BindingContext = vm;

        InitializeComponent();

       
    }

  
}

