using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class IndexerSingleton : SystemSingleton
{
	[CompilerGenerated]
	private readonly string m_MockSingleton;

	private static IndexerSingleton EnableStub;

	public string Handle
	{
		[CompilerGenerated]
		get
		{
			return m_MockSingleton;
		}
	}

	public string Suffix { get; }

	public IndexerSingleton(string handle, string suffix)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(handle, suffix, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public IndexerSingleton(string handle, string suffix, TestsInterpreter start, TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 2:
				return;
			default:
				m_MockSingleton = handle ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0xB026CF2 ^ 0xB02C5F6));
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
				{
					num = 0;
				}
				break;
			case 1:
				_MethodSingleton = suffix ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x3353457 ^ 0x3359D43));
				num = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
				{
					num = 2;
				}
				break;
			}
		}
	}

	internal static bool SortStub()
	{
		return EnableStub == null;
	}

	internal static IndexerSingleton InsertStub()
	{
		return EnableStub;
	}
}
