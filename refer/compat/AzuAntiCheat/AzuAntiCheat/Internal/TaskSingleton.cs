namespace AzuAnticheat.Internal;

internal sealed class TaskSingleton : ClientSingleton
{
	internal static TaskSingleton ConnectStub;

	public override int NestingIncrease => -1;

	internal override TreeNodeStates Type => (TreeNodeStates)4;

	public bool IsImplicit { get; }

	public TaskSingleton(bool isImplicit, TestsInterpreter start, TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			}
			_UtilsSingleton = isImplicit;
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a == 0)
			{
				num = 0;
			}
		}
	}

	public TaskSingleton(bool isImplicit)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(isImplicit, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd != 0)
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
		return string.Format(DicSingleton.gE3WbyDVW(-830028630 ^ -830050332), IsImplicit);
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool StartStub()
	{
		return ConnectStub == null;
	}

	internal static TaskSingleton RemoveStub()
	{
		return ConnectStub;
	}
}
