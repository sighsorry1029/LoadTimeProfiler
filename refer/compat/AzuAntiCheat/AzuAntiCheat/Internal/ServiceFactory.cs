using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ServiceFactory : ModelFactory
{
	internal static ServiceFactory ReadReader;

	public ServiceFactory()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 != 0)
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
	public ServiceFactory(QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ViewReader()
	{
		return ReadReader == null;
	}

	internal static ServiceFactory InitReader()
	{
		return ReadReader;
	}
}
