using System;

namespace AzuAnticheat.Internal;

internal abstract class ListAuthentication : ValSetter
{
	protected readonly ValSetter m_QueueAuthentication;

	private static ListAuthentication AssetIssuer;

	protected ListAuthentication(ValSetter nextEmitter)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
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
			m_QueueAuthentication = nextEmitter ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-32257720 ^ -32266946));
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
			{
				num = 1;
			}
		}
	}

	public virtual void Emit(PageSetter eventInfo, MockInterpreter emitter)
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
				m_QueueAuthentication.Emit(eventInfo, emitter);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public virtual void Emit(InstanceSetter eventInfo, MockInterpreter emitter)
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
				m_QueueAuthentication.Emit(eventInfo, emitter);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public virtual void Emit(RecordSetter eventInfo, MockInterpreter emitter)
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
				m_QueueAuthentication.Emit(eventInfo, emitter);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public virtual void Emit(ParameterSetter eventInfo, MockInterpreter emitter)
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
				m_QueueAuthentication.Emit(eventInfo, emitter);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public virtual void Emit(StatusSetter eventInfo, MockInterpreter emitter)
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
				m_QueueAuthentication.Emit(eventInfo, emitter);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public virtual void Emit(AttrSetter eventInfo, MockInterpreter emitter)
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
				m_QueueAuthentication.Emit(eventInfo, emitter);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool ListIssuer()
	{
		return AssetIssuer == null;
	}

	internal static ListAuthentication CalcIssuer()
	{
		return AssetIssuer;
	}
}
