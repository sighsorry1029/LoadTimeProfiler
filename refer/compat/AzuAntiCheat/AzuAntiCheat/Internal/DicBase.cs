using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true, Inherited = false)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class DicBase : Attribute
{
	[CompilerGenerated]
	private readonly string m_ParamsBase;

	internal static DicBase LoginSingleton;

	public string ParameterName
	{
		[CompilerGenerated]
		get
		{
			return m_ParamsBase;
		}
	}

	public DicBase(string parameterName)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
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
				m_ParamsBase = parameterName;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool ConnectSingleton()
	{
		return LoginSingleton == null;
	}

	internal static DicBase StartSingleton()
	{
		return LoginSingleton;
	}
}
