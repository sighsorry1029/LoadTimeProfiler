using AzuAnticheat.Internal;
using Microsoft.CodeAnalysis;

namespace System.Runtime.CompilerServices;

[_003C529eae1c_002D7574_002D416d_002D9392_002D457d528689b4_003EEmbedded]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
[CompilerGenerated]
internal sealed class _003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContextAttribute : Attribute
{
	public readonly byte Flag;

	internal static _003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContextAttribute LogoutWrapper;

	public _003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContextAttribute(byte P_0)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
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
			Flag = P_0;
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
			{
				num = 1;
			}
		}
	}

	internal static bool CountWrapper()
	{
		return LogoutWrapper == null;
	}

	internal static _003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContextAttribute SetWrapper()
	{
		return LogoutWrapper;
	}
}
