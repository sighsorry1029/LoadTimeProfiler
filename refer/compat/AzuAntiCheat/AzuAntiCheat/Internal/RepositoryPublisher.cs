using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using BepInEx.Configuration;
using HarmonyLib;
using JetBrains.Annotations;
using UnityEngine;

namespace AzuAnticheat.Internal;

[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
[PublicAPI]
[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(1)]
internal class RepositoryPublisher
{
	[HarmonyPatch(typeof(ZRpc), "HandlePackage")]
	[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)]
	private static class MappingPublisher
	{
		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
		public static ZRpc schemaPublisher;

		[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(1)]
		[HarmonyPrefix]
		private static void Prefix(ZRpc __instance)
		{
			schemaPublisher = __instance;
		}
	}

	[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)]
	[HarmonyPatch(typeof(ZNet), "Awake")]
	internal static class StructPublisher
	{
		[CompilerGenerated]
		private sealed class _003C_003CPostfix_003Eg__WatchAdminListChanges_007C0_0_003Ed : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			private _003C_003Ec__DisplayClass0_0 _003C_003E8__1;

			[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(new byte[] { 0, 1 })]
			private List<string> _003CCurrentList_003E5__2;

			[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(new byte[] { 0, 1 })]
			private List<ZNetPeer> _003CadminPeer_003E5__3;

			[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(new byte[] { 0, 1 })]
			private List<ZNetPeer> _003CnonAdminPeer_003E5__4;

			private static _003C_003CPostfix_003Eg__WatchAdminListChanges_007C0_0_003Ed DefineWrapper;

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
			public _003C_003CPostfix_003Eg__WatchAdminListChanges_007C0_0_003Ed(int _003C_003E1__state)
			{
				GetterIssuer.DeleteInitializer();
				base._002Ector();
				int num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 != 0)
				{
					num = 1;
				}
				while (true)
				{
					switch (num)
					{
					default:
						return;
					case 1:
						this._003C_003E1__state = _003C_003E1__state;
						num = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
						{
							num = 0;
						}
						break;
					case 0:
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
				int num = 15;
				bool flag = default(bool);
				int num3 = default(int);
				while (true)
				{
					int num2 = num;
					while (true)
					{
						switch (num2)
						{
						case 10:
							_003CadminPeer_003E5__3 = null;
							num2 = 12;
							continue;
						case 22:
							flag = !_003C_003E8__1._ObjectPublisher.GetList().SequenceEqual(_003CCurrentList_003E5__2);
							num2 = 5;
							continue;
						case 16:
							_003CnonAdminPeer_003E5__4 = ZNet.instance.GetPeers().Except(_003CadminPeer_003E5__3).ToList();
							num2 = 2;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
							{
								num2 = 2;
							}
							continue;
						case 14:
							if (num3 != 0)
							{
								num2 = 5;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
								{
									num2 = 24;
								}
								continue;
							}
							goto default;
						case 8:
							_003C_003E1__state = 1;
							num2 = 6;
							continue;
						case 12:
							_003CnonAdminPeer_003E5__4 = null;
							num2 = 3;
							continue;
						case 4:
						case 9:
							return false;
						default:
							_003C_003E1__state = -1;
							num2 = 25;
							continue;
						case 17:
							_003C_003E8__1._ClassPublisher = AccessTools.DeclaredMethod(typeof(ZNet), DicSingleton.gE3WbyDVW(-1954645236 ^ -1954661360));
							num2 = 11;
							continue;
						case 3:
						case 13:
						case 20:
						case 26:
							break;
						case 2:
							_003CPostfix_003Eg__SendAdmin_007C0_1(_003CnonAdminPeer_003E5__4, isAdmin: false);
							num2 = 19;
							continue;
						case 5:
							if (!flag)
							{
								num2 = 4;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 == 0)
								{
									num2 = 13;
								}
								continue;
							}
							goto case 23;
						case 19:
							_003CPostfix_003Eg__SendAdmin_007C0_1(_003CadminPeer_003E5__3, isAdmin: true);
							num2 = 9;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c != 0)
							{
								num2 = 10;
							}
							continue;
						case 11:
							_003C_003E8__1._ObjectPublisher = (SyncedList)AccessTools.DeclaredField(typeof(ZNet), DicSingleton.gE3WbyDVW(--650088194 ^ 0x26BFC83E)).GetValue(ZNet.instance);
							num2 = 18;
							continue;
						case 21:
						case 24:
							if (num3 == 1)
							{
								goto case 7;
							}
							num2 = 9;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
							{
								num2 = 5;
							}
							continue;
						case 15:
							num3 = _003C_003E1__state;
							num2 = 14;
							continue;
						case 25:
							_003C_003E8__1 = new _003C_003Ec__DisplayClass0_0();
							num2 = 11;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 != 0)
							{
								num2 = 17;
							}
							continue;
						case 6:
							return true;
						case 7:
							_003C_003E1__state = -1;
							num2 = 22;
							continue;
						case 18:
							_003CCurrentList_003E5__2 = new List<string>(_003C_003E8__1._ObjectPublisher.GetList());
							num2 = 20;
							continue;
						case 23:
							_003CCurrentList_003E5__2 = new List<string>(_003C_003E8__1._ObjectPublisher.GetList());
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
							{
								num2 = 1;
							}
							continue;
						case 1:
							_003CadminPeer_003E5__3 = ZNet.instance.GetPeers().Where(delegate(ZNetPeer p)
							{
								int num4 = 1;
								string hostName = default(string);
								bool result = default(bool);
								while (true)
								{
									int num5 = num4;
									int num6;
									while (true)
									{
										switch (num5)
										{
										default:
											if ((object)_003C_003E8__1._ClassPublisher != null)
											{
												num5 = 2;
												if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
												{
													num5 = 2;
												}
												continue;
											}
											num6 = (_003C_003E8__1._ObjectPublisher.Contains(hostName) ? 1 : 0);
											break;
										case 1:
											hostName = p.m_rpc.GetSocket().GetHostName();
											num5 = 0;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
											{
												num5 = 0;
											}
											continue;
										case 2:
											num6 = (((bool)_003C_003E8__1._ClassPublisher.Invoke(ZNet.instance, new object[2] { _003C_003E8__1._ObjectPublisher, hostName })) ? 1 : 0);
											break;
										case 3:
										case 4:
											return result;
										}
										break;
									}
									result = (byte)num6 != 0;
									num4 = 4;
								}
							}).ToList();
							num2 = 16;
							continue;
						}
						break;
					}
					_003C_003E2__current = new WaitForSeconds(30f);
					num = 8;
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

			internal static bool IncludeWrapper()
			{
				return DefineWrapper == null;
			}

			internal static _003C_003CPostfix_003Eg__WatchAdminListChanges_007C0_0_003Ed CheckWrapper()
			{
				return DefineWrapper;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass0_0
		{
			public MethodInfo _ClassPublisher;

			public SyncedList _ObjectPublisher;

			public Func<ZNetPeer, bool> _ConsumerPublisher;

			internal static _003C_003Ec__DisplayClass0_0 RateWrapper;

			public _003C_003Ec__DisplayClass0_0()
			{
				GetterIssuer.DeleteInitializer();
				base._002Ector();
				int num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 != 0)
				{
					num = 0;
				}
				switch (num)
				{
				case 0:
					break;
				}
			}

			internal bool _003CPostfix_003Eb__2(ZNetPeer p)
			{
				int num = 1;
				string hostName = default(string);
				bool result = default(bool);
				while (true)
				{
					int num2 = num;
					int num3;
					while (true)
					{
						switch (num2)
						{
						default:
							if ((object)_ClassPublisher != null)
							{
								num2 = 2;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
								{
									num2 = 2;
								}
								continue;
							}
							num3 = (_ObjectPublisher.Contains(hostName) ? 1 : 0);
							break;
						case 1:
							hostName = p.m_rpc.GetSocket().GetHostName();
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
							{
								num2 = 0;
							}
							continue;
						case 2:
							num3 = (((bool)_ClassPublisher.Invoke(ZNet.instance, new object[2] { _ObjectPublisher, hostName })) ? 1 : 0);
							break;
						case 3:
						case 4:
							return result;
						}
						break;
					}
					result = (byte)num3 != 0;
					num = 4;
				}
			}

			internal static bool ResetWrapper()
			{
				return RateWrapper == null;
			}

			internal static _003C_003Ec__DisplayClass0_0 CustomizeWrapper()
			{
				return RateWrapper;
			}
		}

		internal static StructPublisher StartWrapper;

		[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(1)]
		[HarmonyPostfix]
		private static void Postfix(ZNet __instance)
		{
			_QueuePublisher = __instance.IsServer();
			foreach (RepositoryPublisher item in descriptorPublisher)
			{
				ZRoutedRpc.instance.Register<ZPackage>(item._VisitorPublisher + DicSingleton.gE3WbyDVW(0x548F02D9 ^ 0x548F490F), item.RPC_FromOtherClientConfigSync);
				if (_QueuePublisher)
				{
					item.InitialSyncDone = true;
					UnityEngine.Debug.Log(DicSingleton.gE3WbyDVW(-220409977 ^ -220429193) + item._VisitorPublisher + DicSingleton.gE3WbyDVW(0x7B291245 ^ 0x7B295E49));
				}
			}
			if (_QueuePublisher)
			{
				__instance.StartCoroutine(WatchAdminListChanges());
			}
			[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(1)]
			[IteratorStateMachine(typeof(_003C_003CPostfix_003Eg__WatchAdminListChanges_007C0_0_003Ed))]
			static IEnumerator WatchAdminListChanges()
			{
				int num = 2;
				int num2 = num;
				IEnumerator result = default(IEnumerator);
				_003C_003CPostfix_003Eg__WatchAdminListChanges_007C0_0_003Ed _003C_003CPostfix_003Eg__WatchAdminListChanges_007C0_0_003Ed = default(_003C_003CPostfix_003Eg__WatchAdminListChanges_007C0_0_003Ed);
				while (true)
				{
					switch (num2)
					{
					case 1:
						result = _003C_003CPostfix_003Eg__WatchAdminListChanges_007C0_0_003Ed;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af != 0)
						{
							num2 = 0;
						}
						break;
					default:
						return result;
					case 2:
						_003C_003CPostfix_003Eg__WatchAdminListChanges_007C0_0_003Ed = new _003C_003CPostfix_003Eg__WatchAdminListChanges_007C0_0_003Ed(0);
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a != 0)
						{
							num2 = 1;
						}
						break;
					}
				}
			}
		}

		[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(1)]
		[CompilerGenerated]
		internal static void _003CPostfix_003Eg__SendAdmin_007C0_1(List<ZNetPeer> peers, bool isAdmin)
		{
			ZPackage package = ConfigsToPackage(null, null, new ComparatorBase[1]
			{
				new ComparatorBase
				{
					_DefinitionBase = DicSingleton.gE3WbyDVW(-1880453928 ^ -1880439802),
					_ComposerBase = DicSingleton.gE3WbyDVW(-2133864647 ^ -2133883245),
					globalBase = typeof(bool),
					m_MapBase = isAdmin
				}
			});
			RepositoryPublisher repositoryPublisher = descriptorPublisher.First();
			if (repositoryPublisher != null)
			{
				ZNet.instance.StartCoroutine(repositoryPublisher.sendZPackage(peers, package));
			}
		}

		internal static bool RemoveWrapper()
		{
			return StartWrapper == null;
		}

		internal static StructPublisher ResolveWrapper()
		{
			return StartWrapper;
		}
	}

	[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)]
	[HarmonyPatch(typeof(ZNet), "OnNewConnection")]
	private static class PropertyPublisher
	{
		internal static PropertyPublisher CancelWrapper;

		[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(1)]
		[HarmonyPostfix]
		private static void Postfix(ZNet __instance, ZNetPeer peer)
		{
			if (__instance.IsServer())
			{
				return;
			}
			foreach (RepositoryPublisher item in descriptorPublisher)
			{
				peer.m_rpc.Register<ZPackage>(item._VisitorPublisher + DicSingleton.gE3WbyDVW(0x6BAF1854 ^ 0x6BAF5382), item.RPC_FromServerConfigSync);
			}
		}

		internal static bool ReflectWrapper()
		{
			return CancelWrapper == null;
		}

		internal static PropertyPublisher CollectWrapper()
		{
			return CancelWrapper;
		}
	}

	[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)]
	private class ConfigurationPublisher
	{
		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(new byte[] { 1, 1, 2 })]
		public readonly Dictionary<WrapperPublisher, object> m_SpecificationPublisher;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(new byte[] { 1, 1, 2 })]
		public readonly Dictionary<PrinterPublisher, object> _RefPublisher;

		internal static ConfigurationPublisher ManageWrapper;

		public ConfigurationPublisher()
		{
			GetterIssuer.DeleteInitializer();
			m_SpecificationPublisher = new Dictionary<WrapperPublisher, object>();
			_RefPublisher = new Dictionary<PrinterPublisher, object>();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool ForgotWrapper()
		{
			return ManageWrapper == null;
		}

		internal static ConfigurationPublisher RestartWrapper()
		{
			return ManageWrapper;
		}
	}

	[HarmonyPatch(typeof(ZNet), "Shutdown")]
	[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)]
	private class ObserverPublisher
	{
		private static ObserverPublisher GetWrapper;

		[HarmonyPostfix]
		private static void Postfix()
		{
			int num = 2;
			int num2 = num;
			HashSet<RepositoryPublisher>.Enumerator enumerator = default(HashSet<RepositoryPublisher>.Enumerator);
			RepositoryPublisher current = default(RepositoryPublisher);
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 0:
					return;
				case 2:
					tagPublisher = true;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
					{
						num2 = 0;
					}
					break;
				case 4:
					try
					{
						while (true)
						{
							IL_010d:
							int num3;
							if (!enumerator.MoveNext())
							{
								num3 = 2;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 != 0)
								{
									num3 = 2;
								}
								goto IL_006a;
							}
							goto IL_00e8;
							IL_00e8:
							current = enumerator.Current;
							num3 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
							{
								num3 = 0;
							}
							goto IL_006a;
							IL_006a:
							while (true)
							{
								switch (num3)
								{
								case 5:
									current.IsSourceOfTruth = true;
									num3 = 3;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
									{
										num3 = 1;
									}
									continue;
								default:
								{
									current.resetConfigsFromServer();
									int num4 = 5;
									num3 = num4;
									continue;
								}
								case 3:
									current.InitialSyncDone = false;
									num3 = 1;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
									{
										num3 = 1;
									}
									continue;
								case 4:
									break;
								case 1:
									goto IL_010d;
								case 2:
									goto end_IL_010d;
								}
								break;
							}
							goto IL_00e8;
							continue;
							end_IL_010d:
							break;
						}
					}
					finally
					{
						((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						int num5 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
						{
							num5 = 0;
						}
						switch (num5)
						{
						case 0:
							break;
						}
					}
					goto case 3;
				case 3:
					tagPublisher = false;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
					{
						num2 = 0;
					}
					break;
				case 1:
					enumerator = descriptorPublisher.GetEnumerator();
					num2 = 4;
					break;
				}
			}
		}

		public ObserverPublisher()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool CalculateWrapper()
		{
			return GetWrapper == null;
		}

		internal static ObserverPublisher MoveWrapper()
		{
			return GetWrapper;
		}
	}

	[HarmonyPatch(typeof(ZNet), "RPC_PeerInfo")]
	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
	private class AdapterPublisher
	{
		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		private class ProcPublisher : ZPlayFabSocket, ISocket
		{
			public volatile bool m_RoleBase;

			public volatile int m_PublisherBase;

			public readonly List<ZPackage> baseBase;

			public readonly ISocket m_PrototypeBase;

			private static ProcPublisher RegisterCustomer;

			public ProcPublisher(ISocket original)
			{
				GetterIssuer.DeleteInitializer();
				m_RoleBase = false;
				m_PublisherBase = -1;
				baseBase = new List<ZPackage>();
				m_PrototypeBase = original;
				base._002Ector();
				int num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 != 0)
				{
					num = 0;
				}
				switch (num)
				{
				case 0:
					break;
				}
			}

			public new bool IsConnected()
			{
				return m_PrototypeBase.IsConnected();
			}

			public new ZPackage Recv()
			{
				return m_PrototypeBase.Recv();
			}

			public new int GetSendQueueSize()
			{
				return m_PrototypeBase.GetSendQueueSize();
			}

			public new int GetCurrentSendRate()
			{
				return m_PrototypeBase.GetCurrentSendRate();
			}

			public new bool IsHost()
			{
				return m_PrototypeBase.IsHost();
			}

			public new void Dispose()
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
						m_PrototypeBase.Dispose();
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 != 0)
						{
							num2 = 0;
						}
						break;
					case 0:
						return;
					}
				}
			}

			public new bool GotNewData()
			{
				return m_PrototypeBase.GotNewData();
			}

			public new void Close()
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
						m_PrototypeBase.Close();
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

			public new string GetEndPointString()
			{
				return m_PrototypeBase.GetEndPointString();
			}

			public new void GetAndResetStats(out int totalSent, out int totalRecv)
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
						m_PrototypeBase.GetAndResetStats(out totalSent, out totalRecv);
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
						{
							num2 = 0;
						}
						break;
					case 0:
						return;
					}
				}
			}

			public new void GetConnectionQuality(out float localQuality, out float remoteQuality, out int ping, out float outByteSec, out float inByteSec)
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
						m_PrototypeBase.GetConnectionQuality(out localQuality, out remoteQuality, out ping, out outByteSec, out inByteSec);
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
						{
							num2 = 0;
						}
						break;
					case 0:
						return;
					}
				}
			}

			public new ISocket Accept()
			{
				return m_PrototypeBase.Accept();
			}

			public new int GetHostPort()
			{
				return m_PrototypeBase.GetHostPort();
			}

			public new bool Flush()
			{
				return m_PrototypeBase.Flush();
			}

			public new string GetHostName()
			{
				return m_PrototypeBase.GetHostName();
			}

			public new void VersionMatch()
			{
				int num = 5;
				int num2 = num;
				bool roleBase = default(bool);
				while (true)
				{
					switch (num2)
					{
					default:
						return;
					case 2:
					case 3:
						m_PublisherBase = baseBase.Count;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
						{
							num2 = 0;
						}
						continue;
					case 4:
						if (!roleBase)
						{
							num2 = 3;
							continue;
						}
						break;
					case 0:
						return;
					case 6:
						return;
					case 5:
						roleBase = m_RoleBase;
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 != 0)
						{
							num2 = 0;
						}
						continue;
					case 1:
						break;
					}
					m_PrototypeBase.VersionMatch();
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
					{
						num2 = 0;
					}
				}
			}

			public new void Send(ZPackage pkg)
			{
				int num = 3;
				int num2 = num;
				bool flag = default(bool);
				int num3 = default(int);
				int pos = default(int);
				ZPackage zPackage = default(ZPackage);
				while (true)
				{
					int num4;
					switch (num2)
					{
					case 2:
						pkg.SetPos(0);
						num2 = 8;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 != 0)
						{
							num2 = 3;
						}
						continue;
					default:
						if (!flag)
						{
							num2 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 != 0)
							{
								num2 = 7;
							}
							continue;
						}
						goto case 9;
					case 10:
						num4 = ((!m_RoleBase) ? 1 : 0);
						break;
					case 8:
						num3 = pkg.ReadInt();
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
						{
							num2 = 14;
						}
						continue;
					case 1:
						return;
					case 11:
						return;
					case 12:
						if (num3 != DicSingleton.gE3WbyDVW(-359091888 ^ -359072380).GetStableHashCode())
						{
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
							{
								num2 = 4;
							}
							continue;
						}
						goto case 10;
					case 5:
					case 7:
						pkg.SetPos(pos);
						num2 = 15;
						continue;
					case 13:
						baseBase.Add(zPackage);
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
						{
							num2 = 0;
						}
						continue;
					case 6:
						zPackage.SetPos(pos);
						num2 = 13;
						continue;
					case 15:
						m_PrototypeBase.Send(pkg);
						num2 = 10;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
						{
							num2 = 11;
						}
						continue;
					case 4:
						if (num3 == DicSingleton.gE3WbyDVW(0x3A437A88 ^ 0x3A433662).GetStableHashCode())
						{
							num2 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
							{
								num2 = 10;
							}
							continue;
						}
						num4 = 0;
						break;
					case 3:
						pos = pkg.GetPos();
						num2 = 2;
						continue;
					case 9:
						zPackage = new ZPackage(pkg.GetArray());
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 != 0)
						{
							num2 = 1;
						}
						continue;
					case 14:
						if (num3 != DicSingleton.gE3WbyDVW(0x21AFFB2B ^ 0x21AFB7EB).GetStableHashCode())
						{
							num2 = 12;
							continue;
						}
						goto case 10;
					}
					flag = (byte)num4 != 0;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
					{
						num2 = 0;
					}
				}
			}

			internal static bool SetupCustomer()
			{
				return RegisterCustomer == null;
			}

			internal static ProcPublisher SelectCustomer()
			{
				return RegisterCustomer;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass2_0
		{
			[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
			public ZRpc m_ReaderBase;

			[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
			public ZNet factoryBase;

			[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(new byte[] { 0, 1, 1 })]
			public Dictionary<Assembly, ProcPublisher> m_SetterBase;

			[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
			public ZNetPeer writerBase;

			private static _003C_003Ec__DisplayClass2_0 RunCustomer;

			public _003C_003Ec__DisplayClass2_0()
			{
				GetterIssuer.DeleteInitializer();
				base._002Ector();
				int num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb == 0)
				{
					num = 0;
				}
				switch (num)
				{
				case 0:
					break;
				}
			}

			internal static bool VerifyCustomer()
			{
				return RunCustomer == null;
			}

			internal static _003C_003Ec__DisplayClass2_0 PopCustomer()
			{
				return RunCustomer;
			}
		}

		internal static AdapterPublisher RevertWrapper;

		[HarmonyPrefix]
		[HarmonyPriority(800)]
		private static void Prefix([_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(new byte[] { 2, 1, 1 })] ref Dictionary<Assembly, ProcPublisher> __state, ZNet __instance, ZRpc rpc)
		{
			int num = 12;
			FieldInfo fieldInfo = default(FieldInfo);
			ZNetPeer zNetPeer = default(ZNetPeer);
			ProcPublisher procPublisher = default(ProcPublisher);
			ZPlayFabSocket zPlayFabSocket = default(ZPlayFabSocket);
			bool flag2 = default(bool);
			bool flag = default(bool);
			bool flag3 = default(bool);
			while (true)
			{
				int num2 = num;
				int num3;
				while (true)
				{
					switch (num2)
					{
					case 6:
					case 16:
						fieldInfo.SetValue(zNetPeer, procPublisher);
						num2 = 10;
						continue;
					case 10:
					case 17:
						if (__state == null)
						{
							num2 = 15;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec != 0)
							{
								num2 = 1;
							}
							continue;
						}
						goto case 5;
					case 3:
						zPlayFabSocket = fieldInfo.GetValue(zNetPeer) as ZPlayFabSocket;
						num2 = 19;
						continue;
					case 14:
						if (zNetPeer != null)
						{
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
							{
								num2 = 1;
							}
							continue;
						}
						num3 = 0;
						break;
					case 13:
						if (!flag2)
						{
							num2 = 6;
							continue;
						}
						goto case 9;
					case 12:
						flag = __instance.IsServer();
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
						{
							num2 = 11;
						}
						continue;
					case 19:
						flag2 = zPlayFabSocket != null;
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
						{
							num2 = 13;
						}
						continue;
					case 15:
						__state = new Dictionary<Assembly, ProcPublisher>();
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 == 0)
						{
							num2 = 5;
						}
						continue;
					case 8:
						procPublisher = new ProcPublisher(rpc.GetSocket());
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
						{
							num2 = 0;
						}
						continue;
					case 5:
						__state[Assembly.GetExecutingAssembly()] = procPublisher;
						num2 = 7;
						continue;
					case 9:
						typeof(ZPlayFabSocket).GetField(DicSingleton.gE3WbyDVW(-428683152 ^ -428696340)).SetValue(procPublisher, zPlayFabSocket.m_remotePlayerId);
						num2 = 16;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 != 0)
						{
							num2 = 16;
						}
						continue;
					case 18:
						if (!flag3)
						{
							num2 = 17;
							continue;
						}
						goto case 2;
					case 2:
						fieldInfo = AccessTools.DeclaredField(typeof(ZNetPeer), DicSingleton.gE3WbyDVW(0x7A125A0E ^ 0x7A121678));
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
						{
							num2 = 3;
						}
						continue;
					default:
						AccessTools.DeclaredField(typeof(ZRpc), DicSingleton.gE3WbyDVW(0xB967DC8 ^ 0xB9631BE)).SetValue(rpc, procPublisher);
						num2 = 4;
						continue;
					case 4:
						zNetPeer = AccessTools.DeclaredMethod(typeof(ZNet), DicSingleton.gE3WbyDVW(-1180565667 ^ -1180585001), new Type[1] { typeof(ZRpc) }).Invoke(__instance, new object[1] { rpc }) as ZNetPeer;
						num2 = 14;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
						{
							num2 = 13;
						}
						continue;
					case 7:
						return;
					case 11:
						if (!flag)
						{
							return;
						}
						num2 = 8;
						continue;
					case 1:
						num3 = ((ZNet.m_onlineBackend != OnlineBackendType.Steamworks) ? 1 : 0);
						break;
					}
					break;
				}
				flag3 = (byte)num3 != 0;
				num = 18;
			}
		}

		[HarmonyPostfix]
		private static void Postfix(Dictionary<Assembly, ProcPublisher> __state, ZNet __instance, ZRpc rpc)
		{
			_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass2_0();
			CS_0024_003C_003E8__locals15.m_ReaderBase = rpc;
			CS_0024_003C_003E8__locals15.factoryBase = __instance;
			CS_0024_003C_003E8__locals15.m_SetterBase = __state;
			if (CS_0024_003C_003E8__locals15.factoryBase.IsServer())
			{
				object obj = AccessTools.DeclaredMethod(typeof(ZNet), DicSingleton.gE3WbyDVW(-359091888 ^ -359072294), new Type[1] { typeof(ZRpc) }).Invoke(CS_0024_003C_003E8__locals15.factoryBase, new object[1] { CS_0024_003C_003E8__locals15.m_ReaderBase });
				CS_0024_003C_003E8__locals15.writerBase = obj as ZNetPeer;
				if (CS_0024_003C_003E8__locals15.writerBase == null)
				{
					SendBufferedData();
				}
				else
				{
					CS_0024_003C_003E8__locals15.factoryBase.StartCoroutine(sendAsync());
				}
			}
			void SendBufferedData()
			{
				int num = 15;
				int num3 = default(int);
				ProcPublisher procPublisher = default(ProcPublisher);
				ZNetPeer zNetPeer = default(ZNetPeer);
				bool flag4 = default(bool);
				bool flag3 = default(bool);
				bool flag5 = default(bool);
				bool flag = default(bool);
				bool flag2 = default(bool);
				while (true)
				{
					int num2 = num;
					while (true)
					{
						switch (num2)
						{
						case 8:
							num3 = 0;
							num2 = 21;
							continue;
						case 11:
							procPublisher.m_PrototypeBase.VersionMatch();
							num2 = 20;
							continue;
						case 5:
							zNetPeer = AccessTools.DeclaredMethod(typeof(ZNet), DicSingleton.gE3WbyDVW(-243097544 ^ -243077966), new Type[1] { typeof(ZRpc) }).Invoke(CS_0024_003C_003E8__locals15.factoryBase, new object[1] { CS_0024_003C_003E8__locals15.m_ReaderBase }) as ZNetPeer;
							num2 = 16;
							continue;
						case 12:
							flag4 = num3 == procPublisher.m_PublisherBase;
							num2 = 7;
							continue;
						case 20:
							return;
						case 2:
							procPublisher.m_PrototypeBase.VersionMatch();
							num2 = 6;
							continue;
						case 10:
							if (!flag3)
							{
								return;
							}
							num2 = 11;
							continue;
						case 9:
							flag3 = procPublisher.baseBase.Count == procPublisher.m_PublisherBase;
							num = 10;
							break;
						case 18:
							AccessTools.DeclaredField(typeof(ZRpc), DicSingleton.gE3WbyDVW(0x9000142 ^ 0x9004D34)).SetValue(CS_0024_003C_003E8__locals15.m_ReaderBase, procPublisher.m_PrototypeBase);
							num = 5;
							break;
						case 6:
							procPublisher.m_PrototypeBase.Send(procPublisher.baseBase[num3]);
							num2 = 17;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
							{
								num2 = 13;
							}
							continue;
						case 19:
							if (flag5)
							{
								num2 = 22;
								continue;
							}
							goto case 13;
						case 13:
							procPublisher = CS_0024_003C_003E8__locals15.m_SetterBase[Assembly.GetExecutingAssembly()];
							num2 = 2;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
							{
								num2 = 4;
							}
							continue;
						case 17:
							num3++;
							num2 = 3;
							continue;
						case 16:
							flag5 = zNetPeer != null;
							num2 = 19;
							continue;
						case 7:
							if (flag4)
							{
								num2 = 2;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 != 0)
								{
									num2 = 1;
								}
								continue;
							}
							goto case 6;
						case 1:
							if (flag)
							{
								num2 = 18;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
								{
									num2 = 16;
								}
								continue;
							}
							goto case 13;
						case 3:
						case 21:
							flag2 = num3 < procPublisher.baseBase.Count;
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
							{
								num2 = 0;
							}
							continue;
						default:
							if (!flag2)
							{
								num2 = 9;
								continue;
							}
							goto case 12;
						case 4:
							procPublisher.m_RoleBase = true;
							num2 = 4;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
							{
								num2 = 8;
							}
							continue;
						case 14:
							flag = procPublisher != null;
							num2 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 == 0)
							{
								num2 = 1;
							}
							continue;
						case 22:
							AccessTools.DeclaredField(typeof(ZNetPeer), DicSingleton.gE3WbyDVW(-25744665 ^ -25729391)).SetValue(zNetPeer, procPublisher.m_PrototypeBase);
							num2 = 13;
							continue;
						case 15:
							procPublisher = CS_0024_003C_003E8__locals15.m_ReaderBase.GetSocket() as ProcPublisher;
							num2 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
							{
								num2 = 14;
							}
							continue;
						}
						break;
					}
				}
			}
			[IteratorStateMachine(typeof(_003C_003Ec__DisplayClass2_0.InvocationBase))]
			IEnumerator sendAsync()
			{
				int num = 3;
				int num2 = num;
				_003C_003Ec__DisplayClass2_0.InvocationBase invocationBase = default(_003C_003Ec__DisplayClass2_0.InvocationBase);
				IEnumerator result = default(IEnumerator);
				while (true)
				{
					switch (num2)
					{
					case 2:
						invocationBase._InterpreterBase = CS_0024_003C_003E8__locals15;
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f != 0)
						{
							num2 = 1;
						}
						break;
					default:
						return result;
					case 3:
						invocationBase = new _003C_003Ec__DisplayClass2_0.InvocationBase(0);
						num2 = 2;
						break;
					case 1:
						result = invocationBase;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 != 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			}
		}

		public AdapterPublisher()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool InvokeCustomer()
		{
			return RevertWrapper == null;
		}

		internal static AdapterPublisher PublishCustomer()
		{
			return RevertWrapper;
		}
	}

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
	private class ComparatorBase
	{
		public string _DefinitionBase;

		public string _ComposerBase;

		public Type globalBase;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
		public object m_MapBase;

		private static ComparatorBase MapCustomer;

		public ComparatorBase()
		{
			GetterIssuer.DeleteInitializer();
			_DefinitionBase = null;
			_ComposerBase = null;
			globalBase = null;
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool NewCustomer()
		{
			return MapCustomer == null;
		}

		internal static ComparatorBase AddCustomer()
		{
			return MapCustomer;
		}
	}

	[HarmonyPatch(typeof(ConfigEntryBase), "GetSerializedValue")]
	[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)]
	private static class HelperBase
	{
		internal static HelperBase PrepareCustomer;

		[HarmonyPrefix]
		[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(1)]
		private static bool Prefix(ConfigEntryBase __instance, ref string __result)
		{
			int num = 3;
			bool result = default(bool);
			bool flag = default(bool);
			WrapperPublisher wrapperPublisher = default(WrapperPublisher);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					int num3;
					switch (num2)
					{
					case 5:
						result = false;
						num2 = 7;
						continue;
					case 6:
						if (!flag)
						{
							num2 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
							{
								num2 = 0;
							}
							continue;
						}
						goto default;
					case 3:
						wrapperPublisher = configData(__instance);
						num = 2;
						break;
					case 2:
						if (wrapperPublisher != null)
						{
							num = 10;
							break;
						}
						num3 = 1;
						goto IL_0150;
					case 4:
					case 7:
					case 8:
						return result;
					default:
						result = true;
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
						{
							num2 = 0;
						}
						continue;
					case 1:
					case 9:
						__result = TomlTypeConverter.ConvertToString(wrapperPublisher.serverPublisher, __instance.SettingType);
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
						{
							num2 = 5;
						}
						continue;
					case 10:
						{
							num3 = (isWritableConfig(wrapperPublisher) ? 1 : 0);
							goto IL_0150;
						}
						IL_0150:
						flag = (byte)num3 != 0;
						num2 = 6;
						continue;
					}
					break;
				}
			}
		}

		internal static bool WriteCustomer()
		{
			return PrepareCustomer == null;
		}

		internal static HelperBase PrintCustomer()
		{
			return PrepareCustomer;
		}
	}

	[HarmonyPatch(typeof(ConfigEntryBase), "SetSerializedValue")]
	[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)]
	private static class ExceptionBase
	{
		private static ExceptionBase CompareCustomer;

		[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(1)]
		[HarmonyPrefix]
		private static bool Prefix(ConfigEntryBase __instance, string value)
		{
			int num = 4;
			WrapperPublisher wrapperPublisher = default(WrapperPublisher);
			bool result = default(bool);
			bool flag = default(bool);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					int num3;
					switch (num2)
					{
					case 4:
						wrapperPublisher = configData(__instance);
						num2 = 3;
						continue;
					case 2:
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
						{
							num2 = 0;
						}
						continue;
					case 11:
						goto end_IL_0012;
					default:
						return result;
					case 3:
						if (wrapperPublisher == null)
						{
							num2 = 9;
							continue;
						}
						goto case 6;
					case 6:
						num3 = ((wrapperPublisher.serverPublisher == null) ? 1 : 0);
						break;
					case 7:
						if (flag)
						{
							num2 = 11;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 != 0)
							{
								num2 = 11;
							}
							continue;
						}
						goto case 2;
					case 1:
						try
						{
							wrapperPublisher.serverPublisher = TomlTypeConverter.ConvertToValue(value, __instance.SettingType);
							int num4 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 != 0)
							{
								num4 = 0;
							}
							switch (num4)
							{
							case 0:
								break;
							}
						}
						catch (Exception ex)
						{
							int num5 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
							{
								num5 = 1;
							}
							while (true)
							{
								switch (num5)
								{
								case 1:
									UnityEngine.Debug.LogWarning(string.Format(DicSingleton.gE3WbyDVW(--1509395337 ^ 0x59F7C775), __instance.Definition, ex.Message, value));
									num5 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
									{
										num5 = 0;
									}
									continue;
								case 0:
									break;
								}
								break;
							}
						}
						goto case 5;
					case 5:
						result = false;
						num2 = 10;
						continue;
					case 9:
						num3 = 1;
						break;
					}
					flag = (byte)num3 != 0;
					num2 = 7;
					continue;
					end_IL_0012:
					break;
				}
				result = true;
				num = 8;
			}
		}

		internal static bool CloneCustomer()
		{
			return CompareCustomer == null;
		}

		internal static ExceptionBase ReadCustomer()
		{
			return CompareCustomer;
		}
	}

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
	private class ItemBase : Exception
	{
		public string contextBase;

		public string m_MapperBase;

		public string m_IdentifierBase;

		private static ItemBase ViewCustomer;

		public ItemBase()
		{
			GetterIssuer.DeleteInitializer();
			contextBase = null;
			m_MapperBase = null;
			m_IdentifierBase = "";
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool InitCustomer()
		{
			return ViewCustomer == null;
		}

		internal static ItemBase PatchCustomer()
		{
			return ViewCustomer;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_0<T>
	{
		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		public ImporterPublisher<T> syncedEntry;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		public RepositoryPublisher _003C_003E4__this;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		public ConfigEntry<T> configEntry;

		private static object LogoutCustomer;

		public _003C_003Ec__DisplayClass34_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)]
		internal void _003CAddConfigEntry_003Eb__0(object _, EventArgs _)
		{
			int num = 4;
			int num2 = num;
			bool flag = default(bool);
			while (true)
			{
				int num3;
				switch (num2)
				{
				default:
					num3 = (syncedEntry._AlgoPublisher ? 1 : 0);
					break;
				case 4:
					if (tagPublisher)
					{
						num2 = 3;
						continue;
					}
					goto default;
				case 1:
					return;
				case 5:
					return;
				case 2:
					_003C_003E4__this.Broadcast(ZRoutedRpc.Everybody, configEntry);
					num2 = 5;
					continue;
				case 6:
					if (!flag)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 2;
				case 3:
					num3 = 0;
					break;
				}
				flag = (byte)num3 != 0;
				num2 = 6;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
				{
					num2 = 6;
				}
			}
		}

		internal static bool CountCustomer()
		{
			return LogoutCustomer == null;
		}

		internal static object SetCustomer()
		{
			return LogoutCustomer;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass36_0
	{
		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		public RepositoryPublisher _ExpressionBase;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		public PrinterPublisher m_ProductBase;

		internal static _003C_003Ec__DisplayClass36_0 PushCustomer;

		public _003C_003Ec__DisplayClass36_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal void _003CAddCustomValue_003Eb__1()
		{
			int num = 1;
			int num2 = num;
			bool flag = default(bool);
			while (true)
			{
				switch (num2)
				{
				case 1:
					flag = !tagPublisher;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
					{
						num2 = 0;
					}
					continue;
				case 2:
					_ExpressionBase.Broadcast(ZRoutedRpc.Everybody, m_ProductBase);
					num2 = 3;
					continue;
				case 3:
					return;
				}
				if (!flag)
				{
					return;
				}
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 != 0)
				{
					num2 = 2;
				}
			}
		}

		internal static bool ValidateCustomer()
		{
			return PushCustomer == null;
		}

		internal static _003C_003Ec__DisplayClass36_0 EnableCustomer()
		{
			return PushCustomer;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass51_0
	{
		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		public WrapperPublisher m_RegistryBase;

		internal static _003C_003Ec__DisplayClass51_0 SortCustomer;

		public _003C_003Ec__DisplayClass51_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)]
		internal bool _003CisWritableConfig_003Eb__0(RepositoryPublisher cs)
		{
			return cs.dispatcherPublisher.Contains(m_RegistryBase);
		}

		internal static bool InsertCustomer()
		{
			return SortCustomer == null;
		}

		internal static _003C_003Ec__DisplayClass51_0 FindCustomer()
		{
			return SortCustomer;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass55_0
	{
		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		public ZNetPeer _StateBase;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		public RepositoryPublisher _ValueBase;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		public ZRoutedRpc decoratorBase;

		private static _003C_003Ec__DisplayClass55_0 VisitCustomer;

		public _003C_003Ec__DisplayClass55_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool OrderCustomer()
		{
			return VisitCustomer == null;
		}

		internal static _003C_003Ec__DisplayClass55_0 UpdateCustomer()
		{
			return VisitCustomer;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass56_0
	{
		public long _PageBase;

		internal static _003C_003Ec__DisplayClass56_0 InterruptCustomer;

		public _003C_003Ec__DisplayClass56_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)]
		internal bool _003CsendZPackage_003Eb__0(ZNetPeer p)
		{
			return p.m_uid == _PageBase;
		}

		internal static bool DeleteCustomer()
		{
			return InterruptCustomer == null;
		}

		internal static _003C_003Ec__DisplayClass56_0 FillCustomer()
		{
			return InterruptCustomer;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass57_0
	{
		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		public RepositoryPublisher parserBase;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		public ZPackage requestBase;

		internal static _003C_003Ec__DisplayClass57_0 FlushCustomer;

		public _003C_003Ec__DisplayClass57_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)]
		internal IEnumerator<bool> _003CsendZPackage_003Eb__1(ZNetPeer p)
		{
			return parserBase.distributeConfigToPeers(p, requestBase);
		}

		internal static bool DestroyCustomer()
		{
			return FlushCustomer == null;
		}

		internal static _003C_003Ec__DisplayClass57_0 ComputeCustomer()
		{
			return FlushCustomer;
		}
	}

	[CompilerGenerated]
	private sealed class _003CdistributeConfigToPeers_003Ed__55 : IEnumerator<bool>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private bool _003C_003E2__current;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		public ZNetPeer peer;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		public ZPackage package;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		public RepositoryPublisher _003C_003E4__this;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		private _003C_003Ec__DisplayClass55_0 _003C_003E8__1;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		private byte[] _003Cdata_003E5__2;

		private int _003Cfragments_003E5__3;

		private long _003CpackageIdentifier_003E5__4;

		private int _003Cfragment_003E5__5;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		private ZPackage _003CfragmentedPackage_003E5__6;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		private IEnumerator<bool> _003C_003Es__7;

		private bool _003Cwait_003E5__8;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		private IEnumerator<bool> _003C_003Es__9;

		private bool _003Cwait_003E5__10;

		private static _003CdistributeConfigToPeers_003Ed__55 DisableCustomer;

		bool IEnumerator<bool>.Current
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
			[return: _003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CdistributeConfigToPeers_003Ed__55(int _003C_003E1__state)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
				{
					num = 1;
				}
			}
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = 10;
			int num2 = num;
			int num3 = default(int);
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 10:
					num3 = _003C_003E1__state;
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
					{
						num2 = 9;
					}
					break;
				case 8:
					try
					{
						return;
					}
					finally
					{
						_003C_003Em__Finally2();
						int num4 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
						{
							num4 = 0;
						}
						switch (num4)
						{
						case 0:
							break;
						}
					}
				case 2:
					return;
				case 1:
					num2 = 8;
					break;
				case 15:
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
					{
						num2 = 1;
					}
					break;
				case 0:
					return;
				case 4:
				case 16:
					if (num3 != 1)
					{
						num2 = 11;
						break;
					}
					goto case 15;
				case 17:
					return;
				case 3:
				case 12:
					if (num3 != -3)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 15;
				case 5:
				case 11:
					if (num3 != 3)
					{
						num2 = 2;
						break;
					}
					goto case 1;
				case 14:
					try
					{
						return;
					}
					finally
					{
						_003C_003Em__Finally1();
						int num5 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
						{
							num5 = 0;
						}
						switch (num5)
						{
						case 0:
							break;
						}
					}
				case 6:
					return;
				case 7:
					return;
				case 9:
					if (num3 > -3)
					{
						num2 = 11;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 == 0)
						{
							num2 = 16;
						}
						break;
					}
					goto case 13;
				case 13:
					if (num3 != -4)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
						{
							num2 = 3;
						}
						break;
					}
					goto case 1;
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int num;
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E8__1 = new _003C_003Ec__DisplayClass55_0();
					_003C_003E8__1._StateBase = peer;
					_003C_003E8__1._ValueBase = _003C_003E4__this;
					_003C_003E8__1.decoratorBase = ZRoutedRpc.instance;
					if (_003C_003E8__1.decoratorBase == null)
					{
						return false;
					}
					_003Cdata_003E5__2 = package.GetArray();
					if (_003Cdata_003E5__2 != null && _003Cdata_003E5__2.LongLength > 250000)
					{
						_003Cfragments_003E5__3 = (int)(1 + (_003Cdata_003E5__2.LongLength - 1) / 250000);
						_003CpackageIdentifier_003E5__4 = ++_ThreadPublisher;
						_003Cfragment_003E5__5 = 0;
						goto IL_02bb;
					}
					_003C_003Es__9 = waitForQueue().GetEnumerator();
					_003C_003E1__state = -4;
					goto IL_0333;
				case 1:
					_003C_003E1__state = -3;
					goto IL_0182;
				case 2:
					_003C_003E1__state = -1;
					goto IL_02a1;
				case 3:
					{
						_003C_003E1__state = -4;
						goto IL_0333;
					}
					IL_0182:
					if (_003C_003Es__7.MoveNext())
					{
						_003Cwait_003E5__8 = _003C_003Es__7.Current;
						_003C_003E2__current = _003Cwait_003E5__8;
						_003C_003E1__state = 1;
						return true;
					}
					_003C_003Em__Finally1();
					_003C_003Es__7 = null;
					if (!_003C_003E8__1._StateBase.m_socket.IsConnected())
					{
						return false;
					}
					_003CfragmentedPackage_003E5__6 = new ZPackage();
					_003CfragmentedPackage_003E5__6.Write((byte)2);
					_003CfragmentedPackage_003E5__6.Write(_003CpackageIdentifier_003E5__4);
					_003CfragmentedPackage_003E5__6.Write(_003Cfragment_003E5__5);
					_003CfragmentedPackage_003E5__6.Write(_003Cfragments_003E5__3);
					_003CfragmentedPackage_003E5__6.Write(_003Cdata_003E5__2.Skip(250000 * _003Cfragment_003E5__5).Take(250000).ToArray());
					SendPackage(_003CfragmentedPackage_003E5__6);
					if (_003Cfragment_003E5__5 != _003Cfragments_003E5__3 - 1)
					{
						_003C_003E2__current = true;
						_003C_003E1__state = 2;
						return true;
					}
					goto IL_02a1;
					IL_0333:
					if (_003C_003Es__9.MoveNext())
					{
						_003Cwait_003E5__10 = _003C_003Es__9.Current;
						_003C_003E2__current = _003Cwait_003E5__10;
						_003C_003E1__state = 3;
						return true;
					}
					_003C_003Em__Finally2();
					_003C_003Es__9 = null;
					SendPackage(package);
					break;
					IL_02a1:
					_003CfragmentedPackage_003E5__6 = null;
					num = _003Cfragment_003E5__5 + 1;
					_003Cfragment_003E5__5 = num;
					goto IL_02bb;
					IL_02bb:
					if (_003Cfragment_003E5__5 < _003Cfragments_003E5__3)
					{
						_003C_003Es__7 = waitForQueue().GetEnumerator();
						_003C_003E1__state = -3;
						goto IL_0182;
					}
					break;
				}
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
			void SendPackage(ZPackage pkg)
			{
				int num2 = 6;
				string text = default(string);
				bool queuePublisher = default(bool);
				while (true)
				{
					int num3 = num2;
					while (true)
					{
						switch (num3)
						{
						default:
							return;
						case 3:
							((_003C_003Ec__DisplayClass55_0)this)._StateBase.m_rpc.Invoke(text, pkg);
							num3 = 2;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 == 0)
							{
								num3 = 1;
							}
							continue;
						case 5:
							queuePublisher = _QueuePublisher;
							num3 = 4;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
							{
								num3 = 0;
							}
							continue;
						case 6:
							text = ((_003C_003Ec__DisplayClass55_0)this)._ValueBase._VisitorPublisher + DicSingleton.gE3WbyDVW(0x4097B854 ^ 0x4097F382);
							num3 = 5;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
							{
								num3 = 0;
							}
							continue;
						case 2:
							return;
						case 4:
							if (!queuePublisher)
							{
								break;
							}
							goto end_IL_0012;
						case 0:
							return;
						case 1:
							break;
						}
						((_003C_003Ec__DisplayClass55_0)this).decoratorBase.InvokeRoutedRPC(((_003C_003Ec__DisplayClass55_0)this)._StateBase.m_server ? 0 : ((_003C_003Ec__DisplayClass55_0)this)._StateBase.m_uid, text, pkg);
						num3 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
						{
							num3 = 0;
						}
						continue;
						end_IL_0012:
						break;
					}
					num2 = 3;
				}
			}
			[IteratorStateMachine(typeof(_003C_003Ec__DisplayClass55_0.BroadcasterBase))]
			IEnumerable<bool> waitForQueue()
			{
				//yield-return decompiler failed: Missing enumeratorCtor.Body
				return new _003C_003Ec__DisplayClass55_0.BroadcasterBase(-2)
				{
					_TestsBase = this
				};
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			int num = 2;
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					default:
						_003C_003Es__7.Dispose();
						num2 = 4;
						break;
					case 3:
						return;
					case 1:
						if (_003C_003Es__7 == null)
						{
							goto end_IL_0012;
						}
						goto default;
					case 4:
						return;
					case 2:
						_003C_003E1__state = -1;
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
						{
							num2 = 0;
						}
						break;
					}
					continue;
					end_IL_0012:
					break;
				}
				num = 3;
			}
		}

		private void _003C_003Em__Finally2()
		{
			int num = 4;
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					default:
						return;
					case 3:
						if (_003C_003Es__9 == null)
						{
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
							{
								num2 = 0;
							}
							continue;
						}
						break;
					case 0:
						return;
					case 1:
						return;
					case 2:
						break;
					case 4:
						goto end_IL_0012;
					}
					_003C_003Es__9.Dispose();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 != 0)
					{
						num2 = 0;
					}
					continue;
					end_IL_0012:
					break;
				}
				_003C_003E1__state = -1;
				num = 3;
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		internal static bool QueryCustomer()
		{
			return DisableCustomer == null;
		}

		internal static _003CdistributeConfigToPeers_003Ed__55 AwakeCustomer()
		{
			return DisableCustomer;
		}
	}

	[CompilerGenerated]
	private sealed class _003CsendZPackage_003Ed__57 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		private object _003C_003E2__current;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(new byte[] { 0, 1 })]
		public List<ZNetPeer> peers;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		public ZPackage package;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		public RepositoryPublisher _003C_003E4__this;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		private _003C_003Ec__DisplayClass57_0 _003C_003E8__1;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		private byte[] _003CrawData_003E5__2;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(new byte[] { 0, 1 })]
		private List<IEnumerator<bool>> _003Cwriters_003E5__3;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		private ZPackage _003CcompressedPackage_003E5__4;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		private MemoryStream _003Coutput_003E5__5;

		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		private DeflateStream _003CdeflateStream_003E5__6;

		internal static _003CsendZPackage_003Ed__57 InstantiateCustomer;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			[return: _003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			[return: _003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CsendZPackage_003Ed__57(int _003C_003E1__state)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
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
			int num = 1;
			int num3 = default(int);
			bool flag = default(bool);
			bool flag3 = default(bool);
			bool flag2 = default(bool);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					int num6;
					switch (num2)
					{
					case 12:
						return false;
					case 38:
						return false;
					case 26:
						_003CdeflateStream_003E5__6 = new DeflateStream(_003Coutput_003E5__5, System.IO.Compression.CompressionLevel.Optimal);
						num2 = 13;
						continue;
					case 1:
						num3 = _003C_003E1__state;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd != 0)
						{
							num2 = 0;
						}
						continue;
					case 25:
						if (!flag)
						{
							_003CrawData_003E5__2 = _003C_003E8__1.requestBase.GetArray();
							num2 = 33;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
							{
								num2 = 13;
							}
						}
						else
						{
							num2 = 2;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 != 0)
							{
								num2 = 12;
							}
						}
						continue;
					case 17:
						_003C_003E8__1.requestBase = package;
						num = 29;
						break;
					case 28:
						_003C_003E8__1.parserBase = _003C_003E4__this;
						num2 = 17;
						continue;
					case 5:
						_003C_003E1__state = 1;
						num2 = 8;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
						{
							num2 = 23;
						}
						continue;
					case 20:
						if (!flag3)
						{
							num2 = 7;
							continue;
						}
						goto case 9;
					case 21:
						_003CcompressedPackage_003E5__4.Write((byte)4);
						num2 = 24;
						continue;
					case 13:
						try
						{
							_003CdeflateStream_003E5__6.Write(_003CrawData_003E5__2, 0, _003CrawData_003E5__2.Length);
							int num4 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
							{
								num4 = 0;
							}
							switch (num4)
							{
							case 0:
								break;
							}
						}
						finally
						{
							if (_003CdeflateStream_003E5__6 != null)
							{
								int num5 = 1;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 != 0)
								{
									num5 = 0;
								}
								while (true)
								{
									switch (num5)
									{
									case 1:
										((IDisposable)_003CdeflateStream_003E5__6).Dispose();
										num5 = 0;
										if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f != 0)
										{
											num5 = 0;
										}
										continue;
									case 0:
										break;
									}
									break;
								}
							}
						}
						goto case 6;
					case 34:
						_003CcompressedPackage_003E5__4 = null;
						num2 = 31;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c == 0)
						{
							num2 = 26;
						}
						continue;
					case 8:
						_003C_003E8__1.requestBase = _003CcompressedPackage_003E5__4;
						num2 = 34;
						continue;
					case 24:
						_003Coutput_003E5__5 = new MemoryStream();
						num2 = 26;
						continue;
					case 23:
						return true;
					case 27:
						_003C_003E1__state = -1;
						num2 = 32;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
						{
							num2 = 5;
						}
						continue;
					case 11:
					case 14:
						return false;
					case 2:
					case 19:
						_003C_003E1__state = -1;
						num2 = 22;
						continue;
					case 33:
						if (_003CrawData_003E5__2 != null)
						{
							num2 = 37;
							continue;
						}
						num6 = 0;
						goto IL_050c;
					case 15:
						if (!flag2)
						{
							num2 = 38;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa != 0)
							{
								num2 = 25;
							}
							continue;
						}
						goto case 3;
					case 9:
						_003CcompressedPackage_003E5__4 = new ZPackage();
						num = 21;
						break;
					case 3:
						_003C_003E2__current = null;
						num2 = 5;
						continue;
					case 37:
						num6 = ((_003CrawData_003E5__2.LongLength > 10000) ? 1 : 0);
						goto IL_050c;
					default:
						if (num3 != 0)
						{
							goto case 4;
						}
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 != 0)
						{
							num2 = 2;
						}
						continue;
					case 6:
						_003CdeflateStream_003E5__6 = null;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
						{
							num2 = 18;
						}
						continue;
					case 18:
						_003CcompressedPackage_003E5__4.Write(_003Coutput_003E5__5.ToArray());
						num2 = 8;
						continue;
					case 29:
						flag = !ZNet.instance;
						num2 = 25;
						continue;
					case 31:
						_003Coutput_003E5__5 = null;
						num2 = 19;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 == 0)
						{
							num2 = 36;
						}
						continue;
					case 4:
					case 16:
						if (num3 == 1)
						{
							goto case 27;
						}
						num2 = 11;
						continue;
					case 10:
					case 35:
						flag2 = _003Cwriters_003E5__3.Count > 0;
						num2 = 15;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 != 0)
						{
							num2 = 11;
						}
						continue;
					case 22:
						_003C_003E8__1 = new _003C_003Ec__DisplayClass57_0();
						num2 = 28;
						continue;
					case 7:
					case 36:
						_003Cwriters_003E5__3 = (from p in peers
							where p.IsReady()
							select _003C_003E8__1.parserBase.distributeConfigToPeers(p, _003C_003E8__1.requestBase)).ToList();
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
						{
							num2 = 30;
						}
						continue;
					case 30:
						_003Cwriters_003E5__3.RemoveAll((IEnumerator<bool> writer) => !writer.MoveNext());
						num2 = 35;
						continue;
					case 32:
						{
							_003Cwriters_003E5__3.RemoveAll((IEnumerator<bool> writer) => !writer.MoveNext());
							num = 10;
							break;
						}
						IL_050c:
						flag3 = (byte)num6 != 0;
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
						{
							num2 = 20;
						}
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

		internal static bool LoginCustomer()
		{
			return InstantiateCustomer == null;
		}

		internal static _003CsendZPackage_003Ed__57 ConnectCustomer()
		{
			return InstantiateCustomer;
		}
	}

	public static bool tagPublisher;

	public readonly string _VisitorPublisher;

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
	public string _StubPublisher;

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
	public string policyPublisher;

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
	public string strategyPublisher;

	public bool m_ProcessorPublisher;

	private bool? infoPublisher;

	private bool _DicPublisher;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool m_ParamsPublisher;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
	private Action<bool> poolPublisher;

	private static readonly HashSet<RepositoryPublisher> descriptorPublisher;

	private readonly HashSet<WrapperPublisher> dispatcherPublisher;

	private HashSet<PrinterPublisher> _ListPublisher;

	private static bool _QueuePublisher;

	private static bool collectionPublisher;

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
	private WrapperPublisher managerPublisher;

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action tokenizerPublisher;

	private readonly Dictionary<string, SortedDictionary<int, byte[]>> listenerPublisher;

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(new byte[] { 1, 0, 1 })]
	private readonly List<KeyValuePair<long, string>> m_AccountPublisher;

	private static long _ThreadPublisher;

	internal static RepositoryPublisher DisableWrapper;

	public bool IsLocked
	{
		get
		{
			int num = 1;
			int num2 = num;
			bool? flag = default(bool?);
			int result;
			while (true)
			{
				bool num3;
				switch (num2)
				{
				default:
					if (!flag.HasValue)
					{
						num2 = 4;
						continue;
					}
					num3 = flag == true;
					goto IL_00e4;
				case 2:
					result = ((!collectionPublisher) ? 1 : 0);
					break;
				case 4:
					if (managerPublisher == null)
					{
						num2 = 5;
						continue;
					}
					goto case 3;
				case 3:
					num3 = ((IConvertible)managerPublisher.BaseConfig.BoxedValue).ToInt32(CultureInfo.InvariantCulture) != 0;
					goto IL_00e4;
				case 1:
					flag = infoPublisher;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
					{
						num2 = 0;
					}
					continue;
				case 5:
					{
						result = 0;
						break;
					}
					IL_00e4:
					if (num3)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
						{
							num2 = 2;
						}
						continue;
					}
					goto case 5;
				}
				break;
			}
			return (byte)result != 0;
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
					infoPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public bool IsAdmin
	{
		get
		{
			int num = 1;
			int num2 = num;
			int result;
			while (true)
			{
				switch (num2)
				{
				case 2:
					result = (_DicPublisher ? 1 : 0);
					break;
				case 1:
					if (collectionPublisher)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 2;
				default:
					result = 1;
					break;
				}
				break;
			}
			return (byte)result != 0;
		}
	}

	public bool IsSourceOfTruth
	{
		get
		{
			return _DicPublisher;
		}
		private set
		{
			int num = 4;
			int num2 = num;
			bool flag = default(bool);
			while (true)
			{
				switch (num2)
				{
				case 3:
					if (flag)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
						{
							num2 = 0;
						}
						break;
					}
					return;
				default:
					_DicPublisher = value;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
					{
						num2 = 1;
					}
					break;
				case 2:
					return;
				case 5:
					return;
				case 4:
					flag = value != _DicPublisher;
					num2 = 3;
					break;
				case 1:
				{
					Action<bool> action = poolPublisher;
					if (action == null)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
						{
							num2 = 2;
						}
						break;
					}
					action(value);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 == 0)
					{
						num2 = 5;
					}
					break;
				}
				}
			}
		}
	}

	public bool InitialSyncDone
	{
		[CompilerGenerated]
		get
		{
			return m_ParamsPublisher;
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
				case 0:
					return;
				case 1:
					m_ParamsPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
	public event Action<bool> QueryRole
	{
		[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(2)]
		[CompilerGenerated]
		add
		{
			Action<bool> action = poolPublisher;
			Action<bool> action2;
			do
			{
				action2 = action;
				Action<bool> value2 = (Action<bool>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref poolPublisher, value2, action2);
			}
			while ((object)action != action2);
		}
		[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(2)]
		[CompilerGenerated]
		remove
		{
			Action<bool> action = poolPublisher;
			Action<bool> action2;
			do
			{
				action2 = action;
				Action<bool> value2 = (Action<bool>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref poolPublisher, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
	private event Action ReadRole
	{
		[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(2)]
		[CompilerGenerated]
		add
		{
			int num = 5;
			Action action = default(Action);
			Action action2 = default(Action);
			Action value2 = default(Action);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					default:
						return;
					case 0:
						return;
					case 2:
						if ((object)action == action2)
						{
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 != 0)
							{
								num2 = 0;
							}
							continue;
						}
						break;
					case 5:
						action = tokenizerPublisher;
						num2 = 4;
						continue;
					case 4:
						break;
					case 3:
						value2 = (Action)Delegate.Combine(action2, value);
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f == 0)
						{
							num2 = 1;
						}
						continue;
					case 1:
						action = Interlocked.CompareExchange(ref tokenizerPublisher, value2, action2);
						num2 = 2;
						continue;
					}
					break;
				}
				action2 = action;
				num = 3;
			}
		}
		[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(2)]
		[CompilerGenerated]
		remove
		{
			int num = 3;
			int num2 = num;
			Action action2 = default(Action);
			Action action = default(Action);
			Action value2 = default(Action);
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 2:
					action2 = action;
					num2 = 5;
					break;
				case 1:
					if ((object)action == action2)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 != 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 2;
				case 3:
					action = tokenizerPublisher;
					num2 = 2;
					break;
				case 5:
					value2 = (Action)Delegate.Remove(action2, value);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
					{
						num2 = 4;
					}
					break;
				case 0:
					return;
				case 4:
					action = Interlocked.CompareExchange(ref tokenizerPublisher, value2, action2);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb != 0)
					{
						num2 = 1;
					}
					break;
				}
			}
		}
	}

	static RepositoryPublisher()
	{
		int num = 2;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 6:
					collectionPublisher = false;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 != 0)
					{
						num2 = 3;
					}
					continue;
				case 3:
					break;
				case 1:
					tagPublisher = false;
					num2 = 5;
					continue;
				case 0:
					return;
				case 2:
					GetterIssuer.DeleteInitializer();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 != 0)
					{
						num2 = 0;
					}
					continue;
				case 5:
					descriptorPublisher = new HashSet<RepositoryPublisher>();
					num2 = 6;
					continue;
				case 4:
					RuntimeHelpers.RunClassConstructor(typeof(ParamBase).TypeHandle);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b != 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			}
			_ThreadPublisher = 0L;
			num = 4;
		}
	}

	public RepositoryPublisher(string name)
	{
		GetterIssuer.DeleteInitializer();
		m_ProcessorPublisher = false;
		_DicPublisher = true;
		m_ParamsPublisher = false;
		dispatcherPublisher = new HashSet<WrapperPublisher>();
		_ListPublisher = new HashSet<PrinterPublisher>();
		managerPublisher = null;
		listenerPublisher = new Dictionary<string, SortedDictionary<int, byte[]>>();
		m_AccountPublisher = new List<KeyValuePair<long, string>>();
		base._002Ector();
		int num = 3;
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
				new ParamBase(this);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f == 0)
				{
					num2 = 0;
				}
				break;
			case 3:
				_VisitorPublisher = name;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
				{
					num2 = 2;
				}
				break;
			case 2:
				descriptorPublisher.Add(this);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public ImporterPublisher<T> AddConfigEntry<[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)] T>(ConfigEntry<T> configEntry)
	{
		_003C_003Ec__DisplayClass34_0<T> CS_0024_003C_003E8__locals16 = new _003C_003Ec__DisplayClass34_0<T>();
		CS_0024_003C_003E8__locals16._003C_003E4__this = this;
		CS_0024_003C_003E8__locals16.configEntry = configEntry;
		WrapperPublisher wrapperPublisher = configData(CS_0024_003C_003E8__locals16.configEntry);
		CS_0024_003C_003E8__locals16.syncedEntry = wrapperPublisher as ImporterPublisher<T>;
		if (CS_0024_003C_003E8__locals16.syncedEntry == null)
		{
			CS_0024_003C_003E8__locals16.syncedEntry = new ImporterPublisher<T>(CS_0024_003C_003E8__locals16.configEntry);
			AccessTools.DeclaredField(typeof(ConfigDescription), DicSingleton.gE3WbyDVW(0x33F6A245 ^ 0x33F6E787)).SetValue(CS_0024_003C_003E8__locals16.configEntry.Description, new object[1]
			{
				new AnnotationPublisher()
			}.Concat(CS_0024_003C_003E8__locals16.configEntry.Description.Tags ?? Array.Empty<object>()).Concat(new ImporterPublisher<T>[1] { CS_0024_003C_003E8__locals16.syncedEntry }).ToArray());
			CS_0024_003C_003E8__locals16.configEntry.SettingChanged += [_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)] (object _, EventArgs _) =>
			{
				int num = 4;
				int num2 = num;
				bool flag = default(bool);
				while (true)
				{
					int num3;
					switch (num2)
					{
					default:
						num3 = (CS_0024_003C_003E8__locals16.syncedEntry._AlgoPublisher ? 1 : 0);
						break;
					case 4:
						if (tagPublisher)
						{
							num2 = 3;
							continue;
						}
						goto default;
					case 1:
						return;
					case 5:
						return;
					case 2:
						CS_0024_003C_003E8__locals16._003C_003E4__this.Broadcast(ZRoutedRpc.Everybody, CS_0024_003C_003E8__locals16.configEntry);
						num2 = 5;
						continue;
					case 6:
						if (!flag)
						{
							num2 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
							{
								num2 = 0;
							}
							continue;
						}
						goto case 2;
					case 3:
						num3 = 0;
						break;
					}
					flag = (byte)num3 != 0;
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
					{
						num2 = 6;
					}
				}
			};
			dispatcherPublisher.Add(CS_0024_003C_003E8__locals16.syncedEntry);
		}
		return CS_0024_003C_003E8__locals16.syncedEntry;
	}

	public ImporterPublisher<T> AddLockingConfigEntry<[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)] T>(ConfigEntry<T> lockingConfig) where T : IConvertible
	{
		if (managerPublisher != null)
		{
			throw new Exception(DicSingleton.gE3WbyDVW(-1866665889 ^ -1866680913));
		}
		managerPublisher = AddConfigEntry(lockingConfig);
		lockingConfig.SettingChanged += [_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)] (object _, EventArgs _) =>
		{
			tokenizerPublisher?.Invoke();
		};
		return (ImporterPublisher<T>)managerPublisher;
	}

	internal void AddCustomValue(PrinterPublisher customValue)
	{
		int num = 8;
		int num2 = num;
		_003C_003Ec__DisplayClass36_0 _003C_003Ec__DisplayClass36_ = default(_003C_003Ec__DisplayClass36_0);
		bool flag = default(bool);
		while (true)
		{
			switch (num2)
			{
			case 9:
				return;
			case 6:
				_003C_003Ec__DisplayClass36_.m_ProductBase.CalcRole(_003C_003Ec__DisplayClass36_._003CAddCustomValue_003Eb__1);
				num2 = 9;
				break;
			case 3:
				if (!flag)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 5;
			case 5:
				throw new Exception(DicSingleton.gE3WbyDVW(-1614185587 ^ -1614201371));
			default:
				_ListPublisher.Add(_003C_003Ec__DisplayClass36_.m_ProductBase);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba != 0)
				{
					num2 = 0;
				}
				break;
			case 7:
				_003C_003Ec__DisplayClass36_._ExpressionBase = this;
				num2 = 4;
				break;
			case 4:
				_003C_003Ec__DisplayClass36_.m_ProductBase = customValue;
				num2 = 2;
				break;
			case 8:
				_003C_003Ec__DisplayClass36_ = new _003C_003Ec__DisplayClass36_0();
				num2 = 7;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 != 0)
				{
					num2 = 7;
				}
				break;
			case 2:
				flag = _ListPublisher.Select([_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)] (PrinterPublisher v) => v._RegPublisher).Concat(new string[1] { DicSingleton.gE3WbyDVW(0x1C9EFC64 ^ 0x1C9EBA2E) }).Contains(_003C_003Ec__DisplayClass36_.m_ProductBase._RegPublisher);
				num2 = 3;
				break;
			case 1:
				_ListPublisher = new HashSet<PrinterPublisher>(_ListPublisher.OrderByDescending([_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)] (PrinterPublisher v) => v.m_AdvisorPublisher));
				num2 = 6;
				break;
			}
		}
	}

	private void RPC_FromServerConfigSync(ZRpc rpc, ZPackage package)
	{
		int num = 6;
		bool flag = default(bool);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 4:
					if (!flag)
					{
						num2 = 2;
						continue;
					}
					break;
				case 6:
					ReadRole += serverLockedSettingChanged;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
					{
						num2 = 2;
					}
					continue;
				case 5:
					IsSourceOfTruth = false;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
					{
						num2 = 0;
					}
					continue;
				case 1:
					goto end_IL_0012;
				case 2:
					return;
				case 3:
					return;
				}
				InitialSyncDone = true;
				num2 = 3;
				continue;
				end_IL_0012:
				break;
			}
			flag = HandleConfigSyncRPC(0L, package, clientUpdate: false);
			num = 4;
		}
	}

	private void RPC_FromOtherClientConfigSync(long sender, ZPackage package)
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
				HandleConfigSyncRPC(sender, package, clientUpdate: true);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private bool HandleConfigSyncRPC(long sender, ZPackage package, bool clientUpdate)
	{
		try
		{
			if (_QueuePublisher && IsLocked)
			{
				string text = MappingPublisher.schemaPublisher?.GetSocket()?.GetHostName();
				if (text != null)
				{
					MethodInfo methodInfo = AccessTools.DeclaredMethod(typeof(ZNet), DicSingleton.gE3WbyDVW(-1611872559 ^ -1611890227));
					SyncedList syncedList = (SyncedList)AccessTools.DeclaredField(typeof(ZNet), DicSingleton.gE3WbyDVW(0x1C779450 ^ 0x1C77D36C)).GetValue(ZNet.instance);
					if (!(((object)methodInfo == null) ? syncedList.Contains(text) : ((bool)methodInfo.Invoke(ZNet.instance, new object[2] { syncedList, text }))))
					{
						return false;
					}
				}
			}
			m_AccountPublisher.RemoveAll(([_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(new byte[] { 0, 1 })] KeyValuePair<long, string> kv) =>
			{
				if (kv.Key < DateTimeOffset.Now.Ticks)
				{
					listenerPublisher.Remove(kv.Value);
					return true;
				}
				return false;
			});
			byte b = package.ReadByte();
			if ((b & 2) != 0)
			{
				long num = package.ReadLong();
				string text2 = sender.ToString() + num;
				if (!listenerPublisher.TryGetValue(text2, out var value))
				{
					value = new SortedDictionary<int, byte[]>();
					listenerPublisher[text2] = value;
					m_AccountPublisher.Add(new KeyValuePair<long, string>(DateTimeOffset.Now.AddSeconds(60.0).Ticks, text2));
				}
				int key = package.ReadInt();
				int num2 = package.ReadInt();
				value.Add(key, package.ReadByteArray());
				if (value.Count < num2)
				{
					return false;
				}
				listenerPublisher.Remove(text2);
				package = new ZPackage(value.Values.SelectMany([_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)] (byte[] a) => a).ToArray());
				b = package.ReadByte();
			}
			tagPublisher = true;
			if ((b & 4) != 0)
			{
				byte[] buffer = package.ReadByteArray();
				MemoryStream stream = new MemoryStream(buffer);
				MemoryStream memoryStream = new MemoryStream();
				using (DeflateStream deflateStream = new DeflateStream(stream, CompressionMode.Decompress))
				{
					deflateStream.CopyTo(memoryStream);
				}
				package = new ZPackage(memoryStream.ToArray());
				b = package.ReadByte();
			}
			if ((b & 1) == 0)
			{
				resetConfigsFromServer();
			}
			ConfigurationPublisher configurationPublisher = ReadConfigsFromPackage(package);
			ConfigFile configFile = null;
			bool saveOnConfigSet = false;
			foreach (KeyValuePair<WrapperPublisher, object> item in configurationPublisher.m_SpecificationPublisher)
			{
				if (!_QueuePublisher && item.Key.serverPublisher == null)
				{
					item.Key.serverPublisher = item.Key.BaseConfig.BoxedValue;
				}
				if (configFile == null)
				{
					configFile = item.Key.BaseConfig.ConfigFile;
					saveOnConfigSet = configFile.SaveOnConfigSet;
					configFile.SaveOnConfigSet = false;
				}
				item.Key.BaseConfig.BoxedValue = item.Value;
			}
			if (configFile != null)
			{
				configFile.SaveOnConfigSet = saveOnConfigSet;
			}
			foreach (KeyValuePair<PrinterPublisher, object> item2 in configurationPublisher._RefPublisher)
			{
				if (!_QueuePublisher)
				{
					PrinterPublisher key2 = item2.Key;
					if (key2._ErrorPublisher == null)
					{
						key2._ErrorPublisher = item2.Key.BoxedValue;
					}
				}
				item2.Key.BoxedValue = item2.Value;
			}
			UnityEngine.Debug.Log(string.Format(DicSingleton.gE3WbyDVW(0x74FC52AF ^ 0x74FC15F9), configurationPublisher.m_SpecificationPublisher.Count, configurationPublisher._RefPublisher.Count, (_QueuePublisher || clientUpdate) ? string.Format(DicSingleton.gE3WbyDVW(0x6BAF1854 ^ 0x6BAF5FA4), sender) : DicSingleton.gE3WbyDVW(0x69B67B3A ^ 0x69B63CE2), _StubPublisher ?? _VisitorPublisher));
			if (!_QueuePublisher)
			{
				serverLockedSettingChanged();
			}
			return true;
		}
		finally
		{
			tagPublisher = false;
		}
	}

	private ConfigurationPublisher ReadConfigsFromPackage(ZPackage package)
	{
		int num = 54;
		bool flag8 = default(bool);
		string text = default(string);
		object obj = default(object);
		ConfigurationPublisher configurationPublisher = default(ConfigurationPublisher);
		WrapperPublisher value2 = default(WrapperPublisher);
		bool flag6 = default(bool);
		bool flag11 = default(bool);
		ConfigurationPublisher result = default(ConfigurationPublisher);
		Dictionary<string, PrinterPublisher> dictionary = default(Dictionary<string, PrinterPublisher>);
		PrinterPublisher value = default(PrinterPublisher);
		bool flag = default(bool);
		bool flag2 = default(bool);
		bool flag3 = default(bool);
		string text3 = default(string);
		Type type2 = default(Type);
		bool flag7 = default(bool);
		int num5 = default(int);
		int num6 = default(int);
		bool flag5 = default(bool);
		bool flag4 = default(bool);
		Type type = default(Type);
		bool flag12 = default(bool);
		bool flag10 = default(bool);
		string text2 = default(string);
		Dictionary<string, WrapperPublisher> dictionary2 = default(Dictionary<string, WrapperPublisher>);
		bool flag9 = default(bool);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				int num3;
				object obj2;
				int num8;
				int num4;
				int num7;
				switch (num2)
				{
				case 28:
					flag8 = text == DicSingleton.gE3WbyDVW(-1931860206 ^ -1931845288);
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
					{
						num2 = 8;
					}
					continue;
				case 12:
					if (!(obj is bool))
					{
						num2 = 4;
						continue;
					}
					goto case 57;
				case 10:
					configurationPublisher.m_SpecificationPublisher[value2] = obj;
					num2 = 68;
					continue;
				case 72:
					if (flag6)
					{
						num2 = 13;
						continue;
					}
					goto case 14;
				case 57:
					flag11 = (bool)obj;
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f == 0)
					{
						num2 = 17;
					}
					continue;
				case 11:
					result = new ConfigurationPublisher();
					num2 = 33;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd != 0)
					{
						num2 = 5;
					}
					continue;
				case 5:
					collectionPublisher = flag11;
					num2 = 32;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
					{
						num2 = 31;
					}
					continue;
				case 49:
					if (obj != null)
					{
						num2 = 16;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
						{
							num2 = 36;
						}
						continue;
					}
					goto case 3;
				case 69:
					flag6 = dictionary.TryGetValue(text, out value);
					num2 = 72;
					continue;
				case 7:
					if (!flag)
					{
						num2 = 70;
						continue;
					}
					goto case 26;
				case 6:
				case 8:
				case 33:
					return result;
				case 43:
					if (flag2)
					{
						num2 = 5;
						continue;
					}
					goto case 14;
				case 45:
					if (flag3)
					{
						num2 = 73;
						continue;
					}
					goto case 14;
				case 41:
				case 58:
					num3 = ((GetZPackageTypeString(value._ReponsePublisher) == text3) ? 1 : 0);
					goto IL_0c83;
				case 3:
					obj2 = null;
					goto IL_0ba5;
				case 2:
					if (!(text3 == ""))
					{
						num2 = 33;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 != 0)
						{
							num2 = 75;
						}
						continue;
					}
					goto case 42;
				case 51:
				case 75:
					num8 = ((GetZPackageTypeString(type2) == text3) ? 1 : 0);
					goto IL_0d37;
				case 21:
					if (!value._ReponsePublisher.IsValueType)
					{
						num2 = 40;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
						{
							num2 = 19;
						}
						continue;
					}
					goto case 15;
				case 20:
				case 59:
					flag7 = num5 < num6;
					num2 = 47;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 == 0)
					{
						num2 = 43;
					}
					continue;
				case 16:
					num5 = 0;
					num2 = 33;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f != 0)
					{
						num2 = 59;
					}
					continue;
				case 15:
					if (!(Nullable.GetUnderlyingType(value._ReponsePublisher) != null))
					{
						num2 = 58;
						continue;
					}
					goto case 40;
				case 54:
					configurationPublisher = new ConfigurationPublisher();
					num2 = 53;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
					{
						num2 = 50;
					}
					continue;
				case 46:
					if (flag5)
					{
						num2 = 10;
						continue;
					}
					goto case 74;
				case 65:
					if (flag4)
					{
						num2 = 12;
						continue;
					}
					goto case 69;
				case 71:
					if (Nullable.GetUnderlyingType(type2) != null)
					{
						num2 = 27;
						continue;
					}
					goto case 51;
				case 67:
					type2 = configType(value2.BaseConfig);
					num2 = 2;
					continue;
				case 17:
					num4 = 1;
					goto IL_0c66;
				case 1:
				case 30:
					UnityEngine.Debug.LogWarning(DicSingleton.gE3WbyDVW(0x554A128B ^ 0x554A587F) + text3 + DicSingleton.gE3WbyDVW(0x1C9EFC64 ^ 0x1C9EB77E));
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
					{
						num2 = 9;
					}
					continue;
				case 52:
					type = Type.GetType(text3);
					num2 = 29;
					continue;
				case 38:
					num7 = ((type != null) ? 1 : 0);
					goto IL_0b82;
				case 62:
					result = configurationPublisher;
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
					{
						num2 = 5;
					}
					continue;
				case 19:
					num2 = 23;
					continue;
				case 42:
					if (type2.IsValueType)
					{
						num2 = 49;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
						{
							num2 = 71;
						}
						continue;
					}
					goto case 27;
				case 56:
					text = package.ReadString();
					num2 = 61;
					continue;
				case 37:
					if (!flag12)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 19;
				case 64:
					if (!flag10)
					{
						num2 = 18;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
						{
							num2 = 6;
						}
						continue;
					}
					goto case 67;
				case 23:
					try
					{
						int num9;
						if (text3 == "")
						{
							num9 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 == 0)
							{
								num9 = 0;
							}
							goto IL_068f;
						}
						goto IL_06a5;
						IL_06a5:
						object obj3 = ReadValueWithTypeFromZPackage(package, type);
						goto IL_06c7;
						IL_06c7:
						obj = obj3;
						num9 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
						{
							num9 = 0;
						}
						goto IL_068f;
						IL_068f:
						switch (num9)
						{
						case 2:
							goto IL_06a5;
						case 1:
							goto IL_06c6;
						case 0:
							break;
						}
						goto end_IL_065f;
						IL_06c6:
						obj3 = null;
						goto IL_06c7;
						end_IL_065f:;
					}
					catch (ItemBase itemBase)
					{
						int num10 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 != 0)
						{
							num10 = 1;
						}
						while (true)
						{
							switch (num10)
							{
							case 1:
								UnityEngine.Debug.LogWarning(DicSingleton.gE3WbyDVW(-1580624393 ^ -1580605953) + itemBase.m_MapperBase + DicSingleton.gE3WbyDVW(0x74FC52AF ^ 0x74FC1AFB) + itemBase.m_IdentifierBase + DicSingleton.gE3WbyDVW(-1977574774 ^ -1977560348) + text3 + DicSingleton.gE3WbyDVW(0x4BDBCDC0 ^ 0x4BDB8542) + text + DicSingleton.gE3WbyDVW(-1461449777 ^ -1461435553) + text2 + DicSingleton.gE3WbyDVW(0x6E29C0C0 ^ 0x6E29886C) + (_StubPublisher ?? _VisitorPublisher) + DicSingleton.gE3WbyDVW(0x940D407 ^ 0x9409CC5) + itemBase.contextBase);
								num10 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d != 0)
								{
									num10 = 0;
								}
								continue;
							}
							break;
						}
						goto case 14;
					}
					goto case 50;
				case 9:
					if (!flag8)
					{
						num2 = 55;
						continue;
					}
					goto case 49;
				default:
					flag10 = dictionary2.TryGetValue(text2 + DicSingleton.gE3WbyDVW(0x4C73F208 ^ 0x4C73B812) + text, out value2);
					num2 = 64;
					continue;
				case 31:
					if (!flag9)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 28;
				case 34:
					num6 = package.ReadInt();
					num2 = 16;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 != 0)
					{
						num2 = 13;
					}
					continue;
				case 47:
					if (!flag7)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
						{
							num2 = 62;
						}
						continue;
					}
					goto case 66;
				case 50:
					flag9 = text2 == DicSingleton.gE3WbyDVW(-316028230 ^ -316046748);
					num = 31;
					break;
				case 29:
					if (!(text3 == ""))
					{
						num2 = 38;
						continue;
					}
					num7 = 1;
					goto IL_0b82;
				case 14:
				case 22:
				case 24:
				case 32:
				case 35:
				case 44:
				case 68:
				case 76:
					num5++;
					num2 = 20;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
					{
						num2 = 15;
					}
					continue;
				case 66:
					text2 = package.ReadString();
					num2 = 56;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
					{
						num2 = 22;
					}
					continue;
				case 26:
					configurationPublisher._RefPublisher[value] = obj;
					num2 = 24;
					continue;
				case 61:
					text3 = package.ReadString();
					num = 52;
					break;
				case 25:
				case 55:
					flag4 = text == DicSingleton.gE3WbyDVW(-1614185587 ^ -1614204377);
					num2 = 65;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
					{
						num2 = 13;
					}
					continue;
				case 13:
					if (!(text3 == ""))
					{
						num2 = 21;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
						{
							num2 = 41;
						}
						continue;
					}
					goto case 21;
				case 53:
					dictionary2 = dispatcherPublisher.Where([_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)] (WrapperPublisher c) => c._AlgoPublisher).ToDictionary([_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)] (WrapperPublisher c) => c.BaseConfig.Definition.Section + DicSingleton.gE3WbyDVW(-1954645236 ^ -1954664170) + c.BaseConfig.Definition.Key, [_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)] (WrapperPublisher c) => c);
					num2 = 60;
					continue;
				case 60:
					dictionary = _ListPublisher.ToDictionary([_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)] (PrinterPublisher c) => c._RegPublisher, [_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)] (PrinterPublisher c) => c);
					num2 = 34;
					continue;
				case 36:
					obj2 = obj.ToString();
					goto IL_0ba5;
				case 73:
					UnityEngine.Debug.LogWarning(DicSingleton.gE3WbyDVW(-1466472923 ^ -1466487081) + (obj?.ToString() ?? DicSingleton.gE3WbyDVW(-316028230 ^ -316046370)) + DicSingleton.gE3WbyDVW(-293474990 ^ -293493726) + (policyPublisher ?? DicSingleton.gE3WbyDVW(-2133864647 ^ -2133883231)));
					num2 = 16;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
					{
						num2 = 35;
					}
					continue;
				case 4:
					num4 = 0;
					goto IL_0c66;
				case 40:
					num3 = 1;
					goto IL_0c83;
				case 63:
				case 70:
					UnityEngine.Debug.LogWarning(DicSingleton.gE3WbyDVW(-1773869960 ^ -1773883974) + text3 + DicSingleton.gE3WbyDVW(0x5A8BEE ^ 0x5AC200) + text + DicSingleton.gE3WbyDVW(-1123846595 ^ -1123860847) + (_StubPublisher ?? _VisitorPublisher) + DicSingleton.gE3WbyDVW(-1829625923 ^ -1829611649) + value._ReponsePublisher.AssemblyQualifiedName);
					num2 = 44;
					continue;
				case 27:
					num8 = 1;
					goto IL_0d37;
				case 74:
					UnityEngine.Debug.LogWarning(DicSingleton.gE3WbyDVW(0x6DF53C90 ^ 0x6DF57552) + text3 + DicSingleton.gE3WbyDVW(0x6BAF1854 ^ 0x6BAF50D6) + text + DicSingleton.gE3WbyDVW(0x1606DF07 ^ 0x16069797) + text2 + DicSingleton.gE3WbyDVW(0x33F6A245 ^ 0x33F6EAE9) + (_StubPublisher ?? _VisitorPublisher) + DicSingleton.gE3WbyDVW(0x2BC53863 ^ 0x2BC570A1) + type2.AssemblyQualifiedName);
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
					{
						num2 = 14;
					}
					continue;
				case 18:
				case 48:
					{
						UnityEngine.Debug.LogWarning(DicSingleton.gE3WbyDVW(0x1606DF07 ^ 0x16069527) + text + DicSingleton.gE3WbyDVW(0x4BDBCDC0 ^ 0x4BDB8550) + text2 + DicSingleton.gE3WbyDVW(0x6DF53C90 ^ 0x6DF5743C) + (_StubPublisher ?? _VisitorPublisher) + DicSingleton.gE3WbyDVW(-1483531944 ^ -1483517128));
						num2 = 22;
						continue;
					}
					IL_0c83:
					flag = (byte)num3 != 0;
					num2 = 7;
					continue;
					IL_0c66:
					flag2 = (byte)num4 != 0;
					num2 = 43;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
					{
						num2 = 35;
					}
					continue;
					IL_0ba5:
					flag3 = (string)obj2 != policyPublisher;
					num2 = 45;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 != 0)
					{
						num2 = 41;
					}
					continue;
					IL_0d37:
					flag5 = (byte)num8 != 0;
					num2 = 46;
					continue;
					IL_0b82:
					flag12 = (byte)num7 != 0;
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
					{
						num2 = 37;
					}
					continue;
				}
				break;
			}
		}
	}

	private static bool isWritableConfig(WrapperPublisher config)
	{
		int num = 2;
		int num2 = num;
		bool flag = default(bool);
		_003C_003Ec__DisplayClass51_0 _003C_003Ec__DisplayClass51_ = default(_003C_003Ec__DisplayClass51_0);
		RepositoryPublisher repositoryPublisher = default(RepositoryPublisher);
		bool result = default(bool);
		while (true)
		{
			int num3;
			switch (num2)
			{
			case 11:
				if (flag)
				{
					num2 = 13;
					continue;
				}
				goto case 18;
			case 1:
				_003C_003Ec__DisplayClass51_.m_RegistryBase = config;
				num2 = 9;
				continue;
			case 4:
				if (repositoryPublisher.IsLocked)
				{
					num2 = 14;
					continue;
				}
				goto default;
			default:
				if (_003C_003Ec__DisplayClass51_.m_RegistryBase == repositoryPublisher.managerPublisher)
				{
					num2 = 16;
					continue;
				}
				num3 = 1;
				break;
			case 18:
				if (repositoryPublisher.IsSourceOfTruth)
				{
					num2 = 10;
					continue;
				}
				goto case 8;
			case 13:
				result = true;
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 != 0)
				{
					num2 = 5;
				}
				continue;
			case 12:
				flag = repositoryPublisher == null;
				num2 = 7;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 != 0)
				{
					num2 = 11;
				}
				continue;
			case 2:
				_003C_003Ec__DisplayClass51_ = new _003C_003Ec__DisplayClass51_0();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b == 0)
				{
					num2 = 1;
				}
				continue;
			case 16:
				num3 = (collectionPublisher ? 1 : 0);
				break;
			case 15:
				if (_003C_003Ec__DisplayClass51_.m_RegistryBase.serverPublisher == null)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 == 0)
					{
						num2 = 6;
					}
					continue;
				}
				goto case 4;
			case 8:
				if (!_003C_003Ec__DisplayClass51_.m_RegistryBase._AlgoPublisher)
				{
					num2 = 3;
					continue;
				}
				goto case 15;
			case 5:
			case 7:
			case 17:
				return result;
			case 9:
				repositoryPublisher = descriptorPublisher.FirstOrDefault(_003C_003Ec__DisplayClass51_._003CisWritableConfig_003Eb__0);
				num2 = 12;
				continue;
			case 14:
				num3 = 0;
				break;
			case 3:
			case 6:
			case 10:
				num3 = 1;
				break;
			}
			result = (byte)num3 != 0;
			num2 = 7;
		}
	}

	private void serverLockedSettingChanged()
	{
		int num = 1;
		int num2 = num;
		HashSet<WrapperPublisher>.Enumerator enumerator = default(HashSet<WrapperPublisher>.Enumerator);
		WrapperPublisher current = default(WrapperPublisher);
		while (true)
		{
			switch (num2)
			{
			case 1:
				enumerator = dispatcherPublisher.GetEnumerator();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
				{
					num2 = 0;
				}
				continue;
			case 2:
				return;
			}
			try
			{
				while (true)
				{
					IL_00b5:
					int num4;
					if (!enumerator.MoveNext())
					{
						int num3 = 3;
						num4 = num3;
						goto IL_003c;
					}
					goto IL_0056;
					IL_003c:
					while (true)
					{
						switch (num4)
						{
						case 2:
							break;
						case 1:
							configAttribute<AnnotationPublisher>(current.BaseConfig)._ProcessPublisher = !isWritableConfig(current);
							num4 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
							{
								num4 = 0;
							}
							continue;
						default:
							goto IL_00b5;
						case 3:
							return;
						}
						break;
					}
					goto IL_0056;
					IL_0056:
					current = enumerator.Current;
					num4 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
					{
						num4 = 0;
					}
					goto IL_003c;
				}
			}
			finally
			{
				((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
				int num5 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
				{
					num5 = 0;
				}
				switch (num5)
				{
				case 0:
					break;
				}
			}
		}
	}

	private void resetConfigsFromServer()
	{
		ConfigFile configFile = null;
		bool saveOnConfigSet = false;
		foreach (WrapperPublisher item in dispatcherPublisher.Where([_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)] (WrapperPublisher config) => config.serverPublisher != null))
		{
			if (configFile == null)
			{
				configFile = item.BaseConfig.ConfigFile;
				saveOnConfigSet = configFile.SaveOnConfigSet;
				configFile.SaveOnConfigSet = false;
			}
			item.BaseConfig.BoxedValue = item.serverPublisher;
			item.serverPublisher = null;
		}
		if (configFile != null)
		{
			configFile.SaveOnConfigSet = saveOnConfigSet;
		}
		foreach (PrinterPublisher item2 in _ListPublisher.Where([_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)] (PrinterPublisher config) => config._ErrorPublisher != null))
		{
			item2.BoxedValue = item2._ErrorPublisher;
			item2._ErrorPublisher = null;
		}
		ReadRole -= serverLockedSettingChanged;
		serverLockedSettingChanged();
	}

	[IteratorStateMachine(typeof(_003CdistributeConfigToPeers_003Ed__55))]
	private IEnumerator<bool> distributeConfigToPeers(ZNetPeer peer, ZPackage package)
	{
		//yield-return decompiler failed: Missing enumeratorCtor.Body
		return new _003CdistributeConfigToPeers_003Ed__55(0)
		{
			_003C_003E4__this = this,
			peer = peer,
			package = package
		};
	}

	private IEnumerator sendZPackage(long target, ZPackage package)
	{
		int num = 10;
		int num2 = num;
		IEnumerator result = default(IEnumerator);
		bool flag = default(bool);
		_003C_003Ec__DisplayClass56_0 _003C_003Ec__DisplayClass56_ = default(_003C_003Ec__DisplayClass56_0);
		List<ZNetPeer> list = default(List<ZNetPeer>);
		bool flag2 = default(bool);
		while (true)
		{
			switch (num2)
			{
			case 2:
			case 5:
			case 12:
				return result;
			default:
				result = Enumerable.Empty<object>().GetEnumerator();
				num2 = 12;
				break;
			case 8:
				flag = _003C_003Ec__DisplayClass56_._PageBase != ZRoutedRpc.Everybody;
				num2 = 6;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 != 0)
				{
					num2 = 5;
				}
				break;
			case 1:
				list = list.Where(_003C_003Ec__DisplayClass56_._003CsendZPackage_003Eb__0).ToList();
				num2 = 6;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
				{
					num2 = 11;
				}
				break;
			case 11:
				result = sendZPackage(list, package);
				num2 = 5;
				break;
			case 4:
				flag2 = !ZNet.instance;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
				{
					num2 = 3;
				}
				break;
			case 10:
				_003C_003Ec__DisplayClass56_ = new _003C_003Ec__DisplayClass56_0();
				num2 = 8;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
				{
					num2 = 9;
				}
				break;
			case 3:
				if (flag2)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 7;
			case 9:
				_003C_003Ec__DisplayClass56_._PageBase = target;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
				{
					num2 = 4;
				}
				break;
			case 7:
				list = (List<ZNetPeer>)AccessTools.DeclaredField(typeof(ZRoutedRpc), DicSingleton.gE3WbyDVW(0x7A125A0E ^ 0x7A12116A)).GetValue(ZRoutedRpc.instance);
				num2 = 8;
				break;
			case 6:
				if (flag)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 11;
			}
		}
	}

	[IteratorStateMachine(typeof(_003CsendZPackage_003Ed__57))]
	private IEnumerator sendZPackage(List<ZNetPeer> peers, ZPackage package)
	{
		//yield-return decompiler failed: Missing enumeratorCtor.Body
		return new _003CsendZPackage_003Ed__57(0)
		{
			_003C_003E4__this = this,
			peers = peers,
			package = package
		};
	}

	private void Broadcast(long target, params ConfigEntryBase[] configs)
	{
		int num = 1;
		bool flag = default(bool);
		ZPackage package = default(ZPackage);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				int num3;
				switch (num2)
				{
				case 5:
					if (flag)
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
						{
							num2 = 4;
						}
						continue;
					}
					return;
				case 4:
					package = ConfigsToPackage(configs);
					num2 = 6;
					continue;
				case 1:
					if (IsLocked)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					num3 = 1;
					goto IL_00c1;
				default:
					num3 = (_QueuePublisher ? 1 : 0);
					goto IL_00c1;
				case 2:
					return;
				case 3:
					return;
				case 6:
					{
						ZNet instance = ZNet.instance;
						if ((object)instance != null)
						{
							instance.StartCoroutine(sendZPackage(target, package));
							num2 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
							{
								num2 = 2;
							}
							continue;
						}
						break;
					}
					IL_00c1:
					flag = (byte)num3 != 0;
					num2 = 5;
					continue;
				}
				break;
			}
			num = 3;
		}
	}

	private void Broadcast(long target, params PrinterPublisher[] customValues)
	{
		int num = 3;
		bool flag = default(bool);
		ZPackage package = default(ZPackage);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				int num3;
				switch (num2)
				{
				default:
					return;
				case 4:
					if (!flag)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					break;
				case 3:
					if (IsLocked)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					num3 = 1;
					goto IL_00be;
				case 2:
					num3 = (_QueuePublisher ? 1 : 0);
					goto IL_00be;
				case 0:
					return;
				case 6:
					break;
				case 1:
					return;
				case 5:
					return;
				case 7:
					{
						ZNet instance = ZNet.instance;
						if ((object)instance == null)
						{
							num2 = 5;
							continue;
						}
						instance.StartCoroutine(sendZPackage(target, package));
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
						{
							num2 = 1;
						}
						continue;
					}
					IL_00be:
					flag = (byte)num3 != 0;
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd != 0)
					{
						num2 = 4;
					}
					continue;
				}
				break;
			}
			package = ConfigsToPackage(null, customValues);
			num = 7;
		}
	}

	[return: _003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
	private static WrapperPublisher configData(ConfigEntryBase config)
	{
		int num = 3;
		int num2 = num;
		WrapperPublisher result = default(WrapperPublisher);
		while (true)
		{
			object obj;
			switch (num2)
			{
			default:
				return result;
			case 3:
			{
				object[] tags = config.Description.Tags;
				if (tags == null)
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
					{
						num2 = 0;
					}
					continue;
				}
				obj = tags.OfType<WrapperPublisher>().SingleOrDefault();
				break;
			}
			case 2:
				obj = null;
				break;
			}
			result = (WrapperPublisher)obj;
			num2 = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
			{
				num2 = 0;
			}
		}
	}

	[return: _003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(new byte[] { 2, 1 })]
	public static ImporterPublisher<T> ConfigData<[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)] T>(ConfigEntry<T> config)
	{
		return config.Description.Tags?.OfType<ImporterPublisher<T>>().SingleOrDefault();
	}

	private static T configAttribute<[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)] T>(ConfigEntryBase config)
	{
		return config.Description.Tags.OfType<T>().First();
	}

	private static Type configType(ConfigEntryBase config)
	{
		return configType(config.SettingType);
	}

	private static Type configType(Type type)
	{
		int num = 1;
		int num2 = num;
		Type result;
		while (true)
		{
			switch (num2)
			{
			default:
				result = type;
				break;
			case 1:
				if (!type.IsEnum)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
					{
						num2 = 0;
					}
					continue;
				}
				result = Enum.GetUnderlyingType(type);
				break;
			}
			break;
		}
		return result;
	}

	private static ZPackage ConfigsToPackage([_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(new byte[] { 2, 1 })] IEnumerable<ConfigEntryBase> configs = null, [_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(new byte[] { 2, 1 })] IEnumerable<PrinterPublisher> customValues = null, [_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(new byte[] { 2, 1 })] IEnumerable<ComparatorBase> packageEntries = null, bool partial = true)
	{
		List<ConfigEntryBase> list = configs?.Where([_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)] (ConfigEntryBase config) => configData(config)._AlgoPublisher).ToList() ?? new List<ConfigEntryBase>();
		List<PrinterPublisher> list2 = customValues?.ToList() ?? new List<PrinterPublisher>();
		ZPackage zPackage = new ZPackage();
		zPackage.Write((byte)(partial ? 1 : 0));
		zPackage.Write(list.Count + list2.Count + (packageEntries?.Count() ?? 0));
		foreach (ComparatorBase item in packageEntries ?? Array.Empty<ComparatorBase>())
		{
			AddEntryToPackage(zPackage, item);
		}
		foreach (PrinterPublisher item2 in list2)
		{
			AddEntryToPackage(zPackage, new ComparatorBase
			{
				_DefinitionBase = DicSingleton.gE3WbyDVW(-428135557 ^ -428121179),
				_ComposerBase = item2._RegPublisher,
				globalBase = item2._ReponsePublisher,
				m_MapBase = item2.BoxedValue
			});
		}
		foreach (ConfigEntryBase item3 in list)
		{
			AddEntryToPackage(zPackage, new ComparatorBase
			{
				_DefinitionBase = item3.Definition.Section,
				_ComposerBase = item3.Definition.Key,
				globalBase = configType(item3),
				m_MapBase = item3.BoxedValue
			});
		}
		return zPackage;
	}

	private static void AddEntryToPackage(ZPackage package, ComparatorBase entry)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 4:
				return;
			case 1:
				package.Write(entry._ComposerBase);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
				{
					num2 = 0;
				}
				break;
			case 3:
				AddValueToZPackage(package, entry.m_MapBase);
				num2 = 4;
				break;
			case 2:
				package.Write(entry._DefinitionBase);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba != 0)
				{
					num2 = 1;
				}
				break;
			default:
				package.Write((entry.m_MapBase == null) ? "" : GetZPackageTypeString(entry.globalBase));
				num2 = 3;
				break;
			}
		}
	}

	private static string GetZPackageTypeString(Type type)
	{
		return type.AssemblyQualifiedName;
	}

	private static void AddValueToZPackage(ZPackage package, [_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)] object value)
	{
		Type type = value?.GetType();
		if (value is Enum)
		{
			value = ((IConvertible)value).ToType(Enum.GetUnderlyingType(value.GetType()), CultureInfo.InvariantCulture);
		}
		else
		{
			if (value is ICollection collection)
			{
				package.Write(collection.Count);
				{
					foreach (object item in collection)
					{
						AddValueToZPackage(package, item);
					}
					return;
				}
			}
			if ((object)type != null && type.IsValueType && !type.IsPrimitive)
			{
				FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				package.Write(fields.Length);
				FieldInfo[] array = fields;
				foreach (FieldInfo fieldInfo in array)
				{
					package.Write(GetZPackageTypeString(fieldInfo.FieldType));
					AddValueToZPackage(package, fieldInfo.GetValue(value));
				}
				return;
			}
		}
		ZRpc.Serialize(new object[1] { value }, ref package);
	}

	private static object ReadValueWithTypeFromZPackage(ZPackage package, Type type)
	{
		int num = 31;
		int num4 = default(int);
		bool flag2 = default(bool);
		object result = default(object);
		object uninitializedObject = default(object);
		bool flag7 = default(bool);
		int num10 = default(int);
		Type type2 = default(Type);
		bool flag6 = default(bool);
		FieldInfo fieldInfo = default(FieldInfo);
		FieldInfo[] array = default(FieldInfo[]);
		int num6 = default(int);
		string text = default(string);
		FieldInfo field2 = default(FieldInfo);
		Type type3 = default(Type);
		bool flag = default(bool);
		List<object> parameters = default(List<object>);
		object obj = default(object);
		int num5 = default(int);
		FieldInfo[] fields = default(FieldInfo[]);
		int num7 = default(int);
		bool flag5 = default(bool);
		ParameterInfo parameterInfo = default(ParameterInfo);
		int num8 = default(int);
		bool flag4 = default(bool);
		IDictionary dictionary = default(IDictionary);
		FieldInfo field = default(FieldInfo);
		object obj2 = default(object);
		bool flag3 = default(bool);
		MethodInfo method = default(MethodInfo);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				int num3;
				int num11;
				int num9;
				switch (num2)
				{
				case 5:
					num4++;
					num2 = 52;
					continue;
				case 3:
					if (!flag2)
					{
						num2 = 58;
						continue;
					}
					goto case 45;
				case 57:
					result = uninitializedObject;
					num2 = 60;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
					{
						num2 = 54;
					}
					continue;
				case 65:
					num3 = ((type.GetGenericTypeDefinition() == typeof(Dictionary<, >)) ? 1 : 0);
					goto IL_095f;
				case 46:
					if (!type.IsGenericType)
					{
						num2 = 18;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 != 0)
						{
							num2 = 64;
						}
						continue;
					}
					goto case 55;
				case 17:
					num4 = 0;
					num2 = 22;
					continue;
				case 22:
				case 52:
					flag7 = num4 < num10;
					num2 = 44;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 != 0)
					{
						num2 = 51;
					}
					continue;
				case 11:
					num11 = (type2.IsAssignableFrom(type) ? 1 : 0);
					goto IL_096c;
				case 44:
					if (!flag6)
					{
						num2 = 12;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 53;
				case 16:
					fieldInfo = array[num6];
					num2 = 67;
					continue;
				case 15:
					throw new ItemBase
					{
						m_MapperBase = text,
						contextBase = GetZPackageTypeString(fieldInfo.FieldType),
						m_IdentifierBase = fieldInfo.Name
					};
				case 29:
					fieldInfo.SetValue(uninitializedObject, ReadValueWithTypeFromZPackage(package, fieldInfo.FieldType));
					num2 = 40;
					continue;
				case 43:
					field2 = type3.GetField(DicSingleton.gE3WbyDVW(0x6CF51E1A ^ 0x6CF555B2), BindingFlags.Instance | BindingFlags.NonPublic);
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
					{
						num2 = 5;
					}
					continue;
				case 54:
					flag = text != GetZPackageTypeString(fieldInfo.FieldType);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 != 0)
					{
						num2 = 0;
					}
					continue;
				case 67:
					text = package.ReadString();
					num2 = 54;
					continue;
				case 8:
					result = parameters.First();
					num2 = 34;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 != 0)
					{
						num2 = 36;
					}
					continue;
				case 18:
					if (type.IsValueType)
					{
						num2 = 26;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 30;
				case 2:
					parameters = new List<object>();
					num2 = 24;
					continue;
				case 40:
					num6++;
					num2 = 66;
					continue;
				case 4:
					obj = Activator.CreateInstance(type);
					num2 = 6;
					continue;
				case 51:
					if (!flag7)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 39;
				case 55:
					type2 = typeof(ICollection<>).MakeGenericType(type.GenericTypeArguments[0]);
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
					{
						num2 = 5;
					}
					continue;
				case 21:
					flag6 = num5 != fields.Length;
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
					{
						num2 = 44;
					}
					continue;
				case 42:
					num7++;
					num2 = 62;
					continue;
				case 33:
					num6 = 0;
					num2 = 61;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 != 0)
					{
						num2 = 43;
					}
					continue;
				case 31:
					if ((object)type == null)
					{
						num2 = 19;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
						{
							num2 = 30;
						}
						continue;
					}
					goto case 18;
				case 41:
					if (type != typeof(List<string>))
					{
						num2 = 46;
						continue;
					}
					goto case 64;
				case 59:
					array = fields;
					num2 = 33;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
					{
						num2 = 24;
					}
					continue;
				case 32:
					if (!flag5)
					{
						num2 = 18;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
						{
							num2 = 19;
						}
						continue;
					}
					goto case 35;
				case 37:
					num9 = ((!type.IsEnum) ? 1 : 0);
					goto IL_0952;
				case 19:
				case 38:
					parameterInfo = (ParameterInfo)FormatterServices.GetUninitializedObject(typeof(ParameterInfo));
					num2 = 50;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
					{
						num2 = 36;
					}
					continue;
				case 20:
					num8 = package.ReadInt();
					num2 = 14;
					continue;
				case 25:
					if (flag4)
					{
						num2 = 34;
						continue;
					}
					goto case 49;
				case 68:
					dictionary.Add(field.GetValue(obj2), field2.GetValue(obj2));
					num2 = 42;
					continue;
				case 58:
					result = dictionary;
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 == 0)
					{
						num2 = 5;
					}
					continue;
				case 24:
					ZRpc.Deserialize(new ParameterInfo[2] { null, parameterInfo }, package, ref parameters);
					num2 = 8;
					continue;
				case 9:
					num7 = 0;
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec == 0)
					{
						num2 = 13;
					}
					continue;
				case 35:
					num10 = package.ReadInt();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
					{
						num2 = 4;
					}
					continue;
				case 26:
					if (!type.IsPrimitive)
					{
						num2 = 37;
						continue;
					}
					goto case 30;
				case 1:
					result = obj;
					num = 28;
					break;
				case 47:
					field = type3.GetField(DicSingleton.gE3WbyDVW(-1544119467 ^ -1544105781), BindingFlags.Instance | BindingFlags.NonPublic);
					num2 = 43;
					continue;
				case 14:
					dictionary = (IDictionary)Activator.CreateInstance(type);
					num2 = 48;
					continue;
				case 48:
					type3 = typeof(KeyValuePair<, >).MakeGenericType(type.GenericTypeArguments);
					num2 = 47;
					continue;
				case 34:
					fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					num2 = 56;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
					{
						num2 = 29;
					}
					continue;
				case 10:
					if ((object)type2 != null)
					{
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
						{
							num2 = 11;
						}
						continue;
					}
					goto case 64;
				case 50:
					AccessTools.DeclaredField(typeof(ParameterInfo), DicSingleton.gE3WbyDVW(0x4C23C86A ^ 0x4C2383AA)).SetValue(parameterInfo, type);
					num2 = 2;
					continue;
				case 63:
					if (flag3)
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e != 0)
						{
							num2 = 20;
						}
						continue;
					}
					goto case 41;
				case 13:
				case 62:
					flag2 = num7 < num8;
					num2 = 3;
					continue;
				case 53:
					throw new ItemBase
					{
						m_MapperBase = string.Format(DicSingleton.gE3WbyDVW(-25744665 ^ -25730671), num5),
						contextBase = string.Format(DicSingleton.gE3WbyDVW(0x5901407C ^ 0x59010B0A), fields.Length)
					};
				case 12:
					uninitializedObject = FormatterServices.GetUninitializedObject(type);
					num2 = 33;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a != 0)
					{
						num2 = 59;
					}
					continue;
				case 45:
					obj2 = ReadValueWithTypeFromZPackage(package, type3);
					num2 = 68;
					continue;
				case 7:
				case 27:
				case 28:
				case 36:
				case 60:
					return result;
				case 61:
				case 66:
					if (num6 >= array.Length)
					{
						num = 57;
						break;
					}
					goto case 16;
				case 39:
					method.Invoke(obj, new object[1] { ReadValueWithTypeFromZPackage(package, type.GenericTypeArguments[0]) });
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb == 0)
					{
						num2 = 3;
					}
					continue;
				case 49:
					if (!type.IsGenericType)
					{
						num2 = 23;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
						{
							num2 = 10;
						}
						continue;
					}
					goto case 65;
				case 56:
					num5 = package.ReadInt();
					num2 = 21;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 == 0)
					{
						num2 = 20;
					}
					continue;
				default:
					if (!flag)
					{
						num2 = 29;
						continue;
					}
					goto case 15;
				case 6:
					method = type2.GetMethod(DicSingleton.gE3WbyDVW(-614239580 ^ -614254318));
					num2 = 17;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
					{
						num2 = 8;
					}
					continue;
				case 30:
					num9 = 0;
					goto IL_0952;
				case 23:
					num3 = 0;
					goto IL_095f;
				case 64:
					{
						num11 = 0;
						goto IL_096c;
					}
					IL_0952:
					flag4 = (byte)num9 != 0;
					num2 = 25;
					continue;
					IL_095f:
					flag3 = (byte)num3 != 0;
					num2 = 63;
					continue;
					IL_096c:
					flag5 = (byte)num11 != 0;
					num2 = 32;
					continue;
				}
				break;
			}
		}
	}

	internal static bool QueryWrapper()
	{
		return DisableWrapper == null;
	}

	internal static RepositoryPublisher AwakeWrapper()
	{
		return DisableWrapper;
	}
}
