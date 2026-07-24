using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[DebuggerDisplay("{Value}")]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class RefFilter : MappingFilter, RecordPrototype
{
	[CompilerGenerated]
	private sealed class _003CSafeAllNodes_003Ed__19 : IEnumerable<MappingFilter>, IEnumerable, IEnumerator<MappingFilter>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private MappingFilter _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public RefFilter _003C_003E4__this;

		internal static _003CSafeAllNodes_003Ed__19 InitAuthentication;

		MappingFilter IEnumerator<MappingFilter>.Current
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
			[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CSafeAllNodes_003Ed__19(int _003C_003E1__state)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a != 0)
			{
				num = 1;
			}
			while (true)
			{
				switch (num)
				{
				default:
					_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
					num = 2;
					break;
				case 1:
					this._003C_003E1__state = _003C_003E1__state;
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 != 0)
					{
						num = 0;
					}
					break;
				case 2:
					return;
				}
			}
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = 6;
			RefFilter refFilter = default(RefFilter);
			int num3 = default(int);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					case 3:
						return true;
					case 4:
						_003C_003E2__current = refFilter;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 != 0)
						{
							num2 = 0;
						}
						break;
					case 2:
						return false;
					default:
						_003C_003E1__state = 1;
						num2 = 3;
						break;
					case 5:
						refFilter = _003C_003E4__this;
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 == 0)
						{
							num2 = 1;
						}
						break;
					case 8:
						if (num3 == 1)
						{
							_003C_003E1__state = -1;
							num2 = 3;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 == 0)
							{
								num2 = 7;
							}
						}
						else
						{
							num2 = 2;
						}
						break;
					case 1:
						if (num3 == 0)
						{
							_003C_003E1__state = -1;
							num2 = 4;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
							{
								num2 = 0;
							}
							break;
						}
						goto end_IL_0012;
					case 6:
						num3 = _003C_003E1__state;
						num2 = 5;
						break;
					case 7:
						return false;
					}
					continue;
					end_IL_0012:
					break;
				}
				num = 8;
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
		[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		IEnumerator<MappingFilter> IEnumerable<MappingFilter>.GetEnumerator()
		{
			_003CSafeAllNodes_003Ed__19 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003CSafeAllNodes_003Ed__19(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<MappingFilter>)this).GetEnumerator();
		}

		internal static bool PatchAuthentication()
		{
			return InitAuthentication == null;
		}

		internal static _003CSafeAllNodes_003Ed__19 AssetAuthentication()
		{
			return InitAuthentication;
		}
	}

	[CompilerGenerated]
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	private string observerFilter;

	[CompilerGenerated]
	private RuleFactory m_AdapterFilter;

	private static RefFilter CloneAuthentication;

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public string Value
	{
		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
		[CompilerGenerated]
		get
		{
			return observerFilter;
		}
		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
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
					observerFilter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public RuleFactory Style
	{
		[CompilerGenerated]
		get
		{
			return m_AdapterFilter;
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
					m_AdapterFilter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public override SpecificationFilter NodeType => (SpecificationFilter)2;

	internal RefFilter(StubReader parser, PolicyFilter state)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 != 0)
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
				Load(parser, state);
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	private void Load(StubReader parser, PolicyFilter state)
	{
		int num = 4;
		int num2 = num;
		ClassFactory classFactory = default(ClassFactory);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 4:
				classFactory = parser.Consume<ClassFactory>();
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 != 0)
				{
					num2 = 3;
				}
				break;
			case 0:
				return;
			case 3:
				Load(classFactory, state);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e != 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				Style = classFactory.Style;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				Value = classFactory.Value;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	public RefFilter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	public RefFilter(string value)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 != 0)
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
			Value = value;
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
			{
				num = 1;
			}
		}
	}

	internal override void ResolveAliases(PolicyFilter state)
	{
		throw new NotSupportedException(DicSingleton.gE3WbyDVW(-1891833728 ^ -1891852574));
	}

	internal override void Emit(ModelReader emitter, InfoFilter state)
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
				emitter.Emit(new ClassFactory(base.Anchor, base.Tag, Value ?? string.Empty, Style, base.Tag.IsEmpty, isQuotedImplicit: false));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public override void Accept(ParamsFilter visitor)
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
				visitor.Visit(this);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	public override bool Equals(object obj)
	{
		int num = 1;
		int num2 = num;
		RefFilter refFilter = default(RefFilter);
		while (true)
		{
			switch (num2)
			{
			case 1:
				refFilter = obj as RefFilter;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 != 0)
				{
					num2 = 0;
				}
				continue;
			default:
				if (refFilter != null)
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
					{
						num2 = 2;
					}
					continue;
				}
				break;
			case 2:
				if (!object.Equals(base.Tag, refFilter.Tag))
				{
					num2 = 4;
					continue;
				}
				goto case 3;
			case 3:
				return object.Equals(Value, refFilter.Value);
			case 4:
				break;
			}
			break;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ProxyReader.CombineHashCodes(base.Tag, Value);
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public static explicit operator string(RefFilter value)
	{
		return value.Value;
	}

	internal override string ToString(SingletonFactory level)
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
				if (text == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 == 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			default:
				text = string.Empty;
				break;
			}
			break;
		}
		return text;
	}

	[IteratorStateMachine(typeof(_003CSafeAllNodes_003Ed__19))]
	internal override IEnumerable<MappingFilter> SafeAllNodes(SingletonFactory level)
	{
		//yield-return decompiler failed: Missing enumeratorCtor.Body
		return new _003CSafeAllNodes_003Ed__19(-2)
		{
			_003C_003E4__this = this
		};
	}

	void RecordPrototype.Read(StubReader parser, Type expectedType, ServicePrototype nestedObjectDeserializer)
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
				Load(parser, new PolicyFilter());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void RecordPrototype.Write(ModelReader emitter, BridgePrototype nestedObjectSerializer)
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
				Emit(emitter, new InfoFilter());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool ReadAuthentication()
	{
		return CloneAuthentication == null;
	}

	internal static RefFilter ViewAuthentication()
	{
		return CloneAuthentication;
	}
}
