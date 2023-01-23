using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Windows.Input;

namespace Aplicatie.Controls;

public partial class FlowControl : ContentView
{
	public FlowControl()
	{
		InitializeComponent();
	}

    async void Expander_ExpandedChanged(object sender, ExpandedChangedEventArgs e)
    {
        var collapsedText = e.IsExpanded ? "expanded" : "collapsed";
        await Toast.Make($"Expander is {collapsedText}").Show(CancellationToken.None);
    }


    

}