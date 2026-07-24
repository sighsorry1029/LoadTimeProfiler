using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class MessageAuthentication : WrapperSetter
{
	private sealed class ValAuthentication : IList, ICollection, IEnumerable
	{
		[CompilerGenerated]
		private sealed class _003CGetEnumerator_003Ed__25 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ValAuthentication _003C_003E4__this;

			private int _003Ci_003E5__2;

			private static _003CGetEnumerator_003Ed__25? AwakeMock;

			object IEnumerator<object>.Current
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
			public _003CGetEnumerator_003Ed__25(int _003C_003E1__state)
			{
				GetterIssuer.DeleteInitializer();
				base._002Ector();
				int num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 != 0)
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
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
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
				ValAuthentication valAuthentication = default(ValAuthentication);
				int num3 = default(int);
				int num4 = default(int);
				while (true)
				{
					int num2 = num;
					while (true)
					{
						switch (num2)
						{
						case 7:
						case 11:
							if (_003Ci_003E5__2 >= valAuthentication.Count)
							{
								num2 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 == 0)
								{
									num2 = 0;
								}
								break;
							}
							goto case 3;
						case 1:
							valAuthentication = _003C_003E4__this;
							num2 = 6;
							break;
						case 6:
							if (num3 != 0)
							{
								num2 = 10;
								break;
							}
							_003C_003E1__state = -1;
							num2 = 9;
							break;
						default:
							return false;
						case 12:
							return false;
						case 9:
							_003Ci_003E5__2 = 0;
							num2 = 7;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 != 0)
							{
								num2 = 5;
							}
							break;
						case 5:
							num4 = _003Ci_003E5__2 + 1;
							num2 = 4;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
							{
								num2 = 0;
							}
							break;
						case 13:
							_003C_003E1__state = 1;
							num2 = 7;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
							{
								num2 = 8;
							}
							break;
						case 2:
							num3 = _003C_003E1__state;
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
							{
								num2 = 1;
							}
							break;
						case 4:
							_003Ci_003E5__2 = num4;
							num2 = 11;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
							{
								num2 = 4;
							}
							break;
						case 3:
							_003C_003E2__current = valAuthentication.configAuthentication[_003Ci_003E5__2];
							num2 = 13;
							break;
						case 8:
							return true;
						case 10:
							if (num3 == 1)
							{
								_003C_003E1__state = -1;
								num = 5;
								goto end_IL_0012;
							}
							num2 = 12;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
							{
								num2 = 9;
							}
							break;
						}
						continue;
						end_IL_0012:
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

			internal static bool InstantiateMock()
			{
				return AwakeMock == null;
			}

			internal static _003CGetEnumerator_003Ed__25? LoginMock()
			{
				return AwakeMock;
			}
		}

		private object?[] configAuthentication;

		[CompilerGenerated]
		private int wrapperAuthentication;

		internal static ValAuthentication? ComputeMock;

		public bool IsFixedSize => false;

		public bool IsReadOnly => false;

		public object? this[int index]
		{
			get
			{
				return configAuthentication[index];
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
						configAuthentication[index] = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
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
				return wrapperAuthentication;
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
					case 1:
						wrapperAuthentication = value;
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
		}

		public bool IsSynchronized => false;

		public object SyncRoot => configAuthentication;

		public ValAuthentication()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db == 0)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
				{
					num = 1;
				}
			}
		}

		public int Add(object? value)
		{
			int num = 5;
			int num2 = num;
			int count = default(int);
			while (true)
			{
				switch (num2)
				{
				case 1:
					count = Count;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
					{
						num2 = 2;
					}
					break;
				default:
					return count;
				case 2:
					configAuthentication[Count] = value;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
					{
						num2 = 1;
					}
					break;
				case 5:
					if (Count == configAuthentication.Length)
					{
						num2 = 4;
						break;
					}
					goto case 2;
				case 4:
					Array.Resize(ref configAuthentication, configAuthentication.Length * 2);
					num2 = 2;
					break;
				case 3:
					Count = count + 1;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		public void Clear()
		{
			int num = 2;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 1:
					Count = 0;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb != 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				case 2:
					configAuthentication = new object[10];
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
					{
						num2 = 1;
					}
					break;
				}
			}
		}

		bool IList.Contains(object? value)
		{
			throw new NotSupportedException();
		}

		int IList.IndexOf(object? value)
		{
			throw new NotSupportedException();
		}

		void IList.Insert(int index, object? value)
		{
			throw new NotSupportedException();
		}

		void IList.Remove(object? value)
		{
			throw new NotSupportedException();
		}

		void IList.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

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
				case 1:
					Array.Copy(configAuthentication, 0, array, index, Count);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 != 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		[IteratorStateMachine(typeof(_003CGetEnumerator_003Ed__25))]
		public IEnumerator GetEnumerator()
		{
			//yield-return decompiler failed: Missing enumeratorCtor.Body
			return new _003CGetEnumerator_003Ed__25(0)
			{
				_003C_003E4__this = this
			};
		}

		internal static bool DisableMock()
		{
			return ComputeMock == null;
		}

		internal static ValAuthentication? QueryMock()
		{
			return ComputeMock;
		}
	}

	private readonly MapAuthentication m_ExporterAuthentication;

	private static MessageAuthentication FillMock;

	public MessageAuthentication(MapAuthentication factory)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
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
			m_ExporterAuthentication = factory ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-32257720 ^ -32267478));
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
			{
				num = 1;
			}
		}
	}

	public bool Deserialize(CandidateInterpreter parser, Type expectedType, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, out object? value)
	{
		if (!m_ExporterAuthentication.IsArray(expectedType))
		{
			value = false;
			return false;
		}
		Type valueType = m_ExporterAuthentication.GetValueType(expectedType);
		ValAuthentication valAuthentication = new ValAuthentication();
		ServerAuthentication.DeserializeHelper(valueType, parser, nestedObjectDeserializer, valAuthentication, m_ExporterAuthentication);
		Array array = m_ExporterAuthentication.CreateArray(expectedType, valAuthentication.Count);
		valAuthentication.CopyTo(array, 0);
		value = array;
		return true;
	}

	internal static bool FlushMock()
	{
		return FillMock == null;
	}

	internal static MessageAuthentication DestroyMock()
	{
		return FillMock;
	}
}
