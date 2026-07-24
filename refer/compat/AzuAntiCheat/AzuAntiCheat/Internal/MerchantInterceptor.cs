using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class MerchantInterceptor : StrategyInterceptor
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public Type attrInterceptor;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public object m_MessageInterceptor;

		internal static _003C_003Ec__DisplayClass3_0 DeleteUtils;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)]
		internal IEnumerable<RequestPrototype> _003CGetProperties_003Eb__0(InstancePrototype i)
		{
			return i.GetProperties(attrInterceptor, m_MessageInterceptor);
		}

		internal static bool FillUtils()
		{
			return DeleteUtils == null;
		}

		internal static _003C_003Ec__DisplayClass3_0 FlushUtils()
		{
			return DeleteUtils;
		}
	}

	private readonly IEnumerable<InstancePrototype> _TestInterceptor;

	internal static MerchantInterceptor StopUtils;

	public MerchantInterceptor(params InstancePrototype[] typeInspectors)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector((IEnumerable<InstancePrototype>)typeInspectors);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public MerchantInterceptor(IEnumerable<InstancePrototype> typeInspectors)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		_TestInterceptor = typeInspectors?.ToList() ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1385030784 ^ -1385006864));
	}

	public override IEnumerable<RequestPrototype> GetProperties(Type type, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object container)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals4.attrInterceptor = type;
		CS_0024_003C_003E8__locals4.m_MessageInterceptor = container;
		return _TestInterceptor.SelectMany([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (InstancePrototype i) => i.GetProperties(CS_0024_003C_003E8__locals4.attrInterceptor, CS_0024_003C_003E8__locals4.m_MessageInterceptor));
	}

	internal static bool ExcludeUtils()
	{
		return StopUtils == null;
	}

	internal static MerchantInterceptor InterruptUtils()
	{
		return StopUtils;
	}
}
