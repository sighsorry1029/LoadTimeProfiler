using System;
using System.Diagnostics;
using System.Text;

namespace AzuAnticheat.Internal;

[DebuggerStepThrough]
internal static class ReponseAttribute
{
	internal readonly struct ModelAttribute : IDisposable
	{
		public readonly StringBuilder m_AdvisorAttribute;

		private readonly ContainerAttribute<StringBuilder> _ConnectionAttribute;

		private static object QueryAttribute;

		public ModelAttribute(StringBuilder builder, ContainerAttribute<StringBuilder> pool)
		{
			GetterIssuer.DeleteInitializer();
			m_AdvisorAttribute = builder;
			_ConnectionAttribute = pool;
		}

		public override string ToString()
		{
			return m_AdvisorAttribute.ToString();
		}

		public void Dispose()
		{
			int num = 1;
			int num2 = num;
			StringBuilder advisorAttribute = default(StringBuilder);
			while (true)
			{
				switch (num2)
				{
				case 3:
					return;
				case 1:
					advisorAttribute = m_AdvisorAttribute;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
					{
						num2 = 0;
					}
					continue;
				case 4:
					_ConnectionAttribute.Free(advisorAttribute);
					num2 = 3;
					continue;
				case 2:
					advisorAttribute.Length = 0;
					num2 = 4;
					continue;
				}
				if (advisorAttribute.Capacity > 1024)
				{
					return;
				}
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
				{
					num2 = 2;
				}
			}
		}

		internal static bool AwakeAttribute()
		{
			return QueryAttribute == null;
		}

		internal static object InstantiateAttribute()
		{
			return QueryAttribute;
		}
	}

	private static readonly ContainerAttribute<StringBuilder> _ProxyAttribute;

	internal static ReponseAttribute DestroyAttribute;

	static ReponseAttribute()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				_ProxyAttribute = new ContainerAttribute<StringBuilder>(() => new StringBuilder());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 2:
				GetterIssuer.DeleteInitializer();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 != 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	public static ModelAttribute Rent()
	{
		return new ModelAttribute(_ProxyAttribute.Allocate(), _ProxyAttribute);
	}

	internal static bool ComputeAttribute()
	{
		return DestroyAttribute == null;
	}

	internal static ReponseAttribute DisableAttribute()
	{
		return DestroyAttribute;
	}
}
