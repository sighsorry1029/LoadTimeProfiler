using System;
using System.Collections.Generic;
using System.Globalization;

namespace AzuAnticheat.Internal;

internal sealed class DispatcherInvocation : RoleAuthentication, MessageSetter
{
	private class CollectionInvocation
	{
		public VisitorAttribute managerInvocation;

		private static CollectionInvocation ConnectReg;

		public CollectionInvocation()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool StartReg()
		{
			return ConnectReg == null;
		}

		internal static CollectionInvocation RemoveReg()
		{
			return ConnectReg;
		}
	}

	private readonly IDictionary<object, CollectionInvocation> m_ListInvocation;

	private uint queueInvocation;

	internal static DispatcherInvocation AwakeReg;

	public DispatcherInvocation(IEnumerable<StrategySetter> typeConverters)
	{
		GetterIssuer.DeleteInitializer();
		m_ListInvocation = new Dictionary<object, CollectionInvocation>();
		base._002Ector(typeConverters);
	}

	protected override bool Enter(ImporterSetter value)
	{
		int num = 5;
		int num2 = num;
		CollectionInvocation value2 = default(CollectionInvocation);
		while (true)
		{
			switch (num2)
			{
			case 2:
				value2.managerInvocation = new VisitorAttribute(DicSingleton.gE3WbyDVW(-1244021215 ^ -1244013053) + queueInvocation.ToString(CultureInfo.InvariantCulture));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
				{
					num2 = 1;
				}
				break;
			case 5:
				if (value.Value != null)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 == 0)
					{
						num2 = 4;
					}
					break;
				}
				goto IL_00f0;
			case 4:
				if (m_ListInvocation.TryGetValue(value.Value, out value2))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto IL_00f0;
			case 1:
				queueInvocation++;
				num2 = 3;
				break;
			case 3:
				return false;
			default:
				{
					if (value2.managerInvocation.IsEmpty)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb != 0)
						{
							num2 = 2;
						}
						break;
					}
					goto case 3;
				}
				IL_00f0:
				return true;
			}
		}
	}

	protected override bool EnterMapping(ImporterSetter key, ImporterSetter value)
	{
		return true;
	}

	protected override bool EnterMapping(RegSetter key, ImporterSetter value)
	{
		return true;
	}

	protected override void VisitScalar(ImporterSetter scalar)
	{
	}

	protected override void VisitMappingStart(ImporterSetter mapping, Type keyType, Type valueType)
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
				VisitObject(mapping);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	protected override void VisitMappingEnd(ImporterSetter mapping)
	{
	}

	protected override void VisitSequenceStart(ImporterSetter sequence, Type elementType)
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
				VisitObject(sequence);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	protected override void VisitSequenceEnd(ImporterSetter sequence)
	{
	}

	private void VisitObject(ImporterSetter value)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 0:
				return;
			case 2:
				if (value.Value == null)
				{
					return;
				}
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				m_ListInvocation.Add(value.Value, new CollectionInvocation());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	VisitorAttribute MessageSetter.GetAlias(object target)
	{
		int num = 1;
		int num2 = num;
		CollectionInvocation value = default(CollectionInvocation);
		while (true)
		{
			switch (num2)
			{
			case 2:
				return value.managerInvocation;
			case 1:
				if (target != null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto IL_0030;
			default:
				{
					if (m_ListInvocation.TryGetValue(target, out value))
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
						{
							num2 = 1;
						}
						break;
					}
					goto IL_0030;
				}
				IL_0030:
				return VisitorAttribute._StubAttribute;
			}
		}
	}

	internal static bool InstantiateReg()
	{
		return AwakeReg == null;
	}

	internal static DispatcherInvocation LoginReg()
	{
		return AwakeReg;
	}
}
