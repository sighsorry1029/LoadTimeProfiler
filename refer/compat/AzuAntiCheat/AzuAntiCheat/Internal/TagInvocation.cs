namespace AzuAnticheat.Internal;

internal sealed class TagInvocation
{
	public static class VisitorInvocation
	{
		public static readonly RoleSingleton m_StubInvocation;

		public static readonly RoleSingleton _PolicyInvocation;

		public static readonly RoleSingleton strategyInvocation;

		public static readonly RoleSingleton m_ProcessorInvocation;

		internal static VisitorInvocation FindReg;

		static VisitorInvocation()
		{
			int num = 3;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 2:
					m_StubInvocation = new RoleSingleton(DicSingleton.gE3WbyDVW(0x602C149E ^ 0x602C7160));
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 != 0)
					{
						num2 = 4;
					}
					break;
				default:
					strategyInvocation = new RoleSingleton(DicSingleton.gE3WbyDVW(-1954645236 ^ -1954669230));
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 != 0)
					{
						num2 = 1;
					}
					break;
				case 4:
					_PolicyInvocation = new RoleSingleton(DicSingleton.gE3WbyDVW(-1461449777 ^ -1461424671));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
					{
						num2 = 0;
					}
					break;
				case 1:
					m_ProcessorInvocation = new RoleSingleton(DicSingleton.gE3WbyDVW(-1466472923 ^ -1466498903));
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
					{
						num2 = 5;
					}
					break;
				case 5:
					return;
				case 3:
					GetterIssuer.DeleteInitializer();
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec == 0)
					{
						num2 = 2;
					}
					break;
				}
			}
		}

		internal static bool VisitReg()
		{
			return FindReg == null;
		}

		internal static VisitorInvocation OrderReg()
		{
			return FindReg;
		}
	}

	internal static TagInvocation EnableReg;

	public TagInvocation()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool SortReg()
	{
		return EnableReg == null;
	}

	internal static TagInvocation InsertReg()
	{
		return EnableReg;
	}
}
