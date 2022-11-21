using Aplicatie.ViewModels;

namespace Aplicatie.Views;


public partial class MainPage : ContentPage
{
    

    public MainPage(MainViewModel vm)
    {
      
        BindingContext = vm;

        InitializeComponent();

       
    }

  
}

