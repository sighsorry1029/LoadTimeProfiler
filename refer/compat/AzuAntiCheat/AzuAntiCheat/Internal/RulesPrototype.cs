using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class RulesPrototype : ContextPrototype
{
	[CompilerGenerated]
	private HelperReader _GetterPrototype;

	[CompilerGenerated]
	private ValueFactory codePrototype;

	private static RulesPrototype IncludeConfiguration;

	public HelperReader Anchor
	{
		[CompilerGenerated]
		get
		{
			return _GetterPrototype;
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
					_GetterPrototype = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public ValueFactory Tag
	{
		[CompilerGenerated]
		get
		{
			return codePrototype;
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
				case 1:
					codePrototype = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 == 0)
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

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	protected RulesPrototype(UtilsPrototype source)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(source);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool CheckConfiguration()
	{
		return IncludeConfiguration == null;
	}

	internal static RulesPrototype RateConfiguration()
	{
		return IncludeConfiguration;
	}
}
