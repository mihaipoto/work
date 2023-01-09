using Aplicatie.Core.Modele;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie.ViewModels;

public partial class AppConfigVM : ObservableObject
{
    [ObservableProperty]
    List<ModDeLucruVM> moduriDeLucru;


    [ObservableProperty]
    DateTime lastModified;

    [ObservableProperty]
    string filePath;

    [ObservableProperty]
    List<FluxModelVM> fluxuri;


    public AppConfigVM(AppConfig appConfig)
    {
        ModuriDeLucru = new();
        ModuriDeLucru.MapeazaLista(appConfig.ModuriDeLucru, creator: m => new(m));
        
        LastModified = appConfig.LastModified;
        FilePath = appConfig.FilePath;
        Fluxuri = new();
        Fluxuri.MapeazaLista<FluxModel,FluxModelVM>(
            listaSursa: appConfig.Fluxuri, 
            creator: f => new FluxModelVM(f));
    }


    //public static explicit operator AppConfigVM(AppConfig appConfig)
    //{
    //    return new AppConfigVM(appConfig);

    //}

    //public static explicit operator AppConfig(AppConfigVM appConfigVM)
    //{
    //    return appConfigVM.ToAppConfig();
    //}

   
}

public partial class ModDeLucruVM : ObservableObject
{
    [ObservableProperty]
    string nume;

    [ObservableProperty]
    bool esteActiv;

    public ModDeLucruVM()
    {

    }
    public ModDeLucruVM(ModDeLucru modDeLucru)
    {
        Nume = modDeLucru.Nume;
        EsteActiv = modDeLucru.EsteActiv;
    }

   
}

public partial class FluxModelVM : ObservableObject
{
    [ObservableProperty]
    public int idFlux;

    [ObservableProperty]
    public List<EnumerabilVM> enumerabile = new();

    public FluxModelVM()
    {

    }

    public FluxModelVM(FluxModel flux)
    {
        IdFlux = flux.IdFlux;
        Enumerabile = new();
        Enumerabile.MapeazaLista<Enumerabil, EnumerabilVM>(
            listaSursa: flux.Enumerabile,
            creator: e => new EnumerabilVM(e));
    }
}

public partial class EnumerabilVM : ObservableObject
{
    [ObservableProperty]
    public string nume;


    [ObservableProperty]
    public List<string> valori;

    public EnumerabilVM()
    {

    }
    public EnumerabilVM(Enumerabil enumerabil)
    {
        Nume = enumerabil.Nume;
        Valori = new();
        Valori.MapeazaLista<string>(listaSursa: enumerabil.Valori);
    }

    [ObservableProperty]
    bool isCheckboxChecked;

    [ObservableProperty]
    string entryText;

    

}

public static class AppConfigExtensions
{
    

    public static AppConfig ToAppConfig(this AppConfigVM appConfigVM)
    {
        var appConfig = new AppConfig();
        appConfig.ModuriDeLucru = new();
        appConfig.ModuriDeLucru.MapeazaLista(appConfigVM.ModuriDeLucru, creator: m => m.ToModDeLucru());
        appConfig.LastModified = appConfigVM.LastModified;
        appConfig.FilePath = appConfigVM.FilePath;
        appConfig.Fluxuri.MapeazaLista<FluxModelVM,FluxModel>(
            listaSursa: appConfigVM.Fluxuri,
            creator: f => f.ToFluxModel());
        return appConfig;

    }

    public static ModDeLucru ToModDeLucru(this ModDeLucruVM modDeLucruVM)
    {
        var modDeLucru = new ModDeLucru();
        modDeLucru.Nume = modDeLucruVM.Nume;
        modDeLucru.EsteActiv = modDeLucruVM.EsteActiv;
        return modDeLucru;
    }

    public static FluxModel ToFluxModel(this FluxModelVM fluxModelVM)
    {
        var fluxModel = new FluxModel();
        fluxModel.IdFlux = fluxModelVM.IdFlux;
        fluxModel.Enumerabile.MapeazaLista<EnumerabilVM, Enumerabil>(
            listaSursa: fluxModelVM.enumerabile,
            creator: enumerabilVM => enumerabilVM.ToEnumerabil());
        return fluxModel;
        
    }

    public static Enumerabil ToEnumerabil(this EnumerabilVM enumerabilVM)
    {
        var enumerabil = new Enumerabil();
        enumerabil.Nume = enumerabilVM.Nume;
        enumerabil.Valori.MapeazaLista<string>(enumerabilVM.valori);
        return enumerabil;
    }

}
