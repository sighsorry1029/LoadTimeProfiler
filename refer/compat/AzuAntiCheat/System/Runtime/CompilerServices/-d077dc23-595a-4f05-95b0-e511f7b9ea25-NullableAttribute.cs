using AzuAnticheat.Internal;
using Microsoft.CodeAnalysis;

namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
[_003C529eae1c_002D7574_002D416d_002D9392_002D457d528689b4_003EEmbedded]
[CompilerGenerated]
internal sealed class _003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullableAttribute : Attribute
{
	public readonly byte[] NullableFlags;

	private static _003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullableAttribute AssetWrapper;

	public _003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullableAttribute(byte P_0)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 != 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 1:
				NullableFlags = new byte[1] { P_0 };
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public _003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullableAttribute(byte[] P_0)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool ListWrapper()
	{
		return AssetWrapper == null;
	}

	internal static _003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullableAttribute CalcWrapper()
	{
		return AssetWrapper;
	}
}
