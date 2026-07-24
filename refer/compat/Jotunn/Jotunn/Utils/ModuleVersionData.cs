using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jotunn.Utils;

/// <summary>
///     Deserialize version string into a usable format.
/// </summary>
internal class ModuleVersionData
{
	/// <summary>
	///     Valheim version
	/// </summary>
	public Version ValheimVersion { get; internal set; }

	/// <summary>
	///     Module data
	/// </summary>
	public List<ModModule> Modules { get; internal set; } = new List<ModModule>();

	public string VersionString { get; internal set; } = string.Empty;

	public uint NetworkVersion { get; internal set; }

	public int ModModuleDataLayout { get; private set; }

	/// <summary>
	///     Whether all the ModModule instances were formatted in a supported 
	///     data layout and all instances had the same data layout. 
	/// </summary>
	public bool IsSupportedDataLayout => ModModule.SupportedDataLayouts.Contains(ModModuleDataLayout);

	/// <summary>
	///     Create from module data
	/// </summary>
	/// <param name="versionData"></param>
	internal ModuleVersionData(List<ModModule> versionData)
	{
		ValheimVersion = GameVersions.ValheimVersion;
		VersionString = GetVersionString();
		NetworkVersion = GameVersions.NetworkVersion;
		Modules = new List<ModModule>(versionData);
		ModModuleDataLayout = GetModModuleDataLayoutVersion(Modules);
	}

	internal ModuleVersionData(Version valheimVersion, List<ModModule> versionData)
	{
		ValheimVersion = valheimVersion;
		VersionString = GetVersionString();
		NetworkVersion = GameVersions.NetworkVersion;
		Modules = new List<ModModule>(versionData);
		ModModuleDataLayout = GetModModuleDataLayoutVersion(Modules);
	}

	/// <summary>
	///     Create from ZPackage
	/// </summary>
	/// <param name="pkg"></param>
	internal ModuleVersionData(ZPackage pkg)
	{
		try
		{
			pkg.SetPos(0);
			ValheimVersion = new Version(pkg.ReadInt(), pkg.ReadInt(), pkg.ReadInt());
			for (int num = pkg.ReadInt(); num > 0; num--)
			{
				Modules.Add(new ModModule(pkg, legacy: true));
			}
			if (pkg.m_reader.BaseStream.Position != pkg.m_reader.BaseStream.Length)
			{
				VersionString = pkg.ReadString();
			}
			if (pkg.m_reader.BaseStream.Position != pkg.m_reader.BaseStream.Length)
			{
				NetworkVersion = pkg.ReadUInt();
			}
			if (pkg.m_reader.BaseStream.Position == pkg.m_reader.BaseStream.Length)
			{
				return;
			}
			List<ModModule> list = new List<ModModule>();
			int num2 = pkg.ReadInt();
			int pos = pkg.GetPos();
			while (num2 > 0)
			{
				try
				{
					ModModule item = new ModModule(pkg, legacy: false);
					list.Add(item);
					num2--;
				}
				catch (NotSupportedException ex)
				{
					pkg.SetPos(pos);
					ModModuleDataLayout = pkg.ReadInt();
					Logger.LogError($"Could not parse unsupported data layout version {ModModuleDataLayout} from zPackage");
					Logger.LogError(ex.Message);
					break;
				}
			}
			Modules = list;
			ModModuleDataLayout = GetModModuleDataLayoutVersion(Modules);
		}
		catch (Exception ex2)
		{
			Logger.LogError("Could not deserialize version message data from zPackage");
			Logger.LogError(ex2.Message);
		}
	}

	/// <summary>
	///     Create ZPackage
	/// </summary>
	/// <returns>ZPackage</returns>
	public ZPackage ToZPackage()
	{
		ZPackage zPackage = new ZPackage();
		zPackage.Write(ValheimVersion.Major);
		zPackage.Write(ValheimVersion.Minor);
		zPackage.Write(ValheimVersion.Build);
		zPackage.Write(Modules.Count);
		foreach (ModModule module in Modules)
		{
			module.WriteToPackage(zPackage, legacy: true);
		}
		zPackage.Write(VersionString);
		zPackage.Write(NetworkVersion);
		zPackage.Write(Modules.Count);
		foreach (ModModule module2 in Modules)
		{
			module2.WriteToPackage(zPackage, legacy: false);
		}
		return zPackage;
	}

	/// <inheritdoc />
	public override int GetHashCode()
	{
		return (((ValheimVersion != null) ? ValheimVersion.GetHashCode() : 0) * 397) ^ ((Modules != null) ? Modules.GetHashCode() : 0);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (string.IsNullOrEmpty(VersionString))
		{
			stringBuilder.AppendLine($"Valheim {ValheimVersion.Major}.{ValheimVersion.Minor}.{ValheimVersion.Build}");
		}
		else
		{
			stringBuilder.AppendLine("Valheim " + VersionString);
		}
		foreach (ModModule module in Modules)
		{
			stringBuilder.AppendLine($"{module.ModName} {module.GetVersionString()} {module.CompatibilityLevel} {module.VersionStrictness}");
		}
		return stringBuilder.ToString();
	}

	public string ToString(bool showEnforce)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string text = VersionString;
		if (string.IsNullOrEmpty(text))
		{
			text = $"Valheim {ValheimVersion.Major}.{ValheimVersion.Minor}.{ValheimVersion.Build}";
		}
		if (NetworkVersion != 0)
		{
			stringBuilder.AppendLine($"Valheim {text} (n-{NetworkVersion})");
		}
		else
		{
			stringBuilder.AppendLine("Valheim " + text);
		}
		foreach (ModModule module in Modules)
		{
			stringBuilder.AppendLine(module.ModName + " " + module.GetVersionString() + (showEnforce ? $" {module.CompatibilityLevel} {module.VersionStrictness}" : ""));
		}
		return stringBuilder.ToString();
	}

	public ModModule FindModule(ModModule modModule, bool legacyDataLayout)
	{
		if (legacyDataLayout)
		{
			return Modules.FirstOrDefault((ModModule x) => x.ModName == modModule.ModName);
		}
		return Modules.FirstOrDefault((ModModule x) => x.ModID == modModule.ModID);
	}

	public bool HasModule(ModModule modModule, bool legacyDataLayout)
	{
		return FindModule(modModule, legacyDataLayout) != null;
	}

	private static string GetVersionString()
	{
		return global::Version.GetVersionString().Replace("-ServerCharacters", "");
	}

	private static int GetModModuleDataLayoutVersion(List<ModModule> modules)
	{
		if (modules.Any((ModModule x) => x.DataLayoutVersion != modules.FirstOrDefault()?.DataLayoutVersion))
		{
			throw new NotSupportedException("DataVersionLayout is not the same for all ModModule instances.");
		}
		return modules.FirstOrDefault()?.DataLayoutVersion ?? 1;
	}
}
