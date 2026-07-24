using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal static class ProcessAttribute
{
	private static ProcessAttribute RemoveAttribute;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ThrowArgumentOutOfRangeException(string paramName, string message)
	{
		throw new ArgumentOutOfRangeException(paramName, message);
	}

	internal static bool ResolveAttribute()
	{
		return RemoveAttribute == null;
	}

	internal static ProcessAttribute DefineAttribute()
	{
		return RemoveAttribute;
	}
}
