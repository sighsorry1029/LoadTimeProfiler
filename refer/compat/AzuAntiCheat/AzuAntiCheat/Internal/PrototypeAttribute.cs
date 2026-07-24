using System;

namespace AzuAnticheat.Internal;

internal class PrototypeAttribute : StrategySetter
{
	private readonly bool m_InterceptorAttribute;

	private static PrototypeAttribute InterruptIssuer;

	public PrototypeAttribute(bool jsonCompatible)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 0:
				return;
			case 1:
				m_InterceptorAttribute = jsonCompatible;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public bool Accepts(Type type)
	{
		return type == typeof(Guid);
	}

	public object ReadYaml(CandidateInterpreter parser, Type type)
	{
		return new Guid(parser.Consume<BridgeSingleton>().Value);
	}

	public void WriteYaml(MockInterpreter emitter, object? value, Type type)
	{
		int num = 1;
		int num2 = num;
		Guid guid = default(Guid);
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			case 1:
				guid = (Guid)value;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				emitter.Emit(new BridgeSingleton(VisitorAttribute._StubAttribute, RoleSingleton.publisherSingleton, guid.ToString(DicSingleton.gE3WbyDVW(0x5A1B57A3 ^ 0x5A1B394B)), m_InterceptorAttribute ? ((ConnectionInterpreter)3) : ((ConnectionInterpreter)0), isPlainImplicit: true, isQuotedImplicit: false));
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	internal static bool DeleteIssuer()
	{
		return InterruptIssuer == null;
	}

	internal static PrototypeAttribute FillIssuer()
	{
		return InterruptIssuer;
	}
}
