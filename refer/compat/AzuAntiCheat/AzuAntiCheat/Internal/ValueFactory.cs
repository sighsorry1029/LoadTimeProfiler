using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal struct ValueFactory : IEquatable<ValueFactory>
{
	public static readonly ValueFactory _DecoratorFactory;

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	private readonly string _BroadcasterFactory;

	internal static object CancelError;

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
					string broadcasterFactory = _BroadcasterFactory;
					if (broadcasterFactory != null)
					{
						return broadcasterFactory;
					}
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 == 0)
					{
						num2 = 0;
					}
					break;
				}
				default:
					throw new InvalidOperationException(DicSingleton.gE3WbyDVW(-316028230 ^ -316052102));
				}
			}
		}
	}

	public bool IsEmpty => _BroadcasterFactory == null;

	public bool IsNonSpecific
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
					if (!IsEmpty)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
						{
							num2 = 0;
						}
						break;
					}
					return false;
				case 2:
					return _BroadcasterFactory == DicSingleton.gE3WbyDVW(0x540450D2 ^ 0x54042C28);
				default:
					if (_BroadcasterFactory == DicSingleton.gE3WbyDVW(-1549341817 ^ -1549364577))
					{
						return true;
					}
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f != 0)
					{
						num2 = 2;
					}
					break;
				}
			}
		}
	}

	public bool IsLocal
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
					if (!IsEmpty)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
						{
							num2 = 0;
						}
						break;
					}
					return false;
				default:
					return Value[0] == '!';
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
					if (!IsEmpty)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d != 0)
						{
							num2 = 0;
						}
						break;
					}
					return false;
				default:
					return !IsLocal;
				}
			}
		}
	}

	public ValueFactory(string value)
	{
		GetterIssuer.DeleteInitializer();
		_BroadcasterFactory = value ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x940D407 ^ 0x9409FAF));
		if (value.Length == 0)
		{
			throw new ArgumentException(DicSingleton.gE3WbyDVW(-447849421 ^ -447810519), DicSingleton.gE3WbyDVW(-65056140 ^ -65070628));
		}
		if (!IsGlobal || Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute))
		{
			return;
		}
		throw new ArgumentException(DicSingleton.gE3WbyDVW(-2133864647 ^ -2133891217), DicSingleton.gE3WbyDVW(-1735703950 ^ -1735718438));
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
				text = _BroadcasterFactory;
				if (text != null)
				{
					break;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
				{
					num2 = 0;
				}
				continue;
			default:
				text = DicSingleton.gE3WbyDVW(0x4BDBCDC0 ^ 0x4BDBB13A);
				break;
			}
			break;
		}
		return text;
	}

	public bool Equals(ValueFactory other)
	{
		return object.Equals(_BroadcasterFactory, other._BroadcasterFactory);
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	public override bool Equals(object obj)
	{
		int num = 1;
		int num2 = num;
		ValueFactory other = default(ValueFactory);
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (obj is ValueFactory)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 != 0)
					{
						num2 = 0;
					}
					break;
				}
				return false;
			case 2:
				return Equals(other);
			default:
				other = (ValueFactory)obj;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
				{
					num2 = 2;
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
				string broadcasterFactory = _BroadcasterFactory;
				if (broadcasterFactory == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 != 0)
					{
						num2 = 0;
					}
					break;
				}
				return broadcasterFactory.GetHashCode();
			}
			default:
				return 0;
			}
		}
	}

	public static bool operator ==(ValueFactory left, ValueFactory right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(ValueFactory left, ValueFactory right)
	{
		return !(left == right);
	}

	public static bool operator ==(ValueFactory left, string right)
	{
		return object.Equals(left._BroadcasterFactory, right);
	}

	public static bool operator !=(ValueFactory left, string right)
	{
		return !(left == right);
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	public static implicit operator ValueFactory(string value)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return new ValueFactory(value);
			case 1:
				if (value == null)
				{
					return _DecoratorFactory;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	static ValueFactory()
	{
		GetterIssuer.DeleteInitializer();
	}

	internal static bool ReflectError()
	{
		return CancelError == null;
	}

	internal static object CollectError()
	{
		return CancelError;
	}
}
