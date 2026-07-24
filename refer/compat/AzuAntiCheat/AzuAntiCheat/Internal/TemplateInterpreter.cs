using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class TemplateInterpreter<T> : IEnumerable<T>, IEnumerable
{
	[CompilerGenerated]
	private sealed class _003CGetEnumerator_003Ed__16 : IEnumerator<T>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		public TemplateInterpreter<T> _003C_003E4__this;

		private int _003Cptr_003E5__2;

		private int _003Ci_003E5__3;

		private static object FillConsumer;

		T IEnumerator<T>.Current
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
		public _003CGetEnumerator_003Ed__16(int _003C_003E1__state)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
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
				this._003C_003E1__state = _003C_003E1__state;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
				{
					num = 1;
				}
			}
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = 2;
			int num4 = default(int);
			TemplateInterpreter<T> templateInterpreter = default(TemplateInterpreter<T>);
			int num3 = default(int);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					case 10:
						if (num4 == 0)
						{
							goto end_IL_0012;
						}
						num2 = 15;
						break;
					case 8:
						_003C_003E2__current = templateInterpreter.m_PredicateInterpreter[_003Cptr_003E5__2];
						num2 = 6;
						break;
					case 11:
						num3 = _003Ci_003E5__3;
						num2 = 7;
						break;
					case 5:
						_003Ci_003E5__3 = 0;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
						{
							num2 = 0;
						}
						break;
					case 2:
						num4 = _003C_003E1__state;
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
						{
							num2 = 1;
						}
						break;
					case 1:
						templateInterpreter = _003C_003E4__this;
						num2 = 10;
						break;
					case 15:
						if (num4 != 1)
						{
							num2 = 14;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
							{
								num2 = 8;
							}
							break;
						}
						_003C_003E1__state = -1;
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 != 0)
						{
							num2 = 0;
						}
						break;
					default:
						if (_003Ci_003E5__3 >= templateInterpreter.Count)
						{
							num2 = 12;
							break;
						}
						goto case 8;
					case 12:
						return false;
					case 13:
						return true;
					case 3:
						_003Cptr_003E5__2 = (_003Cptr_003E5__2 - 1) & templateInterpreter.systemInterpreter;
						num2 = 11;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
						{
							num2 = 11;
						}
						break;
					case 6:
						_003C_003E1__state = 1;
						num2 = 13;
						break;
					case 7:
						_003Ci_003E5__3 = num3 + 1;
						num2 = 9;
						break;
					case 14:
						return false;
					case 4:
						_003Cptr_003E5__2 = templateInterpreter._WatcherInterpreter;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
						{
							num2 = 5;
						}
						break;
					}
					continue;
					end_IL_0012:
					break;
				}
				_003C_003E1__state = -1;
				num = 4;
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

		internal static bool FlushConsumer()
		{
			return FillConsumer == null;
		}

		internal static object DestroyConsumer()
		{
			return FillConsumer;
		}
	}

	private T[] m_PredicateInterpreter;

	private int _WatcherInterpreter;

	private int customerInterpreter;

	private int systemInterpreter;

	private int m_ResolverInterpreter;

	internal static object ExcludeConsumer;

	public int Count => m_ResolverInterpreter;

	public int Capacity => m_PredicateInterpreter.Length;

	public TemplateInterpreter(int initialCapacity = 128)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 8;
		while (true)
		{
			switch (num)
			{
			case 8:
				if (initialCapacity > 0)
				{
					num = 7;
					break;
				}
				goto default;
			default:
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(0x270E0638 ^ 0x270E78F4), DicSingleton.gE3WbyDVW(-948533799 ^ -948503753));
			case 7:
				if (WrapperAttribute.IsPowerOfTwo(initialCapacity))
				{
					num = 5;
					break;
				}
				goto case 1;
			case 2:
				customerInterpreter = initialCapacity / 2;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 != 0)
				{
					num = 4;
				}
				break;
			case 3:
				return;
			case 6:
				_WatcherInterpreter = initialCapacity / 2;
				num = 2;
				break;
			case 4:
				systemInterpreter = initialCapacity - 1;
				num = 3;
				break;
			case 1:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(0x120E76C ^ 0x120983C), DicSingleton.gE3WbyDVW(-359091888 ^ -359084132));
			case 5:
				m_PredicateInterpreter = new T[initialCapacity];
				num = 6;
				break;
			}
		}
	}

	public void Enqueue(T item)
	{
		ResizeIfNeeded();
		m_PredicateInterpreter[customerInterpreter] = item;
		customerInterpreter = (customerInterpreter - 1) & systemInterpreter;
		m_ResolverInterpreter++;
	}

	public T Dequeue()
	{
		if (m_ResolverInterpreter == 0)
		{
			throw new InvalidOperationException(DicSingleton.gE3WbyDVW(0x2BC349D6 ^ 0x2BC3367E));
		}
		T result = m_PredicateInterpreter[_WatcherInterpreter];
		_WatcherInterpreter = (_WatcherInterpreter - 1) & systemInterpreter;
		m_ResolverInterpreter--;
		return result;
	}

	public void Insert(int index, T item)
	{
		if (index > m_ResolverInterpreter)
		{
			throw new InvalidOperationException(DicSingleton.gE3WbyDVW(0x408F2744 ^ 0x408F5894));
		}
		ResizeIfNeeded();
		CalculateInsertionParameters(systemInterpreter, m_ResolverInterpreter, index, ref _WatcherInterpreter, ref customerInterpreter, out var insertPtr, out var copyIndex, out var copyOffset, out var copyLength);
		if (copyLength != 0)
		{
			Array.Copy(m_PredicateInterpreter, copyIndex, m_PredicateInterpreter, copyIndex + copyOffset, copyLength);
		}
		m_PredicateInterpreter[insertPtr] = item;
		m_ResolverInterpreter++;
	}

	private void ResizeIfNeeded()
	{
		int num = 1;
		int num4 = default(int);
		T[] array = default(T[]);
		int num3 = default(int);
		int num5 = default(int);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 4:
				case 12:
					customerInterpreter += num4;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
					{
						num2 = 2;
					}
					break;
				case 9:
					Array.Copy(m_PredicateInterpreter, 0, array, 0, num3);
					num2 = 12;
					break;
				case 1:
					num4 = m_PredicateInterpreter.Length;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
					{
						num2 = 0;
					}
					break;
				case 5:
				case 7:
					m_PredicateInterpreter = array;
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb == 0)
					{
						num2 = 12;
					}
					break;
				default:
					if (m_ResolverInterpreter != num4)
					{
						return;
					}
					goto end_IL_0012;
				case 3:
					array = new T[num4 * 2];
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec != 0)
					{
						num2 = 13;
					}
					break;
				case 13:
					num3 = _WatcherInterpreter + 1;
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
					{
						num2 = 11;
					}
					break;
				case 6:
					return;
				case 14:
					systemInterpreter = systemInterpreter * 2 + 1;
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 != 0)
					{
						num2 = 1;
					}
					break;
				case 10:
					Array.Copy(m_PredicateInterpreter, _WatcherInterpreter + 1, array, customerInterpreter + 1, num5);
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
					{
						num2 = 7;
					}
					break;
				case 8:
					if (num5 <= 0)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
						{
							num2 = 5;
						}
						break;
					}
					goto case 10;
				case 2:
					num5 = num4 - num3;
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
					{
						num2 = 7;
					}
					break;
				case 11:
					if (num3 <= 0)
					{
						num2 = 4;
						break;
					}
					goto case 9;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 3;
		}
	}

	internal static void CalculateInsertionParameters(int mask, int count, int index, ref int readPtr, ref int writePtr, out int insertPtr, out int copyIndex, out int copyOffset, out int copyLength)
	{
		int num = 27;
		int num6 = default(int);
		int num7 = default(int);
		int num5 = default(int);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				int num3;
				int num4;
				switch (num2)
				{
				case 18:
					copyOffset = -1;
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
					{
						num2 = 16;
					}
					continue;
				case 21:
					writePtr = (writePtr - 1) & mask;
					num2 = 14;
					continue;
				case 9:
					if (writePtr <= insertPtr)
					{
						num = 17;
						break;
					}
					goto case 11;
				case 3:
					copyOffset = 0;
					num2 = 19;
					continue;
				case 24:
					if (num6 <= num7)
					{
						num2 = 12;
						continue;
					}
					copyIndex = writePtr + 1;
					num2 = 18;
					continue;
				case 10:
					if (index == count)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
						{
							num2 = 4;
						}
						continue;
					}
					if (num5 >= insertPtr)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 6;
				case 7:
					return;
				case 23:
					insertPtr = (readPtr - index) & mask;
					num = 10;
					break;
				case 14:
					return;
				case 11:
					num3 = int.MaxValue;
					goto IL_0350;
				case 25:
					copyOffset = 0;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db == 0)
					{
						num2 = 2;
					}
					continue;
				case 4:
					writePtr = (writePtr - 1) & mask;
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
					{
						num2 = 8;
					}
					continue;
				case 16:
					copyLength = num7;
					num = 21;
					break;
				case 12:
					insertPtr++;
					num2 = 2;
					continue;
				case 29:
					return;
				case 15:
					return;
				case 8:
					copyIndex = 0;
					num2 = 3;
					continue;
				case 22:
					copyIndex = insertPtr;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 == 0)
					{
						num2 = 0;
					}
					continue;
				case 26:
					if (index != 0)
					{
						num2 = 23;
						continue;
					}
					goto case 20;
				case 2:
					readPtr++;
					num2 = 22;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
					{
						num2 = 14;
					}
					continue;
				case 6:
					num4 = int.MaxValue;
					goto IL_0339;
				case 28:
					copyLength = num6;
					num2 = 29;
					continue;
				default:
					copyOffset = 1;
					num2 = 13;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
					{
						num2 = 28;
					}
					continue;
				case 5:
					copyLength = 0;
					num2 = 7;
					continue;
				case 27:
					num5 = (readPtr + 1) & mask;
					num2 = 26;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
					{
						num2 = 21;
					}
					continue;
				case 19:
					copyLength = 0;
					num2 = 13;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
					{
						num2 = 15;
					}
					continue;
				case 20:
					insertPtr = (readPtr = num5);
					num2 = 13;
					continue;
				case 13:
					copyIndex = 0;
					num = 25;
					break;
				case 1:
					num4 = readPtr - insertPtr;
					goto IL_0339;
				case 17:
					{
						num3 = insertPtr - writePtr;
						goto IL_0350;
					}
					IL_0339:
					num6 = num4;
					num = 9;
					break;
					IL_0350:
					num7 = num3;
					num2 = 24;
					continue;
				}
				break;
			}
		}
	}

	[IteratorStateMachine(typeof(TemplateInterpreter<>._003CGetEnumerator_003Ed__16))]
	public IEnumerator<T> GetEnumerator()
	{
		//yield-return decompiler failed: Missing enumeratorCtor.Body
		return new _003CGetEnumerator_003Ed__16(0)
		{
			_003C_003E4__this = this
		};
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	internal static bool InterruptConsumer()
	{
		return ExcludeConsumer == null;
	}

	internal static object DeleteConsumer()
	{
		return ExcludeConsumer;
	}
}
