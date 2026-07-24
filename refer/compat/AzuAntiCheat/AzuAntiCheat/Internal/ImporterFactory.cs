using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ImporterFactory : ModelFactory
{
	internal static ImporterFactory RemoveReader;

	public ImporterFactory()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
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
	public ImporterFactory(QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ResolveReader()
	{
		return RemoveReader == null;
	}

	internal static ImporterFactory DefineReader()
	{
		return RemoveReader;
	}
}
