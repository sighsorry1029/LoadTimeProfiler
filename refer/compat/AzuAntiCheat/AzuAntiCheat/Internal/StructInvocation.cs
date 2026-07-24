namespace AzuAnticheat.Internal;

internal sealed class StructInvocation : MappingInvocation
{
	private static StructInvocation CustomizeReg;

	public StructInvocation(ErrorSetter<MockInterpreter> nextVisitor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(nextVisitor);
	}

	public override bool EnterMapping(RegSetter key, ImporterSetter value, MockInterpreter context)
	{
		int num = 4;
		FilterInvocation customAttribute = default(FilterInvocation);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 4:
					customAttribute = key.GetCustomAttribute<FilterInvocation>();
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
					{
						num2 = 1;
					}
					continue;
				case 3:
					if (customAttribute == null)
					{
						break;
					}
					goto default;
				case 2:
				case 5:
				case 6:
					return base.EnterMapping(key, value, context);
				case 1:
					context.Emit(new DecoratorSingleton(customAttribute.Description, isInline: false));
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
					{
						num2 = 2;
					}
					continue;
				default:
					if (customAttribute.Description == null)
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
						{
							num2 = 5;
						}
						continue;
					}
					goto case 1;
				}
				break;
			}
			num = 6;
		}
	}

	internal static bool CancelReg()
	{
		return CustomizeReg == null;
	}

	internal static StructInvocation ReflectReg()
	{
		return CustomizeReg;
	}
}
