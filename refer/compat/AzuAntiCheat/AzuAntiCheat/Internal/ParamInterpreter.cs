using System;

namespace AzuAnticheat.Internal;

internal sealed class ParamInterpreter : ReaderSingleton
{
	internal static ParamInterpreter CheckConsumer;

	public ParamInterpreter(string message)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(message);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ParamInterpreter(in TestsInterpreter start, in TestsInterpreter end, string message)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end, message);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ParamInterpreter(string message, Exception inner)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(message, inner);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool RateConsumer()
	{
		return CheckConsumer == null;
	}

	internal static ParamInterpreter ResetConsumer()
	{
		return CheckConsumer;
	}
}
