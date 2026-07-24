using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace AzuAnticheat.Internal;

[DebuggerDisplay("Count = {children.Count}")]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class ProcFilter : MappingFilter, IEnumerable<MappingFilter>, IEnumerable, RecordPrototype
{
	[CompilerGenerated]
	private sealed class _003CSafeAllNodes_003Ed__19 : IEnumerable<MappingFilter>, IEnumerable, IEnumerator<MappingFilter>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private MappingFilter _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		private SingletonFactory level;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public SingletonFactory _003C_003E3__level;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public ProcFilter _003C_003E4__this;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1 })]
		private IEnumerator<MappingFilter> _003C_003E7__wrap1;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1 })]
		private IEnumerator<MappingFilter> _003C_003E7__wrap2;

		private static _003CSafeAllNodes_003Ed__19 SetAuthentication;

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
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
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
					this._003C_003E1__state = _003C_003E1__state;
					num = 2;
					break;
				case 2:
					_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
					{
						num = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if ((uint)(num - -4) > 1u && num != 2)
			{
				return;
			}
			try
			{
				if (num != -4 && num != 2)
				{
					return;
				}
				try
				{
				}
				finally
				{
					_003C_003Em__Finally2();
				}
			}
			finally
			{
				_003C_003Em__Finally1();
			}
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				ProcFilter procFilter = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					level.Increment();
					_003C_003E2__current = procFilter;
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = procFilter.roleReader.GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_00f5;
				case 2:
					{
						_003C_003E1__state = -4;
						goto IL_00d8;
					}
					IL_00f5:
					if (_003C_003E7__wrap1.MoveNext())
					{
						MappingFilter current = _003C_003E7__wrap1.Current;
						_003C_003E7__wrap2 = current.SafeAllNodes(level).GetEnumerator();
						_003C_003E1__state = -4;
						goto IL_00d8;
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap1 = null;
					level.Decrement();
					return false;
					IL_00d8:
					if (_003C_003E7__wrap2.MoveNext())
					{
						MappingFilter current2 = _003C_003E7__wrap2.Current;
						_003C_003E2__current = current2;
						_003C_003E1__state = 2;
						return true;
					}
					_003C_003Em__Finally2();
					_003C_003E7__wrap2 = null;
					goto IL_00f5;
				}
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
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
					_003C_003E1__state = -1;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
					{
						num2 = 1;
					}
					break;
				case 1:
					if (_003C_003E7__wrap1 != null)
					{
						num2 = 3;
						break;
					}
					return;
				case 3:
					_003C_003E7__wrap1.Dispose();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 != 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		private void _003C_003Em__Finally2()
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					if (_003C_003E7__wrap2 == null)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					break;
				case 2:
					return;
				case 3:
					return;
				case 1:
					_003C_003E1__state = -3;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
					{
						num2 = 0;
					}
					continue;
				case 4:
					break;
				}
				_003C_003E7__wrap2.Dispose();
				num2 = 3;
			}
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
			_003CSafeAllNodes_003Ed__19 _003CSafeAllNodes_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CSafeAllNodes_003Ed__ = this;
			}
			else
			{
				_003CSafeAllNodes_003Ed__ = new _003CSafeAllNodes_003Ed__19(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003CSafeAllNodes_003Ed__.level = _003C_003E3__level;
			return _003CSafeAllNodes_003Ed__;
		}

		[DebuggerHidden]
		[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<MappingFilter>)this).GetEnumerator();
		}

		internal static bool PushAuthentication()
		{
			return SetAuthentication == null;
		}

		internal static _003CSafeAllNodes_003Ed__19 ValidateAuthentication()
		{
			return SetAuthentication;
		}
	}

	private readonly IList<MappingFilter> roleReader;

	[CompilerGenerated]
	private ProcFactory _PublisherReader;

	private static ProcFilter CalcAuthentication;

	public IList<MappingFilter> Children => roleReader;

	public ProcFactory Style
	{
		[CompilerGenerated]
		get
		{
			return _PublisherReader;
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
				case 1:
					_PublisherReader = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}
	}

	public override SpecificationFilter NodeType => (SpecificationFilter)3;

	internal ProcFilter(StubReader parser, PolicyFilter state)
	{
		GetterIssuer.DeleteInitializer();
		roleReader = new List<MappingFilter>();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec == 0)
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
				Load(parser, state);
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	private void Load(StubReader parser, PolicyFilter state)
	{
		int num = 7;
		RefFactory refFactory = default(RefFactory);
		bool flag = default(bool);
		MappingFilter mappingFilter = default(MappingFilter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 5:
					break;
				case 6:
					Load(refFactory, state);
					num2 = 2;
					continue;
				case 2:
					Style = refFactory.Style;
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
					{
						num2 = 1;
					}
					continue;
				case 12:
					flag = flag || mappingFilter is DispatcherFilter;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
					{
						num2 = 0;
					}
					continue;
				case 10:
					flag = false;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 == 0)
					{
						num2 = 1;
					}
					continue;
				default:
				{
					if (!parser.TryConsume<SpecificationFactory>(out var _))
					{
						num2 = 8;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 3;
				}
				case 3:
					if (flag)
					{
						num2 = 5;
						continue;
					}
					return;
				case 9:
					return;
				case 7:
					refFactory = parser.Consume<RefFactory>();
					num2 = 6;
					continue;
				case 4:
				case 8:
					mappingFilter = MappingFilter.ParseNode(parser, state);
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 != 0)
					{
						num2 = 11;
					}
					continue;
				case 11:
					roleReader.Add(mappingFilter);
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
					{
						num2 = 7;
					}
					continue;
				}
				break;
			}
			state.AddNodeWithUnresolvedAliases(this);
			num = 9;
		}
	}

	public ProcFilter()
	{
		GetterIssuer.DeleteInitializer();
		roleReader = new List<MappingFilter>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ProcFilter(params MappingFilter[] children)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector((IEnumerable<MappingFilter>)children);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ProcFilter(IEnumerable<MappingFilter> children)
	{
		GetterIssuer.DeleteInitializer();
		roleReader = new List<MappingFilter>();
		base._002Ector();
		foreach (MappingFilter child in children)
		{
			roleReader.Add(child);
		}
	}

	public void Add(MappingFilter child)
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
				roleReader.Add(child);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public void Add(string child)
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
				roleReader.Add(new RefFilter(child));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal override void ResolveAliases(PolicyFilter state)
	{
		int num = 2;
		int num2 = num;
		int num3 = default(int);
		while (true)
		{
			switch (num2)
			{
			case 1:
			case 5:
				if (num3 >= roleReader.Count)
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
					{
						num2 = 3;
					}
					break;
				}
				goto case 6;
			case 4:
				num3++;
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec != 0)
				{
					num2 = 5;
				}
				break;
			case 6:
				if (roleReader[num3] is DispatcherFilter)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 4;
			default:
				roleReader[num3] = state.GetNode(roleReader[num3].Anchor, roleReader[num3].Start, roleReader[num3].End);
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
				{
					num2 = 4;
				}
				break;
			case 3:
				return;
			case 2:
				num3 = 0;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal override void Emit(ModelReader emitter, InfoFilter state)
	{
		emitter.Emit(new RefFactory(base.Anchor, base.Tag, base.Tag.IsEmpty, Style));
		foreach (MappingFilter item in roleReader)
		{
			item.Save(emitter, state);
		}
		emitter.Emit(new SpecificationFactory());
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
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
		int num = 10;
		int num3 = default(int);
		ProcFilter procFilter = default(ProcFilter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 8:
					if (object.Equals(roleReader[num3], procFilter.roleReader[num3]))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 3;
				default:
					return true;
				case 2:
					if (roleReader.Count == procFilter.roleReader.Count)
					{
						num3 = 0;
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
						{
							num2 = 4;
						}
						continue;
					}
					goto IL_01c3;
				case 3:
					return false;
				case 1:
					num3++;
					num = 7;
					break;
				case 10:
					procFilter = obj as ProcFilter;
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
					{
						num2 = 9;
					}
					continue;
				case 9:
					if (procFilter != null)
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto IL_01c3;
				case 4:
					return false;
				case 6:
				case 7:
					if (num3 >= roleReader.Count)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 8;
				case 5:
					{
						if (object.Equals(base.Tag, procFilter.Tag))
						{
							num = 2;
							break;
						}
						goto IL_01c3;
					}
					IL_01c3:
					num2 = 4;
					continue;
				}
				break;
			}
		}
	}

	public override int GetHashCode()
	{
		int h = 0;
		foreach (MappingFilter item in roleReader)
		{
			h = ProxyReader.CombineHashCodes(h, item);
		}
		return ProxyReader.CombineHashCodes(h, base.Tag);
	}

	[IteratorStateMachine(typeof(_003CSafeAllNodes_003Ed__19))]
	internal override IEnumerable<MappingFilter> SafeAllNodes(SingletonFactory level)
	{
		//yield-return decompiler failed: Missing enumeratorCtor.Body
		return new _003CSafeAllNodes_003Ed__19(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__level = level
		};
	}

	internal override string ToString(SingletonFactory level)
	{
		int num = 3;
		int num2 = num;
		StringBuilder stringBuilder = default(StringBuilder);
		IEnumerator<MappingFilter> enumerator = default(IEnumerator<MappingFilter>);
		MappingFilter current = default(MappingFilter);
		while (true)
		{
			switch (num2)
			{
			case 4:
				level.Decrement();
				num2 = 5;
				break;
			case 1:
				stringBuilder.Append(DicSingleton.gE3WbyDVW(0xFB046CE ^ 0xFB03012));
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
				{
					num2 = 4;
				}
				break;
			default:
				enumerator = roleReader.GetEnumerator();
				num2 = 6;
				break;
			case 5:
				return stringBuilder.ToString();
			case 6:
				try
				{
					while (true)
					{
						IL_014f:
						int num3;
						if (!enumerator.MoveNext())
						{
							num3 = 5;
							goto IL_00bd;
						}
						goto IL_00df;
						IL_00bd:
						while (true)
						{
							int num4;
							switch (num3)
							{
							case 2:
								break;
							case 3:
								stringBuilder.Append(DicSingleton.gE3WbyDVW(-823738529 ^ -823731661));
								num3 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
								{
									num3 = 0;
								}
								continue;
							case 1:
								if (stringBuilder.Length > 2)
								{
									num4 = 3;
									goto IL_00b9;
								}
								goto default;
							case 4:
								goto IL_014f;
							default:
								stringBuilder.Append(current.ToString(level));
								num4 = 4;
								goto IL_00b9;
							case 5:
								goto end_IL_014f;
								IL_00b9:
								num3 = num4;
								continue;
							}
							break;
						}
						goto IL_00df;
						IL_00df:
						current = enumerator.Current;
						num3 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
						{
							num3 = 1;
						}
						goto IL_00bd;
						continue;
						end_IL_014f:
						break;
					}
				}
				finally
				{
					int num5;
					if (enumerator == null)
					{
						num5 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
						{
							num5 = 1;
						}
						goto IL_01ad;
					}
					goto IL_01e2;
					IL_01ad:
					switch (num5)
					{
					case 1:
						goto end_IL_0188;
					case 2:
						goto end_IL_0188;
					}
					goto IL_01e2;
					IL_01e2:
					enumerator.Dispose();
					num5 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
					{
						num5 = 2;
					}
					goto IL_01ad;
					end_IL_0188:;
				}
				goto case 1;
			case 2:
				return DicSingleton.gE3WbyDVW(-849667636 ^ -849646984);
			case 3:
				if (level.TryIncrement())
				{
					stringBuilder = new StringBuilder(DicSingleton.gE3WbyDVW(0x5A1F7167 ^ 0x5A1F07B3));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
					{
						num2 = 0;
					}
				}
				else
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	public IEnumerator<MappingFilter> GetEnumerator()
	{
		return Children.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa != 0)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool LogoutAuthentication()
	{
		return CalcAuthentication == null;
	}

	internal static ProcFilter CountAuthentication()
	{
		return CalcAuthentication;
	}
}
