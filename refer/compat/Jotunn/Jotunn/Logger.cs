using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using BepInEx;
using BepInEx.Logging;

namespace Jotunn;

/// <summary>
///     A namespace wide Logger class, which automatically creates a ManualLogSource
///     for every Class from which it is being called.
/// </summary>
public class Logger
{
	/// <summary>
	///     Add DateTime to the log output
	/// </summary>
	public static bool ShowDate = false;

	private static Logger instance = new Logger();

	private readonly Dictionary<string, ManualLogSource> logger = new Dictionary<string, ManualLogSource>();

	/// <summary>
	///     Remove and clear all Logger instances
	/// </summary>
	internal static void Destroy()
	{
		LogDebug("Destroying Logger");
		foreach (KeyValuePair<string, ManualLogSource> item in instance.logger)
		{
			BepInEx.Logging.Logger.Sources.Remove(item.Value);
		}
		instance.logger.Clear();
	}

	/// <summary>
	///     Get or create a <see cref="T:BepInEx.Logging.ManualLogSource" /> with the callers <see cref="P:System.Type.FullName" />
	/// </summary>
	/// <returns>A BepInEx <see cref="T:BepInEx.Logging.ManualLogSource" /></returns>
	private ManualLogSource GetLogger()
	{
		Type declaringType = new StackFrame(3).GetMethod().DeclaringType;
		if (!logger.TryGetValue(declaringType.FullName, out var value))
		{
			value = BepInEx.Logging.Logger.CreateLogSource(declaringType.FullName);
			logger.Add(declaringType.FullName, value);
		}
		return value;
	}

	private static void Log(LogLevel level, BepInPlugin sourceMod, object data)
	{
		string text = string.Empty;
		if (ShowDate)
		{
			text = text + "[" + DateTime.Now.ToString(DateTimeFormatInfo.InvariantInfo) + "] ";
		}
		if (sourceMod != null)
		{
			text = text + "[" + sourceMod.Name + "] ";
		}
		instance.GetLogger().Log(level, $"{text}{data}");
	}

	/// <summary>
	///     Logs a message with <see cref="F:BepInEx.Logging.LogLevel.Fatal" /> level.
	/// </summary>
	/// <param name="data">Data to log</param>
	public static void LogFatal(object data)
	{
		Log(LogLevel.Fatal, null, data);
	}

	/// <summary>
	///     Logs a message with <see cref="F:BepInEx.Logging.LogLevel.Fatal" /> level.
	///     This is used when the responsible mod is different from mod logging this message.
	/// </summary>
	/// <param name="sourceMod">Known mod that is responsible for this log</param>
	/// <param name="data">Data to log</param>
	public static void LogFatal(BepInPlugin sourceMod, object data)
	{
		Log(LogLevel.Fatal, sourceMod, data);
	}

	/// <summary>
	///     Logs a message with <see cref="F:BepInEx.Logging.LogLevel.Error" /> level.
	/// </summary>
	/// <param name="data">Data to log</param>
	public static void LogError(object data)
	{
		Log(LogLevel.Error, null, data);
	}

	/// <summary>
	///     Logs a message with <see cref="F:BepInEx.Logging.LogLevel.Error" /> level.
	///     This is used when the responsible mod is different from mod logging this message.
	/// </summary>
	/// <param name="sourceMod">Known mod that is responsible for this log</param>
	/// <param name="data">Data to log</param>
	public static void LogError(BepInPlugin sourceMod, object data)
	{
		Log(LogLevel.Error, sourceMod, data);
	}

	/// <summary>
	///     Logs a message with <see cref="F:BepInEx.Logging.LogLevel.Warning" /> level.
	/// </summary>
	/// <param name="data">Data to log</param>
	public static void LogWarning(object data)
	{
		Log(LogLevel.Warning, null, data);
	}

	/// <summary>
	///     Logs a message with <see cref="F:BepInEx.Logging.LogLevel.Warning" /> level.
	///     This is used when the responsible mod is different from mod logging this message.
	/// </summary>
	/// <param name="sourceMod">Known mod that is responsible for this log</param>
	/// <param name="data">Data to log</param>
	public static void LogWarning(BepInPlugin sourceMod, object data)
	{
		Log(LogLevel.Warning, sourceMod, data);
	}

	/// <summary>
	///     Logs a message with <see cref="F:BepInEx.Logging.LogLevel.Message" /> level.
	/// </summary>
	/// <param name="data">Data to log</param>
	public static void LogMessage(object data)
	{
		Log(LogLevel.Message, null, data);
	}

	/// <summary>
	///     Logs a message with <see cref="F:BepInEx.Logging.LogLevel.Message" /> level.
	///     This is used when the responsible mod is different from mod logging this message.
	/// </summary>
	/// <param name="sourceMod">Known mod that is responsible for this log</param>
	/// <param name="data">Data to log</param>
	public static void LogMessage(BepInPlugin sourceMod, object data)
	{
		Log(LogLevel.Message, sourceMod, data);
	}

	/// <summary>
	///     Logs a message with <see cref="F:BepInEx.Logging.LogLevel.Info" /> level.
	/// </summary>
	/// <param name="data">Data to log</param>
	public static void LogInfo(object data)
	{
		Log(LogLevel.Info, null, data);
	}

	/// <summary>
	///     Logs a message with <see cref="F:BepInEx.Logging.LogLevel.Info" /> level.
	///     This is used when the responsible mod is different from mod logging this message.
	/// </summary>
	/// <param name="sourceMod">Known mod that is responsible for this log</param>
	/// <param name="data">Data to log</param>
	public static void LogInfo(BepInPlugin sourceMod, object data)
	{
		Log(LogLevel.Info, sourceMod, data);
	}

	/// <summary>
	///     Logs a message with <see cref="F:BepInEx.Logging.LogLevel.Debug" /> level.
	/// </summary>
	/// <param name="data">Data to log</param>
	public static void LogDebug(object data)
	{
		Log(LogLevel.Debug, null, data);
	}

	/// <summary>
	///     Logs a message with <see cref="F:BepInEx.Logging.LogLevel.Debug" /> level.
	///     This is used when the responsible mod is different from mod logging this message.
	/// </summary>
	/// <param name="sourceMod">Known mod that is responsible for this log</param>
	/// <param name="data">Data to log</param>
	public static void LogDebug(BepInPlugin sourceMod, object data)
	{
		Log(LogLevel.Debug, sourceMod, data);
	}
}
