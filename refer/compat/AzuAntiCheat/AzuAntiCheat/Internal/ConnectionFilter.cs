using System;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal class ConnectionFilter : StatusPrototype
{
	private readonly DateTimeKind _AnnotationFilter;

	private readonly IFormatProvider _ProcessFilter;

	private readonly string[] m_RepositoryFilter;

	internal static ConnectionFilter ExcludeAnnotation;

	public ConnectionFilter(DateTimeKind kind = DateTimeKind.Utc, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] IFormatProvider provider = null, params string[] formats)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 3;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
		{
			num = 2;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			case 2:
				m_RepositoryFilter = formats.DefaultIfEmpty(DicSingleton.gE3WbyDVW(-34102588 ^ -34091994)).ToArray();
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
				{
					num = 1;
				}
				break;
			case 3:
				_AnnotationFilter = ((kind == DateTimeKind.Unspecified) ? DateTimeKind.Utc : kind);
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
				{
					num = 0;
				}
				break;
			default:
				_ProcessFilter = provider ?? CultureInfo.InvariantCulture;
				num = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b != 0)
				{
					num = 1;
				}
				break;
			}
		}
	}

	public bool Accepts(Type type)
	{
		return type == typeof(DateTime);
	}

	public object ReadYaml(StubReader parser, Type type)
	{
		return EnsureDateTimeKind(DateTime.ParseExact(parser.Consume<ClassFactory>().Value, style: (_AnnotationFilter == DateTimeKind.Local) ? DateTimeStyles.AssumeLocal : DateTimeStyles.AssumeUniversal, formats: m_RepositoryFilter, provider: _ProcessFilter), _AnnotationFilter);
	}

	public void WriteYaml(ModelReader emitter, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object value, Type type)
	{
		int num = 1;
		DateTime dateTime = default(DateTime);
		string value2 = default(string);
		DateTime dateTime3 = default(DateTime);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				DateTime dateTime2;
				switch (num2)
				{
				default:
					if (_AnnotationFilter != DateTimeKind.Local)
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
						{
							num2 = 1;
						}
						continue;
					}
					dateTime2 = dateTime.ToLocalTime();
					break;
				case 5:
					emitter.Emit(new ClassFactory(HelperReader._ExceptionReader, ValueFactory._DecoratorFactory, value2, (RuleFactory)0, isPlainImplicit: true, isQuotedImplicit: false));
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 != 0)
					{
						num2 = 2;
					}
					continue;
				case 2:
					return;
				case 4:
					goto end_IL_0012;
				case 3:
					dateTime2 = dateTime.ToUniversalTime();
					break;
				case 1:
					dateTime = (DateTime)value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 != 0)
					{
						num2 = 0;
					}
					continue;
				}
				dateTime3 = dateTime2;
				num2 = 4;
				continue;
				end_IL_0012:
				break;
			}
			value2 = dateTime3.ToString(m_RepositoryFilter.First(), _ProcessFilter);
			num = 5;
		}
	}

	private static DateTime EnsureDateTimeKind(DateTime dt, DateTimeKind kind)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				if (kind == DateTimeKind.Utc)
				{
					num2 = 4;
					break;
				}
				goto IL_007a;
			case 1:
				if (dt.Kind == DateTimeKind.Local)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto IL_007a;
			case 3:
				return dt.ToLocalTime();
			case 4:
				return dt.ToUniversalTime();
			case 2:
				{
					if (kind == DateTimeKind.Local)
					{
						num2 = 3;
						break;
					}
					goto IL_0070;
				}
				IL_0070:
				return dt;
				IL_007a:
				if (dt.Kind == DateTimeKind.Utc)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
					{
						num2 = 2;
					}
					break;
				}
				goto IL_0070;
			}
		}
	}

	internal static bool InterruptAnnotation()
	{
		return ExcludeAnnotation == null;
	}

	internal static ConnectionFilter DeleteAnnotation()
	{
		return ExcludeAnnotation;
	}
}
