using Aplicatie.Core.Models;
using Aplicatie.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Options;

namespace Aplicatie.ViewModels;

public partial class FlowItemConfigurationVM : ObservableValidator
{
    [ObservableProperty]
    int _idFlux;

    [ObservableProperty]
    List<EnumerabilVM> _enumerabile;


    public FlowItemConfigurationVM()
    {

    }

    public FlowItemConfigurationVM(FlowItemSettings source)
    {

        try
        {
            IdFlux = source.IdFlux;
            Enumerabile = new();
            Enumerabile.MapList(
                listaSursa: source.Enumerabile,
                creator: e => new (e));
        }
        catch (Exception ex)
        {

            throw;
        }

    }

   
}