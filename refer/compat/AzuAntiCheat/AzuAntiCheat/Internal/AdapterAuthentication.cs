using System;
using System.Globalization;
using System.Linq;

namespace AzuAnticheat.Internal;

internal class AdapterAuthentication : StrategySetter
{
	private readonly IFormatProvider procAuthentication;

	private readonly ConnectionInterpreter _RoleAttribute;

	private readonly DateTimeStyles m_PublisherAttribute;

	private readonly string[] baseAttribute;

	private static AdapterAuthentication SearchIssuer;

	public AdapterAuthentication(IFormatProvider? provider = null, ConnectionInterpreter style = (ConnectionInterpreter)0, DateTimeStyles dateStyle = DateTimeStyles.None, params string[] formats)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		procAuthentication = provider ?? CultureInfo.InvariantCulture;
		_RoleAttribute = style;
		m_PublisherAttribute = dateStyle;
		baseAttribute = formats.DefaultIfEmpty<string>(DicSingleton.gE3WbyDVW(0x940D407 ^ 0x9406073)).ToArray();
	}

	public bool Accepts(Type type)
	{
		return type == typeof(DateTimeOffset);
	}

	public object ReadYaml(CandidateInterpreter parser, Type type)
	{
		return DateTimeOffset.ParseExact(parser.Consume<BridgeSingleton>().Value, baseAttribute, procAuthentication, m_PublisherAttribute);
	}

	public void WriteYaml(MockInterpreter emitter, object? value, Type type)
	{
		int num = 1;
		int num2 = num;
		string value2 = default(string);
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		while (true)
		{
			switch (num2)
			{
			default:
				value2 = dateTimeOffset.ToString(baseAttribute.First(), procAuthentication);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				dateTimeOffset = (DateTimeOffset)value;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
				{
					num2 = 0;
				}
				break;
			case 3:
				return;
			case 2:
				emitter.Emit(new BridgeSingleton(VisitorAttribute._StubAttribute, RoleSingleton.publisherSingleton, value2, _RoleAttribute, isPlainImplicit: true, isQuotedImplicit: false));
				num2 = 3;
				break;
			}
		}
	}

	internal static bool StopIssuer()
	{
		return SearchIssuer == null;
	}

	internal static AdapterAuthentication ExcludeIssuer()
	{
		return SearchIssuer;
	}
}
