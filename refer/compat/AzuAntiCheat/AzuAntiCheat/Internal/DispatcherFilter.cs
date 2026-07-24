using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal class DispatcherFilter : MappingFilter
{
	[CompilerGenerated]
	private sealed class _003CSafeAllNodes_003Ed__7 : IEnumerable<MappingFilter>, IEnumerable, IEnumerator<MappingFilter>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private MappingFilter _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public DispatcherFilter _003C_003E4__this;

		private static _003CSafeAllNodes_003Ed__7 CollectAnnotation;

		MappingFilter IEnumerator<MappingFilter>.Current
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
		public _003CSafeAllNodes_003Ed__7(int _003C_003E1__state)
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
				default:
					_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
					num = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 != 0)
					{
						num = 1;
					}
					break;
				case 2:
					this._003C_003E1__state = _003C_003E1__state;
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 == 0)
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
			int num = 8;
			int num3 = default(int);
			DispatcherFilter dispatcherFilter = default(DispatcherFilter);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					case 5:
						_003C_003E1__state = 1;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 == 0)
						{
							num2 = 1;
						}
						break;
					case 4:
						if (num3 != 0)
						{
							num2 = 6;
							break;
						}
						_003C_003E1__state = -1;
						num2 = 3;
						break;
					default:
						return false;
					case 2:
						return false;
					case 8:
						num3 = _003C_003E1__state;
						num2 = 7;
						break;
					case 6:
						if (num3 == 1)
						{
							_003C_003E1__state = -1;
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
							{
								num2 = 0;
							}
							break;
						}
						goto end_IL_0012;
					case 3:
						_003C_003E2__current = dispatcherFilter;
						num2 = 5;
						break;
					case 1:
						return true;
					case 7:
						dispatcherFilter = _003C_003E4__this;
						num2 = 4;
						break;
					}
					continue;
					end_IL_0012:
					break;
				}
				num = 2;
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
		IEnumerator<MappingFilter> IEnumerable<MappingFilter>.GetEnumerator()
		{
			_003CSafeAllNodes_003Ed__7 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003CSafeAllNodes_003Ed__7(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<MappingFilter>)this).GetEnumerator();
		}

		internal static bool ManageAnnotation()
		{
			return CollectAnnotation == null;
		}

		internal static _003CSafeAllNodes_003Ed__7 ForgotAnnotation()
		{
			return CollectAnnotation;
		}
	}

	private static DispatcherFilter CustomizeAnnotation;

	public override SpecificationFilter NodeType => (SpecificationFilter)0;

	internal DispatcherFilter(HelperReader anchor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 1:
				base.Anchor = anchor;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 != 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal override void ResolveAliases(PolicyFilter state)
	{
		throw new NotSupportedException(DicSingleton.gE3WbyDVW(0x2BB207E4 ^ 0x2BB2776A));
	}

	internal override void Emit(ModelReader emitter, InfoFilter state)
	{
		throw new NotSupportedException(DicSingleton.gE3WbyDVW(0x7B291245 ^ 0x7B296345));
	}

	public override void Accept(ParamsFilter visitor)
	{
		throw new NotSupportedException(DicSingleton.gE3WbyDVW(0x1C9EFC64 ^ 0x1C9E8DF4));
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	public override bool Equals(object obj)
	{
		int num = 1;
		DispatcherFilter dispatcherFilter = default(DispatcherFilter);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 3:
					if (Equals(dispatcherFilter))
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 4;
				case 2:
					return object.Equals(base.Anchor, dispatcherFilter.Anchor);
				case 4:
					return false;
				case 1:
					dispatcherFilter = obj as DispatcherFilter;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
					{
						num2 = 0;
					}
					continue;
				default:
					if (dispatcherFilter == null)
					{
						break;
					}
					goto case 3;
				}
				break;
			}
			num = 4;
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	internal override string ToString(SingletonFactory level)
	{
		return DicSingleton.gE3WbyDVW(0x3A437A88 ^ 0x3A4308AC) + base.Anchor.ToString();
	}

	[IteratorStateMachine(typeof(_003CSafeAllNodes_003Ed__7))]
	internal override IEnumerable<MappingFilter> SafeAllNodes(SingletonFactory level)
	{
		//yield-return decompiler failed: Missing enumeratorCtor.Body
		return new _003CSafeAllNodes_003Ed__7(-2)
		{
			_003C_003E4__this = this
		};
	}

	internal static bool CancelAnnotation()
	{
		return CustomizeAnnotation == null;
	}

	internal static DispatcherFilter ReflectAnnotation()
	{
		return CustomizeAnnotation;
	}
}
