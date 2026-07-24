using System;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal sealed class HelperAuthentication : ServerSetter
{
	internal static HelperAuthentication UpdateImporter;

	bool ServerSetter.Resolve(OrderSingleton? nodeEvent, ref Type currentType)
	{
		int num = 7;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				currentType = typeof(List<object>);
				num2 = 3;
				break;
			case 3:
				return true;
			default:
				currentType = typeof(Dictionary<object, object>);
				num2 = 2;
				break;
			case 2:
				return true;
			case 4:
			case 6:
				return false;
			case 7:
				if (!(currentType == typeof(object)))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
					{
						num2 = 6;
					}
					break;
				}
				goto case 5;
			case 5:
				if (!(nodeEvent is ExporterSingleton))
				{
					if (!(nodeEvent is FacadeSingleton))
					{
						num2 = 4;
						break;
					}
					goto default;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	public HelperAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool SearchImporter()
	{
		return UpdateImporter == null;
	}

	internal static HelperAuthentication StopImporter()
	{
		return UpdateImporter;
	}
}
