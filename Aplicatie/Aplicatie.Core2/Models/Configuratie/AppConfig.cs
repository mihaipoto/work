
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Aplicatie.Core.Models;


public record AppConfig
{
    public GeneralSettings? GeneralConfiguration { get; set; }

    public List<FlowItemSettings>? FlowListConfiguration { get; set; }

    public UsbServiceSettings? UsbServiceConfiguration { get; set; }

    public Workflow? WorkflowConfiguration { get; set; }

    public Tema TemaCurenta { get; set; }

    public AppConfig()
    {
    }

    public AppConfig(AppConfig source)
    {
        try
        {
            GeneralConfiguration = new(source.GeneralConfiguration ?? throw new Exception("GenConfig is null here"));
            WorkflowConfiguration= new(source?.WorkflowConfiguration);
            FlowListConfiguration = new();
            FlowListConfiguration.MapList(
               listaSursa: source?.FlowListConfiguration,
               creator: f => new(f));
            UsbServiceConfiguration = new(source?.UsbServiceConfiguration);
        }
        catch (Exception ex )
        {

            Debug.WriteLine(ex);
        }
       
    }

}

