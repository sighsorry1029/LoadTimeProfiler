using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class GetterAuthentication : WrapperSetter
{
	private sealed class CodeAuthentication : IList, ICollection, IEnumerable
	{
		[CompilerGenerated]
		private sealed class _003CGetEnumerator_003Ed__25 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CodeAuthentication _003C_003E4__this;

			private int _003Ci_003E5__2;

			internal static _003CGetEnumerator_003Ed__25? CollectImporter;

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
				int num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
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
						num = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 != 0)
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
				int num = 6;
				int num3 = default(int);
				CodeAuthentication codeAuthentication = default(CodeAuthentication);
				int num4 = default(int);
				while (true)
				{
					int num2 = num;
					while (true)
					{
						switch (num2)
						{
						case 1:
							return true;
						case 13:
							if (num3 == 1)
							{
								_003C_003E1__state = -1;
								num2 = 7;
							}
							else
							{
								num2 = 10;
							}
							continue;
						case 4:
						case 11:
							if (_003Ci_003E5__2 >= codeAuthentication.Count)
							{
								num2 = 3;
								continue;
							}
							break;
						case 10:
							return false;
						case 12:
							_003C_003E1__state = 1;
							num2 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
							{
								num2 = 1;
							}
							continue;
						case 7:
							num4 = _003Ci_003E5__2 + 1;
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
							{
								num2 = 0;
							}
							continue;
						case 2:
							_003Ci_003E5__2 = 0;
							num2 = 11;
							continue;
						case 5:
							codeAuthentication = _003C_003E4__this;
							num2 = 9;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
							{
								num2 = 0;
							}
							continue;
						case 6:
							num3 = _003C_003E1__state;
							num2 = 5;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 != 0)
							{
								num2 = 2;
							}
							continue;
						case 3:
							return false;
						default:
							goto end_IL_0012;
						case 9:
							if (num3 == 0)
							{
								_003C_003E1__state = -1;
								num2 = 2;
							}
							else
							{
								num2 = 13;
							}
							continue;
						case 8:
							break;
						}
						_003C_003E2__current = codeAuthentication.indexerAuthentication[_003Ci_003E5__2];
						num2 = 12;
						continue;
						end_IL_0012:
						break;
					}
					_003Ci_003E5__2 = num4;
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

			internal static bool ManageImporter()
			{
				return CollectImporter == null;
			}

			internal static _003CGetEnumerator_003Ed__25? ForgotImporter()
			{
				return CollectImporter;
			}
		}

		private object?[] indexerAuthentication;

		[CompilerGenerated]
		private int mockAuthentication;

		private static CodeAuthentication? CustomizeImporter;

		public bool IsFixedSize => false;

		public bool IsReadOnly => false;

		public object? this[int index]
		{
			get
			{
				return indexerAuthentication[index];
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
					case 1:
						indexerAuthentication[index] = value;
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
		}

		public int Count
		{
			[CompilerGenerated]
			get
			{
				return mockAuthentication;
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
						mockAuthentication = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 != 0)
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

		public object SyncRoot => indexerAuthentication;

		public CodeAuthentication()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
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
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
				{
					num = 1;
				}
			}
		}

		public int Add(object? value)
		{
			int num = 3;
			int num2 = num;
			int count = default(int);
			while (true)
			{
				switch (num2)
				{
				case 2:
					Array.Resize(ref indexerAuthentication, indexerAuthentication.Length * 2);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
					{
						num2 = 1;
					}
					continue;
				case 3:
					if (Count == indexerAuthentication.Length)
					{
						num2 = 2;
						continue;
					}
					break;
				case 4:
					count = Count;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
					{
						num2 = 0;
					}
					continue;
				default:
					Count = count + 1;
					num2 = 5;
					continue;
				case 5:
					return count;
				case 1:
					break;
				}
				indexerAuthentication[Count] = value;
				num2 = 4;
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
				case 2:
					return;
				case 1:
					indexerAuthentication = new object[10];
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 != 0)
					{
						num2 = 0;
					}
					break;
				default:
					Count = 0;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 != 0)
					{
						num2 = 2;
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
				case 0:
					return;
				case 1:
					Array.Copy(indexerAuthentication, 0, array, index, Count);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
					{
						num2 = 0;
					}
					break;
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

		internal static bool CancelImporter()
		{
			return CustomizeImporter == null;
		}

		internal static CodeAuthentication? ReflectImporter()
		{
			return CustomizeImporter;
		}
	}

	private static GetterAuthentication CheckImporter;

	public bool Deserialize(CandidateInterpreter parser, Type expectedType, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, out object? value)
	{
		if (!expectedType.IsArray)
		{
			value = false;
			return false;
		}
		Type elementType = expectedType.GetElementType();
		CodeAuthentication codeAuthentication = new CodeAuthentication();
		CustomerAuthentication.DeserializeHelper(elementType, parser, nestedObjectDeserializer, codeAuthentication, canUpdate: true);
		Array array = Array.CreateInstance(elementType, codeAuthentication.Count);
		codeAuthentication.CopyTo(array, 0);
		value = array;
		return true;
	}

	public GetterAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool RateImporter()
	{
		return CheckImporter == null;
	}

	internal static GetterAuthentication ResetImporter()
	{
		return CheckImporter;
	}
}
