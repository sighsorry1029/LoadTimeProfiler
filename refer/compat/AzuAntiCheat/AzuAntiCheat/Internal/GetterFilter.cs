using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class GetterFilter : TaskPrototype
{
	private readonly IDictionary<ValueFactory, Type> _CodeFilter;

	internal static GetterFilter AddInstance;

	public GetterFilter(IDictionary<ValueFactory, Type> tagMappings)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		_CodeFilter = tagMappings ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-360128320 ^ -360150510));
	}

	bool TaskPrototype.Resolve([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] ListenerFactory nodeEvent, ref Type currentType)
	{
		int num = 3;
		int num2 = num;
		ValueFactory tag = default(ValueFactory);
		Type value = default(Type);
		while (true)
		{
			switch (num2)
			{
			default:
				if (tag.IsEmpty)
				{
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 != 0)
					{
						num2 = 5;
					}
					break;
				}
				goto case 4;
			case 3:
				if (nodeEvent != null)
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
					{
						num2 = 2;
					}
					break;
				}
				goto case 5;
			case 6:
				currentType = value;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				tag = nodeEvent.Tag;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 == 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				return true;
			case 5:
				return false;
			case 4:
				if (_CodeFilter.TryGetValue(nodeEvent.Tag, out value))
				{
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 5;
			}
		}
	}

	internal static bool PrepareInstance()
	{
		return AddInstance == null;
	}

	internal static GetterFilter WriteInstance()
	{
		return AddInstance;
	}
}
