using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class ReponseFilter : DatabaseFilter
{
	private readonly bool proxyFilter;

	private readonly IDictionary<Type, ValueFactory> _ModelFilter;

	private static ReponseFilter FindAnnotation;

	public ReponseFilter(DecoratorPrototype nextEmitter, bool requireTagWhenStaticAndActualTypesAreDifferent, IDictionary<Type, ValueFactory> tagMappings)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(nextEmitter);
		proxyFilter = requireTagWhenStaticAndActualTypesAreDifferent;
		_ModelFilter = tagMappings ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(--1509395337 ^ 0x59F7E15B));
	}

	public override void Emit(IndexerPrototype eventInfo, ModelReader emitter)
	{
		int num = 9;
		RuleFactory style = default(RuleFactory);
		object value = default(object);
		TypeCode typeCode = default(TypeCode);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					base.Emit(eventInfo, emitter);
					num2 = 3;
					continue;
				case 25:
					eventInfo.RenderedValue = "";
					num2 = 41;
					continue;
				case 39:
					eventInfo.Style = style;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
					{
						num2 = 0;
					}
					continue;
				case 21:
					if (eventInfo.Style != 0)
					{
						num2 = 18;
						continue;
					}
					goto case 39;
				case 26:
					eventInfo.RenderedValue = IdentifierInterceptor.FormatNumber((double)value);
					num = 7;
					break;
				case 4:
					eventInfo.RenderedValue = IdentifierInterceptor.FormatNumber(value);
					num = 24;
					break;
				case 32:
					eventInfo.Tag = QueueInterceptor.CollectionInterceptor._AccountInterceptor;
					num2 = 4;
					continue;
				case 35:
					goto IL_0194;
				case 14:
					goto IL_01a9;
				case 33:
					eventInfo.RenderedValue = IdentifierInterceptor.FormatNumber((float)value);
					num2 = 2;
					continue;
				case 22:
					eventInfo.RenderedValue = "";
					num2 = 38;
					continue;
				case 31:
					eventInfo.Tag = QueueInterceptor.CollectionInterceptor.managerInterceptor;
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 != 0)
					{
						num2 = 25;
					}
					continue;
				case 5:
					eventInfo.RenderedValue = IdentifierInterceptor.FormatNumber(value);
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 != 0)
					{
						num2 = 1;
					}
					continue;
				case 6:
					typeCode = CollectionBase.GetTypeCode(eventInfo.Source.Type);
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 != 0)
					{
						num2 = 17;
					}
					continue;
				case 3:
					return;
				case 1:
					eventInfo.RenderedValue = IdentifierInterceptor.FormatTimeSpan(value);
					num = 28;
					break;
				case 8:
					value = eventInfo.Source.Value;
					num2 = 40;
					continue;
				case 11:
					goto IL_02a9;
				case 17:
					switch (typeCode)
					{
					case TypeCode.Decimal:
						break;
					case TypeCode.Boolean:
						goto IL_0194;
					case TypeCode.Single:
						goto IL_01a9;
					case TypeCode.SByte:
					case TypeCode.Byte:
					case TypeCode.Int16:
					case TypeCode.UInt16:
					case TypeCode.Int32:
					case TypeCode.UInt32:
					case TypeCode.Int64:
					case TypeCode.UInt64:
						goto IL_02a9;
					default:
						goto IL_0320;
					case TypeCode.DateTime:
						goto IL_03c7;
					case TypeCode.Double:
						goto IL_0417;
					case TypeCode.Empty:
						goto IL_043c;
					case TypeCode.Char:
					case TypeCode.String:
						goto IL_0498;
					case TypeCode.Object:
					case TypeCode.DBNull:
					case (TypeCode)17:
						goto IL_04bd;
					}
					goto case 32;
				case 29:
					throw new NotSupportedException(string.Format(DicSingleton.gE3WbyDVW(-1931860206 ^ -1931849866), typeCode));
				case 2:
				case 7:
				case 10:
				case 12:
				case 13:
				case 19:
				case 24:
				case 28:
				case 38:
				case 41:
					eventInfo.IsPlainImplicit = true;
					num2 = 21;
					continue;
				case 27:
					goto IL_03c7;
				case 30:
					eventInfo.RenderedValue = IdentifierInterceptor.FormatDateTime(value);
					num = 19;
					break;
				case 40:
					if (value == null)
					{
						num2 = 31;
						continue;
					}
					goto case 6;
				case 42:
					goto IL_0417;
				case 37:
					goto IL_043c;
				case 20:
					eventInfo.RenderedValue = value.ToString();
					num2 = 36;
					continue;
				case 9:
					style = (RuleFactory)1;
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
					{
						num2 = 1;
					}
					continue;
				case 23:
					goto IL_0498;
				case 16:
				case 34:
					goto IL_04bd;
				case 15:
					eventInfo.RenderedValue = IdentifierInterceptor.FormatBoolean(value);
					num2 = 13;
					continue;
				case 36:
					{
						style = (RuleFactory)0;
						num2 = 10;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
						{
							num2 = 4;
						}
						continue;
					}
					IL_01a9:
					eventInfo.Tag = QueueInterceptor.CollectionInterceptor._AccountInterceptor;
					num2 = 33;
					continue;
					IL_0194:
					eventInfo.Tag = QueueInterceptor.CollectionInterceptor.tokenizerInterceptor;
					num2 = 15;
					continue;
					IL_04bd:
					if (eventInfo.Source.Type == typeof(TimeSpan))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 29;
					IL_0498:
					eventInfo.Tag = ParamsInterceptor.PoolInterceptor._ListInterceptor;
					num2 = 20;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
					{
						num2 = 16;
					}
					continue;
					IL_043c:
					eventInfo.Tag = QueueInterceptor.CollectionInterceptor.managerInterceptor;
					num2 = 22;
					continue;
					IL_0417:
					eventInfo.Tag = QueueInterceptor.CollectionInterceptor._AccountInterceptor;
					num2 = 26;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
					{
						num2 = 5;
					}
					continue;
					IL_03c7:
					eventInfo.Tag = SchemaInterceptor.StructInterceptor._ClassInterceptor;
					num2 = 30;
					continue;
					IL_0320:
					num2 = 34;
					continue;
					IL_02a9:
					eventInfo.Tag = QueueInterceptor.CollectionInterceptor.m_ListenerInterceptor;
					num2 = 5;
					continue;
				}
				break;
			}
		}
	}

	public override void Emit(WatcherPrototype eventInfo, ModelReader emitter)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 2:
				AssignTypeIfNeeded(eventInfo);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a != 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	public override void Emit(CandidatePrototype eventInfo, ModelReader emitter)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			case 1:
				AssignTypeIfNeeded(eventInfo);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 != 0)
				{
					num2 = 0;
				}
				break;
			default:
				base.Emit(eventInfo, emitter);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	private void AssignTypeIfNeeded(RulesPrototype eventInfo)
	{
		int num = 5;
		int num2 = num;
		ValueFactory value = default(ValueFactory);
		while (true)
		{
			switch (num2)
			{
			case 2:
				if (eventInfo.Source.Value == null)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto default;
			case 8:
				throw new TestsFactory(DicSingleton.gE3WbyDVW(0x7A125A0E ^ 0x7A12369E) + eventInfo.Source.Type.FullName + DicSingleton.gE3WbyDVW(0x2BB207E4 ^ 0x2BB26B26) + eventInfo.Source.StaticType.FullName + DicSingleton.gE3WbyDVW(0x4C73F208 ^ 0x4C739ED4) + eventInfo.Source.Type.FullName + DicSingleton.gE3WbyDVW(0xDA293E6 ^ 0xDA2FEB8) + eventInfo.Source.Type.Name + DicSingleton.gE3WbyDVW(-1544119467 ^ -1544096363) + eventInfo.Source.Type.FullName + DicSingleton.gE3WbyDVW(-1011281439 ^ -1011253447));
			case 3:
				return;
			case 7:
				return;
			case 1:
				eventInfo.Tag = value;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
				{
					num2 = 6;
				}
				break;
			default:
				if (!(eventInfo.Source.Type != eventInfo.Source.StaticType))
				{
					return;
				}
				num2 = 8;
				break;
			case 6:
				return;
			case 4:
				if (!proxyFilter)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
					{
						num2 = 7;
					}
					break;
				}
				goto case 2;
			case 5:
				if (!_ModelFilter.TryGetValue(eventInfo.Source.Type, out value))
				{
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
					{
						num2 = 2;
					}
					break;
				}
				goto case 1;
			}
		}
	}

	internal static bool VisitAnnotation()
	{
		return FindAnnotation == null;
	}

	internal static ReponseFilter OrderAnnotation()
	{
		return FindAnnotation;
	}
}
