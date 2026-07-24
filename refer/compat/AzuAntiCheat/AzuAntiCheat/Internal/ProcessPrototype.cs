using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class ProcessPrototype : RequestPrototype
{
	private readonly RequestPrototype repositoryPrototype;

	[CompilerGenerated]
	private string m_TagPrototype;

	[CompilerGenerated]
	private int visitorPrototype;

	private static ProcessPrototype ComputeRole;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return m_TagPrototype;
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
					m_TagPrototype = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
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

	public Type Type => repositoryPrototype.Type;

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public Type TypeOverride
	{
		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
		get
		{
			return repositoryPrototype.TypeOverride;
		}
		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
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
				case 0:
					return;
				case 1:
					repositoryPrototype.TypeOverride = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public int Order
	{
		[CompilerGenerated]
		get
		{
			return visitorPrototype;
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
				case 0:
					return;
				case 1:
					visitorPrototype = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public RuleFactory ScalarStyle
	{
		get
		{
			return repositoryPrototype.ScalarStyle;
		}
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
					repositoryPrototype.ScalarStyle = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc == 0)
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

	public bool CanWrite => repositoryPrototype.CanWrite;

	public ProcessPrototype(RequestPrototype baseDescriptor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb != 0)
		{
			num = 2;
		}
		while (true)
		{
			switch (num)
			{
			default:
				Name = baseDescriptor.Name;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
				{
					num = 0;
				}
				break;
			case 2:
				repositoryPrototype = baseDescriptor;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
				{
					num = 0;
				}
				break;
			case 1:
				return;
			}
		}
	}

	public void Write(object target, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object value)
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
				repositoryPrototype.Write(target, value);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public T GetCustomAttribute<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] T>() where T : Attribute
	{
		return repositoryPrototype.GetCustomAttribute<T>();
	}

	public UtilsPrototype Read(object target)
	{
		return repositoryPrototype.Read(target);
	}

	internal static bool DisableRole()
	{
		return ComputeRole == null;
	}

	internal static ProcessPrototype AwakeRole()
	{
		return ComputeRole;
	}
}
