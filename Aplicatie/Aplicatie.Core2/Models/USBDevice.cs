using Aplicatie.Core.Contracts;
using System.Text.Json;

namespace Aplicatie.Core.Models;

public class USBDevice : IFluxInitiator, IEquatable<USBDevice>
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

    public bool Equals(USBDevice? other)
    {
        if(other is null) return false;
        if(Hash.Equals(other.Hash)) return true;
        return false;
    }
}

//public record USBDevice(string DeviceId, string PnpDeviceId) : IFluxInitiator
//{
//    public string Hash { get; init; }
//    Hash = (DeviceId + PnpDeviceId).HashSHA512();
//}