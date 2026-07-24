using AzuAnticheat.Internal;
using Microsoft.CodeAnalysis;

namespace System.Runtime.CompilerServices;

[_003C1c930827_002Df0b5_002D4e54_002D8046_002D3b511e036a7b_003EEmbedded]
[AttributeUsage(AttributeTargets.Module, AllowMultiple = false, Inherited = false)]
[CompilerGenerated]
internal sealed class _003C7c14a8c2_002D7b89_002D43da_002Dbc64_002D670d28850d1a_003ERefSafetyRulesAttribute : Attribute
{
	public readonly int Version;

	private static _003C7c14a8c2_002D7b89_002D43da_002Dbc64_002D670d28850d1a_003ERefSafetyRulesAttribute MapExpression;

	public _003C7c14a8c2_002D7b89_002D43da_002Dbc64_002D670d28850d1a_003ERefSafetyRulesAttribute(int P_0)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 != 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 1:
				Version = P_0;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool NewExpression()
	{
		return MapExpression == null;
	}

	internal static _003C7c14a8c2_002D7b89_002D43da_002Dbc64_002D670d28850d1a_003ERefSafetyRulesAttribute AddExpression()
	{
		return MapExpression;
	}
}
