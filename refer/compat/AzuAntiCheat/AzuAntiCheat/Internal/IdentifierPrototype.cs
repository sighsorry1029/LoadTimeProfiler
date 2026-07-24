using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class IdentifierPrototype : ContextPrototype
{
	[CompilerGenerated]
	private readonly HelperReader tokenPrototype;

	[CompilerGenerated]
	private bool m_CallbackPrototype;

	private static IdentifierPrototype RemoveConfiguration;

	public HelperReader Alias
	{
		[CompilerGenerated]
		get
		{
			return tokenPrototype;
		}
	}

	public bool NeedsExpansion
	{
		[CompilerGenerated]
		get
		{
			return m_CallbackPrototype;
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
					m_CallbackPrototype = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public IdentifierPrototype(UtilsPrototype source, HelperReader alias)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(source);
		int num = 2;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 3:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x602C149E ^ 0x602C4D6E));
			case 1:
				tokenPrototype = alias;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 != 0)
				{
					num = 0;
				}
				break;
			case 2:
				if (!alias.IsEmpty)
				{
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
					{
						num = 1;
					}
					break;
				}
				goto case 3;
			case 0:
				return;
			}
		}
	}

	internal static bool ResolveConfiguration()
	{
		return RemoveConfiguration == null;
	}

	internal static IdentifierPrototype DefineConfiguration()
	{
		return RemoveConfiguration;
	}
}
