using Aplicatie.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aplicatie.Core.Models;

public class USBDeviceEvent
{
    public string DriveLetter { get; set; }

    public EventType Tip { get; set; }

    public USBDevice USBDevice { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, ModelExtensions.CustomJsonSerializerOptions);
    }
}
