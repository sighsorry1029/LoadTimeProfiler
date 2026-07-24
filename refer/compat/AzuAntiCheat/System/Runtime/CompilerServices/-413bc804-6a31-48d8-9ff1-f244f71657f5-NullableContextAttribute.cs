using AzuAnticheat.Internal;
using Microsoft.CodeAnalysis;

namespace System.Runtime.CompilerServices;

[_003C1c930827_002Df0b5_002D4e54_002D8046_002D3b511e036a7b_003EEmbedded]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
[CompilerGenerated]
internal sealed class _003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContextAttribute : Attribute
{
	public readonly byte Flag;

	private static _003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContextAttribute PostExpression;

	public _003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContextAttribute(byte P_0)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
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
				Flag = P_0;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool CallExpression()
	{
		return PostExpression == null;
	}

	internal static _003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContextAttribute ConcatExpression()
	{
		return PostExpression;
	}
}
