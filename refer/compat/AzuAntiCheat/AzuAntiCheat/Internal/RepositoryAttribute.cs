using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal static class RepositoryAttribute
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0<T>
	{
		public T value;

		internal static object ResetAttribute;

		public _003C_003Ec__DisplayClass0_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
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

		internal static bool CustomizeAttribute()
		{
			return ResetAttribute == null;
		}

		internal static object CancelAttribute()
		{
			return ResetAttribute;
		}
	}

	public static Lazy<T> FromValue<T>(T value)
	{
		_003C_003Ec__DisplayClass0_0<T> _003C_003Ec__DisplayClass0_ = new _003C_003Ec__DisplayClass0_0<T>();
		_003C_003Ec__DisplayClass0_.value = value;
		Lazy<T> lazy = new Lazy<T>(() => _003C_003Ec__DisplayClass0_.value, isThreadSafe: false);
		_ = lazy.Value;
		return lazy;
	}
}
