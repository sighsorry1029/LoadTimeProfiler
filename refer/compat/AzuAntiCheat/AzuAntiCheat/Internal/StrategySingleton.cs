using System;
using System.Reflection;

namespace AzuAnticheat.Internal;

internal class StrategySingleton
{
	internal delegate void InfoSingleton(object o);

	internal static Module m_ProcessorSingleton;

	private static StrategySingleton CustomizeGetter;

	internal static void ExcludeInitializer(int typemdt)
	{
		int num = 9;
		MethodInfo method = default(MethodInfo);
		FieldInfo fieldInfo = default(FieldInfo);
		Type type = default(Type);
		int num3 = default(int);
		FieldInfo[] fields = default(FieldInfo[]);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 5:
					method = (MethodInfo)m_ProcessorSingleton.ResolveMethod(fieldInfo.MetadataToken + 100663296);
					num2 = 5;
					if (ReflectGetter() == null)
					{
						num2 = 6;
					}
					continue;
				case 9:
					type = m_ProcessorSingleton.ResolveType(33554432 + typemdt);
					num2 = 8;
					if (!CancelGetter())
					{
						num2 = 3;
					}
					continue;
				case 1:
				case 3:
					break;
				case 4:
					num3 = 0;
					num2 = 4;
					if (ReflectGetter() == null)
					{
						num2 = 10;
					}
					continue;
				default:
					if (num3 < fields.Length)
					{
						num2 = 0;
						if (CancelGetter())
						{
							num2 = 1;
						}
						continue;
					}
					return;
				case 8:
					fields = type.GetFields();
					num2 = 4;
					continue;
				case 2:
					return;
				case 7:
					num3++;
					num2 = 0;
					if (ReflectGetter() == null)
					{
						num2 = 0;
					}
					continue;
				case 6:
					fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
					num2 = 7;
					continue;
				}
				break;
			}
			fieldInfo = fields[num3];
			num = 5;
		}
	}

	public StrategySingleton()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (1 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	static StrategySingleton()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			case 1:
				GetterIssuer.DeleteInitializer();
				num2 = 0;
				if (false)
				{
					num2 = 0;
				}
				break;
			default:
				m_ProcessorSingleton = typeof(StrategySingleton).Assembly.ManifestModule;
				num2 = 2;
				if (1 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool CancelGetter()
	{
		return CustomizeGetter == null;
	}

	internal static StrategySingleton ReflectGetter()
	{
		return CustomizeGetter;
	}
}
