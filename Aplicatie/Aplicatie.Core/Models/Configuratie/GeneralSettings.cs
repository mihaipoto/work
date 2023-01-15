using Aplicatie.Core.Enums;

namespace Aplicatie.Core.Models;

public class GeneralSettings
{
    public DateTime LastModified { get; set; }
    public string ConfigFilePath { get; set; }

   
    public string OutboxPath { get; set; }

    public string InboxPath { get; set; }

    public GeneralSettings()
    {

    }

    public GeneralSettings(GeneralSettings source)
    {
        LastModified = source.LastModified;
        ConfigFilePath = source.ConfigFilePath;
        OutboxPath = source.OutboxPath;
        InboxPath = source.InboxPath;
    }
}