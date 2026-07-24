using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class ItemAttribute : ComposerAttribute
{
	[CompilerGenerated]
	private Type _ContextAttribute;

	private readonly IDictionary<string, Type> mapperAttribute;

	private static ItemAttribute RunToken;

	public Type BaseType
	{
		[CompilerGenerated]
		get
		{
			return _ContextAttribute;
		}
		[CompilerGenerated]
		private set
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
					_ContextAttribute = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
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

	public ItemAttribute(Type baseType, IDictionary<string, Type> typeMapping)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		foreach (KeyValuePair<string, Type> item in typeMapping)
		{
			if (!baseType.IsAssignableFrom(item.Value))
			{
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-380885952 ^ -380857898), string.Format(DicSingleton.gE3WbyDVW(-360128320 ^ -360163984), item.Value, baseType));
			}
		}
		BaseType = baseType;
		mapperAttribute = typeMapping;
	}

	public bool TryDiscriminate(CandidateInterpreter parser, out Type? suggestedType)
	{
		int num = 3;
		int num2 = num;
		BridgeSingleton key = default(BridgeSingleton);
		while (true)
		{
			switch (num2)
			{
			case 1:
				return true;
			case 2:
				suggestedType = mapperAttribute[key.Value];
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
				{
					num2 = 1;
				}
				break;
			case 3:
			{
				if (!parser.TryFindMappingEntry((BridgeSingleton scalar) => mapperAttribute.ContainsKey(scalar.Value), out key, out ClientSingleton _))
				{
					suggestedType = null;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
					{
						num2 = 0;
					}
				}
				else
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 != 0)
					{
						num2 = 2;
					}
				}
				break;
			}
			default:
				return false;
			}
		}
	}

	internal static bool VerifyToken()
	{
		return RunToken == null;
	}

	internal static ItemAttribute PopToken()
	{
		return RunToken;
	}
}
