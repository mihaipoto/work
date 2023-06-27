namespace Aplicatie.Core.Models;

public class FlowItemSettings
{
    public int IdFlux { get; set; }
    public List<Enumerabil> Enumerabile { get; set; }



    public FlowItemSettings()
    {
    }

    public FlowItemSettings(FlowItemSettings source)
    {
        try
        {
            IdFlux = source.IdFlux;
            Enumerabile = new();
            Enumerabile.MapList<Enumerabil, Enumerabil>(
                listaSursa: source.Enumerabile,
                creator: e => new Enumerabil(e));
        }
        catch (Exception ex)
        {

            throw;
        }
        
    }
}
