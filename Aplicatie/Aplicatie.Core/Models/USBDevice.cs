using Aplicatie.Core.Contracts;
using System.Text.Json;

namespace Aplicatie.Core.Models;

public class USBDevice : IFluxInitiator
{
    public string DeviceId { get; init; } = string.Empty;
    public string PnpDeviceId { get; init; } = string.Empty;

    public string Hash { get; init; }

    public USBDevice(string deviceId, string pnpDeviceId)
    {
        DeviceId = deviceId;
        PnpDeviceId = pnpDeviceId;
        Hash = (DeviceId + PnpDeviceId).HashSHA512();
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, ModelExtensions.CustomJsonSerializerOptions);
    }
}