using System;

namespace AzuAnticheat.Internal;

internal abstract class CandidateWriter
{
	internal static CandidateWriter UpdateBridge;

	public virtual bool IsKnownType(Type type)
	{
		throw new NotImplementedException();
	}

	public virtual ConnectionSetter GetTypeResolver()
	{
		throw new NotImplementedException();
	}

	public virtual MapAuthentication GetFactory()
	{
		throw new NotImplementedException();
	}

	public virtual AdvisorSetter GetTypeInspector()
	{
		throw new NotImplementedException();
	}

	protected CandidateWriter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool SearchBridge()
	{
		return UpdateBridge == null;
	}

	internal static CandidateWriter StopBridge()
	{
		return UpdateBridge;
	}
}
