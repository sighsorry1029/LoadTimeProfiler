namespace AzuAnticheat.Internal;

internal sealed class ContextSingleton : SystemSingleton
{
	private static ContextSingleton PrintStub;

	public ContextSingleton()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(in TestsInterpreter._InitializerInterpreter, in TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ContextSingleton(in TestsInterpreter start, in TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
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

	internal static bool CompareStub()
	{
		return PrintStub == null;
	}

	internal static ContextSingleton CloneStub()
	{
		return PrintStub;
	}
}
