using System;
using System.Collections.Generic;
using BepInEx;

namespace Jotunn.Utils;

internal class ModModule
{
	public const int LegacyDataLayoutVersion = 0;

	public const int CurrentDataLayoutVersion = 1;

	public static readonly HashSet<int> SupportedDataLayouts = new HashSet<int> { 0, 1 };

	private string guid;

	/// <summary>
	///     DataLayoutVersion indicates the version layout of data within the ZPkg. If equal to 0 then it is a legacy format.
	/// </summary>
	public int DataLayoutVersion { get; private set; }

	/// <summary>
	///     Identifier for mod based on DataLayoutVersion. 
	///     For legacy layout returns mod name, otherwise returns mod GUID. 
	/// </summary>
	public string ModID
	{
		get
		{
			if (DataLayoutVersion != 0)
			{
				return guid;
			}
			return ModName;
		}
	}

	/// <summary>
	///     Friendly version of mod name.
	/// </summary>
	public string ModName { get; }

	/// <summary>
	///     Version data for mod.
	/// </summary>
	public Version Version { get; }

	/// <summary>
	///     Compatibility level of the mod.
	/// </summary>
	public CompatibilityLevel CompatibilityLevel { get; }

	/// <summary>
	///     Version strictness level of the mod.
	/// </summary>
	public VersionStrictness VersionStrictness { get; }

	/// <summary>
	///     Whether the data layout is a legacy format or not.
	/// </summary>
	public bool IsLegacyDataLayout => false;

	public ModModule(string guid, string name, Version version, CompatibilityLevel compatibilityLevel, VersionStrictness versionStrictness)
	{
		DataLayoutVersion = 1;
		this.guid = guid;
		ModName = name;
		Version = version;
		CompatibilityLevel = compatibilityLevel;
		VersionStrictness = versionStrictness;
	}

	public ModModule(ZPackage pkg, bool legacy)
	{
		if (legacy)
		{
			DataLayoutVersion = 0;
			ModName = pkg.ReadString();
			int major = pkg.ReadInt();
			int minor = pkg.ReadInt();
			int num = pkg.ReadInt();
			Version = ((num >= 0) ? new Version(major, minor, num) : new Version(major, minor));
			CompatibilityLevel = (CompatibilityLevel)pkg.ReadInt();
			VersionStrictness = (VersionStrictness)pkg.ReadInt();
			return;
		}
		DataLayoutVersion = pkg.ReadInt();
		if (!IsSupportedDataLayout())
		{
			throw new NotSupportedException($"{DataLayoutVersion} is not a supported data layout version.");
		}
		if (DataLayoutVersion == 1)
		{
			guid = pkg.ReadString();
			ModName = pkg.ReadString();
			int major2 = pkg.ReadInt();
			int minor2 = pkg.ReadInt();
			int num2 = pkg.ReadInt();
			Version = ((num2 >= 0) ? new Version(major2, minor2, num2) : new Version(major2, minor2));
			CompatibilityLevel = (CompatibilityLevel)pkg.ReadInt();
			VersionStrictness = (VersionStrictness)pkg.ReadInt();
		}
	}

	/// <summary>
	///     Write to ZPkg
	/// </summary>
	/// <param name="pkg"></param>
	/// <param name="legacy"></param>
	public void WriteToPackage(ZPackage pkg, bool legacy)
	{
		if (legacy)
		{
			pkg.Write(ModName);
			pkg.Write(Version.Major);
			pkg.Write(Version.Minor);
			pkg.Write(Version.Build);
			pkg.Write((int)CompatibilityLevel);
			pkg.Write((int)VersionStrictness);
		}
		else
		{
			pkg.Write(DataLayoutVersion);
			pkg.Write(guid);
			pkg.Write(ModName);
			pkg.Write(Version.Major);
			pkg.Write(Version.Minor);
			pkg.Write(Version.Build);
			pkg.Write((int)CompatibilityLevel);
			pkg.Write((int)VersionStrictness);
		}
	}

	public ModModule(BepInPlugin plugin, NetworkCompatibilityAttribute networkAttribute)
	{
		DataLayoutVersion = 1;
		guid = plugin.GUID;
		ModName = plugin.Name;
		Version = plugin.Version;
		CompatibilityLevel = networkAttribute.EnforceModOnClients;
		VersionStrictness = networkAttribute.EnforceSameVersion;
	}

	public ModModule(BepInPlugin plugin)
	{
		DataLayoutVersion = 1;
		guid = plugin.GUID;
		ModName = plugin.Name;
		Version = plugin.Version;
		CompatibilityLevel = CompatibilityLevel.NotEnforced;
		VersionStrictness = VersionStrictness.None;
	}

	public string GetVersionString()
	{
		if (Version.Build >= 0)
		{
			return $"{Version.Major}.{Version.Minor}.{Version.Build}";
		}
		return $"{Version.Major}.{Version.Minor}";
	}

	/// <summary>
	///     Module must at least be loaded on the server
	/// </summary>
	/// <returns></returns>
	public bool IsNeededOnServer()
	{
		if (CompatibilityLevel != CompatibilityLevel.EveryoneMustHaveMod)
		{
			return CompatibilityLevel == CompatibilityLevel.ServerMustHaveMod;
		}
		return true;
	}

	/// <summary>
	///     Module must at least be loaded on the client
	/// </summary>
	/// <returns></returns>
	public bool IsNeededOnClient()
	{
		if (CompatibilityLevel != CompatibilityLevel.EveryoneMustHaveMod)
		{
			return CompatibilityLevel == CompatibilityLevel.ClientMustHaveMod;
		}
		return true;
	}

	/// <summary>
	///    Module is not enforced by the server or client
	/// </summary>
	/// <returns></returns>
	public bool IsNotEnforced()
	{
		if (CompatibilityLevel != CompatibilityLevel.NotEnforced)
		{
			return CompatibilityLevel == CompatibilityLevel.NoNeedForSync;
		}
		return true;
	}

	/// <summary>
	///     Module is not enforced, only version check if both client and server have it
	/// </summary>
	/// <returns></returns>
	public bool OnlyVersionCheck()
	{
		if (CompatibilityLevel != CompatibilityLevel.OnlySyncWhenInstalled)
		{
			return CompatibilityLevel == CompatibilityLevel.VersionCheckOnly;
		}
		return true;
	}

	/// <summary>
	///     Module is formatted as in one of the supported data layout versions. 
	///     Should return false is data was received from a newer version of Jotunn.
	/// </summary>
	/// <returns></returns>
	public bool IsSupportedDataLayout()
	{
		return SupportedDataLayouts.Contains(DataLayoutVersion);
	}

	/// <summary>
	///     Checks if the compare module has a lower version then the other base module
	/// </summary>
	/// <param name="baseModule"></param>
	/// <param name="compareModule"></param>
	/// <param name="strictness"></param>
	/// <returns></returns>
	public static bool IsLowerVersion(ModModule baseModule, ModModule compareModule, VersionStrictness strictness)
	{
		if (strictness == VersionStrictness.None)
		{
			return false;
		}
		bool flag = compareModule.Version.Major < baseModule.Version.Major;
		bool flag2 = compareModule.Version.Minor < baseModule.Version.Minor;
		bool flag3 = compareModule.Version.Build < baseModule.Version.Build;
		bool flag4 = compareModule.Version.Major == baseModule.Version.Major;
		bool flag5 = compareModule.Version.Minor == baseModule.Version.Minor;
		if (strictness >= VersionStrictness.Major && flag)
		{
			return true;
		}
		if (strictness >= VersionStrictness.Minor && flag2 && (flag || flag4))
		{
			return true;
		}
		if (strictness >= VersionStrictness.Patch && flag3 && (flag2 || flag5) && (flag || flag4))
		{
			return true;
		}
		return false;
	}
}
