namespace AzuAnticheat.Internal;

internal sealed class ParamsInvocation
{
	public static class PoolInvocation
	{
		public static readonly RoleSingleton _DescriptorInvocation;

		internal static PoolInvocation ComputeReg;

		static PoolInvocation()
		{
			int num = 2;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 2:
					GetterIssuer.DeleteInitializer();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
					{
						num2 = 0;
					}
					break;
				case 1:
					_DescriptorInvocation = new RoleSingleton(DicSingleton.gE3WbyDVW(0x4097B854 ^ 0x4097DEEA));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		internal static bool DisableReg()
		{
			return ComputeReg == null;
		}

		internal static PoolInvocation QueryReg()
		{
			return ComputeReg;
		}
	}

	private static ParamsInvocation FillReg;

	public ParamsInvocation()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool FlushReg()
	{
		return FillReg == null;
	}

	internal static ParamsInvocation DestroyReg()
	{
		return FillReg;
	}
}
