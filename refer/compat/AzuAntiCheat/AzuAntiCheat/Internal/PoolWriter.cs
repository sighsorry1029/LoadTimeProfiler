using System;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal sealed class PoolWriter
{
	private readonly IDictionary<string, Type> _DescriptorWriter;

	internal static PoolWriter CalcOrder;

	public PoolWriter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 1:
				_DescriptorWriter = new Dictionary<string, Type>();
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public PoolWriter(IDictionary<string, Type> mappings)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		_DescriptorWriter = new Dictionary<string, Type>(mappings);
	}

	public void Add(string tag, Type mapping)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				_DescriptorWriter.Add(tag, mapping);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal Type? GetMapping(string tag)
	{
		int num = 1;
		int num2 = num;
		Type value = default(Type);
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (_DescriptorWriter.TryGetValue(tag, out value))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			case 2:
				return null;
			default:
				return value;
			}
		}
	}

	internal static bool LogoutOrder()
	{
		return CalcOrder == null;
	}

	internal static PoolWriter CountOrder()
	{
		return CalcOrder;
	}
}
