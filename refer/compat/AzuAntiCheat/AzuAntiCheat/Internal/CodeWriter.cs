using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class CodeWriter
{
	[CompilerGenerated]
	private bool m_IndexerWriter;

	internal static CodeWriter AddBridge;

	public bool AllowPrivateConstructors
	{
		[CompilerGenerated]
		get
		{
			return m_IndexerWriter;
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
					m_IndexerWriter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public CodeWriter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool PrepareBridge()
	{
		return AddBridge == null;
	}

	internal static CodeWriter WriteBridge()
	{
		return AddBridge;
	}
}
