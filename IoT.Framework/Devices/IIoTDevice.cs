namespace IoT.Framework.Devices;

public interface IIoTDevice
{
    string DeviceId { get; }

    Task ConnectAsync(CancellationToken cancellationToken = default);
    Task DisconnectAsync(CancellationToken cancellationToken = default);
    Task SendAsync(byte[] payload, CancellationToken cancellationToken = default);
    Task<byte[]> ReceiveAsync(CancellationToken cancellationToken = default);
}
