namespace AzuAnticheat.Internal;

internal sealed class QueueInterceptor
{
	public static class CollectionInterceptor
	{
		public static readonly ValueFactory managerInterceptor;

		public static readonly ValueFactory tokenizerInterceptor;

		public static readonly ValueFactory m_ListenerInterceptor;

		public static readonly ValueFactory _AccountInterceptor;

		internal static CollectionInterceptor CallProcess;

		static CollectionInterceptor()
		{
			int num = 5;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 4:
					managerInterceptor = new ValueFactory(DicSingleton.gE3WbyDVW(0x2D27936 ^ 0x2D21CC8));
					num2 = 2;
					break;
				case 3:
					_AccountInterceptor = new ValueFactory(DicSingleton.gE3WbyDVW(0x765D303 ^ 0x765B58F));
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 == 0)
					{
						num2 = 0;
					}
					break;
				case 1:
					return;
				case 5:
					GetterIssuer.DeleteInitializer();
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf != 0)
					{
						num2 = 4;
					}
					break;
				case 2:
					tokenizerInterceptor = new ValueFactory(DicSingleton.gE3WbyDVW(0x21AFFB2B ^ 0x21AF9D05));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
					{
						num2 = 0;
					}
					break;
				default:
					m_ListenerInterceptor = new ValueFactory(DicSingleton.gE3WbyDVW(0x4097B854 ^ 0x4097DE0A));
					num2 = 3;
					break;
				}
			}
		}

		internal static bool ConcatProcess()
		{
			return CallProcess == null;
		}

		internal static CollectionInterceptor MapProcess()
		{
			return CallProcess;
		}
	}

	internal static QueueInterceptor VerifyProcess;

	public QueueInterceptor()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool PopProcess()
	{
		return VerifyProcess == null;
	}

	internal static QueueInterceptor PostProcess()
	{
		return VerifyProcess;
	}
}
