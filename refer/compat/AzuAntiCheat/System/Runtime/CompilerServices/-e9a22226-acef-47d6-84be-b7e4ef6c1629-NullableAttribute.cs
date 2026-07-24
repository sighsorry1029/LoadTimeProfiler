using AzuAnticheat.Internal;
using Microsoft.CodeAnalysis;

namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
[_003C1c930827_002Df0b5_002D4e54_002D8046_002D3b511e036a7b_003EEmbedded]
[CompilerGenerated]
internal sealed class _003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullableAttribute : Attribute
{
	public readonly byte[] NullableFlags;

	internal static _003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullableAttribute RunExpression;

	public _003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullableAttribute(byte P_0)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd != 0)
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
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 != 0)
			{
				num = 1;
			}
		}
	}

	public _003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullableAttribute(byte[] P_0)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 != 0)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool VerifyExpression()
	{
		return RunExpression == null;
	}

	internal static _003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullableAttribute PopExpression()
	{
		return RunExpression;
	}
}
