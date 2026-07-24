using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class AuthenticationSingleton : SystemSingleton
{
	[CompilerGenerated]
	private readonly VisitorAttribute attributeSingleton;

	private static AuthenticationSingleton ConnectProducer;

	public VisitorAttribute Value
	{
		[CompilerGenerated]
		get
		{
			return attributeSingleton;
		}
	}

	public AuthenticationSingleton(VisitorAttribute value)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(value, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public AuthenticationSingleton(VisitorAttribute value, TestsInterpreter start, TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 2:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0xFB046CE ^ 0xFB00D66));
			case 1:
				return;
			}
			if (!value.IsEmpty)
			{
				attributeSingleton = value;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 != 0)
				{
					num = 1;
				}
			}
			else
			{
				num = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
				{
					num = 0;
				}
			}
		}
	}

	internal static bool StartProducer()
	{
		return ConnectProducer == null;
	}

	internal static AuthenticationSingleton RemoveProducer()
	{
		return ConnectProducer;
	}
}
