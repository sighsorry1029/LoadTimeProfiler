using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class ComposerSingleton : SystemSingleton
{
	[CompilerGenerated]
	private readonly string globalSingleton;

	internal static ComposerSingleton SelectStub;

	public string Value
	{
		[CompilerGenerated]
		get
		{
			return globalSingleton;
		}
	}

	public ComposerSingleton(string value, TestsInterpreter start, TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
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
				globalSingleton = value;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool ChangeStub()
	{
		return SelectStub == null;
	}

	internal static ComposerSingleton CreateStub()
	{
		return SelectStub;
	}
}
