# Changelog

## 1.1.6

- Removed the 1.1.5 per-callback `FejdStartup.Awake` instrumentation after its Harmony detours could trigger a native Mono crash immediately after BepInEx chainloader startup.
- Retains the safe inclusive `FejdStartup.Awake` lifecycle timing and the 1.1.5 AzuAntiCheat prehash and FastAssetBundleLoader hash diagnostics.

## 1.1.5

- Added an exact-version AzuAntiCheat 4.3.11 integration that starts same-launch per-plugin SHA-256 work on one below-normal background worker while BepInEx continues loading plugins.
- Revalidates file identity before consuming a prehash and uses a fresh synchronous streaming hash on any missing, changed, or failed result; no persistent digest cache is trusted.
- Added narrowly scoped per-mod Harmony callback attribution for `FejdStartup.Awake`, with preparation and runtime bookkeeping cost reported separately.
- Added diagnostic timing for only FastAssetBundleLoader's original-source hash inside `TryUseCachedBundle(Stream)`, excluding cache-output verification hashes.
- Keeps all three additions behind the existing `General.Enabled` master switch with no new configuration options.

## 1.1.4

- Removed the recent spawn-readiness, per-prefab ZDO, `CreateObject`, zone-loading hold, Jotunn source-hint, and minimap diagnostic hooks.
- Retains the coarse `Game.RequestRespawn` to `Game.SpawnPlayer` lifecycle interval, normal/failure connection outcomes, major world-loading stages, and per-mod `ObjectDB.Awake`/`ZNetScene.Awake` attribution.
- Keeps completed connection report formatting deferred until after `SpawnPlayer` returns.

## 1.1.3

- Added `Game.UpdateRespawn` and `FindSpawnPoint` activation fallbacks so Unity string-based respawn invocation cannot leave spawn-readiness diagnostics empty.
- Added final-target 3x3 ZDO attribution by prefab, including final known counts, a separate transient peak-missing backlog table with sampled first/last/clear observations, approximate inclusive `CreateObject` time, and registered-instance outcomes.
- Adds best-effort Jotunn source metadata or clearly labeled component-presence hints without enabling Jotunn's startup-costly global `ModQuery` collection.
- Added bounded `SetLoadingInZone`/`UnsetLoadingInZone` diagnostics, split into center-zone direct blockers and 3x3 instance-order candidates clipped to the final spawn attempt's relevant time windows, with the ordering start broadened to cover active-area sampling delay.
- Keeps the new diagnostics observation-only and behind the existing single master switch, with no new configuration options.
- Separately reports measured in-path diagnostic work and defers post-endpoint connection-report assembly through BepInEx's persistent main-thread queue until after `SpawnPlayer` returns, with a generation guard against mixing a newer session's detail.

## 1.1.2

- Added observation-only spawn-readiness diagnostics for the interval between `_RequestRespawn` activation and `SpawnPlayer`, plus connection-wide minimap call timing.
- Separately reports the built-in logout/custom-spawn gate, target-zone readiness, active-area readiness, and `IsAreaReady` completion.
- Samples known 3x3 spawn-sector ZDO totals and uninstantiated valid objects periodically at no more than 1 Hz, plus a terminal readiness sample, without changing loading behavior.
- Reports minimap cache hits, misses, and inclusive `GenerateWorldMap` call time relative to respawn activation so map regeneration can be distinguished from spawn-area loading.
- Keeps the diagnostics always on with the existing master switch, buffers samples in memory without per-sample disk writes, and reports a lower bound for measured diagnostic work.

## 1.1.1

- Replaced the per-feature settings with one `General.Enabled` master switch and automatically removes the retired settings from existing config files.
- Replaced exhaustive connection compatibility analysis with a minimal fixed 90-second floor for vanilla ZRpc, Jotunn, and known ServerSync/AzuAntiCheat send queues.
- Preserves timeout values already longer than 90 seconds and leaves fragment-cache lifetimes unchanged.
- Removed experimental Harmony wrapper rebuild batching and connection-time fragment patching.
- Added event-based connection outcomes that separately report normal connection time, first failure-decision time, and return-to-lobby/error-display time without per-frame polling.
- Starts connection timing only after `TransitionToMainScene` accepts the transition, and distinguishes a benign lobby return from ServerSync/AzuAntiCheat failures that set their terminal status after `Game.Logout`.

## 1.1.0

- Added safe localization CSV acceleration that replays captured `AddWord` sequences into Valheim's existing translation dictionary and keeps other mods' prefix/postfix callbacks active.
- Added Chainloader-scoped automatic config-save coalescing without changing a plugin's `SaveOnConfigSet` policy or delaying explicit `Save()` calls.
- Added opt-in Harmony wrapper rebuild batching. It remains disabled by default because mods that use a patch immediately after installing it can be incompatible.
- Added a structurally verified connection-stability layer for vanilla `ZRpc`, Jotunn `CustomRPC`, embedded/standalone ServerSync copies, and obfuscated AzuAntiCheat queue waits.
- Extended compatible fragment receive-cache lifetimes together with queue timeouts to reduce the risk of the original 60-second cache expiring during a slow fragmented transfer.
- Added acceleration and stability diagnostics to both Start To Lobby and Lobby To World reports.
- Added decompiled compatibility references and a detailed integration analysis for Jotunn 2.29.2, AzuAntiCheat 4.3.11, and the supplied ServerSync build.

## 1.0.1

- Fixed dedicated-server joins not preparing deep lobby attribution, so client-side per-mod `ObjectDB.Awake` and `ZNetScene.Awake` timings are now recorded when connecting to a dedicated server.
- Generalized the active lifecycle callback blocklist so attribution can be prepared safely from both `JoinServer` and local `OnWorldStart` paths.
- Updated the Thunderstore package icon.

## 1.0.0

- Initial public release of LoadTimeProfiler.
- Supports client loading and dedicated server startup profiling.
