using Aplicatie.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Aplicatie.ViewModels;

public partial class EnumerabilVM : ObservableObject
{
    [ObservableProperty]
    string nume;

    [ObservableProperty]
    List<string> valori;

    [ObservableProperty]
    string valoareCompletata;

    [ObservableProperty]
    string regexValidator;

    public EnumerabilVM()
    {

    }
    public EnumerabilVM(Enumerabil enumerabil)
    {
        Nume = enumerabil.Nume;
        Valori = new();
        Valori.MapList<string>(listaSursa: enumerabil.Valori);
        RegexValidator = enumerabil.RegexValidator;
    }

    [ObservableProperty]
    bool isCheckboxChecked;

    [ObservableProperty]
    string entryText;

    

}
