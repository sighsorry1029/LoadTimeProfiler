using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AzuAnticheat.Internal;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Rendering;

namespace AzuAntiCheat;

[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
[BepInPlugin("Azumatt.AzuAntiCheat", "AzuAntiCheat", "4.3.11")]
public sealed class AzuAnticheatPlugin : BaseUnityPlugin
{
	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)]
	public enum Toggle
	{
		On = 1,
		Off = 0
	}

	[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)]
	private class Attr
	{
		public bool? m_Message;

		internal static Attr ViewExpression;

		public Attr()
		{
			GetterIssuer.DeleteInitializer();
			m_Message = false;
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool InitExpression()
		{
			return ViewExpression == null;
		}

		internal static Attr PatchExpression()
		{
			return ViewExpression;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003CStartProcessListRefreshTask_003Eb__82_0_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public AzuAnticheatPlugin _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		internal static object AssetExpression;

		private void MoveNext()
		{
			int num = 2;
			int num3 = default(int);
			TaskAwaiter awaiter = default(TaskAwaiter);
			AzuAnticheatPlugin azuAnticheatPlugin = default(AzuAnticheatPlugin);
			CancellationToken token = default(CancellationToken);
			Process[] processes = default(Process[]);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					case 4:
						return;
					case 3:
						_003C_003Et__builder.SetResult();
						num2 = 4;
						continue;
					case 5:
						try
						{
							int num4;
							if (num3 != 0)
							{
								num4 = 9;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 != 0)
								{
									num4 = 0;
								}
								goto IL_0070;
							}
							goto IL_026e;
							IL_0070:
							while (true)
							{
								switch (num4)
								{
								case 4:
									return;
								case 13:
									awaiter.GetResult();
									num4 = 15;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
									{
										num4 = 8;
									}
									continue;
								case 14:
									awaiter = Task.Delay(TimeSpan.FromSeconds(10.0), azuAnticheatPlugin._Request.Token).GetAwaiter();
									num4 = 3;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 == 0)
									{
										num4 = 2;
									}
									continue;
								default:
									num3 = (_003C_003E1__state = -1);
									num4 = 13;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 != 0)
									{
										num4 = 5;
									}
									continue;
								case 3:
									if (!awaiter.IsCompleted)
									{
										num4 = 4;
										if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 != 0)
										{
											num4 = 7;
										}
										continue;
									}
									goto case 13;
								case 9:
								case 15:
									token = azuAnticheatPlugin._Request.Token;
									num4 = 6;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 != 0)
									{
										num4 = 3;
									}
									continue;
								case 10:
									_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
									num4 = 1;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
									{
										num4 = 4;
									}
									continue;
								case 7:
									num3 = (_003C_003E1__state = 0);
									num4 = 1;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 != 0)
									{
										num4 = 1;
									}
									continue;
								case 6:
									if (token.IsCancellationRequested)
									{
										num4 = 8;
										continue;
									}
									goto case 11;
								case 2:
									_003C_003Eu__1 = default(TaskAwaiter);
									num4 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
									{
										num4 = 0;
									}
									continue;
								case 1:
									_003C_003Eu__1 = awaiter;
									num4 = 6;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 != 0)
									{
										num4 = 10;
									}
									continue;
								case 5:
									azuAnticheatPlugin.m_Page = new ConcurrentBag<Process>(processes);
									num4 = 14;
									continue;
								case 12:
									break;
								case 11:
									processes = Process.GetProcesses();
									num4 = 5;
									continue;
								case 8:
									goto end_IL_0070;
								}
								goto IL_026e;
								continue;
								end_IL_0070:
								break;
							}
							goto end_IL_004b;
							IL_026e:
							awaiter = _003C_003Eu__1;
							num4 = 2;
							goto IL_0070;
							end_IL_004b:;
						}
						catch (Exception exception)
						{
							int num5 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
							{
								num5 = 1;
							}
							while (true)
							{
								switch (num5)
								{
								default:
									return;
								case 0:
									return;
								case 2:
									_003C_003Et__builder.SetException(exception);
									num5 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
									{
										num5 = 0;
									}
									break;
								case 1:
									_003C_003E1__state = -2;
									num5 = 2;
									break;
								}
							}
						}
						break;
					case 2:
						num3 = _003C_003E1__state;
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
						{
							num2 = 0;
						}
						continue;
					case 1:
						azuAnticheatPlugin = _003C_003E4__this;
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 == 0)
						{
							num2 = 5;
						}
						continue;
					}
					break;
				}
				_003C_003E1__state = -2;
				num = 3;
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine([_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)] IAsyncStateMachine stateMachine)
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
					_003C_003Et__builder.SetStateMachine(stateMachine);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		void IAsyncStateMachine.SetStateMachine([_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)] IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}

		internal static bool ListExpression()
		{
			return AssetExpression == null;
		}

		internal static object CalcExpression()
		{
			return AssetExpression;
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		[StructLayout(LayoutKind.Auto)]
		private struct Stub : IAsyncStateMachine
		{
			public int _Policy;

			public AsyncTaskMethodBuilder _Strategy;

			[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(new byte[] { 0, 1 })]
			private TaskAwaiter<string> _Processor;

			private static object SortExpression;

			private void MoveNext()
			{
				int num = 2;
				int num2 = num;
				int num3 = default(int);
				TaskAwaiter<string> awaiter = default(TaskAwaiter<string>);
				while (true)
				{
					switch (num2)
					{
					case 1:
						try
						{
							int num4;
							if (num3 != 0)
							{
								num4 = 3;
								goto IL_0046;
							}
							goto IL_0172;
							IL_0172:
							awaiter = _Processor;
							num4 = 4;
							goto IL_0046;
							IL_0046:
							while (true)
							{
								switch (num4)
								{
								case 3:
									awaiter = GetAsync(DicSingleton.gE3WbyDVW(-25744665 ^ -25743115)).GetAwaiter();
									num4 = 7;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb == 0)
									{
										num4 = 5;
									}
									continue;
								case 6:
									num3 = (_Policy = -1);
									num4 = 8;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c == 0)
									{
										num4 = 7;
									}
									continue;
								case 8:
									m_Predicate = Deobf(awaiter.GetResult().Trim(new char[1] { '"' }));
									num4 = 9;
									continue;
								case 10:
									return;
								case 4:
									_Processor = default(TaskAwaiter<string>);
									num4 = 6;
									continue;
								case 5:
									_Processor = awaiter;
									num4 = 2;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
									{
										num4 = 2;
									}
									continue;
								default:
									num3 = (_Policy = 0);
									num4 = 5;
									continue;
								case 1:
									break;
								case 7:
									if (!awaiter.IsCompleted)
									{
										num4 = 0;
										if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 != 0)
										{
											num4 = 0;
										}
										continue;
									}
									goto case 8;
								case 2:
									_Strategy.AwaitUnsafeOnCompleted(ref awaiter, ref this);
									num4 = 10;
									continue;
								case 9:
									goto end_IL_0046;
								}
								goto IL_0172;
								continue;
								end_IL_0046:
								break;
							}
						}
						catch (Exception exception)
						{
							int num5 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 != 0)
							{
								num5 = 0;
							}
							while (true)
							{
								switch (num5)
								{
								default:
									_Strategy.SetException(exception);
									num5 = 2;
									break;
								case 1:
									_Policy = -2;
									num5 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e != 0)
									{
										num5 = 0;
									}
									break;
								case 2:
									return;
								}
							}
						}
						goto default;
					case 3:
						return;
					default:
						_Policy = -2;
						num2 = 4;
						break;
					case 2:
						num3 = _Policy;
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
						{
							num2 = 0;
						}
						break;
					case 4:
						_Strategy.SetResult();
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 != 0)
						{
							num2 = 3;
						}
						break;
					}
				}
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine([_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)] IAsyncStateMachine stateMachine)
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
						_Strategy.SetStateMachine(stateMachine);
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 == 0)
						{
							num2 = 0;
						}
						break;
					case 0:
						return;
					}
				}
			}

			void IAsyncStateMachine.SetStateMachine([_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)] IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}

			internal static bool InsertExpression()
			{
				return SortExpression == null;
			}

			internal static object FindExpression()
			{
				return SortExpression;
			}
		}

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public static readonly _003C_003Ec m_Server;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public static EventHandler algo;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public static Action m_Importer;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public static EventHandler m_Creator;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public static Action printer;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public static EventHandler _Database;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public static Action m_Error;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public static EventHandler _Reg;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public static Action reponse;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public static EventHandler m_Proxy;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public static Action m_Model;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public static EventHandler advisor;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public static Action _Connection;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public static Func<Task> m_Annotation;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public static Func<Type, bool> repository;

		internal static _003C_003Ec PushExpression;

		static _003C_003Ec()
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					m_Server = new _003C_003Ec();
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
					{
						num2 = 0;
					}
					break;
				case 2:
					return;
				case 1:
					GetterIssuer.DeleteInitializer();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		public _003C_003Ec()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)]
		internal void _003CAwake_003Eb__62_1(object _, EventArgs _)
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
					m_Product.AssignLocalValue(_Facade.Value);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		internal void _003CAwake_003Eb__62_2()
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
					AcLogger.LogInfo(string.Format(DicSingleton.gE3WbyDVW(-1880453928 ^ -1880451932), m_Product.Value));
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

		[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)]
		internal void _003CAwake_003Eb__62_3(object _, EventArgs _)
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
					m_Registry.AssignLocalValue(m_Event.Value);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		internal void _003CAwake_003Eb__62_4()
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
					AcLogger.LogInfo(string.Format(DicSingleton.gE3WbyDVW(0x21AFFB2B ^ 0x21AFE395), m_Registry.Value));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c != 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)]
		internal void _003CAwake_003Eb__62_5(object _, EventArgs _)
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
					decorator.AssignLocalValue(client.Value);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		internal void _003CAwake_003Eb__62_6()
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
					AcLogger.LogInfo(string.Format(DicSingleton.gE3WbyDVW(-525002617 ^ -525008507), decorator.Value));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)]
		internal void _003CAwake_003Eb__62_7(object _, EventArgs _)
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
					broadcaster.AssignLocalValue(m_Record.Value);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf != 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		internal void _003CAwake_003Eb__62_8()
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
					AcLogger.LogInfo(string.Format(DicSingleton.gE3WbyDVW(-736996892 ^ -736999244), broadcaster.Value));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)]
		internal void _003CAwake_003Eb__62_9(object _, EventArgs _)
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
					m_Worker.AssignLocalValue(service.Value);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 != 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		internal void _003CAwake_003Eb__62_10()
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
					AcLogger.LogInfo(string.Format(DicSingleton.gE3WbyDVW(0x59C84793 ^ 0x59C85E01), m_Worker.Value));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)]
		internal void _003CAwake_003Eb__62_11(object _, EventArgs _)
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
					_Task.AssignLocalValue(_Parameter.Value);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		internal void _003CAwake_003Eb__62_12()
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
					AcLogger.LogInfo(string.Format(DicSingleton.gE3WbyDVW(-1461449777 ^ -1461448167), _Task.Value));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)]
		[AsyncStateMachine(typeof(Stub))]
		internal Task _003CPopulateLinkHook_003Eb__65_0()
		{
			int num = 2;
			int num2 = num;
			Stub stateMachine = default(Stub);
			while (true)
			{
				switch (num2)
				{
				case 1:
					stateMachine._Policy = -1;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 != 0)
					{
						num2 = 0;
					}
					break;
				default:
					stateMachine._Strategy.Start(ref stateMachine);
					num2 = 3;
					break;
				case 3:
					return stateMachine._Strategy.Task;
				case 2:
					stateMachine._Strategy = AsyncTaskMethodBuilder.Create();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
					{
						num2 = 1;
					}
					break;
				}
			}
		}

		[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)]
		internal bool _003Cxouweoriulf_003Eb__77_0(Type ex)
		{
			return ex != null;
		}

		internal static bool ValidateExpression()
		{
			return PushExpression == null;
		}

		internal static _003C_003Ec EnableExpression()
		{
			return PushExpression;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetAsync_003Ed__63 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public string uri;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		private HttpWebResponse _003Cresponse_003E5__2;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		private TaskAwaiter<WebResponse> _003C_003Eu__1;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		private Stream _003Cstream_003E5__3;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		private StreamReader _003Creader_003E5__4;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		private TaskAwaiter<string> _003C_003Eu__2;

		private static object VisitExpression;

		private void MoveNext()
		{
			int num = 2;
			int num3 = default(int);
			TaskAwaiter<WebResponse> awaiter2 = default(TaskAwaiter<WebResponse>);
			WebResponse result2 = default(WebResponse);
			TaskAwaiter<string> awaiter = default(TaskAwaiter<string>);
			string result = default(string);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					case 3:
						_003C_003E1__state = -2;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
						{
							num2 = 0;
						}
						continue;
					case 1:
						try
						{
							int num4;
							if (num3 == 0)
							{
								num4 = 6;
								goto IL_0068;
							}
							goto IL_0118;
							IL_0152:
							num4 = 3;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
							{
								num4 = 8;
							}
							goto IL_0068;
							IL_0068:
							while (true)
							{
								switch (num4)
								{
								case 3:
									_003C_003Eu__1 = default(TaskAwaiter<WebResponse>);
									num4 = 4;
									continue;
								case 4:
									num3 = (_003C_003E1__state = -1);
									num4 = 11;
									continue;
								case 7:
									return;
								case 9:
									_003C_003Eu__1 = awaiter2;
									num4 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec != 0)
									{
										num4 = 0;
									}
									continue;
								case 12:
									break;
								default:
									_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
									num4 = 7;
									continue;
								case 2:
									goto IL_0152;
								case 5:
									num3 = (_003C_003E1__state = 0);
									num4 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
									{
										num4 = 9;
									}
									continue;
								case 6:
								case 10:
									awaiter2 = _003C_003Eu__1;
									num4 = 3;
									continue;
								case 11:
									result2 = awaiter2.GetResult();
									num4 = 14;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db == 0)
									{
										num4 = 10;
									}
									continue;
								case 14:
									_003Cresponse_003E5__2 = (HttpWebResponse)result2;
									num4 = 2;
									continue;
								case 13:
									if (!awaiter2.IsCompleted)
									{
										num4 = 5;
										continue;
									}
									goto case 11;
								case 1:
								{
									HttpWebRequest obj = (HttpWebRequest)WebRequest.Create(uri);
									obj.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
									awaiter2 = obj.GetResponseAsync().GetAwaiter();
									num4 = 5;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
									{
										num4 = 13;
									}
									continue;
								}
								case 8:
									try
									{
										int num5;
										if (num3 != 1)
										{
											num5 = 2;
											goto IL_0247;
										}
										goto IL_025d;
										IL_025d:
										num5 = 1;
										if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
										{
											num5 = 1;
										}
										goto IL_0247;
										IL_0247:
										while (true)
										{
											switch (num5)
											{
											case 2:
												_003Cstream_003E5__3 = _003Cresponse_003E5__2.GetResponseStream();
												num5 = 0;
												if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
												{
													num5 = 0;
												}
												continue;
											case 1:
												try
												{
													int num6;
													if (num3 != 1)
													{
														num6 = 2;
														goto IL_02ba;
													}
													goto IL_02d0;
													IL_02d0:
													num6 = 0;
													if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 != 0)
													{
														num6 = 0;
													}
													goto IL_02ba;
													IL_02ba:
													while (true)
													{
														switch (num6)
														{
														case 1:
															break;
														case 2:
															_003Creader_003E5__4 = new StreamReader(_003Cstream_003E5__3);
															num6 = 1;
															if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
															{
																num6 = 1;
															}
															continue;
														default:
															try
															{
																int num7;
																if (num3 != 1)
																{
																	num7 = 1;
																	if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
																	{
																		num7 = 1;
																	}
																	goto IL_033d;
																}
																goto IL_044d;
																IL_033d:
																while (true)
																{
																	switch (num7)
																	{
																	case 9:
																		num3 = (_003C_003E1__state = -1);
																		num7 = 3;
																		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
																		{
																			num7 = 1;
																		}
																		continue;
																	default:
																		_003C_003Eu__2 = default(TaskAwaiter<string>);
																		num7 = 9;
																		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
																		{
																			num7 = 6;
																		}
																		continue;
																	case 7:
																		_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
																		num7 = 2;
																		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 == 0)
																		{
																			num7 = 2;
																		}
																		continue;
																	case 2:
																		return;
																	case 4:
																		_003C_003Eu__2 = awaiter;
																		num7 = 0;
																		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
																		{
																			num7 = 7;
																		}
																		continue;
																	case 3:
																		result = awaiter.GetResult();
																		num7 = 8;
																		continue;
																	case 6:
																		num3 = (_003C_003E1__state = 1);
																		num7 = 4;
																		continue;
																	case 10:
																		break;
																	case 5:
																		if (!awaiter.IsCompleted)
																		{
																			num7 = 6;
																			continue;
																		}
																		goto case 3;
																	case 1:
																		awaiter = _003Creader_003E5__4.ReadToEndAsync().GetAwaiter();
																		num7 = 0;
																		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
																		{
																			num7 = 5;
																		}
																		continue;
																	case 8:
																		goto end_IL_033d;
																	}
																	goto IL_044d;
																	continue;
																	end_IL_033d:
																	break;
																}
																goto end_IL_0317;
																IL_044d:
																awaiter = _003C_003Eu__2;
																num7 = 0;
																if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
																{
																	num7 = 0;
																}
																goto IL_033d;
																end_IL_0317:;
															}
															finally
															{
																int num8;
																if (num3 >= 0)
																{
																	num8 = 0;
																	if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
																	{
																		num8 = 1;
																	}
																	goto IL_04dc;
																}
																goto IL_051a;
																IL_04dc:
																while (true)
																{
																	switch (num8)
																	{
																	default:
																		goto IL_04f6;
																	case 1:
																		goto end_IL_04dc;
																	case 2:
																		break;
																	case 3:
																		goto end_IL_04dc;
																	}
																	goto IL_051a;
																	IL_04f6:
																	((IDisposable)_003Creader_003E5__4).Dispose();
																	num8 = 3;
																	continue;
																	end_IL_04dc:
																	break;
																}
																goto end_IL_04b6;
																IL_051a:
																if (_003Creader_003E5__4 != null)
																{
																	num8 = 0;
																	if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
																	{
																		num8 = 0;
																	}
																	goto IL_04dc;
																}
																end_IL_04b6:;
															}
															goto end_IL_02ba;
														}
														goto IL_02d0;
														continue;
														end_IL_02ba:
														break;
													}
												}
												finally
												{
													if (num3 < 0)
													{
														int num9 = 1;
														if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
														{
															num9 = 1;
														}
														while (true)
														{
															switch (num9)
															{
															case 1:
																if (_003Cstream_003E5__3 != null)
																{
																	num9 = 2;
																	continue;
																}
																break;
															case 2:
																((IDisposable)_003Cstream_003E5__3).Dispose();
																num9 = 0;
																if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 != 0)
																{
																	num9 = 0;
																}
																continue;
															case 0:
																break;
															}
															break;
														}
													}
												}
												goto end_IL_0247;
											}
											goto IL_025d;
											continue;
											end_IL_0247:
											break;
										}
									}
									finally
									{
										int num10;
										if (num3 >= 0)
										{
											num10 = 3;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 != 0)
											{
												num10 = 3;
											}
											goto IL_05dd;
										}
										goto IL_05f7;
										IL_05dd:
										while (true)
										{
											switch (num10)
											{
											default:
												goto end_IL_05dd;
											case 2:
												break;
											case 3:
												goto end_IL_05dd;
											case 1:
												((IDisposable)_003Cresponse_003E5__2).Dispose();
												num10 = 0;
												if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
												{
													num10 = 0;
												}
												continue;
											case 0:
												goto end_IL_05dd;
											}
											goto IL_05f7;
											continue;
											end_IL_05dd:
											break;
										}
										goto end_IL_05b7;
										IL_05f7:
										if (_003Cresponse_003E5__2 != null)
										{
											num10 = 0;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
											{
												num10 = 1;
											}
											goto IL_05dd;
										}
										end_IL_05b7:;
									}
									goto end_IL_0053;
								}
								break;
							}
							goto IL_0118;
							IL_0118:
							if (num3 != 1)
							{
								num4 = 1;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 != 0)
								{
									num4 = 0;
								}
								goto IL_0068;
							}
							goto IL_0152;
							end_IL_0053:;
						}
						catch (Exception exception)
						{
							int num11 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 != 0)
							{
								num11 = 0;
							}
							while (true)
							{
								switch (num11)
								{
								case 1:
									_003C_003Et__builder.SetException(exception);
									num11 = 2;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 != 0)
									{
										num11 = 0;
									}
									break;
								default:
									_003C_003E1__state = -2;
									num11 = 1;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
									{
										num11 = 1;
									}
									break;
								case 2:
									return;
								}
							}
						}
						goto case 3;
					case 2:
						num3 = _003C_003E1__state;
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
						{
							num2 = 1;
						}
						continue;
					case 4:
						return;
					}
					break;
				}
				_003C_003Et__builder.SetResult(result);
				num = 4;
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine([_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)] IAsyncStateMachine stateMachine)
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
					_003C_003Et__builder.SetStateMachine(stateMachine);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		void IAsyncStateMachine.SetStateMachine([_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)] IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}

		internal static bool OrderExpression()
		{
			return VisitExpression == null;
		}

		internal static object UpdateExpression()
		{
			return VisitExpression;
		}
	}

	[CompilerGenerated]
	private sealed class _003CStuffAndThings_003Ed__80 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		private object _003C_003E2__current;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public AzuAnticheatPlugin _003C_003E4__this;

		private static _003CStuffAndThings_003Ed__80 SearchExpression;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			[return: _003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			[return: _003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CStuffAndThings_003Ed__80(int _003C_003E1__state)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
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
			int num = _003C_003E1__state;
			AzuAnticheatPlugin azuAnticheatPlugin = _003C_003E4__this;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
			}
			else
			{
				_003C_003E1__state = -1;
			}
			Player localPlayer = Player.m_localPlayer;
			serializer = _Candidate.IsAdmin;
			if ((bool)ZNetScene.instance && localPlayer != null && !serializer)
			{
				bool flag = false;
				try
				{
					foreach (Process item in azuAnticheatPlugin.m_Page)
					{
						if (m_Parser.Contains(item.ProcessName.ToLowerInvariant()) && (!(item.ProcessName.ToLowerInvariant() == DicSingleton.gE3WbyDVW(0x9000142 ^ 0x9001BE0)) || !(item.ProcessName.ToLowerInvariant() == DicSingleton.gE3WbyDVW(--708144185 ^ 0x2A3576FD))))
						{
							item.Kill();
							Property.MsgDsc(DicSingleton.gE3WbyDVW(-1461449777 ^ -1461448403) + item.ProcessName, DicSingleton.gE3WbyDVW(-1011281439 ^ -1011283219));
							global = Localization.instance.Localize(DicSingleton.gE3WbyDVW(0x548F02D9 ^ 0x548F19D5));
							flag = true;
						}
					}
				}
				catch
				{
				}
				if (localPlayer != null && !serializer)
				{
					if (authentication && !_Producer)
					{
						global = _Composer;
						Property.MsgDsc(DicSingleton.gE3WbyDVW(0x540450D2 ^ 0x54044BEE) + _Composer, DicSingleton.gE3WbyDVW(-948533799 ^ -948527451));
						flag = true;
					}
					if (localPlayer.InGodMode() && (!_Producer || (_Producer && !_Helper[_Indexer].GodModeBypass.Value)))
					{
						global = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-1059662249 ^ -1059664399));
						Property.MsgDsc(DicSingleton.gE3WbyDVW(-1483531944 ^ -1483537778), DicSingleton.gE3WbyDVW(-1817326817 ^ -1817323773));
						flag = true;
					}
					if (localPlayer.m_debugFly && (!_Producer || (_Producer && !_Helper[_Indexer].FlightBypass.Value)))
					{
						global = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-614239580 ^ -614240538));
						Property.MsgDsc(DicSingleton.gE3WbyDVW(0x6BAF1854 ^ 0x6BAF0434), DicSingleton.gE3WbyDVW(-1059662249 ^ -1059665387));
						flag = true;
					}
					if (localPlayer.NoCostCheat() && (!_Producer || (_Producer && !_Helper[_Indexer].NoCostCheatBypass.Value)))
					{
						global = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-1389846755 ^ -1389853821));
						Property.MsgDsc(DicSingleton.gE3WbyDVW(-1880453928 ^ -1880453094), DicSingleton.gE3WbyDVW(-1743264324 ^ -1743259358));
						flag = true;
					}
					if (GameCamera.instance.m_freeFly && (!_Producer || (_Producer && !_Helper[_Indexer].FreeFlyCamBypass.Value)))
					{
						global = Localization.instance.Localize(DicSingleton.gE3WbyDVW(0x567B7B7F ^ 0x567B6679));
						Property.MsgDsc(DicSingleton.gE3WbyDVW(0x548F02D9 ^ 0x548F1FF5), DicSingleton.gE3WbyDVW(-428135557 ^ -428132739));
						flag = true;
					}
					if (localPlayer.m_ghostMode && !((Character)localPlayer).m_nview.GetZDO().GetBool(DicSingleton.gE3WbyDVW(--650088194 ^ 0x26BF9270)) && !Property.CanGhost(localPlayer) && (!_Producer || (_Producer && !_Helper[_Indexer].GhostModeBypass.Value)))
					{
						global = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-849667636 ^ -849673152));
						Property.MsgDsc(DicSingleton.gE3WbyDVW(-598551743 ^ -598552841), DicSingleton.gE3WbyDVW(-1544119467 ^ -1544124711));
						flag = true;
					}
					if ((localPlayer.GetMaxCarryWeight() > (float)decorator.Value || localPlayer.m_maxCarryWeight > (float)decorator.Value) && (!_Producer || (_Producer && !_Helper[_Indexer].WeightLimitBypass.Value)))
					{
						global = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-1053593978 ^ -1053593466));
						Property.MsgDsc(string.Format(DicSingleton.gE3WbyDVW(-1741204886 ^ -1741206460), localPlayer.GetMaxCarryWeight()), DicSingleton.gE3WbyDVW(-428683152 ^ -428683664));
						flag = true;
					}
					if (localPlayer.GetMaxHealth() > (float)m_Product.Value && (!_Producer || (_Producer && !_Helper[_Indexer].HealthBypass.Value)))
					{
						global = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-1398029315 ^ -1398022793));
						Property.MsgDsc(string.Format(DicSingleton.gE3WbyDVW(-1507873642 ^ -1507872212), localPlayer.GetMaxHealth()), DicSingleton.gE3WbyDVW(-1735703950 ^ -1735697160));
						flag = true;
					}
					if (localPlayer.GetMaxStamina() > (float)m_Registry.Value)
					{
						global = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-1773869960 ^ -1773864096));
						Property.MsgDsc(string.Format(DicSingleton.gE3WbyDVW(-1580624393 ^ -1580627267), localPlayer.GetMaxStamina()), DicSingleton.gE3WbyDVW(-379532028 ^ -379530724));
						flag = true;
					}
					if (localPlayer.IsFlying() && (!_Producer || (_Producer && !_Helper[_Indexer].FlightBypass.Value)))
					{
						global = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-736996892 ^ -736997978));
						Property.MsgDsc(DicSingleton.gE3WbyDVW(-447849421 ^ -447855719), DicSingleton.gE3WbyDVW(--798431903 ^ 0x2F9706DD));
						flag = true;
					}
					if (interpreter)
					{
						global = Localization.instance.Localize(DicSingleton.gE3WbyDVW(-1880453928 ^ -1880452344));
						Property.MsgDsc(DicSingleton.gE3WbyDVW(0x270E0638 ^ 0x270E263E), DicSingleton.gE3WbyDVW(0x4F8CB66E ^ 0x4F8CA9BE));
						flag = true;
					}
				}
				if (localPlayer != null && flag)
				{
					azuAnticheatPlugin.Invoke(DicSingleton.gE3WbyDVW(0x69B67B3A ^ 0x69B65B76), 2f);
					_Invocation = true;
					localPlayer.GetComponent<PlayerController>().enabled = false;
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = false;
				}
			}
			_003C_003E2__current = new WaitForSecondsRealtime(1f);
			_003C_003E1__state = 1;
			return true;
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

		internal static bool StopExpression()
		{
			return SearchExpression == null;
		}

		internal static _003CStuffAndThings_003Ed__80 ExcludeExpression()
		{
			return SearchExpression;
		}
	}

	private static string _Publisher;

	private static string @base;

	private static AppDomain _Prototype;

	private static string m_Interceptor;

	private static string _Filter;

	internal static string reader;

	private static readonly string setter;

	internal static string _Writer;

	private static bool _Invocation;

	internal static bool authentication;

	internal static bool m_Attribute;

	internal static bool interpreter;

	internal static bool m_Issuer;

	private bool rule;

	internal static bool serializer;

	internal static bool _Producer;

	[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(2)]
	internal static string _Comparator;

	[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(new byte[] { 1, 2 })]
	internal static List<Params> _Definition;

	internal static string _Composer;

	internal static string global;

	internal static readonly SortedDictionary<string, string> m_Map;

	internal static SortedDictionary<string, Dispatcher> _Helper;

	private static Rect _Exception;

	private static List<Assembly> mapper;

	private static List<Assembly> m_Identifier;

	private static Dictionary<Assembly, string> token;

	private static Dictionary<Assembly, string> callback;

	internal static string m_Rules;

	internal static string getter;

	internal static string m_Code;

	internal static string _Indexer;

	internal static string mock;

	internal static string _Template;

	internal static string m_Predicate;

	internal readonly Harmony m_Watcher;

	internal static string system;

	public static readonly ManualLogSource AcLogger;

	internal static AzuAnticheatPlugin resolver;

	private static readonly RepositoryPublisher _Candidate;

	internal static readonly ConnectionPublisher<int> m_Product;

	internal static readonly ConnectionPublisher<int> m_Registry;

	internal static readonly ConnectionPublisher<int> decorator;

	internal static readonly ConnectionPublisher<int> broadcaster;

	internal static readonly ConnectionPublisher<float> m_Worker;

	internal static readonly ConnectionPublisher<bool> _Task;

	internal static ConnectionPublisher<string> _Tests;

	internal static ConnectionPublisher<string> _Initializer;

	private ConcurrentBag<Process> m_Page;

	private static HashSet<string> m_Parser;

	private CancellationTokenSource _Request;

	[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(2)]
	private static ConfigEntry<Toggle> m_Param;

	internal static ConfigEntry<int> _Facade;

	internal static ConfigEntry<int> m_Event;

	internal static ConfigEntry<int> client;

	internal static ConfigEntry<int> m_Record;

	internal static ConfigEntry<float> service;

	internal static ConfigEntry<bool> bridge;

	internal static ConfigEntry<bool> _Parameter;

	internal static ConfigEntry<string> _Status;

	internal static ConfigEntry<string> test;

	private static AzuAnticheatPlugin PrepareExpression;

	public void Awake()
	{
		int num = 14;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 2:
					m_Event = base.Config.Bind(DicSingleton.gE3WbyDVW(-243097544 ^ -243095174), DicSingleton.gE3WbyDVW(-1385030784 ^ -1385033134), 1000, new ConfigDescription(DicSingleton.gE3WbyDVW(-1180565667 ^ -1180567891), null, new Attr()));
					num2 = 25;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
					{
						num2 = 19;
					}
					continue;
				case 14:
					resolver = this;
					num2 = 13;
					continue;
				case 21:
					_Candidate.AddLockingConfigEntry(m_Param);
					num2 = 35;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
					{
						num2 = 34;
					}
					continue;
				case 5:
					_Parameter = base.Config.Bind(DicSingleton.gE3WbyDVW(-1335677307 ^ -1335677307), DicSingleton.gE3WbyDVW(-1817326817 ^ -1817325889), defaultValue: false, new ConfigDescription(DicSingleton.gE3WbyDVW(0x5A1F7167 ^ 0x5A1F74DD), null, new Attr()));
					num2 = 45;
					continue;
				case 9:
					m_Record = base.Config.Bind(DicSingleton.gE3WbyDVW(0x548F02D9 ^ 0x548F0B9B), DicSingleton.gE3WbyDVW(-1866665889 ^ -1866663277), 55000, new ConfigDescription(DicSingleton.gE3WbyDVW(0x6BAF1854 ^ 0x6BAF12A4), null, new Attr()));
					num2 = 20;
					continue;
				case 33:
					m_Worker.AssignLocalValue(service.Value);
					num2 = 22;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb == 0)
					{
						num2 = 2;
					}
					continue;
				case 38:
					Directory.CreateDirectory(_Filter);
					num2 = 37;
					continue;
				case 25:
					client = base.Config.Bind(DicSingleton.gE3WbyDVW(0x4C23C86A ^ 0x4C23C128), DicSingleton.gE3WbyDVW(0x567B7B7F ^ 0x567B7131), 5000, new ConfigDescription(DicSingleton.gE3WbyDVW(-293474990 ^ -293476572), null, new Attr()));
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 != 0)
					{
						num2 = 9;
					}
					continue;
				case 17:
					_Status = base.Config.Bind(DicSingleton.gE3WbyDVW(-379532028 ^ -379532028), DicSingleton.gE3WbyDVW(-360128320 ^ -360127756), DicSingleton.gE3WbyDVW(-359091888 ^ -359091402), new ConfigDescription(DicSingleton.gE3WbyDVW(-1931860206 ^ -1931860630), new AcceptableValueList<string>(Localization.instance.m_languages.ToArray()), new Attr()));
					num = 5;
					break;
				case 11:
					ServerBase.AddPlaceholder(DicSingleton.gE3WbyDVW(0x540450D2 ^ 0x54045BE4), DicSingleton.gE3WbyDVW(-1549341817 ^ -1549344763), client);
					num2 = 40;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
					{
						num2 = 23;
					}
					continue;
				case 37:
					DeleteThemYams(m_Interceptor);
					num2 = 30;
					continue;
				case 10:
					erwerwergarnh(null, null);
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c != 0)
					{
						num2 = 46;
					}
					continue;
				case 30:
					DeleteThemYams(_Filter);
					num2 = 17;
					continue;
				case 18:
					m_Param = config(DicSingleton.gE3WbyDVW(-428683152 ^ -428683152), DicSingleton.gE3WbyDVW(-1741204886 ^ -1741204880), Toggle.On, DicSingleton.gE3WbyDVW(-1544119467 ^ -1544119529));
					num2 = 21;
					continue;
				case 44:
					broadcaster.AssignLocalValue(m_Record.Value);
					num = 26;
					break;
				case 8:
					_Facade = base.Config.Bind(DicSingleton.gE3WbyDVW(-316028230 ^ -316029960), DicSingleton.gE3WbyDVW(-1830690703 ^ -1830688469), 1000, new ConfigDescription(DicSingleton.gE3WbyDVW(0x408F2744 ^ 0x408F2E32), null, new Attr()));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 == 0)
					{
						num2 = 2;
					}
					continue;
				case 36:
					m_Registry.AssignLocalValue(m_Event.Value);
					num2 = 12;
					continue;
				case 43:
					PopulateLinkHook();
					num2 = 24;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
					{
						num2 = 17;
					}
					continue;
				case 24:
					system = InvocationPublisher.ComputeHashForMod().Replace(DicSingleton.gE3WbyDVW(-447849421 ^ -447852369), "");
					num2 = 32;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba != 0)
					{
						num2 = 3;
					}
					continue;
				case 6:
					decorator.AssignLocalValue(client.Value);
					num2 = 7;
					continue;
				case 16:
					if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.Null)
					{
						num2 = 39;
						continue;
					}
					goto case 24;
				case 15:
					InvokeRepeating(DicSingleton.gE3WbyDVW(0x548F02D9 ^ 0x548F0EB7), 0f, m_Worker.Value);
					num2 = 43;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
					{
						num2 = 32;
					}
					continue;
				case 39:
					Directory.CreateDirectory(m_Interceptor);
					num2 = 38;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db == 0)
					{
						num2 = 34;
					}
					continue;
				case 31:
					m_Product.AssignLocalValue(_Facade.Value);
					num2 = 4;
					continue;
				case 41:
					_Task.AssignLocalValue(_Parameter.Value);
					num2 = 11;
					continue;
				case 13:
					ServerBase.Load();
					num2 = 18;
					continue;
				case 42:
					SetupWatchers();
					num = 10;
					break;
				case 47:
					bridge = base.Config.Bind(DicSingleton.gE3WbyDVW(-25744665 ^ -25744665), DicSingleton.gE3WbyDVW(0x940D407 ^ 0x940DC75), defaultValue: false, new ConfigDescription(DicSingleton.gE3WbyDVW(-1507873642 ^ -1507875812), null, new Attr()));
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b != 0)
					{
						num2 = 3;
					}
					continue;
				default:
					ServerBase.AddPlaceholder(DicSingleton.gE3WbyDVW(-475093377 ^ -475092355), DicSingleton.gE3WbyDVW(-1817326817 ^ -1817327795), m_Event);
					num = 15;
					break;
				case 28:
					m_Watcher.PatchAll();
					num2 = 42;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
					{
						num2 = 1;
					}
					continue;
				case 45:
					service = base.Config.Bind(DicSingleton.gE3WbyDVW(-1461449777 ^ -1461449777), DicSingleton.gE3WbyDVW(0x4097B854 ^ 0x4097BEFA), 60f, new ConfigDescription(DicSingleton.gE3WbyDVW(-1829625923 ^ -1829627547), null, new Attr()));
					num2 = 47;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
					{
						num2 = 32;
					}
					continue;
				case 20:
					bridge.SettingChanged += [_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)] (object _, EventArgs _) =>
					{
						PopulateLinkHook();
					};
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d != 0)
					{
						num2 = 23;
					}
					continue;
				case 35:
					test = config(DicSingleton.gE3WbyDVW(0x6BAF1854 ^ 0x6BAF188A), DicSingleton.gE3WbyDVW(-940539791 ^ -940539773), "", new ConfigDescription(DicSingleton.gE3WbyDVW(0x1C9EFC64 ^ 0x1C9EFD74), null), synchronizedSetting: false);
					num2 = 16;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba != 0)
					{
						num2 = 10;
					}
					continue;
				case 46:
					return;
				case 40:
					ServerBase.AddPlaceholder(DicSingleton.gE3WbyDVW(-380885952 ^ -380882982), DicSingleton.gE3WbyDVW(0x166FBD ^ 0x166455), _Facade);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
					{
						num2 = 0;
					}
					continue;
				case 23:
					_Facade.SettingChanged += [_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)] (object _, EventArgs _) =>
					{
						int num3 = 1;
						int num4 = num3;
						while (true)
						{
							switch (num4)
							{
							default:
								return;
							case 0:
								return;
							case 1:
								m_Product.AssignLocalValue(_Facade.Value);
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
								{
									num4 = 0;
								}
								break;
							}
						}
					};
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b != 0)
					{
						num2 = 1;
					}
					continue;
				case 1:
					m_Product.CalcRole(delegate
					{
						int num3 = 1;
						int num4 = num3;
						while (true)
						{
							switch (num4)
							{
							default:
								return;
							case 1:
								AcLogger.LogInfo(string.Format(DicSingleton.gE3WbyDVW(-1880453928 ^ -1880451932), m_Product.Value));
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
								{
									num4 = 0;
								}
								break;
							case 0:
								return;
							}
						}
					});
					num2 = 31;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 == 0)
					{
						num2 = 23;
					}
					continue;
				case 4:
					m_Event.SettingChanged += [_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)] (object _, EventArgs _) =>
					{
						int num3 = 1;
						int num4 = num3;
						while (true)
						{
							switch (num4)
							{
							default:
								return;
							case 1:
								m_Registry.AssignLocalValue(m_Event.Value);
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
								{
									num4 = 0;
								}
								break;
							case 0:
								return;
							}
						}
					};
					num2 = 27;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
					{
						num2 = 17;
					}
					continue;
				case 27:
					m_Registry.CalcRole(delegate
					{
						int num3 = 1;
						int num4 = num3;
						while (true)
						{
							switch (num4)
							{
							default:
								return;
							case 1:
								AcLogger.LogInfo(string.Format(DicSingleton.gE3WbyDVW(0x21AFFB2B ^ 0x21AFE395), m_Registry.Value));
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c != 0)
								{
									num4 = 0;
								}
								break;
							case 0:
								return;
							}
						}
					});
					num2 = 36;
					continue;
				case 12:
					client.SettingChanged += [_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)] (object _, EventArgs _) =>
					{
						int num3 = 1;
						int num4 = num3;
						while (true)
						{
							switch (num4)
							{
							default:
								return;
							case 0:
								return;
							case 1:
								decorator.AssignLocalValue(client.Value);
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
								{
									num4 = 0;
								}
								break;
							}
						}
					};
					num2 = 19;
					continue;
				case 19:
					decorator.CalcRole(delegate
					{
						int num3 = 1;
						int num4 = num3;
						while (true)
						{
							switch (num4)
							{
							default:
								return;
							case 0:
								return;
							case 1:
								AcLogger.LogInfo(string.Format(DicSingleton.gE3WbyDVW(-525002617 ^ -525008507), decorator.Value));
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
								{
									num4 = 0;
								}
								break;
							}
						}
					});
					num = 6;
					break;
				case 7:
					m_Record.SettingChanged += [_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)] (object _, EventArgs _) =>
					{
						int num3 = 1;
						int num4 = num3;
						while (true)
						{
							switch (num4)
							{
							default:
								return;
							case 1:
								broadcaster.AssignLocalValue(m_Record.Value);
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf != 0)
								{
									num4 = 0;
								}
								break;
							case 0:
								return;
							}
						}
					};
					num2 = 3;
					continue;
				case 3:
					broadcaster.CalcRole(delegate
					{
						int num3 = 1;
						int num4 = num3;
						while (true)
						{
							switch (num4)
							{
							default:
								return;
							case 0:
								return;
							case 1:
								AcLogger.LogInfo(string.Format(DicSingleton.gE3WbyDVW(-736996892 ^ -736999244), broadcaster.Value));
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
								{
									num4 = 0;
								}
								break;
							}
						}
					});
					num2 = 44;
					continue;
				case 26:
					service.SettingChanged += [_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)] (object _, EventArgs _) =>
					{
						int num3 = 1;
						int num4 = num3;
						while (true)
						{
							switch (num4)
							{
							default:
								return;
							case 1:
								m_Worker.AssignLocalValue(service.Value);
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 != 0)
								{
									num4 = 0;
								}
								break;
							case 0:
								return;
							}
						}
					};
					num = 34;
					break;
				case 34:
					m_Worker.CalcRole(delegate
					{
						int num3 = 1;
						int num4 = num3;
						while (true)
						{
							switch (num4)
							{
							default:
								return;
							case 0:
								return;
							case 1:
								AcLogger.LogInfo(string.Format(DicSingleton.gE3WbyDVW(0x59C84793 ^ 0x59C85E01), m_Worker.Value));
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
								{
									num4 = 0;
								}
								break;
							}
						}
					});
					num2 = 33;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
					{
						num2 = 27;
					}
					continue;
				case 22:
					_Parameter.SettingChanged += [_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)] (object _, EventArgs _) =>
					{
						int num3 = 1;
						int num4 = num3;
						while (true)
						{
							switch (num4)
							{
							default:
								return;
							case 1:
								_Task.AssignLocalValue(_Parameter.Value);
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
								{
									num4 = 0;
								}
								break;
							case 0:
								return;
							}
						}
					};
					num2 = 29;
					continue;
				case 29:
					_Task.CalcRole(delegate
					{
						int num3 = 1;
						int num4 = num3;
						while (true)
						{
							switch (num4)
							{
							default:
								return;
							case 1:
								AcLogger.LogInfo(string.Format(DicSingleton.gE3WbyDVW(-1461449777 ^ -1461448167), _Task.Value));
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
								{
									num4 = 0;
								}
								break;
							case 0:
								return;
							}
						}
					});
					num2 = 41;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd != 0)
					{
						num2 = 6;
					}
					continue;
				case 32:
					_Tests.CalcRole(tcfuyvghbuj);
					num2 = 17;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 != 0)
					{
						num2 = 28;
					}
					continue;
				}
				break;
			}
		}
	}

	[AsyncStateMachine(typeof(_003CGetAsync_003Ed__63))]
	public static Task<string> GetAsync(string uri)
	{
		_003CGetAsync_003Ed__63 stateMachine = default(_003CGetAsync_003Ed__63);
		stateMachine._003C_003Et__builder = AsyncTaskMethodBuilder<string>.Create();
		stateMachine.uri = uri;
		stateMachine._003C_003E1__state = -1;
		stateMachine._003C_003Et__builder.Start(ref stateMachine);
		return stateMachine._003C_003Et__builder.Task;
	}

	public static string Deobf(string input)
	{
		int num = 1;
		int num2 = num;
		byte[] bytes = default(byte[]);
		while (true)
		{
			switch (num2)
			{
			case 1:
				bytes = Convert.FromBase64String(input);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db != 0)
				{
					num2 = 0;
				}
				break;
			default:
				return Encoding.UTF8.GetString(bytes);
			}
		}
	}

	internal void PopulateLinkHook()
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			Func<Task> func;
			switch (num2)
			{
			case 2:
				func = _003C_003Ec.m_Annotation;
				if (func == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			case 1:
				return;
			case 3:
				if (!bridge.Value)
				{
					return;
				}
				num2 = 2;
				continue;
			default:
				func = (_003C_003Ec.m_Annotation = [_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)] [AsyncStateMachine(typeof(_003C_003Ec.Stub))] () =>
				{
					int num3 = 2;
					int num4 = num3;
					_003C_003Ec.Stub stateMachine = default(_003C_003Ec.Stub);
					while (true)
					{
						switch (num4)
						{
						case 1:
							stateMachine._Policy = -1;
							num4 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 != 0)
							{
								num4 = 0;
							}
							break;
						default:
							stateMachine._Strategy.Start(ref stateMachine);
							num4 = 3;
							break;
						case 3:
							return stateMachine._Strategy.Task;
						case 2:
							stateMachine._Strategy = AsyncTaskMethodBuilder.Create();
							num4 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
							{
								num4 = 1;
							}
							break;
						}
					}
				});
				break;
			}
			Task.Run(func);
			num2 = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 != 0)
			{
				num2 = 1;
			}
		}
	}

	public void Start()
	{
		int num = 6;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 3:
					tyuiolasdfasdfasdlkfj();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
					{
						num2 = 1;
					}
					continue;
				case 8:
					return;
				case 10:
					return;
				case 9:
					StartCoroutine(StuffAndThings());
					num2 = 8;
					continue;
				case 2:
					break;
				case 6:
					if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.Null)
					{
						num2 = 5;
						continue;
					}
					goto case 1;
				case 4:
					rule = true;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
					{
						num2 = 0;
					}
					continue;
				default:
					AcLogger.LogInfo(DicSingleton.gE3WbyDVW(-1741204886 ^ -1741201720));
					num2 = 3;
					continue;
				case 1:
					if (SystemInfo.graphicsDeviceType != GraphicsDeviceType.Null)
					{
						Observer.GetModList();
						num2 = 7;
						continue;
					}
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
					{
						num2 = 5;
					}
					continue;
				case 7:
					InitializeBannedProcessNames();
					num2 = 2;
					continue;
				case 5:
					Observer.ModeratorListCreate();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
					{
						num2 = 4;
					}
					continue;
				}
				break;
			}
			StartProcessListRefreshTask();
			num = 9;
		}
	}

	public void OnDestroy()
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
				_Request.Cancel();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				base.Config.Save();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 == 0)
				{
					num2 = 1;
				}
				break;
			case 0:
				return;
			}
		}
	}

	private void SetupWatchers()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 3:
				return;
			case 4:
			{
				FileSystemWatcher fileSystemWatcher3 = new FileSystemWatcher(Paths.ConfigPath, DicSingleton.gE3WbyDVW(-379532028 ^ -379535226));
				fileSystemWatcher3.Changed += ShouldReadNewPlugins;
				fileSystemWatcher3.Created += ShouldReadNewPlugins;
				fileSystemWatcher3.Renamed += ShouldReadNewPlugins;
				fileSystemWatcher3.Deleted += ShouldReadNewPlugins;
				fileSystemWatcher3.IncludeSubdirectories = true;
				fileSystemWatcher3.SynchronizingObject = ThreadingHelper.SynchronizingObject;
				fileSystemWatcher3.EnableRaisingEvents = true;
				num2 = 3;
				break;
			}
			case 1:
			{
				FileSystemWatcher fileSystemWatcher2 = new FileSystemWatcher(Paths.ConfigPath, _Publisher);
				fileSystemWatcher2.Changed += xncvboijrcv;
				fileSystemWatcher2.Created += xncvboijrcv;
				fileSystemWatcher2.Renamed += xncvboijrcv;
				fileSystemWatcher2.IncludeSubdirectories = true;
				fileSystemWatcher2.SynchronizingObject = ThreadingHelper.SynchronizingObject;
				fileSystemWatcher2.EnableRaisingEvents = true;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
				{
					num2 = 0;
				}
				break;
			}
			default:
			{
				FileSystemWatcher fileSystemWatcher4 = new FileSystemWatcher(Paths.ConfigPath, DicSingleton.gE3WbyDVW(-381685266 ^ -381682432));
				fileSystemWatcher4.Changed += erwerwergarnh;
				fileSystemWatcher4.Created += erwerwergarnh;
				fileSystemWatcher4.Renamed += erwerwergarnh;
				fileSystemWatcher4.IncludeSubdirectories = true;
				fileSystemWatcher4.SynchronizingObject = ThreadingHelper.SynchronizingObject;
				fileSystemWatcher4.EnableRaisingEvents = true;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d != 0)
				{
					num2 = 2;
				}
				break;
			}
			case 2:
			{
				FileSystemWatcher fileSystemWatcher = new FileSystemWatcher(Paths.ConfigPath, DicSingleton.gE3WbyDVW(0xDA293E6 ^ 0xDA29ED4));
				fileSystemWatcher.Changed += oasdfouasdkfj;
				fileSystemWatcher.Created += oasdfouasdkfj;
				fileSystemWatcher.Renamed += oasdfouasdkfj;
				fileSystemWatcher.IncludeSubdirectories = true;
				fileSystemWatcher.SynchronizingObject = ThreadingHelper.SynchronizingObject;
				fileSystemWatcher.EnableRaisingEvents = true;
				num2 = 4;
				break;
			}
			}
		}
	}

	private void xncvboijrcv(object sender, FileSystemEventArgs e)
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				try
				{
					AcLogger.LogDebug(DicSingleton.gE3WbyDVW(-1954645236 ^ -1954646372));
					int num3 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 == 0)
					{
						num3 = 0;
					}
					while (true)
					{
						switch (num3)
						{
						case 1:
							return;
						}
						base.Config.Reload();
						num3 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 == 0)
						{
							num3 = 1;
						}
					}
				}
				catch
				{
					int num4 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 != 0)
					{
						num4 = 1;
					}
					while (true)
					{
						switch (num4)
						{
						default:
							return;
						case 2:
							AcLogger.LogError(DicSingleton.gE3WbyDVW(0xFB046CE ^ 0xFB048C8));
							num4 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
							{
								num4 = 0;
							}
							break;
						case 1:
							AcLogger.LogError(DicSingleton.gE3WbyDVW(-2075300707 ^ -2075303585) + _Publisher);
							num4 = 2;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
							{
								num4 = 2;
							}
							break;
						case 0:
							return;
						}
					}
				}
			case 3:
				if (File.Exists(@base))
				{
					num2 = 2;
					break;
				}
				return;
			case 0:
				return;
			case 2:
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 != 0)
				{
					num2 = 1;
				}
				break;
			case 4:
				return;
			}
		}
	}

	private void erwerwergarnh(object sender, FileSystemEventArgs e)
	{
		switch (1)
		{
		case 0:
			break;
		case 1:
			try
			{
				Observer.WebhookCreate();
				int num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
				{
					num = 0;
				}
				switch (num)
				{
				case 0:
					break;
				}
				break;
			}
			catch
			{
				int num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
				{
					num2 = 0;
				}
				while (true)
				{
					switch (num2)
					{
					case 1:
						return;
					case 2:
						AcLogger.LogError(DicSingleton.gE3WbyDVW(0x548F02D9 ^ 0x548F0CDF));
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
						{
							num2 = 1;
						}
						break;
					default:
						AcLogger.LogError(DicSingleton.gE3WbyDVW(-34102588 ^ -34100040));
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
						{
							num2 = 2;
						}
						break;
					}
				}
			}
		}
	}

	internal static void oasdfouasdkfj(object sender, FileSystemEventArgs e)
	{
		if (!File.Exists(reader))
		{
			return;
		}
		try
		{
			AcLogger.LogDebug(DicSingleton.gE3WbyDVW(-490894496 ^ -490896288));
			StreamReader streamReader = File.OpenText(reader);
			_Helper = new GlobalSetter().WithNamingConvention(TagAuthentication.m_VisitorAuthentication).Build().Deserialize<SortedDictionary<string, Dispatcher>>(streamReader);
			streamReader.Close();
			_Tests.AssignLocalValue(File.ReadAllText(reader));
		}
		catch
		{
			AcLogger.LogError(DicSingleton.gE3WbyDVW(0xC23E82C ^ 0xC23E714));
			AcLogger.LogError(DicSingleton.gE3WbyDVW(-166253478 ^ -166256036));
		}
	}

	private static void tcfuyvghbuj()
	{
		int num = 3;
		int num2 = num;
		ExporterSetter exporterSetter = default(ExporterSetter);
		SortedDictionary<string, Dispatcher>.ValueCollection.Enumerator enumerator = default(SortedDictionary<string, Dispatcher>.ValueCollection.Enumerator);
		Dispatcher current = default(Dispatcher);
		bool? flag = default(bool?);
		ref Dispatcher reference = default(ref Dispatcher);
		bool value = default(bool);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 3:
				exporterSetter = new GlobalSetter().WithNamingConvention(TagAuthentication.m_VisitorAuthentication).Build();
				num2 = 2;
				break;
			case 2:
				AcLogger.LogDebug(DicSingleton.gE3WbyDVW(-1891833728 ^ -1891834040));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
				{
					num2 = 1;
				}
				break;
			case 0:
				return;
			case 1:
				try
				{
					Dictionary<string, Dispatcher> dictionary = exporterSetter.Deserialize<Dictionary<string, Dispatcher>>(_Tests.Value);
					if (dictionary != null)
					{
						goto IL_08f8;
					}
					int num3 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
					{
						num3 = 1;
					}
					goto IL_00c3;
					IL_08f8:
					_Helper = new SortedDictionary<string, Dispatcher>(dictionary);
					num3 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
					{
						num3 = 3;
					}
					goto IL_00c3;
					IL_00c3:
					while (true)
					{
						switch (num3)
						{
						case 2:
							return;
						default:
							try
							{
								while (true)
								{
									int num4;
									if (!enumerator.MoveNext())
									{
										num4 = 58;
										if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
										{
											num4 = 27;
										}
										goto IL_0101;
									}
									goto IL_0599;
									IL_0599:
									current = enumerator.Current;
									num4 = 9;
									goto IL_0101;
									IL_0101:
									while (true)
									{
										int num5;
										switch (num4)
										{
										case 58:
											return;
										case 15:
											flag = reference.ConsoleUseBypass;
											num4 = 60;
											continue;
										case 43:
											flag = reference.FreeFlyCamBypass;
											num4 = 54;
											continue;
										case 39:
											flag = reference.WeightLimitBypass;
											num4 = 25;
											continue;
										case 13:
											if (flag.HasValue)
											{
												num4 = 45;
												if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
												{
													num4 = 41;
												}
												continue;
											}
											goto default;
										case 28:
										case 38:
											break;
										case 33:
											if (!flag.HasValue)
											{
												num4 = 12;
												continue;
											}
											goto case 2;
										case 23:
										{
											bool? flag2 = (reference.NoCostCheatBypass = value);
											num4 = 2;
											continue;
										}
										case 16:
											if (flag.HasValue)
											{
												num4 = 56;
												continue;
											}
											goto case 41;
										case 37:
											value = flag == true;
											num4 = 32;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec != 0)
											{
												num4 = 35;
											}
											continue;
										case 55:
										{
											bool? flag2 = (reference.FlightBypass = value);
											num4 = 46;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
											{
												num4 = 26;
											}
											continue;
										}
										case 19:
											flag = reference.ExploreMapBypass;
											num4 = 48;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 != 0)
											{
												num4 = 0;
											}
											continue;
										case 36:
										{
											bool? flag2 = (reference.ExploreMapBypass = value);
											num4 = 17;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 != 0)
											{
												num4 = 16;
											}
											continue;
										}
										case 34:
											flag = reference.DamageBypass;
											num5 = 22;
											goto IL_00fd;
										case 14:
											if (!flag.HasValue)
											{
												num4 = 62;
												continue;
											}
											goto case 52;
										default:
											value = false;
											num4 = 53;
											continue;
										case 11:
										{
											bool? flag2 = (reference.GhostModeBypass = value);
											num4 = 12;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
											{
												num4 = 20;
											}
											continue;
										}
										case 62:
											value = false;
											num4 = 8;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
											{
												num4 = 30;
											}
											continue;
										case 6:
										{
											bool? flag2 = (reference.DamageBypass = value);
											num5 = 4;
											goto IL_00fd;
										}
										case 7:
											flag = reference.GodModeBypass;
											num4 = 42;
											continue;
										case 2:
											reference = ref current;
											num5 = 44;
											goto IL_00fd;
										case 53:
										{
											bool? flag2 = (reference.GodModeBypass = value);
											num4 = 49;
											continue;
										}
										case 27:
										case 61:
											reference = ref current;
											num4 = 7;
											continue;
										case 29:
											value = false;
											num4 = 55;
											continue;
										case 57:
											if (flag.HasValue)
											{
												num4 = 28;
												if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
												{
													num4 = 17;
												}
												continue;
											}
											goto case 26;
										case 32:
											if (flag.HasValue)
											{
												num4 = 27;
												continue;
											}
											goto case 51;
										case 47:
											if (flag.HasValue)
											{
												num4 = 3;
												continue;
											}
											goto case 59;
										case 3:
										case 17:
											reference = ref current;
											num5 = 34;
											goto IL_00fd;
										case 5:
										case 20:
											reference = ref current;
											num4 = 43;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 != 0)
											{
												num4 = 39;
											}
											continue;
										case 45:
										case 49:
											reference = ref current;
											num4 = 15;
											continue;
										case 51:
											value = false;
											num4 = 10;
											continue;
										case 46:
										case 50:
											reference = ref current;
											num4 = 36;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
											{
												num4 = 40;
											}
											continue;
										case 24:
											goto IL_0599;
										case 30:
										{
											bool? flag2 = (reference.ConsoleUseBypass = value);
											num4 = 52;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
											{
												num4 = 44;
											}
											continue;
										}
										case 60:
											value = flag == true;
											num4 = 14;
											continue;
										case 48:
											value = flag == true;
											num4 = 47;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
											{
												num4 = 25;
											}
											continue;
										case 40:
											flag = reference.NoCostCheatBypass;
											num4 = 63;
											continue;
										case 9:
											reference = ref current;
											num4 = 8;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 == 0)
											{
												num4 = 19;
											}
											continue;
										case 18:
											value = flag == true;
											num4 = 0;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 == 0)
											{
												num4 = 1;
											}
											continue;
										case 63:
											value = flag == true;
											num4 = 18;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec == 0)
											{
												num4 = 33;
											}
											continue;
										case 35:
											if (flag.HasValue)
											{
												num4 = 50;
												if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
												{
													num4 = 40;
												}
												continue;
											}
											goto case 29;
										case 21:
											flag = reference.FlightBypass;
											num4 = 37;
											continue;
										case 52:
											reference = ref current;
											num4 = 39;
											continue;
										case 44:
											flag = reference.GhostModeBypass;
											num4 = 18;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
											{
												num4 = 16;
											}
											continue;
										case 4:
										case 56:
											reference = ref current;
											num4 = 21;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
											{
												num4 = 12;
											}
											continue;
										case 25:
											value = flag == true;
											num4 = 57;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b != 0)
											{
												num4 = 53;
											}
											continue;
										case 41:
											value = false;
											num5 = 6;
											goto IL_00fd;
										case 1:
											if (flag.HasValue)
											{
												num5 = 5;
												goto IL_00fd;
											}
											goto case 31;
										case 26:
											value = false;
											num4 = 8;
											continue;
										case 12:
											value = false;
											num5 = 23;
											goto IL_00fd;
										case 10:
										{
											bool? flag2 = (reference.FreeFlyCamBypass = value);
											num4 = 61;
											continue;
										}
										case 8:
										{
											bool? flag2 = (reference.WeightLimitBypass = value);
											num4 = 38;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
											{
												num4 = 6;
											}
											continue;
										}
										case 22:
											value = flag == true;
											num4 = 16;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec != 0)
											{
												num4 = 9;
											}
											continue;
										case 54:
											value = flag == true;
											num4 = 19;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 != 0)
											{
												num4 = 32;
											}
											continue;
										case 42:
											value = flag == true;
											num4 = 13;
											continue;
										case 31:
											value = false;
											num4 = 11;
											continue;
										case 59:
											{
												value = false;
												num4 = 36;
												continue;
											}
											IL_00fd:
											num4 = num5;
											continue;
										}
										break;
									}
								}
							}
							finally
							{
								((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
								int num6 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 != 0)
								{
									num6 = 0;
								}
								switch (num6)
								{
								case 0:
									break;
								}
							}
						case 3:
							enumerator = _Helper.Values.GetEnumerator();
							num3 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 != 0)
							{
								num3 = 0;
							}
							continue;
						case 1:
							break;
						}
						break;
					}
					dictionary = new Dictionary<string, Dispatcher>();
					goto IL_08f8;
				}
				catch (Exception arg)
				{
					int num7 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
					{
						num7 = 1;
					}
					while (true)
					{
						switch (num7)
						{
						default:
							return;
						case 0:
							return;
						case 1:
							AcLogger.LogError(string.Format(DicSingleton.gE3WbyDVW(-380885952 ^ -380881838), arg));
							num7 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 != 0)
							{
								num7 = 0;
							}
							break;
						}
					}
				}
			}
		}
	}

	private void ShouldReadNewPlugins(object sender, FileSystemEventArgs e)
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
				rule = true;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	private static byte[] loadFile(string filename)
	{
		int num = 1;
		int num2 = num;
		byte[] array = default(byte[]);
		while (true)
		{
			switch (num2)
			{
			case 1:
			{
				FileStream fileStream = new FileStream(filename, FileMode.Open);
				array = new byte[(int)fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
				{
					num2 = 0;
				}
				break;
			}
			default:
				return array;
			}
		}
	}

	private static void DeleteThemYams(string directory)
	{
		try
		{
			string[] files = Directory.GetFiles(directory, DicSingleton.gE3WbyDVW(-1977574774 ^ -1977578778));
			for (int i = 0; i < files.Length; i++)
			{
				File.Delete(files[i]);
			}
			files = Directory.GetFiles(directory, DicSingleton.gE3WbyDVW(0x548F02D9 ^ 0x548F12A3));
			for (int i = 0; i < files.Length; i++)
			{
				File.Delete(files[i]);
			}
		}
		catch (DirectoryNotFoundException ex)
		{
			AcLogger.LogError(DicSingleton.gE3WbyDVW(-1741204886 ^ -1741208864));
			AcLogger.LogError(ex.Message);
		}
		catch (UnauthorizedAccessException ex2)
		{
			AcLogger.LogError(DicSingleton.gE3WbyDVW(0xB967DC8 ^ 0xB966D14));
			AcLogger.LogError(ex2.Message);
		}
		catch (Exception ex3)
		{
			AcLogger.LogError(DicSingleton.gE3WbyDVW(0xB026CF2 ^ 0xB027D22));
			AcLogger.LogError(ex3.Message);
		}
	}

	private void tyuiolasdfasdfasdlkfj()
	{
		int num = 34;
		string text2 = default(string);
		string[] array = default(string[]);
		int num3 = default(int);
		string[] files2 = default(string[]);
		string text = default(string);
		Assembly assembly2 = default(Assembly);
		Assembly assembly = default(Assembly);
		string[] files = default(string[]);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 21:
					text2 = array[num3];
					num2 = 32;
					continue;
				case 27:
					mapper.Clear();
					num2 = 17;
					continue;
				case 40:
					DeleteThemYams(_Filter);
					num2 = 38;
					continue;
				case 30:
					m_Rules = "";
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 != 0)
					{
						num2 = 2;
					}
					continue;
				case 43:
					AcLogger.LogInfo(string.Format(DicSingleton.gE3WbyDVW(0xFB046CE ^ 0xFB054F6), files2.Length));
					num2 = 31;
					continue;
				case 2:
					loadFile(text);
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
					{
						num2 = 13;
					}
					continue;
				case 35:
					if (!xouweoriulf(m_Identifier, isWhitelist: true))
					{
						num = 36;
						break;
					}
					goto case 15;
				case 4:
					callback.Add(assembly2, text);
					num2 = 20;
					continue;
				case 20:
					num3++;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 != 0)
					{
						num2 = 1;
					}
					continue;
				case 45:
					m_Identifier.Add(assembly);
					num2 = 10;
					continue;
				case 13:
					callback.Clear();
					num2 = 43;
					continue;
				case 26:
					text = array[num3];
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c == 0)
					{
						num2 = 0;
					}
					continue;
				case 10:
					token.Add(assembly, text2);
					num = 28;
					break;
				case 11:
					AcLogger.LogInfo(DicSingleton.gE3WbyDVW(-1977574774 ^ -1977579086));
					num2 = 7;
					continue;
				case 47:
					files = Directory.GetFiles(_Filter, DicSingleton.gE3WbyDVW(-1335677307 ^ -1335680249), SearchOption.AllDirectories);
					num2 = 44;
					continue;
				case 9:
					if (m_Identifier.Count < 1)
					{
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 != 0)
						{
							num2 = 30;
						}
						continue;
					}
					goto case 5;
				case 37:
					AcLogger.LogInfo(DicSingleton.gE3WbyDVW(-1059662249 ^ -1059666789));
					num2 = 24;
					continue;
				case 39:
					mapper.Add(assembly2);
					num2 = 4;
					continue;
				case 36:
				case 38:
					files2 = Directory.GetFiles(m_Interceptor, DicSingleton.gE3WbyDVW(0x4BDBCDC0 ^ 0x4BDBC042), SearchOption.AllDirectories);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
					{
						num2 = 47;
					}
					continue;
				case 41:
					getter = "";
					num = 9;
					break;
				case 12:
				case 22:
					if (num3 >= array.Length)
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 != 0)
						{
							num2 = 25;
						}
						continue;
					}
					goto case 21;
				case 5:
					rule = false;
					num2 = 6;
					continue;
				case 3:
					if (files2.Length != 0)
					{
						num2 = 19;
						continue;
					}
					goto case 37;
				case 14:
					assembly2 = Assembly.LoadFile(text);
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 != 0)
					{
						num2 = 39;
					}
					continue;
				case 16:
					num3 = 0;
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 != 0)
					{
						num2 = 12;
					}
					continue;
				default:
					array = files;
					num2 = 46;
					continue;
				case 42:
					array = files2;
					num2 = 16;
					continue;
				case 28:
					num3++;
					num = 22;
					break;
				case 24:
				case 25:
					if (files.Length != 0)
					{
						num2 = 48;
						continue;
					}
					goto case 11;
				case 15:
					if (mapper.Count > 0)
					{
						num2 = 8;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
						{
							num2 = 8;
						}
						continue;
					}
					goto case 18;
				case 34:
					if (!rule)
					{
						num2 = 33;
						continue;
					}
					DeleteThemYams(m_Interceptor);
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
					{
						num2 = 40;
					}
					continue;
				case 44:
					m_Identifier.Clear();
					num2 = 27;
					continue;
				case 6:
					return;
				case 7:
				case 23:
					if (m_Identifier.Count > 0)
					{
						num = 35;
						break;
					}
					goto case 15;
				case 18:
					if (mapper.Count < 1)
					{
						num2 = 41;
						continue;
					}
					goto case 9;
				case 31:
					AcLogger.LogInfo(string.Format(DicSingleton.gE3WbyDVW(0x3C33E48 ^ 0x3C32C20), files.Length));
					num = 3;
					break;
				case 32:
					assembly = Assembly.LoadFile(text2);
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f == 0)
					{
						num2 = 45;
					}
					continue;
				case 1:
				case 29:
					if (num3 >= array.Length)
					{
						num2 = 23;
						continue;
					}
					goto case 26;
				case 17:
					token.Clear();
					num2 = 13;
					continue;
				case 19:
					AcLogger.LogInfo(DicSingleton.gE3WbyDVW(0x14AB6F1E ^ 0x14AB7D88));
					num2 = 42;
					continue;
				case 48:
					AcLogger.LogInfo(DicSingleton.gE3WbyDVW(0x7FAAD78F ^ 0x7FAAC48B));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
					{
						num2 = 0;
					}
					continue;
				case 46:
					num3 = 0;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 != 0)
					{
						num2 = 29;
					}
					continue;
				case 33:
					return;
				case 8:
					if (xouweoriulf(mapper))
					{
						num = 18;
						break;
					}
					goto case 36;
				}
				break;
			}
		}
	}

	private static bool xouweoriulf(List<Assembly> listToLoad, bool isWhitelist = false, bool isValheimAssem = false)
	{
		SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
		string text = (isWhitelist ? DicSingleton.gE3WbyDVW(-1075938037 ^ -1075941733) : DicSingleton.gE3WbyDVW(0x7B291245 ^ 0x7B29012B));
		Dictionary<Assembly, string> dictionary = (isWhitelist ? token : callback);
		try
		{
			foreach (Assembly item in listToLoad)
			{
				Type[] array;
				try
				{
					array = item.GetTypes();
				}
				catch (ReflectionTypeLoadException ex)
				{
					array = ex.Types.Where([_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)] (Type type) => type != null).ToArray();
				}
				try
				{
					Type[] array2 = array;
					for (int num = 0; num < array2.Length; num++)
					{
						BepInPlugin customAttribute = array2[num].GetCustomAttribute<BepInPlugin>();
						if (customAttribute == null)
						{
							continue;
						}
						byte[] bytes;
						try
						{
							bytes = File.ReadAllBytes(dictionary[item]);
						}
						catch
						{
							if (File.Exists(dictionary[item]))
							{
								throw;
							}
							return false;
						}
						string text2 = TrustworthyTrygve(bytes);
						string text3 = TrustyBusty(text2 + DicSingleton.gE3WbyDVW(0x765D303 ^ 0x765C0B7));
						string value = TrustyBusty(text2 + text3 + TrustyBusty(DicSingleton.gE3WbyDVW(-598551743 ^ -598556517)));
						if (!sortedDictionary.ContainsKey(string.Format(DicSingleton.gE3WbyDVW(-545065612 ^ -545070822), customAttribute.Name, customAttribute.Version)))
						{
							sortedDictionary.Add(string.Format(DicSingleton.gE3WbyDVW(0x1C779450 ^ 0x1C77803E), customAttribute.Name, customAttribute.Version), value);
						}
					}
				}
				catch (Exception data)
				{
					AcLogger.LogError(data);
				}
			}
			AcLogger.LogInfo(DicSingleton.gE3WbyDVW(0x6BAF1854 ^ 0x6BAF0CD6) + text + DicSingleton.gE3WbyDVW(0xB967DC8 ^ 0xB966960));
			string rules = Class.ToYAML(sortedDictionary);
			if (isWhitelist)
			{
				m_Rules = rules;
			}
			else
			{
				getter = rules;
			}
		}
		catch
		{
			string text4 = DicSingleton.gE3WbyDVW(-1053593978 ^ -1053590982);
			AcLogger.LogError(DicSingleton.gE3WbyDVW(-65056140 ^ -65052746) + text + DicSingleton.gE3WbyDVW(-1466472923 ^ -1466469653) + text4 + DicSingleton.gE3WbyDVW(0x5A1B57A3 ^ 0x5A1B4377));
		}
		return true;
	}

	internal static string TrustworthyTrygve(byte[] bytes)
	{
		int num = 1;
		int num2 = num;
		string result = default(string);
		SHA256 sHA = default(SHA256);
		byte b = default(byte);
		int num4 = default(int);
		while (true)
		{
			switch (num2)
			{
			case 2:
				return result;
			default:
				try
				{
					byte[] array = sHA.ComputeHash(bytes);
					StringBuilder stringBuilder = new StringBuilder();
					byte[] array2 = array;
					int num3 = 5;
					while (true)
					{
						switch (num3)
						{
						case 8:
							stringBuilder.Append(b.ToString(DicSingleton.gE3WbyDVW(-2075300707 ^ -2075297321)));
							num3 = 7;
							continue;
						default:
							b = array2[num4];
							num3 = 8;
							continue;
						case 4:
							result = stringBuilder.ToString();
							num3 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
							{
								num3 = 1;
							}
							continue;
						case 2:
						case 6:
							if (num4 < array2.Length)
							{
								num3 = 3;
								continue;
							}
							goto case 4;
						case 5:
							num4 = 0;
							num3 = 6;
							continue;
						case 7:
							num4++;
							num3 = 2;
							continue;
						case 1:
							break;
						}
						break;
					}
				}
				finally
				{
					if (sHA != null)
					{
						int num5 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
						{
							num5 = 0;
						}
						while (true)
						{
							switch (num5)
							{
							default:
								((IDisposable)sHA).Dispose();
								num5 = 1;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef != 0)
								{
									num5 = 1;
								}
								continue;
							case 1:
								break;
							}
							break;
						}
					}
				}
				goto case 2;
			case 1:
				sHA = SHA256.Create();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static string TrustyBusty(string source)
	{
		int num = 1;
		int num2 = num;
		string result = default(string);
		SHA384 sHA = default(SHA384);
		while (true)
		{
			switch (num2)
			{
			case 2:
				return result;
			default:
				try
				{
					byte[] bytes = Encoding.UTF8.GetBytes(source);
					int num3 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab != 0)
					{
						num3 = 0;
					}
					while (true)
					{
						switch (num3)
						{
						default:
							result = BitConverter.ToString(sHA.ComputeHash(bytes)).Replace(DicSingleton.gE3WbyDVW(-614239580 ^ -614236616), string.Empty);
							num3 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
							{
								num3 = 1;
							}
							continue;
						case 1:
							break;
						}
						break;
					}
				}
				finally
				{
					if (sHA != null)
					{
						int num4 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 == 0)
						{
							num4 = 1;
						}
						while (true)
						{
							switch (num4)
							{
							case 1:
								((IDisposable)sHA).Dispose();
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
								{
									num4 = 0;
								}
								continue;
							case 0:
								break;
							}
							break;
						}
					}
				}
				goto case 2;
			case 1:
				sHA = SHA384.Create();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	[IteratorStateMachine(typeof(_003CStuffAndThings_003Ed__80))]
	internal IEnumerator StuffAndThings()
	{
		//yield-return decompiler failed: Missing enumeratorCtor.Body
		return new _003CStuffAndThings_003Ed__80(0)
		{
			_003C_003E4__this = this
		};
	}

	private void InitializeBannedProcessNames()
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
				m_Parser = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
				{
					DicSingleton.gE3WbyDVW(-1389846755 ^ -1389852081),
					DicSingleton.gE3WbyDVW(0x3FCF6129 ^ 0x3FCF7449),
					DicSingleton.gE3WbyDVW(0x9000142 ^ 0x9001432),
					DicSingleton.gE3WbyDVW(-830028630 ^ -830025430),
					DicSingleton.gE3WbyDVW(0x40385DA3 ^ 0x4038482D),
					DicSingleton.gE3WbyDVW(0x5A8BEE ^ 0x5A9E4E),
					DicSingleton.gE3WbyDVW(-475093377 ^ -475089973),
					DicSingleton.gE3WbyDVW(-1011281439 ^ -1011284957),
					DicSingleton.gE3WbyDVW(0x7742C60 ^ 0x77439AC),
					DicSingleton.gE3WbyDVW(-447849421 ^ -447854107),
					DicSingleton.gE3WbyDVW(-490894496 ^ -490889572),
					DicSingleton.gE3WbyDVW(-545065612 ^ -545070266),
					DicSingleton.gE3WbyDVW(0x69B67B3A ^ 0x69B66D7E)
				};
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private void StartProcessListRefreshTask()
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
				Task.Run([AsyncStateMachine(typeof(_003C_003CStartProcessListRefreshTask_003Eb__82_0_003Ed))] [_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)] () =>
				{
					int num3 = 3;
					int num4 = num3;
					_003C_003CStartProcessListRefreshTask_003Eb__82_0_003Ed stateMachine = default(_003C_003CStartProcessListRefreshTask_003Eb__82_0_003Ed);
					while (true)
					{
						switch (num4)
						{
						case 4:
							stateMachine._003C_003E1__state = -1;
							num4 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 != 0)
							{
								num4 = 1;
							}
							break;
						case 3:
							stateMachine._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
							num4 = 2;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
							{
								num4 = 2;
							}
							break;
						case 1:
							stateMachine._003C_003Et__builder.Start(ref stateMachine);
							num4 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 != 0)
							{
								num4 = 0;
							}
							break;
						default:
							return stateMachine._003C_003Et__builder.Task;
						case 2:
							stateMachine._003C_003E4__this = this;
							num4 = 4;
							break;
						}
					}
				}, _Request.Token);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private void OnGUI()
	{
		int num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 5:
				return;
			case 1:
				return;
			case 3:
				GUI.backgroundColor = Color.clear;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				_Exception = GUI.Window(432712245, _Exception, GUIBUILDER, "");
				num2 = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 != 0)
				{
					num2 = 3;
				}
				break;
			default:
				_Exception = new Rect(0f, 0f, Screen.width, Screen.height);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c != 0)
				{
					num2 = 2;
				}
				break;
			case 4:
				if (!_Invocation)
				{
					return;
				}
				num2 = 3;
				break;
			}
		}
	}

	private void GUIBUILDER(int windowId)
	{
		int num = 1;
		int num2 = num;
		string text = default(string);
		GUIStyle style = default(GUIStyle);
		while (true)
		{
			switch (num2)
			{
			case 6:
				return;
			default:
				text = Localization.instance.Localize(DicSingleton.gE3WbyDVW(0xC23E82C ^ 0xC23FE78)) + DicSingleton.gE3WbyDVW(0x940D407 ^ 0x940C271) + global.Replace(DicSingleton.gE3WbyDVW(0x2D27936 ^ 0x2D26F4A), Environment.NewLine);
				num2 = 5;
				break;
			case 5:
				if (!GUI.Button(new Rect(0f, 0f, Screen.width, Screen.height), text, style))
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 == 0)
					{
						num2 = 0;
					}
				}
				else
				{
					Cursor.lockState = CursorLockMode.None;
					num2 = 3;
				}
				break;
			case 2:
				return;
			case 1:
				style = new GUIStyle(GUI.skin.button)
				{
					fontSize = 50,
					fontStyle = FontStyle.Bold,
					normal = 
					{
						textColor = Color.red
					},
					hover = 
					{
						textColor = Color.red
					},
					alignment = TextAnchor.MiddleCenter
				};
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 == 0)
				{
					num2 = 0;
				}
				break;
			case 4:
				Application.Quit();
				num2 = 6;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
				{
					num2 = 4;
				}
				break;
			case 3:
				Cursor.visible = false;
				num2 = 4;
				break;
			}
		}
	}

	private void Exitclient()
	{
		Application.Quit();
	}

	private ConfigEntry<T> config<[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(2)] T>(string group, string name, T value, ConfigDescription description, bool synchronizedSetting = true)
	{
		ConfigDescription configDescription = new ConfigDescription(description.Description + (synchronizedSetting ? DicSingleton.gE3WbyDVW(0x40385DA3 ^ 0x40384B19) : DicSingleton.gE3WbyDVW(0x21AFFB2B ^ 0x21AFEDAF)), description.AcceptableValues, description.Tags);
		ConfigEntry<T> configEntry = base.Config.Bind(group, name, value, configDescription);
		_Candidate.AddConfigEntry(configEntry)._AlgoPublisher = synchronizedSetting;
		return configEntry;
	}

	private ConfigEntry<T> config<[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(2)] T>(string group, string name, T value, string description, bool synchronizedSetting = true)
	{
		return config(group, name, value, new ConfigDescription(description, null), synchronizedSetting);
	}

	public AzuAnticheatPlugin()
	{
		GetterIssuer.DeleteInitializer();
		m_Watcher = new Harmony(DicSingleton.gE3WbyDVW(0x765D303 ^ 0x765C5EB));
		m_Page = new ConcurrentBag<Process>();
		_Request = new CancellationTokenSource();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	static AzuAnticheatPlugin()
	{
		int num = 41;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 36:
					getter = "";
					num2 = 47;
					continue;
				case 42:
					_Exception = new Rect(0f, 0f, Screen.width, Screen.height);
					num2 = 45;
					continue;
				case 3:
					_Filter = string.Format(DicSingleton.gE3WbyDVW(-1954645236 ^ -1954648958), Paths.ConfigPath, Path.DirectorySeparatorChar, DicSingleton.gE3WbyDVW(-360128320 ^ -360122446));
					num2 = 46;
					continue;
				case 30:
					global = "";
					num2 = 31;
					continue;
				case 40:
					_Publisher = DicSingleton.gE3WbyDVW(-1461449777 ^ -1461445413);
					num = 37;
					break;
				case 41:
					GetterIssuer.DeleteInitializer();
					num2 = 40;
					continue;
				case 25:
					decorator = new ConnectionPublisher<int>(_Candidate, DicSingleton.gE3WbyDVW(0x2BC349D6 ^ 0x2BC35E10), 5000);
					num2 = 38;
					continue;
				case 12:
					m_Event = null;
					num2 = 17;
					continue;
				case 53:
					AcLogger = BepInEx.Logging.Logger.CreateLogSource(DicSingleton.gE3WbyDVW(0x21AFFB2B ^ 0x21AFEC59));
					num = 44;
					break;
				case 19:
					_Indexer = "";
					num2 = 27;
					continue;
				case 1:
					_Task = new ConnectionPublisher<bool>(_Candidate, DicSingleton.gE3WbyDVW(0x540450D2 ^ 0x540448F0), value: false);
					num2 = 39;
					continue;
				case 21:
					_Facade = null;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
					{
						num2 = 12;
					}
					continue;
				case 45:
					mapper = new List<Assembly>();
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
					{
						num2 = 9;
					}
					continue;
				case 13:
					m_Issuer = false;
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 != 0)
					{
						num2 = 6;
					}
					continue;
				case 35:
					_Producer = false;
					num2 = 20;
					continue;
				case 28:
					_Definition = new List<Params>();
					num2 = 33;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 != 0)
					{
						num2 = 54;
					}
					continue;
				case 15:
					_Writer = "";
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c != 0)
					{
						num2 = 2;
					}
					continue;
				case 8:
					m_Record = null;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec == 0)
					{
						num2 = 2;
					}
					continue;
				case 27:
					mock = "";
					num2 = 51;
					continue;
				case 39:
					_Tests = new ConnectionPublisher<string>(_Candidate, DicSingleton.gE3WbyDVW(0x3C33E48 ^ 0x3C3267E), "");
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 != 0)
					{
						num2 = 1;
					}
					continue;
				case 9:
					m_Identifier = new List<Assembly>();
					num2 = 22;
					continue;
				case 20:
					_Comparator = "";
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
					{
						num2 = 28;
					}
					continue;
				case 38:
					broadcaster = new ConnectionPublisher<int>(_Candidate, DicSingleton.gE3WbyDVW(0x4C23C86A ^ 0x4C23DF80), 55000);
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a != 0)
					{
						num2 = 48;
					}
					continue;
				case 6:
				{
					string configPath2 = Paths.ConfigPath;
					char directorySeparatorChar = Path.DirectorySeparatorChar;
					setter = configPath2 + directorySeparatorChar + DicSingleton.gE3WbyDVW(-1064640644 ^ -1064643694);
					num2 = 15;
					continue;
				}
				case 32:
					m_Predicate = string.Empty;
					num2 = 52;
					continue;
				case 34:
					_Status = null;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 != 0)
					{
						num2 = 0;
					}
					continue;
				case 29:
					_Prototype = null;
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
					{
						num2 = 11;
					}
					continue;
				case 51:
					_Template = "";
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
					{
						num2 = 32;
					}
					continue;
				case 44:
					resolver = null;
					num = 16;
					break;
				case 46:
					reader = null;
					num = 6;
					break;
				case 18:
					m_Attribute = false;
					num2 = 10;
					continue;
				case 50:
					m_Parser = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
					num2 = 21;
					continue;
				case 4:
					_Initializer = new ConnectionPublisher<string>(_Candidate, DicSingleton.gE3WbyDVW(-954365995 ^ -954359933), "");
					num2 = 50;
					continue;
				case 10:
					interpreter = false;
					num2 = 13;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd != 0)
					{
						num2 = 12;
					}
					continue;
				case 48:
					m_Worker = new ConnectionPublisher<float>(_Candidate, DicSingleton.gE3WbyDVW(-1507873642 ^ -1507871598), 60f);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
					{
						num2 = 1;
					}
					continue;
				case 54:
					_Composer = "";
					num2 = 30;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
					{
						num2 = 2;
					}
					continue;
				case 22:
					token = new Dictionary<Assembly, string>();
					num2 = 14;
					continue;
				case 23:
					_Parameter = null;
					num2 = 34;
					continue;
				case 31:
					m_Map = new SortedDictionary<string, string>();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 != 0)
					{
						num2 = 49;
					}
					continue;
				case 26:
					m_Rules = "";
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
					{
						num2 = 36;
					}
					continue;
				case 37:
				{
					string configPath = Paths.ConfigPath;
					char directorySeparatorChar = Path.DirectorySeparatorChar;
					@base = configPath + directorySeparatorChar + _Publisher;
					num2 = 29;
					continue;
				}
				case 14:
					callback = new Dictionary<Assembly, string>();
					num2 = 26;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb == 0)
					{
						num2 = 20;
					}
					continue;
				case 16:
					_Candidate = new RepositoryPublisher(DicSingleton.gE3WbyDVW(-598551743 ^ -598555223))
					{
						_StubPublisher = DicSingleton.gE3WbyDVW(-381685266 ^ -381688164),
						policyPublisher = DicSingleton.gE3WbyDVW(-1830690703 ^ -1830684729),
						strategyPublisher = DicSingleton.gE3WbyDVW(-1461449777 ^ -1461445511)
					};
					num2 = 43;
					continue;
				case 47:
					m_Code = "";
					num2 = 19;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
					{
						num2 = 19;
					}
					continue;
				case 7:
					serializer = false;
					num2 = 35;
					continue;
				case 0:
					return;
				case 43:
					m_Product = new ConnectionPublisher<int>(_Candidate, DicSingleton.gE3WbyDVW(-2133864647 ^ -2133867311), 1000);
					num2 = 24;
					continue;
				case 5:
					authentication = false;
					num2 = 18;
					continue;
				case 49:
					_Helper = new SortedDictionary<string, Dispatcher>();
					num2 = 42;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
					{
						num2 = 17;
					}
					continue;
				case 11:
					m_Interceptor = string.Format(DicSingleton.gE3WbyDVW(-1461449777 ^ -1461445497), Paths.ConfigPath, Path.DirectorySeparatorChar, DicSingleton.gE3WbyDVW(-1735703950 ^ -1735699200));
					num2 = 3;
					continue;
				case 33:
					bridge = null;
					num2 = 23;
					continue;
				case 2:
					service = null;
					num2 = 33;
					continue;
				case 24:
					m_Registry = new ConnectionPublisher<int>(_Candidate, DicSingleton.gE3WbyDVW(-32257720 ^ -32258790), 1000);
					num2 = 25;
					continue;
				case 17:
					client = null;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a != 0)
					{
						num2 = 8;
					}
					continue;
				case 52:
					system = "";
					num2 = 53;
					continue;
				}
				break;
			}
		}
	}

	internal static bool WriteExpression()
	{
		return (object)PrepareExpression == null;
	}

	internal static AzuAnticheatPlugin PrintExpression()
	{
		return PrepareExpression;
	}
}
