using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace AzuAnticheat.Internal;

[DebuggerDisplay("Count = {children.Count}")]
internal sealed class ParserAttribute : ProductAttribute, IEnumerable<ProductAttribute>, IEnumerable, TagSetter
{
	[CompilerGenerated]
	private sealed class _003CSafeAllNodes_003Ed__19 : IEnumerable<ProductAttribute>, IEnumerable, IEnumerator<ProductAttribute>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private ProductAttribute _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private ProxyInterpreter level;

		public ProxyInterpreter _003C_003E3__level;

		public ParserAttribute _003C_003E4__this;

		private IEnumerator<ProductAttribute> _003C_003E7__wrap1;

		private IEnumerator<ProductAttribute> _003C_003E7__wrap2;

		private static _003CSafeAllNodes_003Ed__19 RateToken;

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
		public _003CSafeAllNodes_003Ed__19(int _003C_003E1__state)
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
					_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 == 0)
					{
						num = 0;
					}
					break;
				case 2:
					this._003C_003E1__state = _003C_003E1__state;
					num = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
					{
						num = 1;
					}
					break;
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
			bool result = default(bool);
			switch (1)
			{
			case 1:
				try
				{
					int num = _003C_003E1__state;
					int num2 = 21;
					ProductAttribute current2 = default(ProductAttribute);
					ProductAttribute current = default(ProductAttribute);
					ParserAttribute parserAttribute = default(ParserAttribute);
					while (true)
					{
						IL_003e:
						int num3 = num2;
						while (true)
						{
							switch (num3)
							{
							case 19:
								result = false;
								num3 = 31;
								continue;
							case 24:
								_003C_003Em__Finally2();
								num3 = 20;
								continue;
							case 17:
								_003C_003E2__current = current2;
								num3 = 23;
								continue;
							case 7:
								result = true;
								num3 = 28;
								continue;
							case 14:
								_003C_003E7__wrap2 = current.SafeAllNodes(level).GetEnumerator();
								num3 = 6;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
								{
									num3 = 11;
								}
								continue;
							case 4:
								result = false;
								num3 = 6;
								continue;
							case 1:
								_003C_003E7__wrap1 = parserAttribute._RequestAttribute.GetEnumerator();
								num3 = 30;
								continue;
							case 6:
								break;
							case 30:
								_003C_003E1__state = -3;
								num3 = 1;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 != 0)
								{
									num3 = 32;
								}
								continue;
							case 10:
								break;
							case 16:
							case 33:
								current = _003C_003E7__wrap1.Current;
								num3 = 8;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
								{
									num3 = 14;
								}
								continue;
							case 3:
								_003C_003E2__current = parserAttribute;
								num3 = 15;
								continue;
							case 9:
								current2 = _003C_003E7__wrap2.Current;
								num3 = 11;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
								{
									num3 = 17;
								}
								continue;
							case 27:
								level.Increment();
								num3 = 3;
								continue;
							case 8:
								level.Decrement();
								num3 = 19;
								continue;
							case 20:
								_003C_003E7__wrap2 = null;
								num3 = 2;
								continue;
							case 2:
							case 32:
								if (_003C_003E7__wrap1.MoveNext())
								{
									num3 = 16;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 != 0)
									{
										num3 = 6;
									}
									continue;
								}
								goto default;
							case 15:
								_003C_003E1__state = 1;
								num3 = 7;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
								{
									num3 = 6;
								}
								continue;
							default:
								_003C_003Em__Finally1();
								num3 = 25;
								continue;
							case 29:
								result = true;
								num3 = 10;
								continue;
							case 21:
								parserAttribute = _003C_003E4__this;
								num3 = 13;
								continue;
							case 13:
								switch (num)
								{
								case 2:
									goto IL_0358;
								case 0:
									goto IL_037a;
								case 1:
									goto IL_03c1;
								}
								num3 = 4;
								continue;
							case 12:
							case 22:
								if (!_003C_003E7__wrap2.MoveNext())
								{
									num3 = 7;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 == 0)
									{
										num3 = 24;
									}
									continue;
								}
								goto case 9;
							case 18:
								goto IL_0358;
							case 26:
								goto IL_037a;
							case 25:
								_003C_003E7__wrap1 = null;
								num3 = 8;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
								{
									num3 = 7;
								}
								continue;
							case 23:
								goto IL_03ac;
							case 5:
								goto IL_03c1;
							case 11:
								_003C_003E1__state = -4;
								num3 = 19;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
								{
									num3 = 22;
								}
								continue;
							case 28:
								break;
							case 31:
								break;
								IL_03c1:
								_003C_003E1__state = -1;
								num3 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
								{
									num3 = 1;
								}
								continue;
								IL_037a:
								_003C_003E1__state = -1;
								num3 = 27;
								continue;
								IL_0358:
								_003C_003E1__state = -4;
								num3 = 8;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 == 0)
								{
									num3 = 12;
								}
								continue;
							}
							break;
							IL_03ac:
							_003C_003E1__state = 2;
							num2 = 29;
							goto IL_003e;
						}
						break;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					int num4 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
					{
						num4 = 0;
					}
					switch (num4)
					{
					case 0:
						break;
					}
					throw;
				}
				break;
			}
			return result;
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
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				case 1:
					if (_003C_003E7__wrap1 == null)
					{
						return;
					}
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec == 0)
					{
						num2 = 3;
					}
					break;
				case 3:
					_003C_003E7__wrap1.Dispose();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		private void _003C_003Em__Finally2()
		{
			int num = 3;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 4:
					_003C_003E7__wrap2.Dispose();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 != 0)
					{
						num2 = 1;
					}
					break;
				case 2:
					if (_003C_003E7__wrap2 == null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 != 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 4;
				case 0:
					return;
				case 1:
					return;
				case 3:
					_003C_003E1__state = -3;
					num2 = 2;
					break;
				}
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<ProductAttribute> IEnumerable<ProductAttribute>.GetEnumerator()
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
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ProductAttribute>)this).GetEnumerator();
		}

		internal static bool ResetToken()
		{
			return RateToken == null;
		}

		internal static _003CSafeAllNodes_003Ed__19 CustomizeToken()
		{
			return RateToken;
		}
	}

	private readonly IList<ProductAttribute> _RequestAttribute;

	[CompilerGenerated]
	private DockingBehavior _ParamAttribute;

	internal static ParserAttribute DefineToken;

	public IList<ProductAttribute> Children => _RequestAttribute;

	public DockingBehavior Style
	{
		[CompilerGenerated]
		get
		{
			return _ParamAttribute;
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
					_ParamAttribute = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec != 0)
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

	public override ActivityTemplateFactoryBuilderWriterStates NodeType => (ActivityTemplateFactoryBuilderWriterStates)3;

	internal ParserAttribute(CandidateInterpreter parser, IdentifierAttribute state)
	{
		GetterIssuer.DeleteInitializer();
		_RequestAttribute = new List<ProductAttribute>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
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
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 != 0)
			{
				num = 1;
			}
		}
	}

	private void Load(CandidateInterpreter parser, IdentifierAttribute state)
	{
		int num = 9;
		int num2 = num;
		ExporterSingleton exporterSingleton = default(ExporterSingleton);
		ProductAttribute productAttribute = default(ProductAttribute);
		bool flag = default(bool);
		while (true)
		{
			switch (num2)
			{
			case 8:
				Load(exporterSingleton, state);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
				{
					num2 = 5;
				}
				continue;
			case 5:
				Style = exporterSingleton.Style;
				num2 = 6;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 != 0)
				{
					num2 = 7;
				}
				continue;
			case 10:
				return;
			case 2:
				productAttribute = ProductAttribute.ParseNode(parser, state);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 != 0)
				{
					num2 = 0;
				}
				continue;
			default:
				_RequestAttribute.Add(productAttribute);
				num2 = 11;
				continue;
			case 7:
				flag = false;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
				{
					num2 = 1;
				}
				continue;
			case 3:
				return;
			case 6:
				if (!flag)
				{
					num2 = 10;
					continue;
				}
				break;
			case 11:
				flag = flag || productAttribute is MethodAttribute;
				num2 = 4;
				continue;
			case 1:
			case 4:
			{
				if (parser.TryConsume<MessageSingleton>(out var _))
				{
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
					{
						num2 = 6;
					}
					continue;
				}
				goto case 2;
			}
			case 9:
				exporterSingleton = parser.Consume<ExporterSingleton>();
				num2 = 8;
				continue;
			case 12:
				break;
			}
			state.AddNodeWithUnresolvedAliases(this);
			num2 = 3;
		}
	}

	public ParserAttribute()
	{
		GetterIssuer.DeleteInitializer();
		_RequestAttribute = new List<ProductAttribute>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ParserAttribute(params ProductAttribute[] children)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector((IEnumerable<ProductAttribute>)children);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ParserAttribute(IEnumerable<ProductAttribute> children)
	{
		GetterIssuer.DeleteInitializer();
		_RequestAttribute = new List<ProductAttribute>();
		base._002Ector();
		foreach (ProductAttribute child in children)
		{
			_RequestAttribute.Add(child);
		}
	}

	public void Add(ProductAttribute child)
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
				_RequestAttribute.Add(child);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 != 0)
				{
					num2 = 0;
				}
				break;
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
				_RequestAttribute.Add(new UtilsAttribute(child));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal override void ResolveAliases(IdentifierAttribute state)
	{
		int num = 1;
		int num2 = num;
		int num3 = default(int);
		while (true)
		{
			switch (num2)
			{
			case 5:
				num3++;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc != 0)
				{
					num2 = 2;
				}
				continue;
			case 7:
				_RequestAttribute[num3] = state.GetNode(_RequestAttribute[num3].Anchor, _RequestAttribute[num3].Start, _RequestAttribute[num3].End);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
				{
					num2 = 5;
				}
				continue;
			case 4:
			case 6:
				if (_RequestAttribute[num3] is MethodAttribute)
				{
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 != 0)
					{
						num2 = 7;
					}
					continue;
				}
				goto case 5;
			case 1:
				num3 = 0;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
				{
					num2 = 0;
				}
				continue;
			case 3:
				return;
			}
			if (num3 < _RequestAttribute.Count)
			{
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf != 0)
				{
					num2 = 4;
				}
				continue;
			}
			return;
		}
	}

	internal override void Emit(MockInterpreter emitter, RulesAttribute state)
	{
		emitter.Emit(new ExporterSingleton(base.Anchor, base.Tag, base.Tag.IsEmpty, Style));
		foreach (ProductAttribute item in _RequestAttribute)
		{
			item.Save(emitter, state);
		}
		emitter.Emit(new MessageSingleton());
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public override bool Equals(object? obj)
	{
		int num = 11;
		int num2 = num;
		int num3 = default(int);
		ParserAttribute parserAttribute = default(ParserAttribute);
		while (true)
		{
			switch (num2)
			{
			case 3:
				return false;
			case 2:
				return false;
			case 6:
			case 7:
				if (num3 < _RequestAttribute.Count)
				{
					num2 = 12;
					continue;
				}
				goto case 4;
			case 9:
			case 12:
				if (object.Equals(_RequestAttribute[num3], parserAttribute._RequestAttribute[num3]))
				{
					num3++;
					num2 = 7;
				}
				else
				{
					num2 = 3;
				}
				continue;
			case 5:
				if (_RequestAttribute.Count == parserAttribute._RequestAttribute.Count)
				{
					num3 = 0;
					num2 = 6;
					continue;
				}
				break;
			case 11:
				parserAttribute = obj as ParserAttribute;
				num2 = 10;
				continue;
			case 4:
				return true;
			case 10:
				if (parserAttribute == null)
				{
					num2 = 8;
					continue;
				}
				goto case 1;
			case 1:
				if (!object.Equals(base.Tag, parserAttribute.Tag))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
					{
						num2 = 0;
					}
					continue;
				}
				goto case 5;
			}
			num2 = 2;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
			{
				num2 = 2;
			}
		}
	}

	public override int GetHashCode()
	{
		int h = 0;
		foreach (ProductAttribute item in _RequestAttribute)
		{
			h = IndexerInterpreter.CombineHashCodes(h, item);
		}
		return IndexerInterpreter.CombineHashCodes(h, base.Tag);
	}

	[IteratorStateMachine(typeof(_003CSafeAllNodes_003Ed__19))]
	internal override IEnumerable<ProductAttribute> SafeAllNodes(ProxyInterpreter level)
	{
		//yield-return decompiler failed: Missing enumeratorCtor.Body
		return new _003CSafeAllNodes_003Ed__19(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__level = level
		};
	}

	internal override string ToString(ProxyInterpreter level)
	{
		if (!level.TryIncrement())
		{
			return DicSingleton.gE3WbyDVW(-428135557 ^ -428123953);
		}
		ReponseAttribute.ModelAttribute modelAttribute = ReponseAttribute.Rent();
		try
		{
			StringBuilder advisorAttribute = modelAttribute.m_AdvisorAttribute;
			advisorAttribute.Append(DicSingleton.gE3WbyDVW(0x548F02D9 ^ 0x548F740D));
			foreach (ProductAttribute item in _RequestAttribute)
			{
				if (advisorAttribute.Length > 2)
				{
					advisorAttribute.Append(DicSingleton.gE3WbyDVW(0x40385DA3 ^ 0x403838CF));
				}
				advisorAttribute.Append(item.ToString(level));
			}
			advisorAttribute.Append(DicSingleton.gE3WbyDVW(0x40385DA3 ^ 0x40382B7F));
			level.Decrement();
			return advisorAttribute.ToString();
		}
		finally
		{
			((IDisposable)modelAttribute/*cast due to .constrained prefix*/).Dispose();
		}
	}

	public IEnumerator<ProductAttribute> GetEnumerator()
	{
		return Children.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
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
			case 0:
				return;
			case 1:
				Load(parser, new IdentifierAttribute());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
				{
					num2 = 0;
				}
				break;
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool IncludeToken()
	{
		return DefineToken == null;
	}

	internal static ParserAttribute CheckToken()
	{
		return DefineToken;
	}
}
