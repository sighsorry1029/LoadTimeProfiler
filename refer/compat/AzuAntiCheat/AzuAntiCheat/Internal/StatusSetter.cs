using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class StatusSetter : ParamSetter
{
	[CompilerGenerated]
	private bool m_MerchantSetter;

	[CompilerGenerated]
	private DockingBehavior testSetter;

	private static StatusSetter MoveParameter;

	public bool IsImplicit
	{
		[CompilerGenerated]
		get
		{
			return m_MerchantSetter;
		}
		[CompilerGenerated]
		set
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 0:
					return;
				case 1:
					m_MerchantSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public DockingBehavior Style
	{
		[CompilerGenerated]
		get
		{
			return testSetter;
		}
		[CompilerGenerated]
		set
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 1:
					testSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}
	}

	public StatusSetter(ImporterSetter source)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(source);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool RevertParameter()
	{
		return MoveParameter == null;
	}

	internal static StatusSetter InvokeObserver()
	{
		return MoveParameter;
	}
}
