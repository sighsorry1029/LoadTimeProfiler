using System;

namespace AzuAnticheat.Internal;

internal abstract class MappingInvocation : ErrorSetter<MockInterpreter>
{
	private readonly ErrorSetter<MockInterpreter> schemaInvocation;

	internal static MappingInvocation CheckReg;

	protected MappingInvocation(ErrorSetter<MockInterpreter> nextVisitor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		schemaInvocation = nextVisitor;
	}

	public virtual bool Enter(ImporterSetter value, MockInterpreter context)
	{
		return schemaInvocation.Enter(value, context);
	}

	public virtual bool EnterMapping(ImporterSetter key, ImporterSetter value, MockInterpreter context)
	{
		return schemaInvocation.EnterMapping(key, value, context);
	}

	public virtual bool EnterMapping(RegSetter key, ImporterSetter value, MockInterpreter context)
	{
		return schemaInvocation.EnterMapping(key, value, context);
	}

	public virtual void VisitScalar(ImporterSetter scalar, MockInterpreter context)
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
				schemaInvocation.VisitScalar(scalar, context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public virtual void VisitMappingStart(ImporterSetter mapping, Type keyType, Type valueType, MockInterpreter context)
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
				schemaInvocation.VisitMappingStart(mapping, keyType, valueType, context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public virtual void VisitMappingEnd(ImporterSetter mapping, MockInterpreter context)
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
				schemaInvocation.VisitMappingEnd(mapping, context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public virtual void VisitSequenceStart(ImporterSetter sequence, Type elementType, MockInterpreter context)
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
				schemaInvocation.VisitSequenceStart(sequence, elementType, context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public virtual void VisitSequenceEnd(ImporterSetter sequence, MockInterpreter context)
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
				schemaInvocation.VisitSequenceEnd(sequence, context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool RateReg()
	{
		return CheckReg == null;
	}

	internal static MappingInvocation ResetReg()
	{
		return CheckReg;
	}
}
