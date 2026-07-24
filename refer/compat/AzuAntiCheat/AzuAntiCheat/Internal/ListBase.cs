using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class ListBase : CultureInfo
{
	private readonly IFormatProvider m_QueueBase;

	internal static ListBase ResetSingleton;

	public ListBase(CultureInfo baseCulture, IFormatProvider provider)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(baseCulture.LCID);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			}
			m_QueueBase = provider;
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
			{
				num = 0;
			}
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	public override object GetFormat(Type formatType)
	{
		return m_QueueBase.GetFormat(formatType);
	}

	internal static bool CustomizeSingleton()
	{
		return ResetSingleton == null;
	}

	internal static ListBase CancelSingleton()
	{
		return ResetSingleton;
	}
}
