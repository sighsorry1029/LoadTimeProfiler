using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal static class TestsPrototype
{
	internal static TestsPrototype InitMethod;

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public static object NonNullValue(this UtilsPrototype objectDescriptor)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
			{
				object value = objectDescriptor.Value;
				if (value != null)
				{
					return value;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
				{
					num2 = 0;
				}
				break;
			}
			default:
				throw new InvalidOperationException(DicSingleton.gE3WbyDVW(0x548F02D9 ^ 0x548F5B27) + objectDescriptor.Type.FullName + DicSingleton.gE3WbyDVW(0x1C9EFC64 ^ 0x1C9EA63A));
			}
		}
	}

	internal static bool PatchMethod()
	{
		return InitMethod == null;
	}

	internal static TestsPrototype AssetMethod()
	{
		return InitMethod;
	}
}
