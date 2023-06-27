using Aplicatie.ViewModels;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Aplicatie.Views;

public partial class StartPage : ContentPage
{
	public StartPage(StartViewModel vm)
	{
		BindingContext= vm;
		InitializeComponent();
	}


    async void Expander_ExpandedChanged(object sender, ExpandedChangedEventArgs e)
    {
        var collapsedText = e.IsExpanded ? "expanded" : "collapsed";
        await Toast.Make($"Expander is {collapsedText}").Show(CancellationToken.None);
    }
}