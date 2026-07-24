namespace AzuAnticheat.Internal;

internal sealed class AttrSetter : TestsSetter
{
	internal static AttrSetter PublishObserver;

	public AttrSetter(ImporterSetter source)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(source);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool RegisterObserver()
	{
		return PublishObserver == null;
	}

	internal static AttrSetter SetupObserver()
	{
		return PublishObserver;
	}
}
