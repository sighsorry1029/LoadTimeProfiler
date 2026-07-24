using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class PrototypeSingleton
{
	[CompilerGenerated]
	private readonly int interceptorSingleton;

	[CompilerGenerated]
	private readonly int m_FilterSingleton;

	private static PrototypeSingleton FillProducer;

	public int Major
	{
		[CompilerGenerated]
		get
		{
			return interceptorSingleton;
		}
	}

	public int Minor
	{
		[CompilerGenerated]
		get
		{
			return m_FilterSingleton;
		}
	}

	public PrototypeSingleton(int major, int minor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 != 0)
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
				if (major < 0)
				{
					throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-447849421 ^ -447810389), string.Format(DicSingleton.gE3WbyDVW(0x3C33E48 ^ 0x3C396EE), major));
				}
				interceptorSingleton = major;
				num = 2;
				break;
			case 2:
				if (minor < 0)
				{
					throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-1447578472 ^ -1447617450), string.Format(DicSingleton.gE3WbyDVW(-1398029315 ^ -1398052005), minor));
				}
				m_FilterSingleton = minor;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public override bool Equals(object? obj)
	{
		int num = 4;
		int num2 = num;
		PrototypeSingleton prototypeSingleton = default(PrototypeSingleton);
		while (true)
		{
			switch (num2)
			{
			case 1:
				return Minor == prototypeSingleton.Minor;
			case 2:
				return false;
			default:
				if (Major == prototypeSingleton.Major)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 != 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 2;
			case 4:
				prototypeSingleton = obj as PrototypeSingleton;
				num2 = 3;
				break;
			case 3:
				if (prototypeSingleton == null)
				{
					num2 = 2;
					break;
				}
				goto default;
			}
		}
	}

	public override int GetHashCode()
	{
		int num = 1;
		int num2 = num;
		int major = default(int);
		while (true)
		{
			switch (num2)
			{
			case 1:
				major = Major;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return IndexerInterpreter.CombineHashCodes(major.GetHashCode(), Minor.GetHashCode());
			}
		}
	}

	internal static bool FlushProducer()
	{
		return FillProducer == null;
	}

	internal static PrototypeSingleton DestroyProducer()
	{
		return FillProducer;
	}
}
