using System;

namespace AzuAnticheat.Internal;

internal class ContextAuthentication : ServerSetter
{
	internal static ContextAuthentication FillImporter;

	bool ServerSetter.Resolve(OrderSingleton? nodeEvent, ref Type currentType)
	{
		int num = 2;
		int num2 = num;
		RoleSingleton tag = default(RoleSingleton);
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			switch (num2)
			{
			default:
				if (tag.IsEmpty)
				{
					num2 = 5;
					continue;
				}
				break;
			case 4:
				throw new ReaderSingleton(in start, nodeEvent.End, string.Format(DicSingleton.gE3WbyDVW(-1880453928 ^ -1880431024), nodeEvent.Tag));
			case 5:
				return false;
			case 1:
				tag = nodeEvent.Tag;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
				{
					num2 = 0;
				}
				continue;
			case 2:
				if (nodeEvent != null)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 != 0)
					{
						num2 = 1;
					}
					continue;
				}
				goto case 5;
			case 3:
				break;
			}
			start = nodeEvent.Start;
			num2 = 4;
		}
	}

	public ContextAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool FlushImporter()
	{
		return FillImporter == null;
	}

	internal static ContextAuthentication DestroyImporter()
	{
		return FillImporter;
	}
}
