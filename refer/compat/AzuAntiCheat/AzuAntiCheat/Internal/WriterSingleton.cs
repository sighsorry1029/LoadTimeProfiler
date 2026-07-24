using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class WriterSingleton : SystemSingleton
{
	[CompilerGenerated]
	private readonly VisitorAttribute invocationSingleton;

	internal static WriterSingleton AwakeProducer;

	public VisitorAttribute Value
	{
		[CompilerGenerated]
		get
		{
			return invocationSingleton;
		}
	}

	public WriterSingleton(VisitorAttribute value)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(value, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public WriterSingleton(VisitorAttribute value, TestsInterpreter start, TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 != 0)
		{
			num = 3;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(--798431903 ^ 0x2F975137));
			default:
				invocationSingleton = value;
				num = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
				{
					num = 2;
				}
				break;
			case 3:
				if (!value.IsEmpty)
				{
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 != 0)
					{
						num = 0;
					}
					break;
				}
				goto case 1;
			case 2:
				return;
			}
		}
	}

	internal static bool InstantiateProducer()
	{
		return AwakeProducer == null;
	}

	internal static WriterSingleton LoginProducer()
	{
		return AwakeProducer;
	}
}
