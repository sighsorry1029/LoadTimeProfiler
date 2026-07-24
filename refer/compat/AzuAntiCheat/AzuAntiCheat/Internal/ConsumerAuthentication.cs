namespace AzuAnticheat.Internal;

internal sealed class ConsumerAuthentication : ValSetter
{
	internal static ConsumerAuthentication SortIssuer;

	void ValSetter.Emit(PageSetter eventInfo, MockInterpreter emitter)
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
				emitter.Emit(new StateSingleton(eventInfo.Alias));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void ValSetter.Emit(InstanceSetter eventInfo, MockInterpreter emitter)
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
				emitter.Emit(new BridgeSingleton(eventInfo.Anchor, eventInfo.Tag, eventInfo.RenderedValue, eventInfo.Style, eventInfo.IsPlainImplicit, eventInfo.IsQuotedImplicit));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void ValSetter.Emit(RecordSetter eventInfo, MockInterpreter emitter)
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
				emitter.Emit(new FacadeSingleton(eventInfo.Anchor, eventInfo.Tag, eventInfo.IsImplicit, eventInfo.Style));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void ValSetter.Emit(ParameterSetter eventInfo, MockInterpreter emitter)
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
				emitter.Emit(new ParamSingleton());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void ValSetter.Emit(StatusSetter eventInfo, MockInterpreter emitter)
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
				emitter.Emit(new ExporterSingleton(eventInfo.Anchor, eventInfo.Tag, eventInfo.IsImplicit, eventInfo.Style));
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

	void ValSetter.Emit(AttrSetter eventInfo, MockInterpreter emitter)
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
				emitter.Emit(new MessageSingleton());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public ConsumerAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool InsertIssuer()
	{
		return SortIssuer == null;
	}

	internal static ConsumerAuthentication FindIssuer()
	{
		return SortIssuer;
	}
}
