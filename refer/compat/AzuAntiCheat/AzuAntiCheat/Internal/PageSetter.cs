using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class PageSetter : TestsSetter
{
	[CompilerGenerated]
	private readonly VisitorAttribute m_ParserSetter;

	[CompilerGenerated]
	private bool _RequestSetter;

	private static PageSetter ResolveParameter;

	public VisitorAttribute Alias
	{
		[CompilerGenerated]
		get
		{
			return m_ParserSetter;
		}
	}

	public bool NeedsExpansion
	{
		[CompilerGenerated]
		get
		{
			return _RequestSetter;
		}
		[CompilerGenerated]
		set
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 1:
					_RequestSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 != 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}
	}

	public PageSetter(ImporterSetter source, VisitorAttribute alias)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(source);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e != 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 3:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-849667636 ^ -849657796));
			case 1:
				m_ParserSetter = alias;
				num = 2;
				break;
			default:
				if (!alias.IsEmpty)
				{
					num = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
					{
						num = 1;
					}
					break;
				}
				goto case 3;
			case 2:
				return;
			}
		}
	}

	internal static bool DefineParameter()
	{
		return ResolveParameter == null;
	}

	internal static PageSetter IncludeParameter()
	{
		return ResolveParameter;
	}
}
