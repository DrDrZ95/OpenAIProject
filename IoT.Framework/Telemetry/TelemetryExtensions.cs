using System.Diagnostics;
using IoT.Framework.Devices;

namespace IoT.Framework.Telemetry;

public static class TelemetryExtensions
{
    private static readonly ActivitySource ActivitySource = new("IoT.Framework");

    public static Activity? StartDeviceActivity(this IIoTDevice device, string name)
    {
        var activity = ActivitySource.StartActivity(name);
        activity?.SetTag("device.id", device.DeviceId);
        return activity;
    }
}
