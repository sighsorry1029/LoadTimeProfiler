# LoadTimeProfiler

Profiles modded Valheim startup, world joins, and dedicated server boot. It also provides optional localization caching, config-write coalescing, and timeout protection without changing gameplay or world data.

## Features

- Measures Start to Lobby, Lobby to World, and dedicated server startup.
- Shows plugin construction, `Awake`, `OnEnable`, `Start`, and major lifecycle timings.
- Attributes synchronous Harmony callback time in `ObjectDB.Awake` and `ZNetScene.Awake` to individual mods.
- Optionally accelerates supported localization work and automatic BepInEx config writes.
- Applies a configurable timeout floor to supported vanilla, Jotunn, ServerSync, and AzuAntiCheat paths.
- Keeps the newest 20 reports for comparison.

## Installation

Place `LoadTimeProfiler.dll` in:

```text
BepInEx/patchers
```

Do not place it in `BepInEx/plugins`. Install it separately on each client or dedicated server you want to profile.

Timeout protection is endpoint-local. Install the same build and timeout setting on both client and server when you want equivalent protection in both directions.

## Usage

1. Start Valheim normally.
2. Wait for the main menu to measure Start to Lobby.
3. Enter a world to also measure Lobby to World.
4. Open the newest report in:

```text
BepInEx/config/LoadTimeProfiler
```

Dedicated servers create a `Server Startup` report in the same directory. Compare multiple warm runs because disk cache, network conditions, world size, and background programs can affect loading time.

Lobby To World starts when `TransitionToMainScene` accepts the world transition and ends when `SpawnPlayer` completes. Earlier login, password, permission, warning, and world-selection prompts are not included.

## Configuration

The configuration file is:

```text
BepInEx/config/sighsorry.LoadTimeProfiler.cfg
```

| Setting | Default | Purpose |
|---|---:|---|
| `General.ProfilingEnabled` | `true` | Creates timing reports and enables lifecycle and per-mod attribution. |
| `General.LocalizationCacheEnabled` | `true` | Caches supported vanilla and external localization work. |
| `General.ConfigWriteCoalescingEnabled` | `true` | Coalesces automatic config writes during `Chainloader.Start`. |
| `General.TimeoutProtectionSeconds` | `120` | Sets the minimum supported connection and send-queue timeout. Use `0` to disable it. |

Changes apply on the next launch. The four settings are independent. Longer original timeout limits are preserved.

## Compatibility

When one of these mods is installed, disable the overlapping LoadTimeProfiler feature:

| Installed mod | LoadTimeProfiler setting |
|---|---|
| Smoothbrain-StartupAccelerator | `LocalizationCacheEnabled = false` and `ConfigWriteCoalescingEnabled = false` |
| MSchmoecker-LocalizationCache | `LocalizationCacheEnabled = false` |
| MSchmoecker-TimeoutLimit | `TimeoutProtectionSeconds = 0` |

LoadTimeProfiler does not detect these mods or change settings automatically. Edit the config and restart the game.

## Reading Reports

- `Total` is the complete measured session time.
- `Milestone intervals` show where time passed between major loading events.
- `Plugin construction/Awake/OnEnable` and `Plugin Start methods` show per-plugin startup work.
- `Measured lifecycle execution times` show inclusive Valheim lifecycle duration.
- `Scoped deep attribution` assigns synchronous `ObjectDB.Awake` and `ZNetScene.Awake` callbacks to mods.
- `Connection outcome` separates successful connection time from failure-decision time.

Slow entries are investigation targets, not automatic proof that a mod is broken. Framework mods may perform work on behalf of other mods. Acceleration hit counts and internal patch timings are intentionally omitted because they do not measure end-to-end time saved.

## Example Reports

The abridged logs below are examples only.

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

For `15.022 s (13.311 s + 1.711 s): ZNetScene.Awake`, `13.311 s` is measured lifecycle execution and `1.711 s` is the remaining time before the next milestone. Scoped attribution rows use `ObjectDB + ZNetScene` order.

## Limits

LoadTimeProfiler attributes synchronous work it can observe. Network waits, coroutine continuations, background tasks, vanilla work, transpiled code, and work delegated through another framework may remain unattributed or appear under the framework. Timeout protection cannot make an offline, incompatible, or permanently stalled peer connect.
