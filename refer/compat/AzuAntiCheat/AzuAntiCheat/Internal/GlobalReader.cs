using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal static class GlobalReader
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0<T>
	{
		public T value;

		internal static object PostService;

		public _003C_003Ec__DisplayClass0_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal T _003CFromValue_003Eb__0()
		{
			return value;
		}

		internal static bool CallService()
		{
			return PostService == null;
		}

		internal static object ConcatService()
		{
			return PostService;
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public static Lazy<T> FromValue<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] T>(T value)
	{
		_003C_003Ec__DisplayClass0_0<T> _003C_003Ec__DisplayClass0_ = new _003C_003Ec__DisplayClass0_0<T>();
		_003C_003Ec__DisplayClass0_.value = value;
		Lazy<T> lazy = new Lazy<T>(() => _003C_003Ec__DisplayClass0_.value, isThreadSafe: false);
		_ = lazy.Value;
		return lazy;
	}
}
