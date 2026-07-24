using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class ThreadReader : StubReader
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	private sealed class ObjectReader : IEnumerable<LinkedListNode<MappingFactory>>, IEnumerable
	{
		[CompilerGenerated]
		private sealed class _003CEnumerate_003Ed__11 : IEnumerable<LinkedListNode<MappingFactory>>, IEnumerable, IEnumerator<LinkedListNode<MappingFactory>>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private LinkedListNode<MappingFactory> _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1 })]
			private LinkedListNode<MappingFactory> node;

			[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1 })]
			public LinkedListNode<MappingFactory> _003C_003E3__node;

			internal static _003CEnumerate_003Ed__11 PrepareError;

			LinkedListNode<MappingFactory> IEnumerator<LinkedListNode<MappingFactory>>.Current
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
			public _003CEnumerate_003Ed__11(int _003C_003E1__state)
			{
				GetterIssuer.DeleteInitializer();
				base._002Ector();
				int num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 == 0)
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
					case 2:
						_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
						num = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
						{
							num = 0;
						}
						break;
					case 1:
						this._003C_003E1__state = _003C_003E1__state;
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
				int num = 8;
				int num2 = num;
				int num3 = default(int);
				while (true)
				{
					switch (num2)
					{
					case 10:
						return false;
					case 8:
						num3 = _003C_003E1__state;
						num2 = 7;
						continue;
					case 7:
						if (num3 == 0)
						{
							num2 = 3;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 != 0)
							{
								num2 = 1;
							}
							continue;
						}
						goto case 6;
					case 4:
						node = node.Next;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
						{
							num2 = 1;
						}
						continue;
					case 11:
						_003C_003E1__state = 1;
						num2 = 5;
						continue;
					case 5:
						return true;
					case 2:
						return false;
					case 3:
						_003C_003E1__state = -1;
						num2 = 9;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
						{
							num2 = 7;
						}
						continue;
					case 6:
						if (num3 == 1)
						{
							_003C_003E1__state = -1;
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 != 0)
							{
								num2 = 4;
							}
						}
						else
						{
							num2 = 2;
						}
						continue;
					case 1:
					case 9:
						if (node == null)
						{
							num2 = 10;
							continue;
						}
						break;
					}
					_003C_003E2__current = node;
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
					{
						num2 = 4;
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
			[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 0, 1 })]
			IEnumerator<LinkedListNode<MappingFactory>> IEnumerable<LinkedListNode<MappingFactory>>.GetEnumerator()
			{
				_003CEnumerate_003Ed__11 _003CEnumerate_003Ed__;
				if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
				{
					_003C_003E1__state = 0;
					_003CEnumerate_003Ed__ = this;
				}
				else
				{
					_003CEnumerate_003Ed__ = new _003CEnumerate_003Ed__11(0);
				}
				_003CEnumerate_003Ed__.node = _003C_003E3__node;
				return _003CEnumerate_003Ed__;
			}

			[DebuggerHidden]
			[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<LinkedListNode<MappingFactory>>)this).GetEnumerator();
			}

			internal static bool WriteError()
			{
				return PrepareError == null;
			}

			internal static _003CEnumerate_003Ed__11 PrintError()
			{
				return PrepareError;
			}
		}

		private readonly LinkedList<MappingFactory> _ConsumerReader;

		private readonly HashSet<LinkedListNode<MappingFactory>> m_PropertyReader;

		private readonly Dictionary<HelperReader, LinkedListNode<MappingFactory>> configurationReader;

		private static ObjectReader MapError;

		public ObjectReader()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 3;
			while (true)
			{
				switch (num)
				{
				case 2:
					return;
				default:
					m_PropertyReader = new HashSet<LinkedListNode<MappingFactory>>();
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e != 0)
					{
						num = 1;
					}
					break;
				case 1:
					configurationReader = new Dictionary<HelperReader, LinkedListNode<MappingFactory>>();
					num = 2;
					break;
				case 3:
					_ConsumerReader = new LinkedList<MappingFactory>();
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
					{
						num = 0;
					}
					break;
				}
			}
		}

		public void AddAfter(LinkedListNode<MappingFactory> node, IEnumerable<MappingFactory> items)
		{
			foreach (MappingFactory item in items)
			{
				node = _ConsumerReader.AddAfter(node, item);
			}
		}

		public void Add(MappingFactory item)
		{
			int num = 2;
			int num2 = num;
			LinkedListNode<MappingFactory> node = default(LinkedListNode<MappingFactory>);
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 0:
					return;
				case 1:
					AddReference(item, node);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db != 0)
					{
						num2 = 0;
					}
					break;
				case 2:
					node = _ConsumerReader.AddLast(item);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 != 0)
					{
						num2 = 1;
					}
					break;
				}
			}
		}

		public void MarkDeleted(LinkedListNode<MappingFactory> node)
		{
			m_PropertyReader.Add(node);
		}

		public void CleanMarked()
		{
			foreach (LinkedListNode<MappingFactory> item in m_PropertyReader)
			{
				_ConsumerReader.Remove(item);
			}
		}

		public IEnumerable<LinkedListNode<MappingFactory>> FromAnchor(HelperReader anchor)
		{
			LinkedListNode<MappingFactory> next = configurationReader[anchor].Next;
			return Enumerate(next);
		}

		public IEnumerator<LinkedListNode<MappingFactory>> GetEnumerator()
		{
			return Enumerate(_ConsumerReader.First).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		[IteratorStateMachine(typeof(_003CEnumerate_003Ed__11))]
		private IEnumerable<LinkedListNode<MappingFactory>> Enumerate([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 2, 1 })] LinkedListNode<MappingFactory> node)
		{
			//yield-return decompiler failed: Missing enumeratorCtor.Body
			return new _003CEnumerate_003Ed__11(-2)
			{
				_003C_003E3__node = node
			};
		}

		private void AddReference(MappingFactory item, LinkedListNode<MappingFactory> node)
		{
			if (item is QueueFactory { Anchor: { IsEmpty: false } anchor })
			{
				configurationReader[anchor] = node;
			}
		}

		internal static bool NewError()
		{
			return MapError == null;
		}

		internal static ObjectReader AddError()
		{
			return MapError;
		}
	}

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	private sealed class SpecificationReader : DispatcherFactory
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
		private MappingFactory _RefReader;

		internal static SpecificationReader CompareError;

		public MappingFactory Clone(MappingFactory e)
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					if (_RefReader != null)
					{
						num2 = 3;
						break;
					}
					goto case 2;
				case 1:
					e.Accept(this);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 != 0)
					{
						num2 = 0;
					}
					break;
				case 2:
					throw new InvalidOperationException(string.Format(DicSingleton.gE3WbyDVW(-428135557 ^ -428103503), e.Type));
				case 3:
					return _RefReader;
				}
			}
		}

		void DispatcherFactory.Visit(TagFactory e)
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
					_RefReader = new TagFactory(e.Value, e.Start, e.End);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		void DispatcherFactory.Visit(PublisherSetter e)
		{
			throw new NotSupportedException();
		}

		void DispatcherFactory.Visit(RoleSetter e)
		{
			throw new NotSupportedException();
		}

		void DispatcherFactory.Visit(DicFactory e)
		{
			throw new NotSupportedException();
		}

		void DispatcherFactory.Visit(ProcessorFactory e)
		{
			throw new NotSupportedException();
		}

		void DispatcherFactory.Visit(ClassFactory e)
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
					_RefReader = new ClassFactory(HelperReader._ExceptionReader, e.Tag, e.Value, e.Style, e.IsPlainImplicit, e.IsQuotedImplicit, e.Start, e.End);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 != 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		void DispatcherFactory.Visit(RefFactory e)
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
					_RefReader = new RefFactory(HelperReader._ExceptionReader, e.Tag, e.IsImplicit, e.Style, e.Start, e.End);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		void DispatcherFactory.Visit(SpecificationFactory e)
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
					_RefReader = new SpecificationFactory(e.Start, e.End);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		void DispatcherFactory.Visit(QueueFactory e)
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
					_RefReader = new QueueFactory(HelperReader._ExceptionReader, e.Tag, e.IsImplicit, e.Style, e.Start, e.End);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		void DispatcherFactory.Visit(ListFactory e)
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
					_RefReader = new ListFactory(e.Start, e.End);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		void DispatcherFactory.Visit(StubFactory e)
		{
			throw new NotSupportedException();
		}

		public SpecificationReader()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool CloneError()
		{
			return CompareError == null;
		}

		internal static SpecificationReader ReadError()
		{
			return CompareError;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public int m_ObserverReader;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public SpecificationReader _AdapterReader;

		internal static _003C_003Ec__DisplayClass14_0 ViewError;

		public _003C_003Ec__DisplayClass14_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)]
		internal bool _003CGetMappingEvents_003Eb__1(MappingFactory e)
		{
			int num = 1;
			int num2 = num;
			int num3 = default(int);
			while (true)
			{
				switch (num2)
				{
				case 1:
					num3 = (m_ObserverReader += e.NestingIncrease);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
					{
						num2 = 0;
					}
					break;
				default:
					return num3 >= 0;
				}
			}
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)]
		internal MappingFactory _003CGetMappingEvents_003Eb__2(MappingFactory e)
		{
			return _AdapterReader.Clone(e);
		}

		internal static bool InitError()
		{
			return ViewError == null;
		}

		internal static _003C_003Ec__DisplayClass14_0 PatchError()
		{
			return ViewError;
		}
	}

	private readonly ObjectReader m_MappingReader;

	private readonly StubReader _SchemaReader;

	private IEnumerator<LinkedListNode<MappingFactory>> m_StructReader;

	private bool _ClassReader;

	private static ThreadReader PostError;

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public MappingFactory Current
	{
		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
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
					LinkedListNode<MappingFactory> current = m_StructReader.Current;
					if (current == null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 != 0)
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

	public ThreadReader(StubReader innerParser)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			case 4:
				return;
			case 3:
				_ClassReader = false;
				num = 2;
				break;
			default:
				_SchemaReader = innerParser;
				num = 4;
				break;
			case 2:
				m_StructReader = m_MappingReader.GetEnumerator();
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 != 0)
				{
					num = 0;
				}
				break;
			case 1:
				m_MappingReader = new ObjectReader();
				num = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 != 0)
				{
					num = 3;
				}
				break;
			}
		}
	}

	public bool MoveNext()
	{
		int num = 5;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 4:
				Merge();
				num2 = 3;
				break;
			default:
				m_StructReader = m_MappingReader.GetEnumerator();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 != 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				return m_StructReader.MoveNext();
			case 5:
				if (!_ClassReader)
				{
					num2 = 4;
					break;
				}
				goto case 1;
			case 3:
				m_MappingReader.CleanMarked();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				_ClassReader = true;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	private void Merge()
	{
		while (_SchemaReader.MoveNext())
		{
			m_MappingReader.Add(_SchemaReader.Current);
		}
		foreach (LinkedListNode<MappingFactory> item in m_MappingReader)
		{
			if (IsMergeToken(item))
			{
				m_MappingReader.MarkDeleted(item);
				if (!HandleMerge(item.Next))
				{
					throw new TemplateFactory(item.Value.Start, item.Value.End, DicSingleton.gE3WbyDVW(-736996892 ^ -736963994));
				}
			}
		}
	}

	private bool HandleMerge([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 2, 1 })] LinkedListNode<MappingFactory> node)
	{
		if (node == null)
		{
			return false;
		}
		if (node.Value is TagFactory anchorAlias)
		{
			return HandleAnchorAlias(node, node, anchorAlias);
		}
		if (node.Value is RefFactory)
		{
			return HandleSequence(node);
		}
		return false;
	}

	private bool HandleMergeSequence(LinkedListNode<MappingFactory> sequenceStart, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 2, 1 })] LinkedListNode<MappingFactory> node)
	{
		if (node == null)
		{
			return false;
		}
		if (node.Value is TagFactory anchorAlias)
		{
			return HandleAnchorAlias(sequenceStart, node, anchorAlias);
		}
		if (node.Value is RefFactory)
		{
			return HandleSequence(node);
		}
		return false;
	}

	private bool IsMergeToken(LinkedListNode<MappingFactory> node)
	{
		if (node.Value is ClassFactory classFactory)
		{
			return classFactory.Value == DicSingleton.gE3WbyDVW(-490894496 ^ -490927966);
		}
		return false;
	}

	private bool HandleAnchorAlias(LinkedListNode<MappingFactory> node, LinkedListNode<MappingFactory> anchorNode, TagFactory anchorAlias)
	{
		IEnumerable<MappingFactory> mappingEvents = GetMappingEvents(anchorAlias.Value);
		m_MappingReader.AddAfter(node, mappingEvents);
		m_MappingReader.MarkDeleted(anchorNode);
		return true;
	}

	private bool HandleSequence(LinkedListNode<MappingFactory> node)
	{
		m_MappingReader.MarkDeleted(node);
		LinkedListNode<MappingFactory> linkedListNode = node;
		while (linkedListNode != null)
		{
			if (linkedListNode.Value is SpecificationFactory)
			{
				m_MappingReader.MarkDeleted(linkedListNode);
				return true;
			}
			LinkedListNode<MappingFactory> next = linkedListNode.Next;
			HandleMergeSequence(node, next);
			linkedListNode = next;
		}
		return true;
	}

	private IEnumerable<MappingFactory> GetMappingEvents(HelperReader anchor)
	{
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals4._AdapterReader = new SpecificationReader();
		CS_0024_003C_003E8__locals4.m_ObserverReader = 0;
		return from e in (from e in m_MappingReader.FromAnchor(anchor)
				select e.Value).TakeWhile([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (MappingFactory e) =>
			{
				int num = 1;
				int num2 = num;
				int num3 = default(int);
				while (true)
				{
					switch (num2)
					{
					case 1:
						num3 = (CS_0024_003C_003E8__locals4.m_ObserverReader += e.NestingIncrease);
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
						{
							num2 = 0;
						}
						break;
					default:
						return num3 >= 0;
					}
				}
			})
			select CS_0024_003C_003E8__locals4._AdapterReader.Clone(e);
	}

	internal static bool CallError()
	{
		return PostError == null;
	}

	internal static ThreadReader ConcatError()
	{
		return PostError;
	}
}
