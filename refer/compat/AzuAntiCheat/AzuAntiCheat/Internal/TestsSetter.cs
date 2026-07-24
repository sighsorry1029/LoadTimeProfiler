using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal abstract class TestsSetter
{
	[CompilerGenerated]
	private readonly ImporterSetter m_InitializerSetter;

	private static TestsSetter ConnectParameter;

	public ImporterSetter Source
	{
		[CompilerGenerated]
		get
		{
			return m_InitializerSetter;
		}
	}

	protected TestsSetter(ImporterSetter source)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
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
			m_InitializerSetter = source ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x5A1B57A3 ^ 0x5A1B0E43));
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 == 0)
			{
				num = 1;
			}
		}
	}

	internal static bool StartParameter()
	{
		return ConnectParameter == null;
	}

	internal static TestsSetter RemoveParameter()
	{
		return ConnectParameter;
	}
}
