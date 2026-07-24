using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal class ErrorFactory : ModelFactory
{
	[CompilerGenerated]
	private readonly string m_RegFactory;

	private static readonly Regex _ProxyFactory;

	private static ErrorFactory ResetReader;

	public string Handle
	{
		[CompilerGenerated]
		get
		{
			return m_RegFactory;
		}
	}

	public string Prefix { get; }

	public ErrorFactory(string handle, string prefix)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(handle, prefix, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ErrorFactory(string handle, string prefix, QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end);
		if (string.IsNullOrEmpty(handle))
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x540450D2 ^ 0x5404F9D6), DicSingleton.gE3WbyDVW(-1544119467 ^ -1544146319));
		}
		if (!_ProxyFactory.IsMatch(handle))
		{
			throw new ArgumentException(DicSingleton.gE3WbyDVW(-1614185587 ^ -1614163217), DicSingleton.gE3WbyDVW(0x6729A6D ^ 0x6723369));
		}
		m_RegFactory = handle;
		if (string.IsNullOrEmpty(prefix))
		{
			throw new ArgumentNullException(DicSingleton.gE3WbyDVW(--1509395337 ^ 0x59F72183), DicSingleton.gE3WbyDVW(-65056140 ^ -65013650));
		}
		_ReponseFactory = prefix;
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	public override bool Equals(object obj)
	{
		int num = 4;
		int num2 = num;
		ErrorFactory errorFactory = default(ErrorFactory);
		while (true)
		{
			switch (num2)
			{
			case 4:
				errorFactory = obj as ErrorFactory;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
				{
					num2 = 3;
				}
				break;
			case 3:
				if (errorFactory != null)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto default;
			case 2:
				return Prefix.Equals(errorFactory.Prefix);
			default:
				return false;
			case 1:
				if (!Handle.Equals(errorFactory.Handle))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			}
		}
	}

	public override int GetHashCode()
	{
		return Handle.GetHashCode() ^ Prefix.GetHashCode();
	}

	public override string ToString()
	{
		return Handle + DicSingleton.gE3WbyDVW(-1863475926 ^ -1863501966) + Prefix;
	}

	static ErrorFactory()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				_ProxyFactory = new Regex(DicSingleton.gE3WbyDVW(-228218718 ^ -228261178), RegexOptions.Compiled);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				GetterIssuer.DeleteInitializer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
				{
					num2 = 1;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool CustomizeReader()
	{
		return ResetReader == null;
	}

	internal static ErrorFactory CancelReader()
	{
		return ResetReader;
	}
}
