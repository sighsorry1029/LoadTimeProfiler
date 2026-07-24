using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class TemplateFilter : WorkerPrototype
{
	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	private sealed class PredicateFilter : IList, ICollection, IEnumerable
	{
		[CompilerGenerated]
		private sealed class _003CGetEnumerator_003Ed__25 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
			private object _003C_003E2__current;

			[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
			public PredicateFilter _003C_003E4__this;

			private int _003Ci_003E5__2;

			internal static _003CGetEnumerator_003Ed__25 EnableInstance;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
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
			public _003CGetEnumerator_003Ed__25(int _003C_003E1__state)
			{
				GetterIssuer.DeleteInitializer();
				base._002Ector();
				int num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
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
						this._003C_003E1__state = _003C_003E1__state;
						num = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c != 0)
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
			}

			private bool MoveNext()
			{
				int num = 1;
				PredicateFilter predicateFilter = default(PredicateFilter);
				int num3 = default(int);
				int num4 = default(int);
				while (true)
				{
					int num2 = num;
					while (true)
					{
						switch (num2)
						{
						case 13:
							_003C_003E1__state = 1;
							num2 = 7;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
							{
								num2 = 3;
							}
							continue;
						case 5:
							_003C_003E2__current = predicateFilter._WatcherFilter[_003Ci_003E5__2];
							num2 = 13;
							continue;
						case 12:
							_003Ci_003E5__2 = 0;
							num2 = 5;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
							{
								num2 = 9;
							}
							continue;
						case 2:
							break;
						case 3:
							if (num3 != 1)
							{
								num2 = 6;
								continue;
							}
							_003C_003E1__state = -1;
							num2 = 2;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
							{
								num2 = 2;
							}
							continue;
						case 11:
							return false;
						default:
							predicateFilter = _003C_003E4__this;
							num2 = 8;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
							{
								num2 = 2;
							}
							continue;
						case 7:
							return true;
						case 6:
							return false;
						case 1:
							num3 = _003C_003E1__state;
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
							{
								num2 = 0;
							}
							continue;
						case 10:
							_003Ci_003E5__2 = num4;
							num2 = 2;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
							{
								num2 = 4;
							}
							continue;
						case 8:
							if (num3 == 0)
							{
								_003C_003E1__state = -1;
								num2 = 12;
							}
							else
							{
								num2 = 3;
							}
							continue;
						case 4:
						case 9:
							if (_003Ci_003E5__2 >= predicateFilter.Count)
							{
								num2 = 11;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
								{
									num2 = 10;
								}
								continue;
							}
							goto case 5;
						}
						break;
					}
					num4 = _003Ci_003E5__2 + 1;
					num = 10;
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

			internal static bool SortInstance()
			{
				return EnableInstance == null;
			}

			internal static _003CGetEnumerator_003Ed__25 InsertInstance()
			{
				return EnableInstance;
			}
		}

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 2 })]
		private object[] _WatcherFilter;

		[CompilerGenerated]
		private int m_CustomerFilter;

		internal static PredicateFilter SetInstance;

		public bool IsFixedSize => false;

		public bool IsReadOnly => false;

		public object this[int index]
		{
			get
			{
				return _WatcherFilter[index];
			}
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
						_WatcherFilter[index] = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			}
		}

		public int Count
		{
			[CompilerGenerated]
			get
			{
				return m_CustomerFilter;
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
						m_CustomerFilter = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			}
		}

		public bool IsSynchronized => false;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)]
		public object SyncRoot
		{
			[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
			get
			{
				return _WatcherFilter;
			}
		}

		public PredicateFilter()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 != 0)
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
				Clear();
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
				{
					num = 1;
				}
			}
		}

		public int Add(object value)
		{
			int num = 4;
			int num2 = num;
			int count = default(int);
			while (true)
			{
				switch (num2)
				{
				case 5:
					count = Count;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb != 0)
					{
						num2 = 0;
					}
					break;
				case 2:
					return count;
				case 1:
					_WatcherFilter[Count] = value;
					num2 = 5;
					break;
				default:
					Count = count + 1;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 != 0)
					{
						num2 = 2;
					}
					break;
				case 4:
					if (Count == _WatcherFilter.Length)
					{
						num2 = 3;
						break;
					}
					goto case 1;
				case 3:
					Array.Resize(ref _WatcherFilter, _WatcherFilter.Length * 2);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
					{
						num2 = 1;
					}
					break;
				}
			}
		}

		public void Clear()
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					_WatcherFilter = new object[10];
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 != 0)
					{
						num2 = 0;
					}
					break;
				default:
					Count = 0;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
					{
						num2 = 2;
					}
					break;
				case 2:
					return;
				}
			}
		}

		bool IList.Contains(object value)
		{
			throw new NotSupportedException();
		}

		int IList.IndexOf(object value)
		{
			throw new NotSupportedException();
		}

		void IList.Insert(int index, object value)
		{
			throw new NotSupportedException();
		}

		void IList.Remove(object value)
		{
			throw new NotSupportedException();
		}

		void IList.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
		public void CopyTo(Array array, int index)
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
					Array.Copy(_WatcherFilter, 0, array, index, Count);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
		[IteratorStateMachine(typeof(_003CGetEnumerator_003Ed__25))]
		public IEnumerator GetEnumerator()
		{
			//yield-return decompiler failed: Missing enumeratorCtor.Body
			return new _003CGetEnumerator_003Ed__25(0)
			{
				_003C_003E4__this = this
			};
		}

		internal static bool PushInstance()
		{
			return SetInstance == null;
		}

		internal static PredicateFilter ValidateInstance()
		{
			return SetInstance;
		}
	}

	internal static TemplateFilter CalcInstance;

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	bool WorkerPrototype.Deserialize(StubReader parser, Type expectedType, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 1, 1, 2 })] Func<StubReader, Type, object> nestedObjectDeserializer, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] out object value)
	{
		if (!expectedType.IsArray)
		{
			value = false;
			return false;
		}
		Type elementType = expectedType.GetElementType();
		PredicateFilter predicateFilter = new PredicateFilter();
		SystemFilter.DeserializeHelper(elementType, parser, nestedObjectDeserializer, predicateFilter, canUpdate: true);
		Array array = Array.CreateInstance(elementType, predicateFilter.Count);
		predicateFilter.CopyTo(array, 0);
		value = array;
		return true;
	}

	public TemplateFilter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool LogoutInstance()
	{
		return CalcInstance == null;
	}

	internal static TemplateFilter CountInstance()
	{
		return CalcInstance;
	}
}
