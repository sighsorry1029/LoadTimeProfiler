using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal abstract class SystemSingleton
{
	[CompilerGenerated]
	private readonly TestsInterpreter candidateSingleton;

	private static SystemSingleton UpdateStub;

	public TestsInterpreter Start { get; }

	public TestsInterpreter End
	{
		[CompilerGenerated]
		get
		{
			return candidateSingleton;
		}
	}

	protected SystemSingleton(in TestsInterpreter start, in TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				candidateSingleton = end;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 2:
				_ResolverSingleton = start;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 != 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	internal static bool SearchStub()
	{
		return UpdateStub == null;
	}

	internal static SystemSingleton StopStub()
	{
		return UpdateStub;
	}
}
