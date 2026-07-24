using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace AzuAnticheat.Internal;

internal sealed class ResolverAttribute : ProductAttribute, IEnumerable<KeyValuePair<ProductAttribute, ProductAttribute>>, IEnumerable, TagSetter
{
	[CompilerGenerated]
	private sealed class _003CSafeAllNodes_003Ed__23 : IEnumerable<ProductAttribute>, IEnumerable, IEnumerator<ProductAttribute>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private ProductAttribute _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private ProxyInterpreter level;

		public ProxyInterpreter _003C_003E3__level;

		public ResolverAttribute _003C_003E4__this;

		private IEnumerator<KeyValuePair<ProductAttribute, ProductAttribute>> _003C_003E7__wrap1;

		private KeyValuePair<ProductAttribute, ProductAttribute> _003Cchild_003E5__3;

		private IEnumerator<ProductAttribute> _003C_003E7__wrap3;

		private static _003CSafeAllNodes_003Ed__23 VisitToken;

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
		public _003CSafeAllNodes_003Ed__23(int _003C_003E1__state)
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
				case 2:
					this._003C_003E1__state = _003C_003E1__state;
					num = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
					{
						num = 1;
					}
					break;
				case 0:
					return;
				case 1:
					_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
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
			int num = _003C_003E1__state;
			if ((uint)(num - -5) > 2u && (uint)(num - 2) > 1u)
			{
				return;
			}
			try
			{
				switch (num)
				{
				case -4:
				case 2:
					try
					{
						break;
					}
					finally
					{
						_003C_003Em__Finally2();
					}
				case -5:
				case 3:
					try
					{
						break;
					}
					finally
					{
						_003C_003Em__Finally3();
					}
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
				ResolverAttribute resolverAttribute = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					level.Increment();
					_003C_003E2__current = resolverAttribute;
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = resolverAttribute.m_CandidateAttribute.GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_018e;
				case 2:
					_003C_003E1__state = -4;
					goto IL_00e9;
				case 3:
					{
						_003C_003E1__state = -5;
						goto IL_0160;
					}
					IL_018e:
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
						ProductAttribute current = _003C_003E7__wrap3.Current;
						_003C_003E2__current = current;
						_003C_003E1__state = 3;
						return true;
					}
					_003C_003Em__Finally3();
					_003C_003E7__wrap3 = null;
					_003Cchild_003E5__3 = default(KeyValuePair<ProductAttribute, ProductAttribute>);
					goto IL_018e;
					IL_00e9:
					if (_003C_003E7__wrap3.MoveNext())
					{
						ProductAttribute current2 = _003C_003E7__wrap3.Current;
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
				default:
					if (_003C_003E7__wrap1 != null)
					{
						num2 = 3;
						break;
					}
					return;
				case 2:
					return;
				case 3:
					_003C_003E7__wrap1.Dispose();
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
					{
						num2 = 0;
					}
					break;
				case 1:
					_003C_003E1__state = -1;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
					{
						num2 = 0;
					}
					break;
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
				case 2:
					_003C_003E7__wrap3.Dispose();
					num2 = 3;
					continue;
				case 3:
					return;
				case 1:
					_003C_003E1__state = -3;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
					{
						num2 = 0;
					}
					continue;
				}
				if (_003C_003E7__wrap3 != null)
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
					{
						num2 = 2;
					}
					continue;
				}
				return;
			}
		}

		private void _003C_003Em__Finally3()
		{
			int num = 4;
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					default:
						return;
					case 3:
						if (_003C_003E7__wrap3 == null)
						{
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
							{
								num2 = 0;
							}
							continue;
						}
						break;
					case 0:
						return;
					case 2:
						return;
					case 4:
						_003C_003E1__state = -3;
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec != 0)
						{
							num2 = 3;
						}
						continue;
					case 1:
						break;
					}
					break;
				}
				_003C_003E7__wrap3.Dispose();
				num = 2;
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
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ProductAttribute>)this).GetEnumerator();
		}

		internal static bool OrderToken()
		{
			return VisitToken == null;
		}

		internal static _003CSafeAllNodes_003Ed__23 UpdateToken()
		{
			return VisitToken;
		}
	}

	private readonly ServerAttribute<ProductAttribute, ProductAttribute> m_CandidateAttribute;

	[CompilerGenerated]
	private Level expressionAttribute;

	internal static ResolverAttribute SortToken;

	public ConfigAttribute<ProductAttribute, ProductAttribute> Children => m_CandidateAttribute;

	public Level Style
	{
		[CompilerGenerated]
		get
		{
			return expressionAttribute;
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
					expressionAttribute = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 != 0)
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

	public override ActivityTemplateFactoryBuilderWriterStates NodeType => (ActivityTemplateFactoryBuilderWriterStates)1;

	internal ResolverAttribute(CandidateInterpreter parser, IdentifierAttribute state)
	{
		GetterIssuer.DeleteInitializer();
		m_CandidateAttribute = new ServerAttribute<ProductAttribute, ProductAttribute>();
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
			Load(parser, state);
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
			{
				num = 0;
			}
		}
	}

	private void Load(CandidateInterpreter parser, IdentifierAttribute state)
	{
		int num = 3;
		bool flag = default(bool);
		FacadeSingleton facadeSingleton = default(FacadeSingleton);
		ProductAttribute productAttribute2 = default(ProductAttribute);
		ProductAttribute productAttribute = default(ProductAttribute);
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					flag = false;
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
					{
						num2 = 4;
					}
					continue;
				case 3:
					facadeSingleton = parser.Consume<FacadeSingleton>();
					num2 = 2;
					continue;
				case 11:
					if (!flag)
					{
						num2 = 12;
						continue;
					}
					goto case 9;
				case 4:
				case 8:
				{
					if (parser.TryConsume<ParamSingleton>(out var _))
					{
						num2 = 11;
						continue;
					}
					goto case 13;
				}
				case 2:
					Load(facadeSingleton, state);
					num2 = 5;
					continue;
				case 12:
					return;
				case 10:
					return;
				case 6:
					productAttribute2 = ProductAttribute.ParseNode(parser, state);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
					{
						num2 = 1;
					}
					continue;
				case 5:
					Style = facadeSingleton.Style;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
					{
						num2 = 0;
					}
					continue;
				case 13:
					productAttribute = ProductAttribute.ParseNode(parser, state);
					num2 = 6;
					continue;
				case 1:
					try
					{
						m_CandidateAttribute.Add(productAttribute, productAttribute2);
						int num3 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
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
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
						{
							num4 = 0;
						}
						while (true)
						{
							switch (num4)
							{
							case 1:
								throw new ReaderSingleton(in start, productAttribute.End, DicSingleton.gE3WbyDVW(-1611872559 ^ -1611877353), innerException);
							}
							start = productAttribute.Start;
							num4 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 != 0)
							{
								num4 = 1;
							}
						}
					}
					goto case 7;
				case 9:
					state.AddNodeWithUnresolvedAliases(this);
					num = 10;
					break;
				case 7:
					flag = flag || productAttribute is MethodAttribute || productAttribute2 is MethodAttribute;
					num = 8;
					break;
				}
				break;
			}
		}
	}

	public ResolverAttribute()
	{
		GetterIssuer.DeleteInitializer();
		m_CandidateAttribute = new ServerAttribute<ProductAttribute, ProductAttribute>();
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

	public ResolverAttribute(params KeyValuePair<ProductAttribute, ProductAttribute>[] children)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector((IEnumerable<KeyValuePair<ProductAttribute, ProductAttribute>>)children);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ResolverAttribute(IEnumerable<KeyValuePair<ProductAttribute, ProductAttribute>> children)
	{
		GetterIssuer.DeleteInitializer();
		m_CandidateAttribute = new ServerAttribute<ProductAttribute, ProductAttribute>();
		base._002Ector();
		foreach (KeyValuePair<ProductAttribute, ProductAttribute> child in children)
		{
			m_CandidateAttribute.Add(child);
		}
	}

	public ResolverAttribute(params ProductAttribute[] children)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector((IEnumerable<ProductAttribute>)children);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ResolverAttribute(IEnumerable<ProductAttribute> children)
	{
		GetterIssuer.DeleteInitializer();
		m_CandidateAttribute = new ServerAttribute<ProductAttribute, ProductAttribute>();
		base._002Ector();
		using IEnumerator<ProductAttribute> enumerator = children.GetEnumerator();
		while (enumerator.MoveNext())
		{
			ProductAttribute current = enumerator.Current;
			if (!enumerator.MoveNext())
			{
				throw new ArgumentException(DicSingleton.gE3WbyDVW(0x74FC52AF ^ 0x74FC204B));
			}
			Add(current, enumerator.Current);
		}
	}

	public void Add(ProductAttribute key, ProductAttribute value)
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
				m_CandidateAttribute.Add(key, value);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public void Add(string key, ProductAttribute value)
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
				m_CandidateAttribute.Add(new UtilsAttribute(key), value);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public void Add(ProductAttribute key, string value)
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
				m_CandidateAttribute.Add(key, new UtilsAttribute(value));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
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
				m_CandidateAttribute.Add(new UtilsAttribute(key), new UtilsAttribute(value));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal override void ResolveAliases(IdentifierAttribute state)
	{
		Dictionary<ProductAttribute, ProductAttribute> dictionary = null;
		Dictionary<ProductAttribute, ProductAttribute> dictionary2 = null;
		foreach (KeyValuePair<ProductAttribute, ProductAttribute> item in m_CandidateAttribute)
		{
			if (item.Key is MethodAttribute)
			{
				if (dictionary == null)
				{
					dictionary = new Dictionary<ProductAttribute, ProductAttribute>();
				}
				dictionary.Add(item.Key, state.GetNode(item.Key.Anchor, item.Key.Start, item.Key.End));
			}
			if (item.Value is MethodAttribute)
			{
				if (dictionary2 == null)
				{
					dictionary2 = new Dictionary<ProductAttribute, ProductAttribute>();
				}
				dictionary2.Add(item.Key, state.GetNode(item.Value.Anchor, item.Value.Start, item.Value.End));
			}
		}
		if (dictionary2 != null)
		{
			foreach (KeyValuePair<ProductAttribute, ProductAttribute> item2 in dictionary2)
			{
				m_CandidateAttribute[item2.Key] = item2.Value;
			}
		}
		if (dictionary == null)
		{
			return;
		}
		foreach (KeyValuePair<ProductAttribute, ProductAttribute> item3 in dictionary)
		{
			ProductAttribute value = m_CandidateAttribute[item3.Key];
			m_CandidateAttribute.Remove(item3.Key);
			m_CandidateAttribute.Add(item3.Value, value);
		}
	}

	internal override void Emit(MockInterpreter emitter, RulesAttribute state)
	{
		emitter.Emit(new FacadeSingleton(base.Anchor, base.Tag, isImplicit: true, Style));
		foreach (KeyValuePair<ProductAttribute, ProductAttribute> item in m_CandidateAttribute)
		{
			item.Key.Save(emitter, state);
			item.Value.Save(emitter, state);
		}
		emitter.Emit(new ParamSingleton());
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public override bool Equals(object? obj)
	{
		if (!(obj is ResolverAttribute resolverAttribute) || !object.Equals(base.Tag, resolverAttribute.Tag) || m_CandidateAttribute.Count != resolverAttribute.m_CandidateAttribute.Count)
		{
			return false;
		}
		foreach (KeyValuePair<ProductAttribute, ProductAttribute> item in m_CandidateAttribute)
		{
			if (resolverAttribute.m_CandidateAttribute.TryGetValue(item.Key, out ProductAttribute value) && object.Equals(item.Value, value))
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
		foreach (KeyValuePair<ProductAttribute, ProductAttribute> item in m_CandidateAttribute)
		{
			num = IndexerInterpreter.CombineHashCodes(num, item.Key);
			num = IndexerInterpreter.CombineHashCodes(num, item.Value);
		}
		return num;
	}

	[IteratorStateMachine(typeof(_003CSafeAllNodes_003Ed__23))]
	internal override IEnumerable<ProductAttribute> SafeAllNodes(ProxyInterpreter level)
	{
		//yield-return decompiler failed: Missing enumeratorCtor.Body
		return new _003CSafeAllNodes_003Ed__23(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__level = level
		};
	}

	internal override string ToString(ProxyInterpreter level)
	{
		if (!level.TryIncrement())
		{
			return DicSingleton.gE3WbyDVW(-293474990 ^ -293495066);
		}
		ReponseAttribute.ModelAttribute modelAttribute = ReponseAttribute.Rent();
		try
		{
			StringBuilder advisorAttribute = modelAttribute.m_AdvisorAttribute;
			advisorAttribute.Append(DicSingleton.gE3WbyDVW(0x38262FC9 ^ 0x38265C39));
			foreach (KeyValuePair<ProductAttribute, ProductAttribute> item in m_CandidateAttribute)
			{
				if (advisorAttribute.Length > 2)
				{
					advisorAttribute.Append(DicSingleton.gE3WbyDVW(-316028230 ^ -316035114));
				}
				advisorAttribute.Append(DicSingleton.gE3WbyDVW(0x3A437A88 ^ 0x3A430978)).Append(item.Key.ToString(level)).Append(DicSingleton.gE3WbyDVW(0x69B67B3A ^ 0x69B61E56))
					.Append(item.Value.ToString(level))
					.Append(DicSingleton.gE3WbyDVW(-830028630 ^ -830032046));
			}
			advisorAttribute.Append(DicSingleton.gE3WbyDVW(--798431903 ^ 0x2F976967));
			level.Decrement();
			return advisorAttribute.ToString();
		}
		finally
		{
			((IDisposable)modelAttribute/*cast due to .constrained prefix*/).Dispose();
		}
	}

	public IEnumerator<KeyValuePair<ProductAttribute, ProductAttribute>> GetEnumerator()
	{
		return m_CandidateAttribute.GetEnumerator();
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
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

	public static ResolverAttribute FromObject(object mapping)
	{
		int num = 1;
		int num2 = num;
		IEnumerator<PropertyInfo> enumerator = default(IEnumerator<PropertyInfo>);
		PropertyInfo current = default(PropertyInfo);
		ProductAttribute productAttribute = default(ProductAttribute);
		object value = default(object);
		ResolverAttribute resolverAttribute = default(ResolverAttribute);
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (mapping != null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 5;
			case 4:
				try
				{
					while (true)
					{
						IL_019c:
						int num4;
						if (!enumerator.MoveNext())
						{
							int num3 = 8;
							num4 = num3;
							goto IL_0087;
						}
						goto IL_00e4;
						IL_0087:
						while (true)
						{
							string text;
							switch (num4)
							{
							case 6:
								break;
							case 9:
								if (!current.CanRead)
								{
									num4 = 1;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
									{
										num4 = 0;
									}
									continue;
								}
								goto default;
							case 7:
								productAttribute = value as ProductAttribute;
								num4 = 3;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
								{
									num4 = 2;
								}
								continue;
							case 11:
								value = current.GetValue(mapping, null);
								num4 = 7;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
								{
									num4 = 1;
								}
								continue;
							case 5:
								text = Convert.ToString(value);
								if (text == null)
								{
									num4 = 2;
									continue;
								}
								goto IL_0223;
							case 1:
							case 10:
							case 12:
								goto IL_019c;
							default:
								if (current.GetGetMethod(nonPublic: false).GetParameters().Length != 0)
								{
									num4 = 5;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 != 0)
									{
										num4 = 12;
									}
									continue;
								}
								goto case 11;
							case 3:
								if (productAttribute == null)
								{
									num4 = 5;
									continue;
								}
								goto case 4;
							case 4:
								resolverAttribute.Add(current.Name, productAttribute);
								num4 = 10;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 != 0)
								{
									num4 = 10;
								}
								continue;
							case 2:
								text = string.Empty;
								goto IL_0223;
							case 8:
								goto end_IL_019c;
								IL_0223:
								productAttribute = text;
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
								{
									num4 = 4;
								}
								continue;
							}
							break;
						}
						goto IL_00e4;
						IL_00e4:
						current = enumerator.Current;
						num4 = 9;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 != 0)
						{
							num4 = 4;
						}
						goto IL_0087;
						continue;
						end_IL_019c:
						break;
					}
				}
				finally
				{
					if (enumerator != null)
					{
						int num5 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
						{
							num5 = 0;
						}
						while (true)
						{
							switch (num5)
							{
							default:
								enumerator.Dispose();
								num5 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 != 0)
								{
									num5 = 1;
								}
								continue;
							case 1:
								break;
							}
							break;
						}
					}
				}
				goto case 3;
			case 3:
				return resolverAttribute;
			case 2:
				enumerator = InterceptorSetter.GetPublicProperties(mapping.GetType()).GetEnumerator();
				num2 = 4;
				break;
			case 5:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(--798431903 ^ 0x2F976E9F));
			default:
				resolverAttribute = new ResolverAttribute();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	internal static bool InsertToken()
	{
		return SortToken == null;
	}

	internal static ResolverAttribute FindToken()
	{
		return SortToken;
	}
}
