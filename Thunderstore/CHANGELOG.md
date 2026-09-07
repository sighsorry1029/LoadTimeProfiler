# Changelog

## 1.2.5

- Fixed scoped Harmony callback attribution when lifecycle calls are nested inside `ObjectDB.Awake` or `ZNetScene.Awake`, preserving outer callbacks and exclusive timing through nested and recursive phases.
- Avoids unnecessary translation dictionary snapshots when foreign patches force localization CSV caching to bypass.
- Simplified instrumentation bookkeeping, pending config-write tracking, and LocalizeKey adapter internals while preserving configuration keys, Harmony callback signatures, and compatibility policies.
- Added 12 isolated regression cases covering config saves, nested attribution, and LocalizeKey identity, replay, and invalidation behavior.
- Added the `SkipReleasePackage` build option so Release builds can be validated without regenerating the Thunderstore package; default packaging behavior is unchanged.

## 1.2.4

- Increased automatic profile-log retention from 10 to 20 reports.
- Refined the package description around faster startup, reliable world joins, and built-in profiling.

## 1.2.3

- Reworked the README into a shorter installation, configuration, compatibility, and report-reading guide.
- Retained both the Start To Lobby and Lobby To World report examples.
- Removed the remaining legacy-key guidance and retired internal identifier; the runtime and config schema are current-only.

## 1.2.2

- Added explicit manual overlap guidance to the three acceleration/protection config descriptions and the README.
- Documents which LoadTimeProfiler setting to disable when StartupAccelerator, LocalizationCache, or TimeoutLimit is installed.
- Keeps configuration authoritative: no runtime scan for these conflicting mods, automatic feature override, or additional config option was added.

## 1.2.1

- Simplified profile reports to measured loading and connection timings plus actionable compatibility warnings.
- Removed acceleration, localization-cache, config-write, and timeout-protection installation status, hit counters, and internal processing-time sections because they do not measure end-to-end time saved.
- Removed all legacy configuration migration and legacy-mod detection/bypass paths. Only the four current `General` settings are read; legacy keys are ignored.

## 1.2.0

- Replaced the single `General.Enabled` master switch with independent profiling, localization-cache, config-write-coalescing, and timeout-protection settings.
- Profiling can now be disabled without disabling startup acceleration or connection protection; no report files or profiling-only runtime hooks are created in that mode.
- Changed the default timeout floor from 90 to 120 seconds, made it configurable through `General.TimeoutProtectionSeconds`, and uses `0` to disable protection while preserving longer original limits.
- Added safe migration from `General.Enabled` and older per-feature settings, including preservation of the previous all-disabled state.
- Keeps only the minimal plugin-discovery and startup-completion hooks required by external localization caching when profiling is disabled.

## 1.1.13

- Removed the Jotunn localization producer adapter after its pre-`Awake` Harmony preparation was found to initialize `LocalizationManager` before `Jotunn.Main.Instance` existed.
- Keeps Jotunn localization entirely on its original path while retaining the successfully exercised vanilla CSV, canonical `LocalizationManager.Localizer`, and manager-library `LocalizeKey` caches.
- Prevents the resulting Jotunn `TypeInitializationException` cascade into dependent mods such as VNEI, STUWard, and content registrations.

## 1.1.12

- Extended startup localization acceleration to repeatedly invoked, canonical `LocalizationManager.Localizer`, Jotunn, and manager-library `LocalizeKey` producers.
- Requires exact identities, method signatures, semantic fields, validated IL call flow, and actual Harmony callback registration; obfuscated AzuAntiCheat localization and stateful/side-effect variants stay on their original paths.
- Added per-adapter fail-open isolation, mutation invalidation, exception-safe startup lifetime cleanup, cache-release on lobby arrival, and adapter installation/hit diagnostics.

## 1.1.11

- Removed the experimental `ObjectDB.Awake` and `ZNetScene.Awake` Harmony wrapper batching after warm comparisons showed only a small end-to-end startup improvement.
- Restored immediate Harmony wrapper rebuild semantics and removed every `PatchFunctions.UpdateWrapper` hook, flush path, statistic, and report entry.
- Retains the localization cache, automatic config-write coalescing, profiling, and fixed 90-second connection-timeout protection.

## 1.1.10

- Removed global `PatchFunctions.UpdateWrapper` timing, per-target dictionaries, physical-rebuild statistics, and the startup-only `UpdateWrapper` finalizer.
- Retains exact `ObjectDB.Awake` and `ZNetScene.Awake` batching through a minimal prefix-only path; non-target requests now perform only fast target checks before continuing normally.
- Keeps structural Harmony validation, first-rebuild materialization, exception-safe final flush, compatibility fallback, and concise exact-target flush diagnostics.

## 1.1.9

- Added structurally verified, Chainloader-scoped Harmony wrapper batching for only the exact parameterless `ObjectDB.Awake` and `ZNetScene.Awake` targets.
- Added `PatchFunctions.UpdateWrapper` request, physical rebuild, avoided rebuild, target, and final flush diagnostics to the startup report.
- Keeps the first rebuild for each exact target, every other Harmony target, and every background-thread patch request on its original immediate path; adds no configuration option and removes the diagnostic hook when Chainloader finishes.

## 1.1.8

- Removed the exact-version AzuAntiCheat same-launch prehash integration, its background worker, and its report section.
- Restores AzuAntiCheat's original synchronous hash path while retaining normal plugin timing and the minimal 90-second AzuAntiCheat send-queue protection.

## 1.1.7

- Removed the observation-only FastAssetBundleLoader hash diagnostic and both of its Harmony hooks after confirming that the loader and its cache are effective independently.
- Keeps FastAssetBundleLoader behavior untouched and retains the AzuAntiCheat same-launch asynchronous prehash.

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
