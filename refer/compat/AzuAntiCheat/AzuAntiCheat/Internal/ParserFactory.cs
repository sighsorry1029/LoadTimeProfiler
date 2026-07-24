using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class ParserFactory : ModelFactory
{
	internal static ParserFactory RevertError;

	public HelperReader Value { get; }

	public ParserFactory(HelperReader value)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(value, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c != 0)
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
	public ParserFactory(HelperReader value, QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 == 0)
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
				if (!value.IsEmpty)
				{
					num = 2;
					break;
				}
				goto case 3;
			case 3:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1059662249 ^ -1059676673));
			case 2:
				_RequestFactory = value;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 != 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool InvokeReader()
	{
		return RevertError == null;
	}

	internal static ParserFactory PublishReader()
	{
		return RevertError;
	}
}
