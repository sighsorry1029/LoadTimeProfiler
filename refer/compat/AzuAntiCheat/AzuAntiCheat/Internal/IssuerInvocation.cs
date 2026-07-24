using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace AzuAnticheat.Internal;

internal sealed class IssuerInvocation : AnnotationSetter
{
	private sealed class RuleInvocation : Dictionary<VisitorAttribute, SerializerInvocation>, IdentifierInvocation
	{
		internal static RuleInvocation MoveOrder;

		public void OnDeserialization()
		{
			foreach (SerializerInvocation value in base.Values)
			{
				if (!value.HasValue)
				{
					StateSingleton composerInvocation = value._ComposerInvocation;
					throw new ProcessorAttribute(composerInvocation.Start, composerInvocation.End, string.Format(DicSingleton.gE3WbyDVW(-948533799 ^ -948509389), composerInvocation.Value));
				}
			}
		}

		public RuleInvocation()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool RevertOrder()
		{
			return MoveOrder == null;
		}

		internal static RuleInvocation InvokeProxy()
		{
			return MoveOrder;
		}
	}

	private sealed class SerializerInvocation : ProcessSetter
	{
		[CompilerGenerated]
		private Action<object?>? m_ProducerInvocation;

		[CompilerGenerated]
		private bool _ComparatorInvocation;

		private object? definitionInvocation;

		public readonly StateSingleton? _ComposerInvocation;

		private static SerializerInvocation? PublishProxy;

		public bool HasValue
		{
			[CompilerGenerated]
			get
			{
				return _ComparatorInvocation;
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
						_ComparatorInvocation = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 == 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			}
		}

		public object? Value
		{
			get
			{
				int num = 2;
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					default:
						throw new InvalidOperationException(DicSingleton.gE3WbyDVW(0x6E29C0C0 ^ 0x6E29A1DA));
					case 1:
						return definitionInvocation;
					case 2:
						if (HasValue)
						{
							num2 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
							{
								num2 = 1;
							}
							break;
						}
						goto default;
					}
				}
			}
			set
			{
				int num = 3;
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					default:
						throw new InvalidOperationException(DicSingleton.gE3WbyDVW(0x7FAAD78F ^ 0x7FAAB6B7));
					case 2:
						HasValue = true;
						num2 = 4;
						break;
					case 6:
						return;
					case 4:
						definitionInvocation = value;
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
						{
							num2 = 1;
						}
						break;
					case 3:
						if (!HasValue)
						{
							num2 = 2;
							break;
						}
						goto default;
					case 1:
					{
						Action<object?>? action = m_ProducerInvocation;
						if (action == null)
						{
							num2 = 5;
							break;
						}
						action(value);
						num2 = 6;
						break;
					}
					case 5:
						return;
					}
				}
			}
		}

		public event Action<object?>? ValueAvailable
		{
			[CompilerGenerated]
			add
			{
				Action<object> action = m_ProducerInvocation;
				Action<object> action2;
				do
				{
					action2 = action;
					Action<object> value2 = (Action<object>)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref m_ProducerInvocation, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action<object> action = m_ProducerInvocation;
				Action<object> action2;
				do
				{
					action2 = action;
					Action<object> value2 = (Action<object>)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref m_ProducerInvocation, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public SerializerInvocation(StateSingleton alias)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
			{
				num = 1;
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
					_ComposerInvocation = alias;
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 != 0)
					{
						num = 0;
					}
					break;
				}
			}
		}

		public SerializerInvocation(object? value)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
			{
				num = 0;
			}
			while (true)
			{
				switch (num)
				{
				case 2:
					definitionInvocation = value;
					num = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 != 0)
					{
						num = 0;
					}
					break;
				case 1:
					return;
				default:
					HasValue = true;
					num = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
					{
						num = 2;
					}
					break;
				}
			}
		}

		internal static bool RegisterProxy()
		{
			return PublishProxy == null;
		}

		internal static SerializerInvocation? SetupProxy()
		{
			return PublishProxy;
		}
	}

	private readonly AnnotationSetter fieldInvocation;

	internal static IssuerInvocation RestartOrder;

	public IssuerInvocation(AnnotationSetter innerDeserializer)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e != 0)
		{
			num = 1;
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
				fieldInvocation = innerDeserializer ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1614185587 ^ -1614210075));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public object? DeserializeValue(CandidateInterpreter parser, Type expectedType, MethodInvocation state, AnnotationSetter nestedObjectDeserializer)
	{
		int num = 8;
		VisitorAttribute visitorAttribute = default(VisitorAttribute);
		OrderSingleton event2 = default(OrderSingleton);
		StateSingleton @event = default(StateSingleton);
		RuleInvocation ruleInvocation = default(RuleInvocation);
		SerializerInvocation value2 = default(SerializerInvocation);
		TestsInterpreter start = default(TestsInterpreter);
		SerializerInvocation value = default(SerializerInvocation);
		VisitorAttribute anchor = default(VisitorAttribute);
		RuleInvocation ruleInvocation2 = default(RuleInvocation);
		object obj = default(object);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 21:
					visitorAttribute = event2.Anchor;
					num2 = 4;
					continue;
				case 8:
					if (parser.TryConsume<StateSingleton>(out @event))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
						{
							num2 = 7;
						}
						continue;
					}
					visitorAttribute = VisitorAttribute._StubAttribute;
					num2 = 15;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
					{
						num2 = 12;
					}
					continue;
				case 4:
					ruleInvocation = state.Get<RuleInvocation>();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 == 0)
					{
						num2 = 0;
					}
					continue;
				case 3:
					if (!value2.HasValue)
					{
						num2 = 22;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb == 0)
						{
							num2 = 15;
						}
						continue;
					}
					goto case 23;
				case 14:
					throw new ProcessorAttribute(in start, @event.End, string.Format(DicSingleton.gE3WbyDVW(0x21AFFB2B ^ 0x21AF9BA5), @event.Value));
				case 11:
					return value;
				case 26:
					if (anchor.IsEmpty)
					{
						num2 = 12;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 == 0)
						{
							num2 = 6;
						}
						continue;
					}
					goto case 21;
				case 15:
					if (!parser.Accept<OrderSingleton>(out event2))
					{
						num2 = 18;
						continue;
					}
					break;
				case 19:
					goto end_IL_0012;
				default:
					if (ruleInvocation.ContainsKey(visitorAttribute))
					{
						num2 = 25;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
						{
							num2 = 12;
						}
						continue;
					}
					goto case 6;
				case 23:
					ruleInvocation2[visitorAttribute] = new SerializerInvocation(obj);
					num2 = 24;
					continue;
				case 5:
					ruleInvocation2.Add(visitorAttribute, new SerializerInvocation(obj));
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
					{
						num2 = 1;
					}
					continue;
				case 16:
					if (!ruleInvocation2.TryGetValue(visitorAttribute, out value2))
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 != 0)
						{
							num2 = 4;
						}
						continue;
					}
					goto case 3;
				case 17:
					if (visitorAttribute.IsEmpty)
					{
						num2 = 20;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 != 0)
						{
							num2 = 4;
						}
						continue;
					}
					goto end_IL_0012;
				case 6:
					ruleInvocation[visitorAttribute] = new SerializerInvocation(new StateSingleton(visitorAttribute));
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
					{
						num2 = 13;
					}
					continue;
				case 12:
				case 13:
				case 18:
				case 25:
					obj = fieldInvocation.DeserializeValue(parser, expectedType, state, nestedObjectDeserializer);
					num2 = 17;
					continue;
				case 10:
					start = @event.Start;
					num2 = 13;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
					{
						num2 = 14;
					}
					continue;
				case 1:
				case 9:
				case 20:
				case 24:
					return obj;
				case 22:
					value2.Value = obj;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
					{
						num2 = 9;
					}
					continue;
				case 7:
					if (state.Get<RuleInvocation>().TryGetValue(@event.Value, out value))
					{
						if (value.HasValue)
						{
							return value.Value;
						}
						num2 = 11;
					}
					else
					{
						num2 = 10;
					}
					continue;
				case 2:
					break;
				}
				anchor = event2.Anchor;
				num2 = 26;
				continue;
				end_IL_0012:
				break;
			}
			ruleInvocation2 = state.Get<RuleInvocation>();
			num = 16;
		}
	}

	internal static bool GetOrder()
	{
		return RestartOrder == null;
	}

	internal static IssuerInvocation CalculateOrder()
	{
		return RestartOrder;
	}
}
