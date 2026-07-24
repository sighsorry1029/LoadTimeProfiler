using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BepInEx;
using Jotunn.Entities;
using Jotunn.Managers;

namespace Jotunn.Utils;

internal static class AutomaticLocalizationsLoading
{
	public const string TranslationsFolderName = "Translations";

	public const string CommunityTranslationFileName = "community_translation.json";

	public static void Init()
	{
		HashSet<FileInfo> hashSet = new HashSet<FileInfo>();
		HashSet<FileInfo> hashSet2 = new HashSet<FileInfo>();
		HashSet<FileInfo> hashSet3 = new HashSet<FileInfo>();
		foreach (FileInfo translationFile in GetTranslationFiles(Paths.LanguageTranslationsFolder, "community_translation.json"))
		{
			hashSet.Add(translationFile);
		}
		foreach (FileInfo translationFile2 in GetTranslationFiles(Paths.LanguageTranslationsFolder, "*.json"))
		{
			hashSet.Add(translationFile2);
		}
		foreach (FileInfo translationFile3 in GetTranslationFiles(Paths.LanguageTranslationsFolder, "*.language"))
		{
			hashSet2.Add(translationFile3);
		}
		foreach (FileInfo translationFile4 in GetTranslationFiles(Paths.LanguageTranslationsFolder, "*.yaml"))
		{
			hashSet3.Add(translationFile4);
		}
		foreach (FileInfo translationFile5 in GetTranslationFiles(Paths.LanguageTranslationsFolder, "*.yml"))
		{
			hashSet3.Add(translationFile5);
		}
		foreach (FileInfo item in hashSet)
		{
			try
			{
				BepInPlugin bepInPlugin = BepInExUtils.GetPluginInfoFromPath(item)?.Metadata;
				LocalizationManager.Instance.GetLocalization(bepInPlugin ?? Main.Instance.Info.Metadata).AddFileByPath(item.FullName, isJson: true);
			}
			catch (Exception arg)
			{
				Logger.LogWarning($"Exception caught while loading localization file {item}: {arg}");
			}
		}
		foreach (FileInfo item2 in hashSet2)
		{
			try
			{
				BepInPlugin bepInPlugin2 = BepInExUtils.GetPluginInfoFromPath(item2)?.Metadata;
				LocalizationManager.Instance.GetLocalization(bepInPlugin2 ?? Main.Instance.Info.Metadata).AddFileByPath(item2.FullName);
			}
			catch (Exception arg2)
			{
				Logger.LogWarning($"Exception caught while loading localization file {item2}: {arg2}");
			}
		}
		if (hashSet3.Count > 0 && !CustomLocalization.IsYamlDotNetAvailable())
		{
			Logger.LogWarning($"Found {hashSet3.Count} YAML localization file(s) but YamlDotNet is not loaded. " + "Mods using .yaml/.yml localization must include YamlDotNet.dll as a dependency.");
			return;
		}
		foreach (FileInfo item3 in hashSet3)
		{
			try
			{
				BepInPlugin bepInPlugin3 = BepInExUtils.GetPluginInfoFromPath(item3)?.Metadata;
				LocalizationManager.Instance.GetLocalization(bepInPlugin3 ?? Main.Instance.Info.Metadata).AddFileByPath(item3.FullName);
			}
			catch (Exception arg3)
			{
				Logger.LogWarning($"Exception caught while loading localization file {item3}: {arg3}");
			}
		}
	}

	private static IEnumerable<FileInfo> GetTranslationFiles(string path, string searchPattern)
	{
		return GetTranslationFiles(new DirectoryInfo(path), searchPattern);
	}

	private static IEnumerable<FileInfo> GetTranslationFiles(DirectoryInfo pathDirectoryInfo, string searchPattern)
	{
		if (!pathDirectoryInfo.Exists)
		{
			yield break;
		}
		string[] files = Directory.GetFiles(pathDirectoryInfo.FullName, searchPattern, SearchOption.AllDirectories);
		foreach (string item in files.Where((string path) => new DirectoryInfo(path).Parent?.Parent?.Name == "Translations"))
		{
			yield return new FileInfo(item);
		}
	}
}
