namespace AzuAnticheat.Internal;

internal sealed class CodeSingleton : SystemSingleton
{
	private static CodeSingleton SetStub;

	public CodeSingleton()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(in TestsInterpreter._InitializerInterpreter, in TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public CodeSingleton(in TestsInterpreter start, in TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool PushStub()
	{
		return SetStub == null;
	}

	internal static CodeSingleton ValidateStub()
	{
		return SetStub;
	}
}
