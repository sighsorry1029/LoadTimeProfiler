using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using BepInEx.Bootstrap;

namespace LoadTimeProfiler;

// This optional UI boundary is entered only after Chainloader has loaded plugins.
// There is no assembly reference to ConfigManager and no second ConfigFile/state.
internal static class ConfigManagerIntegration
{
    private const string ManagerGuid = "sighsorry.ConfigManager";
    private static readonly object[] GroupValues = CreateGroupValues();
    private static IDisposable? _registration;
    private static int _attempted;
    private static int _stopped;

    private static object[] CreateGroupValues()
    {
        object[] values = new object[16];
        for (int i = 0; i < values.Length; i++) values[i] = (LogGroups)i;
        return values;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void TryRegister()
    {
        if (Volatile.Read(ref _stopped) != 0 ||
            Interlocked.Exchange(ref _attempted, 1) != 0 ||
            LoadTimeProfilerPatcher.IsDedicatedServer) return;
        ModConfiguration? configuration = LoadTimeProfilerPatcher.Configuration;
        if (configuration == null || !Chainloader.PluginInfos.TryGetValue(ManagerGuid, out var plugin) ||
            plugin.Instance == null) return;

        try
        {
            Type manager = plugin.Instance.GetType();
            Type? descriptor = manager.Assembly.GetType("ConfigurationManager.ExternalSetting");
            ConstructorInfo? constructor = descriptor?.GetConstructor(new[]
            {
                typeof(string), typeof(string), typeof(string), typeof(Type), typeof(object),
                typeof(Func<object>), typeof(Action<object>)
            });
            Type? enumerable = descriptor == null ? null : typeof(IEnumerable<>).MakeGenericType(descriptor);
            MethodInfo? register = enumerable == null ? null : manager.GetMethod("RegisterExternalSettings",
                BindingFlags.Public | BindingFlags.Static, null,
                new[] { typeof(string), typeof(string), typeof(string), enumerable }, null);
            if (constructor == null || register == null ||
                !typeof(IDisposable).IsAssignableFrom(register.ReturnType))
            {
                LoadTimeProfilerPatcher.LogInfo("This ConfigManager build does not support external settings. " +
                    "Use its cfg text editor or install a build with the external settings API.");
                return;
            }

            List<object> settings = new();
            void Add(string section, string key, string description, Type type, object defaultValue,
                Func<object> get, Action<object>? set)
            {
                settings.Add(constructor.Invoke(new object?[]
                    { section, key, description, type, defaultValue, get, set }));
            }
            void AddSetting(string section, string key, string description, Type type, object defaultValue)
                => Add(section, key, description, type, defaultValue,
                    () => configuration.GetSettingValue(section, key),
                    value => configuration.SetSettingValue(section, key, value));

            AddSetting("General", "ProfilingEnabled", "Measure startup and world-join times and write timing reports. Restart required.",
                typeof(bool), true);
            AddSetting("General", "LocalizationCacheEnabled", "Cache supported localization work. Restart required.",
                typeof(bool), true);
            AddSetting("General", "ConfigWriteCoalescingEnabled", "Coalesce automatic config writes during startup. Restart required.",
                typeof(bool), true);
            AddSetting("General", "ConfigAutoReloadEnabled", "Automatically reload other mods' BepInEx cfg files after local file edits. " +
                "Each mod determines whether changed values take effect during play and whether they synchronize to clients. " +
                "Does not control LoadTimeProfiler's live logging settings. Restart required.", typeof(bool), false);
            AddSetting("General", "TimeoutProtectionSeconds", "Minimum supported connection timeout in seconds. " +
                "Applies locally on clients, hosts and dedicated servers; not synchronized. " +
                "Use 0 to disable this protection. Longer original timeouts remain. Restart required.", typeof(float), 120f);
            string? conflict = LogFiltering.ConflictName;
            string? conflictDescription = conflict == null ? null :
                "LoadTimeProfiler's logging filter is disabled because " + conflict + " is loaded. " +
                "These checkboxes show saved LTP rules, not the other patcher's settings, and cannot be edited here. " +
                "Remove the overlapping patcher and restart to use LTP filtering. Other LTP features remain active.";
            if (conflict != null)
            {
                string status = "Disabled: " + conflict + " is loaded.";
                Add("Logging - Mods", "Status", conflictDescription!, typeof(string), status, () => status, null);
            }
            List<(string Guid, string Name)> mods = new();
            Dictionary<string, int> nameCounts = new(StringComparer.Ordinal);
            foreach (var info in Chainloader.PluginInfos.Values)
            {
                if (info.Instance == null || info.Metadata.GUID == LoadTimeProfilerPatcher.ModGUID) continue;
                string name = info.Metadata.Name;
                mods.Add((info.Metadata.GUID, name));
                nameCounts.TryGetValue(name, out int count);
                nameCounts[name] = count + 1;
            }
            mods.Sort((left, right) => StringComparer.Ordinal.Compare(left.Guid, right.Guid));
            HashSet<string> labels = new(StringComparer.Ordinal);
            if (conflict != null) labels.Add("Status");
            foreach (var mod in mods)
            {
                string guid = mod.Guid;
                string label = nameCounts[mod.Name] > 1 ? mod.Name + " [" + guid + "]" : mod.Name;
                // A plugin name may itself look like one of the disambiguated labels.
                while (!labels.Add(label)) label += " [" + guid + "]";
                string description = "Mod GUID: " + guid + ". " + (conflictDescription ??
                    "Controls this mod's default BepInEx logger, " +
                    "including constructor and Awake logs on the next launch. Select the groups to allow; " +
                    "select all for every log, or clear all to silence this logger. Changes apply immediately. " +
                    "Unity logs and unowned custom/shared Manual loggers are always allowed by LoadTimeProfiler.");
                Add("Logging - Mods", label, description,
                    typeof(LogGroups), LogGroups.Errors | LogGroups.Warnings,
                    () => GroupValues[(int)configuration.GetModLogGroups(guid)],
                    conflict == null ? value => configuration.SetModLogGroups(guid, (LogGroups)value) : null);
            }

            Array entries = Array.CreateInstance(descriptor!, settings.Count);
            for (int index = 0; index < settings.Count; index++) entries.SetValue(settings[index], index);

            IDisposable registration = (IDisposable)(register.Invoke(null, new object[]
                { LoadTimeProfilerPatcher.ModGUID, LoadTimeProfilerPatcher.ModName,
                    LoadTimeProfilerPatcher.ModVersion, entries })
                ?? throw new InvalidOperationException("ConfigManager returned no registration handle."));
            Interlocked.Exchange(ref _registration, registration)?.Dispose();
            if (Volatile.Read(ref _stopped) != 0) Dispose();
        }
        catch (Exception ex)
        {
            Exception cause = ex is TargetInvocationException invocation && invocation.InnerException != null
                ? invocation.InnerException : ex;
            LoadTimeProfilerPatcher.LogWarning("ConfigManager integration failed; cfg reload remains available: " + cause.Message);
        }
    }

    internal static void Dispose()
    {
        Volatile.Write(ref _stopped, 1);
        try { Interlocked.Exchange(ref _registration, null)?.Dispose(); }
        catch (Exception ex) { LoadTimeProfilerPatcher.LogWarning("ConfigManager registration cleanup failed: " + ex.Message); }
    }
}
