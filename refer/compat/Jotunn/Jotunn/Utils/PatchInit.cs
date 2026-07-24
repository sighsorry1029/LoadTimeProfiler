using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BepInEx;

namespace Jotunn.Utils;

internal class PatchInit
{
	/// <summary>
	///     Invoke patch initialization methods for all loaded mods.
	/// </summary>
	[Obsolete]
	internal static void InitializePatches()
	{
		List<Tuple<MethodInfo, int>> list = new List<Tuple<MethodInfo, int>>();
		HashSet<Assembly> hashSet = new HashSet<Assembly>();
		foreach (BaseUnityPlugin value in BepInExUtils.GetDependentPlugins().Values)
		{
			try
			{
				Assembly assembly = value.GetType().Assembly;
				if (hashSet.Contains(assembly))
				{
					continue;
				}
				hashSet.Add(assembly);
				Type[] types = assembly.GetTypes();
				foreach (Type type in types)
				{
					try
					{
						foreach (MethodInfo item in from x in type.GetMethods(BindingFlags.Static | BindingFlags.Public)
							where x.GetCustomAttributes(typeof(PatchInitAttribute), inherit: false).Length == 1
							select x)
						{
							PatchInitAttribute patchInitAttribute = item.GetCustomAttributes(typeof(PatchInitAttribute), inherit: false).FirstOrDefault() as PatchInitAttribute;
							list.Add(new Tuple<MethodInfo, int>(item, patchInitAttribute.Priority));
						}
					}
					catch (Exception)
					{
					}
				}
			}
			catch (Exception)
			{
			}
		}
		foreach (Tuple<MethodInfo, int> item2 in list.OrderBy((Tuple<MethodInfo, int> x) => x.Item2))
		{
			Logger.LogDebug("Applying patches in " + item2.Item1.DeclaringType.Name + "." + item2.Item1.Name);
			item2.Item1.Invoke(null, null);
		}
	}
}
