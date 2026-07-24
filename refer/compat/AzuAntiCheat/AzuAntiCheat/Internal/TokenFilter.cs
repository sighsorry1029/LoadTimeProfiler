using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal class TokenFilter : TaskPrototype
{
	private readonly IDictionary<Type, Type> m_CallbackFilter;

	internal static TokenFilter PopInstance;

	public TokenFilter(IDictionary<Type, Type> mappings)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		if (mappings == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x4995986C ^ 0x4995F218));
		}
		foreach (KeyValuePair<Type, Type> mapping in mappings)
		{
			if (!mapping.Key.IsAssignableFrom(mapping.Value))
			{
				throw new InvalidOperationException(string.Format(DicSingleton.gE3WbyDVW(0x40385DA3 ^ 0x4038341F), mapping.Value, mapping.Key));
			}
		}
		m_CallbackFilter = mappings;
	}

	public bool Resolve([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] ListenerFactory nodeEvent, ref Type currentType)
	{
		int num = 1;
		int num2 = num;
		Type value = default(Type);
		while (true)
		{
			switch (num2)
			{
			default:
				currentType = value;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				return true;
			case 1:
				if (!m_CallbackFilter.TryGetValue(currentType, out value))
				{
					return false;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool PostInstance()
	{
		return PopInstance == null;
	}

	internal static TokenFilter CallInstance()
	{
		return PopInstance;
	}
}
