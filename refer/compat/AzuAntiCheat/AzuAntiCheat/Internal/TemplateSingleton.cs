using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AzuAnticheat.Internal;

internal class TemplateSingleton : SystemSingleton
{
	[CompilerGenerated]
	private readonly string predicateSingleton;

	[CompilerGenerated]
	private readonly string watcherSingleton;

	private static readonly Regex _CustomerSingleton;

	private static TemplateSingleton FindStub;

	public string Handle
	{
		[CompilerGenerated]
		get
		{
			return predicateSingleton;
		}
	}

	public string Prefix
	{
		[CompilerGenerated]
		get
		{
			return watcherSingleton;
		}
	}

	public TemplateSingleton(string handle, string prefix)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(handle, prefix, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public TemplateSingleton(string handle, string prefix, TestsInterpreter start, TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
		int num = 3;
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 2:
				if (string.IsNullOrEmpty(prefix))
				{
					num = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
					{
						num = 4;
					}
					break;
				}
				watcherSingleton = prefix;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f != 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			case 1:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(-1466472923 ^ -1466446009), DicSingleton.gE3WbyDVW(0x1679942F ^ 0x16793D2B));
			case 4:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x9000142 ^ 0x900AB48), DicSingleton.gE3WbyDVW(-1830690703 ^ -1830729109));
			case 3:
				if (!string.IsNullOrEmpty(handle))
				{
					num = 5;
					break;
				}
				goto case 6;
			case 6:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0xB967DC8 ^ 0xB96D4CC), DicSingleton.gE3WbyDVW(0x4097B854 ^ 0x40971170));
			case 5:
				if (_CustomerSingleton.IsMatch(handle))
				{
					predicateSingleton = handle;
					num = 2;
					break;
				}
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 != 0)
				{
					num = 1;
				}
				break;
			}
		}
	}

	public override bool Equals(object? obj)
	{
		int num = 2;
		int num2 = num;
		TemplateSingleton templateSingleton = default(TemplateSingleton);
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (templateSingleton == null)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
					{
						num2 = 3;
					}
					break;
				}
				goto default;
			default:
				if (!Handle.Equals(templateSingleton.Handle))
				{
					num2 = 5;
					break;
				}
				goto case 4;
			case 4:
				return Prefix.Equals(templateSingleton.Prefix);
			case 3:
			case 5:
				return false;
			case 2:
				templateSingleton = obj as TemplateSingleton;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	public override int GetHashCode()
	{
		return Handle.GetHashCode() ^ Prefix.GetHashCode();
	}

	public override string ToString()
	{
		return Handle + DicSingleton.gE3WbyDVW(-2075300707 ^ -2075277627) + Prefix;
	}

	static TemplateSingleton()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				_CustomerSingleton = new Regex(DicSingleton.gE3WbyDVW(0x4995986C ^ 0x49953208), RegexOptions.Compiled);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				return;
			case 1:
				GetterIssuer.DeleteInitializer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool VisitStub()
	{
		return FindStub == null;
	}

	internal static TemplateSingleton OrderStub()
	{
		return FindStub;
	}
}
