using System;

namespace AzuAnticheat.Internal;

internal class ProcessorAttribute : ReaderSingleton
{
	private static ProcessorAttribute MoveAttribute;

	public ProcessorAttribute(string message)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(message);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ProcessorAttribute(in TestsInterpreter start, in TestsInterpreter end, string message)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end, message);
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

	public ProcessorAttribute(string message, Exception inner)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(message, inner);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool RevertAttribute()
	{
		return MoveAttribute == null;
	}

	internal static ProcessorAttribute InvokeConsumer()
	{
		return MoveAttribute;
	}
}
