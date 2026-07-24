using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class BroadcasterInvocation : ConfigInvocation
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public Type _TaskInvocation;

		public object utilsInvocation;

		private static _003C_003Ec__DisplayClass3_0 CustomizeProxy;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal IEnumerable<RegSetter> _003CGetProperties_003Eb__0(AdvisorSetter i)
		{
			return i.GetProperties(_TaskInvocation, utilsInvocation);
		}

		internal static bool CancelProxy()
		{
			return CustomizeProxy == null;
		}

		internal static _003C_003Ec__DisplayClass3_0 ReflectProxy()
		{
			return CustomizeProxy;
		}
	}

	private readonly IEnumerable<AdvisorSetter> m_WorkerInvocation;

	internal static BroadcasterInvocation CheckProxy;

	public BroadcasterInvocation(params AdvisorSetter[] typeInspectors)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector((IEnumerable<AdvisorSetter>)typeInspectors);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public BroadcasterInvocation(IEnumerable<AdvisorSetter> typeInspectors)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		m_WorkerInvocation = typeInspectors?.ToList() ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1123846595 ^ -1123871411));
	}

	public override IEnumerable<RegSetter> GetProperties(Type type, object? container)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals4._TaskInvocation = type;
		CS_0024_003C_003E8__locals4.utilsInvocation = container;
		return m_WorkerInvocation.SelectMany((AdvisorSetter i) => i.GetProperties(CS_0024_003C_003E8__locals4._TaskInvocation, CS_0024_003C_003E8__locals4.utilsInvocation));
	}

	internal static bool RateProxy()
	{
		return CheckProxy == null;
	}

	internal static BroadcasterInvocation ResetProxy()
	{
		return CheckProxy;
	}
}
