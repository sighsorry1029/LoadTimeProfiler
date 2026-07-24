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
            if (!LoadTimeProfilerPatcher.AnyRuntimeFeatureEnabled)
            {
                return;
            }

            LoadTimeProfilerPatcher.AttachBepInExLogger();
            ProfilerLog.WriteLine(
                "Chainloader runtime entrypoint reached. Installing profiling, acceleration, and stability hooks.");
            RuntimeHookInstaller.Install();
            StartupAcceleration.InstallBeforeChainloader();
            ConnectionStability.InstallBeforeChainloader();
            StartupAcceleration.BeginChainloader();
            ChainloaderProfiler.BeginChainloader();

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

            RuntimeHookInstaller.RemovePluginConstructionHook();
            ProfilerLog.WriteLine("Runtime hook initialization failed: " + ex);
            LoadTimeProfilerPatcher.LogError("Runtime hook initialization failed: " + ex.Message);
        }
    }

    public static void AfterChainloaderStart()
    {
        if (!LoadTimeProfilerPatcher.AnyRuntimeFeatureEnabled)
        {
            return;
        }

        bool prepareServerAttribution = _chainloaderStarted &&
                                        LoadTimeProfilerPatcher.IsDedicatedServer;
        try
        {
            StartupAcceleration.EndChainloader();
        }
        catch (Exception ex)
        {
            ProfilerLog.WriteLine("Startup acceleration completion failed: " + ex);
        }

        try
        {
            if (_chainloaderStarted)
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
        StartupAcceleration.CheckLoadedCompatibility();
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
    }

    internal static void HandleChainloaderFailure(Exception exception)
    {
        if (!_chainloaderStarted)
        {
            return;
        }

        try
        {
            if (LoadTimeProfilerPatcher.AnyRuntimeFeatureEnabled)
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
        }
    }
}
