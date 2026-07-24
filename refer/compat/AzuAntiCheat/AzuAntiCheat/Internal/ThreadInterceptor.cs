namespace AzuAnticheat.Internal;

internal sealed class ThreadInterceptor
{
	public static class MappingInterceptor
	{
	}

	internal static ThreadInterceptor NewProcess;

	public ThreadInterceptor()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool AddProcess()
	{
		return NewProcess == null;
	}

	internal static ThreadInterceptor PrepareProcess()
	{
		return NewProcess;
	}
}
