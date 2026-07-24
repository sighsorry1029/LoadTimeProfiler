using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class ReaderSingleton : Exception
{
	[CompilerGenerated]
	private readonly TestsInterpreter factorySingleton;

	private static ReaderSingleton ComputeProducer;

	public TestsInterpreter Start
	{
		[CompilerGenerated]
		get
		{
			return factorySingleton;
		}
	}

	public TestsInterpreter End { get; }

	public ReaderSingleton(string message)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(in TestsInterpreter._InitializerInterpreter, in TestsInterpreter._InitializerInterpreter, message);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ReaderSingleton(in TestsInterpreter start, in TestsInterpreter end, string message)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(in start, in end, message, null);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ReaderSingleton(in TestsInterpreter start, in TestsInterpreter end, string message, Exception? innerException)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(message, innerException);
		factorySingleton = start;
		_SetterSingleton = end;
	}

	public ReaderSingleton(string message, Exception inner)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(in TestsInterpreter._InitializerInterpreter, in TestsInterpreter._InitializerInterpreter, message, inner);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public override string ToString()
	{
		return string.Format(DicSingleton.gE3WbyDVW(0x21AFFB2B ^ 0x21AF53F7), Start, End, Message);
	}

	internal static bool DisableProducer()
	{
		return ComputeProducer == null;
	}

	internal static ReaderSingleton QueryProducer()
	{
		return ComputeProducer;
	}
}
