# IoT Framework Overview

The `IoT.Framework` solution provides a minimal starting point for building IoT-ready .NET applications. It offers basic abstractions for devices, a device manager, and simple telemetry helpers based on `System.Diagnostics`.

## Solution structure

- `IoT.Framework/IoT.Framework.csproj` - Class library containing the IoT abstractions.
- `IoT.Framework.sln` - Solution file referencing the library project.

## Getting started

1. Include the project in your application and implement `IIoTDevice` for each device type.
2. Use `DeviceManager` to register and retrieve devices at runtime.
3. Call `StartDeviceActivity` to produce telemetry spans that include the device identifier, enabling end-to-end tracing across your IoT workflows.

These building blocks are intentionally lightweight so beginners can adapt them to complex business scenarios and expand the framework with features such as protocol adapters, persistence layers, or advanced telemetry.
