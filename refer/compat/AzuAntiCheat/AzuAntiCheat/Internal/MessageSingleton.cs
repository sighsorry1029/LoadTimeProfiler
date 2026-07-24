namespace AzuAnticheat.Internal;

internal sealed class MessageSingleton : ClientSingleton
{
	internal static MessageSingleton PopGetter;

	public override int NestingIncrease => -1;

	internal override TreeNodeStates Type => (TreeNodeStates)8;

	public MessageSingleton(in TestsInterpreter start, in TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public MessageSingleton()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(in TestsInterpreter._InitializerInterpreter, in TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
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
		return DicSingleton.gE3WbyDVW(0x4F8CB66E ^ 0x4F8C1B38);
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool PostGetter()
	{
		return PopGetter == null;
	}

	internal static MessageSingleton CallGetter()
	{
		return PopGetter;
	}
}
