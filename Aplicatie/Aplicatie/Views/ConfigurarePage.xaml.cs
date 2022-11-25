using Aplicatie.ViewModels;

namespace Aplicatie.Pages;

public partial class ConfigurarePage : ContentPage
{
    private readonly ConfigurareViewModel _vm;

    public ConfigurarePage(ConfigurareViewModel vm)
	{
		InitializeComponent();
        _vm = vm;
        BindingContext= _vm;

    }
}