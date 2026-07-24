namespace AzuAnticheat.Internal;

internal sealed class MapperSingleton : SystemSingleton
{
	internal static MapperSingleton ReadStub;

	public MapperSingleton()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(in TestsInterpreter._InitializerInterpreter, in TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public MapperSingleton(in TestsInterpreter start, in TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ViewStub()
	{
		return ReadStub == null;
	}

	internal static MapperSingleton InitStub()
	{
		return ReadStub;
	}
}
