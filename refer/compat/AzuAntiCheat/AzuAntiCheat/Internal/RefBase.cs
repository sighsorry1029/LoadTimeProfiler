using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class RefBase : ValuePrototype
{
	private readonly ContainerPrototype m_ObserverBase;

	private static RefBase ListConfiguration;

	public RefBase()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(new AdapterBase().BuildValueDeserializer());
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	private RefBase(ContainerPrototype valueDeserializer)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
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
			m_ObserverBase = valueDeserializer ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x548F02D9 ^ 0x548F54BF));
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
			{
				num = 1;
			}
		}
	}

	public static RefBase FromValueDeserializer(ContainerPrototype valueDeserializer)
	{
		return new RefBase(valueDeserializer);
	}

	public T Deserialize<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] T>(string input)
	{
		using StringReader input2 = new StringReader(input);
		return Deserialize<T>(input2);
	}

	public T Deserialize<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] T>(TextReader input)
	{
		return Deserialize<T>(new PublisherFactory(input));
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public object Deserialize(TextReader input)
	{
		return Deserialize(input, typeof(object));
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public object Deserialize(string input, Type type)
	{
		int num = 1;
		int num2 = num;
		StringReader stringReader = default(StringReader);
		object result = default(object);
		while (true)
		{
			switch (num2)
			{
			case 1:
				stringReader = new StringReader(input);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef != 0)
				{
					num2 = 0;
				}
				continue;
			case 2:
				break;
			default:
				try
				{
					result = Deserialize(stringReader, type);
					int num3 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 != 0)
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
					if (stringReader != null)
					{
						int num4 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
						{
							num4 = 1;
						}
						while (true)
						{
							switch (num4)
							{
							case 1:
								((IDisposable)stringReader).Dispose();
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
								{
									num4 = 0;
								}
								continue;
							case 0:
								break;
							}
							break;
						}
					}
				}
				break;
			}
			break;
		}
		return result;
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public object Deserialize(TextReader input, Type type)
	{
		return Deserialize(new PublisherFactory(input), type);
	}

	public T Deserialize<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] T>(StubReader parser)
	{
		return (T)Deserialize(parser, typeof(T));
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public object Deserialize(StubReader parser)
	{
		return Deserialize(parser, typeof(object));
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public object Deserialize(StubReader parser, Type type)
	{
		int num = 2;
		object result = default(object);
		RequestInterceptor requestInterceptor = default(RequestInterceptor);
		bool flag2 = default(bool);
		bool flag = default(bool);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 8:
				case 13:
					return result;
				case 5:
					parser.Consume<RoleSetter>();
					num2 = 13;
					continue;
				case 4:
					requestInterceptor = new RequestInterceptor();
					num2 = 9;
					continue;
				default:
					result = null;
					num = 12;
					break;
				case 7:
				case 15:
					if (!flag2)
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 != 0)
						{
							num2 = 8;
						}
						continue;
					}
					goto case 5;
				case 16:
					parser.Consume<ProcessorFactory>();
					num = 7;
					break;
				case 12:
				{
					if (!parser.Accept<ProcessorFactory>(out var _))
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
						{
							num2 = 11;
						}
						continue;
					}
					goto case 3;
				}
				case 3:
				case 14:
					if (!flag)
					{
						num = 15;
						break;
					}
					goto case 16;
				case 11:
				{
					if (parser.Accept<RoleSetter>(out var _))
					{
						num2 = 14;
						continue;
					}
					goto case 4;
				}
				case 10:
					throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1244021215 ^ -1244010307));
				case 2:
					if (parser == null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
						{
							num2 = 1;
						}
					}
					else if (!(type == null))
					{
						flag2 = parser.TryConsume<PublisherSetter>(out var _);
						num2 = 6;
					}
					else
					{
						num2 = 10;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
						{
							num2 = 9;
						}
					}
					continue;
				case 1:
					throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x3A437A88 ^ 0x3A432C04));
				case 9:
					try
					{
						result = m_ObserverBase.DeserializeValue(parser, type, requestInterceptor, m_ObserverBase);
						int num3 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
						{
							num3 = 1;
						}
						while (true)
						{
							switch (num3)
							{
							case 1:
								requestInterceptor.OnDeserialization();
								num3 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
								{
									num3 = 0;
								}
								continue;
							case 0:
								break;
							}
							break;
						}
					}
					finally
					{
						if (requestInterceptor != null)
						{
							int num4 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
							{
								num4 = 1;
							}
							while (true)
							{
								switch (num4)
								{
								case 1:
									((IDisposable)requestInterceptor).Dispose();
									num4 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
									{
										num4 = 0;
									}
									continue;
								case 0:
									break;
								}
								break;
							}
						}
					}
					goto case 3;
				case 6:
				{
					flag = parser.TryConsume<DicFactory>(out var _);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 != 0)
					{
						num2 = 0;
					}
					continue;
				}
				}
				break;
			}
		}
	}

	internal static bool CalcConfiguration()
	{
		return ListConfiguration == null;
	}

	internal static RefBase LogoutConfiguration()
	{
		return ListConfiguration;
	}
}
