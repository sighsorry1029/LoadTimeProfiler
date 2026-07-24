using System;
using System.Collections.Generic;
using System.Linq;

namespace AzuAnticheat.Internal;

internal sealed class MethodInvocation : IDisposable
{
	private readonly IDictionary<Type, object> m_TemplateInvocation;

	private static MethodInvocation SetProxy;

	public T Get<T>() where T : class, new()
	{
		if (!m_TemplateInvocation.TryGetValue(typeof(T), out object value))
		{
			value = new T();
			m_TemplateInvocation.Add(typeof(T), value);
		}
		return (T)value;
	}

	public void OnDeserialization()
	{
		int num = 1;
		int num2 = num;
		IEnumerator<IdentifierInvocation> enumerator = default(IEnumerator<IdentifierInvocation>);
		while (true)
		{
			switch (num2)
			{
			case 1:
				enumerator = m_TemplateInvocation.Values.OfType<IdentifierInvocation>().GetEnumerator();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
				{
					num2 = 0;
				}
				continue;
			case 2:
				return;
			}
			try
			{
				while (true)
				{
					int num3;
					if (!enumerator.MoveNext())
					{
						num3 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
						{
							num3 = 1;
						}
						goto IL_007d;
					}
					goto IL_00b9;
					IL_00b9:
					enumerator.Current.OnDeserialization();
					int num4 = 2;
					num3 = num4;
					goto IL_007d;
					IL_007d:
					switch (num3)
					{
					case 2:
						break;
					default:
						goto IL_00b9;
					case 1:
						return;
					}
				}
			}
			finally
			{
				if (enumerator != null)
				{
					int num5 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 != 0)
					{
						num5 = 1;
					}
					while (true)
					{
						switch (num5)
						{
						case 1:
							enumerator.Dispose();
							num5 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 != 0)
							{
								num5 = 0;
							}
							continue;
						case 0:
							break;
						}
						break;
					}
				}
			}
		}
	}

	public void Dispose()
	{
		foreach (IDisposable item in m_TemplateInvocation.Values.OfType<IDisposable>())
		{
			item.Dispose();
		}
	}

	public MethodInvocation()
	{
		GetterIssuer.DeleteInitializer();
		m_TemplateInvocation = new Dictionary<Type, object>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool PushProxy()
	{
		return SetProxy == null;
	}

	internal static MethodInvocation ValidateProxy()
	{
		return SetProxy;
	}
}
