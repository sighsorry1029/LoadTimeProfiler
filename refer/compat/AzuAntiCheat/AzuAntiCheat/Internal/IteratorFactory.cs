using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class IteratorFactory : ModelFactory
{
	[CompilerGenerated]
	private readonly string clientFactory;

	[CompilerGenerated]
	private readonly bool recordFactory;

	private static IteratorFactory PrintReader;

	public string Value
	{
		[CompilerGenerated]
		get
		{
			return clientFactory;
		}
	}

	public bool IsInline
	{
		[CompilerGenerated]
		get
		{
			return recordFactory;
		}
	}

	public IteratorFactory(string value, bool isInline)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(value, isInline, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public IteratorFactory(string value, bool isInline, QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end);
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 2:
				recordFactory = isInline;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			case 1:
				clientFactory = value ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x4097B854 ^ 0x4097F3FC));
				num = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool CompareReader()
	{
		return PrintReader == null;
	}

	internal static IteratorFactory CloneReader()
	{
		return PrintReader;
	}
}
