using System.Collections.Concurrent;
using IoT.Framework.Devices;

namespace IoT.Framework;

public class DeviceManager
{
    private readonly ConcurrentDictionary<string, IIoTDevice> _devices = new();

    public bool RegisterDevice(IIoTDevice device) =>
        _devices.TryAdd(device.DeviceId, device);

    public IIoTDevice? GetDevice(string deviceId) =>
        _devices.TryGetValue(deviceId, out var device) ? device : null;

    public IEnumerable<IIoTDevice> GetAllDevices() => _devices.Values;
}
