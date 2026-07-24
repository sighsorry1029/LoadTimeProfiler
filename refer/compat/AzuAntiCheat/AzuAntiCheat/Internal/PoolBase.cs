using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
internal sealed class PoolBase : Attribute
{
	[CompilerGenerated]
	private readonly bool descriptorBase;

	internal static PoolBase RemoveSingleton;

	public bool ReturnValue
	{
		[CompilerGenerated]
		get
		{
			return descriptorBase;
		}
	}

	public PoolBase(bool returnValue)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
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
			descriptorBase = returnValue;
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 != 0)
			{
				num = 1;
			}
		}
	}

	internal static bool ResolveSingleton()
	{
		return RemoveSingleton == null;
	}

	internal static PoolBase DefineSingleton()
	{
		return RemoveSingleton;
	}
}
