using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal static class MockInvocation
{
	[CompilerGenerated]
	private sealed class _003CGetImplementedInterfaces_003Ed__1 : IEnumerable<Type>, IEnumerable, IEnumerator<Type>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private Type _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Type type;

		public Type _003C_003E3__type;

		private Type[] _003C_003E7__wrap1;

		private int _003C_003E7__wrap2;

		internal static _003CGetImplementedInterfaces_003Ed__1 CalcProxy;

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
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
			{
				num = 0;
			}
			while (true)
			{
				switch (num)
				{
				case 1:
					_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
					num = 2;
					continue;
				case 2:
					return;
				}
				this._003C_003E1__state = _003C_003E1__state;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
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
			int num = 10;
			Type type = default(Type);
			int num3 = default(int);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					case 5:
						_003C_003E7__wrap2++;
						num2 = 7;
						continue;
					case 7:
					case 18:
						if (_003C_003E7__wrap2 >= _003C_003E7__wrap1.Length)
						{
							num2 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb == 0)
							{
								num2 = 1;
							}
							continue;
						}
						goto case 15;
					case 8:
						break;
					case 14:
						_003C_003E1__state = 1;
						num2 = 3;
						continue;
					default:
						_003C_003E7__wrap1 = this.type.GetInterfaces();
						num2 = 17;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
						{
							num2 = 9;
						}
						continue;
					case 15:
						type = _003C_003E7__wrap1[_003C_003E7__wrap2];
						num2 = 8;
						continue;
					case 13:
						_003C_003E1__state = 2;
						num2 = 9;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
						{
							num2 = 12;
						}
						continue;
					case 4:
						_003C_003E2__current = this.type;
						num2 = 14;
						continue;
					case 9:
						switch (num3)
						{
						default:
							num2 = 16;
							break;
						case 0:
							_003C_003E1__state = -1;
							num2 = 11;
							break;
						case 1:
							_003C_003E1__state = -1;
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
							{
								num2 = 0;
							}
							break;
						case 2:
							_003C_003E1__state = -1;
							num2 = 5;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
							{
								num2 = 1;
							}
							break;
						}
						continue;
					case 6:
						return false;
					case 16:
						return false;
					case 3:
						return true;
					case 1:
						_003C_003E7__wrap1 = null;
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
						{
							num2 = 6;
						}
						continue;
					case 12:
						return true;
					case 17:
						_003C_003E7__wrap2 = 0;
						num2 = 18;
						continue;
					case 11:
						if (!InterceptorSetter.IsInterface(this.type))
						{
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
							{
								num2 = 2;
							}
							continue;
						}
						goto case 4;
					case 10:
						num3 = _003C_003E1__state;
						num2 = 9;
						continue;
					}
					break;
				}
				_003C_003E2__current = type;
				num = 13;
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
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Type>)this).GetEnumerator();
		}

		internal static bool LogoutProxy()
		{
			return CalcProxy == null;
		}

		internal static _003CGetImplementedInterfaces_003Ed__1 CountProxy()
		{
			return CalcProxy;
		}
	}

	private static MockInvocation PatchProxy;

	public static Type? GetImplementedGenericInterface(Type type, Type genericInterfaceType)
	{
		foreach (Type implementedInterface in GetImplementedInterfaces(type))
		{
			if (!InterceptorSetter.IsGenericType(implementedInterface) || !(implementedInterface.GetGenericTypeDefinition() == genericInterfaceType))
			{
				continue;
			}
			return implementedInterface;
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

	internal static bool AssetProxy()
	{
		return PatchProxy == null;
	}

	internal static MockInvocation ListProxy()
	{
		return PatchProxy;
	}
}
