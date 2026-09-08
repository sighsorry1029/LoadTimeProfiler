# LoadTimeProfiler

Profiles modded Valheim startup, world joins, and dedicated server boot. One patcher DLL also provides optional localization caching, config-write coalescing, timeout protection, logging filters, and automatic reload of other mods' BepInEx cfg files.

## Features

- Measures Start to Lobby, Lobby to World, and dedicated server startup.
- Shows plugin construction, `Awake`, `OnEnable`, `Start`, and major lifecycle timings.
- Attributes synchronous Harmony callback time in `ObjectDB.Awake` and `ZNetScene.Awake` to individual mods.
- Optionally accelerates supported localization work and automatic BepInEx config writes.
- Applies a configurable timeout floor to supported vanilla, Jotunn, ServerSync, and AzuAntiCheat paths.
- Gives each mod four GUID-based log checkboxes, without inspecting the stack on each message.
- Reloads logging settings automatically, including on headless servers with no connected player.
- Optionally reloads other mods' registered BepInEx cfg files after local file edits, without an in-game administrator or ConfigManager.
- Keeps the newest 20 reports for comparison.

## Installation

Place `LoadTimeProfiler.dll` in:

```text
BepInEx/patchers
```

Do not place it in `BepInEx/plugins`. Install it separately on each client or dedicated server you want to profile.

Timeout protection is endpoint-local. Install the same build and timeout setting on both client and server when you want equivalent protection in both directions.

If QuietLogs or ShutUp is loaded alongside this build, the integrated logging filter disables itself and warns; the other LoadTimeProfiler features continue. Remove the overlapping patcher and restart to use integrated filtering. If automatic cfg reload is enabled while standalone ConfigWatcher is loaded, only LTP's automatic cfg watcher stays inactive to avoid duplicate reloads.

## Usage

1. Start Valheim normally.
2. Wait for the main menu to measure Start to Lobby.
3. Enter a world to also measure Lobby to World.
4. Open the newest report in:

```text
BepInEx/config/LoadTimeProfiler
```

Dedicated servers create a `Server Startup` report in the same directory. Compare multiple warm runs because disk cache, network conditions, world size, and background programs can affect loading time.

Start To Lobby starts at this patcher's `Patch` callback and ends when `FejdStartup.Start` completes. It does not include the entire executable startup or all later rendering. The earlier preloader config/Manual logging setup is outside that clock; use an external launch-to-menu measurement when comparing total startup cost.

Lobby To World starts when `TransitionToMainScene` accepts the world transition and ends when `SpawnPlayer` completes. Earlier login, password, permission, warning, and world-selection prompts are not included.

## Configuration

The configuration file is:

```text
BepInEx/config/sighsorry.LoadTimeProfiler.cfg
```

| Setting | Default | Purpose |
|---|---:|---|
| `General.ProfilingEnabled` | `true` | Measures loading times, creates timing reports and enables lifecycle and per-mod attribution. |
| `General.LocalizationCacheEnabled` | `true` | Caches supported vanilla and external localization work. |
| `General.ConfigWriteCoalescingEnabled` | `true` | Coalesces automatic config writes during `Chainloader.Start`. |
| `General.ConfigAutoReloadEnabled` | `false` | Automatically reloads other mods' registered BepInEx cfg files after local file edits. Restart required. |
| `General.TimeoutProtectionSeconds` | `120` | Sets the minimum supported connection and send-queue timeout. Use `0` to disable it. |
| `Logging.Mods.<GUID>` | `Errors, Warnings` when absent | Allowed groups for the mod's default BepInEx logger. |

Each mod has four independent checkboxes. There is no logging master switch, common logger option, or source-name override.

| Checkbox | Config name | Default |
|---|---|---|
| Fatal + Error | `Errors` | Checked |
| Warning | `Warnings` | Checked |
| Message + Info | `Information` | Unchecked |
| Debug | `Debug` | Unchecked |

Unconfigured mods keep fatal/error/warning messages and suppress message/info/debug on their default logger. Clear every checkbox (`None` in the file) to silence that logger; select all four to allow every event, including custom level values. LoadTimeProfiler's own diagnostic logger and report files remain available. Unity logs and unowned/custom/shared Manual loggers always pass through this filter.

Example (replace the example GUIDs with the actual mod GUIDs):

```ini
[General]
ProfilingEnabled = true
LocalizationCacheEnabled = true
ConfigWriteCoalescingEnabled = true
ConfigAutoReloadEnabled = false
TimeoutProtectionSeconds = 120

[Logging.Mods]
sighsorry.ConfigManager = Errors, Warnings
author.examplemod = Errors, Warnings, Information, Debug
author.noisymod = None
```

The five `[General]` keys may be omitted: missing or invalid values keep that entry's current value, or its default on the first readable load. `[Logging.Mods]` may be empty or absent; removing a GUID rule restores its Errors + Warnings default. An invalid rule for a present GUID keeps its current groups, or Errors + Warnings on the first readable load. Section/key names and GUIDs are case-sensitive. Select groups using the comma-separated config names above, case-insensitively, or use `None` alone. Numeric masks and unrecognized group names are invalid values. The timeout must be a finite, nonnegative number; longer original timeouts remain unchanged. Timeout protection is local on clients, hosts and dedicated servers, with no server-forced value or ServerSync dependency.

Logging settings are checked every 500ms by a background timer. Two identical reads normally apply an edit within 0.5–1 second; file locks or scheduling can delay this. Reload applies valid entries independently, retains only invalid entries' current/default values, and publishes one immutable snapshot. Unknown sections and keys are ignored. Repeated keys use the last valid assignment; a malformed section header ends the previous section until another valid header appears. Invalid entries produce a deduplicated summary warning without blocking other settings. Whole-file read failures, invalid UTF-8 and files over 256KiB keep the previous snapshot. Use UTF-8 (optional BOM) and full-line `#` or `;` comments. Replacement saves and deletion/recreation are supported; a settled partial save cannot be distinguished from an intentional edit.

The five `General` settings are fixed at process startup. Editing them records a restart-needed notice without changing installed patches; among LTP's settings, only logging changes apply immediately. `ProfilingEnabled` controls measurement and reports; startup acceleration, timeout protection and automatic cfg reload retain their own settings. LTP logging reload remains available with `ConfigAutoReloadEnabled = false` and when all startup features are disabled. Each process reads its own file; LTP settings are not synchronized across the network.

LTP's automatic reload never rewrites its configuration file. The file is created when missing at startup; explicit ConfigManager edits save it as described below. If the initial file cannot be read, startup defaults apply, other-mod automatic reload stays disabled, and all logs pass until a readable file is loaded. A readable file with invalid individual values uses normal per-entry defaults and still applies its valid entries. Unknown text stays on disk; old section/key names are neither converted nor treated as aliases for current names.

### Automatic reload of other mods

To enable this on a server, set `ConfigAutoReloadEnabled = true` in its LTP cfg and restart the server once. Subsequent saves to tracked mod cfg files are reloaded locally; neither a connected administrator nor ConfigManager is required. The switch is local to each client, host or dedicated-server process and does not force client settings.

LTP tracks real `ConfigFile` objects created after its tracking hook is installed, reconciles loaded plugins' default configs, and also tracks later-created configs. Only registered `.cfg` paths are watched; it does not create substitute configuration objects for arbitrary files. Additional custom configs created before LTP initializes cannot be discovered by this hook. Watching begins after Chainloader and startup config-write coalescing finish; the current startup files establish the initial baseline.

One watcher is shared per registered directory. File creation, modification, rename/replace and deletion/recreation are handled. Events are coalesced for 500ms and the changed file's content must be stable on successive checks before reload is queued on BepInEx's Unity main-thread dispatcher. Normal changes take roughly one second, with longer delays for locks, repeated edits or a busy main thread. Identical contents are skipped for objects that already processed them. There is no per-frame file or plugin scan, and this feature's check timer stops when no work is pending. Watchers hold weak configuration references and are disposed at shutdown.

During each native `ConfigFile.Reload()`, automatic `SaveOnConfigSet` writes are temporarily disabled and the original flag is restored in `finally`. LTP does not call `Save()` or suppress a mod's explicit saves, callbacks or existing watcher. Read/reload failures are isolated and retried; successfully reloaded objects sharing a file are not repeatedly called for the same contents. Known standalone ConfigWatcher disables this feature only; other mods' private watchers are not automatically removed and may still cause additional callbacks.

Live behavior depends on the target mod. Values read during normal operation and changes handled by `SettingChanged` or `ConfigReloaded` can take effect; startup-only patches, copied values and already-created objects may still require a restart or a mod-specific refresh. BepInEx applies entries individually, so invalid entries, callbacks and their side effects cannot be rolled back as a transaction. Custom JSON/YAML loaders are outside this feature. The target mod's existing ServerSync or Jotunn integration may propagate its registered settings to clients; LTP adds no synchronization dependency or authority bypass.

### ConfigManager

A compatible `sighsorry.ConfigManager` build with the external settings API shows LoadTimeProfiler in its normal settings list. Use a build that supports grouped checkbox labels, caching and read-only external settings. `General` contains the five settings that require a restart; `Logging - Mods` contains one row of four log checkboxes per loaded plugin. The automatic cfg reload option requires only the updated LoadTimeProfiler DLL. Mod rows use display names, with the GUID in their description; equal display names also show the GUID in the label. With LTP filtering active, each mod log checkbox applies immediately. Edit the timeout directly in its row: Enter or leaving the field commits, Escape cancels, and invalid input remains visible without changing the saved value. String editors elsewhere in ConfigManager still use their edit window.

When ShutUp or QuietLogs is loaded, `Logging - Mods` shows a read-only `Status` row naming the conflict and disables editing of the per-mod checkboxes, including Edit and Reset. These values are saved LTP rules, not the other patcher's settings. General settings remain editable. Detection uses the loaded assembly name, regardless of the standalone patcher's own enabled setting. Remove the overlapping patcher and restart to enable LTP filtering and its controls. This status display requires the updated ConfigManager DLL as well as LoadTimeProfiler; it does not add runtime dependencies to headless servers.

LoadTimeProfiler validates the selected UI value and saves it to the same `sighsorry.LoadTimeProfiler.cfg`. It reads the latest file, preserves unrelated settings, invalid values, unknown sections, comments and the BOM, then atomically replaces the file. Existing errors elsewhere do not block the edit. A missing current key or section is added only when that setting is edited; repeated target keys keep their earlier lines and update the last occurrence. Valid disk edits to other entries are included in the published snapshot. An invalid requested value, unreadable/missing file, busy reload, size limit or detected concurrent edit still produces an error without publishing an unsaved value. Another application's rename/replace in the final filesystem commit window cannot be made fully transactional with this process. This per-entry policy belongs to LTP; ConfigManager's ordinary BepInEx settings path is unchanged.

UI values follow the latest configuration snapshot, including external file reloads. Startup options still require a restart; logging changes apply immediately. The UI does not own a second configuration or synchronize settings to a server. Integration collects loaded plugins once after Chainloader, with no per-frame discovery or list rebuilding. Saved rules for absent plugins remain in the file and apply when those GUIDs return; editing another row does not remove them. ConfigManager is optional and is not needed on a dedicated server. Older ConfigManager builds and other ConfigurationManager forks can still use their cfg text editor where provided, but do not gain normal-list integration from the filename alone.

## Logging behavior

- The `BaseUnityPlugin` constructor hook binds the default logger object to `Info.Metadata.GUID` before the derived constructor body and `Awake`. Same-name plugins have independent rules. This hook remains active after profiling finishes and when all startup features are off. It is installed after Unity loads, without resolving Unity types in preloader initialization.
- Matching uses the default logger object, not its source name or the caller's assembly. Renamed displays retain their GUID rule. A logger without this ownership connection always passes, including custom/shared loggers and BepInEx/preloader Manual logs. Source names do not create ownership or exemptions. Sharing a plugin's already-owned default logger retains that logger's GUID policy.
- LoadTimeProfiler's actual diagnostic logger object always passes. Its name is not used to grant exemptions to owned plugin loggers.
- A blocked Manual log skips event allocation and every `LogEvent` subscriber, including console/disk listeners. Reports use a separate file writer and remain available.
- Unity managed Logger/Debug output, native output and Unity-to-BepInEx forwarding are not filtered. Their filter patches and logger-initialization bootstrap hook have been removed. A mod's `Debug.Log` calls remain visible even when its default BepInEx logger is silenced.
- Caller-created strings/argument arrays and game `ZLog` pre-formatting remain. Independent `ILogSource` implementations such as Trace, Console and HarmonyX are outside the Manual filter.
- Mods using default-logger events as functional inputs may need all four groups selected. Filtering does not repair the condition that caused an error. Allowing a message cannot restore messages blocked by another logger or mod.
- The filtering path has no per-message file access, stack inspection, reflection, locks, or allocations of its own. Unowned Manual messages still enter the common prefix and perform an ownership lookup before passing; this is not zero overhead. Unity logging has no LTP filter hooks. Logger/GUID registrations retain only standard logger references and GUIDs for the process lifetime, not Unity plugin instances, and are cleared on filter disposal. The timer has a small file-reading/allocation cost, and allowed logs still incur their normal output costs.

Logging is part of the single patcher DLL and retains a process-wide lifetime while the profiler measures bounded sessions. Its own cfg reload is independent of the optional other-mod watcher. Loading-time savings depend on actual logging bottlenecks and are not guaranteed by integration.

## Compatibility

When one of these mods is installed, disable the overlapping LoadTimeProfiler feature:

| Installed mod | LoadTimeProfiler setting |
|---|---|
| Smoothbrain-StartupAccelerator | `LocalizationCacheEnabled = false` and `ConfigWriteCoalescingEnabled = false` |
| MSchmoecker-LocalizationCache | `LocalizationCacheEnabled = false` |
| MSchmoecker-TimeoutLimit | `TimeoutProtectionSeconds = 0` |

LoadTimeProfiler does not detect the three acceleration/timeout overlaps above or change their settings automatically. Edit the config and restart. Standalone QuietLogs/ShutUp detection prevents overlapping logging filters; standalone ConfigWatcher detection prevents overlapping automatic cfg watchers. Each conflict disables only its matching LTP feature.

## Reading Reports

- `Total` is the complete measured session time.
- `Milestone intervals` show where time passed between major loading events.
- `Plugin construction/Awake/OnEnable` and `Plugin Start methods` show per-plugin startup work.
- `Measured lifecycle execution times` show inclusive Valheim lifecycle duration.
- `Scoped deep attribution` assigns synchronous `ObjectDB.Awake` and `ZNetScene.Awake` callbacks to mods.
- `Connection outcome` separates successful connection time from failure-decision time.
- `Logging at start/end`, hook availability, and config revisions record the conditions of the measurement. A revision change warns that configuration changed during the session, even if it was subsequently changed back. Startup feature values remain fixed until restart.

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
  0.714 s: LoadTimeProfiler.Patcher.Patch
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

## Build and validation

Use the .NET SDK and .NET Framework 4.8 targeting pack with the configured Valheim/BepInEx references. To build without copying the DLL to your game:

```powershell
dotnet build LoadTimeProfiler.csproj -c Debug -p:DeployToGame=true
./tests/RunRegressionTests.ps1 -AssemblyPath ./bin/Debug/LoadTimeProfiler.dll
./tests/RunLogFilteringTests.ps1 -AssemblyPath ./bin/Debug/LoadTimeProfiler.dll -SkipBenchmark
./tests/RunConfigAutoReloadTests.ps1 -AssemblyPath ./bin/Debug/LoadTimeProfiler.dll
```

Debug deployment copies only the final DLL into the game's `BepInEx/patchers` directory. Use `-p:DeployToGame=false` to skip the copy. For an explicitly requested release, `dotnet build LoadTimeProfiler.csproj -c Release` generates the Thunderstore ZIP; a registered release-manager watcher may publish that ZIP automatically. Check the project's folder, team and selected sites before the Release build. Ordinary Debug validation does not generate release packages.

Set `-p:BepInExPath=<profile>/BepInEx` for a specific runtime. Add `-p:SkipReleasePackage=true` to omit packaging. `tests/RunUnitySmoke.ps1` normally runs an isolated headless client. `-DisableStartupFeatures` disables profiling, acceleration and timeout protection; `-EnableConfigAutoReload` independently enables other-mod reload. Add `-ConfigManagerAssemblyPath <DLL>` to check the actual Manager settings list and get/set integration. `-ShutUpConflictFixture` adds a no-op test assembly named ShutUp to check name-based conflict detection and read-only logging rows; it does not test the original ShutUp mod. `-DedicatedRuntime -GameExecutable <valheim_server.exe> -LoaderDirectory <Valheim directory>` uses the actual dedicated executable with probe-only guards preventing platform login and world/network initialization. These tests do not create a world, join a server, verify connected-client synchronization, or exercise rendered UI and mouse clicks. See [VALIDATION.md](VALIDATION.md) for performed checks, performance scope, and remaining validation.
