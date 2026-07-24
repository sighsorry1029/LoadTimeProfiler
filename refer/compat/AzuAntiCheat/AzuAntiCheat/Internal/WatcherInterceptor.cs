using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace AzuAnticheat.Internal;

internal sealed class WatcherInterceptor : ContainerPrototype
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1 })]
	private sealed class SystemInterceptor : Dictionary<HelperReader, ResolverInterceptor>, UtilsInterceptor
	{
		private static SystemInterceptor ResetMerchant;

		public void OnDeserialization()
		{
			int num = 1;
			int num2 = num;
			ValueCollection.Enumerator enumerator = default(ValueCollection.Enumerator);
			ResolverInterceptor current = default(ResolverInterceptor);
			TagFactory registryInterceptor = default(TagFactory);
			while (true)
			{
				switch (num2)
				{
				case 1:
					enumerator = base.Values.GetEnumerator();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
					{
						num2 = 0;
					}
					continue;
				case 2:
					return;
				}
				try
				{
					while (true)
					{
						IL_00c8:
						int num3;
						if (!enumerator.MoveNext())
						{
							num3 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
							{
								num3 = 0;
							}
							goto IL_003c;
						}
						goto IL_00ee;
						IL_00ee:
						current = enumerator.Current;
						int num4 = 4;
						num3 = num4;
						goto IL_003c;
						IL_003c:
						while (true)
						{
							switch (num3)
							{
							default:
								return;
							case 4:
								goto IL_005a;
							case 1:
								registryInterceptor = current._RegistryInterceptor;
								num3 = 3;
								continue;
							case 3:
								throw new MapperReader(registryInterceptor.Start, registryInterceptor.End, string.Format(DicSingleton.gE3WbyDVW(0xDA293E6 ^ 0xDA2F30C), registryInterceptor.Value));
							case 2:
								break;
							case 0:
								return;
							}
							break;
							IL_005a:
							if (!current.HasValue)
							{
								num3 = 1;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
								{
									num3 = 0;
								}
								continue;
							}
							goto IL_00c8;
						}
						goto IL_00ee;
					}
				}
				finally
				{
					((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
					int num5 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 != 0)
					{
						num5 = 0;
					}
					switch (num5)
					{
					case 0:
						break;
					}
				}
			}
		}

		public SystemInterceptor()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool CustomizeMerchant()
		{
			return ResetMerchant == null;
		}

		internal static SystemInterceptor CancelMerchant()
		{
			return ResetMerchant;
		}
	}

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	private sealed class ResolverInterceptor : IteratorPrototype
	{
		[CompilerGenerated]
		private Action<object> m_CandidateInterceptor;

		[CompilerGenerated]
		private bool expressionInterceptor;

		private object m_ProductInterceptor;

		public readonly TagFactory _RegistryInterceptor;

		internal static ResolverInterceptor ReflectMerchant;

		public bool HasValue
		{
			[CompilerGenerated]
			get
			{
				return expressionInterceptor;
			}
			[CompilerGenerated]
			private set
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
						expressionInterceptor = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 != 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			}
		}

		public object Value
		{
			get
			{
				int num = 1;
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					case 1:
						if (!HasValue)
						{
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
							{
								num2 = 0;
							}
							break;
						}
						return m_ProductInterceptor;
					default:
						throw new InvalidOperationException(DicSingleton.gE3WbyDVW(0x6729A6D ^ 0x672FB77));
					}
				}
			}
			set
			{
				int num = 5;
				while (true)
				{
					int num2 = num;
					while (true)
					{
						switch (num2)
						{
						default:
							return;
						case 5:
							if (!HasValue)
							{
								num2 = 4;
								continue;
							}
							goto case 1;
						case 2:
							m_ProductInterceptor = value;
							num2 = 2;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 != 0)
							{
								num2 = 3;
							}
							continue;
						case 1:
							throw new InvalidOperationException(DicSingleton.gE3WbyDVW(-447849421 ^ -447857397));
						case 4:
							break;
						case 6:
							return;
						case 3:
						{
							Action<object> action = m_CandidateInterceptor;
							if (action == null)
							{
								num2 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 == 0)
								{
									num2 = 0;
								}
							}
							else
							{
								action(value);
								num2 = 6;
							}
							continue;
						}
						case 0:
							return;
						}
						break;
					}
					HasValue = true;
					num = 2;
				}
			}
		}

		public event Action<object> ValueAvailable
		{
			[CompilerGenerated]
			add
			{
				Action<object> action = m_CandidateInterceptor;
				Action<object> action2;
				do
				{
					action2 = action;
					Action<object> value2 = (Action<object>)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref m_CandidateInterceptor, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action<object> action = m_CandidateInterceptor;
				Action<object> action2;
				do
				{
					action2 = action;
					Action<object> value2 = (Action<object>)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref m_CandidateInterceptor, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
		public ResolverInterceptor(TagFactory alias)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
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
				_RegistryInterceptor = alias;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
				{
					num = 1;
				}
			}
		}

		public ResolverInterceptor(object value)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 2;
			while (true)
			{
				switch (num)
				{
				default:
					return;
				case 0:
					return;
				case 1:
					m_ProductInterceptor = value;
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
					{
						num = 0;
					}
					break;
				case 2:
					HasValue = true;
					num = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 != 0)
					{
						num = 0;
					}
					break;
				}
			}
		}

		internal static bool CollectMerchant()
		{
			return ReflectMerchant == null;
		}

		internal static ResolverInterceptor ManageMerchant()
		{
			return ReflectMerchant;
		}
	}

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)]
	private readonly ContainerPrototype customerInterceptor;

	internal static WatcherInterceptor IncludeMerchant;

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public WatcherInterceptor(ContainerPrototype innerDeserializer)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
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
			customerInterceptor = innerDeserializer ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-2133864647 ^ -2133872815));
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
			{
				num = 0;
			}
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public object DeserializeValue(StubReader parser, Type expectedType, RequestInterceptor state, ContainerPrototype nestedObjectDeserializer)
	{
		int num = 21;
		SystemInterceptor systemInterceptor = default(SystemInterceptor);
		HelperReader helperReader = default(HelperReader);
		HelperReader anchor = default(HelperReader);
		SystemInterceptor systemInterceptor2 = default(SystemInterceptor);
		ResolverInterceptor value = default(ResolverInterceptor);
		object obj = default(object);
		TagFactory event2 = default(TagFactory);
		ListenerFactory @event = default(ListenerFactory);
		ResolverInterceptor value2 = default(ResolverInterceptor);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 3:
					systemInterceptor[helperReader] = new ResolverInterceptor(new TagFactory(helperReader));
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
					{
						num2 = 22;
					}
					continue;
				case 17:
					if (!anchor.IsEmpty)
					{
						num2 = 11;
						continue;
					}
					goto case 14;
				case 19:
					systemInterceptor2 = state.Get<SystemInterceptor>();
					num2 = 18;
					continue;
				default:
					return value;
				case 20:
					helperReader = HelperReader._ExceptionReader;
					num2 = 5;
					continue;
				case 25:
					if (systemInterceptor.ContainsKey(helperReader))
					{
						num2 = 14;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
						{
							num2 = 14;
						}
						continue;
					}
					goto case 3;
				case 6:
				case 7:
				case 23:
				case 26:
					return obj;
				case 2:
					if (state.Get<SystemInterceptor>().TryGetValue(event2.Value, out value))
					{
						num2 = 12;
						continue;
					}
					goto case 4;
				case 8:
					systemInterceptor2.Add(helperReader, new ResolverInterceptor(obj));
					num2 = 7;
					continue;
				case 14:
				case 15:
				case 22:
					obj = customerInterceptor.DeserializeValue(parser, expectedType, state, nestedObjectDeserializer);
					num2 = 13;
					continue;
				case 27:
					anchor = @event.Anchor;
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
					{
						num2 = 17;
					}
					continue;
				case 16:
					systemInterceptor = state.Get<SystemInterceptor>();
					num2 = 25;
					continue;
				case 5:
					if (!parser.Accept<ListenerFactory>(out @event))
					{
						num2 = 15;
						continue;
					}
					goto case 27;
				case 11:
					helperReader = @event.Anchor;
					num2 = 16;
					continue;
				case 9:
					break;
				case 18:
					if (systemInterceptor2.TryGetValue(helperReader, out value2))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 8;
				case 13:
					if (helperReader.IsEmpty)
					{
						num2 = 26;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 != 0)
						{
							num2 = 4;
						}
						continue;
					}
					goto case 19;
				case 21:
					if (!parser.TryConsume<TagFactory>(out event2))
					{
						num2 = 20;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
						{
							num2 = 11;
						}
						continue;
					}
					goto case 2;
				case 24:
					value2.Value = obj;
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
					{
						num2 = 3;
					}
					continue;
				case 1:
				case 10:
					if (!value2.HasValue)
					{
						num2 = 24;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					break;
				case 4:
					throw new MapperReader(event2.Start, event2.End, string.Format(DicSingleton.gE3WbyDVW(-614239580 ^ -614264278), event2.Value));
				case 12:
					if (value.HasValue)
					{
						return value.Value;
					}
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			}
			systemInterceptor2[helperReader] = new ResolverInterceptor(obj);
			num = 23;
		}
	}

	internal static bool CheckMerchant()
	{
		return IncludeMerchant == null;
	}

	internal static WatcherInterceptor RateMerchant()
	{
		return IncludeMerchant;
	}
}
