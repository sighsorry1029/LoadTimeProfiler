using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using Jotunn.Managers;
using SimpleJson;
using YamlDotNet.Serialization;

namespace Jotunn.Entities;

/// <summary> Wrapper to hold each mod localization data. </summary>
public class CustomLocalization : CustomEntity
{
	private static HashSet<string> loggedInvalidTokens = new HashSet<string>();

	private static bool? _yamlDotNetAvailable;

	/// <summary> Map that work as [language][token] = translation. </summary>
	internal Dictionary<string, Dictionary<string, string>> Map { get; }

	/// <summary>
	///     Returns true if YamlDotNet is loaded in the current AppDomain.
	///     Placed here (not on LocalizationManager) so it can be called without triggering
	///     LocalizationManager's static constructor, which requires the game runtime.
	/// </summary>
	internal static bool IsYamlDotNetAvailable()
	{
		bool valueOrDefault = _yamlDotNetAvailable == true;
		if (!_yamlDotNetAvailable.HasValue)
		{
			valueOrDefault = AppDomain.CurrentDomain.GetAssemblies().Any((Assembly a) => a.GetName().Name == "YamlDotNet");
			_yamlDotNetAvailable = valueOrDefault;
			return valueOrDefault;
		}
		return valueOrDefault;
	}

	/// <summary>
	///     Default constructor.
	/// </summary>
	[Obsolete("Use LocalizationManager.Instance.GetLocalization() instead")]
	public CustomLocalization()
		: base(Assembly.GetCallingAssembly())
	{
		Map = new Dictionary<string, Dictionary<string, string>>();
	}

	/// <summary>
	///     SourceMod hint constructor.
	/// </summary>
	/// <param name="sourceMod"> Mod data in the shape of BepInPlugin class. </param>
	public CustomLocalization(BepInPlugin sourceMod)
		: base(sourceMod)
	{
		Map = new Dictionary<string, Dictionary<string, string>>();
	}

	/// <summary> Retrieve list of languages that have been added. </summary>
	public IEnumerable<string> GetLanguages()
	{
		return Map.Keys;
	}

	/// <summary> Retrieve translations for given language. </summary>
	/// <param name="language"> Language of the translation you want to retrieve. </param>
	public IReadOnlyDictionary<string, string> GetTranslations(in string language)
	{
		if (!Map.TryGetValue(language, out var value))
		{
			return new Dictionary<string, string>();
		}
		return value;
	}

	/// <summary>
	///     Retrieve a translation from this custom localization or <see cref="M:Localization.Translate(System.String)" />.
	///     Searches with the user language with a fallback to English.
	/// </summary>
	/// <param name="word">Word to translate.</param>
	/// <returns>Translated word in player language or english as a fallback.</returns>
	public string TryTranslate(string word)
	{
		if (string.IsNullOrEmpty(word))
		{
			return string.Empty;
		}
		if (!word.StartsWith('$'.ToString()))
		{
			return word;
		}
		if (word.IndexOfAny(LocalizationManager.ForbiddenCharsArr) != -1)
		{
			if (loggedInvalidTokens.Add(word))
			{
				Logger.LogWarning(base.SourceMod, "Token '" + word + "' must not contain following chars: ' (){}[]+-!?/\\\\&%,.:-=<>\n'");
			}
			return "[" + word + "]";
		}
		string text = word.TrimStart('$');
		string playerLanguage = LocalizationManager.GetPlayerLanguage();
		string text2 = "English";
		if (Map.TryGetValue(playerLanguage, out var value) && value.TryGetValue(text, out var value2))
		{
			return value2;
		}
		if (playerLanguage != text2 && Map.TryGetValue(text2, out value) && value.TryGetValue(text, out value2))
		{
			return value2;
		}
		if (Localization.m_instance != null)
		{
			return Localization.m_instance.Translate(text);
		}
		return "[" + word + "]";
	}

	/// <summary> Checks if a translation exists for given language and token. </summary>
	/// <param name="language"> Language being checked. </param>
	/// <param name="token"> Token being checked. </param>
	/// <returns> True if the token was found. </returns>
	public bool Contains(in string language, in string token)
	{
		string key = token.TrimStart('$');
		if (Map.TryGetValue(language, out var value))
		{
			return value.ContainsKey(key);
		}
		return false;
	}

	/// <summary> Add a translation. </summary>
	/// <param name="token"> Token of the translation you want to add. </param>
	/// <param name="translation"> The translation. </param>
	public void AddTranslation(in string token, string translation)
	{
		AddTranslation("English", in token, translation);
	}

	/// <summary> Add a translation. </summary>
	/// <param name="language"> Language of the translation you want to add. </param>
	/// <param name="token"> Token of the translation you want to add. </param>
	/// <param name="translation"> The translation. </param>
	public void AddTranslation(in string language, in string token, string translation)
	{
		if (!Map.ContainsKey(language))
		{
			Map.Add(language, new Dictionary<string, string>());
		}
		if (ValidateLanguage(in language) && ValidateToken(in token) && ValidateTranslation(in translation))
		{
			string cleanedToken = token.TrimStart('$');
			AddTranslationToMap(in language, cleanedToken, translation);
		}
	}

	/// <summary> Add a group of translations. </summary>
	/// <param name="language"> Language of the translation you want to add. </param>
	/// <param name="tokenValue"> Token-Value dictionary. </param>
	public void AddTranslation(in string language, Dictionary<string, string> tokenValue)
	{
		if (!Map.ContainsKey(language))
		{
			Map.Add(language, new Dictionary<string, string>());
		}
		if (!ValidateLanguage(in language))
		{
			return;
		}
		foreach (KeyValuePair<string, string> item in tokenValue)
		{
			string token = item.Key.TrimStart('$');
			string translation = item.Value;
			if (ValidateToken(in token) && ValidateTranslation(in translation))
			{
				AddTranslationToMap(in language, token, translation);
			}
		}
	}

	/// <summary> Add a translation file via absolute path. </summary>
	/// <param name="path"> Absolute path to file. </param>
	/// <param name="isJson"> Is the language file a json file. </param>
	public void AddFileByPath(string path, bool isJson = false)
	{
		if (path == null)
		{
			throw new ArgumentNullException("path");
		}
		string text = File.ReadAllText(path);
		if (text == null)
		{
			throw new ArgumentNullException("fileContent");
		}
		string text2 = Path.GetExtension(path).ToLowerInvariant();
		string text3;
		if (text2 == ".yaml" || text2 == ".yml")
		{
			AddYamlFile(Path.GetFileName(Path.GetDirectoryName(path)), text);
			text3 = "YAML";
		}
		else if (isJson)
		{
			AddJsonFile(Path.GetFileName(Path.GetDirectoryName(path)), text);
			text3 = "JSON";
		}
		else
		{
			AddLanguageFile(text);
			text3 = "";
		}
		Logger.LogDebug("Added " + text3 + " language file: " + Path.GetFileName(path));
	}

	/// <summary> Add a json language file (match crowdin format). </summary>
	/// <param name="language"> Language for the json file, for example, "English" </param>
	/// <param name="fileContent"> Entire file as string </param>
	public void AddJsonFile(string language, string fileContent)
	{
		if (!ValidateLanguage(in language))
		{
			return;
		}
		IDictionary<string, object> dictionary;
		try
		{
			dictionary = global::SimpleJson.SimpleJson.DeserializeObject<IDictionary<string, object>>(fileContent);
		}
		catch (Exception ex)
		{
			Logger.LogWarning(base.SourceMod, "Could not read " + language + " JSON localization: " + ex.Message);
			return;
		}
		if (!Map.ContainsKey(language))
		{
			Map.Add(language, new Dictionary<string, string>());
		}
		foreach (KeyValuePair<string, object> item in dictionary)
		{
			string translation = item.Value as string;
			string token = item.Key.TrimStart('$');
			if (ValidateToken(in token) && ValidateTranslation(in translation))
			{
				AddTranslationToMap(in language, token, translation);
			}
		}
	}

	/// <summary> Add a YAML language file. Keys are flat string-to-string mappings. </summary>
	/// <param name="language"> Language for the yaml file, for example, "English" </param>
	/// <param name="fileContent"> Entire file as string </param>
	public void AddYamlFile(string language, string fileContent)
	{
		if (!IsYamlDotNetAvailable())
		{
			Logger.LogWarning(base.SourceMod, "Cannot load YAML localization for '" + language + "': YamlDotNet is not loaded. Mods using .yaml/.yml localization must include YamlDotNet.dll as a dependency.");
		}
		else if (ValidateLanguage(in language))
		{
			ParseAndAddYaml(language, fileContent);
		}
	}

	private void ParseAndAddYaml(string language, string fileContent)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected O, but got Unknown
		Dictionary<string, string> dictionary;
		try
		{
			dictionary = ((BuilderSkeleton<DeserializerBuilder>)new DeserializerBuilder()).IgnoreFields().Build().Deserialize<Dictionary<string, string>>(fileContent);
		}
		catch (Exception ex)
		{
			Logger.LogWarning(base.SourceMod, "Could not read " + language + " YAML localization: " + ex.Message);
			return;
		}
		if (dictionary == null)
		{
			return;
		}
		if (!Map.ContainsKey(language))
		{
			Map.Add(language, new Dictionary<string, string>());
		}
		foreach (KeyValuePair<string, string> item in dictionary)
		{
			string token = item.Key.TrimStart('$');
			if (ValidateToken(in token) && ValidateTranslation(item.Value))
			{
				AddTranslationToMap(in language, token, item.Value);
			}
		}
	}

	/// <summary> Add a Unity style translation file. </summary>
	/// <param name="fileContent"> Contents of the language file in string format. </param>
	public void AddLanguageFile(string fileContent)
	{
		StringReader stringReader = new StringReader(fileContent);
		string[] array = stringReader.ReadLine().Split(',');
		foreach (List<string> item in LocalizationManager.DoQuoteLineSplit(stringReader))
		{
			if (item.Count == 0)
			{
				continue;
			}
			string token = item[0];
			if (token.StartsWith("//") || token.Length == 0 || !ValidateToken(in token))
			{
				continue;
			}
			string cleanedToken = token.TrimStart('$');
			for (int i = 1; i < item.Count; i++)
			{
				string language = array[i];
				string translation = item[i];
				if (string.IsNullOrEmpty(translation) || translation[0] == '\r')
				{
					translation = item[1];
				}
				if (ValidateLanguage(in language) && ValidateTranslation(in translation))
				{
					if (!Map.ContainsKey(language))
					{
						Map.Add(language, new Dictionary<string, string>());
					}
					AddTranslationToMap(in language, cleanedToken, translation);
				}
			}
		}
	}

	/// <summary> Attempts to remove a given token from certain language. </summary>
	/// <param name="language"> Language from which to search the token. </param>
	/// <param name="token"> Token to clear. </param>
	public void ClearToken(in string language, in string token)
	{
		if (Map.ContainsKey(language))
		{
			Map.Remove(token.TrimStart('$'));
		}
	}

	/// <summary> Attempts to remove a given token from default language. </summary>
	/// <param name="token"> Token to clear. </param>
	public void ClearToken(in string token)
	{
		ClearToken("English", in token);
	}

	/// <summary> Attempts to remove given language. </summary>
	/// <param name="language"> Language to clear. </param>
	public void ClearLanguage(in string language)
	{
		Map.Remove(language);
	}

	/// <summary> Clear all localization data. </summary>
	public void ClearAll()
	{
		Map.Clear();
	}

	private void AddTranslationToMap(in string language, string cleanedToken, string translation)
	{
		Map[language][cleanedToken] = translation;
		if (Localization.m_instance != null && !Localization.m_instance.m_translations.ContainsKey(cleanedToken))
		{
			Localization.m_instance.AddWord(cleanedToken, translation);
		}
	}

	private bool ValidateLanguage(in string language)
	{
		if (string.IsNullOrEmpty(language))
		{
			throw new ArgumentNullException("language");
		}
		if (!char.IsUpper(language[0]))
		{
			Logger.LogWarning(base.SourceMod, "Language '" + language + "' must start with a capital letter");
			return false;
		}
		return true;
	}

	private bool ValidateToken(in string token)
	{
		if (string.IsNullOrEmpty(token))
		{
			throw new ArgumentNullException("token");
		}
		if (token.IndexOfAny(LocalizationManager.ForbiddenCharsArr) != -1)
		{
			if (loggedInvalidTokens.Add(token))
			{
				Logger.LogWarning(base.SourceMod, "Token '" + token + "' must not contain following chars: ' (){}[]+-!?/\\\\&%,.:-=<>\n'");
			}
			return false;
		}
		return true;
	}

	private bool ValidateTranslation(in string translation)
	{
		if (translation == null)
		{
			throw new ArgumentNullException("translation");
		}
		return true;
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return "Localization (" + base.SourceMod.GUID + ")";
	}
}
