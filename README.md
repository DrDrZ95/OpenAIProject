# NET.Agent

This repository contains a simple Blazor Server application targeting **.NET 8** alongside a lightweight IoT framework.

## Solutions

- `NET.Agent.sln` – Blazor Server sample.
- `IoT.Framework.sln` – IoT framework with device abstractions and telemetry helpers.

## Building

Use the .NET 8 SDK to build and run the project:

```bash
dotnet build NET.Agent.sln
dotnet run --project NET.Agent/NET.Agent.csproj
```

## Documentation

- eBPF integration: [docs/eBPF_integration.md](docs/eBPF_integration.md)
- IoT framework overview: [docs/iot_framework_overview.md](docs/iot_framework_overview.md)
