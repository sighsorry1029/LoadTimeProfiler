using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ProductInvocation : ConfigInvocation
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public ProductInvocation _ValueInvocation;

		public object decoratorInvocation;

		internal static _003C_003Ec__DisplayClass3_0 ResolveProxy;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal List<RegSetter> _003CGetProperties_003Eb__0(Type t)
		{
			return _ValueInvocation.registryInvocation.GetProperties(t, decoratorInvocation).ToList();
		}

		internal static bool DefineProxy()
		{
			return ResolveProxy == null;
		}

		internal static _003C_003Ec__DisplayClass3_0 IncludeProxy()
		{
			return ResolveProxy;
		}
	}

	private readonly AdvisorSetter registryInvocation;

	private readonly ConcurrentDictionary<Type, List<RegSetter>> m_StateInvocation;

	internal static ProductInvocation ConnectProxy;

	public ProductInvocation(AdvisorSetter innerTypeDescriptor)
	{
		GetterIssuer.DeleteInitializer();
		m_StateInvocation = new ConcurrentDictionary<Type, List<RegSetter>>();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 0:
				return;
			case 1:
				registryInvocation = innerTypeDescriptor ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-380885952 ^ -380877050));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public override IEnumerable<RegSetter> GetProperties(Type type, object? container)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals4._ValueInvocation = this;
		CS_0024_003C_003E8__locals4.decoratorInvocation = container;
		return m_StateInvocation.GetOrAdd(type, (Type t) => CS_0024_003C_003E8__locals4._ValueInvocation.registryInvocation.GetProperties(t, CS_0024_003C_003E8__locals4.decoratorInvocation).ToList());
	}

	internal static bool StartProxy()
	{
		return ConnectProxy == null;
	}

	internal static ProductInvocation RemoveProxy()
	{
		return ConnectProxy;
	}
}
