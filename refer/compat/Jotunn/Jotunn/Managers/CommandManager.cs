using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Jotunn.Entities;

namespace Jotunn.Managers;

/// <summary>
///     Manager for handling custom console and chat commands.
/// </summary>
public class CommandManager : IManager
{
	private static class Patches
	{
		[HarmonyPatch(typeof(Console), "Awake")]
		[HarmonyPostfix]
		private static void AddCustomCommands(Console __instance)
		{
			Instance.AddCustomCommands(__instance);
		}

		[HarmonyPatch(typeof(Terminal.ConsoleCommand), "GetTabOptions")]
		[HarmonyPostfix]
		private static void ConsoleCommand_GetTabOptions(Terminal.ConsoleCommand __instance, ref List<string> __result)
		{
			Instance.ConsoleCommand_GetTabOptions(__instance, ref __result);
		}
	}

	private static CommandManager _instance;

	/// <summary>
	///     Internal Action delegate to add custom entities into vanilla command's option list
	/// </summary>
	internal static Action<string, List<string>> OnGetTabOptions;

	private List<ConsoleCommand> _customCommands = new List<ConsoleCommand>();

	/// <summary>
	///     The singleton instance of this manager.
	/// </summary>
	public static CommandManager Instance => _instance ?? (_instance = new CommandManager());

	/// <summary>
	///     A list of all the custom console commands that have been added to the game through this manager,
	///     either by Jotunn or by mods using Jotunn.
	/// </summary>
	public ReadOnlyCollection<ConsoleCommand> CustomCommands => _customCommands.AsReadOnly();

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private CommandManager()
	{
	}

	static CommandManager()
	{
		((IManager)Instance).Init();
	}

	/// <summary>
	///     Initialize console commands that come with Jotunn.
	/// </summary>
	void IManager.Init()
	{
		Main.LogInit("CommandManager");
		Main.Harmony.PatchAll(typeof(Patches));
	}

	/// <summary>
	///     Adds a new console command to Valheim.
	/// </summary>
	/// <param name="cmd">The console command to add</param>
	public void AddConsoleCommand(ConsoleCommand cmd)
	{
		if (_customCommands.Exists((ConsoleCommand c) => c.Name == cmd.Name))
		{
			Logger.LogWarning(cmd.SourceMod, "Cannot have two console commands with same name: " + cmd.Name);
		}
		else if (cmd.Name.Contains(" "))
		{
			Logger.LogWarning(cmd.SourceMod, "Cannot have command containing space: '" + cmd.Name + "'");
		}
		else
		{
			_customCommands.Add(cmd);
		}
	}

	private void AddCustomCommands(Console self)
	{
		if (!_customCommands.Any())
		{
			return;
		}
		Logger.LogInfo($"Adding {_customCommands.Count} commands to the Console");
		foreach (ConsoleCommand customCommand in _customCommands)
		{
			if (((Terminal)self).m_commandList.Contains(customCommand.Name))
			{
				Logger.LogWarning(customCommand.SourceMod, "Cannot override existing command: " + customCommand.Name);
			}
			else
			{
				CreateVanillaCommand(customCommand);
			}
		}
		((Terminal)self).updateCommandList();
	}

	private Terminal.ConsoleCommand CreateVanillaCommand(ConsoleCommand command)
	{
		ConstructorInfo constructorInfo = AccessTools.Constructor(typeof(Terminal.ConsoleCommand), new Type[12]
		{
			typeof(string),
			typeof(string),
			typeof(Terminal.ConsoleEvent),
			typeof(bool),
			typeof(bool),
			typeof(bool),
			typeof(bool),
			typeof(bool),
			typeof(Terminal.ConsoleOptionsFetcher),
			typeof(bool),
			typeof(bool),
			typeof(bool)
		});
		if (constructorInfo != null)
		{
			return (Terminal.ConsoleCommand)constructorInfo.Invoke(new object[12]
			{
				command.Name,
				command.Help,
				(Terminal.ConsoleEvent)delegate(Terminal.ConsoleEventArgs args)
				{
					command.Run(args.Args.Skip(1).ToArray(), args.Context);
				},
				command.IsCheat,
				command.IsNetwork,
				command.OnlyServer,
				command.IsSecret,
				false,
				new Terminal.ConsoleOptionsFetcher(command.CommandOptionList),
				false,
				false,
				false
			});
		}
		Logger.LogError("No suitable constructor for Terminal.ConsoleCommand found");
		return null;
	}

	/// <summary>
	///     Fire <see cref="F:Jotunn.Managers.CommandManager.OnGetTabOptions" /> for any ConsoleCommand when its tabOptions member
	///     is first populated to add Jötunn entities to the option list
	/// </summary>
	/// <param name="self"></param>
	/// <param name="result"></param>
	/// <returns></returns>
	private void ConsoleCommand_GetTabOptions(Terminal.ConsoleCommand self, ref List<string> result)
	{
		if (self.m_tabOptions == null && self.m_tabOptionsFetcher != null)
		{
			OnGetTabOptions?.SafeInvoke(self.Command, result);
		}
	}
}
