namespace AzuAnticheat.Internal;

internal sealed class GetterSingleton : SystemSingleton
{
	internal static GetterSingleton CalcStub;

	public GetterSingleton()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(in TestsInterpreter._InitializerInterpreter, in TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public GetterSingleton(in TestsInterpreter start, in TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool LogoutStub()
	{
		return CalcStub == null;
	}

	internal static GetterSingleton CountStub()
	{
		return CalcStub;
	}
}
