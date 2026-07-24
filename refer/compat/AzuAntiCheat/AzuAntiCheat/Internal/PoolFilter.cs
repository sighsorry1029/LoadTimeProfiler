using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal class PoolFilter
{
	private readonly StubReader descriptorFilter;

	private static PoolFilter CheckAnnotation;

	public PoolFilter(StubReader iParser)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa != 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 0:
				return;
			case 1:
				descriptorFilter = iParser ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-614239580 ^ -614261458));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public void WriteTo(TextWriter textWriter)
	{
		int num = 29;
		int num3 = default(int);
		MappingFactory current = default(MappingFactory);
		char c = default(char);
		QueueFactory queueFactory = default(QueueFactory);
		RefFactory refFactory = default(RefFactory);
		TagFactory tagFactory = default(TagFactory);
		DicFactory dicFactory = default(DicFactory);
		RuleFactory style = default(RuleFactory);
		ClassFactory classFactory = default(ClassFactory);
		string value = default(string);
		ProcessorFactory processorFactory = default(ProcessorFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 34:
					textWriter.Write(DicSingleton.gE3WbyDVW(0x1C9EFC64 ^ 0x1C9E8C7C));
					num2 = 18;
					continue;
				case 39:
					num3 = 0;
					num2 = 46;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
					{
						num2 = 56;
					}
					continue;
				case 58:
				case 59:
					textWriter.Write(DicSingleton.gE3WbyDVW(-1398029315 ^ -1398035435));
					num2 = 57;
					continue;
				case 27:
				case 76:
					textWriter.Write(DicSingleton.gE3WbyDVW(0x7742C60 ^ 0x7745C34));
					num2 = 9;
					continue;
				case 63:
					if (current is ListFactory)
					{
						num2 = 72;
						continue;
					}
					goto case 5;
				case 82:
					textWriter.Write(DicSingleton.gE3WbyDVW(-849667636 ^ -849643976));
					num2 = 79;
					continue;
				case 67:
					if (c != '\\')
					{
						num2 = 71;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
						{
							num2 = 80;
						}
						continue;
					}
					goto case 83;
				case 5:
					queueFactory = current as QueueFactory;
					num2 = 81;
					continue;
				case 64:
					textWriter.Write(DicSingleton.gE3WbyDVW(-293474990 ^ -293502230));
					num2 = 55;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 == 0)
					{
						num2 = 41;
					}
					continue;
				case 8:
					textWriter.Write(DicSingleton.gE3WbyDVW(-1389846755 ^ -1389852319));
					num2 = 41;
					continue;
				case 37:
					return;
				case 2:
					refFactory = current as RefFactory;
					num2 = 6;
					continue;
				case 36:
					switch (c)
					{
					case '\n':
						break;
					default:
						goto IL_03a4;
					case '\r':
						goto IL_0592;
					case '\v':
					case '\f':
						goto IL_0641;
					case '\t':
						goto IL_0653;
					case '\b':
						goto IL_086a;
					}
					goto case 8;
				case 29:
				case 50:
					if (!descriptorFilter.MoveNext())
					{
						num = 37;
						break;
					}
					goto case 28;
				case 66:
					if (tagFactory != null)
					{
						num2 = 35;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb == 0)
						{
							num2 = 29;
						}
						continue;
					}
					goto case 77;
				case 74:
					textWriter.Write(DicSingleton.gE3WbyDVW(-1977574774 ^ -1977554198));
					num2 = 69;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
					{
						num2 = 16;
					}
					continue;
				case 4:
				case 25:
				case 31:
				case 41:
				case 46:
				case 51:
					num3++;
					num2 = 7;
					continue;
				case 73:
					if (dicFactory == null)
					{
						num2 = 63;
						continue;
					}
					goto case 21;
				case 81:
					if (queueFactory != null)
					{
						num2 = 58;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
						{
							num2 = 57;
						}
						continue;
					}
					goto case 12;
				case 30:
				case 35:
					textWriter.Write(DicSingleton.gE3WbyDVW(0x44072FB7 ^ 0x4407402B));
					num2 = 62;
					continue;
				case 21:
					textWriter.Write(DicSingleton.gE3WbyDVW(0x3C33E48 ^ 0x3C3518C));
					num2 = 42;
					continue;
				case 43:
				case 61:
					textWriter.Write(DicSingleton.gE3WbyDVW(-2103041941 ^ -2103029753));
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
					{
						num2 = 1;
					}
					continue;
				case 20:
				case 52:
					textWriter.Write(DicSingleton.gE3WbyDVW(-108820061 ^ -108791421));
					num2 = 70;
					continue;
				case 65:
					style = classFactory.Style;
					num2 = 86;
					continue;
				case 16:
					goto IL_053d;
				case 13:
					goto IL_0592;
				case 12:
					classFactory = current as ClassFactory;
					num2 = 33;
					continue;
				default:
					c = value[num3];
					num2 = 17;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
					{
						num2 = 36;
					}
					continue;
				case 83:
					textWriter.Write(DicSingleton.gE3WbyDVW(--708144185 ^ 0x2A351C79));
					num2 = 25;
					continue;
				case 38:
				case 80:
					goto IL_0641;
				case 44:
					goto IL_0653;
				case 57:
					WriteAnchorAndTag(textWriter, queueFactory);
					num2 = 24;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
					{
						num2 = 24;
					}
					continue;
				case 62:
					textWriter.Write(tagFactory.Value);
					num2 = 11;
					continue;
				case 22:
					if (!(current is RoleSetter))
					{
						num2 = 75;
						continue;
					}
					goto case 74;
				case 87:
					textWriter.Write(DicSingleton.gE3WbyDVW(-428683152 ^ -428687396));
					num2 = 30;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
					{
						num2 = 48;
					}
					continue;
				case 14:
					if (current is SpecificationFactory)
					{
						num2 = 49;
						continue;
					}
					goto case 2;
				case 86:
					switch (style)
					{
					case (RuleFactory)4:
						break;
					case (RuleFactory)5:
						goto IL_053d;
					default:
						goto IL_0755;
					case (RuleFactory)2:
						goto IL_0977;
					case (RuleFactory)3:
						goto IL_0a0e;
					}
					goto case 34;
				case 19:
					dicFactory = current as DicFactory;
					num2 = 73;
					continue;
				case 40:
					if (processorFactory == null)
					{
						num2 = 19;
						continue;
					}
					goto case 87;
				case 33:
					if (classFactory == null)
					{
						num2 = 14;
						continue;
					}
					goto case 82;
				case 49:
				case 71:
					textWriter.Write(DicSingleton.gE3WbyDVW(-830028630 ^ -830032670));
					num2 = 68;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 != 0)
					{
						num2 = 3;
					}
					continue;
				case 79:
					WriteAnchorAndTag(textWriter, classFactory);
					num2 = 57;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 == 0)
					{
						num2 = 65;
					}
					continue;
				case 7:
				case 56:
					if (num3 >= value.Length)
					{
						goto case 3;
					}
					num2 = 85;
					continue;
				case 60:
					goto IL_086a;
				case 75:
					if (!(current is PublisherSetter))
					{
						goto case 3;
					}
					num2 = 61;
					continue;
				case 42:
					if (!dicFactory.IsImplicit)
					{
						num2 = 54;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 3;
				case 84:
					tagFactory = current as TagFactory;
					num2 = 66;
					continue;
				case 48:
					if (!processorFactory.IsImplicit)
					{
						num2 = 64;
						continue;
					}
					goto case 3;
				case 77:
					processorFactory = current as ProcessorFactory;
					num2 = 40;
					continue;
				case 1:
					goto IL_0977;
				case 3:
				case 11:
				case 15:
				case 23:
				case 24:
				case 26:
				case 32:
				case 55:
				case 68:
				case 69:
				case 78:
					textWriter.WriteLine();
					num2 = 50;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
					{
						num2 = 3;
					}
					continue;
				case 10:
				case 72:
					textWriter.Write(DicSingleton.gE3WbyDVW(-360128320 ^ -360149220));
					num2 = 26;
					continue;
				case 45:
					goto IL_0a0e;
				case 28:
					current = descriptorFilter.Current;
					num2 = 37;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 == 0)
					{
						num2 = 84;
					}
					continue;
				case 17:
				case 18:
				case 47:
				case 53:
				case 70:
					value = classFactory.Value;
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 != 0)
					{
						num2 = 39;
					}
					continue;
				case 9:
					WriteAnchorAndTag(textWriter, refFactory);
					num2 = 15;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
					{
						num2 = 2;
					}
					continue;
				case 54:
					textWriter.Write(DicSingleton.gE3WbyDVW(0x4F8CB66E ^ 0x4F8CD9BE));
					num2 = 78;
					continue;
				case 6:
					{
						if (refFactory != null)
						{
							num2 = 27;
							continue;
						}
						goto case 22;
					}
					IL_086a:
					textWriter.Write(DicSingleton.gE3WbyDVW(0x6729A6D ^ 0x672EA45));
					num2 = 51;
					continue;
					IL_0653:
					textWriter.Write(DicSingleton.gE3WbyDVW(--1182565251 ^ 0x467CF3B3));
					num2 = 31;
					continue;
					IL_0a0e:
					textWriter.Write(DicSingleton.gE3WbyDVW(0x9000142 ^ 0x9007142));
					num2 = 17;
					continue;
					IL_0977:
					textWriter.Write(DicSingleton.gE3WbyDVW(0x540450D2 ^ 0x540420DA));
					num2 = 53;
					continue;
					IL_0755:
					num2 = 52;
					continue;
					IL_0641:
					textWriter.Write(c);
					num2 = 4;
					continue;
					IL_0592:
					textWriter.Write(DicSingleton.gE3WbyDVW(-598551743 ^ -598563975));
					num = 46;
					break;
					IL_03a4:
					num2 = 67;
					continue;
					IL_053d:
					textWriter.Write(DicSingleton.gE3WbyDVW(0x6DF53C90 ^ 0x6DF54C80));
					num2 = 47;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
					{
						num2 = 19;
					}
					continue;
				}
				break;
			}
		}
	}

	private void WriteAnchorAndTag(TextWriter textWriter, ListenerFactory nodeEvent)
	{
		int num = 6;
		HelperReader anchor = default(HelperReader);
		ValueFactory tag = default(ValueFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 3:
					return;
				case 2:
					break;
				case 6:
					anchor = nodeEvent.Anchor;
					num2 = 5;
					continue;
				case 1:
					tag = nodeEvent.Tag;
					textWriter.Write(tag.Value);
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
					{
						num2 = 4;
					}
					continue;
				case 8:
					textWriter.Write(DicSingleton.gE3WbyDVW(-316028230 ^ -316032454));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 != 0)
					{
						num2 = 1;
					}
					continue;
				default:
					textWriter.Write(nodeEvent.Anchor);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
					{
						num2 = 2;
					}
					continue;
				case 4:
					textWriter.Write(DicSingleton.gE3WbyDVW(--1509395337 ^ 0x59F7FB01));
					num2 = 3;
					continue;
				case 7:
					textWriter.Write(DicSingleton.gE3WbyDVW(-1059662249 ^ -1059674577));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
					{
						num2 = 0;
					}
					continue;
				case 5:
					if (!anchor.IsEmpty)
					{
						num2 = 7;
						continue;
					}
					break;
				case 9:
					if (tag.IsEmpty)
					{
						return;
					}
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
					{
						num2 = 3;
					}
					continue;
				}
				break;
			}
			tag = nodeEvent.Tag;
			num = 9;
		}
	}

	internal static bool RateAnnotation()
	{
		return CheckAnnotation == null;
	}

	internal static PoolFilter ResetAnnotation()
	{
		return CheckAnnotation;
	}
}
