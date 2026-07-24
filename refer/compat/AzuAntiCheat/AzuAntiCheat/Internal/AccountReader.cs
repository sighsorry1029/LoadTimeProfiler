using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class AccountReader : TestsFactory
{
	private static AccountReader RunError;

	public AccountReader(string message)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(message);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public AccountReader(QueueReader start, QueueReader end, string message)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end, message);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public AccountReader(string message, Exception inner)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(message, inner);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool VerifyError()
	{
		return RunError == null;
	}

	internal static AccountReader PopError()
	{
		return RunError;
	}
}
