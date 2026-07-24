using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class CandidatePrototype : RulesPrototype
{
	[CompilerGenerated]
	private bool expressionPrototype;

	[CompilerGenerated]
	private ProcFactory _ProductPrototype;

	private static CandidatePrototype CalculateConfiguration;

	public bool IsImplicit
	{
		[CompilerGenerated]
		get
		{
			return expressionPrototype;
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
					expressionPrototype = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public ProcFactory Style
	{
		[CompilerGenerated]
		get
		{
			return _ProductPrototype;
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
					_ProductPrototype = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public CandidatePrototype(UtilsPrototype source)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(source);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool MoveConfiguration()
	{
		return CalculateConfiguration == null;
	}

	internal static CandidatePrototype RevertConfiguration()
	{
		return CalculateConfiguration;
	}
}
