using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class RuleSingleton : SystemSingleton
{
	[CompilerGenerated]
	private readonly string m_SerializerSingleton;

	[CompilerGenerated]
	private readonly bool producerSingleton;

	private static RuleSingleton RestartProducer;

	public string Value
	{
		[CompilerGenerated]
		get
		{
			return m_SerializerSingleton;
		}
	}

	public bool IsInline
	{
		[CompilerGenerated]
		get
		{
			return producerSingleton;
		}
	}

	public RuleSingleton(string value, bool isInline)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(value, isInline, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public RuleSingleton(string value, bool isInline, TestsInterpreter start, TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
		int num = 2;
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 0:
				return;
			case 1:
				producerSingleton = isInline;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
				{
					num = 0;
				}
				break;
			case 2:
				m_SerializerSingleton = value ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x5A1B57A3 ^ 0x5A1B1C0B));
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool GetProducer()
	{
		return RestartProducer == null;
	}

	internal static RuleSingleton CalculateProducer()
	{
		return RestartProducer;
	}
}
