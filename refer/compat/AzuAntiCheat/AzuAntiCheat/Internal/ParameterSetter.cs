namespace AzuAnticheat.Internal;

internal sealed class ParameterSetter : TestsSetter
{
	private static ParameterSetter RestartParameter;

	public ParameterSetter(ImporterSetter source)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(source);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool GetParameter()
	{
		return RestartParameter == null;
	}

	internal static ParameterSetter CalculateParameter()
	{
		return RestartParameter;
	}
}
