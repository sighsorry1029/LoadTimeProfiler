using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class IdentifierSingleton : SystemSingleton
{
	[CompilerGenerated]
	private bool tokenSingleton;

	[CompilerGenerated]
	private readonly string m_CallbackSingleton;

	[CompilerGenerated]
	private readonly ConnectionInterpreter rulesSingleton;

	private static IdentifierSingleton PatchStub;

	public bool IsKey
	{
		[CompilerGenerated]
		get
		{
			return tokenSingleton;
		}
		[CompilerGenerated]
		set
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 0:
					return;
				case 1:
					tokenSingleton = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public string Value
	{
		[CompilerGenerated]
		get
		{
			return m_CallbackSingleton;
		}
	}

	public ConnectionInterpreter Style
	{
		[CompilerGenerated]
		get
		{
			return rulesSingleton;
		}
	}

	public IdentifierSingleton(string value)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(value, (ConnectionInterpreter)0);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public IdentifierSingleton(string value, ConnectionInterpreter style)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(value, style, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public IdentifierSingleton(string value, ConnectionInterpreter style, TestsInterpreter start, TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
		int num = 2;
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 0:
				return;
			case 1:
				rulesSingleton = style;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
				{
					num = 0;
				}
				break;
			case 2:
				m_CallbackSingleton = value ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x4C73F208 ^ 0x4C73B9A0));
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a == 0)
				{
					num = 1;
				}
				break;
			}
		}
	}

	internal static bool AssetStub()
	{
		return PatchStub == null;
	}

	internal static IdentifierSingleton ListStub()
	{
		return PatchStub;
	}
}
