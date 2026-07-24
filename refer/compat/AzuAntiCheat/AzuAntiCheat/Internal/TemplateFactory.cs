using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal class TemplateFactory : TestsFactory
{
	internal static TemplateFactory DisableError;

	public TemplateFactory(string message)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(message);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public TemplateFactory(QueueReader start, QueueReader end, string message)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end, message);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public TemplateFactory(string message, Exception inner)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(message, inner);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool QueryError()
	{
		return DisableError == null;
	}

	internal static TemplateFactory AwakeError()
	{
		return DisableError;
	}
}
