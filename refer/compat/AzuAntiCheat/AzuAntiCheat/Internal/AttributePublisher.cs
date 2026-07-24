using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
internal static class AttributePublisher
{
	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)]
	public enum Bond
	{

	}

	internal static AttributePublisher ViewVisitor;

	public static bool IsLocalInstance(this ZNet znet)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return !znet.IsDedicated();
			case 1:
				if (!znet.IsServer())
				{
					return false;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public static bool IsClientInstance(this ZNet znet)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (znet.IsServer())
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			case 2:
				return !znet.IsDedicated();
			default:
				return false;
			}
		}
	}

	public static bool IsServerInstance(this ZNet znet)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				if (!znet.IsServer())
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
					{
						num2 = 1;
					}
					break;
				}
				goto default;
			default:
				return znet.IsDedicated();
			case 1:
				return false;
			}
		}
	}

	public static Bond GetInstanceType(this ZNet znet)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 3:
				return (Bond)1;
			case 2:
				return (Bond)2;
			case 1:
				if (znet.IsLocalInstance())
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 != 0)
					{
						num2 = 0;
					}
					break;
				}
				if (!znet.IsClientInstance())
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 != 0)
					{
						num2 = 2;
					}
					break;
				}
				goto case 3;
			default:
				return (Bond)0;
			}
		}
	}

	public static bool IsAdmin(this ZNet znet, long uid)
	{
		return znet.ListContainsId(znet.m_adminList, znet.GetPeer(uid).m_socket.GetHostName());
	}

	public static bool IsAdmin(this ZNet znet, ZRpc rpc)
	{
		return znet.ListContainsId(znet.m_adminList, znet.GetPeer(rpc).m_socket.GetHostName());
	}

	public static bool IsAdmin(this ZNet znet, string hostName)
	{
		return znet.ListContainsId(znet.m_adminList, hostName);
	}

	internal static bool InitVisitor()
	{
		return ViewVisitor == null;
	}

	internal static AttributePublisher PatchVisitor()
	{
		return ViewVisitor;
	}
}
