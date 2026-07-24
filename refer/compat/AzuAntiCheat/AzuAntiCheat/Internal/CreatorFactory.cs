using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class CreatorFactory : ModelFactory
{
	[CompilerGenerated]
	private readonly string m_PrinterFactory;

	[CompilerGenerated]
	private readonly string databaseFactory;

	internal static CreatorFactory IncludeReader;

	public string Handle
	{
		[CompilerGenerated]
		get
		{
			return m_PrinterFactory;
		}
	}

	public string Suffix
	{
		[CompilerGenerated]
		get
		{
			return databaseFactory;
		}
	}

	public CreatorFactory(string handle, string suffix)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(handle, suffix, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public CreatorFactory(string handle, string suffix, QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 2:
				return;
			default:
				m_PrinterFactory = handle ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-2103041941 ^ -2103015057));
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
				{
					num = 1;
				}
				break;
			case 1:
				databaseFactory = suffix ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1053593978 ^ -1053571182));
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 != 0)
				{
					num = 2;
				}
				break;
			}
		}
	}

	internal static bool CheckReader()
	{
		return IncludeReader == null;
	}

	internal static CreatorFactory RateReader()
	{
		return IncludeReader;
	}
}
