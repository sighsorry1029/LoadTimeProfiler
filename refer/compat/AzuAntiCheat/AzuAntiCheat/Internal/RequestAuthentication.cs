using System;
using System.Collections;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal sealed class RequestAuthentication : WrapperSetter
{
	internal static RequestAuthentication CalcMock;

	public bool Deserialize(CandidateInterpreter parser, Type expectedType, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, out object? value)
	{
		Type type;
		if (expectedType == typeof(IEnumerable))
		{
			type = typeof(object);
		}
		else
		{
			Type implementedGenericInterface = MockInvocation.GetImplementedGenericInterface(expectedType, typeof(IEnumerable<>));
			if (implementedGenericInterface != expectedType)
			{
				value = null;
				return false;
			}
			type = implementedGenericInterface.GetGenericArguments()[0];
		}
		Type arg = typeof(List<>).MakeGenericType(type);
		value = nestedObjectDeserializer(parser, arg);
		return true;
	}

	public RequestAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool LogoutMock()
	{
		return CalcMock == null;
	}

	internal static RequestAuthentication CountMock()
	{
		return CalcMock;
	}
}
