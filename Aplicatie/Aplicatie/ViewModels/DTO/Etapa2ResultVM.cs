using Aplicatie.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie.ViewModels;

public partial class Etapa2ResultVM : ObservableObject
{
    [ObservableProperty]
    string _etapa2Nume;

    [ObservableProperty]
    List<ItemEtapa2VM> _etapa2ListaItemi;

    public Etapa2ResultVM()
    {

    }

    public Etapa2ResultVM(Etapa2ResultModel model)
    {
        Etapa2Nume= model.Etapa2Nume;
        Etapa2ListaItemi = new();
        Etapa2ListaItemi.MapList(model.Etapa2ListaItemi, (i) => new(i));
    }


}


public partial class ItemEtapa2VM : ObservableObject
{
    [ObservableProperty]
    string _itemNume;

    [ObservableProperty]
    string _itemValoare;

    [ObservableProperty]
    SubItemEtapa2VM _subItemEtapa;

    public ItemEtapa2VM()
    {

    }

    public ItemEtapa2VM(ItemEtapa2Model model)
    {
        ItemNume = model.ItemNume;
        ItemValoare =model.ItemValoare;
        SubItemEtapa = new(model.SubItemEtapa);
    }
}

public partial class SubItemEtapa2VM : ObservableObject
{
    [ObservableProperty]
    string _subItemNume;

    [ObservableProperty]
    string _subItemValoare;

    public SubItemEtapa2VM()
    {

    }

    public SubItemEtapa2VM(SubItemEtapa2Model model)
    {
        SubItemNume = model.SubItemNume;
        SubItemValoare = model.SubItemValoare;
    }
}
