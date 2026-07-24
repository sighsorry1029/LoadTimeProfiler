using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class MerchantPrototype<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] T, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TT> : IEnumerable<Func<T, TT>>, IEnumerable
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	public sealed class AttrPrototype
	{
		public readonly Type messagePrototype;

		public readonly Func<T, TT> exporterPrototype;

		public AttrPrototype(Type componentType, Func<T, TT> factory)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			messagePrototype = componentType;
			exporterPrototype = factory;
		}
	}

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	public sealed class ValPrototype
	{
		public readonly Type m_ConfigPrototype;

		public readonly Func<TT, T, TT> wrapperPrototype;

		public ValPrototype(Type componentType, Func<TT, T, TT> factory)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			m_ConfigPrototype = componentType;
			wrapperPrototype = factory;
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)]
	private class ServerPrototype : ParamPrototype<TT>
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)]
		private readonly MerchantPrototype<T, TT> m_AlgoPrototype;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 0, 0 })]
		private readonly AttrPrototype _ImporterPrototype;

		private static object CreateRole;

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
		public ServerPrototype(MerchantPrototype<T, TT> registrations, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 0, 0 })] AttrPrototype newRegistration)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			m_AlgoPrototype = registrations;
			_ImporterPrototype = newRegistration;
		}

		void ParamPrototype<TT>.InsteadOf<TRegistrationType>()
		{
			if (_ImporterPrototype.messagePrototype != typeof(TRegistrationType))
			{
				m_AlgoPrototype.EnsureNoDuplicateRegistrationType(_ImporterPrototype.messagePrototype);
			}
			int index = m_AlgoPrototype.EnsureRegistrationExists<TRegistrationType>();
			m_AlgoPrototype.testPrototype[index] = _ImporterPrototype;
		}

		void ParamPrototype<TT>.After<TRegistrationType>()
		{
			m_AlgoPrototype.EnsureNoDuplicateRegistrationType(_ImporterPrototype.messagePrototype);
			int num = m_AlgoPrototype.EnsureRegistrationExists<TRegistrationType>();
			m_AlgoPrototype.testPrototype.Insert(num + 1, _ImporterPrototype);
		}

		void ParamPrototype<TT>.Before<TRegistrationType>()
		{
			m_AlgoPrototype.EnsureNoDuplicateRegistrationType(_ImporterPrototype.messagePrototype);
			int index = m_AlgoPrototype.EnsureRegistrationExists<TRegistrationType>();
			m_AlgoPrototype.testPrototype.Insert(index, _ImporterPrototype);
		}

		void ParamPrototype<TT>.OnBottom()
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					m_AlgoPrototype.EnsureNoDuplicateRegistrationType(_ImporterPrototype.messagePrototype);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
					{
						num2 = 0;
					}
					break;
				case 2:
					return;
				default:
					m_AlgoPrototype.testPrototype.Add(_ImporterPrototype);
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
					{
						num2 = 1;
					}
					break;
				}
			}
		}

		void ParamPrototype<TT>.OnTop()
		{
			int num = 2;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 2:
					m_AlgoPrototype.EnsureNoDuplicateRegistrationType(_ImporterPrototype.messagePrototype);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 != 0)
					{
						num2 = 0;
					}
					break;
				case 1:
					m_AlgoPrototype.testPrototype.Insert(0, _ImporterPrototype);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		internal static bool TestRole()
		{
			return CreateRole == null;
		}

		internal static object RunRole()
		{
			return CreateRole;
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)]
	private class CreatorPrototype : FacadePrototype<TT>
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass3_0<TRegistrationType> where TRegistrationType : TT
		{
			public CreatorPrototype _003C_003E4__this;

			[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1 })]
			public Func<T, TT> innerComponentFactory;

			private static object ConcatRole;

			public _003C_003Ec__DisplayClass3_0()
			{
				GetterIssuer.DeleteInitializer();
				base._002Ector();
				int num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f == 0)
				{
					num = 0;
				}
				switch (num)
				{
				case 0:
					break;
				}
			}

			[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
			internal TT _003CYamlDotNet_002ESerialization_002EITrackingRegistrationLocationSelectionSyntax_003CTComponent_003E_002EInsteadOf_003Eb__0(T arg)
			{
				return _003C_003E4__this.m_DatabasePrototype.wrapperPrototype(innerComponentFactory(arg), arg);
			}

			internal static bool MapRole()
			{
				return ConcatRole == null;
			}

			internal static object AddRole()
			{
				return ConcatRole;
			}
		}

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)]
		private readonly MerchantPrototype<T, TT> _PrinterPrototype;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 0, 0 })]
		private readonly ValPrototype m_DatabasePrototype;

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
		public CreatorPrototype(MerchantPrototype<T, TT> registrations, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 0, 0 })] ValPrototype newRegistration)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			_PrinterPrototype = registrations;
			m_DatabasePrototype = newRegistration;
		}

		void FacadePrototype<TT>.InsteadOf<TRegistrationType>()
		{
			_003C_003Ec__DisplayClass3_0<TRegistrationType> CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass3_0<TRegistrationType>();
			CS_0024_003C_003E8__locals4._003C_003E4__this = this;
			if (m_DatabasePrototype.m_ConfigPrototype != typeof(TRegistrationType))
			{
				_PrinterPrototype.EnsureNoDuplicateRegistrationType(m_DatabasePrototype.m_ConfigPrototype);
			}
			int index = _PrinterPrototype.EnsureRegistrationExists<TRegistrationType>();
			CS_0024_003C_003E8__locals4.innerComponentFactory = _PrinterPrototype.testPrototype[index].exporterPrototype;
			_PrinterPrototype.testPrototype[index] = new AttrPrototype(m_DatabasePrototype.m_ConfigPrototype, [_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)] (T arg) => CS_0024_003C_003E8__locals4._003C_003E4__this.m_DatabasePrototype.wrapperPrototype(CS_0024_003C_003E8__locals4.innerComponentFactory(arg), arg));
		}
	}

	[CompilerGenerated]
	private sealed class _003Cget_InReverseOrder_003Ed__9 : IEnumerable<Func<T, TT>>, IEnumerable, IEnumerator<Func<T, TT>>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private Func<T, TT> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public MerchantPrototype<T, TT> _003C_003E4__this;

		private int _003Ci_003E5__2;

		internal static object PrepareRole;

		Func<T, TT> IEnumerator<Func<T, TT>>.Current
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
		public _003Cget_InReverseOrder_003Ed__9(int _003C_003E1__state)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 != 0)
			{
				num = 2;
			}
			while (true)
			{
				switch (num)
				{
				default:
					_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
					num = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
					{
						num = 1;
					}
					break;
				case 1:
					return;
				case 2:
					this._003C_003E1__state = _003C_003E1__state;
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 == 0)
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
			int num = 4;
			int num4 = default(int);
			MerchantPrototype<T, TT> merchantPrototype = default(MerchantPrototype<T, TT>);
			int num3 = default(int);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					case 15:
						if (num4 != 1)
						{
							num = 14;
							break;
						}
						_003C_003E1__state = -1;
						num = 7;
						break;
					case 14:
						return false;
					case 13:
						_003C_003E1__state = -1;
						num2 = 10;
						continue;
					case 9:
						if (num4 == 0)
						{
							num2 = 13;
							continue;
						}
						goto case 15;
					case 8:
						return false;
					default:
						if (_003Ci_003E5__2 >= 0)
						{
							num2 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 == 0)
							{
								num2 = 1;
							}
							continue;
						}
						goto case 8;
					case 10:
						_003Ci_003E5__2 = merchantPrototype.testPrototype.Count - 1;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
						{
							num2 = 0;
						}
						continue;
					case 1:
					case 5:
						_003C_003E2__current = merchantPrototype.testPrototype[_003Ci_003E5__2].exporterPrototype;
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 != 0)
						{
							num2 = 2;
						}
						continue;
					case 11:
						return true;
					case 6:
						_003C_003E1__state = 1;
						num2 = 11;
						continue;
					case 3:
						merchantPrototype = _003C_003E4__this;
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
						{
							num2 = 9;
						}
						continue;
					case 4:
						num4 = _003C_003E1__state;
						num2 = 3;
						continue;
					case 7:
						num3 = _003Ci_003E5__2 - 1;
						num2 = 12;
						continue;
					case 12:
						_003Ci_003E5__2 = num3;
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

		[DebuggerHidden]
		[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 0, 1, 1 })]
		IEnumerator<Func<T, TT>> IEnumerable<Func<T, TT>>.GetEnumerator()
		{
			_003Cget_InReverseOrder_003Ed__9 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003Cget_InReverseOrder_003Ed__9(0)
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
			return ((IEnumerable<Func<T, TT>>)this).GetEnumerator();
		}

		internal static bool WriteRole()
		{
			return PrepareRole == null;
		}

		internal static object PrintRole()
		{
			return PrepareRole;
		}
	}

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 1, 0, 0 })]
	private readonly List<AttrPrototype> testPrototype;

	internal static object CalculateMethod;

	public int Count => testPrototype.Count;

	public IEnumerable<Func<T, TT>> InReverseOrder
	{
		[IteratorStateMachine(typeof(MerchantPrototype<, >._003Cget_InReverseOrder_003Ed__9))]
		get
		{
			//yield-return decompiler failed: Missing enumeratorCtor.Body
			return new _003Cget_InReverseOrder_003Ed__9(-2)
			{
				_003C_003E4__this = this
			};
		}
	}

	public MerchantPrototype<T, TT> Clone()
	{
		MerchantPrototype<T, TT> merchantPrototype = new MerchantPrototype<T, TT>();
		foreach (AttrPrototype item in testPrototype)
		{
			merchantPrototype.testPrototype.Add(item);
		}
		return merchantPrototype;
	}

	public void Add(Type componentType, Func<T, TT> factory)
	{
		testPrototype.Add(new AttrPrototype(componentType, factory));
	}

	public void Remove(Type componentType)
	{
		int num = 3;
		int num3 = default(int);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 6:
					if (!(testPrototype[num3].messagePrototype == componentType))
					{
						goto end_IL_0012;
					}
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
					{
						num2 = 1;
					}
					break;
				case 2:
				case 4:
					if (num3 >= testPrototype.Count)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b == 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 6;
				case 5:
					return;
				case 1:
					testPrototype.RemoveAt(num3);
					num2 = 5;
					break;
				case 3:
					num3 = 0;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e != 0)
					{
						num2 = 2;
					}
					break;
				default:
					throw new KeyNotFoundException(DicSingleton.gE3WbyDVW(0x2BC53863 ^ 0x2BC5634F) + componentType.FullName + DicSingleton.gE3WbyDVW(0x74FC52AF ^ 0x74FC09DB));
				}
				continue;
				end_IL_0012:
				break;
			}
			num3++;
			num = 4;
		}
	}

	public ParamPrototype<TT> CreateRegistrationLocationSelector(Type componentType, Func<T, TT> factory)
	{
		return new ServerPrototype(this, new AttrPrototype(componentType, factory));
	}

	public FacadePrototype<TT> CreateTrackingRegistrationLocationSelector(Type componentType, Func<TT, T, TT> factory)
	{
		return new CreatorPrototype(this, new ValPrototype(componentType, factory));
	}

	public IEnumerator<Func<T, TT>> GetEnumerator()
	{
		return testPrototype.Select([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (AttrPrototype e) => e.exporterPrototype).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private int IndexOfRegistration(Type registrationType)
	{
		int num = 2;
		int num2 = num;
		int num3 = default(int);
		while (true)
		{
			switch (num2)
			{
			case 6:
				if (!(registrationType == testPrototype[num3].messagePrototype))
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 != 0)
					{
						num2 = 3;
					}
					break;
				}
				goto default;
			default:
				return num3;
			case 3:
				num3++;
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
				{
					num2 = 4;
				}
				break;
			case 2:
				num3 = 0;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
			case 4:
				if (num3 >= testPrototype.Count)
				{
					num2 = 5;
					break;
				}
				goto case 6;
			case 5:
				return -1;
			}
		}
	}

	private void EnsureNoDuplicateRegistrationType(Type componentType)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (IndexOfRegistration(componentType) != -1)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 == 0)
					{
						num2 = 0;
					}
					break;
				}
				return;
			default:
				throw new InvalidOperationException(DicSingleton.gE3WbyDVW(-2133864647 ^ -2133879647) + componentType.FullName + DicSingleton.gE3WbyDVW(-1273961441 ^ -1273970727));
			}
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	private int EnsureRegistrationExists<TRegistrationType>()
	{
		int num = IndexOfRegistration(typeof(TRegistrationType));
		if (num == -1)
		{
			throw new InvalidOperationException(DicSingleton.gE3WbyDVW(-849667636 ^ -849657260) + typeof(TRegistrationType).FullName + DicSingleton.gE3WbyDVW(-1549341817 ^ -1549355135));
		}
		return num;
	}

	public MerchantPrototype()
	{
		GetterIssuer.DeleteInitializer();
		testPrototype = new List<AttrPrototype>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool MoveMethod()
	{
		return CalculateMethod == null;
	}

	internal static object RevertMethod()
	{
		return CalculateMethod;
	}
}
