using Aplicatie.ViewModels;

namespace Aplicatie.Views;

public partial class AddPage : ContentPage
{
	public AddPage(AddViewModel vm)
	{
		BindingContext= vm;
		InitializeComponent();
		
	}
}