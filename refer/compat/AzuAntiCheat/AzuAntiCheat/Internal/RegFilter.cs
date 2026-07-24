using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class RegFilter : DatabaseFilter
{
	private static RegFilter EnableAnnotation;

	public RegFilter(DecoratorPrototype nextEmitter)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(nextEmitter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public override void Emit(IdentifierPrototype eventInfo, ModelReader emitter)
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
				eventInfo.NeedsExpansion = true;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public override void Emit(IndexerPrototype eventInfo, ModelReader emitter)
	{
		int num = 5;
		object value = default(object);
		TypeCode typeCode = default(TypeCode);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 28:
					eventInfo.Style = (RuleFactory)3;
					num2 = 20;
					continue;
				case 11:
					eventInfo.RenderedValue = value.ToString();
					num2 = 28;
					continue;
				case 30:
					eventInfo.RenderedValue = IdentifierInterceptor.FormatNumber(value);
					num2 = 25;
					continue;
				case 16:
					throw new NotSupportedException(string.Format(DicSingleton.gE3WbyDVW(-1483531944 ^ -1483509444), typeCode));
				default:
					base.Emit(eventInfo, emitter);
					num2 = 21;
					continue;
				case 1:
					goto IL_017c;
				case 18:
					goto IL_01ab;
				case 26:
					goto IL_01c2;
				case 12:
				case 27:
					goto IL_01e5;
				case 23:
					goto IL_021e;
				case 5:
					eventInfo.IsPlainImplicit = true;
					num2 = 4;
					continue;
				case 3:
					switch (typeCode)
					{
					case TypeCode.Char:
					case TypeCode.String:
						break;
					case TypeCode.Empty:
						goto IL_017c;
					case TypeCode.Boolean:
						goto IL_01ab;
					case TypeCode.SByte:
					case TypeCode.Byte:
					case TypeCode.Int16:
					case TypeCode.UInt16:
					case TypeCode.Int32:
					case TypeCode.UInt32:
					case TypeCode.Int64:
					case TypeCode.UInt64:
						goto IL_01c2;
					case TypeCode.Object:
					case TypeCode.DBNull:
					case (TypeCode)17:
						goto IL_01e5;
					case TypeCode.Single:
					case TypeCode.Double:
					case TypeCode.Decimal:
						goto IL_021e;
					default:
						goto IL_0299;
					case TypeCode.DateTime:
						goto IL_02f7;
					}
					goto case 11;
				case 2:
					if (value == null)
					{
						num2 = 24;
						continue;
					}
					goto case 8;
				case 17:
					eventInfo.Style = (RuleFactory)3;
					num = 9;
					break;
				case 29:
					goto IL_02f7;
				case 7:
					eventInfo.RenderedValue = IdentifierInterceptor.FormatTimeSpan(value);
					num2 = 19;
					continue;
				case 8:
					typeCode = CollectionBase.GetTypeCode(eventInfo.Source.Type);
					num2 = 3;
					continue;
				case 13:
					value = eventInfo.Source.Value;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 != 0)
					{
						num2 = 0;
					}
					continue;
				case 22:
					eventInfo.RenderedValue = value.ToString();
					num2 = 17;
					continue;
				case 21:
					return;
				case 24:
					eventInfo.RenderedValue = DicSingleton.gE3WbyDVW(0x44072FB7 ^ 0x440766D3);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
					{
						num2 = 0;
					}
					continue;
				case 4:
					{
						eventInfo.Style = (RuleFactory)1;
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
						{
							num2 = 13;
						}
						continue;
					}
					IL_01ab:
					eventInfo.RenderedValue = IdentifierInterceptor.FormatBoolean(value);
					num2 = 6;
					continue;
					IL_017c:
					eventInfo.RenderedValue = DicSingleton.gE3WbyDVW(-1507873642 ^ -1507858958);
					num2 = 10;
					continue;
					IL_02f7:
					eventInfo.RenderedValue = IdentifierInterceptor.FormatDateTime(value);
					num2 = 15;
					continue;
					IL_0299:
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
					{
						num2 = 12;
					}
					continue;
					IL_021e:
					eventInfo.RenderedValue = IdentifierInterceptor.FormatNumber(value);
					num2 = 14;
					continue;
					IL_01e5:
					if (eventInfo.Source.Type == typeof(TimeSpan))
					{
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
						{
							num2 = 5;
						}
						continue;
					}
					goto case 16;
					IL_01c2:
					if (CollectionBase.IsEnum(eventInfo.Source.Type))
					{
						num = 22;
						break;
					}
					goto case 30;
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 2:
				eventInfo.Style = (TokenizerFactory)2;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 == 0)
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
			default:
				base.Emit(eventInfo, emitter);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				eventInfo.Style = (ProcFactory)2;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool SortAnnotation()
	{
		return EnableAnnotation == null;
	}

	internal static RegFilter InsertAnnotation()
	{
		return EnableAnnotation;
	}
}
