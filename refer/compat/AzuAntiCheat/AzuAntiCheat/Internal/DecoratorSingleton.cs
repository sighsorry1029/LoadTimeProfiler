using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class DecoratorSingleton : ClientSingleton
{
	[CompilerGenerated]
	private readonly string broadcasterSingleton;

	[CompilerGenerated]
	private readonly bool workerSingleton;

	private static DecoratorSingleton AwakeStub;

	public string Value
	{
		[CompilerGenerated]
		get
		{
			return broadcasterSingleton;
		}
	}

	public bool IsInline
	{
		[CompilerGenerated]
		get
		{
			return workerSingleton;
		}
	}

	internal override TreeNodeStates Type => (TreeNodeStates)11;

	public DecoratorSingleton(string value, bool isInline)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(value, isInline, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public DecoratorSingleton(string value, bool isInline, TestsInterpreter start, TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 2:
				workerSingleton = isInline;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
				{
					num = 1;
				}
				break;
			case 1:
				return;
			default:
				broadcasterSingleton = value;
				num = 2;
				break;
			}
		}
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public override string ToString()
	{
		int num = 2;
		int num2 = num;
		string text;
		while (true)
		{
			switch (num2)
			{
			default:
				text = DicSingleton.gE3WbyDVW(0x1A7A0414 ^ 0x1A7AAF0C);
				break;
			case 2:
				if (IsInline)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 != 0)
					{
						num2 = 1;
					}
					continue;
				}
				goto default;
			case 1:
				text = DicSingleton.gE3WbyDVW(-25744665 ^ -25722431);
				break;
			}
			break;
		}
		return text + DicSingleton.gE3WbyDVW(-736996892 ^ -736953646) + Value + DicSingleton.gE3WbyDVW(-1735703950 ^ -1735710164);
	}

	internal static bool InstantiateStub()
	{
		return AwakeStub == null;
	}

	internal static DecoratorSingleton LoginStub()
	{
		return AwakeStub;
	}
}
