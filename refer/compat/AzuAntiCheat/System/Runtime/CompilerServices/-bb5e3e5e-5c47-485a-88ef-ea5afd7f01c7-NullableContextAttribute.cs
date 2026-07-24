using AzuAnticheat.Internal;
using Microsoft.CodeAnalysis;

namespace System.Runtime.CompilerServices;

[_003Cb89b921d_002D8954_002D4084_002Dbd4d_002D1feb826a594e_003EEmbedded]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
[CompilerGenerated]
internal sealed class _003Cbb5e3e5e_002D5c47_002D485a_002D88ef_002Dea5afd7f01c7_003ENullableContextAttribute : Attribute
{
	public readonly byte Flag;

	internal static _003Cbb5e3e5e_002D5c47_002D485a_002D88ef_002Dea5afd7f01c7_003ENullableContextAttribute RegisterSingleton;

	public _003Cbb5e3e5e_002D5c47_002D485a_002D88ef_002Dea5afd7f01c7_003ENullableContextAttribute(byte P_0)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
		{
			num = 0;
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
				Flag = P_0;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool SetupSingleton()
	{
		return RegisterSingleton == null;
	}

	internal static _003Cbb5e3e5e_002D5c47_002D485a_002D88ef_002Dea5afd7f01c7_003ENullableContextAttribute SelectSingleton()
	{
		return RegisterSingleton;
	}
}
