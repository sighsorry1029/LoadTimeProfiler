using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[DebuggerDisplay("{Value}")]
internal sealed class UtilsAttribute : ProductAttribute, TagSetter
{
	[CompilerGenerated]
	private sealed class _003CSafeAllNodes_003Ed__20 : IEnumerable<ProductAttribute>, IEnumerable, IEnumerator<ProductAttribute>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private ProductAttribute _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public UtilsAttribute _003C_003E4__this;

		private static _003CSafeAllNodes_003Ed__20 StartToken;

		ProductAttribute IEnumerator<ProductAttribute>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CSafeAllNodes_003Ed__20(int _003C_003E1__state)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
			{
				num = 1;
			}
			while (true)
			{
				switch (num)
				{
				case 1:
					this._003C_003E1__state = _003C_003E1__state;
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
					{
						num = 0;
					}
					break;
				case 2:
					return;
				default:
					_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
					num = 2;
					break;
				}
			}
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = 1;
			int num2 = num;
			int num3 = default(int);
			UtilsAttribute utilsAttribute = default(UtilsAttribute);
			while (true)
			{
				switch (num2)
				{
				case 7:
					if (num3 != 1)
					{
						num2 = 6;
						break;
					}
					_003C_003E1__state = -1;
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
					{
						num2 = 7;
					}
					break;
				case 8:
					return false;
				case 3:
					_003C_003E1__state = 1;
					num2 = 5;
					break;
				case 6:
					return false;
				case 4:
					if (num3 == 0)
					{
						_003C_003E1__state = -1;
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
						{
							num2 = 1;
						}
					}
					else
					{
						num2 = 7;
					}
					break;
				case 5:
					return true;
				case 2:
					_003C_003E2__current = utilsAttribute;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb != 0)
					{
						num2 = 3;
					}
					break;
				default:
					utilsAttribute = _003C_003E4__this;
					num2 = 4;
					break;
				case 1:
					num3 = _003C_003E1__state;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<ProductAttribute> IEnumerable<ProductAttribute>.GetEnumerator()
		{
			_003CSafeAllNodes_003Ed__20 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003CSafeAllNodes_003Ed__20(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ProductAttribute>)this).GetEnumerator();
		}

		internal static bool RemoveToken()
		{
			return StartToken == null;
		}

		internal static _003CSafeAllNodes_003Ed__20 ResolveToken()
		{
			return StartToken;
		}
	}

	private bool m_TestsAttribute;

	private string? initializerAttribute;

	[CompilerGenerated]
	private ConnectionInterpreter _PageAttribute;

	private static UtilsAttribute InstantiateToken;

	public string? Value
	{
		get
		{
			return initializerAttribute;
		}
		set
		{
			int num = 2;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 2:
					if (value == null)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 4;
				case 4:
					m_TestsAttribute = false;
					num2 = 5;
					break;
				case 0:
					return;
				case 3:
				case 5:
					initializerAttribute = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
					{
						num2 = 0;
					}
					break;
				case 1:
					m_TestsAttribute = true;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 != 0)
					{
						num2 = 2;
					}
					break;
				}
			}
		}
	}

	public ConnectionInterpreter Style
	{
		[CompilerGenerated]
		get
		{
			return _PageAttribute;
		}
		[CompilerGenerated]
		set
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
					_PageAttribute = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public override ActivityTemplateFactoryBuilderWriterStates NodeType => (ActivityTemplateFactoryBuilderWriterStates)2;

	internal UtilsAttribute(CandidateInterpreter parser, IdentifierAttribute state)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
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
			Load(parser, state);
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
			{
				num = 0;
			}
		}
	}

	private void Load(CandidateInterpreter parser, IdentifierAttribute state)
	{
		int num = 4;
		BridgeSingleton bridgeSingleton = default(BridgeSingleton);
		RoleSingleton tag = default(RoleSingleton);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 16:
					return;
				case 7:
					if (!bridgeSingleton.Value.Equals(DicSingleton.gE3WbyDVW(0x1C9EFC64 ^ 0x1C9E97C4), StringComparison.InvariantCulture))
					{
						num2 = 14;
						continue;
					}
					goto case 8;
				case 14:
					if (bridgeSingleton.Value.Equals(DicSingleton.gE3WbyDVW(-2083714112 ^ -2083692436), StringComparison.InvariantCulture))
					{
						num2 = 10;
						continue;
					}
					goto case 2;
				case 3:
					Load(bridgeSingleton, state);
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
					{
						num2 = 6;
					}
					continue;
				default:
					initializerAttribute = bridgeSingleton.Value;
					num2 = 13;
					continue;
				case 15:
					if (bridgeSingleton.Value == string.Empty)
					{
						num2 = 9;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
						{
							num2 = 5;
						}
						continue;
					}
					goto case 1;
				case 2:
					if (bridgeSingleton.Value == DicSingleton.gE3WbyDVW(-1773869960 ^ -1773891614))
					{
						num2 = 8;
						continue;
					}
					goto default;
				case 4:
					bridgeSingleton = parser.Consume<BridgeSingleton>();
					num2 = 3;
					continue;
				case 8:
				case 9:
				case 10:
					m_TestsAttribute = true;
					num2 = 6;
					continue;
				case 5:
					if (!tag.IsEmpty)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 15;
				case 13:
					break;
				case 12:
					if (bridgeSingleton.Style == (ConnectionInterpreter)1)
					{
						num2 = 11;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto default;
				case 11:
					tag = base.Tag;
					num2 = 5;
					continue;
				case 1:
					if (!bridgeSingleton.Value.Equals(DicSingleton.gE3WbyDVW(-545065612 ^ -545080304), StringComparison.InvariantCulture))
					{
						num2 = 7;
						continue;
					}
					goto case 8;
				}
				break;
			}
			Style = bridgeSingleton.Style;
			num = 16;
		}
	}

	public UtilsAttribute()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public UtilsAttribute(string? value)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 1:
				Value = value;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal override void ResolveAliases(IdentifierAttribute state)
	{
		throw new NotSupportedException(DicSingleton.gE3WbyDVW(-992201216 ^ -992198558));
	}

	internal override void Emit(MockInterpreter emitter, RulesAttribute state)
	{
		int num = 10;
		bool isPlainImplicit = default(bool);
		RoleSingleton tag = default(RoleSingleton);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 11:
					if (Style == (ConnectionInterpreter)0)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 2;
				case 18:
					isPlainImplicit = true;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 != 0)
					{
						num2 = 6;
					}
					continue;
				case 9:
					isPlainImplicit = tag.IsEmpty;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 != 0)
					{
						num2 = 0;
					}
					continue;
				case 7:
				case 14:
					if (tag.IsEmpty)
					{
						num2 = 17;
						continue;
					}
					goto case 2;
				case 1:
					tag = TagInvocation.VisitorInvocation.m_StubInvocation;
					num2 = 18;
					continue;
				case 3:
				case 5:
					tag = TagInvocation.VisitorInvocation.m_StubInvocation;
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 != 0)
					{
						num2 = 0;
					}
					continue;
				case 10:
					tag = base.Tag;
					num = 9;
					break;
				case 8:
					isPlainImplicit = true;
					num2 = 12;
					continue;
				case 15:
					if (Value == null)
					{
						num2 = 5;
						continue;
					}
					goto case 13;
				default:
					if (m_TestsAttribute)
					{
						num2 = 16;
						continue;
					}
					goto case 7;
				case 13:
					if (!(Value == ""))
					{
						num2 = 14;
						continue;
					}
					goto case 3;
				case 17:
					if (Value != null)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 19;
				case 16:
					if (Style == (ConnectionInterpreter)1)
					{
						num2 = 15;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
						{
							num2 = 4;
						}
						continue;
					}
					goto case 7;
				case 4:
					return;
				case 19:
					if (Style != (ConnectionInterpreter)1)
					{
						num = 11;
						break;
					}
					goto case 1;
				case 2:
				case 6:
				case 12:
					emitter.Emit(new BridgeSingleton(base.Anchor, tag, Value ?? string.Empty, Style, isPlainImplicit, isQuotedImplicit: false));
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
					{
						num2 = 4;
					}
					continue;
				}
				break;
			}
		}
	}

	public override void Accept(CodeAttribute visitor)
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
				visitor.Visit(this);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public override bool Equals(object? obj)
	{
		int num = 1;
		int num2 = num;
		UtilsAttribute utilsAttribute = default(UtilsAttribute);
		while (true)
		{
			switch (num2)
			{
			default:
				if (utilsAttribute != null)
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 != 0)
					{
						num2 = 2;
					}
					continue;
				}
				break;
			case 1:
				utilsAttribute = obj as UtilsAttribute;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
				{
					num2 = 0;
				}
				continue;
			case 2:
				if (object.Equals(base.Tag, utilsAttribute.Tag))
				{
					num2 = 3;
					continue;
				}
				break;
			case 3:
				return object.Equals(Value, utilsAttribute.Value);
			}
			break;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = 1;
		int num2 = num;
		RoleSingleton tag = default(RoleSingleton);
		while (true)
		{
			switch (num2)
			{
			default:
				return IndexerInterpreter.CombineHashCodes(tag.GetHashCode(), Value);
			case 1:
				tag = base.Tag;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public static explicit operator string?(UtilsAttribute value)
	{
		return value.Value;
	}

	internal override string ToString(ProxyInterpreter level)
	{
		int num = 1;
		int num2 = num;
		string text;
		while (true)
		{
			switch (num2)
			{
			case 1:
				text = Value;
				if (text != null)
				{
					break;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 == 0)
				{
					num2 = 0;
				}
				continue;
			default:
				text = string.Empty;
				break;
			}
			break;
		}
		return text;
	}

	[IteratorStateMachine(typeof(_003CSafeAllNodes_003Ed__20))]
	internal override IEnumerable<ProductAttribute> SafeAllNodes(ProxyInterpreter level)
	{
		//yield-return decompiler failed: Missing enumeratorCtor.Body
		return new _003CSafeAllNodes_003Ed__20(-2)
		{
			_003C_003E4__this = this
		};
	}

	void TagSetter.Read(CandidateInterpreter parser, Type expectedType, VisitorSetter nestedObjectDeserializer)
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
				Load(parser, new IdentifierAttribute());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	void TagSetter.Write(MockInterpreter emitter, StubSetter nestedObjectSerializer)
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
				Emit(emitter, new RulesAttribute());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool LoginToken()
	{
		return InstantiateToken == null;
	}

	internal static UtilsAttribute ConnectToken()
	{
		return InstantiateToken;
	}
}
