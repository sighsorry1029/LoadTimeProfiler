using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class TestsInterceptor
{
	private readonly IDictionary<string, object> _InitializerInterceptor;

	private readonly IDictionary<object, string> m_PageInterceptor;

	internal static TestsInterceptor SetupUtils;

	public object this[string anchor]
	{
		get
		{
			int num = 2;
			int num2 = num;
			object value = default(object);
			while (true)
			{
				switch (num2)
				{
				case 2:
					if (!_InitializerInterceptor.TryGetValue(anchor, out value))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 != 0)
						{
							num2 = 0;
						}
						break;
					}
					goto default;
				default:
					return value;
				case 1:
					throw new MapperReader(DicSingleton.gE3WbyDVW(0x2D27936 ^ 0x2D21B54) + anchor + DicSingleton.gE3WbyDVW(0x4995986C ^ 0x4995FA12));
				}
			}
		}
	}

	public void Add(string anchor, object @object)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 3:
				return;
			case 4:
				return;
			default:
				if (@object == null)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 != 0)
					{
						num2 = 4;
					}
					break;
				}
				goto case 2;
			case 2:
				m_PageInterceptor.Add(@object, anchor);
				num2 = 3;
				break;
			case 1:
				_InitializerInterceptor.Add(anchor, @object);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public bool TryGetAnchor(object @object, [StrategyBase(false)][_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] out string anchor)
	{
		return m_PageInterceptor.TryGetValue(@object, out anchor);
	}

	public TestsInterceptor()
	{
		GetterIssuer.DeleteInitializer();
		_InitializerInterceptor = new Dictionary<string, object>();
		m_PageInterceptor = new Dictionary<object, string>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool SelectUtils()
	{
		return SetupUtils == null;
	}

	internal static TestsInterceptor ChangeUtils()
	{
		return SetupUtils;
	}
}
