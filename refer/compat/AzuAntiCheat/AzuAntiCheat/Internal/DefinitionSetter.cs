using System;
using System.IO;

namespace AzuAnticheat.Internal;

internal sealed class DefinitionSetter : ExporterSetter
{
	private readonly AnnotationSetter _ComposerSetter;

	internal static DefinitionSetter CalcParameter;

	public DefinitionSetter()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(new GlobalSetter().BuildValueDeserializer());
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	private DefinitionSetter(AnnotationSetter valueDeserializer)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
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
			_ComposerSetter = valueDeserializer ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x270E0638 ^ 0x270E505E));
			num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
			{
				num = 1;
			}
		}
	}

	public static DefinitionSetter FromValueDeserializer(AnnotationSetter valueDeserializer)
	{
		return new DefinitionSetter(valueDeserializer);
	}

	public T Deserialize<T>(string input)
	{
		using StringReader input2 = new StringReader(input);
		return Deserialize<T>(input2);
	}

	public T Deserialize<T>(TextReader input)
	{
		return Deserialize<T>(new ExporterInterpreter(input));
	}

	public T Deserialize<T>(CandidateInterpreter parser)
	{
		return (T)Deserialize(parser, typeof(T));
	}

	public object? Deserialize(string input)
	{
		return Deserialize(input, typeof(object));
	}

	public object? Deserialize(TextReader input)
	{
		return Deserialize(input, typeof(object));
	}

	public object? Deserialize(CandidateInterpreter parser)
	{
		return Deserialize(parser, typeof(object));
	}

	public object? Deserialize(string input, Type type)
	{
		int num = 1;
		int num2 = num;
		object result = default(object);
		StringReader stringReader = default(StringReader);
		while (true)
		{
			switch (num2)
			{
			default:
				try
				{
					result = Deserialize(stringReader, type);
					int num3 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
					{
						num3 = 0;
					}
					switch (num3)
					{
					case 0:
						break;
					}
				}
				finally
				{
					int num4;
					if (stringReader == null)
					{
						num4 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 != 0)
						{
							num4 = 0;
						}
						goto IL_008a;
					}
					goto IL_00bf;
					IL_008a:
					switch (num4)
					{
					default:
						goto end_IL_0065;
					case 1:
						goto end_IL_0065;
					case 2:
						break;
					case 0:
						goto end_IL_0065;
					}
					goto IL_00bf;
					IL_00bf:
					((IDisposable)stringReader).Dispose();
					num4 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c != 0)
					{
						num4 = 0;
					}
					goto IL_008a;
					end_IL_0065:;
				}
				break;
			case 1:
				stringReader = new StringReader(input);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa != 0)
				{
					num2 = 0;
				}
				continue;
			case 2:
				break;
			}
			break;
		}
		return result;
	}

	public object? Deserialize(TextReader input, Type type)
	{
		return Deserialize(new ExporterInterpreter(input), type);
	}

	public object? Deserialize(CandidateInterpreter parser, Type type)
	{
		int num = 10;
		bool flag2 = default(bool);
		object result = default(object);
		MethodInvocation methodInvocation = default(MethodInvocation);
		bool flag = default(bool);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 3:
					if (flag2)
					{
						num = 2;
						break;
					}
					goto case 11;
				case 2:
					parser.Consume<TaskSingleton>();
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
					{
						num2 = 11;
					}
					continue;
				case 8:
					return result;
				default:
					parser.Consume<WrapperSingleton>();
					num2 = 8;
					continue;
				case 6:
					try
					{
						result = _ComposerSetter.DeserializeValue(parser, type, methodInvocation, _ComposerSetter);
						int num3 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
						{
							num3 = 0;
						}
						while (true)
						{
							switch (num3)
							{
							default:
								methodInvocation.OnDeserialization();
								num3 = 1;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
								{
									num3 = 0;
								}
								continue;
							case 1:
								break;
							}
							break;
						}
					}
					finally
					{
						int num4;
						if (methodInvocation == null)
						{
							num4 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb == 0)
							{
								num4 = 0;
							}
							goto IL_0131;
						}
						goto IL_0166;
						IL_0131:
						switch (num4)
						{
						default:
							goto end_IL_010c;
						case 0:
							goto end_IL_010c;
						case 1:
							break;
						case 2:
							goto end_IL_010c;
						}
						goto IL_0166;
						IL_0166:
						((IDisposable)methodInvocation).Dispose();
						num4 = 2;
						goto IL_0131;
						end_IL_010c:;
					}
					goto case 3;
				case 1:
				{
					if (!parser.Accept<WrapperSingleton>(out var _))
					{
						num2 = 12;
						continue;
					}
					goto case 3;
				}
				case 5:
				{
					flag2 = parser.TryConsume<TestsSingleton>(out var _);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
					{
						num2 = 4;
					}
					continue;
				}
				case 13:
				{
					if (!parser.Accept<TaskSingleton>(out var _))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 3;
				}
				case 11:
					if (flag)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 8;
				case 10:
					if (parser == null)
					{
						num2 = 9;
						continue;
					}
					if (!(type == null))
					{
						flag = parser.TryConsume<ServerSingleton>(out var _);
						num2 = 5;
						continue;
					}
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
					{
						num2 = 7;
					}
					continue;
				case 7:
					throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x44072FB7 ^ 0x4407792B));
				case 9:
					throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1614185587 ^ -1614205695));
				case 12:
					methodInvocation = new MethodInvocation();
					num = 6;
					break;
				case 4:
					result = null;
					num2 = 13;
					continue;
				}
				break;
			}
		}
	}

	internal static bool LogoutParameter()
	{
		return CalcParameter == null;
	}

	internal static DefinitionSetter CountParameter()
	{
		return CalcParameter;
	}
}
