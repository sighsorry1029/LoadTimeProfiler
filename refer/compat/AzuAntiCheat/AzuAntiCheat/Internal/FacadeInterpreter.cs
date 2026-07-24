using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class FacadeInterpreter : CandidateInterpreter
{
	private sealed class IteratorInterpreter : IEnumerable<LinkedListNode<ClientSingleton>>, IEnumerable
	{
		[CompilerGenerated]
		private sealed class _003CEnumerate_003Ed__12 : IEnumerable<LinkedListNode<ClientSingleton>>, IEnumerable, IEnumerator<LinkedListNode<ClientSingleton>>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private LinkedListNode<ClientSingleton> _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private LinkedListNode<ClientSingleton> node;

			public LinkedListNode<ClientSingleton> _003C_003E3__node;

			internal static _003CEnumerate_003Ed__12 RestartConsumer;

			LinkedListNode<ClientSingleton> IEnumerator<LinkedListNode<ClientSingleton>>.Current
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
			public _003CEnumerate_003Ed__12(int _003C_003E1__state)
			{
				GetterIssuer.DeleteInitializer();
				base._002Ector();
				int num = 2;
				while (true)
				{
					switch (num)
					{
					case 1:
						return;
					case 2:
						this._003C_003E1__state = _003C_003E1__state;
						num = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba != 0)
						{
							num = 0;
						}
						break;
					default:
						_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
						num = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 != 0)
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
			}

			private bool MoveNext()
			{
				int num = 10;
				int num3 = default(int);
				while (true)
				{
					int num2 = num;
					while (true)
					{
						switch (num2)
						{
						case 10:
							num3 = _003C_003E1__state;
							num = 9;
							break;
						case 3:
							return true;
						case 1:
							_003C_003E1__state = 1;
							num2 = 3;
							continue;
						case 11:
							_003C_003E2__current = node;
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
							{
								num2 = 1;
							}
							continue;
						case 7:
							if (num3 == 1)
							{
								_003C_003E1__state = -1;
								num2 = 6;
								continue;
							}
							num2 = 8;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
							{
								num2 = 7;
							}
							continue;
						case 5:
							return false;
						default:
							if (node == null)
							{
								num2 = 5;
								continue;
							}
							goto case 11;
						case 9:
							if (num3 == 0)
							{
								num2 = 2;
								continue;
							}
							goto case 7;
						case 8:
							return false;
						case 2:
							_003C_003E1__state = -1;
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
							{
								num2 = 0;
							}
							continue;
						case 6:
							node = node.Next;
							num = 4;
							break;
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
			IEnumerator<LinkedListNode<ClientSingleton>> IEnumerable<LinkedListNode<ClientSingleton>>.GetEnumerator()
			{
				_003CEnumerate_003Ed__12 _003CEnumerate_003Ed__;
				if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
				{
					_003C_003E1__state = 0;
					_003CEnumerate_003Ed__ = this;
				}
				else
				{
					_003CEnumerate_003Ed__ = new _003CEnumerate_003Ed__12(0);
				}
				_003CEnumerate_003Ed__.node = _003C_003E3__node;
				return _003CEnumerate_003Ed__;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<LinkedListNode<ClientSingleton>>)this).GetEnumerator();
			}

			internal static bool GetConsumer()
			{
				return RestartConsumer == null;
			}

			internal static _003CEnumerate_003Ed__12 CalculateConsumer()
			{
				return RestartConsumer;
			}
		}

		private readonly LinkedList<ClientSingleton> _ClientInterpreter;

		private readonly HashSet<LinkedListNode<ClientSingleton>> _RecordInterpreter;

		private readonly Dictionary<VisitorAttribute, LinkedListNode<ClientSingleton>> serviceInterpreter;

		internal static IteratorInterpreter CollectConsumer;

		public IteratorInterpreter()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 2;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
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
					_RecordInterpreter = new HashSet<LinkedListNode<ClientSingleton>>();
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 == 0)
					{
						num = 3;
					}
					break;
				case 3:
					serviceInterpreter = new Dictionary<VisitorAttribute, LinkedListNode<ClientSingleton>>();
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
					{
						num = 0;
					}
					break;
				case 0:
					return;
				case 2:
					_ClientInterpreter = new LinkedList<ClientSingleton>();
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 != 0)
					{
						num = 1;
					}
					break;
				}
			}
		}

		public void AddAfter(LinkedListNode<ClientSingleton> node, IEnumerable<ClientSingleton> items)
		{
			foreach (ClientSingleton item in items)
			{
				node = _ClientInterpreter.AddAfter(node, item);
			}
		}

		public void Add(ClientSingleton item)
		{
			int num = 1;
			int num2 = num;
			LinkedListNode<ClientSingleton> node = default(LinkedListNode<ClientSingleton>);
			while (true)
			{
				switch (num2)
				{
				default:
					AddReference(item, node);
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c != 0)
					{
						num2 = 1;
					}
					break;
				case 2:
					return;
				case 1:
					node = _ClientInterpreter.AddLast(item);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		public void MarkDeleted(LinkedListNode<ClientSingleton> node)
		{
			_RecordInterpreter.Add(node);
		}

		public bool IsDeleted(LinkedListNode<ClientSingleton> node)
		{
			return _RecordInterpreter.Contains(node);
		}

		public void CleanMarked()
		{
			foreach (LinkedListNode<ClientSingleton> item in _RecordInterpreter)
			{
				_ClientInterpreter.Remove(item);
			}
		}

		public IEnumerable<LinkedListNode<ClientSingleton>> FromAnchor(VisitorAttribute anchor)
		{
			LinkedListNode<ClientSingleton> next = serviceInterpreter[anchor].Next;
			return Enumerate(next);
		}

		public IEnumerator<LinkedListNode<ClientSingleton>> GetEnumerator()
		{
			return Enumerate(_ClientInterpreter.First).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		[IteratorStateMachine(typeof(_003CEnumerate_003Ed__12))]
		private IEnumerable<LinkedListNode<ClientSingleton>> Enumerate(LinkedListNode<ClientSingleton>? node)
		{
			//yield-return decompiler failed: Missing enumeratorCtor.Body
			return new _003CEnumerate_003Ed__12(-2)
			{
				_003C_003E3__node = node
			};
		}

		private void AddReference(ClientSingleton item, LinkedListNode<ClientSingleton> node)
		{
			if (item is FacadeSingleton { Anchor: { IsEmpty: false } anchor })
			{
				serviceInterpreter[anchor] = node;
			}
		}

		internal static bool ManageConsumer()
		{
			return CollectConsumer == null;
		}

		internal static IteratorInterpreter ForgotConsumer()
		{
			return CollectConsumer;
		}
	}

	private sealed class BridgeInterpreter : RequestSingleton
	{
		private ClientSingleton? m_ParameterInterpreter;

		private static BridgeInterpreter MoveConsumer;

		public ClientSingleton Clone(ClientSingleton e)
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 2:
					throw new InvalidOperationException(string.Format(DicSingleton.gE3WbyDVW(-1817326817 ^ -1817360171), e.Type));
				case 1:
					e.Accept(this);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 == 0)
					{
						num2 = 0;
					}
					continue;
				}
				if (m_ParameterInterpreter == null)
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
					{
						num2 = 2;
					}
					continue;
				}
				return m_ParameterInterpreter;
			}
		}

		void RequestSingleton.Visit(StateSingleton e)
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
					m_ParameterInterpreter = new StateSingleton(e.Value, e.Start, e.End);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		void RequestSingleton.Visit(ServerSingleton e)
		{
			throw new NotSupportedException();
		}

		void RequestSingleton.Visit(WrapperSingleton e)
		{
			throw new NotSupportedException();
		}

		void RequestSingleton.Visit(TestsSingleton e)
		{
			throw new NotSupportedException();
		}

		void RequestSingleton.Visit(TaskSingleton e)
		{
			throw new NotSupportedException();
		}

		void RequestSingleton.Visit(BridgeSingleton e)
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
					m_ParameterInterpreter = new BridgeSingleton(VisitorAttribute._StubAttribute, e.Tag, e.Value, e.Style, e.IsPlainImplicit, e.IsQuotedImplicit, e.Start, e.End);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		void RequestSingleton.Visit(ExporterSingleton e)
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
					m_ParameterInterpreter = new ExporterSingleton(VisitorAttribute._StubAttribute, e.Tag, e.IsImplicit, e.Style, e.Start, e.End);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		void RequestSingleton.Visit(MessageSingleton e)
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
					m_ParameterInterpreter = new MessageSingleton(e.Start, e.End);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		void RequestSingleton.Visit(FacadeSingleton e)
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
					m_ParameterInterpreter = new FacadeSingleton(VisitorAttribute._StubAttribute, e.Tag, e.IsImplicit, e.Style, e.Start, e.End);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		void RequestSingleton.Visit(ParamSingleton e)
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
					m_ParameterInterpreter = new ParamSingleton(e.Start, e.End);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		void RequestSingleton.Visit(DecoratorSingleton e)
		{
			throw new NotSupportedException();
		}

		public BridgeInterpreter()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool RevertConsumer()
		{
			return MoveConsumer == null;
		}

		internal static BridgeInterpreter InvokeProducer()
		{
			return MoveConsumer;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public FacadeInterpreter m_TestInterpreter;

		public int _AttrInterpreter;

		public BridgeInterpreter m_MessageInterpreter;

		internal static _003C_003Ec__DisplayClass14_0 SelectProducer;

		public _003C_003Ec__DisplayClass14_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal bool _003CGetMappingEvents_003Eb__0(LinkedListNode<ClientSingleton> e)
		{
			return !m_TestInterpreter._EventInterpreter.IsDeleted(e);
		}

		internal bool _003CGetMappingEvents_003Eb__2(ClientSingleton e)
		{
			int num = 1;
			int num2 = num;
			int num3 = default(int);
			while (true)
			{
				switch (num2)
				{
				default:
					return num3 >= 0;
				case 1:
					num3 = (_AttrInterpreter += e.NestingIncrease);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		internal ClientSingleton _003CGetMappingEvents_003Eb__3(ClientSingleton e)
		{
			return m_MessageInterpreter.Clone(e);
		}

		internal static bool ChangeProducer()
		{
			return SelectProducer == null;
		}

		internal static _003C_003Ec__DisplayClass14_0 CreateProducer()
		{
			return SelectProducer;
		}
	}

	private readonly IteratorInterpreter _EventInterpreter;

	private readonly CandidateInterpreter m_InstanceInterpreter;

	private IEnumerator<LinkedListNode<ClientSingleton>> _OrderInterpreter;

	private bool containerInterpreter;

	private static FacadeInterpreter CustomizeConsumer;

	public ClientSingleton? Current
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
				{
					LinkedListNode<ClientSingleton> current = _OrderInterpreter.Current;
					if (current == null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
						{
							num2 = 0;
						}
						break;
					}
					return current.Value;
				}
				default:
					return null;
				}
			}
		}
	}

	public FacadeInterpreter(CandidateInterpreter innerParser)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				_EventInterpreter = new IteratorInterpreter();
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
				{
					num = 0;
				}
				break;
			default:
				containerInterpreter = false;
				num = 3;
				break;
			case 4:
				return;
			case 3:
				_OrderInterpreter = _EventInterpreter.GetEnumerator();
				num = 2;
				break;
			case 2:
				m_InstanceInterpreter = innerParser;
				num = 4;
				break;
			}
		}
	}

	public bool MoveNext()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 5:
				containerInterpreter = true;
				num2 = 6;
				break;
			case 2:
				_EventInterpreter.CleanMarked();
				num2 = 3;
				break;
			case 3:
				_OrderInterpreter = _EventInterpreter.GetEnumerator();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 == 0)
				{
					num2 = 5;
				}
				break;
			default:
				return _OrderInterpreter.MoveNext();
			case 4:
				Merge();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
				{
					num2 = 2;
				}
				break;
			case 1:
				if (containerInterpreter)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 4;
			}
		}
	}

	private void Merge()
	{
		int num = 4;
		int num2 = num;
		IEnumerator<LinkedListNode<ClientSingleton>> enumerator = default(IEnumerator<LinkedListNode<ClientSingleton>>);
		LinkedListNode<ClientSingleton> current = default(LinkedListNode<ClientSingleton>);
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 2:
			case 4:
				if (!m_InstanceInterpreter.MoveNext())
				{
					num2 = 5;
					break;
				}
				goto case 3;
			case 1:
				try
				{
					while (true)
					{
						IL_0101:
						int num3;
						if (!enumerator.MoveNext())
						{
							num3 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 != 0)
							{
								num3 = 0;
							}
							goto IL_0071;
						}
						goto IL_00c6;
						IL_00c6:
						current = enumerator.Current;
						num3 = 5;
						goto IL_0071;
						IL_0071:
						while (true)
						{
							switch (num3)
							{
							default:
								return;
							case 5:
								if (!IsMergeToken(current))
								{
									num3 = 6;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
									{
										num3 = 7;
									}
									continue;
								}
								goto case 8;
							case 4:
								break;
							case 1:
								throw new StructInterpreter(in start, current.Value.End, DicSingleton.gE3WbyDVW(-428683152 ^ -428715022));
							case 3:
							case 7:
								goto IL_0101;
							case 8:
							{
								_EventInterpreter.MarkDeleted(current);
								int num4 = 6;
								num3 = num4;
								continue;
							}
							case 2:
								start = current.Value.Start;
								num3 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
								{
									num3 = 1;
								}
								continue;
							case 6:
								if (HandleMerge(current.Next))
								{
									num3 = 1;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
									{
										num3 = 3;
									}
									continue;
								}
								goto case 2;
							case 0:
								return;
							}
							break;
						}
						goto IL_00c6;
					}
				}
				finally
				{
					if (enumerator != null)
					{
						int num5 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
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
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 == 0)
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
			case 3:
				_EventInterpreter.Add(m_InstanceInterpreter.Current);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
				{
					num2 = 2;
				}
				break;
			case 5:
				enumerator = _EventInterpreter.GetEnumerator();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	private bool HandleMerge(LinkedListNode<ClientSingleton>? node)
	{
		if (node == null)
		{
			return false;
		}
		if (node.Value is StateSingleton anchorAlias)
		{
			return HandleAnchorAlias(node, node, anchorAlias);
		}
		if (node.Value is ExporterSingleton)
		{
			return HandleSequence(node);
		}
		return false;
	}

	private bool HandleMergeSequence(LinkedListNode<ClientSingleton> sequenceStart, LinkedListNode<ClientSingleton>? node)
	{
		if (node == null)
		{
			return false;
		}
		if (node.Value is StateSingleton anchorAlias)
		{
			return HandleAnchorAlias(sequenceStart, node, anchorAlias);
		}
		if (node.Value is ExporterSingleton)
		{
			return HandleSequence(node);
		}
		return false;
	}

	private bool IsMergeToken(LinkedListNode<ClientSingleton> node)
	{
		if (node.Value is BridgeSingleton bridgeSingleton)
		{
			return bridgeSingleton.Value == DicSingleton.gE3WbyDVW(-1064640644 ^ -1064674114);
		}
		return false;
	}

	private bool HandleAnchorAlias(LinkedListNode<ClientSingleton> node, LinkedListNode<ClientSingleton> anchorNode, StateSingleton anchorAlias)
	{
		IEnumerable<ClientSingleton> mappingEvents = GetMappingEvents(anchorAlias.Value);
		_EventInterpreter.AddAfter(node, mappingEvents);
		_EventInterpreter.MarkDeleted(anchorNode);
		return true;
	}

	private bool HandleSequence(LinkedListNode<ClientSingleton> node)
	{
		_EventInterpreter.MarkDeleted(node);
		LinkedListNode<ClientSingleton> linkedListNode = node;
		while (linkedListNode != null)
		{
			if (linkedListNode.Value is MessageSingleton)
			{
				_EventInterpreter.MarkDeleted(linkedListNode);
				return true;
			}
			LinkedListNode<ClientSingleton> next = linkedListNode.Next;
			HandleMergeSequence(node, next);
			linkedListNode = next;
		}
		return true;
	}

	private IEnumerable<ClientSingleton> GetMappingEvents(VisitorAttribute anchor)
	{
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals6.m_TestInterpreter = this;
		CS_0024_003C_003E8__locals6.m_MessageInterpreter = new BridgeInterpreter();
		CS_0024_003C_003E8__locals6._AttrInterpreter = 0;
		return from e in (from e in _EventInterpreter.FromAnchor(anchor)
				where !CS_0024_003C_003E8__locals6.m_TestInterpreter._EventInterpreter.IsDeleted(e)
				select e.Value).TakeWhile(delegate(ClientSingleton e)
			{
				int num = 1;
				int num2 = num;
				int num3 = default(int);
				while (true)
				{
					switch (num2)
					{
					default:
						return num3 >= 0;
					case 1:
						num3 = (CS_0024_003C_003E8__locals6._AttrInterpreter += e.NestingIncrease);
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 != 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			})
			select CS_0024_003C_003E8__locals6.m_MessageInterpreter.Clone(e);
	}

	internal static bool CancelConsumer()
	{
		return CustomizeConsumer == null;
	}

	internal static FacadeInterpreter ReflectConsumer()
	{
		return CustomizeConsumer;
	}
}
