using System;

namespace AzuAnticheat.Internal;

internal static class CreatorSetter
{
	private static CreatorSetter CalcObserver;

	public static object NonNullValue(this ImporterSetter objectDescriptor)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
			{
				object? value = objectDescriptor.Value;
				if (value != null)
				{
					return value;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 != 0)
				{
					num2 = 0;
				}
				break;
			}
			default:
				throw new InvalidOperationException(DicSingleton.gE3WbyDVW(0x59C84793 ^ 0x59C81E6D) + objectDescriptor.Type.FullName + DicSingleton.gE3WbyDVW(0x23D015CA ^ 0x23D04F94));
			}
		}
	}

	internal static bool LogoutObserver()
	{
		return CalcObserver == null;
	}

	internal static CreatorSetter CountObserver()
	{
		return CalcObserver;
	}
}
