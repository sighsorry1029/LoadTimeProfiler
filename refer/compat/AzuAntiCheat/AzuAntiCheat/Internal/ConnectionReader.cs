using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class ConnectionReader<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] T> : IEnumerable<T>, IEnumerable
{
	[CompilerGenerated]
	private sealed class _003CGetEnumerator_003Ed__16 : IEnumerator<T>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public ConnectionReader<T> _003C_003E4__this;

		private int _003Cptr_003E5__2;

		private int _003Ci_003E5__3;

		private static object ManageService;

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
			[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
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
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
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
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 == 0)
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
			int num = 9;
			ConnectionReader<T> connectionReader = default(ConnectionReader<T>);
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					default:
						_003Cptr_003E5__2 = (_003Cptr_003E5__2 - 1) & connectionReader.m_TagReader;
						num2 = 15;
						continue;
					case 8:
						connectionReader = _003C_003E4__this;
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
						{
							num2 = 1;
						}
						continue;
					case 16:
						_003Ci_003E5__3 = 0;
						num2 = 3;
						continue;
					case 12:
						return false;
					case 15:
						num4 = _003Ci_003E5__3;
						num2 = 13;
						continue;
					case 4:
						return true;
					case 5:
						_003C_003E1__state = 1;
						num2 = 4;
						continue;
					case 1:
						if (num3 == 0)
						{
							num2 = 11;
							continue;
						}
						goto case 10;
					case 7:
						_003C_003E2__current = connectionReader.annotationReader[_003Cptr_003E5__2];
						num2 = 5;
						continue;
					case 13:
						_003Ci_003E5__3 = num4 + 1;
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
						{
							num2 = 6;
						}
						continue;
					case 14:
						_003Cptr_003E5__2 = connectionReader.m_ProcessReader;
						num2 = 16;
						continue;
					case 2:
						return false;
					case 11:
						_003C_003E1__state = -1;
						num = 14;
						break;
					case 9:
						num3 = _003C_003E1__state;
						num2 = 8;
						continue;
					case 3:
					case 6:
						if (_003Ci_003E5__3 >= connectionReader.Count)
						{
							num2 = 12;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 == 0)
							{
								num2 = 8;
							}
							continue;
						}
						goto case 7;
					case 10:
						if (num3 == 1)
						{
							_003C_003E1__state = -1;
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 == 0)
							{
								num2 = 0;
							}
							continue;
						}
						num = 2;
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

		internal static bool ForgotService()
		{
			return ManageService == null;
		}

		internal static object RestartService()
		{
			return ManageService;
		}
	}

	private T[] annotationReader;

	private int m_ProcessReader;

	private int m_RepositoryReader;

	private int m_TagReader;

	private int visitorReader;

	internal static object CancelService;

	public int Count => visitorReader;

	public int Capacity => annotationReader.Length;

	public ConnectionReader(int initialCapacity = 128)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 3:
				m_TagReader = initialCapacity - 1;
				num = 6;
				break;
			case 6:
				return;
			default:
				m_ProcessReader = initialCapacity / 2;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
				{
					num = 5;
				}
				break;
			case 2:
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(0x38262FC9 ^ 0x38265105), DicSingleton.gE3WbyDVW(0x69B67B3A ^ 0x69B605D4));
			case 5:
				m_RepositoryReader = initialCapacity / 2;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 == 0)
				{
					num = 3;
				}
				break;
			case 1:
				if (initialCapacity > 0)
				{
					if (SingletonReader.IsPowerOfTwo(initialCapacity))
					{
						num = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
						{
							num = 3;
						}
						break;
					}
					goto case 4;
				}
				num = 2;
				break;
			case 4:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(-1741204886 ^ -1741214406), DicSingleton.gE3WbyDVW(-1549341817 ^ -1549363893));
			case 7:
				annotationReader = new T[initialCapacity];
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public void Enqueue(T item)
	{
		ResizeIfNeeded();
		annotationReader[m_RepositoryReader] = item;
		m_RepositoryReader = (m_RepositoryReader - 1) & m_TagReader;
		visitorReader++;
	}

	public T Dequeue()
	{
		if (visitorReader == 0)
		{
			throw new InvalidOperationException(DicSingleton.gE3WbyDVW(-1773869960 ^ -1773888560));
		}
		T result = annotationReader[m_ProcessReader];
		m_ProcessReader = (m_ProcessReader - 1) & m_TagReader;
		visitorReader--;
		return result;
	}

	public void Insert(int index, T item)
	{
		if (index > visitorReader)
		{
			throw new InvalidOperationException(DicSingleton.gE3WbyDVW(-380885952 ^ -380871792));
		}
		ResizeIfNeeded();
		CalculateInsertionParameters(m_TagReader, visitorReader, index, ref m_ProcessReader, ref m_RepositoryReader, out var insertPtr, out var copyIndex, out var copyOffset, out var copyLength);
		if (copyLength != 0)
		{
			Array.Copy(annotationReader, copyIndex, annotationReader, copyIndex + copyOffset, copyLength);
		}
		annotationReader[insertPtr] = item;
		visitorReader++;
	}

	private void ResizeIfNeeded()
	{
		int num = 10;
		int num4 = default(int);
		T[] destinationArray = default(T[]);
		int num5 = default(int);
		int num3 = default(int);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 9:
					if (visitorReader == num4)
					{
						num2 = 6;
						continue;
					}
					return;
				case 11:
					Array.Copy(annotationReader, m_ProcessReader + 1, destinationArray, m_RepositoryReader + 1, num5);
					num2 = 7;
					continue;
				case 3:
					Array.Copy(annotationReader, 0, destinationArray, 0, num3);
					num2 = 12;
					continue;
				default:
					num5 = num4 - num3;
					num2 = 4;
					continue;
				case 4:
					if (num5 > 0)
					{
						num2 = 11;
						continue;
					}
					goto case 7;
				case 12:
					m_RepositoryReader += num4;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 != 0)
					{
						num2 = 0;
					}
					continue;
				case 6:
					destinationArray = new T[num4 * 2];
					num2 = 2;
					continue;
				case 7:
					annotationReader = destinationArray;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
					{
						num2 = 0;
					}
					continue;
				case 8:
					return;
				case 10:
					num4 = annotationReader.Length;
					num2 = 9;
					continue;
				case 1:
					m_TagReader = m_TagReader * 2 + 1;
					num2 = 8;
					continue;
				case 5:
					if (num3 > 0)
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec == 0)
						{
							num2 = 3;
						}
						continue;
					}
					goto case 12;
				case 2:
					break;
				}
				break;
			}
			num3 = m_ProcessReader + 1;
			num = 5;
		}
	}

	internal static void CalculateInsertionParameters(int mask, int count, int index, ref int readPtr, ref int writePtr, out int insertPtr, out int copyIndex, out int copyOffset, out int copyLength)
	{
		int num = 15;
		int num3 = default(int);
		int num6 = default(int);
		int num5 = default(int);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				int num4;
				int num7;
				switch (num2)
				{
				case 4:
					copyIndex = insertPtr;
					num2 = 16;
					continue;
				case 7:
					if (index == count)
					{
						num2 = 19;
						continue;
					}
					if (num3 < insertPtr)
					{
						num2 = 10;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 != 0)
						{
							num2 = 5;
						}
						continue;
					}
					num4 = readPtr - insertPtr;
					goto IL_02b7;
				case 26:
					num7 = int.MaxValue;
					goto IL_02ca;
				case 3:
					copyLength = 0;
					num2 = 22;
					continue;
				case 14:
					if (index == 0)
					{
						num2 = 2;
						continue;
					}
					insertPtr = (readPtr - index) & mask;
					num2 = 7;
					continue;
				case 5:
					if (num6 > num5)
					{
						num2 = 12;
						continue;
					}
					goto case 11;
				case 15:
					num3 = (readPtr + 1) & mask;
					num2 = 14;
					continue;
				case 10:
					num4 = int.MaxValue;
					goto IL_02b7;
				case 8:
					copyLength = num6;
					num2 = 23;
					continue;
				case 16:
					copyOffset = 1;
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 != 0)
					{
						num2 = 4;
					}
					continue;
				case 18:
					if (writePtr > insertPtr)
					{
						num2 = 26;
						continue;
					}
					num7 = insertPtr - writePtr;
					goto IL_02ca;
				case 25:
					copyOffset = 0;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 == 0)
					{
						num2 = 0;
					}
					continue;
				default:
					copyLength = 0;
					num2 = 20;
					continue;
				case 22:
					return;
				case 20:
					return;
				case 13:
					copyOffset = 0;
					num = 3;
					break;
				case 2:
					insertPtr = (readPtr = num3);
					num2 = 21;
					continue;
				case 17:
					copyLength = num5;
					num2 = 27;
					continue;
				case 6:
					copyIndex = 0;
					num2 = 13;
					continue;
				case 19:
					writePtr = (writePtr - 1) & mask;
					num2 = 6;
					continue;
				case 9:
					return;
				case 11:
					insertPtr++;
					num2 = 24;
					continue;
				case 24:
					readPtr++;
					num2 = 4;
					continue;
				case 23:
					return;
				case 12:
					copyIndex = writePtr + 1;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
					{
						num2 = 1;
					}
					continue;
				case 1:
					copyOffset = -1;
					num = 17;
					break;
				case 21:
					copyIndex = 0;
					num2 = 25;
					continue;
				case 27:
					{
						writePtr = (writePtr - 1) & mask;
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 != 0)
						{
							num2 = 9;
						}
						continue;
					}
					IL_02b7:
					num6 = num4;
					num2 = 18;
					continue;
					IL_02ca:
					num5 = num7;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec != 0)
					{
						num2 = 4;
					}
					continue;
				}
				break;
			}
		}
	}

	[IteratorStateMachine(typeof(ConnectionReader<>._003CGetEnumerator_003Ed__16))]
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

	internal static bool ReflectService()
	{
		return CancelService == null;
	}

	internal static object CollectService()
	{
		return CancelService;
	}
}
