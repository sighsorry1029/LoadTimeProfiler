using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace AzuAnticheat.Internal;

internal abstract class ConfigInvocation : AdvisorSetter
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public string _AlgoInvocation;

		private static _003C_003Ec__DisplayClass1_0 PrintReg;

		public _003C_003Ec__DisplayClass1_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal bool _003CGetProperty_003Eb__0(RegSetter p)
		{
			return p.Name == _AlgoInvocation;
		}

		internal static bool CompareReg()
		{
			return PrintReg == null;
		}

		internal static _003C_003Ec__DisplayClass1_0 CloneReg()
		{
			return PrintReg;
		}
	}

	internal static ConfigInvocation ConcatReg;

	public abstract IEnumerable<RegSetter> GetProperties(Type type, object? container);

	public RegSetter GetProperty(Type type, object? container, string name, [ReponseSingleton(true)] bool ignoreUnmatched)
	{
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass1_0();
		CS_0024_003C_003E8__locals4._AlgoInvocation = name;
		IEnumerable<RegSetter> enumerable = from p in GetProperties(type, container)
			where p.Name == CS_0024_003C_003E8__locals4._AlgoInvocation
			select p;
		using IEnumerator<RegSetter> enumerator = enumerable.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			if (ignoreUnmatched)
			{
				return null;
			}
			throw new SerializationException(DicSingleton.gE3WbyDVW(-1580624393 ^ -1580599717) + CS_0024_003C_003E8__locals4._AlgoInvocation + DicSingleton.gE3WbyDVW(0x940D407 ^ 0x940B7C3) + type.FullName + DicSingleton.gE3WbyDVW(0x765D303 ^ 0x7658627));
		}
		RegSetter current = enumerator.Current;
		if (enumerator.MoveNext())
		{
			throw new SerializationException(DicSingleton.gE3WbyDVW(0x4995986C ^ 0x4995FB9E) + CS_0024_003C_003E8__locals4._AlgoInvocation + DicSingleton.gE3WbyDVW(0xDA293E6 ^ 0xDA2F7AE) + type.FullName + DicSingleton.gE3WbyDVW(0x2BC349D6 ^ 0x2BC32D56) + string.Join(DicSingleton.gE3WbyDVW(0x7742C60 ^ 0x774490C), enumerable.Select((RegSetter p) => p.Name).ToArray()));
		}
		return current;
	}

	protected ConfigInvocation()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool MapReg()
	{
		return ConcatReg == null;
	}

	internal static ConfigInvocation NewReg()
	{
		return ConcatReg;
	}
}
