using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class TestsSingleton : ClientSingleton
{
	[CompilerGenerated]
	private readonly ProductSingleton? pageSingleton;

	private static TestsSingleton? ResolveStub;

	public override int NestingIncrease => 1;

	internal override TreeNodeStates Type => (TreeNodeStates)3;

	public ProcInterpreter? Tags { get; }

	public ProductSingleton? Version
	{
		[CompilerGenerated]
		get
		{
			return pageSingleton;
		}
	}

	public bool IsImplicit { get; }

	public TestsSingleton(ProductSingleton? version, ProcInterpreter? tags, bool isImplicit, TestsInterpreter start, TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				_InitializerSingleton = tags;
				num = 2;
				break;
			case 3:
				return;
			case 2:
				_ParserSingleton = isImplicit;
				num = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
				{
					num = 3;
				}
				break;
			default:
				pageSingleton = version;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
				{
					num = 1;
				}
				break;
			}
		}
	}

	public TestsSingleton(ProductSingleton? version, ProcInterpreter? tags, bool isImplicit)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(version, tags, isImplicit, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public TestsSingleton(in TestsInterpreter start, in TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(null, null, isImplicit: true, start, end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public TestsSingleton()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(null, null, isImplicit: true, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
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
		return string.Format(DicSingleton.gE3WbyDVW(-830028630 ^ -830050502), IsImplicit);
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
			case 0:
				return;
			case 1:
				visitor.Visit(this);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool DefineStub()
	{
		return ResolveStub == null;
	}

	internal static TestsSingleton? IncludeStub()
	{
		return ResolveStub;
	}
}
