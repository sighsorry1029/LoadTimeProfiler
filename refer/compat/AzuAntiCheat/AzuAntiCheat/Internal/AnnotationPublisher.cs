using JetBrains.Annotations;

namespace AzuAnticheat.Internal;

internal class AnnotationPublisher
{
	[UsedImplicitly]
	public bool? _ProcessPublisher;

	private static AnnotationPublisher FlushWrapper;

	public AnnotationPublisher()
	{
		GetterIssuer.DeleteInitializer();
		_ProcessPublisher = false;
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool DestroyWrapper()
	{
		return FlushWrapper == null;
	}

	internal static AnnotationPublisher ComputeWrapper()
	{
		return FlushWrapper;
	}
}
