using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class StateInterceptor : ContainerPrototype
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public ContainerPrototype _BroadcasterInterceptor;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public RequestInterceptor workerInterceptor;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1, 2 })]
		public Func<StubReader, Type, object> taskInterceptor;

		internal static _003C_003Ec__DisplayClass3_0 CalculateMerchant;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
		internal object _003CDeserializeValue_003Eb__0(StubReader r, Type t)
		{
			return _BroadcasterInterceptor.DeserializeValue(r, t, workerInterceptor, _BroadcasterInterceptor);
		}

		internal static bool MoveMerchant()
		{
			return CalculateMerchant == null;
		}

		internal static _003C_003Ec__DisplayClass3_0 RevertMerchant()
		{
			return CalculateMerchant;
		}
	}

	private readonly IList<WorkerPrototype> m_ValueInterceptor;

	private readonly IList<TaskPrototype> decoratorInterceptor;

	private static StateInterceptor ForgotMerchant;

	public StateInterceptor(IList<WorkerPrototype> deserializers, IList<TaskPrototype> typeResolvers)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		m_ValueInterceptor = deserializers ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0xB026CF2 ^ 0xB020DAC));
		decoratorInterceptor = typeResolvers ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1580624393 ^ -1580600181));
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public object DeserializeValue(StubReader parser, Type expectedType, RequestInterceptor state, ContainerPrototype nestedObjectDeserializer)
	{
		int num = 5;
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = default(_003C_003Ec__DisplayClass3_0);
		Type typeFromEvent = default(Type);
		ListenerFactory @event = default(ListenerFactory);
		object result = default(object);
		object value = default(object);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				object obj;
				switch (num2)
				{
				case 3:
					_003C_003Ec__DisplayClass3_.workerInterceptor = state;
					num2 = 2;
					continue;
				case 5:
					_003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
					num2 = 4;
					continue;
				case 8:
					obj = null;
					goto IL_03db;
				case 6:
					typeFromEvent = GetTypeFromEvent(@event, expectedType);
					num2 = 9;
					continue;
				case 2:
					parser.Accept<ListenerFactory>(out @event);
					num = 6;
					break;
				case 4:
					_003C_003Ec__DisplayClass3_._BroadcasterInterceptor = nestedObjectDeserializer;
					num = 3;
					break;
				default:
					if (@event != null)
					{
						num = 7;
						break;
					}
					goto case 8;
				case 9:
					try
					{
						IEnumerator<WorkerPrototype> enumerator = m_ValueInterceptor.GetEnumerator();
						int num3 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f == 0)
						{
							num3 = 0;
						}
						switch (num3)
						{
						default:
							try
							{
								while (true)
								{
									int num4;
									if (!enumerator.MoveNext())
									{
										num4 = 1;
										if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db == 0)
										{
											num4 = 1;
										}
										goto IL_013f;
									}
									goto IL_01d9;
									IL_0170:
									result = ContainerInterceptor.ChangeType(value, expectedType);
									num4 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
									{
										num4 = 0;
									}
									goto IL_013f;
									IL_013f:
									switch (num4)
									{
									case 0:
										break;
									case 4:
										goto IL_0170;
									case 2:
									case 5:
										continue;
									case 3:
										goto IL_01d9;
									case 1:
										goto end_IL_0109;
									}
									break;
									IL_01d9:
									if (!enumerator.Current.Deserialize(parser, typeFromEvent, _003C_003Ec__DisplayClass3_._003CDeserializeValue_003Eb__0, out value))
									{
										int num5 = 2;
										num4 = num5;
										goto IL_013f;
									}
									goto IL_0170;
								}
							}
							finally
							{
								if (enumerator != null)
								{
									int num6 = 1;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 != 0)
									{
										num6 = 0;
									}
									while (true)
									{
										switch (num6)
										{
										case 1:
											enumerator.Dispose();
											num6 = 0;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
											{
												num6 = 0;
											}
											continue;
										case 0:
											break;
										}
										break;
									}
								}
							}
							return result;
						case 1:
							break;
							end_IL_0109:
							break;
						}
					}
					catch (TestsFactory)
					{
						int num7 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
						{
							num7 = 0;
						}
						switch (num7)
						{
						default:
							throw;
						}
					}
					catch (Exception innerException)
					{
						int num8 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a != 0)
						{
							num8 = 3;
						}
						object obj2;
						while (true)
						{
							switch (num8)
							{
							case 1:
								obj2 = null;
								goto IL_035c;
							case 3:
								if (@event != null)
								{
									num8 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 != 0)
									{
										num8 = 0;
									}
									continue;
								}
								goto case 1;
							default:
								obj2 = @event.Start;
								goto IL_035c;
							case 2:
								{
									obj2 = QueueReader.m_CollectionReader;
									break;
								}
								IL_035c:
								if (obj2 != null)
								{
									break;
								}
								num8 = 2;
								continue;
							}
							break;
						}
						throw new TestsFactory((QueueReader)obj2, @event?.End ?? QueueReader.m_CollectionReader, DicSingleton.gE3WbyDVW(-1273961441 ^ -1273985659), innerException);
					}
					goto default;
				case 7:
					obj = @event.Start;
					goto IL_03db;
				case 1:
					{
						obj = QueueReader.m_CollectionReader;
						goto IL_0401;
					}
					IL_0401:
					throw new TestsFactory((QueueReader)obj, @event?.End ?? QueueReader.m_CollectionReader, DicSingleton.gE3WbyDVW(0xB026CF2 ^ 0xB020D2C) + expectedType.AssemblyQualifiedName);
					IL_03db:
					if (obj == null)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto IL_0401;
				}
				break;
			}
		}
	}

	private Type GetTypeFromEvent([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] ListenerFactory nodeEvent, Type currentType)
	{
		using (IEnumerator<TaskPrototype> enumerator = decoratorInterceptor.GetEnumerator())
		{
			while (enumerator.MoveNext() && !enumerator.Current.Resolve(nodeEvent, ref currentType))
			{
			}
		}
		return currentType;
	}

	internal static bool RestartMerchant()
	{
		return ForgotMerchant == null;
	}

	internal static StateInterceptor GetMerchant()
	{
		return ForgotMerchant;
	}
}
