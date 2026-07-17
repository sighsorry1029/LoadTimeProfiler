# Changelog

## 1.0.1

- Fixed dedicated-server joins not preparing deep lobby attribution, so client-side per-mod `ObjectDB.Awake` and `ZNetScene.Awake` timings are now recorded when connecting to a dedicated server.
- Generalized the active lifecycle callback blocklist so attribution can be prepared safely from both `JoinServer` and local `OnWorldStart` paths.
- Updated the Thunderstore package icon.

## 1.0.0

- Initial public release of LoadTimeProfiler.
- Supports client loading and dedicated server startup profiling.
