using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class ReponsePrototype : UtilsPrototype
{
	[CompilerGenerated]
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	private object proxyPrototype;

	[CompilerGenerated]
	private Type m_ModelPrototype;

	[CompilerGenerated]
	private Type _AdvisorPrototype;

	[CompilerGenerated]
	private RuleFactory _ConnectionPrototype;

	internal static ReponsePrototype FillRole;

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public object Value
	{
		[CompilerGenerated]
		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
		get
		{
			return proxyPrototype;
		}
		[CompilerGenerated]
		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
		private set
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
					proxyPrototype = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
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

	public Type Type
	{
		[CompilerGenerated]
		get
		{
			return m_ModelPrototype;
		}
		[CompilerGenerated]
		private set
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
					m_ModelPrototype = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
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

	public Type StaticType
	{
		[CompilerGenerated]
		get
		{
			return _AdvisorPrototype;
		}
		[CompilerGenerated]
		private set
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
					_AdvisorPrototype = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
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

	public RuleFactory ScalarStyle
	{
		[CompilerGenerated]
		get
		{
			return _ConnectionPrototype;
		}
		[CompilerGenerated]
		private set
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
					_ConnectionPrototype = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public ReponsePrototype([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object value, Type type, Type staticType)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(value, type, staticType, (RuleFactory)0);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ReponsePrototype([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object value, Type type, Type staticType, RuleFactory scalarStyle)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				ScalarStyle = scalarStyle;
				num = 4;
				break;
			default:
				Value = value;
				num = 3;
				break;
			case 4:
				return;
			case 3:
				Type = type ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x5A1F7167 ^ 0x5A1F27FB));
				num = 2;
				break;
			case 2:
				StaticType = staticType ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-475093377 ^ -475071935));
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool FlushRole()
	{
		return FillRole == null;
	}

	internal static ReponsePrototype DestroyRole()
	{
		return FillRole;
	}
}
