using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Jotunn.Configs;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn.Managers;

/// <summary>
///    Manager for handling custom skills added to the game.
/// </summary>
public class SkillManager : IManager
{
	private static class Patches
	{
		[HarmonyPatch(typeof(Skills), "Awake")]
		[HarmonyPostfix]
		private static void RegisterCustomSkills(Skills __instance)
		{
			Instance.RegisterCustomSkills(__instance);
		}

		[HarmonyPatch(typeof(Skills), "IsSkillValid")]
		[HarmonyPostfix]
		private static void Skills_IsSkillValid(Skills __instance, Skills.SkillType type, ref bool __result)
		{
			Instance.Skills_IsSkillValid(__instance, type, ref __result);
		}

		[HarmonyPatch(typeof(Skills), "GetSkill")]
		[HarmonyPrefix]
		private static void Skills_GetSkill(Skills __instance, ref Skills.SkillType skillType)
		{
			Instance.Skills_GetSkill(__instance, ref skillType);
		}

		[HarmonyPatch(typeof(Skills), "CheatRaiseSkill")]
		[HarmonyPrefix]
		private static bool Skills_CheatRaiseSkill(Skills __instance, string name, float value)
		{
			return Instance.Skills_CheatRaiseSkill(__instance, name, value);
		}

		[HarmonyPatch(typeof(Skills), "CheatResetSkill")]
		[HarmonyPrefix]
		private static bool Skills_CheatResetSkill(Skills __instance, string name)
		{
			return Instance.Skills_CheatResetSkill(__instance, name);
		}

		[HarmonyPatch(typeof(Terminal), "Awake")]
		[HarmonyPostfix]
		private static void Terminal_InitTerminal()
		{
			Instance.AddSkillsToTerminal();
		}
	}

	private static SkillManager _instance;

	private bool addedSkillsToTerminal;

	internal Dictionary<Skills.SkillType, SkillConfig> CustomSkills = new Dictionary<Skills.SkillType, SkillConfig>();

	/// <summary>
	///     Global singleton instance of the manager.
	/// </summary>
	public static SkillManager Instance => _instance ?? (_instance = new SkillManager());

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private SkillManager()
	{
	}

	static SkillManager()
	{
		((IManager)Instance).Init();
	}

	/// <summary>
	///     Initialize the manager
	/// </summary>
	void IManager.Init()
	{
		Main.LogInit("SkillManager");
		Main.Harmony.PatchAll(typeof(Patches));
	}

	/// <summary>
	///     Add a new skill with given SkillConfig object.
	/// </summary>
	/// <param name="skillConfig">SkillConfig object representing new skill to register</param>
	/// <returns>The SkillType of the newly added skill</returns>
	public Skills.SkillType AddSkill(SkillConfig skillConfig)
	{
		if (string.IsNullOrEmpty(skillConfig?.Identifier))
		{
			Logger.LogError("Failed to register skill with invalid identifier: " + skillConfig?.Identifier);
			return Skills.SkillType.None;
		}
		CustomSkills.Add(skillConfig.UID, skillConfig);
		return skillConfig.UID;
	}

	/// <summary>
	///     Register a new skill with given parameters, and registers translations for it in the current localization.
	/// </summary>
	/// <param name="identifer">Unique identifier of the new skill, ex: "com.jotunn.testmod.testskill"</param>
	/// <param name="name">Name of the new skill</param>
	/// <param name="description">Description of the new skill</param>
	/// <param name="increaseStep"></param>
	/// <param name="icon">Icon for the skill</param>
	/// <returns>The SkillType of the newly registered skill</returns>
	[Obsolete("Use AddSkill(SkillConfig) instead")]
	public Skills.SkillType AddSkill(string identifer, string name, string description, float increaseStep = 1f, Sprite icon = null)
	{
		return AddSkill(new SkillConfig
		{
			Identifier = identifer,
			Name = name,
			Description = description,
			IncreaseStep = increaseStep,
			Icon = icon
		});
	}

	/// <summary>
	///     Adds skills defined in a JSON file at given path, relative to BepInEx/plugins
	/// </summary>
	/// <param name="path">JSON file path, relative to BepInEx/plugins folder</param>
	public void AddSkillsFromJson(string path)
	{
		string text = AssetUtils.LoadText(path);
		if (string.IsNullOrEmpty(text))
		{
			Logger.LogError("Failed to load skills from json: " + path);
			return;
		}
		List<SkillConfig> list = SkillConfig.ListFromJson(text);
		foreach (SkillConfig item in list)
		{
			AddSkill(item);
		}
	}

	/// <summary>
	///     Gets a custom skill with given SkillType.
	/// </summary>
	/// <param name="skillType">SkillType to look for</param>
	/// <returns>Custom skill with given SkillType</returns>
	public Skills.SkillDef GetSkill(Skills.SkillType skillType)
	{
		if (CustomSkills.ContainsKey(skillType))
		{
			return CustomSkills[skillType].ToSkillDef();
		}
		return Player.m_localPlayer?.GetSkills()?.m_skills?.FirstOrDefault((Skills.SkillDef skill) => skill.m_skill == skillType);
	}

	/// <summary>
	///     Gets a custom skill with given skill identifier.
	/// </summary>
	/// <param name="identifier">String indentifer of SkillType to look for</param>
	/// <returns>Custom skill with given SkillType</returns>
	public Skills.SkillDef GetSkill(string identifier)
	{
		if (string.IsNullOrEmpty(identifier))
		{
			return null;
		}
		return GetSkill((Skills.SkillType)Math.Abs(StringExtensionMethods.GetStableHashCode(identifier)));
	}

	private void RegisterCustomSkills(Skills self)
	{
		if (CustomSkills.Count <= 0)
		{
			return;
		}
		Logger.LogInfo($"Registering {CustomSkills.Count} custom skills");
		foreach (SkillConfig value in CustomSkills.Values)
		{
			LocalizationManager.Instance.JotunnLocalization.AddTranslation($"skill_{value.UID}", value.LocalizedName);
			self.m_skills.Add(value.ToSkillDef());
			Logger.LogDebug("Registered skill " + value.Name + " | ID: " + value.Identifier);
		}
	}

	private void Skills_IsSkillValid(Skills self, Skills.SkillType skillType, ref bool result)
	{
		result = result || CustomSkills.ContainsKey((Skills.SkillType)Math.Abs((int)skillType));
	}

	private void Skills_GetSkill(Skills self, ref Skills.SkillType skillType)
	{
		Skills.SkillType skillType2 = (Skills.SkillType)Math.Abs((int)skillType);
		if (skillType < Skills.SkillType.None && CustomSkills.ContainsKey(skillType2))
		{
			skillType = skillType2;
		}
	}

	private bool Skills_CheatRaiseSkill(Skills self, string name, float value)
	{
		foreach (SkillConfig value2 in CustomSkills.Values)
		{
			if (value2.IsFromName(name))
			{
				Skills.Skill skill = self.GetSkill(value2.UID);
				string localizedName = value2.LocalizedName;
				skill.m_level += value;
				skill.m_level = Mathf.Clamp(skill.m_level, 0f, 100f);
				self.m_player.Message(MessageHud.MessageType.TopLeft, $"Skill increased {localizedName}: {(int)skill.m_level}", 0, skill.m_info.m_icon);
				Console.instance.Print($"Skill {localizedName} = {skill.m_level}");
				Logger.LogDebug($"Raised skill {localizedName} to {skill.m_level}");
				return false;
			}
		}
		return true;
	}

	private bool Skills_CheatResetSkill(Skills self, string name)
	{
		foreach (SkillConfig value in CustomSkills.Values)
		{
			if (value.IsFromName(name))
			{
				self.m_player.GetSkills().ResetSkill(value.UID);
				Console.instance.Print("Skill " + value.LocalizedName + " reset");
				Logger.LogDebug("Reset skill " + value.Name);
				return false;
			}
		}
		return true;
	}

	private void AddSkillsToTerminal()
	{
		if (Terminal.m_terminalInitialized && !addedSkillsToTerminal)
		{
			addedSkillsToTerminal = true;
			AddSkillOptions("raiseskill");
			AddSkillOptions("resetskill");
		}
	}

	private void AddSkillOptions(string commandName)
	{
		if (Terminal.commands.TryGetValue(commandName, out var value))
		{
			Terminal.ConsoleOptionsFetcher fetcher = value.m_tabOptionsFetcher;
			value.m_tabOptionsFetcher = delegate
			{
				List<string> list = fetcher();
				list.AddRange(CustomSkills.Values.Select((SkillConfig skill) => skill.LocalizedName));
				return list;
			};
		}
		else
		{
			Logger.LogWarning("Failed to find " + commandName + " command");
		}
	}
}
