using System;

namespace LoadTimeProfiler;

public static class RuntimeEntrypoint
{
    private static bool _chainloaderStarted;
    internal static bool ChainloaderCompleted { get; private set; }

    public static void BeforeChainloaderStart()
    {
        try
        {
            LoadTimeProfilerPatcher.InitializeProfiler();
            LogFiltering.InstallPluginOwnership();
            if (!LoadTimeProfilerPatcher.AnyStartupFeatureEnabled)
            {
                return;
            }

            LoadTimeProfilerPatcher.AttachBepInExLogger();
            if (LoadTimeProfilerPatcher.RuntimeInstrumentationNeeded)
            {
                RuntimeHookInstaller.Install();
            }

            if (LoadTimeProfilerPatcher.ProfilingEnabled ||
                LoadTimeProfilerPatcher.StartupAccelerationEnabled)
            {
                StartupAcceleration.InstallBeforeChainloader();
            }

            if (LoadTimeProfilerPatcher.TimeoutProtectionEnabled)
            {
                ConnectionStability.InstallBeforeChainloader();
            }

            if (LoadTimeProfilerPatcher.StartupAccelerationEnabled)
            {
                StartupAcceleration.BeginChainloader();
            }

            if (LoadTimeProfilerPatcher.ProfilingEnabled)
            {
                ChainloaderProfiler.BeginChainloader();
            }

            _chainloaderStarted = true;
        }
        catch (Exception ex)
        {
            try
            {
                StartupAcceleration.EndChainloader();
            }
            catch (Exception cleanupException)
            {
                ProfilerLog.WriteLine(
                    "Startup acceleration cleanup after initialization failure also failed: " +
                    cleanupException);
            }
            finally
            {
                StartupAcceleration.AbortStartupScope();
            }

            RuntimeHookInstaller.RemovePluginConstructionHook();
            ProfilerLog.WriteLine("Runtime hook initialization failed: " + ex);
            LoadTimeProfilerPatcher.LogError("Runtime hook initialization failed: " + ex.Message);
        }
    }

    public static void AfterChainloaderStart()
    {
        if (!LoadTimeProfilerPatcher.AnyStartupFeatureEnabled)
        {
            ConfigAutoReload.Start();
            ConfigManagerIntegration.TryRegister();
            return;
        }

        bool prepareServerAttribution =
            LoadTimeProfilerPatcher.ProfilingEnabled &&
            _chainloaderStarted &&
            LoadTimeProfilerPatcher.IsDedicatedServer;
        if (LoadTimeProfilerPatcher.StartupAccelerationEnabled)
        {
            try
            {
                StartupAcceleration.EndChainloader();
            }
            catch (Exception ex)
            {
                ProfilerLog.WriteWarning("Startup acceleration completion failed: " + ex);
            }

            try
            {
                StartupAcceleration.AfterChainloaderStart();
            }
            catch (Exception ex)
            {
                ProfilerLog.WriteWarning(
                    "Localization adapter reconciliation failed: " + ex);
            }
        }

        try
        {
            if (_chainloaderStarted &&
                LoadTimeProfilerPatcher.ProfilingEnabled)
            {
                ChainloaderProfiler.EndChainloader();
            }
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteLine("Chainloader completion measurement failed: " + ex);
        }
        finally
        {
            _chainloaderStarted = false;
            RuntimeHookInstaller.RemovePluginConstructionHook();
        }

        ChainloaderCompleted = true;
        if (LoadTimeProfilerPatcher.TimeoutProtectionEnabled)
        {
            try
            {
                ConnectionStability.InstallLoadedModIntegrations();
            }
            catch (Exception ex)
            {
                ProfilerLog.WriteLine("Connection stability integration failed: " + ex);
                LoadTimeProfilerPatcher.LogWarning(
                    "Connection stability integration failed: " + ex.Message);
            }
        }

        if (prepareServerAttribution)
        {
            try
            {
                DeepLobbyAttributionProfiler.PrepareForActiveSession();
            }
            catch (Exception ex)
            {
                ProfilerLog.WriteLine("Dedicated server attribution preparation failed: " + ex);
            }
        }

        // Begin watching after the startup config-save scope has been flushed.
        ConfigAutoReload.Start();
        ConfigManagerIntegration.TryRegister();
    }

    internal static void HandleChainloaderFailure(Exception exception)
    {
        if (!_chainloaderStarted)
        {
            return;
        }

        try
        {
            if (LoadTimeProfilerPatcher.ProfilingEnabled)
            {
                try
                {
                    ChainloaderProfiler.EndChainloader();
                }
                catch (Exception measurementException)
                {
                    ProfilerLog.WriteLine(
                        "Chainloader failure measurement cleanup failed: " + measurementException);
                }

                TimelineProfiler.AbortStartup(
                    "BepInEx.Chainloader.Start failed: " + exception.GetType().Name);
            }
        }
        catch (Exception cleanupException)
        {
            ProfilerLog.WriteLine(
                "Chainloader failure report cleanup failed: " + cleanupException);
        }
        finally
        {
            _chainloaderStarted = false;
            RuntimeHookInstaller.RemovePluginConstructionHook();
            if (LoadTimeProfilerPatcher.StartupAccelerationEnabled)
            {
                StartupAcceleration.AbortStartupScope();
            }
        }
    }
}
