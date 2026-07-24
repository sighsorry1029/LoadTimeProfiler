using System;
using System.Globalization;

namespace AzuAnticheat.Internal;

internal sealed class BaseSetter : CultureInfo
{
	private readonly IFormatProvider _PrototypeSetter;

	private static BaseSetter CustomizeObject;

	public BaseSetter(CultureInfo baseCulture, IFormatProvider provider)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(baseCulture.LCID);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
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
			_PrototypeSetter = provider;
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 != 0)
			{
				num = 0;
			}
		}
	}

	public override object? GetFormat(Type? formatType)
	{
		return _PrototypeSetter.GetFormat(formatType);
	}

	internal static bool CancelObject()
	{
		return CustomizeObject == null;
	}

	internal static BaseSetter ReflectObject()
	{
		return CustomizeObject;
	}
}
