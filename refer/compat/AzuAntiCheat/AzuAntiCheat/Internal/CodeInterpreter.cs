using System;

namespace AzuAnticheat.Internal;

internal sealed class CodeInterpreter : ReaderSingleton
{
	internal static CodeInterpreter SetConsumer;

	public CodeInterpreter(string message)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(message);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public CodeInterpreter(in TestsInterpreter start, in TestsInterpreter end, string message)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end, message);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public CodeInterpreter(string message, Exception inner)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(message, inner);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool PushConsumer()
	{
		return SetConsumer == null;
	}

	internal static CodeInterpreter ValidateConsumer()
	{
		return SetConsumer;
	}
}
