# eBPF 使用与 .NET 集成指南

本文档概述如何在 Linux 系统上安装并启动 eBPF 工具（以 btrace 为例），以及在 .NET 项目中主动接收和采集 eBPF 数据的方法。文档还简单介绍 eBPF 与操作系统 buffer pool 等内核组件的交互方式。

## 1. eBPF 工具安装

1. 推荐使用较新的 Linux 发行版（如 Ubuntu 22.04 或更高）以确保内核对 eBPF 的支持。
2. 安装必要的软件包：
   ```bash
   sudo apt update
   sudo apt install -y bpfcc-tools linux-headers-$(uname -r)
   ```
   上述命令会安装 bcc 工具集，其中包含 `btrace` 等 eBPF 示例工具。

## 2. 启动和使用 btrace

1. 查看可用的 btrace 脚本：
   ```bash
   ls /usr/share/bcc/tools | grep btrace
   ```
2. 运行 btrace 脚本以跟踪特定系统调用（示例）：
   ```bash
   sudo btrace /usr/share/bcc/tools/biolatency.bt
   ```
   该命令会在终端中实时打印与块设备 I/O 延迟相关的事件，方便分析性能瓶颈。

## 3. 在 .NET 项目中接收和采集 eBPF 数据

1. 在 .NET 项目中，可以通过 **System.Diagnostics.Process** 调用外部命令来执行 btrace，并读取其标准输出：
   ```csharp
   using var process = new Process
   {
       StartInfo = new ProcessStartInfo
       {
           FileName = "sudo",
           Arguments = "btrace /usr/share/bcc/tools/biolatency.bt",
           RedirectStandardOutput = true,
           UseShellExecute = false,
       }
   };
   process.Start();
   string output = await process.StandardOutput.ReadToEndAsync();
   process.WaitForExit();
   // 进一步处理输出数据
   ```
2. 若需长期运行或高频采集，可考虑通过管道或 Socket 将 eBPF 数据传递给 .NET 后台服务进行解析。

## 4. eBPF 与 buffer pool 的交互

* eBPF 程序通常通过内核 hooks（如 kprobe、tracepoint 或 tc）挂载在内核路径上，能够在关键代码执行时捕获数据。
* 对于 buffer pool（如页缓存或网络接收缓冲区）相关的事件，可在对应的内核函数或 tracepoint 上插入 eBPF 程序，实时跟踪缓冲区分配、释放及命中率等信息。
* 数据被捕获后，eBPF 程序可以借助 perf buffer 或 BPF map 将数据传递到用户态。用户态程序（例如 .NET 后台服务）通过读取这些缓冲区即可获得实时的系统指标。

## 5. 结合 OpenTelemetry

1. 在 .NET 项目中配置 OpenTelemetry，创建自定义 Span：
   ```csharp
   using var tracerProvider = Sdk.CreateTracerProviderBuilder()
       .AddSource("CustomBPF")
       .AddConsoleExporter()
       .Build();
   var activitySource = new ActivitySource("CustomBPF");
   using var activity = activitySource.StartActivity("eBPF Event");
   activity?.SetTag("ebpf.output", output); // 将 eBPF 输出作为属性写入 Span
   ```
2. 通过将上述采集到的 eBPF 输出字符串写入 Span Tag，即可在追踪数据中观测系统层面事件，实现应用和内核指标的关联分析。
