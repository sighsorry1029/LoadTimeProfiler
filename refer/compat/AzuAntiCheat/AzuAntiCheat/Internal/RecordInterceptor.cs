using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class RecordInterceptor : StrategyInterceptor
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public RecordInterceptor parameterInterceptor;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public object m_StatusInterceptor;

		internal static _003C_003Ec__DisplayClass3_0 OrderUtils;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal List<RequestPrototype> _003CGetProperties_003Eb__0(Type t)
		{
			return parameterInterceptor._ServiceInterceptor.GetProperties(t, m_StatusInterceptor).ToList();
		}

		internal static bool UpdateUtils()
		{
			return OrderUtils == null;
		}

		internal static _003C_003Ec__DisplayClass3_0 SearchUtils()
		{
			return OrderUtils;
		}
	}

	private readonly InstancePrototype _ServiceInterceptor;

	private readonly ConcurrentDictionary<Type, List<RequestPrototype>> _BridgeInterceptor;

	private static RecordInterceptor InsertUtils;

	public RecordInterceptor(InstancePrototype innerTypeDescriptor)
	{
		GetterIssuer.DeleteInitializer();
		_BridgeInterceptor = new ConcurrentDictionary<Type, List<RequestPrototype>>();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 != 0)
		{
			num = 1;
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
				_ServiceInterceptor = innerTypeDescriptor ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1817326817 ^ -1817335719));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public override IEnumerable<RequestPrototype> GetProperties(Type type, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object container)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals4.parameterInterceptor = this;
		CS_0024_003C_003E8__locals4.m_StatusInterceptor = container;
		return _BridgeInterceptor.GetOrAdd(type, (Type t) => CS_0024_003C_003E8__locals4.parameterInterceptor._ServiceInterceptor.GetProperties(t, CS_0024_003C_003E8__locals4.m_StatusInterceptor).ToList());
	}

	internal static bool FindUtils()
	{
		return InsertUtils == null;
	}

	internal static RecordInterceptor VisitUtils()
	{
		return InsertUtils;
	}
}
