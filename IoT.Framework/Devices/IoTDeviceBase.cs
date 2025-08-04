namespace IoT.Framework.Devices;

public abstract class IoTDeviceBase : IIoTDevice
{
    public string DeviceId { get; }

    protected IoTDeviceBase(string deviceId) => DeviceId = deviceId;

    public abstract Task ConnectAsync(CancellationToken cancellationToken = default);
    public abstract Task DisconnectAsync(CancellationToken cancellationToken = default);
    public abstract Task SendAsync(byte[] payload, CancellationToken cancellationToken = default);
    public abstract Task<byte[]> ReceiveAsync(CancellationToken cancellationToken = default);
}
