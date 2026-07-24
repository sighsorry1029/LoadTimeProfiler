using System;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal sealed class MapperAuthentication : ServerSetter
{
	private readonly IDictionary<RoleSingleton, Type> identifierAuthentication;

	private static MapperAuthentication ComputeImporter;

	public MapperAuthentication(IDictionary<RoleSingleton, Type> tagMappings)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		identifierAuthentication = tagMappings ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-736996892 ^ -737002698));
	}

	bool ServerSetter.Resolve(OrderSingleton? nodeEvent, ref Type currentType)
	{
		int num = 2;
		int num2 = num;
		Type value = default(Type);
		RoleSingleton tag = default(RoleSingleton);
		while (true)
		{
			switch (num2)
			{
			case 3:
				if (identifierAuthentication.TryGetValue(nodeEvent.Tag, out value))
				{
					num2 = 5;
					break;
				}
				goto IL_00ae;
			default:
				if (!tag.IsEmpty)
				{
					num2 = 3;
					break;
				}
				goto IL_00ae;
			case 1:
				tag = nodeEvent.Tag;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
				{
					num2 = 0;
				}
				break;
			case 5:
				currentType = value;
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
				{
					num2 = 4;
				}
				break;
			case 4:
				return true;
			case 2:
				{
					if (nodeEvent != null)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 != 0)
						{
							num2 = 1;
						}
						break;
					}
					goto IL_00ae;
				}
				IL_00ae:
				return false;
			}
		}
	}

	internal static bool DisableImporter()
	{
		return ComputeImporter == null;
	}

	internal static MapperAuthentication QueryImporter()
	{
		return ComputeImporter;
	}
}
