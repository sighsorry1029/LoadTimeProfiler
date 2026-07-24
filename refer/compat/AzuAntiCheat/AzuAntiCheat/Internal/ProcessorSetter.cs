using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ProcessorSetter<T, TT> : IEnumerable<Func<T, TT>>, IEnumerable
{
	public sealed class DicSetter
	{
		public readonly Type m_ParamsSetter;

		public readonly Func<T, TT> poolSetter;

		public DicSetter(Type componentType, Func<T, TT> factory)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			m_ParamsSetter = componentType;
			poolSetter = factory;
		}
	}

	public sealed class DescriptorSetter
	{
		public readonly Type dispatcherSetter;

		public readonly Func<TT, T, TT> m_ListSetter;

		public DescriptorSetter(Type componentType, Func<TT, T, TT> factory)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			dispatcherSetter = componentType;
			m_ListSetter = factory;
		}
	}

	private class QueueSetter : ReponseSetter<TT>
	{
		private readonly ProcessorSetter<T, TT> collectionSetter;

		private readonly DicSetter _ManagerSetter;

		private static object PopStatus;

		public QueueSetter(ProcessorSetter<T, TT> registrations, DicSetter newRegistration)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			collectionSetter = registrations;
			_ManagerSetter = newRegistration;
		}

		void ReponseSetter<TT>.InsteadOf<TRegistrationType>()
		{
			if (_ManagerSetter.m_ParamsSetter != typeof(TRegistrationType))
			{
				collectionSetter.EnsureNoDuplicateRegistrationType(_ManagerSetter.m_ParamsSetter);
			}
			int index = collectionSetter.EnsureRegistrationExists<TRegistrationType>();
			collectionSetter.m_InfoSetter[index] = _ManagerSetter;
		}

		void ReponseSetter<TT>.After<TRegistrationType>()
		{
			collectionSetter.EnsureNoDuplicateRegistrationType(_ManagerSetter.m_ParamsSetter);
			int num = collectionSetter.EnsureRegistrationExists<TRegistrationType>();
			collectionSetter.m_InfoSetter.Insert(num + 1, _ManagerSetter);
		}

		void ReponseSetter<TT>.Before<TRegistrationType>()
		{
			collectionSetter.EnsureNoDuplicateRegistrationType(_ManagerSetter.m_ParamsSetter);
			int index = collectionSetter.EnsureRegistrationExists<TRegistrationType>();
			collectionSetter.m_InfoSetter.Insert(index, _ManagerSetter);
		}

		void ReponseSetter<TT>.OnBottom()
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
					collectionSetter.EnsureNoDuplicateRegistrationType(_ManagerSetter.m_ParamsSetter);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
					{
						num2 = 0;
					}
					break;
				default:
					collectionSetter.m_InfoSetter.Add(_ManagerSetter);
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		void ReponseSetter<TT>.OnTop()
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					collectionSetter.m_InfoSetter.Insert(0, _ManagerSetter);
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
					{
						num2 = 2;
					}
					break;
				case 1:
					collectionSetter.EnsureNoDuplicateRegistrationType(_ManagerSetter.m_ParamsSetter);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
					{
						num2 = 0;
					}
					break;
				case 2:
					return;
				}
			}
		}

		internal static bool PostStatus()
		{
			return PopStatus == null;
		}

		internal static object CallStatus()
		{
			return PopStatus;
		}
	}

	private class TokenizerSetter : ProxySetter<TT>
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass3_0<TRegistrationType> where TRegistrationType : TT
		{
			public TokenizerSetter _003C_003E4__this;

			public Func<T, TT> innerComponentFactory;

			internal static object AddStatus;

			public _003C_003Ec__DisplayClass3_0()
			{
				GetterIssuer.DeleteInitializer();
				base._002Ector();
				int num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 != 0)
				{
					num = 0;
				}
				switch (num)
				{
				case 0:
					break;
				}
			}

			internal TT _003CYamlDotNet_002ESerialization_002EITrackingRegistrationLocationSelectionSyntax_003CTComponent_003E_002EInsteadOf_003Eb__0(T arg)
			{
				return _003C_003E4__this.m_AccountSetter.m_ListSetter(innerComponentFactory(arg), arg);
			}

			internal static bool PrepareStatus()
			{
				return AddStatus == null;
			}

			internal static object WriteStatus()
			{
				return AddStatus;
			}
		}

		private readonly ProcessorSetter<T, TT> listenerSetter;

		private readonly DescriptorSetter m_AccountSetter;

		public TokenizerSetter(ProcessorSetter<T, TT> registrations, DescriptorSetter newRegistration)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			listenerSetter = registrations;
			m_AccountSetter = newRegistration;
		}

		void ProxySetter<TT>.InsteadOf<TRegistrationType>()
		{
			_003C_003Ec__DisplayClass3_0<TRegistrationType> CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass3_0<TRegistrationType>();
			CS_0024_003C_003E8__locals4._003C_003E4__this = this;
			if (m_AccountSetter.dispatcherSetter != typeof(TRegistrationType))
			{
				listenerSetter.EnsureNoDuplicateRegistrationType(m_AccountSetter.dispatcherSetter);
			}
			int index = listenerSetter.EnsureRegistrationExists<TRegistrationType>();
			CS_0024_003C_003E8__locals4.innerComponentFactory = listenerSetter.m_InfoSetter[index].poolSetter;
			listenerSetter.m_InfoSetter[index] = new DicSetter(m_AccountSetter.dispatcherSetter, (T arg) => CS_0024_003C_003E8__locals4._003C_003E4__this.m_AccountSetter.m_ListSetter(CS_0024_003C_003E8__locals4.innerComponentFactory(arg), arg));
		}
	}

	[CompilerGenerated]
	private sealed class _003Cget_InReverseOrder_003Ed__10 : IEnumerable<Func<T, TT>>, IEnumerable, IEnumerator<Func<T, TT>>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private Func<T, TT> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public ProcessorSetter<T, TT> _003C_003E4__this;

		private int _003Ci_003E5__2;

		private static object ReadStatus;

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
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003Cget_InReverseOrder_003Ed__10(int _003C_003E1__state)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 2;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 != 0)
			{
				num = 0;
			}
			while (true)
			{
				switch (num)
				{
				case 2:
					this._003C_003E1__state = _003C_003E1__state;
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
					{
						num = 0;
					}
					break;
				default:
					_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 != 0)
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
			int num = 12;
			int num4 = default(int);
			ProcessorSetter<T, TT> processorSetter = default(ProcessorSetter<T, TT>);
			int num3 = default(int);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					case 10:
						_003Ci_003E5__2 = num4;
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
						{
							num2 = 0;
						}
						break;
					case 4:
						_003Ci_003E5__2 = processorSetter.m_InfoSetter.Count - 1;
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 != 0)
						{
							num2 = 5;
						}
						break;
					default:
						num4 = _003Ci_003E5__2 - 1;
						num2 = 10;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
						{
							num2 = 4;
						}
						break;
					case 12:
						num3 = _003C_003E1__state;
						num2 = 11;
						break;
					case 3:
						_003C_003E2__current = processorSetter.m_InfoSetter[_003Ci_003E5__2].poolSetter;
						num2 = 13;
						break;
					case 1:
					case 5:
						if (_003Ci_003E5__2 < 0)
						{
							num2 = 7;
							break;
						}
						goto case 3;
					case 7:
						return false;
					case 2:
						if (num3 == 0)
						{
							_003C_003E1__state = -1;
							num2 = 4;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba != 0)
							{
								num2 = 2;
							}
							break;
						}
						goto end_IL_0012;
					case 11:
						processorSetter = _003C_003E4__this;
						num2 = 2;
						break;
					case 8:
						return false;
					case 9:
						if (num3 != 1)
						{
							num2 = 3;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
							{
								num2 = 8;
							}
							break;
						}
						_003C_003E1__state = -1;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
						{
							num2 = 0;
						}
						break;
					case 13:
						_003C_003E1__state = 1;
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 != 0)
						{
							num2 = 4;
						}
						break;
					case 6:
						return true;
					}
					continue;
					end_IL_0012:
					break;
				}
				num = 9;
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
		IEnumerator<Func<T, TT>> IEnumerable<Func<T, TT>>.GetEnumerator()
		{
			_003Cget_InReverseOrder_003Ed__10 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003Cget_InReverseOrder_003Ed__10(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Func<T, TT>>)this).GetEnumerator();
		}

		internal static bool ViewStatus()
		{
			return ReadStatus == null;
		}

		internal static object InitStatus()
		{
			return ReadStatus;
		}
	}

	private readonly List<DicSetter> m_InfoSetter;

	private static object PublishStatus;

	public int Count => m_InfoSetter.Count;

	public IEnumerable<Func<T, TT>> InReverseOrder
	{
		[IteratorStateMachine(typeof(ProcessorSetter<, >._003Cget_InReverseOrder_003Ed__10))]
		get
		{
			//yield-return decompiler failed: Missing enumeratorCtor.Body
			return new _003Cget_InReverseOrder_003Ed__10(-2)
			{
				_003C_003E4__this = this
			};
		}
	}

	public ProcessorSetter<T, TT> Clone()
	{
		ProcessorSetter<T, TT> processorSetter = new ProcessorSetter<T, TT>();
		foreach (DicSetter item in m_InfoSetter)
		{
			processorSetter.m_InfoSetter.Add(item);
		}
		return processorSetter;
	}

	public void Clear()
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
				m_InfoSetter.Clear();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public void Add(Type componentType, Func<T, TT> factory)
	{
		m_InfoSetter.Add(new DicSetter(componentType, factory));
	}

	public void Remove(Type componentType)
	{
		int num = 6;
		int num2 = num;
		int num3 = default(int);
		while (true)
		{
			switch (num2)
			{
			case 5:
			case 7:
				if (num3 >= m_InfoSetter.Count)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db != 0)
					{
						num2 = 1;
					}
					continue;
				}
				goto default;
			case 6:
				num3 = 0;
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
				{
					num2 = 5;
				}
				continue;
			default:
				if (!(m_InfoSetter[num3].m_ParamsSetter == componentType))
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb != 0)
					{
						num2 = 4;
					}
					continue;
				}
				break;
			case 1:
				throw new KeyNotFoundException(DicSingleton.gE3WbyDVW(0x30B55457 ^ 0x30B50F7B) + componentType.FullName + DicSingleton.gE3WbyDVW(0x3353457 ^ 0x3356F23));
			case 3:
				return;
			case 4:
				num3++;
				num2 = 7;
				continue;
			case 2:
				break;
			}
			m_InfoSetter.RemoveAt(num3);
			num2 = 3;
		}
	}

	public ReponseSetter<TT> CreateRegistrationLocationSelector(Type componentType, Func<T, TT> factory)
	{
		return new QueueSetter(this, new DicSetter(componentType, factory));
	}

	public ProxySetter<TT> CreateTrackingRegistrationLocationSelector(Type componentType, Func<TT, T, TT> factory)
	{
		return new TokenizerSetter(this, new DescriptorSetter(componentType, factory));
	}

	public IEnumerator<Func<T, TT>> GetEnumerator()
	{
		return m_InfoSetter.Select((DicSetter e) => e.poolSetter).GetEnumerator();
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
			default:
				if (registrationType == m_InfoSetter[num3].m_ParamsSetter)
				{
					num2 = 5;
					break;
				}
				num3++;
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
				{
					num2 = 1;
				}
				break;
			case 4:
				return -1;
			case 5:
				return num3;
			case 2:
				num3 = 0;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 != 0)
				{
					num2 = 1;
				}
				break;
			case 1:
			case 3:
				if (num3 >= m_InfoSetter.Count)
				{
					num2 = 4;
					break;
				}
				goto default;
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
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
					{
						num2 = 0;
					}
					break;
				}
				return;
			default:
				throw new InvalidOperationException(DicSingleton.gE3WbyDVW(0x6729A6D ^ 0x672C1F5) + componentType.FullName + DicSingleton.gE3WbyDVW(0x4E8C8248 ^ 0x4E8CD98E));
			}
		}
	}

	private int EnsureRegistrationExists<TRegistrationType>()
	{
		int num = IndexOfRegistration(typeof(TRegistrationType));
		if (num == -1)
		{
			throw new InvalidOperationException(DicSingleton.gE3WbyDVW(-1549341817 ^ -1549357025) + typeof(TRegistrationType).FullName + DicSingleton.gE3WbyDVW(0x5901407C ^ 0x59011C7A));
		}
		return num;
	}

	public ProcessorSetter()
	{
		GetterIssuer.DeleteInitializer();
		m_InfoSetter = new List<DicSetter>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool RegisterStatus()
	{
		return PublishStatus == null;
	}

	internal static object SetupStatus()
	{
		return PublishStatus;
	}
}
