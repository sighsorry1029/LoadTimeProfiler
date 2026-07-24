using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class GlobalAttribute : ComposerAttribute
{
	[CompilerGenerated]
	private Type _MapAttribute;

	private readonly string helperAttribute;

	private readonly IDictionary<string, Type> exceptionAttribute;

	private static GlobalAttribute ChangeToken;

	public Type BaseType
	{
		[CompilerGenerated]
		get
		{
			return _MapAttribute;
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
					_MapAttribute = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
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

	public GlobalAttribute(Type baseType, string targetKey, IDictionary<string, Type> typeMapping)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		foreach (KeyValuePair<string, Type> item in typeMapping)
		{
			if (!baseType.IsAssignableFrom(item.Value))
			{
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-992201216 ^ -992181354), string.Format(DicSingleton.gE3WbyDVW(-1075938037 ^ -1075918661), item.Value, baseType));
			}
		}
		BaseType = baseType;
		helperAttribute = targetKey;
		exceptionAttribute = typeMapping;
	}

	public bool TryDiscriminate(CandidateInterpreter parser, out Type? suggestedType)
	{
		int num = 6;
		int num2 = num;
		BridgeSingleton bridgeSingleton = default(BridgeSingleton);
		Type value2 = default(Type);
		ClientSingleton value = default(ClientSingleton);
		while (true)
		{
			switch (num2)
			{
			case 2:
				if (bridgeSingleton == null)
				{
					num2 = 3;
					break;
				}
				goto case 1;
			default:
				return false;
			case 1:
				if (!exceptionAttribute.TryGetValue(bridgeSingleton.Value, out value2))
				{
					num2 = 4;
					break;
				}
				goto case 7;
			case 5:
				bridgeSingleton = value as BridgeSingleton;
				num2 = 2;
				break;
			case 8:
				return true;
			case 3:
			case 4:
				suggestedType = null;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec == 0)
				{
					num2 = 0;
				}
				break;
			case 7:
				suggestedType = value2;
				num2 = 8;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
				{
					num2 = 1;
				}
				break;
			case 6:
			{
				if (parser.TryFindMappingEntry((BridgeSingleton scalar) => helperAttribute == scalar.Value, out BridgeSingleton _, out value))
				{
					num2 = 5;
					break;
				}
				goto case 3;
			}
			}
		}
	}

	internal static bool CreateToken()
	{
		return ChangeToken == null;
	}

	internal static GlobalAttribute TestToken()
	{
		return ChangeToken;
	}
}
