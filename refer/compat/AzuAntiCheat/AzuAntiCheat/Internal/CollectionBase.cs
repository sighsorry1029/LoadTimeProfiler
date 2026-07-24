using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal static class CollectionBase
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public BindingFlags m_TokenizerBase;

		internal static _003C_003Ec__DisplayClass11_0 ForgotSingleton;

		public _003C_003Ec__DisplayClass11_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)]
		internal IEnumerable<PropertyInfo> _003CGetProperties_003Eb__0(Type i)
		{
			return i.GetProperties(m_TokenizerBase);
		}

		internal static bool RestartSingleton()
		{
			return ForgotSingleton == null;
		}

		internal static _003C_003Ec__DisplayClass11_0 GetSingleton()
		{
			return ForgotSingleton;
		}
	}

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	private static readonly FieldInfo managerBase;

	private static CollectionBase ReflectSingleton;

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public static Type BaseType(this Type type)
	{
		return type.BaseType;
	}

	public static bool IsValueType(this Type type)
	{
		return type.IsValueType;
	}

	public static bool IsGenericType(this Type type)
	{
		return type.IsGenericType;
	}

	public static bool IsGenericTypeDefinition(this Type type)
	{
		return type.IsGenericTypeDefinition;
	}

	public static bool IsInterface(this Type type)
	{
		return type.IsInterface;
	}

	public static bool IsEnum(this Type type)
	{
		return type.IsEnum;
	}

	public static bool IsDbNull(this object value)
	{
		return value is DBNull;
	}

	public static bool HasDefaultConstructor(this Type type)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (type.IsValueType)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			case 2:
				return type.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, Type.EmptyTypes, null) != null;
			default:
				return true;
			}
		}
	}

	public static TypeCode GetTypeCode(this Type type)
	{
		return Type.GetTypeCode(type);
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public static PropertyInfo GetPublicProperty(this Type type, string name)
	{
		return type.GetProperty(name);
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public static FieldInfo GetPublicStaticField(this Type type, string name)
	{
		return type.GetField(name, BindingFlags.Static | BindingFlags.Public);
	}

	public static IEnumerable<PropertyInfo> GetProperties(this Type type, bool includeNonPublic)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals4.m_TokenizerBase = BindingFlags.Instance | BindingFlags.Public;
		if (includeNonPublic)
		{
			CS_0024_003C_003E8__locals4.m_TokenizerBase |= BindingFlags.NonPublic;
		}
		if (!type.IsInterface)
		{
			return type.GetProperties(CS_0024_003C_003E8__locals4.m_TokenizerBase);
		}
		return new Type[1] { type }.Concat(type.GetInterfaces()).SelectMany([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (Type i) => i.GetProperties(CS_0024_003C_003E8__locals4.m_TokenizerBase));
	}

	public static IEnumerable<PropertyInfo> GetPublicProperties(this Type type)
	{
		return GetProperties(type, includeNonPublic: false);
	}

	public static IEnumerable<FieldInfo> GetPublicFields(this Type type)
	{
		return type.GetFields(BindingFlags.Instance | BindingFlags.Public);
	}

	public static IEnumerable<MethodInfo> GetPublicStaticMethods(this Type type)
	{
		return type.GetMethods(BindingFlags.Static | BindingFlags.Public);
	}

	public static MethodInfo GetPrivateStaticMethod(this Type type, string name)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
			{
				MethodInfo method = type.GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic);
				if ((object)method == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
					{
						num2 = 0;
					}
					break;
				}
				return method;
			}
			default:
				throw new MissingMethodException(DicSingleton.gE3WbyDVW(-428135557 ^ -428113995) + name + DicSingleton.gE3WbyDVW(-1064640644 ^ -1064662424) + type.FullName + DicSingleton.gE3WbyDVW(0x4C23C86A ^ 0x4C239D4E));
			}
		}
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public static MethodInfo GetPublicStaticMethod(this Type type, string name, params Type[] parameterTypes)
	{
		return type.GetMethod(name, BindingFlags.Static | BindingFlags.Public, null, parameterTypes, null);
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public static MethodInfo GetPublicInstanceMethod(this Type type, string name)
	{
		return type.GetMethod(name, BindingFlags.Instance | BindingFlags.Public);
	}

	public static Exception Unwrap(this TargetInvocationException ex)
	{
		int num = 4;
		int num2 = num;
		Exception innerException = default(Exception);
		while (true)
		{
			switch (num2)
			{
			case 4:
				innerException = ex.InnerException;
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
				{
					num2 = 0;
				}
				break;
			default:
				return innerException;
			case 5:
				return ex;
			case 1:
				managerBase.SetValue(innerException, innerException.StackTrace + DicSingleton.gE3WbyDVW(0x2BC53863 ^ 0x2BC56D4F));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
				{
					num2 = 0;
				}
				break;
			case 3:
				if (innerException != null)
				{
					if (!(managerBase != null))
					{
						num2 = 2;
						break;
					}
					goto case 1;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
				{
					num2 = 5;
				}
				break;
			}
		}
	}

	public static bool IsInstanceOf(this Type type, object o)
	{
		return type.IsInstanceOfType(o);
	}

	public static Attribute[] GetAllCustomAttributes<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TAttribute>(this PropertyInfo property)
	{
		return Attribute.GetCustomAttributes(property, typeof(TAttribute));
	}

	static CollectionBase()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				GetterIssuer.DeleteInitializer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a != 0)
				{
					num2 = 0;
				}
				break;
			default:
				managerBase = typeof(Exception).GetField(DicSingleton.gE3WbyDVW(0x7FAAD78F ^ 0x7FAA82BB), BindingFlags.Instance | BindingFlags.NonPublic);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				return;
			}
		}
	}

	internal static bool CollectSingleton()
	{
		return ReflectSingleton == null;
	}

	internal static CollectionBase ManageSingleton()
	{
		return ReflectSingleton;
	}
}
