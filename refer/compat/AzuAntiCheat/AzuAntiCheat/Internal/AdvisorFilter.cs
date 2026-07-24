using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class AdvisorFilter : DecoratorPrototype
{
	internal static AdvisorFilter UpdateAnnotation;

	void DecoratorPrototype.Emit(IdentifierPrototype eventInfo, ModelReader emitter)
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
				emitter.Emit(new TagFactory(eventInfo.Alias));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	void DecoratorPrototype.Emit(IndexerPrototype eventInfo, ModelReader emitter)
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
				emitter.Emit(new ClassFactory(eventInfo.Anchor, eventInfo.Tag, eventInfo.RenderedValue, eventInfo.Style, eventInfo.IsPlainImplicit, eventInfo.IsQuotedImplicit));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	void DecoratorPrototype.Emit(WatcherPrototype eventInfo, ModelReader emitter)
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
				emitter.Emit(new QueueFactory(eventInfo.Anchor, eventInfo.Tag, eventInfo.IsImplicit, eventInfo.Style));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void DecoratorPrototype.Emit(ResolverPrototype eventInfo, ModelReader emitter)
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
				emitter.Emit(new ListFactory());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	void DecoratorPrototype.Emit(CandidatePrototype eventInfo, ModelReader emitter)
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
				emitter.Emit(new RefFactory(eventInfo.Anchor, eventInfo.Tag, eventInfo.IsImplicit, eventInfo.Style));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	void DecoratorPrototype.Emit(RegistryPrototype eventInfo, ModelReader emitter)
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
				emitter.Emit(new SpecificationFactory());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public AdvisorFilter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool SearchAnnotation()
	{
		return UpdateAnnotation == null;
	}

	internal static AdvisorFilter StopAnnotation()
	{
		return UpdateAnnotation;
	}
}
