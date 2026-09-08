using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using BepInEx.Logging;

namespace LoadTimeProfiler;

[Flags]
public enum LogGroups
{
    None = 0,
    [Description("Fatal + Error")] Errors = 1,
    [Description("Warning")] Warnings = 2,
    [Description("Message + Info")] Information = 4,
    [Description("Debug")] Debug = 8
}

internal sealed class LogPolicy
{
    internal const LogGroups DefaultGroups = LogGroups.Errors | LogGroups.Warnings;
    internal const LogGroups EveryGroup = LogGroups.Errors | LogGroups.Warnings | LogGroups.Information | LogGroups.Debug;
    private static readonly LogLevel[] SeverityMasks = CreateSeverityMasks();
    private readonly Dictionary<string, LogGroups> _mods;
    private readonly bool _failOpen;

    internal LogPolicy(Dictionary<string, LogGroups> mods, bool failOpen = false)
    {
        _failOpen = failOpen;
        _mods = new Dictionary<string, LogGroups>(mods, StringComparer.Ordinal);

        StringBuilder description = new();
        if (failOpen) description.Append("configuration unavailable: all logs pass; ");
        description.Append("default groups=").Append(DefaultGroups).Append("; Unity/unmapped=pass; mods=[");
        List<string> names = new(_mods.Keys);
        names.Sort(StringComparer.Ordinal);
        for (int i = 0; i < names.Count; i++)
        {
            if (i > 0) description.Append("; ");
            description.Append(names[i]).Append('=').Append(_mods[names[i]]);
        }

        Description = description.Append(']').ToString();
    }

    internal string Description { get; }

    internal LogGroups GetModGroups(string guid) => _failOpen ? EveryGroup :
        _mods.TryGetValue(guid, out LogGroups groups) ? groups : DefaultGroups;

    internal bool Allows(string? guid, LogLevel level)
    {
        if (_failOpen || guid == null) return true;
        LogGroups groups = GetModGroups(guid);
        if (groups == EveryGroup) return true;
        return (level & SeverityMasks[(int)groups]) != 0;
    }

    private static LogLevel[] CreateSeverityMasks()
    {
        LogLevel[] masks = new LogLevel[16];
        for (int index = 0; index < masks.Length; index++)
        {
            LogGroups groups = (LogGroups)index;
            if ((groups & LogGroups.Errors) != 0) masks[index] |= LogLevel.Fatal | LogLevel.Error;
            if ((groups & LogGroups.Warnings) != 0) masks[index] |= LogLevel.Warning;
            if ((groups & LogGroups.Information) != 0) masks[index] |= LogLevel.Message | LogLevel.Info;
            if ((groups & LogGroups.Debug) != 0) masks[index] |= LogLevel.Debug;
        }
        return masks;
    }

    internal bool HasSameValues(LogPolicy other)
    {
        if (_failOpen != other._failOpen || _mods.Count != other._mods.Count)
        {
            return false;
        }

        foreach (KeyValuePair<string, LogGroups> mod in _mods)
        {
            if (!other._mods.TryGetValue(mod.Key, out LogGroups groups) || groups != mod.Value)
            {
                return false;
            }
        }

        return true;
    }
}

internal sealed class ModSettings
{
    internal ModSettings(
        bool profilingEnabled,
        bool localizationCacheEnabled,
        bool configWriteCoalescingEnabled,
        float timeoutProtectionSeconds,
        LogPolicy logging,
        long revision = 0,
        bool configAutoReloadEnabled = false)
    {
        ProfilingEnabled = profilingEnabled;
        LocalizationCacheEnabled = localizationCacheEnabled;
        ConfigWriteCoalescingEnabled = configWriteCoalescingEnabled;
        ConfigAutoReloadEnabled = configAutoReloadEnabled;
        TimeoutProtectionSeconds = timeoutProtectionSeconds;
        Logging = logging;
        Revision = revision;
    }

    internal bool ProfilingEnabled { get; }
    internal bool LocalizationCacheEnabled { get; }
    internal bool ConfigWriteCoalescingEnabled { get; }
    internal bool ConfigAutoReloadEnabled { get; }
    internal float TimeoutProtectionSeconds { get; }
    internal LogPolicy Logging { get; }
    internal long Revision { get; }

    internal bool HasSameStartupValues(ModSettings other)
    {
        return ProfilingEnabled == other.ProfilingEnabled &&
               LocalizationCacheEnabled == other.LocalizationCacheEnabled &&
               ConfigWriteCoalescingEnabled == other.ConfigWriteCoalescingEnabled &&
               ConfigAutoReloadEnabled == other.ConfigAutoReloadEnabled &&
               TimeoutProtectionSeconds == other.TimeoutProtectionSeconds;
    }

    internal bool HasSameValues(ModSettings other)
    {
        return HasSameStartupValues(other) && Logging.HasSameValues(other.Logging);
    }

    internal ModSettings WithRevision(long revision)
    {
        return new ModSettings(ProfilingEnabled, LocalizationCacheEnabled,
            ConfigWriteCoalescingEnabled, TimeoutProtectionSeconds, Logging, revision, ConfigAutoReloadEnabled);
    }
}

internal sealed class ModConfiguration : IDisposable
{
    internal const int MaximumFileBytes = 256 * 1024;
    private const int PollMilliseconds = 500;
    private static readonly Encoding ConfigEncoding = new UTF8Encoding(false, true);

    private readonly string _configPath;
    private readonly Action<string> _warning;
    private readonly Action<string> _notice;
    private readonly object _publicationLock = new();
    private readonly Timer _timer;
    private ModSettings _snapshot = CreateFallback();
    private int _disposed;
    private int _reloadBusy;
    private bool _startupCaptured;
    private string? _loadedText;
    private string? _candidateText;
    private string? _lastWarning;

    internal ModConfiguration(string configPath, Action<string> warning, Action<string> notice)
    {
        _configPath = Path.GetFullPath(configPath ?? throw new ArgumentNullException(nameof(configPath)));
        _warning = warning ?? throw new ArgumentNullException(nameof(warning));
        _notice = notice ?? throw new ArgumentNullException(nameof(notice));
        CreateDefaultFileIfMissing();
        ReloadNow();
        StartupSettings = Snapshot;
        _startupCaptured = true;
        _timer = new Timer(Poll, null, PollMilliseconds, PollMilliseconds);
    }

    internal ModSettings Snapshot => Volatile.Read(ref _snapshot);
    internal ModSettings StartupSettings { get; }

    // Explicit reload bypasses debounce. Parsing and validation finish before
    // publication; the initial startup settings remain fixed for this process.
    internal bool ReloadNow()
    {
        return TryReload(immediate: true);
    }

    internal object GetSettingValue(string section, string key)
    {
        if (section == null) throw new ArgumentNullException(nameof(section));
        if (key == null) throw new ArgumentNullException(nameof(key));
        ModSettings settings = Snapshot;
        if (section == "General")
        {
            if (key == "ProfilingEnabled") return settings.ProfilingEnabled;
            if (key == "LocalizationCacheEnabled") return settings.LocalizationCacheEnabled;
            if (key == "ConfigWriteCoalescingEnabled") return settings.ConfigWriteCoalescingEnabled;
            if (key == "ConfigAutoReloadEnabled") return settings.ConfigAutoReloadEnabled;
            if (key == "TimeoutProtectionSeconds") return settings.TimeoutProtectionSeconds;
        }
        throw new ArgumentException("Unknown setting: " + section + "." + key + ".");
    }

    internal void SetSettingValue(string section, string key, object value)
    {
        object current = GetSettingValue(section, key);
        if (value == null || value.GetType() != current.GetType())
            throw new ArgumentException(section + "." + key + " requires a " + current.GetType().Name + " value.", nameof(value));
        string formatted;
        if (value is bool enabled) formatted = enabled ? "true" : "false";
        else
        {
            float seconds = (float)value;
            if (float.IsNaN(seconds) || float.IsInfinity(seconds) || seconds < 0f)
                throw new ArgumentOutOfRangeException(nameof(value), "Timeout must be a finite, non-negative number.");
            formatted = seconds.ToString("R", CultureInfo.InvariantCulture);
        }

        SaveEdit(text => EditSetting(text, section, key, formatted));
    }

    internal LogGroups GetModLogGroups(string guid)
    {
        if (guid == null) throw new ArgumentNullException(nameof(guid));
        return Snapshot.Logging.GetModGroups(guid);
    }

    internal void SetModLogGroups(string guid, LogGroups groups)
    {
        if (!IsValidGuid(guid)) throw new ArgumentException("A mod GUID must be a non-empty, unambiguous configuration key.", nameof(guid));
        if ((groups & ~LogPolicy.EveryGroup) != 0)
            throw new ArgumentOutOfRangeException(nameof(groups), "Unsupported log group flags.");
        SaveEdit(document => EditSetting(document, "Logging.Mods", guid, groups.ToString()));
    }

    private static bool IsValidGuid(string? guid)
    {
        if (string.IsNullOrEmpty(guid) || char.IsWhiteSpace(guid![0]) || char.IsWhiteSpace(guid[guid.Length - 1]) ||
            guid[0] == '#' || guid[0] == ';') return false;
        foreach (char character in guid)
            if (char.IsControl(character) || character == '[' || character == ']' || character == '=' || character == '\uFEFF') return false;
        return true;
    }

    private void SaveEdit(Func<string, string> edit)
    {
        if (Volatile.Read(ref _disposed) != 0) throw new ObjectDisposedException(nameof(ModConfiguration));
        if (Interlocked.CompareExchange(ref _reloadBusy, 1, 0) != 0)
            throw new InvalidOperationException("Another configuration reload or save is in progress; retry the change.");
        string? temporary = null;
        bool restartRequired = false;
        try
        {
            string original = ReadConfigText();
            string edited = edit(original);
            ModSettings parsed = Parse(edited, _loadedText == null ? null : Snapshot, out string warning);
            byte[] bytes = ConfigEncoding.GetBytes(edited);
            if (bytes.Length > MaximumFileBytes)
                throw new InvalidDataException("The edited configuration exceeds the 256 KiB limit.");
            temporary = _configPath + "." + Guid.NewGuid().ToString("N") + ".tmp";
            using (FileStream destination = new(temporary, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                destination.Write(bytes, 0, bytes.Length);
                destination.Flush(flushToDisk: true);
            }

            lock (_publicationLock)
            {
                if (_disposed != 0) throw new ObjectDisposedException(nameof(ModConfiguration));
                // Keep in-place writers excluded until replacement. Another process can
                // still rename/replace this path after this check: File.Replace has no CAS.
                using FileStream current = OpenConfigRead();
                if (!string.Equals(original, ReadConfigText(current), StringComparison.Ordinal))
                    throw new IOException("Configuration changed on disk during the save; review the latest values and retry.");
                ModSettings next = PreparePublication(parsed, out restartRequired);
                File.Replace(temporary, _configPath, destinationBackupFileName: null);
                temporary = null;
                Publish(edited, next);
            }

            NotifyRestart(restartRequired);
            if (warning.Length > 0) WarnOnce(warning);
            else _lastWarning = null;
        }
        finally
        {
            if (temporary != null)
            {
                try { File.Delete(temporary); }
                catch (Exception ex) { Notify(_warning, "Could not remove temporary configuration file: " + ex.Message); }
            }
            Volatile.Write(ref _reloadBusy, 0);
        }
    }

    private static string EditSetting(string text, string section, string key, string value)
    {
        string activeSection = string.Empty;
        int insertAt = -1;
        int valueStart = -1, valueEnd = -1;
        for (int start = 0; start < text.Length;)
        {
            int end = GetLineEnd(text, start, out int next);
            string raw = text.Substring(start, end - start);
            string line = (start == 0 ? raw.TrimStart('\uFEFF') : raw).Trim();
            if (line.StartsWith("[", StringComparison.Ordinal))
            {
                // A malformed header ends the previous section in both reading and editing.
                activeSection = line.EndsWith("]", StringComparison.Ordinal) ? line.Substring(1, line.Length - 2) : string.Empty;
                if (activeSection == section) insertAt = next;
            }
            else if (activeSection == section && line.Length > 0 && line[0] != '#' && line[0] != ';')
            {
                int separator = raw.IndexOf('=');
                if (separator >= 0 && string.Equals(raw.Substring(0, separator).Trim(), key, StringComparison.Ordinal))
                {
                    int first = separator + 1, last = raw.Length;
                    while (first < last && char.IsWhiteSpace(raw[first])) first++;
                    while (last > first && char.IsWhiteSpace(raw[last - 1])) last--;
                    // Parsing uses the last valid assignment; repair the last occurrence
                    // so this edit takes effect without rewriting earlier duplicates.
                    valueStart = start + first;
                    valueEnd = start + last;
                }
            }
            start = next;
        }
        if (valueStart >= 0) return text.Substring(0, valueStart) + value + text.Substring(valueEnd);
        string newline = text.Contains("\r\n") ? "\r\n" : text.Contains("\n") ? "\n" :
            text.Contains("\r") ? "\r" : Environment.NewLine;
        string assignment = key + " = " + value + newline;
        if (insertAt < 0)
            return text + (text.Length > 0 && text[text.Length - 1] != '\r' && text[text.Length - 1] != '\n' ? newline : string.Empty) +
                "[" + section + "]" + newline + assignment;
        return text.Insert(insertAt, (insertAt > 0 && text[insertAt - 1] != '\r' && text[insertAt - 1] != '\n' ? newline : string.Empty) + assignment);
    }

    private static int GetLineEnd(string text, int start, out int next)
    {
        int end = start;
        while (end < text.Length && text[end] != '\r' && text[end] != '\n') end++;
        next = end;
        if (next < text.Length && text[next++] == '\r' && next < text.Length && text[next] == '\n') next++;
        return end;
    }

    public void Dispose()
    {
        lock (_publicationLock)
        {
            if (_disposed != 0) return;
            Volatile.Write(ref _disposed, 1);
            _timer.Dispose();
        }
    }

    private static ModSettings CreateFallback(bool failOpen = true)
    {
        return new ModSettings(true, true, true, 120f,
            new LogPolicy(new Dictionary<string, LogGroups>(StringComparer.Ordinal), failOpen: failOpen));
    }

    private void Poll(object? state)
    {
        TryReload(immediate: false);
    }

    private bool TryReload(bool immediate)
    {
        if (Volatile.Read(ref _disposed) != 0 ||
            Interlocked.CompareExchange(ref _reloadBusy, 1, 0) != 0)
        {
            return false;
        }

        try
        {
            string text;
            try
            {
                text = ReadConfigText();
            }
            catch (Exception ex)
            {
                _candidateText = null;
                WarnOnce("Could not read configuration; retaining current settings: " + ex.Message);
                return false;
            }

            if (string.Equals(text, _loadedText, StringComparison.Ordinal))
            {
                _candidateText = null;
                return true;
            }

            if (!immediate)
            {
                if (!string.Equals(text, _candidateText, StringComparison.Ordinal))
                {
                    _candidateText = text;
                    return false;
                }
            }

            _candidateText = text;
            ModSettings parsed = Parse(text, _loadedText == null ? null : Snapshot, out string warning);

            bool restartRequired = false;
            lock (_publicationLock)
            {
                if (_disposed != 0) return false;
                ModSettings next = PreparePublication(parsed, out restartRequired);
                Publish(text, next);
            }

            NotifyRestart(restartRequired);
            if (warning.Length > 0) WarnOnce(warning);
            else _lastWarning = null;
            return true;
        }
        catch (Exception ex)
        {
            WarnOnce("Configuration reload failed; retaining current settings: " + ex.Message);
            return false;
        }
        finally
        {
            Volatile.Write(ref _reloadBusy, 0);
        }
    }

    private string ReadConfigText()
    {
        // Permit rename/replace saves, but retry while a writer holds the file.
        // Timer reloads also wait for two identical successful reads.
        using FileStream stream = OpenConfigRead();
        return ReadConfigText(stream);
    }

    private FileStream OpenConfigRead() => new(
        _configPath, FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Delete);

    private static string ReadConfigText(FileStream stream)
    {
        if (stream.Length > MaximumFileBytes)
        {
            throw new InvalidDataException("Configuration exceeds the 256 KiB limit.");
        }

        byte[] bytes = new byte[(int)stream.Length];
        int read = 0;
        while (read < bytes.Length)
        {
            int count = stream.Read(bytes, read, bytes.Length - read);
            if (count == 0) throw new EndOfStreamException("Configuration changed while being read.");
            read += count;
        }

        return ConfigEncoding.GetString(bytes);
    }

    private ModSettings PreparePublication(ModSettings parsed, out bool restartRequired)
    {
        ModSettings previous = _snapshot;
        restartRequired = false;
        if (previous.HasSameValues(parsed)) return previous;
        ModSettings next = parsed.WithRevision(previous.Revision + 1);
        restartRequired = _startupCaptured && !previous.HasSameStartupValues(next) && !StartupSettings.HasSameStartupValues(next);
        return next;
    }

    private void Publish(string text, ModSettings settings)
    {
        Volatile.Write(ref _snapshot, settings);
        _loadedText = text;
        _candidateText = null;
    }

    private void NotifyRestart(bool restartRequired)
    {
        if (restartRequired && Volatile.Read(ref _disposed) == 0)
            Notify(_notice, "General settings changed; restart required. " +
                "Logging settings are reloaded immediately.");
    }

    private void CreateDefaultFileIfMissing()
    {
        if (File.Exists(_configPath)) return;
        try
        {
            string? directory = Path.GetDirectoryName(_configPath);
            if (directory != null) Directory.CreateDirectory(directory);
            using FileStream stream = new(
                _configPath, FileMode.CreateNew, FileAccess.Write, FileShare.Read);
            using StreamWriter writer = new(stream, ConfigEncoding);
            writer.WriteLine("# LoadTimeProfiler configuration. Missing settings use their current or default values.");
            writer.WriteLine("# Logging changes reload automatically. Other changes require a restart.");
            writer.WriteLine("# Invalid values keep that setting's current or default value; unknown entries are ignored.");
            writer.WriteLine("# Reload never writes this file; UI edits preserve unrelated lines.");
            writer.WriteLine();
            writer.WriteLine("[General]");
            writer.WriteLine("ProfilingEnabled = true");
            writer.WriteLine("LocalizationCacheEnabled = true");
            writer.WriteLine("ConfigWriteCoalescingEnabled = true");
            writer.WriteLine("# Reload other mods' BepInEx cfg files after local file edits. Restart required.");
            writer.WriteLine("# Each mod determines whether its changed values take effect during play.");
            writer.WriteLine("ConfigAutoReloadEnabled = false");
            writer.WriteLine("# Set to 0 to disable the timeout floor. Longer original timeouts are retained.");
            writer.WriteLine("TimeoutProtectionSeconds = 120");
            writer.WriteLine();
            writer.WriteLine("[Logging.Mods]");
            writer.WriteLine("# Exact, case-sensitive plugin GUIDs. Unlisted plugins use Errors, Warnings.");
            writer.WriteLine("# Groups: Errors (Fatal + Error), Warnings, Information (Message + Info), Debug.");
            writer.WriteLine("# Use None to disable a mod's default logger; combine group names with commas.");
            writer.WriteLine("# Unity and unattributed/custom loggers pass through unchanged.");
            writer.WriteLine("# author.examplemod = Errors, Warnings");
        }
        catch (IOException) when (File.Exists(_configPath))
        {
            // Another process may have created the file after the existence check.
        }
        catch (Exception ex)
        {
            WarnOnce("Could not create default configuration: " + ex.Message);
        }
    }

    private static ModSettings Parse(string text, ModSettings? previous, out string warning)
    {
        // A readable file is interpreted per entry. Only an unreadable initial file
        // uses fail-open logging; an invalid individual rule starts at normal defaults.
        previous ??= CreateFallback(failOpen: false);
        bool profiling = previous.ProfilingEnabled;
        bool localization = previous.LocalizationCacheEnabled;
        bool coalescing = previous.ConfigWriteCoalescingEnabled;
        bool autoReload = previous.ConfigAutoReloadEnabled;
        float timeout = previous.TimeoutProtectionSeconds;
        Dictionary<string, LogGroups> mods = new(StringComparer.Ordinal);
        int invalidCount = 0;
        int firstInvalidLine = 0;
        void Invalid(int line)
        {
            if (invalidCount++ == 0) firstInvalidLine = line;
        }
        string section = string.Empty;
        if (text.Length > 0 && text[0] == '\uFEFF') text = text.Substring(1);
        using StringReader reader = new(text);
        int lineNumber = 0;
        string? rawLine;
        while ((rawLine = reader.ReadLine()) != null)
        {
            lineNumber++;
            string line = rawLine.Trim();
            if (line.Length == 0 || line[0] == '#' || line[0] == ';') continue;
            if (line[0] == '[')
            {
                section = line[line.Length - 1] == ']' ? line.Substring(1, line.Length - 2) : string.Empty;
                if (section.Length == 0) Invalid(lineNumber);
                continue;
            }

            if (section != "General" && section != "Logging.Mods") continue;
            int separator = line.IndexOf('=');
            if (separator <= 0)
            {
                Invalid(lineNumber);
                continue;
            }

            string key = line.Substring(0, separator).Trim();
            string value = line.Substring(separator + 1).Trim();
            if (key.Length == 0)
            {
                Invalid(lineNumber);
                continue;
            }

            if (section == "Logging.Mods")
            {
                if (!IsValidGuid(key))
                {
                    Invalid(lineNumber);
                    continue;
                }
                if (TryParseGroups(value, out LogGroups groups)) mods[key] = groups;
                else
                {
                    Invalid(lineNumber);
                    if (!mods.ContainsKey(key)) mods[key] = previous.Logging.GetModGroups(key);
                }
                continue;
            }

            if (key == "TimeoutProtectionSeconds")
            {
                if (float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out float parsedTimeout) &&
                    !float.IsNaN(parsedTimeout) && !float.IsInfinity(parsedTimeout) && parsedTimeout >= 0f)
                    timeout = parsedTimeout;
                else Invalid(lineNumber);
                continue;
            }
            if (key != "ProfilingEnabled" && key != "LocalizationCacheEnabled" &&
                key != "ConfigWriteCoalescingEnabled" && key != "ConfigAutoReloadEnabled") continue;
            if (!bool.TryParse(value, out bool enabled))
            {
                Invalid(lineNumber);
                continue;
            }
            if (key == "ProfilingEnabled") profiling = enabled;
            else if (key == "LocalizationCacheEnabled") localization = enabled;
            else if (key == "ConfigWriteCoalescingEnabled") coalescing = enabled;
            else autoReload = enabled;
        }

        warning = invalidCount == 0 ? string.Empty : "Ignored " + invalidCount +
            " invalid configuration entr" + (invalidCount == 1 ? "y" : "ies") + " (first on line " + firstInvalidLine +
            "). Valid entries were applied; affected settings retain their current or default values.";
        return new ModSettings(profiling, localization, coalescing, timeout,
            new LogPolicy(mods), configAutoReloadEnabled: autoReload);
    }

    private static bool TryParseGroups(string value, out LogGroups groups)
    {
        groups = LogGroups.None;
        if (string.Equals(value, "None", StringComparison.OrdinalIgnoreCase)) return true;
        foreach (string item in value.Split(','))
        {
            string name = item.Trim();
            if (string.Equals(name, "Errors", StringComparison.OrdinalIgnoreCase)) groups |= LogGroups.Errors;
            else if (string.Equals(name, "Warnings", StringComparison.OrdinalIgnoreCase)) groups |= LogGroups.Warnings;
            else if (string.Equals(name, "Information", StringComparison.OrdinalIgnoreCase)) groups |= LogGroups.Information;
            else if (string.Equals(name, "Debug", StringComparison.OrdinalIgnoreCase)) groups |= LogGroups.Debug;
            else return false;
        }
        return true;
    }

    private void WarnOnce(string message)
    {
        if (Volatile.Read(ref _disposed) != 0 || string.Equals(_lastWarning, message, StringComparison.Ordinal)) return;
        _lastWarning = message;
        Notify(_warning, message);
    }

    private static void Notify(Action<string> callback, string message)
    {
        try { callback(message); }
        catch
        {
            // Diagnostics must not disrupt startup, logging, or the reload timer.
        }
    }
}
