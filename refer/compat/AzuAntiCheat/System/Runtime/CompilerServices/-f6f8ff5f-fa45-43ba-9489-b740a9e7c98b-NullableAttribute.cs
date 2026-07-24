using AzuAnticheat.Internal;
using Microsoft.CodeAnalysis;

namespace System.Runtime.CompilerServices;

[_003Cb89b921d_002D8954_002D4084_002Dbd4d_002D1feb826a594e_003EEmbedded]
[CompilerGenerated]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
internal sealed class _003Cf6f8ff5f_002Dfa45_002D43ba_002D9489_002Db740a9e7c98b_003ENullableAttribute : Attribute
{
	public readonly byte[] NullableFlags;

	private static _003Cf6f8ff5f_002Dfa45_002D43ba_002D9489_002Db740a9e7c98b_003ENullableAttribute RevertCustomer;

	public _003Cf6f8ff5f_002Dfa45_002D43ba_002D9489_002Db740a9e7c98b_003ENullableAttribute(byte P_0)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 != 0)
		{
			num = 1;
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public _003Cf6f8ff5f_002Dfa45_002D43ba_002D9489_002Db740a9e7c98b_003ENullableAttribute(byte[] P_0)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
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
			NullableFlags = P_0;
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
			{
				num = 1;
			}
		}
	}

	internal static bool InvokeSingleton()
	{
		return RevertCustomer == null;
	}

	internal static _003Cf6f8ff5f_002Dfa45_002D43ba_002D9489_002Db740a9e7c98b_003ENullableAttribute PublishSingleton()
	{
		return RevertCustomer;
	}
}
