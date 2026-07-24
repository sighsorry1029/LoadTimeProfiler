namespace AzuAnticheat.Internal;

internal sealed class SchemaInterceptor
{
	public static class StructInterceptor
	{
		public static readonly ValueFactory _ClassInterceptor;

		internal static StructInterceptor InitProcess;

		static StructInterceptor()
		{
			int num = 2;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 1:
					_ClassInterceptor = new ValueFactory(DicSingleton.gE3WbyDVW(-243097544 ^ -243087738));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd != 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				case 2:
					GetterIssuer.DeleteInitializer();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		internal static bool PatchProcess()
		{
			return InitProcess == null;
		}

		internal static StructInterceptor AssetProcess()
		{
			return InitProcess;
		}
	}

	private static SchemaInterceptor CloneProcess;

	public SchemaInterceptor()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ReadProcess()
	{
		return CloneProcess == null;
	}

	internal static SchemaInterceptor ViewProcess()
	{
		return CloneProcess;
	}
}
