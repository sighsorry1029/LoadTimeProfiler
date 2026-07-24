using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class FilterInterceptor
{
	private readonly IDictionary<string, Type> readerInterceptor;

	internal static FilterInterceptor InitMerchant;

	public FilterInterceptor()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c != 0)
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
			readerInterceptor = new Dictionary<string, Type>();
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 != 0)
			{
				num = 1;
			}
		}
	}

	public FilterInterceptor(IDictionary<string, Type> mappings)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		readerInterceptor = new Dictionary<string, Type>(mappings);
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
			case 0:
				return;
			case 1:
				readerInterceptor.Add(tag, mapping);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	internal Type GetMapping(string tag)
	{
		int num = 2;
		int num2 = num;
		Type value = default(Type);
		while (true)
		{
			switch (num2)
			{
			default:
				return null;
			case 1:
				return value;
			case 2:
				if (readerInterceptor.TryGetValue(tag, out value))
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto default;
			}
		}
	}

	internal static bool PatchMerchant()
	{
		return InitMerchant == null;
	}

	internal static FilterInterceptor AssetMerchant()
	{
		return InitMerchant;
	}
}
