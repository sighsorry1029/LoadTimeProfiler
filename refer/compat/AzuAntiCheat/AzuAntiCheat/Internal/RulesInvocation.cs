using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal sealed class RulesInvocation
{
	private readonly IDictionary<string, object> m_GetterInvocation;

	private readonly IDictionary<object, string> m_CodeInvocation;

	internal static RulesInvocation PrintProxy;

	public object this[string anchor]
	{
		get
		{
			int num = 1;
			int num2 = num;
			object value = default(object);
			while (true)
			{
				switch (num2)
				{
				default:
					return value;
				case 1:
					if (!m_GetterInvocation.TryGetValue(anchor, out value))
					{
						throw new ProcessorAttribute(DicSingleton.gE3WbyDVW(0x166FBD ^ 0x160DDF) + anchor + DicSingleton.gE3WbyDVW(-359091888 ^ -359083218));
					}
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
					{
						num2 = 0;
					}
					break;
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
			case 1:
				m_GetterInvocation.Add(anchor, @object);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
				{
					num2 = 0;
				}
				continue;
			case 2:
				return;
			case 3:
				return;
			default:
				if (@object == null)
				{
					num2 = 3;
					continue;
				}
				break;
			case 4:
				break;
			}
			m_CodeInvocation.Add(@object, anchor);
			num2 = 2;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 == 0)
			{
				num2 = 2;
			}
		}
	}

	public bool TryGetAnchor(object @object, [ReponseSingleton(false)] out string? anchor)
	{
		return m_CodeInvocation.TryGetValue(@object, out anchor);
	}

	public RulesInvocation()
	{
		GetterIssuer.DeleteInitializer();
		m_GetterInvocation = new Dictionary<string, object>();
		m_CodeInvocation = new Dictionary<object, string>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool CompareProxy()
	{
		return PrintProxy == null;
	}

	internal static RulesInvocation CloneProxy()
	{
		return PrintProxy;
	}
}
