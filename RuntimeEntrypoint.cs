using System;

namespace LoadTimeProfiler;

public static class RuntimeEntrypoint
{
    private static bool _chainloaderStarted;

    public static void BeforeChainloaderStart()
    {
        try
        {
            LoadTimeProfilerPatcher.InitializeProfiler();
            LoadTimeProfilerPatcher.AttachBepInExLogger();
            if (!LoadTimeProfilerPatcher.ProfilingEnabled)
            {
                return;
            }

            ProfilerLog.WriteLine("Chainloader runtime entrypoint reached. Installing Unity and Valheim hooks.");
            RuntimeHookInstaller.Install();
            ChainloaderProfiler.BeginChainloader();
            _chainloaderStarted = true;
        }
        catch (Exception ex)
        {
            RuntimeHookInstaller.RemovePluginConstructionHook();
            ProfilerLog.WriteLine("Runtime hook initialization failed: " + ex);
            LoadTimeProfilerPatcher.LogError("Runtime hook initialization failed: " + ex.Message);
        }
    }

    public static void AfterChainloaderStart()
    {
        bool prepareServerAttribution = _chainloaderStarted &&
                                        LoadTimeProfilerPatcher.ProfilingEnabled &&
                                        LoadTimeProfilerPatcher.IsDedicatedServer;
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
}
