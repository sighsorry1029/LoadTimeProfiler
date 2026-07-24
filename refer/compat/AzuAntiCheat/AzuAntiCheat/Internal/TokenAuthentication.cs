using System;

namespace AzuAnticheat.Internal;

[Obsolete("The mechanism that this class uses to specify type names is non-standard. Register the tags explicitly instead of using this convention.")]
internal sealed class TokenAuthentication : ServerSetter
{
	private static TokenAuthentication AwakeImporter;

	bool ServerSetter.Resolve(OrderSingleton? nodeEvent, ref Type currentType)
	{
		int num = 2;
		RoleSingleton tag = default(RoleSingleton);
		Type type = default(Type);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 6:
					return true;
				case 1:
				case 8:
					return false;
				case 9:
					tag = nodeEvent.Tag;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 != 0)
					{
						num2 = 3;
					}
					continue;
				case 4:
					if (!tag.IsEmpty)
					{
						num2 = 9;
						continue;
					}
					goto case 1;
				default:
					tag = nodeEvent.Tag;
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 != 0)
					{
						num2 = 0;
					}
					continue;
				case 7:
					if (!(type != null))
					{
						num2 = 8;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
						{
							num2 = 6;
						}
						continue;
					}
					break;
				case 3:
					goto end_IL_0012;
				case 2:
					if (nodeEvent == null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto default;
				case 5:
					break;
				}
				currentType = type;
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
				{
					num2 = 6;
				}
				continue;
				end_IL_0012:
				break;
			}
			type = Type.GetType(tag.Value.Substring(1), throwOnError: false);
			num = 7;
		}
	}

	public TokenAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool InstantiateImporter()
	{
		return AwakeImporter == null;
	}

	internal static TokenAuthentication LoginImporter()
	{
		return AwakeImporter;
	}
}
