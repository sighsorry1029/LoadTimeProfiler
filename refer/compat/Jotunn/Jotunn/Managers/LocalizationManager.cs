using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn.Managers;

/// <summary> 
///     Manager for handling localizations for all custom content added to the game.
/// </summary>
public class LocalizationManager : IManager
{
	private static class Patches
	{
		[HarmonyPatch(typeof(FejdStartup), "SetupGui")]
		[HarmonyPostfix]
		private static void LoadAndSetupModLanguages()
		{
			Instance.LoadAndSetupModLanguages(Localization.instance);
		}

		[HarmonyPatch(typeof(Localization), "LoadLanguages")]
		[HarmonyPostfix]
		private static void Localization_LoadLanguages(ref List<string> __result)
		{
			Instance.AddLanguages(ref __result);
		}

		[HarmonyPatch(typeof(Localization), "SetupLanguage")]
		[HarmonyPostfix]
		private static void Localization_SetupLanguage(Localization __instance, string language)
		{
			Instance.AddTranslations(__instance, language);
		}
	}

	/// <summary>
	///     List where all data is collected.
	/// </summary>
	internal readonly Dictionary<string, CustomLocalization> Localizations = new Dictionary<string, CustomLocalization>();

	/// <summary>
	///     Your token must start with this character.
	/// </summary>
	public const char TokenFirstChar = '$';

	/// <summary>
	///     Default language of the game.
	/// </summary>
	public const string DefaultLanguage = "English";

	/// <summary>
	///     Name of the folder that will hold the custom .json translations files.
	/// </summary>
	public const string TranslationsFolderName = "Translations";

	/// <summary>
	///     Name of the community translation files that will be the first custom languages files loaded before any others.
	/// </summary>
	public const string CommunityTranslationFileName = "community_translation.json";

	/// <summary>
	///     String of chars not allowed in a token string.
	/// </summary>
	internal const string ForbiddenChars = " (){}[]+-!?/\\\\&%,.:-=<>\n";

	/// <summary>
	///     Array of chars not allowed in a token string.
	/// </summary>
	internal static readonly char[] ForbiddenCharsArr;

	private static LocalizationManager _instance;

	/// <summary>
	///     Localizations for internal use.
	/// </summary>
	internal CustomLocalization JotunnLocalization = new CustomLocalization(Main.Instance.Info.Metadata);

	/// <summary>
	///     Call into unity's DoQuoteLineSplit.
	/// </summary>
	internal static Func<StringReader, List<List<string>>> DoQuoteLineSplit;

	/// <summary>
	///     The singleton instance of this manager.
	/// </summary>
	public static LocalizationManager Instance => _instance ?? (_instance = new LocalizationManager());

	/// <summary>
	///     Event that gets fired after all custom localization has been added to the game.
	///     Use this event if you need to translate strings using the vanilla <see cref="T:Localization" /> class.
	///     Your code will execute every time the localization gets reset (on every menu start).
	///     If you want to execute just once you will need to unregister from the event after execution.
	/// </summary>
	public static event Action OnLocalizationAdded;

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private LocalizationManager()
	{
	}

	static LocalizationManager()
	{
		ForbiddenCharsArr = " (){}[]+-!?/\\\\&%,.:-=<>\n".ToCharArray();
		((IManager)Instance).Init();
	}

	/// <summary>
	///     Initialize localization manager.
	/// </summary>
	void IManager.Init()
	{
		Main.LogInit("LocalizationManager");
		Main.Harmony.PatchAll(typeof(Patches));
		DoQuoteLineSplit = (Func<StringReader, List<List<string>>>)Delegate.CreateDelegate(typeof(Func<StringReader, List<List<string>>>), null, typeof(Localization).GetMethod("DoQuoteLineSplit", (BindingFlags)(-1)));
		AddLocalization(JotunnLocalization);
	}

	private void LoadAndSetupModLanguages(Localization localization)
	{
		AddLanguages(ref localization.m_languages);
		AddTranslations(localization, GetPlayerLanguage());
		InvokeOnLocalizationAdded();
	}

	private void InvokeOnLocalizationAdded()
	{
		LocalizationManager.OnLocalizationAdded?.SafeInvoke();
	}

	private void AddLanguages(ref List<string> result)
	{
		foreach (CustomLocalization value in Localizations.Values)
		{
			foreach (string language in value.GetLanguages())
			{
				if (!result.Contains(language))
				{
					result.Add(language);
				}
			}
		}
	}

	private void AddTranslations(Localization localization, string language)
	{
		foreach (KeyValuePair<string, string> allTranslation in GetAllTranslations("English"))
		{
			localization.AddWord(allTranslation.Key, allTranslation.Value);
		}
		if (string.IsNullOrEmpty(language) || language == "English")
		{
			return;
		}
		foreach (KeyValuePair<string, string> allTranslation2 in GetAllTranslations(language))
		{
			localization.AddWord(allTranslation2.Key, allTranslation2.Value);
		}
	}

	private IEnumerable<KeyValuePair<string, string>> GetAllTranslations(string language)
	{
		return Localizations.Values.SelectMany((CustomLocalization ct) => ct.GetTranslations(in language));
	}

	internal static string GetPlayerLanguage()
	{
		return PlayerPrefs.GetString("language", "English");
	}

	/// <summary>
	///     Add your mod's custom localization. Only one <see cref="T:Jotunn.Entities.CustomLocalization" /> can be added per mod.
	/// </summary>
	/// <param name="customLocalization">The localization to add.</param>
	/// <returns>true if the custom localization was added to the manager.</returns>
	public bool AddLocalization(CustomLocalization customLocalization)
	{
		if (Localizations.ContainsKey(customLocalization.SourceMod.GUID))
		{
			Logger.LogWarning(customLocalization.SourceMod, $"{customLocalization} already added");
			return false;
		}
		Localizations.Add(customLocalization.SourceMod.GUID, customLocalization);
		return true;
	}

	/// <summary>
	///     Get the CustomLocalization for your mod.
	///     Creates a new <see cref="T:Jotunn.Entities.CustomLocalization" /> if no localization was added before.
	/// </summary>
	/// <returns>Existing or newly created <see cref="T:Jotunn.Entities.CustomLocalization" />.</returns>
	public CustomLocalization GetLocalization()
	{
		return GetLocalization(BepInExUtils.GetSourceModMetadata());
	}

	/// <summary>
	///     Get the CustomLocalization for a given mod.
	///     Creates a new <see cref="T:Jotunn.Entities.CustomLocalization" /> if no localization was added before.
	/// </summary>
	/// <returns>Existing or newly created <see cref="T:Jotunn.Entities.CustomLocalization" />.</returns>
	internal CustomLocalization GetLocalization(BepInPlugin sourceMod)
	{
		if (Localizations.TryGetValue(sourceMod.GUID, out var value))
		{
			return value;
		}
		value = new CustomLocalization(sourceMod);
		AddLocalization(value);
		return value;
	}

	/// <summary>
	///     Retrieve a translation if it's found in any CustomLocalization or <see cref="M:Localization.Translate(System.String)" />.
	/// </summary>
	/// <param name="word"> Word to translate. </param>
	/// <returns> Translated word in player language or english as a fallback. </returns>
	public string TryTranslate(string word)
	{
		string word2 = word.TrimStart('$');
		string text;
		foreach (CustomLocalization value in Localizations.Values)
		{
			if (value != JotunnLocalization)
			{
				text = value.TryTranslate(word);
				if (IsValidTranslation(text))
				{
					return text;
				}
			}
		}
		text = JotunnLocalization.TryTranslate(word);
		if (IsValidTranslation(text))
		{
			return text;
		}
		if (Localization.m_instance != null)
		{
			return Localization.m_instance.Translate(word2);
		}
		return "[" + word + "]";
	}

	private static bool IsValidTranslation(string translation)
	{
		if (!string.IsNullOrEmpty(translation))
		{
			return translation[0] != '[';
		}
		return false;
	}

	/// <summary> 
	///     Registers a new Localization for a language.
	/// </summary>
	/// <param name="config"> Wrapper which contains a language and a Token-Value dictionary. </param>
	[Obsolete("Use AddLocalization(CustomLocalization) instead")]
	public void AddLocalization(LocalizationConfig config)
	{
		GetLocalization().AddTranslation(config.Language, config.Translations);
	}

	/// <summary> 
	///     Registers a new Localization for a language.
	/// </summary>
	/// <param name="language"> The language being added. </param>
	/// <param name="localization"> Token-Value dictionary. </param>
	[Obsolete("Use AddLocalization(CustomLocalization) instead")]
	public void AddLocalization(string language, Dictionary<string, string> localization)
	{
		GetLocalization().AddTranslation(in language, localization);
	}

	/// <summary> 
	///     Add a token and its value to the "English" language.
	/// </summary>
	/// <param name="token"> Token </param>
	/// <param name="value"> Translation. </param>
	/// <param name="forceReplace"> Replace the token if it already exists </param>
	[Obsolete("Use AddLocalization(CustomLocalization) instead")]
	public void AddToken(string token, string value, bool forceReplace = false)
	{
		GetLocalization().AddTranslation(in token, value);
	}

	/// <summary> 
	///     Add a token and its value to the specified language (default to "English").
	/// </summary>
	/// <param name="token"> Token </param>
	/// <param name="value"> Translation. </param>
	/// <param name="language"> Language ID for this token. </param>
	/// <param name="forceReplace"> Replace the token if it already exists </param>
	[Obsolete("Use AddLocalization(CustomLocalization) instead")]
	public void AddToken(string token, string value, string language, bool forceReplace = false)
	{
		GetLocalization().AddTranslation(in language, in token, value);
	}

	/// <summary> 
	///     Add a file via absolute path.
	/// </summary>
	/// <param name="path"> Absolute path to file. </param>
	/// <param name="isJson"> Is the language file a json file. </param>
	[Obsolete("Use AddLocalization(CustomLocalization) instead")]
	public void AddPath(string path, bool isJson = false)
	{
		GetLocalization().AddFileByPath(path, isJson);
	}

	/// <summary>
	///     Add a json language file (match crowdin format).
	/// </summary>
	/// <param name="language"> Language for the json file, for example, "English" </param>
	/// <param name="fileContent"> Entire file as string </param>
	[Obsolete("Use AddLocalization(CustomLocalization) instead")]
	public void AddJson(string language, string fileContent)
	{
		GetLocalization().AddJsonFile(language, fileContent);
	}

	/// <summary>
	///     Add a language file that matches Valheim's language format.
	/// </summary>
	/// <param name="fileContent"> Entire file as string </param>
	[Obsolete("Use AddLocalization(CustomLocalization) instead")]
	public void AddLanguageFile(string fileContent)
	{
		GetLocalization().AddLanguageFile(fileContent);
	}
}
