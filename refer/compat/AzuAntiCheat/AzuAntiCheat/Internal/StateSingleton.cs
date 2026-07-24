using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class StateSingleton : ClientSingleton
{
	[CompilerGenerated]
	private readonly VisitorAttribute valueSingleton;

	internal static StateSingleton ComputeStub;

	internal override TreeNodeStates Type => (TreeNodeStates)5;

	public VisitorAttribute Value
	{
		[CompilerGenerated]
		get
		{
			return valueSingleton;
		}
	}

	public StateSingleton(VisitorAttribute value, TestsInterpreter start, TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
		{
			num = 2;
		}
		while (true)
		{
			switch (num)
			{
			case 3:
				return;
			case 2:
				if (!value.IsEmpty)
				{
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 == 0)
					{
						num = 0;
					}
					break;
				}
				goto case 1;
			case 1:
				throw new ReaderSingleton(in start, in end, DicSingleton.gE3WbyDVW(-940539791 ^ -940561699));
			default:
				valueSingleton = value;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
				{
					num = 3;
				}
				break;
			}
		}
	}

	public StateSingleton(VisitorAttribute value)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(value, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
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
		return string.Format(DicSingleton.gE3WbyDVW(-2133864647 ^ -2133891625), Value);
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool DisableStub()
	{
		return ComputeStub == null;
	}

	internal static StateSingleton QueryStub()
	{
		return ComputeStub;
	}
}
