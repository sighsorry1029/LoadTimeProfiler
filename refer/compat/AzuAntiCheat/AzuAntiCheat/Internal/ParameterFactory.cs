using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal class ParameterFactory : ModelFactory
{
	[CompilerGenerated]
	private readonly string statusFactory;

	private static ParameterFactory LogoutReader;

	internal string Value
	{
		[CompilerGenerated]
		get
		{
			return statusFactory;
		}
	}

	internal ParameterFactory(string value, QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 0:
				return;
			case 1:
				statusFactory = value;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool CountReader()
	{
		return LogoutReader == null;
	}

	internal static ParameterFactory SetReader()
	{
		return LogoutReader;
	}
}
