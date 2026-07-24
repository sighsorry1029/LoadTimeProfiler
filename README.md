# LoadTimeProfiler

Profiles and safely accelerates modded Valheim startup, world loading, and dedicated server boot. It also adds targeted timeout protection for large synchronization payloads during slow world joins.

It starts before normal BepInEx plugins and writes an easy-to-read timing report for each launch. It does not change gameplay content, items, or world data. One master switch controls profiling, safe startup acceleration, and minimal connection protection together.

## Features

- Measures client startup from launch to the main menu.
- Measures the trip from the lobby to a playable world.
- Measures dedicated server startup until the server is ready.
- Shows how much time individual mods spend during plugin setup, including construction, `Awake`, `OnEnable`, and `Start`.
- Shows per-mod synchronous work during the important `ZNetScene.Awake` and `ObjectDB.Awake` loading stages.
- Records a timeline of major Valheim loading stages, making long pauses easier to spot.
- Keeps the latest 10 reports so you can compare runs before and after changing your mod list.
- Caches localization CSV work without replacing Valheim's active translation dictionary or suppressing other mods' localization callbacks.
- Coalesces only automatic BepInEx config writes during `Chainloader.Start`; explicit saves and each plugin's `SaveOnConfigSet` policy remain intact.
- Applies a fixed 90-second floor to vanilla ZRpc, Jotunn, and known ServerSync/AzuAntiCheat send-queue waits without shortening longer original limits.
- Leaves fragment-cache behavior unchanged and avoids broad compatibility scans on the connection path.
- Works on clients and dedicated servers without DataForge or ServerSync.

### Manual Installation

Place `LoadTimeProfiler.dll` directly inside:

```text
BepInEx/patchers
```

Do **not** place it in `BepInEx/plugins`. A patcher needs to start before regular plugins so it can measure their loading time.

Install it separately on every client or dedicated server that you want to profile. A server installation measures the server; a client installation measures that client.

## How To Use

1. Start Valheim or your dedicated server normally.
2. On a client, wait for the main menu and then enter a world if you also want a lobby-to-world report.
3. On a dedicated server, wait until world loading is complete and the server is ready for connections.
4. Open the newest report in:

```text
BepInEx/config/LoadTimeProfiler
```

Each report is named with its launch date and time. Up to 10 reports are stored in this folder. When an 11th report is created, the oldest report is removed automatically.

Compare several runs before deciding that one mod is slow. Loading time can change because of disk cache, network conditions, world size, and other programs running on the computer.

## Configuration

The configuration file is:

```text
BepInEx/config/sighsorry.LoadTimeProfiler.cfg
```

There is one setting:

- `General.Enabled = true` enables timing reports, the safe localization cache, Chainloader-scoped config-write coalescing, and minimal connection protection. Set it to `false` to disable all LoadTimeProfiler runtime hooks and report-file creation. Changes apply on the next launch.

Connection protection uses a fixed 90-second floor. Existing limits longer than 90 seconds are preserved, and fragment-cache lifetimes are not changed. Previous per-feature settings are removed automatically when the configuration is next loaded.

Config coalescing delays only automatic BepInEx writes until `Chainloader.Start` ends. Explicit saves and each plugin's `SaveOnConfigSet` policy remain intact. LoadTimeProfiler automatically keeps original save behavior when another Harmony owner patches `ConfigFile.Save`.

## Incompatibilities

- Smoothbrain-StartupAccelerator
- MSchmoecker-LocalizationCache
- MSchmoecker-TimeoutLimit

Connection stability cannot guarantee success when the peer is offline, versions are incompatible, a mod coroutine never finishes, the network drops packets indefinitely, or an incomplete fragment expires under the original mod behavior. The minimal layer only prevents known 30-second ZRpc and send-queue limits from ending an otherwise healthy transfer too early.

## Dedicated Server Behavior

Install the same `LoadTimeProfiler.dll` in the dedicated server's own `BepInEx/patchers` folder. No client installation is required to measure the server itself.

When the `valheim_server` process starts, LoadTimeProfiler automatically switches to dedicated server mode and creates a **Server Startup** report. It measures:

- BepInEx startup and plugin construction, `Awake`, `OnEnable`, and `Start` work.
- Major server loading stages such as `ZNetScene.Awake`, `ObjectDB.Awake`, `ZoneSystem.Start`, and `DungeonDB.Start`.
- Synchronous per-mod Harmony callback time during `ZNetScene.Awake` and `ObjectDB.Awake`.
- Startup through world and location generation until Valheim opens the server for connections.

The report is saved on the server machine at:

```text
BepInEx/config/LoadTimeProfiler
```

Server reports are not sent to connected players. Installing LoadTimeProfiler only on a client measures that client, while installing it only on the dedicated server measures the server. The server also keeps only its newest 10 reports.

Connection protection is local. Install the same build on both endpoints when you want the fixed protection available for both server-to-client and client-to-server synchronization queues.

## Reading The Report

- **Plugin construction/Awake/OnEnable** shows time spent while BepInEx creates and enables each plugin.
- **Plugin Start** shows measured work from plugin `Start` methods.
- **Timeline** shows the order and duration of major Valheim loading stages.
- **Scoped deep attribution** shows synchronous Harmony callback time assigned to mods during `ZNetScene.Awake` and `ObjectDB.Awake`.
- **Startup acceleration** reports safe localization-cache and automatic config-write activity.
- **Localization CSV acceleration** reports cache hits, misses, replay time, and uncached parse time for the active phase.
- **Connection outcome** separates normal connection time, time to the first failure decision, and the later return-to-lobby/error-display time.
- **Connection stability** reports the fixed 90-second protection targets, preserved fragment behavior, installation time, and compatibility warnings.
- **Unattributed time** is work that cannot be safely assigned to one mod.

The slowest entries are useful investigation targets. They are not automatic proof that a mod is broken; manager mods such as Jotunn may perform work on behalf of several other mods.

## Example Report

The numbers below are only an example. Your results will depend on your computer, world, server, and installed mods.

### Start To Lobby

```text
=== Start To Lobby ===
Result: completed
Total: 2 min 15.781 s
Milestone intervals:
  Breakdown: lifecycle execution + remaining time until the next milestone.
  0.714 s: LoadTimeProfiler.Patcher.Finish
  0.106 s: LoadTimeProfiler.Patcher initialized
  82.336 s: BepInEx.Chainloader.Start
  32.418 s: BepInEx.Chainloader.Start complete
  16.894 s (16.463 s + 0.431 s): FejdStartup.Awake
  0.000 s: FejdStartup.Start
  0.244 s (0.244 s + 0.000 s): FejdStartup.SetupGui
  3.068 s (2.771 s + 0.297 s): FejdStartup.SetupObjectDB
BepInEx startup:
  Before Chainloader.Start (includes Chainloader.Initialize): 820.046 ms
  Chainloader.Start: 1 min 22.336 s
Plugin construction/Awake/OnEnable:
  6.534 s: MonsterLabZ
  4.629 s: MonstrumDeepNorth
  4.091 s: WarfareFireAndIce
  3.134 s: SouthsilArmor
  2.965 s: Jewelcrafting
  2.770 s: CrystalLights
  2.486 s: Warfare
  2.367 s: ValheimCuisine
```

This section helps you find mods that spend a long time being created or enabled before the main menu appears.

### Lobby To World

```text
=== Lobby To World ===
Result: completed
Total: 52.154 s
Connection outcome:
  Normal connection time: 52.154 s
Milestone intervals:
  Breakdown: lifecycle execution + remaining time until the next milestone.
  1.468 s (0.000 s + 1.468 s): FejdStartup.TransitionToMainScene
  0.233 s (0.000 s + 0.233 s): FejdStartup.LoadMainScene
  0.043 s (0.043 s + 0.000 s): Game.Awake
  0.009 s (0.008 s + 0.001 s): ZoneSystem.Awake
  2.262 s (2.261 s + 0.001 s): ZNet.Awake
  15.022 s (13.311 s + 1.711 s): ZNetScene.Awake
  8.769 s (7.079 s + 1.690 s): ObjectDB.Awake
  0.033 s (0.032 s + 0.001 s): Game.Start
  0.438 s (0.437 s + 0.001 s): ZoneSystem.Start
  3.387 s (3.387 s + 0.000 s): DungeonDB.Start
  4.285 s (0.293 s + 3.992 s): ZNet.Start
  16.010 s (0.301 s + 15.709 s): Game.RequestRespawn
  0.167 s (0.167 s + 0.000 s): Game.SpawnPlayer
Measured lifecycle execution times (prefix -> finalizer, inclusive):
  13.311 s: ZNetScene.Awake
  7.079 s: ObjectDB.Awake
  3.388 s: DungeonDB.Start
  2.262 s: ZNet.Awake
  0.437 s: ZoneSystem.Start
  0.301 s: Game.RequestRespawn
  0.293 s: ZNet.Start
  0.167 s: Game.SpawnPlayer
Scoped deep lobby attribution:
  Exclusive synchronous Harmony callback time in ObjectDB.Awake and ZNetScene.Awake.
  Breakdown order: ObjectDB + ZNetScene.
  Prepared callbacks: installed=4, existing=398, skipped=2, failed=0, setup=0.021 s
  11.973 s (0.189 s + 11.783 s): Jotunn
  4.423 s (4.418 s + 0.005 s): DataForge
  0.813 s (0.813 s + 0.000 s): AdminQoL
  0.534 s (0.047 s + 0.486 s): EpicMMOSystem
  0.246 s (0.211 s + 0.035 s): WarfareFireAndIce
  0.180 s (0.116 s + 0.064 s): Jewelcrafting
```

For a milestone such as `15.022 s (13.311 s + 1.711 s): ZNetScene.Awake`, the first value inside the parentheses is measured execution time. The second is the remaining time before the next milestone.

The scoped attribution rows use `ObjectDB + ZNetScene` order. For example, DataForge used `4.418 s` during `ObjectDB.Awake` and `0.005 s` during `ZNetScene.Awake` in this sample.

## Measurement Limits

LoadTimeProfiler safely assigns synchronous work that it can observe. Network waits, coroutine continuations, background work, vanilla work, transpiled code, and work completed before the patcher starts may remain unattributed. Work delegated through another framework may be listed under that framework instead of the mod that requested it.

Acceleration statistics describe work observed or coalesced in the current run; they are not a synthetic estimate of total time saved. Compare several runs with identical mod, world, and endpoint conditions.

Connection timing begins when `FejdStartup.TransitionToMainScene` accepts the world transition, so pre-connection login, permission, warning, and selection prompts are not counted as a hanging connection attempt. Success reuses the existing `Game.SpawnPlayer` completion timestamp. Failure stores `Game.Logout` as a candidate timestamp and confirms it from the terminal status shown by `FejdStartup.ShowConnectError`; a benign return to the lobby is reported as cancelled. This event-based measurement does not poll connection state each frame.
