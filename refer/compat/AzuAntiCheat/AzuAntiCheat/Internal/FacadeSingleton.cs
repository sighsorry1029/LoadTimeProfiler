using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class FacadeSingleton : OrderSingleton
{
	[CompilerGenerated]
	private readonly bool eventSingleton;

	[CompilerGenerated]
	private readonly Level instanceSingleton;

	internal static FacadeSingleton RestartStub;

	public override int NestingIncrease => 1;

	internal override TreeNodeStates Type => (TreeNodeStates)9;

	public bool IsImplicit
	{
		[CompilerGenerated]
		get
		{
			return eventSingleton;
		}
	}

	public override bool IsCanonical => !IsImplicit;

	public Level Style
	{
		[CompilerGenerated]
		get
		{
			return instanceSingleton;
		}
	}

	public FacadeSingleton(VisitorAttribute anchor, RoleSingleton tag, bool isImplicit, Level style, TestsInterpreter start, TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(anchor, tag, start, end);
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 != 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				instanceSingleton = style;
				num = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
				{
					num = 1;
				}
				break;
			case 1:
				eventSingleton = isImplicit;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 == 0)
				{
					num = 0;
				}
				break;
			case 2:
				return;
			}
		}
	}

	public FacadeSingleton(VisitorAttribute anchor, RoleSingleton tag, bool isImplicit, Level style)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(anchor, tag, isImplicit, style, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public FacadeSingleton()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(VisitorAttribute._StubAttribute, RoleSingleton.publisherSingleton, isImplicit: true, (Level)0, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc != 0)
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
		return string.Format(DicSingleton.gE3WbyDVW(-545065612 ^ -545104252), base.Anchor, base.Tag, IsImplicit, Style);
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool GetStub()
	{
		return RestartStub == null;
	}

	internal static FacadeSingleton CalculateStub()
	{
		return RestartStub;
	}
}
