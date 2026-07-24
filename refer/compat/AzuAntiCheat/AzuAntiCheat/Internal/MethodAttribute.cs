using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class MethodAttribute : ProductAttribute
{
	[CompilerGenerated]
	private sealed class _003CSafeAllNodes_003Ed__7 : IEnumerable<ProductAttribute>, IEnumerable, IEnumerator<ProductAttribute>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private ProductAttribute _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public MethodAttribute _003C_003E4__this;

		private static _003CSafeAllNodes_003Ed__7 AssetToken;

		ProductAttribute IEnumerator<ProductAttribute>.Current
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
		public _003CSafeAllNodes_003Ed__7(int _003C_003E1__state)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
			{
				num = 0;
			}
			while (true)
			{
				switch (num)
				{
				default:
					this._003C_003E1__state = _003C_003E1__state;
					num = 2;
					break;
				case 2:
					_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
					num = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
					{
						num = 1;
					}
					break;
				case 1:
					return;
				}
			}
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = 7;
			int num3 = default(int);
			MethodAttribute methodAttribute = default(MethodAttribute);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					case 5:
						if (num3 == 0)
						{
							num2 = 2;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
							{
								num2 = 0;
							}
							continue;
						}
						goto case 3;
					case 7:
						num3 = _003C_003E1__state;
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 != 0)
						{
							num2 = 6;
						}
						continue;
					case 3:
						if (num3 != 1)
						{
							num = 4;
							break;
						}
						_003C_003E1__state = -1;
						num2 = 9;
						continue;
					case 9:
						return false;
					case 6:
						methodAttribute = _003C_003E4__this;
						num = 5;
						break;
					case 1:
						return true;
					case 4:
						return false;
					case 2:
						_003C_003E1__state = -1;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
						{
							num2 = 0;
						}
						continue;
					case 8:
						_003C_003E1__state = 1;
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
						{
							num2 = 1;
						}
						continue;
					default:
						_003C_003E2__current = methodAttribute;
						num2 = 8;
						continue;
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
		IEnumerator<ProductAttribute> IEnumerable<ProductAttribute>.GetEnumerator()
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
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ProductAttribute>)this).GetEnumerator();
		}

		internal static bool ListToken()
		{
			return AssetToken == null;
		}

		internal static _003CSafeAllNodes_003Ed__7 CalcToken()
		{
			return AssetToken;
		}
	}

	internal static MethodAttribute ViewToken;

	public override ActivityTemplateFactoryBuilderWriterStates NodeType => (ActivityTemplateFactoryBuilderWriterStates)0;

	internal MethodAttribute(VisitorAttribute anchor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
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
			base.Anchor = anchor;
			num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 != 0)
			{
				num = 1;
			}
		}
	}

	internal override void ResolveAliases(IdentifierAttribute state)
	{
		throw new NotSupportedException(DicSingleton.gE3WbyDVW(0x7742C60 ^ 0x7745CEE));
	}

	internal override void Emit(MockInterpreter emitter, RulesAttribute state)
	{
		throw new NotSupportedException(DicSingleton.gE3WbyDVW(0x567B7B7F ^ 0x567B0A7F));
	}

	public override void Accept(CodeAttribute visitor)
	{
		throw new NotSupportedException(DicSingleton.gE3WbyDVW(-220409977 ^ -220414441));
	}

	public override bool Equals(object? obj)
	{
		int num = 1;
		int num2 = num;
		MethodAttribute methodAttribute = default(MethodAttribute);
		while (true)
		{
			switch (num2)
			{
			case 3:
				return object.Equals(base.Anchor, methodAttribute.Anchor);
			case 1:
				methodAttribute = obj as MethodAttribute;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				if (Equals(methodAttribute))
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
					{
						num2 = 3;
					}
					break;
				}
				goto IL_0049;
			default:
				{
					if (methodAttribute != null)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
						{
							num2 = 2;
						}
						break;
					}
					goto IL_0049;
				}
				IL_0049:
				return false;
			}
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	internal override string ToString(ProxyInterpreter level)
	{
		return DicSingleton.gE3WbyDVW(-1338893851 ^ -1338872895) + base.Anchor.ToString();
	}

	[IteratorStateMachine(typeof(_003CSafeAllNodes_003Ed__7))]
	internal override IEnumerable<ProductAttribute> SafeAllNodes(ProxyInterpreter level)
	{
		//yield-return decompiler failed: Missing enumeratorCtor.Body
		return new _003CSafeAllNodes_003Ed__7(-2)
		{
			_003C_003E4__this = this
		};
	}

	internal static bool InitToken()
	{
		return ViewToken == null;
	}

	internal static MethodAttribute PatchToken()
	{
		return ViewToken;
	}
}
