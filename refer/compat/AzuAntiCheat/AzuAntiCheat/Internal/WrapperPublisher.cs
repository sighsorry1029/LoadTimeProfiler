using System.Runtime.CompilerServices;
using BepInEx.Configuration;
using JetBrains.Annotations;

namespace AzuAnticheat.Internal;

[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(1)]
[PublicAPI]
internal abstract class WrapperPublisher
{
	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
	public object serverPublisher;

	public bool _AlgoPublisher;

	internal static WrapperPublisher SortWrapper;

	public abstract ConfigEntryBase BaseConfig { get; }

	protected WrapperPublisher()
	{
		GetterIssuer.DeleteInitializer();
		_AlgoPublisher = true;
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool InsertWrapper()
	{
		return SortWrapper == null;
	}

	internal static WrapperPublisher FindWrapper()
	{
		return SortWrapper;
	}
}
