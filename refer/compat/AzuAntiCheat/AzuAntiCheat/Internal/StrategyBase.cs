using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
internal sealed class StrategyBase : Attribute
{
	[CompilerGenerated]
	private readonly bool m_ProcessorBase;

	internal static StrategyBase DestroySingleton;

	public bool ReturnValue
	{
		[CompilerGenerated]
		get
		{
			return m_ProcessorBase;
		}
	}

	public StrategyBase(bool returnValue)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 1:
				m_ProcessorBase = returnValue;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool ComputeSingleton()
	{
		return DestroySingleton == null;
	}

	internal static StrategyBase DisableSingleton()
	{
		return DestroySingleton;
	}
}
