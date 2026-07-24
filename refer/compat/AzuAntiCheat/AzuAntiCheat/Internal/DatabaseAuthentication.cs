using System;
using System.Collections;

namespace AzuAnticheat.Internal;

internal class DatabaseAuthentication : RegistryAuthentication, WrapperSetter
{
	private readonly MapAuthentication _ErrorAuthentication;

	private static DatabaseAuthentication CustomizeMock;

	public DatabaseAuthentication(MapAuthentication objectFactory, bool duplicateKeyChecking)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(duplicateKeyChecking);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 != 0)
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
			_ErrorAuthentication = objectFactory ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x9000142 ^ 0x90057EA));
			num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 != 0)
			{
				num = 1;
			}
		}
	}

	public bool Deserialize(CandidateInterpreter reader, Type expectedType, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, out object? value)
	{
		if (_ErrorAuthentication.IsDictionary(expectedType))
		{
			if (!(_ErrorAuthentication.Create(expectedType) is IDictionary dictionary))
			{
				value = null;
				return false;
			}
			Type keyType = _ErrorAuthentication.GetKeyType(expectedType);
			Type valueType = _ErrorAuthentication.GetValueType(expectedType);
			value = dictionary;
			base.Deserialize(keyType, valueType, reader, nestedObjectDeserializer, dictionary);
			return true;
		}
		value = null;
		return false;
	}

	internal static bool CancelMock()
	{
		return CustomizeMock == null;
	}

	internal static DatabaseAuthentication ReflectMock()
	{
		return CustomizeMock;
	}
}
