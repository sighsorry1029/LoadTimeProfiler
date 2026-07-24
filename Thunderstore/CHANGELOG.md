# Changelog

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
