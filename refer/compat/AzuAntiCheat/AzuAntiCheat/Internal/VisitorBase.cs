using System;

namespace AzuAnticheat.Internal;

[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
internal sealed class VisitorBase : Attribute
{
	internal static VisitorBase StopSingleton;

	public bool ParameterValue { get; }

	public VisitorBase(bool parameterValue)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
		{
			num = 1;
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
				_StubBase = parameterValue;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool ExcludeSingleton()
	{
		return StopSingleton == null;
	}

	internal static VisitorBase InterruptSingleton()
	{
		return StopSingleton;
	}
}
