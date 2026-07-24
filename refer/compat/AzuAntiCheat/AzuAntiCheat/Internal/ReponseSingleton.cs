using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace AzuAnticheat.Internal;

[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
internal sealed class ReponseSingleton : Attribute
{
	internal static ReponseSingleton ExcludeGetter;

	public bool ReturnValue { get; }

	public ReponseSingleton(bool returnValue)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb != 0)
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
				_ProxySingleton = returnValue;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool InterruptGetter()
	{
		return ExcludeGetter == null;
	}

	internal static ReponseSingleton DeleteGetter()
	{
		return ExcludeGetter;
	}
}
