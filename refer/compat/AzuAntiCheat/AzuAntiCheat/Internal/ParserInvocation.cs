using System;
using System.Collections.Generic;
using System.Linq;

namespace AzuAnticheat.Internal;

internal sealed class ParserInvocation : ConfigInvocation
{
	private readonly AdvisorSetter requestInvocation;

	internal static ParserInvocation RestartProxy;

	public ParserInvocation(AdvisorSetter innerTypeDescriptor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			}
			requestInvocation = innerTypeDescriptor ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-166253478 ^ -166244580));
			num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb != 0)
			{
				num = 1;
			}
		}
	}

	public override IEnumerable<RegSetter> GetProperties(Type type, object? container)
	{
		return from p in requestInvocation.GetProperties(type, container)
			where p.CanWrite
			select p;
	}

	internal static bool GetProxy()
	{
		return RestartProxy == null;
	}

	internal static ParserInvocation CalculateProxy()
	{
		return RestartProxy;
	}
}
