using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[Obsolete("The mechanism that this class uses to specify type names is non-standard. Register the tags explicitly instead of using this convention.")]
internal sealed class IndexerFilter : TaskPrototype
{
	private static IndexerFilter PrintInstance;

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	bool TaskPrototype.Resolve([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] ListenerFactory nodeEvent, ref Type currentType)
	{
		int num = 6;
		int num2 = num;
		ValueFactory tag = default(ValueFactory);
		Type type = default(Type);
		while (true)
		{
			switch (num2)
			{
			case 10:
				tag = nodeEvent.Tag;
				num2 = 2;
				break;
			case 6:
				if (nodeEvent == null)
				{
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 7;
			case 1:
				currentType = type;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
				{
					num2 = 9;
				}
				break;
			case 3:
				if (tag.IsEmpty)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 10;
			case 7:
				tag = nodeEvent.Tag;
				num2 = 3;
				break;
			case 2:
				type = Type.GetType(tag.Value.Substring(1), throwOnError: false);
				num2 = 8;
				break;
			case 9:
				return true;
			default:
				return false;
			case 8:
				if (!(type != null))
				{
					num2 = 4;
					break;
				}
				goto case 1;
			}
		}
	}

	public IndexerFilter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool CompareInstance()
	{
		return PrintInstance == null;
	}

	internal static IndexerFilter CloneInstance()
	{
		return PrintInstance;
	}
}
