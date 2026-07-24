using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Permissions;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal static class ContainerInterceptor
{
	private static ContainerInterceptor InitUtils;

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)]
	public static T ChangeType<T>(object value)
	{
		return (T)ChangeType(value, typeof(T));
	}

	public static T ChangeType<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] T>([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object value, IFormatProvider provider)
	{
		return (T)ChangeType(value, typeof(T), provider);
	}

	public static T ChangeType<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] T>([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object value, CultureInfo culture)
	{
		return (T)ChangeType(value, typeof(T), culture);
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	public static object ChangeType(object value, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)] Type destinationType)
	{
		return ChangeType(value, destinationType, CultureInfo.InvariantCulture);
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public static object ChangeType([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object value, Type destinationType, IFormatProvider provider)
	{
		return ChangeType(value, destinationType, new ListBase(CultureInfo.CurrentCulture, provider));
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public static object ChangeType([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object value, Type destinationType, CultureInfo culture)
	{
		int num = 30;
		IEnumerator<MethodInfo> enumerator = default(IEnumerator<MethodInfo>);
		MethodInfo current = default(MethodInfo);
		ParameterInfo[] parameters = default(ParameterInfo[]);
		object result = default(object);
		Type type = default(Type);
		Type destinationType2 = default(Type);
		TypeConverter converter = default(TypeConverter);
		string text = default(string);
		int num3 = default(int);
		Type[] array = default(Type[]);
		TypeConverter converter2 = default(TypeConverter);
		object obj = default(object);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 13:
					try
					{
						while (true)
						{
							int num4;
							if (!enumerator.MoveNext())
							{
								num4 = 9;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 == 0)
								{
									num4 = 2;
								}
								goto IL_0107;
							}
							goto IL_0258;
							IL_0258:
							current = enumerator.Current;
							num4 = 3;
							goto IL_0107;
							IL_0107:
							while (true)
							{
								int num5;
								switch (num4)
								{
								case 1:
									parameters = current.GetParameters();
									num5 = 8;
									goto IL_0103;
								case 10:
									try
									{
										result = current.Invoke(null, new object[1] { value });
										int num6 = 0;
										if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb == 0)
										{
											num6 = 0;
										}
										switch (num6)
										{
										case 0:
											break;
										}
									}
									catch (TargetInvocationException ex)
									{
										throw CollectionBase.Unwrap(ex);
									}
									goto IL_071c;
								case 2:
									if (current.Name == DicSingleton.gE3WbyDVW(-1273961441 ^ -1273985253))
									{
										num4 = 1;
										if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec != 0)
										{
											num4 = 12;
										}
										continue;
									}
									goto case 5;
								case 6:
								case 11:
									break;
								case 3:
									if (!current.IsSpecialName)
									{
										num4 = 6;
										continue;
									}
									goto case 2;
								case 4:
									if (parameters[0].ParameterType.IsAssignableFrom(type))
									{
										num4 = 10;
										continue;
									}
									break;
								case 7:
									goto IL_0258;
								case 5:
									if (current.Name == DicSingleton.gE3WbyDVW(-525002617 ^ -524977255))
									{
										num4 = 0;
										if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
										{
											num4 = 0;
										}
										continue;
									}
									break;
								default:
									if (destinationType.IsAssignableFrom(current.ReturnParameter.ParameterType))
									{
										num4 = 0;
										if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 != 0)
										{
											num4 = 1;
										}
										continue;
									}
									break;
								case 8:
									if (parameters.Length != 1)
									{
										break;
									}
									num5 = 4;
									goto IL_0103;
								case 9:
									goto end_IL_0202;
									IL_0103:
									num4 = num5;
									continue;
								}
								break;
							}
							continue;
							end_IL_0202:
							break;
						}
					}
					finally
					{
						if (enumerator != null)
						{
							int num7 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba != 0)
							{
								num7 = 0;
							}
							while (true)
							{
								switch (num7)
								{
								case 1:
									enumerator.Dispose();
									num7 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
									{
										num7 = 0;
									}
									continue;
								case 0:
									break;
								}
								break;
							}
						}
					}
					goto case 40;
				case 3:
				case 34:
					return value;
				case 38:
					if (!CollectionBase.IsGenericType(destinationType))
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
						{
							num2 = 9;
						}
						continue;
					}
					goto case 15;
				case 28:
					destinationType2 = destinationType.GetGenericArguments()[0];
					num2 = 16;
					continue;
				case 35:
					return null;
				case 4:
					return Activator.CreateInstance(destinationType);
				case 18:
					type = value.GetType();
					num2 = 10;
					continue;
				default:
					if (!converter.CanConvertTo(destinationType))
					{
						num2 = 14;
						continue;
					}
					goto case 31;
				case 25:
					return value;
				case 33:
					return Enum.Parse(destinationType, text, ignoreCase: true);
				case 5:
					if (destinationType == typeof(bool))
					{
						num2 = 11;
						continue;
					}
					goto case 26;
				case 24:
				case 45:
					if (num3 < array.Length)
					{
						num2 = 17;
						continue;
					}
					goto case 42;
				case 43:
					if (converter2 == null)
					{
						num2 = 2;
						continue;
					}
					goto case 27;
				case 10:
					if (destinationType == type)
					{
						num2 = 34;
						continue;
					}
					goto case 6;
				case 23:
					return Activator.CreateInstance(destinationType, obj);
				case 9:
				case 39:
					if (!CollectionBase.IsEnum(destinationType))
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 != 0)
						{
							num2 = 5;
						}
						continue;
					}
					goto case 41;
				case 15:
					if (!(destinationType.GetGenericTypeDefinition() == typeof(Nullable<>)))
					{
						num2 = 39;
						continue;
					}
					goto case 28;
				case 29:
					if (!CollectionBase.IsDbNull(value))
					{
						num2 = 18;
						continue;
					}
					goto case 1;
				case 1:
					if (CollectionBase.IsValueType(destinationType))
					{
						num2 = 4;
						continue;
					}
					goto case 35;
				case 12:
				case 17:
					enumerator = CollectionBase.GetPublicStaticMethods(array[num3]).GetEnumerator();
					num = 13;
					break;
				case 8:
					return converter2.ConvertFrom(null, culture, value);
				case 2:
				case 20:
					array = new Type[2] { type, destinationType };
					num2 = 22;
					continue;
				case 19:
					if (converter != null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 14;
				case 16:
					obj = ChangeType(value, destinationType2, culture);
					num2 = 23;
					continue;
				case 41:
					text = value as string;
					num2 = 36;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd != 0)
					{
						num2 = 8;
					}
					continue;
				case 7:
					if (destinationType == typeof(TimeSpan))
					{
						num2 = 44;
						continue;
					}
					return Convert.ChangeType(value, destinationType, CultureInfo.InvariantCulture);
				case 27:
					if (!converter2.CanConvertFrom(type))
					{
						num2 = 20;
						continue;
					}
					goto case 8;
				case 22:
					num3 = 0;
					num2 = 24;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 != 0)
					{
						num2 = 12;
					}
					continue;
				case 21:
					return false;
				case 6:
					if (!destinationType.IsAssignableFrom(type))
					{
						num = 38;
						break;
					}
					goto case 3;
				case 37:
					return true;
				case 26:
					converter = TypeDescriptor.GetConverter(type);
					num2 = 19;
					continue;
				case 44:
					return TimeSpan.Parse((string)ChangeType(value, typeof(string), CultureInfo.InvariantCulture));
				case 36:
					if (text != null)
					{
						num2 = 33;
						continue;
					}
					goto case 25;
				case 30:
					if (value != null)
					{
						num2 = 12;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 != 0)
						{
							num2 = 29;
						}
						continue;
					}
					goto case 1;
				case 32:
					try
					{
						MethodInfo publicStaticMethod = CollectionBase.GetPublicStaticMethod(destinationType, DicSingleton.gE3WbyDVW(0x1C9EFC64 ^ 0x1C9E9F5C), typeof(string), typeof(IFormatProvider));
						int num8 = 8;
						while (true)
						{
							switch (num8)
							{
							case 1:
							case 5:
								break;
							default:
								publicStaticMethod = CollectionBase.GetPublicStaticMethod(destinationType, DicSingleton.gE3WbyDVW(-1053593978 ^ -1053618754), typeof(string));
								num8 = 6;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
								{
									num8 = 1;
								}
								continue;
							case 4:
								goto end_IL_0770;
							case 6:
								if (!(publicStaticMethod != null))
								{
									num8 = 4;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b != 0)
									{
										num8 = 0;
									}
									continue;
								}
								goto case 3;
							case 3:
								result = publicStaticMethod.Invoke(null, new object[1] { value });
								num8 = 5;
								continue;
							case 8:
								if (publicStaticMethod != null)
								{
									num8 = 7;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
									{
										num8 = 0;
									}
									continue;
								}
								goto default;
							case 7:
								result = publicStaticMethod.Invoke(null, new object[2] { value, culture });
								num8 = 1;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
								{
									num8 = 0;
								}
								continue;
							case 2:
								goto end_IL_0770;
							}
							break;
						}
						goto IL_071c;
						end_IL_0770:;
					}
					catch (TargetInvocationException ex2)
					{
						throw CollectionBase.Unwrap(ex2);
					}
					goto case 7;
				case 11:
					if (!DicSingleton.gE3WbyDVW(0x4E8C8248 ^ 0x4E8CA55A).Equals(value))
					{
						if (!DicSingleton.gE3WbyDVW(--1844849127 ^ 0x6DF64B19).Equals(value))
						{
							num2 = 16;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
							{
								num2 = 26;
							}
							continue;
						}
						goto case 37;
					}
					num2 = 21;
					continue;
				case 42:
					if (type == typeof(string))
					{
						num2 = 32;
						continue;
					}
					goto case 7;
				case 31:
					return converter.ConvertTo(null, culture, value, destinationType);
				case 14:
					converter2 = TypeDescriptor.GetConverter(destinationType);
					num2 = 43;
					continue;
				case 40:
					{
						num3++;
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
						{
							num2 = 45;
						}
						continue;
					}
					IL_071c:
					return result;
				}
				break;
			}
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)]
	[PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
	public static void RegisterTypeConverter<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TConvertible, TConverter>() where TConverter : TypeConverter
	{
		if (!TypeDescriptor.GetAttributes(typeof(TConvertible)).OfType<TypeConverterAttribute>().Any([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (TypeConverterAttribute a) => a.ConverterTypeName == typeof(TConverter).AssemblyQualifiedName))
		{
			TypeDescriptor.AddAttributes(typeof(TConvertible), new TypeConverterAttribute(typeof(TConverter)));
		}
	}

	internal static bool PatchUtils()
	{
		return InitUtils == null;
	}

	internal static ContainerInterceptor AssetUtils()
	{
		return InitUtils;
	}
}
