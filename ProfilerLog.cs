using System;
using System.IO;
using System.Linq;
using System.Text;
using BepInEx;

namespace LoadTimeProfiler;

internal static class ProfilerLog
{
    private const int MaximumRetainedLogs = 10;
    private static readonly object Lock = new();
    private static StreamWriter? _writer;

    internal static string FilePath { get; private set; } = Path.Combine(Paths.ConfigPath, "LoadTimeProfiler", "pending.log");

    internal static void Initialize()
    {
        lock (Lock)
        {
            DisposeWriter();
            DateTime sessionStarted = DateTime.Now;
            string logDirectory = Path.Combine(Paths.ConfigPath, "LoadTimeProfiler");
            try
            {
                Directory.CreateDirectory(logDirectory);
                RetainNewestLogs(logDirectory, MaximumRetainedLogs - 1);
                FilePath = CreateUniqueLogPath(logDirectory, sessionStarted);
                FileStream stream = new(FilePath, FileMode.CreateNew, FileAccess.Write, FileShare.ReadWrite);
                _writer = new StreamWriter(stream, new UTF8Encoding(false))
                {
                    AutoFlush = true
                };

                _writer.WriteLine($"{LoadTimeProfilerPatcher.ModName} {LoadTimeProfilerPatcher.ModVersion}");
                _writer.WriteLine($"Session: {sessionStarted:yyyy-MM-dd HH:mm:ss zzz}");
                _writer.WriteLine($"Process: {Paths.ProcessName}");
                _writer.WriteLine($"Mode: {(LoadTimeProfilerPatcher.IsDedicatedServer ? "Dedicated server" : "Client")}");
                _writer.WriteLine($"BepInEx: {typeof(BaseUnityPlugin).Assembly.GetName().Version}");
                _writer.WriteLine(LoadTimeProfilerPatcher.IsDedicatedServer
                    ? "Coverage: BepInEx plugin construction/Awake/OnEnable, plugin Start methods, dedicated server lifecycle execution, and milestone intervals."
                    : "Coverage: BepInEx plugin construction/Awake/OnEnable, plugin Start methods, selected client lifecycle execution, and milestone intervals.");
                _writer.WriteLine("Deep attribution instruments existing synchronous Harmony callbacks in ObjectDB.Awake and ZNetScene.Awake.");
                _writer.WriteLine();
            }
            catch (Exception ex)
            {
                DisposeWriter();
                LoadTimeProfilerPatcher.LogError($"Could not create profiler log '{FilePath}': {ex.Message}");
            }
        }
    }

    private static string CreateUniqueLogPath(string directory, DateTime timestamp)
    {
        string baseName = timestamp.ToString("yyyy-MM-dd_HH-mm-ss");
        string path = Path.Combine(directory, baseName + ".log");
        for (int suffix = 2; File.Exists(path); suffix++)
        {
            path = Path.Combine(directory, baseName + "_" + suffix + ".log");
        }

        return path;
    }

    private static void RetainNewestLogs(string directory, int maximumExistingLogs)
    {
        FileInfo[] logs = new DirectoryInfo(directory)
            .GetFiles("*.log", SearchOption.TopDirectoryOnly)
            .OrderBy(file => file.LastWriteTimeUtc)
            .ThenBy(file => file.Name, StringComparer.Ordinal)
            .ToArray();
        int removeCount = Math.Max(0, logs.Length - maximumExistingLogs);
        for (int i = 0; i < removeCount; i++)
        {
            try
            {
                logs[i].Delete();
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }

    internal static void WriteLine(string text)
    {
        lock (Lock)
        {
            if (_writer == null)
            {
                return;
            }

            try
            {
                _writer.WriteLine(text);
            }
            catch (Exception ex)
            {
                LoadTimeProfilerPatcher.LogWarning($"Could not write profiler log: {ex.Message}");
                DisposeWriter();
            }
        }
    }

    internal static void WriteBlock(string text)
    {
        lock (Lock)
        {
            if (_writer == null)
            {
                return;
            }

            try
            {
                _writer.WriteLine(text.TrimEnd());
                _writer.WriteLine();
            }
            catch (Exception ex)
            {
                LoadTimeProfilerPatcher.LogWarning($"Could not write profiler log: {ex.Message}");
                DisposeWriter();
            }
        }
    }

    private static void DisposeWriter()
    {
        try
        {
            _writer?.Dispose();
        }
        catch
        {
        }

        _writer = null;
    }
}
