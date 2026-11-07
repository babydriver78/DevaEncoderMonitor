# DevaEncoderMonitor

[![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![WinForms](https://img.shields.io/badge/UI-WinForms-0078D4?style=flat-square&logo=visualstudio)](https://learn.microsoft.com/dotnet/desktop/winforms/)
[![Simulator-first](https://img.shields.io/badge/Mode-Simulator--first-FF9800?style=flat-square)](./src/DevaEncoderMonitor.Core/SimulatedEnclib.cs)
[![19 tests](https://img.shields.io/badge/Tests-19%20green-4CAF50?style=flat-square&logo=xunit)](./src/DevaEncoderMonitor.Tests)

Live position monitor for Deva Electronics encoder interfaces. A small, beginner-friendly .NET application that polls a DEVA001 3-Axis PCI encoder interface and displays real-time position, velocity, and direction per axis.

## Target hardware

**DEVA001 3-Axis PCI Incremental Encoder Interface** (`001-3INC-REN-PCI`).

The software talks to the card through the vendor SDK (`ENCLIB.H` / `enclib32.lib`) behind an `IEnclib` abstraction. The vendor SDK headers and libraries live under `Deva001 SDK/`.

## Simulator-first status

No PCIe card is required to develop or test this project. All encoder data is currently simulated by `SimulatedEnclib`, a thread-safe, deterministic mock of the DEVA001 driver (`SimulatedEnclib.cs`). It runs behind the same `IEnclib` interface the real driver will use, so when hardware arrives, bring-up is a one-file swap: implement `IEnclib` against the real `enclib32.dll` and register it where `SimulatedEnclib.Instance` is used today.

A **SIMULATED** badge is shown in the WinForms status bar whenever the app is running against the mock.

## Features

### Phase 1 — Core math + simulated driver (19 tests green)

* **`DevaEncoderMonitor.Core`** — class library, `net8.0`
* **`IEnclib`** — abstraction over the vendor encoder library; real-driver stub ready
* **`SimulatedEnclib`** — thread-safe singleton mock of the DEVA001 card; idempotent open/close, axis validation, motion profiles
* **`MotionEngine`** — deterministic 3-axis motion simulator (CPR 1024, quadrature x4 = 4096 counts/rev), fixed seed `Random(42)` for reproducible results
* **`EncoderMath`** — pure count<->RPM conversion and 32-bit wrap-around-safe delta math
* **`PositionSnapshot`** — per-axis snapshot: counts, RPM, instantaneous/filtered velocity, inputs, status, direction, timestamp
* **19 xUnit tests** covering `SimulatedEnclib`, `MotionEngine`, and `EncoderMath` (idempotent open, channel validation, motion pause on close, determinism, reverse direction, wrap-around delta, etc.)

### Phase 2 — WinForms DRO UI + polling service + CSV export

* **`DevaEncoderMonitor.App`** — WinForms desktop app, `net8.0-windows`
* **`MainForm`** — digital readout (DRO) for all 3 axes: position counts, RPM, CW/CCW direction, A/B input bits, encoder mode
* **`EncoderService`** — background polling loop (10 ms tick) that reads all axes from the simulator and publishes snapshots; the UI only reads in-memory data, so it never blocks
* **Start/Stop toggle** — button switches between "Start Polling" and "Stop Polling"; CPR field is locked while polling
* **Zero axis** — per-axis zero buttons apply an app-layer offset so displayed position reads `0` after zeroing
* **CSV export** — `CsvLogger` writes timestamped rows (`TimestampUtc, Axis, Counts, Rpm, VelInst, VelFilt, Inputs, Status, Direction`) to `logs/encoder_log_<timestamp>.csv`
* **Simulator badge** — status bar shows "SIMULATED" in lime green


## Build and test instructions

### Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* Windows (WinForms app requires Windows)

### Build

From the repository root:

```powershell
# Restore and build everything
dotnet build src/DevaEncoderMonitor.App/DevaEncoderMonitor.App.csproj

# Build the core library only
dotnet build src/DevaEncoderMonitor.Core/DevaEncoderMonitor.Core.csproj
```

### Run the app

```powershell
dotnet run --project src/DevaEncoderMonitor.App/DevaEncoderMonitor.App.csproj
```

The WinForms window opens showing three axis readouts. Click **Start Polling** to begin simulated motion; the status bar turns green and shows "SIMULATED". Click **Zero N** to zero any axis. Click **Export CSV** to save a snapshot to `logs/`.

### Run tests

```powershell
dotnet test src/DevaEncoderMonitor.Tests/DevaEncoderMonitor.Tests.csproj
```

Expected result: **19 tests, 0 failed**.


## Phase roadmap

| Phase | Status | Focus |
|-------|--------|-------|
| 0 — Scaffold | Done | README, `.gitignore`, `.gitattributes` |
| 1 — Simulated Enclib driver + Core math | Done | `IEnclib`, `SimulatedEnclib`, `MotionEngine`, `EncoderMath`, 19 tests green |
| 2 — WinForms DRO UI + polling service + CSV export | Done | `MainForm`, `EncoderService`, `CsvLogger`; QA fixes applied |
| 3 — Real driver bring-up | Planned | Swap `SimulatedEnclib` for a real `enclib32.dll` implementation behind `IEnclib` |
| 4 — Hardware validation | Planned | Test against physical DEVA001 PCI card; calibrate CPR and direction |



### Things to remember

* `bin/` and `obj/` are ignored by `.gitignore` — never commit build output.
* The `docs/` folder is intentionally left uncommitted (local reference only).
* The `Deva001 SDK/` folder contains vendor binaries and headers; do not modify or redistribute them.
* Run `dotnet test` before committing to confirm all 19 tests are green.
