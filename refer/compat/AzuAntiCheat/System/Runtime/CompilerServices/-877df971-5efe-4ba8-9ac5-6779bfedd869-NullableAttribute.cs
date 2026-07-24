using AzuAnticheat.Internal;
using Microsoft.CodeAnalysis;

namespace System.Runtime.CompilerServices;

[_003Ca4a3bee8_002D01fe_002D4f0d_002D9ed1_002Db573711fc109_003EEmbedded]
[CompilerGenerated]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
internal sealed class _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullableAttribute : Attribute
{
	public readonly byte[] NullableFlags;

	private static _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullableAttribute PatchSingleton;

	public _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullableAttribute(byte P_0)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a == 0)
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
			NullableFlags = new byte[1] { P_0 };
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 != 0)
			{
				num = 1;
			}
		}
	}

	public _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullableAttribute(byte[] P_0)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 != 0)
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
				NullableFlags = P_0;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool AssetSingleton()
	{
		return PatchSingleton == null;
	}

	internal static _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullableAttribute CalcSingleton()
	{
		return PatchSingleton;
	}
}
