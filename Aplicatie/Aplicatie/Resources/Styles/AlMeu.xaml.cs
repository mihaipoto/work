using Aplicatie.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Options;
using Microsoft.Maui.Controls.Xaml;

namespace Aplicatie.Resources.Styles;

[ObservableObject]
public partial class AlMeu : ResourceDictionary
{

    public Tema TemaCurenta { get; private set; }



    public Color CuloareButon => Color.FromArgb(TemaCurenta.BackgroundButon);

    public AlMeu()
    {
        //Application.Current.Dispatcher.
        
    }

    public AlMeu(IOptionsMonitor<AppConfig> appConfigOptionsMonitor)
	{
        TemaCurenta = appConfigOptionsMonitor.CurrentValue.TemaCurenta;



        appConfigOptionsMonitor.OnChange((optiuniNoi) =>
        {
            TemaCurenta = optiuniNoi.TemaCurenta;
            OnPropertyChanged(nameof(CuloareButon));
        });

        OnPropertyChanged(nameof(CuloareButon));
        InitializeComponent();
	}
}