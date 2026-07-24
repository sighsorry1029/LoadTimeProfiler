using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ParamFactory : ModelFactory
{
	[CompilerGenerated]
	private readonly HelperReader facadeFactory;

	private static ParamFactory RegisterReader;

	public HelperReader Value
	{
		[CompilerGenerated]
		get
		{
			return facadeFactory;
		}
	}

	public ParamFactory(HelperReader value)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(value, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
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

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public ParamFactory(HelperReader value, QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end);
		int num = 2;
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 2:
				if (value.IsEmpty)
				{
					num = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
					{
						num = 1;
					}
					break;
				}
				facadeFactory = value;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			case 1:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1908521178 ^ -1908536178));
			}
		}
	}

	internal static bool SetupReader()
	{
		return RegisterReader == null;
	}

	internal static ParamFactory SelectReader()
	{
		return RegisterReader;
	}
}
