using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal static class InterceptorSetter
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public BindingFlags readerSetter;

		internal static _003C_003Ec__DisplayClass11_0 RestartObject;

		public _003C_003Ec__DisplayClass11_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal IEnumerable<PropertyInfo> _003CGetProperties_003Eb__0(Type i)
		{
			return i.GetProperties(readerSetter);
		}

		internal static bool GetObject()
		{
			return RestartObject == null;
		}

		internal static _003C_003Ec__DisplayClass11_0 CalculateObject()
		{
			return RestartObject;
		}
	}

	private static readonly FieldInfo? m_FilterSetter;

	internal static InterceptorSetter CollectObject;

	public static Type? BaseType(this Type type)
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

	public static bool HasDefaultConstructor(this Type type, bool allowPrivateConstructors)
	{
		int num = 3;
		BindingFlags bindingFlags = default(BindingFlags);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 2:
					if (allowPrivateConstructors)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 != 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 1;
				case 4:
					return type.GetConstructor(bindingFlags, null, Type.EmptyTypes, null) != null;
				default:
					bindingFlags |= BindingFlags.NonPublic;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd != 0)
					{
						num2 = 1;
					}
					break;
				case 1:
					if (type.IsValueType)
					{
						return true;
					}
					goto end_IL_0012;
				case 3:
					bindingFlags = BindingFlags.Instance | BindingFlags.Public;
					num2 = 2;
					break;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 4;
		}
	}

	public static TypeCode GetTypeCode(this Type type)
	{
		return Type.GetTypeCode(type);
	}

	public static PropertyInfo? GetPublicProperty(this Type type, string name)
	{
		return type.GetProperty(name);
	}

	public static FieldInfo? GetPublicStaticField(this Type type, string name)
	{
		return type.GetField(name, BindingFlags.Static | BindingFlags.Public);
	}

	public static IEnumerable<PropertyInfo> GetProperties(this Type type, bool includeNonPublic)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals4.readerSetter = BindingFlags.Instance | BindingFlags.Public;
		if (includeNonPublic)
		{
			CS_0024_003C_003E8__locals4.readerSetter |= BindingFlags.NonPublic;
		}
		if (!type.IsInterface)
		{
			return type.GetProperties(CS_0024_003C_003E8__locals4.readerSetter);
		}
		return new Type[1] { type }.Concat(type.GetInterfaces()).SelectMany((Type i) => i.GetProperties(CS_0024_003C_003E8__locals4.readerSetter));
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
				if ((object)method != null)
				{
					return method;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
				{
					num2 = 0;
				}
				break;
			}
			default:
				throw new MissingMethodException(DicSingleton.gE3WbyDVW(-1931860206 ^ -1931840548) + name + DicSingleton.gE3WbyDVW(0x1C9EFC64 ^ 0x1C9EA970) + type.FullName + DicSingleton.gE3WbyDVW(-1180565667 ^ -1180587399));
			}
		}
	}

	public static MethodInfo? GetPublicStaticMethod(this Type type, string name, params Type[] parameterTypes)
	{
		return type.GetMethod(name, BindingFlags.Static | BindingFlags.Public, null, parameterTypes, null);
	}

	public static MethodInfo? GetPublicInstanceMethod(this Type type, string name)
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
			case 3:
				if (innerException != null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
					{
						num2 = 2;
					}
					break;
				}
				goto case 1;
			case 4:
				innerException = ex.InnerException;
				num2 = 3;
				break;
			default:
				m_FilterSetter.SetValue(innerException, innerException.StackTrace + DicSingleton.gE3WbyDVW(0x940D407 ^ 0x940812B));
				num2 = 5;
				break;
			case 5:
				return innerException;
			case 1:
				return ex;
			case 2:
				if (m_FilterSetter != null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 5;
			}
		}
	}

	public static bool IsInstanceOf(this Type type, object o)
	{
		return type.IsInstanceOfType(o);
	}

	public static Attribute[] GetAllCustomAttributes<TAttribute>(this PropertyInfo property)
	{
		return Attribute.GetCustomAttributes(property, typeof(TAttribute), inherit: true);
	}

	static InterceptorSetter()
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				m_FilterSetter = typeof(Exception).GetField(DicSingleton.gE3WbyDVW(-948533799 ^ -948514579), BindingFlags.Instance | BindingFlags.NonPublic);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
				{
					num2 = 2;
				}
				break;
			case 2:
				return;
			}
		}
	}

	internal static bool ManageObject()
	{
		return CollectObject == null;
	}

	internal static InterceptorSetter ForgotObject()
	{
		return CollectObject;
	}
}
