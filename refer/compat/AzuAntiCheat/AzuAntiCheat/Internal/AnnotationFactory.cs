using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class AnnotationFactory : ModelFactory
{
	private static AnnotationFactory ForgotReader;

	public AnnotationFactory()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
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
	public AnnotationFactory(QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool RestartReader()
	{
		return ForgotReader == null;
	}

	internal static AnnotationFactory GetReader()
	{
		return ForgotReader;
	}
}
