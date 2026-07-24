using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal struct HelperReader : IEquatable<HelperReader>
{
	public static readonly HelperReader _ExceptionReader;

	private static readonly Regex m_ItemReader;

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	private readonly string m_ContextReader;

	private static object PrepareService;

	public string Value
	{
		get
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
				{
					string contextReader = m_ContextReader;
					if (contextReader == null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 != 0)
						{
							num2 = 0;
						}
						break;
					}
					return contextReader;
				}
				default:
					throw new InvalidOperationException(DicSingleton.gE3WbyDVW(0x33F6A245 ^ 0x33F6D597));
				}
			}
		}
	}

	public bool IsEmpty => m_ContextReader == null;

	public HelperReader(string value)
	{
		GetterIssuer.DeleteInitializer();
		m_ContextReader = value ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-614239580 ^ -614254324));
		if (m_ItemReader.IsMatch(value))
		{
			return;
		}
		throw new ArgumentException(DicSingleton.gE3WbyDVW(0xB967DC8 ^ 0xB9605EE) + value + DicSingleton.gE3WbyDVW(0x33F6A245 ^ 0x33F6F761), DicSingleton.gE3WbyDVW(-290181924 ^ -290166924));
	}

	public override string ToString()
	{
		int num = 1;
		int num2 = num;
		string text;
		while (true)
		{
			switch (num2)
			{
			case 1:
				text = m_ContextReader;
				if (text != null)
				{
					break;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
				{
					num2 = 0;
				}
				continue;
			default:
				text = DicSingleton.gE3WbyDVW(-1389846755 ^ -1389828133);
				break;
			}
			break;
		}
		return text;
	}

	public bool Equals(HelperReader other)
	{
		return object.Equals(m_ContextReader, other.m_ContextReader);
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	public override bool Equals(object obj)
	{
		int num = 2;
		int num2 = num;
		HelperReader other = default(HelperReader);
		while (true)
		{
			switch (num2)
			{
			case 2:
				if (!(obj is HelperReader))
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b != 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			case 3:
				return Equals(other);
			case 1:
				return false;
			}
			other = (HelperReader)obj;
			num2 = 3;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
			{
				num2 = 3;
			}
		}
	}

	public override int GetHashCode()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
			{
				string contextReader = m_ContextReader;
				if (contextReader == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
					{
						num2 = 0;
					}
					break;
				}
				return contextReader.GetHashCode();
			}
			default:
				return 0;
			}
		}
	}

	public static bool operator ==(HelperReader left, HelperReader right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(HelperReader left, HelperReader right)
	{
		return !(left == right);
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	public static implicit operator HelperReader(string value)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (value != null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
					{
						num2 = 0;
					}
					break;
				}
				return _ExceptionReader;
			default:
				return new HelperReader(value);
			}
		}
	}

	static HelperReader()
	{
		int num = 2;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 0:
					return;
				case 3:
					m_ItemReader = new Regex(DicSingleton.gE3WbyDVW(0x74FC52AF ^ 0x74FC2A77), RegexOptions.Compiled);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
					{
						num2 = 0;
					}
					continue;
				case 1:
					break;
				case 2:
					GetterIssuer.DeleteInitializer();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
					{
						num2 = 1;
					}
					continue;
				}
				break;
			}
			_ExceptionReader = default(HelperReader);
			num = 3;
		}
	}

	internal static bool WriteService()
	{
		return PrepareService == null;
	}

	internal static object PrintService()
	{
		return PrepareService;
	}
}
