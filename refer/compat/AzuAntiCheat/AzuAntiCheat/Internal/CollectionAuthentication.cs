using System;

namespace AzuAnticheat.Internal;

internal sealed class CollectionAuthentication : ListAuthentication
{
	private readonly PublisherInvocation m_ManagerAuthentication;

	internal static CollectionAuthentication LogoutIssuer;

	public CollectionAuthentication(ValSetter nextEmitter, PublisherInvocation formatter)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(nextEmitter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
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
			m_ManagerAuthentication = formatter;
			num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
			{
				num = 1;
			}
		}
	}

	public CollectionAuthentication(ValSetter nextEmitter)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(nextEmitter, PublisherInvocation.Default);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public override void Emit(PageSetter eventInfo, MockInterpreter emitter)
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
				eventInfo.NeedsExpansion = true;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public override void Emit(InstanceSetter eventInfo, MockInterpreter emitter)
	{
		int num = 28;
		int num2 = num;
		object value = default(object);
		TypeCode typeCode = default(TypeCode);
		while (true)
		{
			switch (num2)
			{
			case 1:
				eventInfo.Style = (ConnectionInterpreter)3;
				num2 = 7;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
				{
					num2 = 20;
				}
				break;
			case 23:
				eventInfo.RenderedValue = DicSingleton.gE3WbyDVW(-1338893851 ^ -1338879871);
				num2 = 21;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 == 0)
				{
					num2 = 2;
				}
				break;
			case 12:
			case 14:
				eventInfo.RenderedValue = m_ManagerAuthentication.FormatNumber(value);
				num2 = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b == 0)
				{
					num2 = 9;
				}
				break;
			case 22:
				switch (typeCode)
				{
				case TypeCode.Char:
				case TypeCode.String:
					goto IL_0208;
				case TypeCode.DateTime:
					goto IL_022f;
				case TypeCode.Boolean:
					goto IL_02d3;
				case TypeCode.Object:
				case TypeCode.DBNull:
				case (TypeCode)17:
					goto IL_031f;
				case TypeCode.Empty:
					goto IL_0358;
				case TypeCode.Single:
				case TypeCode.Double:
				case TypeCode.Decimal:
					goto IL_038e;
				case TypeCode.SByte:
				case TypeCode.Byte:
				case TypeCode.Int16:
				case TypeCode.UInt16:
				case TypeCode.Int32:
				case TypeCode.UInt32:
				case TypeCode.Int64:
				case TypeCode.UInt64:
					goto IL_0424;
				}
				num2 = 26;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
				{
					num2 = 19;
				}
				break;
			case 10:
				goto IL_0208;
			case 16:
				goto IL_022f;
			case 2:
				eventInfo.RenderedValue = value.ToString();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
				{
					num2 = 1;
				}
				break;
			case 4:
				eventInfo.Style = (ConnectionInterpreter)3;
				num2 = 19;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
				{
					num2 = 2;
				}
				break;
			case 30:
				if (value == null)
				{
					num2 = 22;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 != 0)
					{
						num2 = 23;
					}
					break;
				}
				goto case 11;
			case 5:
				goto IL_02d3;
			case 8:
			case 26:
				goto IL_031f;
			case 25:
				return;
			case 17:
				goto IL_0358;
			case 18:
				goto IL_038e;
			case 13:
				throw new NotSupportedException(string.Format(DicSingleton.gE3WbyDVW(0x940D407 ^ 0x940BC63), typeCode));
			default:
				base.Emit(eventInfo, emitter);
				num2 = 25;
				break;
			case 27:
				eventInfo.Style = (ConnectionInterpreter)1;
				num2 = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 != 0)
				{
					num2 = 6;
				}
				break;
			case 28:
				eventInfo.IsPlainImplicit = true;
				num2 = 27;
				break;
			case 3:
				goto IL_0424;
			case 11:
				typeCode = InterceptorSetter.GetTypeCode(eventInfo.Source.Type);
				num2 = 22;
				break;
			case 15:
				eventInfo.RenderedValue = m_ManagerAuthentication.FormatTimeSpan(value);
				num2 = 29;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 != 0)
				{
					num2 = 18;
				}
				break;
			case 6:
				{
					value = eventInfo.Source.Value;
					num2 = 30;
					break;
				}
				IL_022f:
				eventInfo.RenderedValue = m_ManagerAuthentication.FormatDateTime(value);
				num2 = 24;
				break;
				IL_031f:
				if (eventInfo.Source.Type == typeof(TimeSpan))
				{
					num2 = 15;
					break;
				}
				goto case 13;
				IL_02d3:
				eventInfo.RenderedValue = m_ManagerAuthentication.FormatBoolean(value);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
				{
					num2 = 0;
				}
				break;
				IL_0424:
				if (!InterceptorSetter.IsEnum(eventInfo.Source.Type))
				{
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c != 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 2;
				IL_0208:
				eventInfo.RenderedValue = value.ToString();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
				{
					num2 = 4;
				}
				break;
				IL_038e:
				eventInfo.RenderedValue = m_ManagerAuthentication.FormatNumber(value);
				num2 = 7;
				break;
				IL_0358:
				eventInfo.RenderedValue = DicSingleton.gE3WbyDVW(-25744665 ^ -25730173);
				num2 = 31;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
				{
					num2 = 31;
				}
				break;
			}
		}
	}

	public override void Emit(RecordSetter eventInfo, MockInterpreter emitter)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			default:
				base.Emit(eventInfo, emitter);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 != 0)
				{
					num2 = 2;
				}
				break;
			case 1:
				eventInfo.Style = (Level)2;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public override void Emit(StatusSetter eventInfo, MockInterpreter emitter)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				base.Emit(eventInfo, emitter);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 2:
				eventInfo.Style = (DockingBehavior)2;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	internal static bool CountIssuer()
	{
		return LogoutIssuer == null;
	}

	internal static CollectionAuthentication SetIssuer()
	{
		return LogoutIssuer;
	}
}
