using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class BaseFilter : RoleFilter
{
	internal static BaseFilter OrderProcess;

	public BaseFilter(ParserPrototype<ModelReader> nextVisitor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(nextVisitor);
	}

	public override bool EnterMapping(RequestPrototype key, UtilsPrototype value, ModelReader context)
	{
		int num = 1;
		int num2 = num;
		RulesInterceptor customAttribute = default(RulesInterceptor);
		while (true)
		{
			switch (num2)
			{
			case 1:
				customAttribute = key.GetCustomAttribute<RulesInterceptor>();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
				{
					num2 = 0;
				}
				break;
			case 3:
				context.Emit(new StubFactory(customAttribute.Description, isInline: false));
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
			case 5:
				return base.EnterMapping(key, value, context);
			default:
				if (customAttribute == null)
				{
					num2 = 5;
					break;
				}
				goto case 4;
			case 4:
				if (customAttribute.Description != null)
				{
					num2 = 3;
					break;
				}
				goto case 2;
			}
		}
	}

	internal static bool UpdateProcess()
	{
		return OrderProcess == null;
	}

	internal static BaseFilter SearchProcess()
	{
		return OrderProcess;
	}
}
