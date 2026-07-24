using System;

namespace AzuAnticheat.Internal;

internal sealed class AdapterInterpreter : ReaderSingleton
{
	private static AdapterInterpreter FindProducer;

	public AdapterInterpreter(string message)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(message);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public AdapterInterpreter(in TestsInterpreter start, in TestsInterpreter end, string message)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end, message);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public AdapterInterpreter(string message, Exception inner)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(message, inner);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool VisitProducer()
	{
		return FindProducer == null;
	}

	internal static AdapterInterpreter OrderProducer()
	{
		return FindProducer;
	}
}
