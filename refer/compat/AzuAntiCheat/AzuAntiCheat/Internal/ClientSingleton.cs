using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal abstract class ClientSingleton
{
	[CompilerGenerated]
	private readonly TestsInterpreter recordSingleton;

	[CompilerGenerated]
	private readonly TestsInterpreter serviceSingleton;

	internal static ClientSingleton SelectGetter;

	public virtual int NestingIncrease => 0;

	internal abstract TreeNodeStates Type { get; }

	public TestsInterpreter Start
	{
		[CompilerGenerated]
		get
		{
			return recordSingleton;
		}
	}

	public TestsInterpreter End
	{
		[CompilerGenerated]
		get
		{
			return serviceSingleton;
		}
	}

	public abstract void Accept(RequestSingleton visitor);

	internal ClientSingleton(in TestsInterpreter start, in TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 2;
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 1:
				serviceSingleton = end;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 == 0)
				{
					num = 0;
				}
				break;
			case 2:
				recordSingleton = start;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
				{
					num = 1;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool ChangeGetter()
	{
		return SelectGetter == null;
	}

	internal static ClientSingleton CreateGetter()
	{
		return SelectGetter;
	}
}
