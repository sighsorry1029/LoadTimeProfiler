namespace AzuAnticheat.Internal;

internal sealed class InfoInvocation
{
	public static class DicInvocation
	{
	}

	private static InfoInvocation UpdateReg;

	public InfoInvocation()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool SearchReg()
	{
		return UpdateReg == null;
	}

	internal static InfoInvocation StopReg()
	{
		return UpdateReg;
	}
}
