# NET.Agent

This repository contains a simple Blazor Server application targeting **.NET 8**. The solution file `NET.Agent.sln` references a single project `NET.Agent` which can be opened using Visual Studio or the `dotnet` CLI.

## Building

Use the .NET 8 SDK to build and run the project:

```bash
dotnet build NET.Agent.sln
dotnet run --project NET.Agent/NET.Agent.csproj
```

## Documentation

Additional information on integrating eBPF tools with this project can be found in [docs/eBPF_integration.md](docs/eBPF_integration.md).
