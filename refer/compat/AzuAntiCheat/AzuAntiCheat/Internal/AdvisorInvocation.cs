namespace AzuAnticheat.Internal;

internal sealed class AdvisorInvocation
{
	public static class ConnectionInvocation
	{
		public static readonly RoleSingleton annotationInvocation;

		public static readonly RoleSingleton processInvocation;

		public static readonly RoleSingleton m_RepositoryInvocation;

		internal static ConnectionInvocation SetReg;

		static ConnectionInvocation()
		{
			int num = 4;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 0:
					return;
				case 3:
					annotationInvocation = new RoleSingleton(DicSingleton.gE3WbyDVW(0x6729A6D ^ 0x672FF19));
					num2 = 2;
					break;
				case 2:
					processInvocation = new RoleSingleton(DicSingleton.gE3WbyDVW(-381685266 ^ -381709236));
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
					{
						num2 = 1;
					}
					break;
				case 4:
					GetterIssuer.DeleteInitializer();
					num2 = 3;
					break;
				case 1:
					m_RepositoryInvocation = new RoleSingleton(DicSingleton.gE3WbyDVW(-293474990 ^ -293500798));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		internal static bool PushReg()
		{
			return SetReg == null;
		}

		internal static ConnectionInvocation ValidateReg()
		{
			return SetReg;
		}
	}

	internal static AdvisorInvocation CalcReg;

	public AdvisorInvocation()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool LogoutReg()
	{
		return CalcReg == null;
	}

	internal static AdvisorInvocation CountReg()
	{
		return CalcReg;
	}
}
