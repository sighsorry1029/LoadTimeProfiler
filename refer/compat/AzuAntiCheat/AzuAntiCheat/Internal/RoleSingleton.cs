using System;

namespace AzuAnticheat.Internal;

internal readonly struct RoleSingleton : IEquatable<RoleSingleton>
{
	public static readonly RoleSingleton publisherSingleton;

	private readonly string? m_BaseSingleton;

	internal static object ExcludeProducer;

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
					string? baseSingleton = m_BaseSingleton;
					if (baseSingleton != null)
					{
						return baseSingleton;
					}
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
					{
						num2 = 0;
					}
					break;
				}
				default:
					throw new InvalidOperationException(DicSingleton.gE3WbyDVW(-428135557 ^ -428110661));
				}
			}
		}
	}

	public bool IsEmpty => m_BaseSingleton == null;

	public bool IsNonSpecific
	{
		get
		{
			int num = 2;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 3:
					return m_BaseSingleton == DicSingleton.gE3WbyDVW(0x540450D2 ^ 0x54042C28);
				case 1:
					return false;
				default:
					if (m_BaseSingleton == DicSingleton.gE3WbyDVW(0x6E29C0C0 ^ 0x6E29B9D8))
					{
						return true;
					}
					num2 = 3;
					break;
				case 2:
					if (IsEmpty)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
						{
							num2 = 1;
						}
						break;
					}
					goto default;
				}
			}
		}
	}

	public bool IsLocal
	{
		get
		{
			int num = 2;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 2:
					if (IsEmpty)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
						{
							num2 = 1;
						}
						break;
					}
					goto default;
				default:
					return Value[0] == '!';
				case 1:
					return false;
				}
			}
		}
	}

	public bool IsGlobal
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
					if (IsEmpty)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 == 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 2;
				case 2:
					return !IsLocal;
				default:
					return false;
				}
			}
		}
	}

	public RoleSingleton(string value)
	{
		GetterIssuer.DeleteInitializer();
		int num = 3;
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 0:
				return;
			case 2:
				if (Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute))
				{
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 != 0)
					{
						num = 0;
					}
					break;
				}
				goto case 4;
			case 5:
			{
				if (value.Length == 0)
				{
					num = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
					{
						num = 0;
					}
					break;
				}
				if (!IsGlobal)
				{
					return;
				}
				int num2 = 2;
				num = num2;
				break;
			}
			case 4:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(-360128320 ^ -360167274), DicSingleton.gE3WbyDVW(-1180565667 ^ -1180584715));
			case 1:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(0x9000142 ^ 0x900A958), DicSingleton.gE3WbyDVW(0x6E29C0C0 ^ 0x6E298B68));
			case 3:
				m_BaseSingleton = value ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1133601918 ^ -1133588438));
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 == 0)
				{
					num = 5;
				}
				break;
			}
		}
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
				text = m_BaseSingleton;
				if (text == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			default:
				text = DicSingleton.gE3WbyDVW(0x74FC52AF ^ 0x74FC2E55);
				break;
			}
			break;
		}
		return text;
	}

	public bool Equals(RoleSingleton other)
	{
		return object.Equals(m_BaseSingleton, other.m_BaseSingleton);
	}

	public override bool Equals(object? obj)
	{
		int num = 1;
		int num2 = num;
		RoleSingleton other = default(RoleSingleton);
		while (true)
		{
			switch (num2)
			{
			case 2:
				return Equals(other);
			default:
				other = (RoleSingleton)obj;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
				{
					num2 = 2;
				}
				break;
			case 1:
				if (!(obj is RoleSingleton))
				{
					return false;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
				{
					num2 = 0;
				}
				break;
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
				string? baseSingleton = m_BaseSingleton;
				if (baseSingleton == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
					{
						num2 = 0;
					}
					break;
				}
				return baseSingleton.GetHashCode();
			}
			default:
				return 0;
			}
		}
	}

	public static bool operator ==(RoleSingleton left, RoleSingleton right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(RoleSingleton left, RoleSingleton right)
	{
		return !(left == right);
	}

	public static bool operator ==(RoleSingleton left, string right)
	{
		return object.Equals(left.m_BaseSingleton, right);
	}

	public static bool operator !=(RoleSingleton left, string right)
	{
		return !(left == right);
	}

	public static implicit operator RoleSingleton(string? value)
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
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
					{
						num2 = 0;
					}
					break;
				}
				return publisherSingleton;
			default:
				return new RoleSingleton(value);
			}
		}
	}

	static RoleSingleton()
	{
		GetterIssuer.DeleteInitializer();
	}

	internal static bool InterruptProducer()
	{
		return ExcludeProducer == null;
	}

	internal static object DeleteProducer()
	{
		return ExcludeProducer;
	}
}
