namespace Aplicatie.ViewModels;

public static class AppConfigExtensions
{
    //public static AppConfig ToAppConfig(this AppConfigVM appConfigVM)
    //{
    //    var appConfig = new AppConfig();
    //    appConfig.ModuriDeLucru = new();
    //    appConfig.ModuriDeLucru.MapeazaLista(appConfigVM.ModuriDeLucru, creator: m => m.ToModDeLucru());
    //    appConfig.LastModified = appConfigVM.LastModified;
    //    appConfig.FilePath = appConfigVM.FilePath;
    //    appConfig.Fluxuri = new();
    //    appConfig.Fluxuri.MapList<FluxModelVM,FlowItemSettings>(
    //        listaSursa: appConfigVM.Fluxuri,
    //        creator: f => f.ToFluxModel());
    //    return appConfig;

    //}

    //public static ModDeLucru ToModDeLucru(this ModDeLucruVM modDeLucruVM)
    //{
    //    var modDeLucru = new ModDeLucru();
    //    modDeLucru.Nume = modDeLucruVM.Nume;
    //    modDeLucru.EsteActiv = modDeLucruVM.EsteActiv;
    //    return modDeLucru;
    //}

    //public static FlowItemSettings ToFluxModel(this FluxModelVM fluxModelVM)
    //{
    //    var fluxModel = new FlowItemSettings();
    //    fluxModel.IdFlux = fluxModelVM.IdFlux;
    //    fluxModel.Enumerabile = new();
    //    fluxModel.Enumerabile.MapList<EnumerabilVM, Enumerabil>(
    //        listaSursa: fluxModelVM.enumerabile,
    //        creator: enumerabilVM => enumerabilVM.ToEnumerabil());
    //    return fluxModel;

    //}

    //public static Enumerabil ToEnumerabil(this EnumerabilVM enumerabilVM)
    //{
    //    var enumerabil = new Enumerabil();
    //    enumerabil.Nume = enumerabilVM.Nume;
    //    enumerabil.Valori = new();
    //    enumerabil.Valori.MapList<string>(enumerabilVM.Valori);
    //    enumerabil.ValoareCompletata = enumerabilVM.ValoareCompletata;
    //    enumerabil.RegexValidator = enumerabilVM.RegexValidator;
    //    return enumerabil;
    //}
}