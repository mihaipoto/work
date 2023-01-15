using Aplicatie.ViewModels;

namespace Aplicatie.Views;

public partial class StartPage : ContentPage
{
	public StartPage(StartViewModel vm)
	{
		BindingContext= vm;
		InitializeComponent();
	}
}