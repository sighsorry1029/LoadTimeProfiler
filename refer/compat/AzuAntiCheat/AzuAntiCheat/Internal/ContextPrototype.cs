using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal abstract class ContextPrototype
{
	private static ContextPrototype LoginConfiguration;

	public UtilsPrototype Source { get; }

	protected ContextPrototype(UtilsPrototype source)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb != 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			}
			_MapperPrototype = source ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1866665889 ^ -1866683969));
			num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
			{
				num = 1;
			}
		}
	}

	internal static bool ConnectConfiguration()
	{
		return LoginConfiguration == null;
	}

	internal static ContextPrototype StartConfiguration()
	{
		return LoginConfiguration;
	}
}
