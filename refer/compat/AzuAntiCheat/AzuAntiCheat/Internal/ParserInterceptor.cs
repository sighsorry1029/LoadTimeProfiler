using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal static class ParserInterceptor
{
	[CompilerGenerated]
	private sealed class _003CGetImplementedInterfaces_003Ed__1 : IEnumerable<Type>, IEnumerable, IEnumerator<Type>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private Type _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		private Type type;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public Type _003C_003E3__type;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		private Type[] _003C_003E7__wrap1;

		private int _003C_003E7__wrap2;

		internal static _003CGetImplementedInterfaces_003Ed__1 VerifyUtils;

		Type IEnumerator<Type>.Current
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
		public _003CGetImplementedInterfaces_003Ed__1(int _003C_003E1__state)
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
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 != 0)
					{
						num = 0;
					}
					break;
				case 2:
					this._003C_003E1__state = _003C_003E1__state;
					num = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
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
			int num = 8;
			Type type = default(Type);
			int num3 = default(int);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					case 9:
						return false;
					case 13:
						_003C_003E7__wrap2++;
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
						{
							num2 = 2;
						}
						continue;
					case 16:
						_003C_003E2__current = type;
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 == 0)
						{
							num2 = 1;
						}
						continue;
					case 4:
					case 11:
						type = _003C_003E7__wrap1[_003C_003E7__wrap2];
						num = 16;
						break;
					case 10:
						return true;
					case 14:
						if (CollectionBase.IsInterface(this.type))
						{
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb != 0)
							{
								num2 = 1;
							}
							continue;
						}
						goto case 17;
					case 6:
						_003C_003E7__wrap2 = 0;
						num2 = 2;
						continue;
					case 1:
						_003C_003E2__current = this.type;
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d != 0)
						{
							num2 = 15;
						}
						continue;
					default:
						return false;
					case 7:
						switch (num3)
						{
						case 0:
							_003C_003E1__state = -1;
							num2 = 14;
							break;
						case 1:
							_003C_003E1__state = -1;
							num2 = 2;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
							{
								num2 = 17;
							}
							break;
						default:
							num2 = 9;
							break;
						case 2:
							_003C_003E1__state = -1;
							num2 = 13;
							break;
						}
						continue;
					case 3:
						_003C_003E1__state = 2;
						num = 12;
						break;
					case 18:
						_003C_003E7__wrap1 = null;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 != 0)
						{
							num2 = 0;
						}
						continue;
					case 8:
						num3 = _003C_003E1__state;
						num2 = 7;
						continue;
					case 17:
						_003C_003E7__wrap1 = this.type.GetInterfaces();
						num2 = 6;
						continue;
					case 12:
						return true;
					case 15:
						_003C_003E1__state = 1;
						num2 = 10;
						continue;
					case 2:
					case 5:
						if (_003C_003E7__wrap2 < _003C_003E7__wrap1.Length)
						{
							num2 = 11;
							continue;
						}
						goto case 18;
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
		[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		IEnumerator<Type> IEnumerable<Type>.GetEnumerator()
		{
			_003CGetImplementedInterfaces_003Ed__1 _003CGetImplementedInterfaces_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CGetImplementedInterfaces_003Ed__ = this;
			}
			else
			{
				_003CGetImplementedInterfaces_003Ed__ = new _003CGetImplementedInterfaces_003Ed__1(0);
			}
			_003CGetImplementedInterfaces_003Ed__.type = _003C_003E3__type;
			return _003CGetImplementedInterfaces_003Ed__;
		}

		[DebuggerHidden]
		[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Type>)this).GetEnumerator();
		}

		internal static bool PopUtils()
		{
			return VerifyUtils == null;
		}

		internal static _003CGetImplementedInterfaces_003Ed__1 PostUtils()
		{
			return VerifyUtils;
		}
	}

	private static ParserInterceptor CreateUtils;

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public static Type GetImplementedGenericInterface(Type type, Type genericInterfaceType)
	{
		foreach (Type implementedInterface in GetImplementedInterfaces(type))
		{
			if (CollectionBase.IsGenericType(implementedInterface) && implementedInterface.GetGenericTypeDefinition() == genericInterfaceType)
			{
				return implementedInterface;
			}
		}
		return null;
	}

	[IteratorStateMachine(typeof(_003CGetImplementedInterfaces_003Ed__1))]
	public static IEnumerable<Type> GetImplementedInterfaces(Type type)
	{
		//yield-return decompiler failed: Missing enumeratorCtor.Body
		return new _003CGetImplementedInterfaces_003Ed__1(-2)
		{
			_003C_003E3__type = type
		};
	}

	internal static bool TestUtils()
	{
		return CreateUtils == null;
	}

	internal static ParserInterceptor RunUtils()
	{
		return CreateUtils;
	}
}
