using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AzuAnticheat.Internal;

internal sealed class TokenizerAuthentication : ListAuthentication
{
	private readonly bool m_ListenerAuthentication;

	private readonly IDictionary<Type, RoleSingleton> _AccountAuthentication;

	private readonly bool threadAuthentication;

	private readonly Regex? m_MappingAuthentication;

	private static readonly string m_SchemaAuthentication;

	private static readonly string _StructAuthentication;

	private readonly ConnectionInterpreter m_ClassAuthentication;

	private readonly PublisherInvocation objectAuthentication;

	internal static TokenizerAuthentication PushIssuer;

	public TokenizerAuthentication(ValSetter nextEmitter, bool requireTagWhenStaticAndActualTypesAreDifferent, IDictionary<Type, RoleSingleton> tagMappings, bool quoteNecessaryStrings, bool quoteYaml1_1Strings, ConnectionInterpreter defaultScalarStyle, PublisherInvocation formatter)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(nextEmitter);
		m_ClassAuthentication = defaultScalarStyle;
		objectAuthentication = formatter;
		_AccountAuthentication = tagMappings;
		threadAuthentication = quoteNecessaryStrings;
		m_MappingAuthentication = new Regex(quoteYaml1_1Strings ? _StructAuthentication : m_SchemaAuthentication, RegexOptions.Compiled);
	}

	public TokenizerAuthentication(ValSetter nextEmitter, bool requireTagWhenStaticAndActualTypesAreDifferent, IDictionary<Type, RoleSingleton> tagMappings, bool quoteNecessaryStrings, bool quoteYaml1_1Strings, ConnectionInterpreter defaultScalarStyle)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(nextEmitter, requireTagWhenStaticAndActualTypesAreDifferent, tagMappings, quoteNecessaryStrings, quoteYaml1_1Strings, defaultScalarStyle, PublisherInvocation.Default);
	}

	public TokenizerAuthentication(ValSetter nextEmitter, bool requireTagWhenStaticAndActualTypesAreDifferent, IDictionary<Type, RoleSingleton> tagMappings, bool quoteNecessaryStrings, ConnectionInterpreter defaultScalarStyle)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(nextEmitter, requireTagWhenStaticAndActualTypesAreDifferent, tagMappings, quoteNecessaryStrings, quoteYaml1_1Strings: false, defaultScalarStyle, PublisherInvocation.Default);
	}

	public TokenizerAuthentication(ValSetter nextEmitter, bool requireTagWhenStaticAndActualTypesAreDifferent, IDictionary<Type, RoleSingleton> tagMappings, bool quoteNecessaryStrings, bool quoteYaml1_1Strings)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(nextEmitter, requireTagWhenStaticAndActualTypesAreDifferent, tagMappings, quoteNecessaryStrings, quoteYaml1_1Strings, (ConnectionInterpreter)0);
	}

	public TokenizerAuthentication(ValSetter nextEmitter, bool requireTagWhenStaticAndActualTypesAreDifferent, IDictionary<Type, RoleSingleton> tagMappings, bool quoteNecessaryStrings)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(nextEmitter, requireTagWhenStaticAndActualTypesAreDifferent, tagMappings, quoteNecessaryStrings, quoteYaml1_1Strings: false);
	}

	public TokenizerAuthentication(ValSetter nextEmitter, bool requireTagWhenStaticAndActualTypesAreDifferent, IDictionary<Type, RoleSingleton> tagMappings)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(nextEmitter);
		m_ListenerAuthentication = requireTagWhenStaticAndActualTypesAreDifferent;
		_AccountAuthentication = tagMappings ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-2075300707 ^ -2075326897));
		objectAuthentication = PublisherInvocation.Default;
	}

	public override void Emit(InstanceSetter eventInfo, MockInterpreter emitter)
	{
		int num = 1;
		ConnectionInterpreter style = default(ConnectionInterpreter);
		object value = default(object);
		TypeCode typeCode = default(TypeCode);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 34:
					style = (ConnectionInterpreter)3;
					num2 = 17;
					continue;
				case 13:
					eventInfo.Tag = TagInvocation.VisitorInvocation.m_StubInvocation;
					num2 = 35;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 != 0)
					{
						num2 = 45;
					}
					continue;
				case 54:
					goto IL_0136;
				case 12:
					goto IL_0174;
				case 3:
				case 39:
				case 42:
					style = m_ClassAuthentication;
					num2 = 20;
					continue;
				case 43:
					eventInfo.RenderedValue = value.ToString();
					num2 = 9;
					continue;
				case 28:
					eventInfo.RenderedValue = objectAuthentication.FormatTimeSpan(value);
					num2 = 5;
					continue;
				case 16:
					eventInfo.Tag = TagInvocation.VisitorInvocation.m_StubInvocation;
					num2 = 4;
					continue;
				case 19:
					goto IL_0221;
				case 4:
					eventInfo.RenderedValue = "";
					num2 = 46;
					continue;
				case 2:
					typeCode = InterceptorSetter.GetTypeCode(eventInfo.Source.Type);
					num2 = 52;
					continue;
				case 24:
					if (value == null)
					{
						num2 = 16;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 != 0)
						{
							num2 = 10;
						}
						continue;
					}
					goto case 2;
				case 22:
					eventInfo.RenderedValue = objectAuthentication.FormatNumber((double)value);
					num = 49;
					break;
				case 40:
					if (eventInfo.Style != 0)
					{
						num = 18;
						break;
					}
					goto case 41;
				case 56:
					eventInfo.RenderedValue = objectAuthentication.FormatNumber((float)value);
					num2 = 53;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 != 0)
					{
						num2 = 45;
					}
					continue;
				case 7:
					if (!IsSpecialStringValue(eventInfo.RenderedValue))
					{
						num2 = 39;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 != 0)
						{
							num2 = 33;
						}
						continue;
					}
					goto case 31;
				case 45:
					eventInfo.RenderedValue = "";
					num2 = 21;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 != 0)
					{
						num2 = 48;
					}
					continue;
				case 26:
					eventInfo.Tag = TagInvocation.VisitorInvocation.strategyInvocation;
					num2 = 57;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 != 0)
					{
						num2 = 11;
					}
					continue;
				case 47:
					goto IL_03e9;
				case 25:
				case 36:
					goto IL_0420;
				case 27:
					goto IL_0487;
				case 52:
					switch (typeCode)
					{
					case TypeCode.Empty:
						break;
					case TypeCode.SByte:
					case TypeCode.Byte:
					case TypeCode.Int16:
					case TypeCode.UInt16:
					case TypeCode.Int32:
					case TypeCode.UInt32:
					case TypeCode.Int64:
					case TypeCode.UInt64:
						goto IL_0136;
					case TypeCode.Boolean:
						goto IL_0174;
					case TypeCode.Char:
					case TypeCode.String:
						goto IL_0221;
					case TypeCode.Single:
						goto IL_03e9;
					case TypeCode.Object:
					case TypeCode.DBNull:
					case (TypeCode)17:
						goto IL_0420;
					case TypeCode.Decimal:
						goto IL_0487;
					default:
						goto IL_04ef;
					case TypeCode.DateTime:
						goto IL_05ae;
					case TypeCode.Double:
						goto IL_05c3;
					}
					goto case 13;
				case 14:
					eventInfo.RenderedValue = objectAuthentication.FormatBoolean(value);
					num = 15;
					break;
				case 35:
					return;
				case 1:
					style = (ConnectionInterpreter)1;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
					{
						num2 = 0;
					}
					continue;
				case 31:
					style = (ConnectionInterpreter)3;
					num2 = 37;
					continue;
				case 10:
					eventInfo.RenderedValue = objectAuthentication.FormatNumber(value);
					num2 = 33;
					continue;
				case 50:
					eventInfo.RenderedValue = objectAuthentication.FormatDateTime(value);
					num2 = 55;
					continue;
				case 32:
					goto IL_05ae;
				case 51:
					goto IL_05c3;
				case 8:
					eventInfo.RenderedValue = value.ToString();
					num2 = 15;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
					{
						num2 = 38;
					}
					continue;
				case 21:
					throw new NotSupportedException(string.Format(DicSingleton.gE3WbyDVW(0x270E0638 ^ 0x270E6E5C), typeCode));
				case 5:
				case 6:
				case 11:
				case 15:
				case 17:
				case 20:
				case 33:
				case 37:
				case 46:
				case 48:
				case 49:
				case 53:
				case 55:
					eventInfo.IsPlainImplicit = true;
					num2 = 40;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
					{
						num2 = 40;
					}
					continue;
				case 18:
				case 44:
					base.Emit(eventInfo, emitter);
					num2 = 35;
					continue;
				case 29:
					if (IsSpecialStringValue(eventInfo.RenderedValue))
					{
						num2 = 34;
						continue;
					}
					goto case 23;
				case 38:
					if (!threadAuthentication)
					{
						num2 = 19;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 != 0)
						{
							num2 = 42;
						}
						continue;
					}
					goto case 7;
				case 41:
					eventInfo.Style = style;
					num2 = 44;
					continue;
				default:
					value = eventInfo.Source.Value;
					num2 = 24;
					continue;
				case 23:
					style = m_ClassAuthentication;
					num2 = 6;
					continue;
				case 9:
					if (threadAuthentication)
					{
						num2 = 19;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
						{
							num2 = 29;
						}
						continue;
					}
					goto case 23;
				case 30:
					eventInfo.Tag = AdvisorInvocation.ConnectionInvocation.m_RepositoryInvocation;
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 != 0)
					{
						num2 = 6;
					}
					continue;
				case 57:
					{
						eventInfo.RenderedValue = objectAuthentication.FormatNumber(value);
						num2 = 11;
						continue;
					}
					IL_0136:
					if (eventInfo.Source.Type.IsEnum)
					{
						num2 = 30;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
						{
							num2 = 9;
						}
						continue;
					}
					goto case 26;
					IL_05c3:
					eventInfo.Tag = TagInvocation.VisitorInvocation.m_ProcessorInvocation;
					num2 = 22;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
					{
						num2 = 21;
					}
					continue;
					IL_05ae:
					eventInfo.Tag = ParamsInvocation.PoolInvocation._DescriptorInvocation;
					num2 = 50;
					continue;
					IL_04ef:
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
					{
						num2 = 25;
					}
					continue;
					IL_0221:
					eventInfo.Tag = AdvisorInvocation.ConnectionInvocation.m_RepositoryInvocation;
					num2 = 18;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
					{
						num2 = 43;
					}
					continue;
					IL_0487:
					eventInfo.Tag = TagInvocation.VisitorInvocation.m_ProcessorInvocation;
					num2 = 10;
					continue;
					IL_0420:
					if (eventInfo.Source.Type == typeof(TimeSpan))
					{
						num2 = 28;
						continue;
					}
					goto case 21;
					IL_03e9:
					eventInfo.Tag = TagInvocation.VisitorInvocation.m_ProcessorInvocation;
					num2 = 56;
					continue;
					IL_0174:
					eventInfo.Tag = TagInvocation.VisitorInvocation._PolicyInvocation;
					num2 = 14;
					continue;
				}
				break;
			}
		}
	}

	public override void Emit(RecordSetter eventInfo, MockInterpreter emitter)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				AssignTypeIfNeeded(eventInfo);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
				{
					num2 = 1;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public override void Emit(StatusSetter eventInfo, MockInterpreter emitter)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				AssignTypeIfNeeded(eventInfo);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec != 0)
				{
					num2 = 0;
				}
				break;
			default:
				base.Emit(eventInfo, emitter);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				return;
			}
		}
	}

	private void AssignTypeIfNeeded(ParamSetter eventInfo)
	{
		int num = 6;
		int num2 = num;
		RoleSingleton value = default(RoleSingleton);
		while (true)
		{
			switch (num2)
			{
			case 2:
				throw new ReaderSingleton(DicSingleton.gE3WbyDVW(-1735703950 ^ -1735708958) + eventInfo.Source.Type.FullName + DicSingleton.gE3WbyDVW(-940539791 ^ -940512077) + eventInfo.Source.StaticType.FullName + DicSingleton.gE3WbyDVW(-1335677307 ^ -1335672231) + eventInfo.Source.Type.FullName + DicSingleton.gE3WbyDVW(-1447578472 ^ -1447568954) + eventInfo.Source.Type.Name + DicSingleton.gE3WbyDVW(0x2D27936 ^ 0x2D217F6) + eventInfo.Source.Type.FullName + DicSingleton.gE3WbyDVW(--1844849127 ^ 0x6DF6473F));
			default:
				if (!(eventInfo.Source.Type != eventInfo.Source.StaticType))
				{
					return;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 != 0)
				{
					num2 = 2;
				}
				continue;
			case 4:
				if (eventInfo.Source.Value == null)
				{
					return;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 == 0)
				{
					num2 = 0;
				}
				continue;
			case 1:
				return;
			case 5:
				if (!m_ListenerAuthentication)
				{
					return;
				}
				num2 = 4;
				continue;
			case 6:
				if (!_AccountAuthentication.TryGetValue(eventInfo.Source.Type, out value))
				{
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 != 0)
					{
						num2 = 3;
					}
					continue;
				}
				break;
			case 3:
				break;
			}
			eventInfo.Tag = value;
			num2 = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
			{
				num2 = 0;
			}
		}
	}

	private bool IsSpecialStringValue(string value)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (!(value.Trim() == string.Empty))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			case 2:
				return true;
			default:
			{
				Regex? mappingAuthentication = m_MappingAuthentication;
				if (mappingAuthentication == null)
				{
					num2 = 3;
					break;
				}
				return mappingAuthentication.IsMatch(value);
			}
			case 3:
				return false;
			}
		}
	}

	static TokenizerAuthentication()
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				return;
			case 3:
				GetterIssuer.DeleteInitializer();
				num2 = 2;
				break;
			case 2:
				m_SchemaAuthentication = DicSingleton.gE3WbyDVW(0x5A1F7167 ^ 0x5A1FC13F);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 != 0)
				{
					num2 = 0;
				}
				break;
			default:
				_StructAuthentication = DicSingleton.gE3WbyDVW(0x1A7A0414 ^ 0x1A7AB5DA);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	internal static bool ValidateIssuer()
	{
		return PushIssuer == null;
	}

	internal static TokenizerAuthentication EnableIssuer()
	{
		return PushIssuer;
	}
}
