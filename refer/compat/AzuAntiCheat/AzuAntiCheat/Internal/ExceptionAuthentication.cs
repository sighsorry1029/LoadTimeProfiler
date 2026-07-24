using System;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal class ExceptionAuthentication : ServerSetter
{
	private readonly IDictionary<Type, Type> itemAuthentication;

	internal static ExceptionAuthentication ExcludeImporter;

	public ExceptionAuthentication(IDictionary<Type, Type> mappings)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		if (mappings == null)
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-2075300707 ^ -2075326743));
		}
		foreach (KeyValuePair<Type, Type> mapping in mappings)
		{
			if (!mapping.Key.IsAssignableFrom(mapping.Value))
			{
				throw new InvalidOperationException(string.Format(DicSingleton.gE3WbyDVW(0x166FBD ^ 0x160601), mapping.Value, mapping.Key));
			}
		}
		itemAuthentication = mappings;
	}

	public bool Resolve(OrderSingleton? nodeEvent, ref Type currentType)
	{
		int num = 1;
		int num2 = num;
		Type value = default(Type);
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (itemAuthentication.TryGetValue(currentType, out value))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
					{
						num2 = 0;
					}
					break;
				}
				return false;
			case 2:
				return true;
			default:
				currentType = value;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc != 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	internal static bool InterruptImporter()
	{
		return ExcludeImporter == null;
	}

	internal static ExceptionAuthentication DeleteImporter()
	{
		return ExcludeImporter;
	}
}
