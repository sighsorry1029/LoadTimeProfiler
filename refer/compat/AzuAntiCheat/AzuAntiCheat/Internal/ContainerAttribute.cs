using System;
using System.Diagnostics;
using System.Threading;

namespace AzuAnticheat.Internal;

[DebuggerStepThrough]
internal sealed class ContainerAttribute<T> where T : class
{
	[DebuggerDisplay("{value,nq}")]
	private struct ServiceAttribute
	{
		internal T? bridgeAttribute;
	}

	internal delegate T ParameterAttribute();

	private T? iteratorAttribute;

	private readonly ServiceAttribute[] m_ClientAttribute;

	private readonly ParameterAttribute recordAttribute;

	internal static object RevertToken;

	internal ContainerAttribute(ParameterAttribute factory)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(factory, Environment.ProcessorCount * 2);
	}

	internal ContainerAttribute(ParameterAttribute factory, int size)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		recordAttribute = factory;
		m_ClientAttribute = new ServiceAttribute[size - 1];
	}

	private T CreateInstance()
	{
		return recordAttribute();
	}

	internal T Allocate()
	{
		T val = iteratorAttribute;
		if (val == null || val != Interlocked.CompareExchange(ref iteratorAttribute, null, val))
		{
			val = AllocateSlow();
		}
		return val;
	}

	private T AllocateSlow()
	{
		ServiceAttribute[] clientAttribute = m_ClientAttribute;
		for (int i = 0; i < clientAttribute.Length; i++)
		{
			T bridgeAttribute = clientAttribute[i].bridgeAttribute;
			if (bridgeAttribute != null && bridgeAttribute == Interlocked.CompareExchange(ref clientAttribute[i].bridgeAttribute, null, bridgeAttribute))
			{
				return bridgeAttribute;
			}
		}
		return CreateInstance();
	}

	internal void Free(T obj)
	{
		if (iteratorAttribute == null)
		{
			iteratorAttribute = obj;
		}
		else
		{
			FreeSlow(obj);
		}
	}

	private void FreeSlow(T obj)
	{
		ServiceAttribute[] clientAttribute = m_ClientAttribute;
		for (int i = 0; i < clientAttribute.Length; i++)
		{
			if (clientAttribute[i].bridgeAttribute == null)
			{
				clientAttribute[i].bridgeAttribute = obj;
				break;
			}
		}
	}

	[Conditional("DEBUG")]
	private void Validate(object obj)
	{
		int num = 6;
		int num3 = default(int);
		ServiceAttribute[] clientAttribute = default(ServiceAttribute[]);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 0:
					return;
				case 5:
					num3 = 0;
					num2 = 4;
					continue;
				case 2:
					return;
				case 1:
				case 4:
					if (num3 >= clientAttribute.Length)
					{
						return;
					}
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
					{
						num2 = 2;
					}
					continue;
				case 3:
				case 7:
					if (clientAttribute[num3].bridgeAttribute != null)
					{
						num3++;
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
						{
							num2 = 0;
						}
					}
					else
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
						{
							num2 = 0;
						}
					}
					continue;
				case 6:
					break;
				}
				break;
			}
			clientAttribute = m_ClientAttribute;
			num = 5;
		}
	}

	internal static bool InvokeAttribute()
	{
		return RevertToken == null;
	}

	internal static object PublishAttribute()
	{
		return RevertToken;
	}
}
