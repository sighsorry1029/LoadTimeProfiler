using System;

namespace AzuAnticheat.Internal;

internal sealed class AdapterInvocation : ErrorSetter<MockInterpreter>
{
	private readonly ValSetter _ProcInvocation;

	internal static AdapterInvocation SelectImporter;

	public AdapterInvocation(ValSetter eventEmitter)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			}
			_ProcInvocation = eventEmitter;
			num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
			{
				num = 1;
			}
		}
	}

	bool ErrorSetter<MockInterpreter>.Enter(ImporterSetter value, MockInterpreter context)
	{
		return true;
	}

	bool ErrorSetter<MockInterpreter>.EnterMapping(ImporterSetter key, ImporterSetter value, MockInterpreter context)
	{
		return true;
	}

	bool ErrorSetter<MockInterpreter>.EnterMapping(RegSetter key, ImporterSetter value, MockInterpreter context)
	{
		return true;
	}

	void ErrorSetter<MockInterpreter>.VisitScalar(ImporterSetter scalar, MockInterpreter context)
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
				_ProcInvocation.Emit(new InstanceSetter(scalar), context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void ErrorSetter<MockInterpreter>.VisitMappingStart(ImporterSetter mapping, Type keyType, Type valueType, MockInterpreter context)
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
				_ProcInvocation.Emit(new RecordSetter(mapping), context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void ErrorSetter<MockInterpreter>.VisitMappingEnd(ImporterSetter mapping, MockInterpreter context)
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
				_ProcInvocation.Emit(new ParameterSetter(mapping), context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void ErrorSetter<MockInterpreter>.VisitSequenceStart(ImporterSetter sequence, Type elementType, MockInterpreter context)
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
				_ProcInvocation.Emit(new StatusSetter(sequence), context);
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

	void ErrorSetter<MockInterpreter>.VisitSequenceEnd(ImporterSetter sequence, MockInterpreter context)
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
				_ProcInvocation.Emit(new AttrSetter(sequence), context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool ChangeImporter()
	{
		return SelectImporter == null;
	}

	internal static AdapterInvocation CreateImporter()
	{
		return SelectImporter;
	}
}
