using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal static class CallbackReader
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)]
	public static readonly ErrorFactory[] rulesReader;

	private static CallbackReader AssetService;

	static CallbackReader()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				GetterIssuer.DeleteInitializer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
				{
					num2 = 0;
				}
				continue;
			case 2:
				return;
			}
			rulesReader = new ErrorFactory[2]
			{
				new ErrorFactory(DicSingleton.gE3WbyDVW(-1466472923 ^ -1466491075), DicSingleton.gE3WbyDVW(0x6CF51E1A ^ 0x6CF56702)),
				new ErrorFactory(DicSingleton.gE3WbyDVW(0x4995986C ^ 0x4995E172), DicSingleton.gE3WbyDVW(-1773869960 ^ -1773888162))
			};
			num2 = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
			{
				num2 = 2;
			}
		}
	}

	internal static bool ListService()
	{
		return AssetService == null;
	}

	internal static CallbackReader CalcService()
	{
		return AssetService;
	}
}
