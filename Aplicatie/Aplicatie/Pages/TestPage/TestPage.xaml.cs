namespace Aplicatie.Pages;

public partial class TestPage : ContentPage
{
	public TestPage(TestPageViewModel vm)
	{
		InitializeComponent();

		BindingContext= vm;
	}
}