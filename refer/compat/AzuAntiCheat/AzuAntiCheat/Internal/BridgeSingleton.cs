using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class BridgeSingleton : OrderSingleton
{
	[CompilerGenerated]
	private readonly ConnectionInterpreter statusSingleton;

	[CompilerGenerated]
	private readonly bool m_MerchantSingleton;

	[CompilerGenerated]
	private readonly bool m_AttrSingleton;

	private static BridgeSingleton TestGetter;

	internal override TreeNodeStates Type => (TreeNodeStates)6;

	public string Value { get; }

	public ConnectionInterpreter Style
	{
		[CompilerGenerated]
		get
		{
			return statusSingleton;
		}
	}

	public bool IsPlainImplicit
	{
		[CompilerGenerated]
		get
		{
			return m_MerchantSingleton;
		}
	}

	public bool IsQuotedImplicit { get; }

	public override bool IsCanonical
	{
		get
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					if (!IsPlainImplicit)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
						{
							num2 = 0;
						}
						break;
					}
					return false;
				default:
					return !IsQuotedImplicit;
				}
			}
		}
	}

	public bool IsKey
	{
		[CompilerGenerated]
		get
		{
			return m_AttrSingleton;
		}
	}

	public BridgeSingleton(VisitorAttribute anchor, RoleSingleton tag, string value, ConnectionInterpreter style, bool isPlainImplicit, bool isQuotedImplicit, TestsInterpreter start, TestsInterpreter end, bool isKey = false)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(anchor, tag, start, end);
		int num = 4;
		while (true)
		{
			switch (num)
			{
			case 1:
				statusSingleton = style;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
				{
					num = 0;
				}
				break;
			case 4:
				_ParameterSingleton = value;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
				{
					num = 1;
				}
				break;
			case 3:
				return;
			default:
				m_MerchantSingleton = isPlainImplicit;
				num = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
				{
					num = 5;
				}
				break;
			case 2:
				m_AttrSingleton = isKey;
				num = 3;
				break;
			case 5:
				_TestSingleton = isQuotedImplicit;
				num = 2;
				break;
			}
		}
	}

	public BridgeSingleton(VisitorAttribute anchor, RoleSingleton tag, string value, ConnectionInterpreter style, bool isPlainImplicit, bool isQuotedImplicit)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(anchor, tag, value, style, isPlainImplicit, isQuotedImplicit, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public BridgeSingleton(string value)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(VisitorAttribute._StubAttribute, RoleSingleton.publisherSingleton, value, (ConnectionInterpreter)0, isPlainImplicit: true, isQuotedImplicit: true, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public BridgeSingleton(RoleSingleton tag, string value)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(VisitorAttribute._StubAttribute, tag, value, (ConnectionInterpreter)0, isPlainImplicit: true, isQuotedImplicit: true, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public BridgeSingleton(VisitorAttribute anchor, RoleSingleton tag, string value)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(anchor, tag, value, (ConnectionInterpreter)0, isPlainImplicit: true, isQuotedImplicit: true, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
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
		return string.Format(DicSingleton.gE3WbyDVW(0x5901407C ^ 0x5901ECFC), base.Anchor, base.Tag, Value, Style, IsPlainImplicit, IsQuotedImplicit);
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool RunGetter()
	{
		return TestGetter == null;
	}

	internal static BridgeSingleton VerifyGetter()
	{
		return TestGetter;
	}
}
