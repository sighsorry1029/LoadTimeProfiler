using System;
using System.Runtime.CompilerServices;
using AzuAnticheat.Internal;

namespace Microsoft.CodeAnalysis;

[_003Ca4a3bee8_002D01fe_002D4f0d_002D9ed1_002Db573711fc109_003EEmbedded]
[CompilerGenerated]
internal sealed class _003Ca4a3bee8_002D01fe_002D4f0d_002D9ed1_002Db573711fc109_003EEmbeddedAttribute : Attribute
{
	internal static _003Ca4a3bee8_002D01fe_002D4f0d_002D9ed1_002Db573711fc109_003EEmbeddedAttribute ReadSingleton;

	public _003Ca4a3bee8_002D01fe_002D4f0d_002D9ed1_002Db573711fc109_003EEmbeddedAttribute()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ViewSingleton()
	{
		return ReadSingleton == null;
	}

	internal static _003Ca4a3bee8_002D01fe_002D4f0d_002D9ed1_002Db573711fc109_003EEmbeddedAttribute InitSingleton()
	{
		return ReadSingleton;
	}
}
