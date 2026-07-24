using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal abstract class ModelFactory
{
	[CompilerGenerated]
	private readonly QueueReader advisorFactory;

	[CompilerGenerated]
	private readonly QueueReader connectionFactory;

	private static ModelFactory ReflectReader;

	public QueueReader Start
	{
		[CompilerGenerated]
		get
		{
			return advisorFactory;
		}
	}

	public QueueReader End
	{
		[CompilerGenerated]
		get
		{
			return connectionFactory;
		}
	}

	protected ModelFactory(QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 2;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			case 2:
				advisorFactory = start ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x3A437A88 ^ 0x3A43D01C));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
				{
					num = 0;
				}
				break;
			default:
				connectionFactory = end ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x7A125A0E ^ 0x7A12F0AC));
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
				{
					num = 1;
				}
				break;
			}
		}
	}

	internal static bool CollectReader()
	{
		return ReflectReader == null;
	}

	internal static ModelFactory ManageReader()
	{
		return ReflectReader;
	}
}
