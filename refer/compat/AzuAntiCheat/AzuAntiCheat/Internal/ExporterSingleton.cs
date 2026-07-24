using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ExporterSingleton : OrderSingleton
{
	[CompilerGenerated]
	private readonly bool m_ValSingleton;

	[CompilerGenerated]
	private readonly DockingBehavior m_ConfigSingleton;

	internal static ExporterSingleton ConcatGetter;

	public override int NestingIncrease => 1;

	internal override TreeNodeStates Type => (TreeNodeStates)7;

	public bool IsImplicit
	{
		[CompilerGenerated]
		get
		{
			return m_ValSingleton;
		}
	}

	public override bool IsCanonical => !IsImplicit;

	public DockingBehavior Style
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigSingleton;
		}
	}

	public ExporterSingleton(VisitorAttribute anchor, RoleSingleton tag, bool isImplicit, DockingBehavior style, TestsInterpreter start, TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(anchor, tag, start, end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 1:
				m_ValSingleton = isImplicit;
				num = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
				{
					num = 2;
				}
				break;
			case 2:
				m_ConfigSingleton = style;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public ExporterSingleton(VisitorAttribute anchor, RoleSingleton tag, bool isImplicit, DockingBehavior style)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(anchor, tag, isImplicit, style, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public override string ToString()
	{
		return string.Format(DicSingleton.gE3WbyDVW(-381685266 ^ -381723492), base.Anchor, base.Tag, IsImplicit, Style);
	}

	public override void Accept(RequestSingleton visitor)
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
				visitor.Visit(this);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool MapGetter()
	{
		return ConcatGetter == null;
	}

	internal static ExporterSingleton NewGetter()
	{
		return ConcatGetter;
	}
}
