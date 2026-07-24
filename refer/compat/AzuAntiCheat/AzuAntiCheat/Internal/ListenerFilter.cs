using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class ListenerFilter : MappingFilter, IEnumerable<KeyValuePair<MappingFilter, MappingFilter>>, IEnumerable, RecordPrototype
{
	[CompilerGenerated]
	private sealed class _003CSafeAllNodes_003Ed__23 : IEnumerable<MappingFilter>, IEnumerable, IEnumerator<MappingFilter>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private MappingFilter _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		private SingletonFactory level;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public SingletonFactory _003C_003E3__level;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public ListenerFilter _003C_003E4__this;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 0, 1, 1 })]
		private IEnumerator<KeyValuePair<MappingFilter, MappingFilter>> _003C_003E7__wrap1;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1 })]
		private KeyValuePair<MappingFilter, MappingFilter> _003Cchild_003E5__3;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1 })]
		private IEnumerator<MappingFilter> _003C_003E7__wrap3;

		internal static _003CSafeAllNodes_003Ed__23 SelectAuthentication;

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
		public _003CSafeAllNodes_003Ed__23(int _003C_003E1__state)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
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
					this._003C_003E1__state = _003C_003E1__state;
					num = 2;
					break;
				case 2:
					_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
					{
						num = 0;
					}
					break;
				}
			}
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = 1;
			int num2 = num;
			int num3 = default(int);
			while (true)
			{
				switch (num2)
				{
				case 2:
					return;
				case 5:
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 != 0)
					{
						num2 = 3;
					}
					break;
				default:
					if ((uint)(num3 - -5) > 2u)
					{
						num2 = 4;
						break;
					}
					goto case 5;
				case 1:
					num3 = _003C_003E1__state;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 != 0)
					{
						num2 = 0;
					}
					break;
				case 3:
					try
					{
						int num4;
						if (num3 > -4)
						{
							num4 = 9;
							goto IL_009f;
						}
						goto IL_018d;
						IL_018d:
						if (num3 != -5)
						{
							num4 = 8;
							goto IL_009f;
						}
						goto IL_0125;
						IL_009f:
						while (true)
						{
							switch (num4)
							{
							case 3:
								return;
							case 4:
								return;
							case 7:
								num4 = 1;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
								{
									num4 = 1;
								}
								continue;
							default:
								if (num3 != 2)
								{
									num4 = 5;
									continue;
								}
								goto case 7;
							case 8:
								if (num3 != -4)
								{
									num4 = 3;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
									{
										num4 = 1;
									}
									continue;
								}
								goto case 7;
							case 10:
								break;
							case 6:
								goto IL_018d;
							case 1:
								try
								{
									return;
								}
								finally
								{
									_003C_003Em__Finally2();
									int num6 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb != 0)
									{
										num6 = 0;
									}
									switch (num6)
									{
									case 0:
										break;
									}
								}
							case 5:
								if (num3 != 3)
								{
									num4 = 4;
									continue;
								}
								break;
							case 2:
								try
								{
									return;
								}
								finally
								{
									_003C_003Em__Finally3();
									int num5 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 != 0)
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
							break;
						}
						goto IL_0125;
						IL_0125:
						num4 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
						{
							num4 = 0;
						}
						goto IL_009f;
					}
					finally
					{
						_003C_003Em__Finally1();
						int num7 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
						{
							num7 = 0;
						}
						switch (num7)
						{
						case 0:
							break;
						}
					}
				case 4:
					if ((uint)(num3 - 2) > 1u)
					{
						return;
					}
					num2 = 5;
					break;
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				ListenerFilter listenerFilter = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					level.Increment();
					_003C_003E2__current = listenerFilter;
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = listenerFilter.accountFilter.GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_0189;
				case 2:
					_003C_003E1__state = -4;
					goto IL_00e9;
				case 3:
					{
						_003C_003E1__state = -5;
						goto IL_0160;
					}
					IL_0189:
					if (_003C_003E7__wrap1.MoveNext())
					{
						_003Cchild_003E5__3 = _003C_003E7__wrap1.Current;
						_003C_003E7__wrap3 = _003Cchild_003E5__3.Key.SafeAllNodes(level).GetEnumerator();
						_003C_003E1__state = -4;
						goto IL_00e9;
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap1 = null;
					level.Decrement();
					return false;
					IL_0160:
					if (_003C_003E7__wrap3.MoveNext())
					{
						MappingFilter current = _003C_003E7__wrap3.Current;
						_003C_003E2__current = current;
						_003C_003E1__state = 3;
						return true;
					}
					_003C_003Em__Finally3();
					_003C_003E7__wrap3 = null;
					_003Cchild_003E5__3 = default(KeyValuePair<MappingFilter, MappingFilter>);
					goto IL_0189;
					IL_00e9:
					if (_003C_003E7__wrap3.MoveNext())
					{
						MappingFilter current2 = _003C_003E7__wrap3.Current;
						_003C_003E2__current = current2;
						_003C_003E1__state = 2;
						return true;
					}
					_003C_003Em__Finally2();
					_003C_003E7__wrap3 = null;
					_003C_003E7__wrap3 = _003Cchild_003E5__3.Value.SafeAllNodes(level).GetEnumerator();
					_003C_003E1__state = -5;
					goto IL_0160;
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
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 4:
					return;
				case 2:
					_003C_003E7__wrap1.Dispose();
					num2 = 3;
					break;
				case 1:
					_003C_003E1__state = -1;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 != 0)
					{
						num2 = 0;
					}
					break;
				case 3:
					return;
				default:
					if (_003C_003E7__wrap1 == null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
						{
							num2 = 4;
						}
						break;
					}
					goto case 2;
				}
			}
		}

		private void _003C_003Em__Finally2()
		{
			int num = 2;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 2:
					_003C_003E1__state = -3;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
					{
						num2 = 1;
					}
					break;
				case 3:
					return;
				case 1:
					if (_003C_003E7__wrap3 == null)
					{
						return;
					}
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 != 0)
					{
						num2 = 0;
					}
					break;
				default:
					_003C_003E7__wrap3.Dispose();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
					{
						num2 = 3;
					}
					break;
				}
			}
		}

		private void _003C_003Em__Finally3()
		{
			int num = 3;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 3:
					_003C_003E1__state = -3;
					num2 = 2;
					break;
				case 4:
					_003C_003E7__wrap3.Dispose();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
					{
						num2 = 1;
					}
					break;
				case 0:
					return;
				case 1:
					return;
				case 2:
					if (_003C_003E7__wrap3 == null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 4;
				}
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
			_003CSafeAllNodes_003Ed__23 _003CSafeAllNodes_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CSafeAllNodes_003Ed__ = this;
			}
			else
			{
				_003CSafeAllNodes_003Ed__ = new _003CSafeAllNodes_003Ed__23(0)
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

		internal static bool ChangeAuthentication()
		{
			return SelectAuthentication == null;
		}

		internal static _003CSafeAllNodes_003Ed__23 CreateAuthentication()
		{
			return SelectAuthentication;
		}
	}

	private readonly InterpreterReader<MappingFilter, MappingFilter> accountFilter;

	[CompilerGenerated]
	private TokenizerFactory m_ThreadFilter;

	internal static ListenerFilter PublishAuthentication;

	public InterpreterReader<MappingFilter, MappingFilter> Children => accountFilter;

	public TokenizerFactory Style
	{
		[CompilerGenerated]
		get
		{
			return m_ThreadFilter;
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
					m_ThreadFilter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public override SpecificationFilter NodeType => (SpecificationFilter)1;

	internal ListenerFilter(StubReader parser, PolicyFilter state)
	{
		GetterIssuer.DeleteInitializer();
		accountFilter = new IssuerReader<MappingFilter, MappingFilter>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
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
			num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
			{
				num = 1;
			}
		}
	}

	private void Load(StubReader parser, PolicyFilter state)
	{
		int num = 3;
		QueueFactory queueFactory = default(QueueFactory);
		MappingFilter mappingFilter = default(MappingFilter);
		MappingFilter mappingFilter2 = default(MappingFilter);
		bool flag = default(bool);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 5:
					Style = queueFactory.Style;
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
					{
						num2 = 1;
					}
					continue;
				case 12:
					mappingFilter = MappingFilter.ParseNode(parser, state);
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
					{
						num2 = 5;
					}
					continue;
				case 10:
					state.AddNodeWithUnresolvedAliases(this);
					num2 = 4;
					continue;
				case 2:
					Load(queueFactory, state);
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 != 0)
					{
						num2 = 5;
					}
					continue;
				case 7:
				case 9:
					mappingFilter2 = MappingFilter.ParseNode(parser, state);
					num2 = 12;
					continue;
				case 4:
					return;
				case 13:
					if (!flag)
					{
						return;
					}
					goto end_IL_0012;
				case 11:
					flag = false;
					num2 = 8;
					continue;
				case 3:
					queueFactory = parser.Consume<QueueFactory>();
					num2 = 2;
					continue;
				case 6:
					try
					{
						accountFilter.Add(mappingFilter2, mappingFilter);
						int num3 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
						{
							num3 = 0;
						}
						switch (num3)
						{
						case 0:
							break;
						}
					}
					catch (ArgumentException innerException)
					{
						int num4 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
						{
							num4 = 0;
						}
						switch (num4)
						{
						default:
							throw new TestsFactory(mappingFilter2.Start, mappingFilter2.End, DicSingleton.gE3WbyDVW(0x5A1B57A3 ^ 0x5A1B2565), innerException);
						}
					}
					break;
				case 1:
				case 8:
				{
					if (!parser.TryConsume<ListFactory>(out var _))
					{
						num2 = 7;
						continue;
					}
					goto case 13;
				}
				}
				flag = flag || mappingFilter2 is DispatcherFilter || mappingFilter is DispatcherFilter;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
				{
					num2 = 1;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 10;
		}
	}

	public ListenerFilter()
	{
		GetterIssuer.DeleteInitializer();
		accountFilter = new IssuerReader<MappingFilter, MappingFilter>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ListenerFilter([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 0, 1, 1 })] params KeyValuePair<MappingFilter, MappingFilter>[] children)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector((IEnumerable<KeyValuePair<MappingFilter, MappingFilter>>)children);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ListenerFilter([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 0, 1, 1 })] IEnumerable<KeyValuePair<MappingFilter, MappingFilter>> children)
	{
		GetterIssuer.DeleteInitializer();
		accountFilter = new IssuerReader<MappingFilter, MappingFilter>();
		base._002Ector();
		foreach (KeyValuePair<MappingFilter, MappingFilter> child in children)
		{
			accountFilter.Add(child);
		}
	}

	public ListenerFilter(params MappingFilter[] children)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector((IEnumerable<MappingFilter>)children);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ListenerFilter(IEnumerable<MappingFilter> children)
	{
		GetterIssuer.DeleteInitializer();
		accountFilter = new IssuerReader<MappingFilter, MappingFilter>();
		base._002Ector();
		using IEnumerator<MappingFilter> enumerator = children.GetEnumerator();
		while (enumerator.MoveNext())
		{
			MappingFilter current = enumerator.Current;
			if (!enumerator.MoveNext())
			{
				throw new ArgumentException(DicSingleton.gE3WbyDVW(0x1679942F ^ 0x1679E6CB));
			}
			Add(current, enumerator.Current);
		}
	}

	public void Add(MappingFilter key, MappingFilter value)
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
				accountFilter.Add(key, value);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public void Add(string key, MappingFilter value)
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
				accountFilter.Add(new RefFilter(key), value);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public void Add(MappingFilter key, string value)
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
				accountFilter.Add(key, new RefFilter(value));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public void Add(string key, string value)
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
				accountFilter.Add(new RefFilter(key), new RefFilter(value));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal override void ResolveAliases(PolicyFilter state)
	{
		Dictionary<MappingFilter, MappingFilter> dictionary = null;
		Dictionary<MappingFilter, MappingFilter> dictionary2 = null;
		foreach (KeyValuePair<MappingFilter, MappingFilter> item in accountFilter)
		{
			if (item.Key is DispatcherFilter)
			{
				if (dictionary == null)
				{
					dictionary = new Dictionary<MappingFilter, MappingFilter>();
				}
				dictionary.Add(item.Key, state.GetNode(item.Key.Anchor, item.Key.Start, item.Key.End));
			}
			if (item.Value is DispatcherFilter)
			{
				if (dictionary2 == null)
				{
					dictionary2 = new Dictionary<MappingFilter, MappingFilter>();
				}
				dictionary2.Add(item.Key, state.GetNode(item.Value.Anchor, item.Value.Start, item.Value.End));
			}
		}
		if (dictionary2 != null)
		{
			foreach (KeyValuePair<MappingFilter, MappingFilter> item2 in dictionary2)
			{
				accountFilter[item2.Key] = item2.Value;
			}
		}
		if (dictionary == null)
		{
			return;
		}
		foreach (KeyValuePair<MappingFilter, MappingFilter> item3 in dictionary)
		{
			MappingFilter value = accountFilter[item3.Key];
			accountFilter.Remove(item3.Key);
			accountFilter.Add(item3.Value, value);
		}
	}

	internal override void Emit(ModelReader emitter, InfoFilter state)
	{
		emitter.Emit(new QueueFactory(base.Anchor, base.Tag, isImplicit: true, Style));
		foreach (KeyValuePair<MappingFilter, MappingFilter> item in accountFilter)
		{
			item.Key.Save(emitter, state);
			item.Value.Save(emitter, state);
		}
		emitter.Emit(new ListFactory());
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
			case 0:
				return;
			case 1:
				visitor.Visit(this);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	public override bool Equals(object obj)
	{
		if (!(obj is ListenerFilter listenerFilter) || !object.Equals(base.Tag, listenerFilter.Tag) || accountFilter.Count != listenerFilter.accountFilter.Count)
		{
			return false;
		}
		foreach (KeyValuePair<MappingFilter, MappingFilter> item in accountFilter)
		{
			if (listenerFilter.accountFilter.TryGetValue(item.Key, out var value) && object.Equals(item.Value, value))
			{
				continue;
			}
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		int num = base.GetHashCode();
		foreach (KeyValuePair<MappingFilter, MappingFilter> item in accountFilter)
		{
			num = ProxyReader.CombineHashCodes(num, item.Key);
			num = ProxyReader.CombineHashCodes(num, item.Value);
		}
		return num;
	}

	[IteratorStateMachine(typeof(_003CSafeAllNodes_003Ed__23))]
	internal override IEnumerable<MappingFilter> SafeAllNodes(SingletonFactory level)
	{
		//yield-return decompiler failed: Missing enumeratorCtor.Body
		return new _003CSafeAllNodes_003Ed__23(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__level = level
		};
	}

	internal override string ToString(SingletonFactory level)
	{
		if (!level.TryIncrement())
		{
			return DicSingleton.gE3WbyDVW(-849667636 ^ -849646984);
		}
		StringBuilder stringBuilder = new StringBuilder(DicSingleton.gE3WbyDVW(-1977574774 ^ -1977554566));
		foreach (KeyValuePair<MappingFilter, MappingFilter> item in accountFilter)
		{
			if (stringBuilder.Length > 2)
			{
				stringBuilder.Append(DicSingleton.gE3WbyDVW(-1398029315 ^ -1398036847));
			}
			stringBuilder.Append(DicSingleton.gE3WbyDVW(-1891833728 ^ -1891853456)).Append(item.Key.ToString(level)).Append(DicSingleton.gE3WbyDVW(-1891833728 ^ -1891856916))
				.Append(item.Value.ToString(level))
				.Append(DicSingleton.gE3WbyDVW(0x5A8BEE ^ 0x5AF816));
		}
		stringBuilder.Append(DicSingleton.gE3WbyDVW(-823738529 ^ -823735129));
		level.Decrement();
		return stringBuilder.ToString();
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 0, 1, 1 })]
	public IEnumerator<KeyValuePair<MappingFilter, MappingFilter>> GetEnumerator()
	{
		return accountFilter.GetEnumerator();
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 != 0)
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
			case 1:
				Emit(emitter, new InfoFilter());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public static ListenerFilter FromObject(object mapping)
	{
		int num = 4;
		int num2 = num;
		IEnumerator<PropertyInfo> enumerator = default(IEnumerator<PropertyInfo>);
		object value = default(object);
		PropertyInfo current = default(PropertyInfo);
		MappingFilter mappingFilter = default(MappingFilter);
		ListenerFilter listenerFilter = default(ListenerFilter);
		while (true)
		{
			switch (num2)
			{
			case 1:
				enumerator = CollectionBase.GetPublicProperties(mapping.GetType()).GetEnumerator();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
				{
					num2 = 0;
				}
				break;
			default:
				try
				{
					while (true)
					{
						IL_0171:
						int num3;
						if (!enumerator.MoveNext())
						{
							num3 = 11;
							goto IL_0080;
						}
						goto IL_00fd;
						IL_0187:
						value = current.GetValue(mapping, null);
						int num4 = 7;
						goto IL_007c;
						IL_00fd:
						current = enumerator.Current;
						num4 = 6;
						goto IL_007c;
						IL_007c:
						num3 = num4;
						goto IL_0080;
						IL_0080:
						while (true)
						{
							string text;
							switch (num3)
							{
							case 7:
								mappingFilter = value as MappingFilter;
								num3 = 10;
								continue;
							case 10:
								if (mappingFilter == null)
								{
									num3 = 1;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 == 0)
									{
										num3 = 3;
									}
									continue;
								}
								goto case 1;
							case 2:
								break;
							case 1:
								listenerFilter.Add(current.Name, mappingFilter);
								num3 = 4;
								continue;
							case 6:
								if (current.CanRead)
								{
									num3 = 5;
									continue;
								}
								goto IL_0171;
							case 5:
								if (current.GetGetMethod(nonPublic: false).GetParameters().Length != 0)
								{
									num3 = 8;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
									{
										num3 = 8;
									}
									continue;
								}
								goto IL_0187;
							case 4:
							case 8:
								goto IL_0171;
							case 9:
								goto IL_0187;
							case 3:
								text = Convert.ToString(value);
								if (text != null)
								{
									goto IL_01d2;
								}
								num3 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
								{
									num3 = 0;
								}
								continue;
							default:
								text = string.Empty;
								goto IL_01d2;
							case 11:
								goto end_IL_0171;
								IL_01d2:
								mappingFilter = text;
								num3 = 1;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac != 0)
								{
									num3 = 0;
								}
								continue;
							}
							break;
						}
						goto IL_00fd;
						continue;
						end_IL_0171:
						break;
					}
				}
				finally
				{
					if (enumerator != null)
					{
						int num5 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
						{
							num5 = 1;
						}
						while (true)
						{
							switch (num5)
							{
							case 1:
								enumerator.Dispose();
								num5 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
								{
									num5 = 0;
								}
								continue;
							case 0:
								break;
							}
							break;
						}
					}
				}
				goto case 2;
			case 2:
				return listenerFilter;
			case 4:
				if (mapping == null)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 == 0)
					{
						num2 = 3;
					}
					break;
				}
				listenerFilter = new ListenerFilter();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
				{
					num2 = 1;
				}
				break;
			case 3:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-954365995 ^ -954338347));
			}
		}
	}

	internal static bool RegisterAuthentication()
	{
		return PublishAuthentication == null;
	}

	internal static ListenerFilter SetupAuthentication()
	{
		return PublishAuthentication;
	}
}
