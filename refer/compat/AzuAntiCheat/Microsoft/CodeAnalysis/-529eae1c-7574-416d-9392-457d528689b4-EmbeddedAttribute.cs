using System;
using System.Runtime.CompilerServices;
using AzuAnticheat.Internal;

namespace Microsoft.CodeAnalysis;

[CompilerGenerated]
[_003C529eae1c_002D7574_002D416d_002D9392_002D457d528689b4_003EEmbedded]
internal sealed class _003C529eae1c_002D7574_002D416d_002D9392_002D457d528689b4_003EEmbeddedAttribute : Attribute
{
	internal static _003C529eae1c_002D7574_002D416d_002D9392_002D457d528689b4_003EEmbeddedAttribute ViewWrapper;

	public _003C529eae1c_002D7574_002D416d_002D9392_002D457d528689b4_003EEmbeddedAttribute()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool InitWrapper()
	{
		return ViewWrapper == null;
	}

	internal static _003C529eae1c_002D7574_002D416d_002D9392_002D457d528689b4_003EEmbeddedAttribute PatchWrapper()
	{
		return ViewWrapper;
	}
}
