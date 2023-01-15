using Aplicatie.ViewModels;

namespace Aplicatie.Views;

public partial class ConfigurarePage : ContentPage
{
    

    public ConfigurarePage(ConfigurareViewModel vm)
	{
		InitializeComponent();
        
        BindingContext= vm;

    }
}