using System;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal sealed class TokenizerInvocation : MappingInvocation
{
	private readonly ValSetter m_ListenerInvocation;

	private readonly MessageSetter m_AccountInvocation;

	private readonly HashSet<VisitorAttribute> m_ThreadInvocation;

	private static TokenizerInvocation ResolveReg;

	public TokenizerInvocation(ErrorSetter<MockInterpreter> nextVisitor, ValSetter eventEmitter, MessageSetter aliasProvider)
	{
		GetterIssuer.DeleteInitializer();
		m_ThreadInvocation = new HashSet<VisitorAttribute>();
		base._002Ector(nextVisitor);
		m_ListenerInvocation = eventEmitter;
		m_AccountInvocation = aliasProvider;
	}

	public override bool Enter(ImporterSetter value, MockInterpreter context)
	{
		int num = 4;
		int num2 = num;
		VisitorAttribute alias = default(VisitorAttribute);
		PageSetter pageSetter = default(PageSetter);
		while (true)
		{
			switch (num2)
			{
			case 7:
				if (!m_ThreadInvocation.Add(alias))
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 6;
			case 1:
				pageSetter = new PageSetter(value, alias);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
				{
					num2 = 0;
				}
				break;
			case 4:
				if (value.Value != null)
				{
					num2 = 3;
					break;
				}
				goto case 6;
			case 3:
				alias = m_AccountInvocation.GetAlias(value.Value);
				num2 = 5;
				break;
			case 2:
				return pageSetter.NeedsExpansion;
			case 6:
				return base.Enter(value, context);
			case 5:
				if (alias.IsEmpty)
				{
					num2 = 6;
					break;
				}
				goto case 7;
			default:
				m_ListenerInvocation.Emit(pageSetter, context);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public override void VisitMappingStart(ImporterSetter mapping, Type keyType, Type valueType, MockInterpreter context)
	{
		int num = 1;
		int num2 = num;
		VisitorAttribute alias = default(VisitorAttribute);
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			case 1:
				alias = m_AccountInvocation.GetAlias(mapping.NonNullValue());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
				{
					num2 = 0;
				}
				continue;
			}
			m_ListenerInvocation.Emit(new RecordSetter(mapping)
			{
				Anchor = alias
			}, context);
			num2 = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
			{
				num2 = 2;
			}
		}
	}

	public override void VisitSequenceStart(ImporterSetter sequence, Type elementType, MockInterpreter context)
	{
		int num = 1;
		int num2 = num;
		VisitorAttribute alias = default(VisitorAttribute);
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			case 1:
				alias = m_AccountInvocation.GetAlias(sequence.NonNullValue());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
				{
					num2 = 0;
				}
				continue;
			}
			m_ListenerInvocation.Emit(new StatusSetter(sequence)
			{
				Anchor = alias
			}, context);
			num2 = 2;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 != 0)
			{
				num2 = 2;
			}
		}
	}

	public override void VisitScalar(ImporterSetter scalar, MockInterpreter context)
	{
		int num = 2;
		int num2 = num;
		InstanceSetter instanceSetter = default(InstanceSetter);
		while (true)
		{
			switch (num2)
			{
			case 3:
				return;
			default:
				m_ListenerInvocation.Emit(instanceSetter, context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
				{
					num2 = 3;
				}
				break;
			case 4:
				instanceSetter.Anchor = m_AccountInvocation.GetAlias(scalar.Value);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb == 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				if (scalar.Value != null)
				{
					num2 = 4;
					break;
				}
				goto default;
			case 2:
				instanceSetter = new InstanceSetter(scalar);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	internal static bool DefineReg()
	{
		return ResolveReg == null;
	}

	internal static TokenizerInvocation IncludeReg()
	{
		return ResolveReg;
	}
}
