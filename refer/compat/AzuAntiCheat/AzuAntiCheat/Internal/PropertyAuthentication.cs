using System;
using System.Globalization;
using System.Linq;

namespace AzuAnticheat.Internal;

internal class PropertyAuthentication : StrategySetter
{
	private readonly DateTimeKind _ConfigurationAuthentication;

	private readonly IFormatProvider m_SpecificationAuthentication;

	private readonly bool m_RefAuthentication;

	private readonly string[] observerAuthentication;

	internal static PropertyAuthentication VisitIssuer;

	public PropertyAuthentication(DateTimeKind kind = DateTimeKind.Utc, IFormatProvider? provider = null, bool doubleQuotes = false, params string[] formats)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		_ConfigurationAuthentication = ((kind == DateTimeKind.Unspecified) ? DateTimeKind.Utc : kind);
		m_SpecificationAuthentication = provider ?? CultureInfo.InvariantCulture;
		m_RefAuthentication = doubleQuotes;
		observerAuthentication = formats.DefaultIfEmpty<string>(DicSingleton.gE3WbyDVW(0x2BC53863 ^ 0x2BC55681)).ToArray();
	}

	public bool Accepts(Type type)
	{
		return type == typeof(DateTime);
	}

	public object ReadYaml(CandidateInterpreter parser, Type type)
	{
		return EnsureDateTimeKind(DateTime.ParseExact(parser.Consume<BridgeSingleton>().Value, style: (_ConfigurationAuthentication == DateTimeKind.Local) ? DateTimeStyles.AssumeLocal : DateTimeStyles.AssumeUniversal, formats: observerAuthentication, provider: m_SpecificationAuthentication), _ConfigurationAuthentication);
	}

	public void WriteYaml(MockInterpreter emitter, object? value, Type type)
	{
		int num = 4;
		int num2 = num;
		DateTime dateTime2 = default(DateTime);
		string value2 = default(string);
		DateTime dateTime3 = default(DateTime);
		while (true)
		{
			DateTime dateTime;
			switch (num2)
			{
			case 1:
				dateTime = dateTime2.ToUniversalTime();
				goto IL_00a9;
			case 3:
				if (_ConfigurationAuthentication != DateTimeKind.Local)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 == 0)
					{
						num2 = 1;
					}
					break;
				}
				dateTime = dateTime2.ToLocalTime();
				goto IL_00a9;
			case 4:
				dateTime2 = (DateTime)value;
				num2 = 3;
				break;
			case 5:
				return;
			default:
				value2 = dateTime3.ToString(observerAuthentication.First(), m_SpecificationAuthentication);
				num2 = 2;
				break;
			case 2:
				{
					emitter.Emit(new BridgeSingleton(VisitorAttribute._StubAttribute, RoleSingleton.publisherSingleton, value2, m_RefAuthentication ? ((ConnectionInterpreter)3) : ((ConnectionInterpreter)0), isPlainImplicit: true, isQuotedImplicit: false));
					num2 = 5;
					break;
				}
				IL_00a9:
				dateTime3 = dateTime;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f != 0)
				{
					num2 = 0;
				}
				break;
			}
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
			case 3:
				return dt.ToUniversalTime();
			case 4:
				if (kind == DateTimeKind.Local)
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c == 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			case 1:
				if (dt.Kind == DateTimeKind.Local)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 != 0)
					{
						num2 = 0;
					}
					continue;
				}
				goto IL_0038;
			default:
				if (kind == DateTimeKind.Utc)
				{
					num2 = 3;
					continue;
				}
				goto IL_0038;
			case 2:
				{
					return dt.ToLocalTime();
				}
				IL_0038:
				if (dt.Kind == DateTimeKind.Utc)
				{
					num2 = 4;
					continue;
				}
				break;
			}
			break;
		}
		return dt;
	}

	internal static bool OrderIssuer()
	{
		return VisitIssuer == null;
	}

	internal static PropertyAuthentication UpdateIssuer()
	{
		return VisitIssuer;
	}
}
