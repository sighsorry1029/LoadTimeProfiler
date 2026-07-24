using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal class TestsFactory : Exception
{
	[CompilerGenerated]
	private readonly QueueReader m_PageFactory;

	internal static TestsFactory GetError;

	public QueueReader Start { get; }

	public QueueReader End
	{
		[CompilerGenerated]
		get
		{
			return m_PageFactory;
		}
	}

	public TestsFactory(string message)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(QueueReader.m_CollectionReader, QueueReader.m_CollectionReader, message);
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

	public TestsFactory(QueueReader start, QueueReader end, string message)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(start, end, message, null);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public TestsFactory(QueueReader start, QueueReader end, string message, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] Exception innerException)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(string.Format(DicSingleton.gE3WbyDVW(-32257720 ^ -32284268), start, end, message), innerException);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
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
				_InitializerFactory = start;
				num = 2;
				break;
			case 2:
				m_PageFactory = end;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef != 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public TestsFactory(string message, Exception inner)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(QueueReader.m_CollectionReader, QueueReader.m_CollectionReader, message, inner);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool CalculateError()
	{
		return GetError == null;
	}

	internal static TestsFactory MoveError()
	{
		return GetError;
	}
}
