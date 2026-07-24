namespace AzuAnticheat.Internal;

internal sealed class ParamsInterceptor
{
	public static class PoolInterceptor
	{
		public static readonly ValueFactory m_DescriptorInterceptor;

		public static readonly ValueFactory dispatcherInterceptor;

		public static readonly ValueFactory _ListInterceptor;

		private static PoolInterceptor CreateProcess;

		static PoolInterceptor()
		{
			int num = 3;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					_ListInterceptor = new ValueFactory(DicSingleton.gE3WbyDVW(-25744665 ^ -25735369));
					num2 = 4;
					break;
				case 3:
					GetterIssuer.DeleteInitializer();
					num2 = 2;
					break;
				case 1:
					dispatcherInterceptor = new ValueFactory(DicSingleton.gE3WbyDVW(-290181924 ^ -290174594));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
					{
						num2 = 0;
					}
					break;
				case 2:
					m_DescriptorInterceptor = new ValueFactory(DicSingleton.gE3WbyDVW(0x4995986C ^ 0x4995FD18));
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 == 0)
					{
						num2 = 1;
					}
					break;
				case 4:
					return;
				}
			}
		}

		internal static bool TestProcess()
		{
			return CreateProcess == null;
		}

		internal static PoolInterceptor RunProcess()
		{
			return CreateProcess;
		}
	}

	private static ParamsInterceptor SetupProcess;

	public ParamsInterceptor()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool SelectProcess()
	{
		return SetupProcess == null;
	}

	internal static ParamsInterceptor ChangeProcess()
	{
		return SetupProcess;
	}
}
