using System;

namespace AzuAnticheat.Internal;

internal sealed class CandidateInvocation : ConnectionSetter
{
	private static CandidateInvocation ComputeProxy;

	public Type Resolve(Type staticType, object? actualValue)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				if (actualValue != null)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
					{
						num2 = 1;
					}
					break;
				}
				goto default;
			default:
				return staticType;
			case 1:
				return actualValue.GetType();
			}
		}
	}

	public CandidateInvocation()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool DisableProxy()
	{
		return ComputeProxy == null;
	}

	internal static CandidateInvocation QueryProxy()
	{
		return ComputeProxy;
	}
}
