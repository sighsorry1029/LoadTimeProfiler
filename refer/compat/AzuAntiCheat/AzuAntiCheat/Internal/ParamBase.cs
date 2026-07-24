using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using BepInEx;
using HarmonyLib;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace AzuAnticheat.Internal;

[PublicAPI]
[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(1)]
[HarmonyPatch]
internal class ParamBase
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass30_0
	{
		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
		public ZRpc m_ConfigBase;

		private static _003C_003Ec__DisplayClass30_0 CancelCustomer;

		public _003C_003Ec__DisplayClass30_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
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
		internal bool _003CGetFailedServer_003Eb__0(ParamBase check)
		{
			int num = 1;
			int num2 = num;
			int result;
			while (true)
			{
				switch (num2)
				{
				case 1:
					if (check.clientBase)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					result = 0;
					break;
				default:
					result = ((!check._BridgeBase.Contains(m_ConfigBase)) ? 1 : 0);
					break;
				}
				break;
			}
			return (byte)result != 0;
		}

		internal static bool ReflectCustomer()
		{
			return CancelCustomer == null;
		}

		internal static _003C_003Ec__DisplayClass30_0 CollectCustomer()
		{
			return CancelCustomer;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass36_0
	{
		[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(new byte[] { 0, 1, 1 })]
		public Action<ZRpc, ZPackage> m_WrapperBase;

		internal static _003C_003Ec__DisplayClass36_0 ManageCustomer;

		public _003C_003Ec__DisplayClass36_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
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
		internal void _003CRegisterAndCheckVersion_003Eb__0(ZRpc rpc, [_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(1)] ZPackage pkg)
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
					CheckVersion(rpc, pkg, m_WrapperBase);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		internal static bool ForgotCustomer()
		{
			return ManageCustomer == null;
		}

		internal static _003C_003Ec__DisplayClass36_0 RestartCustomer()
		{
			return ManageCustomer;
		}
	}

	private static readonly HashSet<ParamBase> facadeBase;

	private static readonly Dictionary<string, string> eventBase;

	public string _InstanceBase;

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
	private string orderBase;

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
	private string m_ContainerBase;

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
	private string _IteratorBase;

	public bool clientBase;

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
	private string recordBase;

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
	private string serviceBase;

	private readonly List<ZRpc> _BridgeBase;

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)]
	private RepositoryPublisher _ParameterBase;

	internal static ParamBase StartCustomer;

	public string DisplayName
	{
		get
		{
			int num = 1;
			int num2 = num;
			string instanceBase;
			while (true)
			{
				switch (num2)
				{
				case 1:
					instanceBase = orderBase;
					if (instanceBase != null)
					{
						break;
					}
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
					{
						num2 = 0;
					}
					continue;
				default:
					instanceBase = _InstanceBase;
					break;
				}
				break;
			}
			return instanceBase;
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
					orderBase = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
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

	public string CurrentVersion
	{
		get
		{
			int num = 1;
			int num2 = num;
			string text;
			while (true)
			{
				switch (num2)
				{
				case 1:
					text = m_ContainerBase;
					if (text == null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					break;
				default:
					text = DicSingleton.gE3WbyDVW(0xB026CF2 ^ 0xB0222C0);
					break;
				}
				break;
			}
			return text;
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
					m_ContainerBase = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
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

	public string MinimumRequiredVersion
	{
		get
		{
			int num = 3;
			while (true)
			{
				int num2 = num;
				while (true)
				{
					string text;
					switch (num2)
					{
					case 2:
						if (clientBase)
						{
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f != 0)
							{
								num2 = 0;
							}
							continue;
						}
						goto case 1;
					case 3:
						text = _IteratorBase;
						if (text != null)
						{
							break;
						}
						goto end_IL_0012;
					case 1:
						text = DicSingleton.gE3WbyDVW(--1182565251 ^ 0x467CCDB1);
						break;
					default:
						text = CurrentVersion;
						break;
					}
					return text;
					continue;
					end_IL_0012:
					break;
				}
				num = 2;
			}
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
					_IteratorBase = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	private static void PatchServerSync()
	{
		Patches patchInfo = PatchProcessor.GetPatchInfo(AccessTools.DeclaredMethod(typeof(ZNet), DicSingleton.gE3WbyDVW(0x548F02D9 ^ 0x548F4C99)));
		if (patchInfo != null && patchInfo.Postfixes.Count([_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)] (Patch p) => p.PatchMethod.DeclaringType == typeof(RepositoryPublisher.StructPublisher)) > 0)
		{
			return;
		}
		Harmony harmony = new Harmony(DicSingleton.gE3WbyDVW(-1880453928 ^ -1880440170));
		foreach (Type item in from t in typeof(RepositoryPublisher).GetNestedTypes(BindingFlags.NonPublic).Concat(new Type[1] { typeof(ParamBase) })
			where t.IsClass
			select t)
		{
			harmony.PatchAll(item);
		}
	}

	static ParamBase()
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				typeof(ThreadingHelper).GetMethod(DicSingleton.gE3WbyDVW(0xC23E82C ^ 0xC23A6A2)).Invoke(ThreadingHelper.Instance, new object[1]
				{
					new Action(PatchServerSync)
				});
				num2 = 4;
				break;
			case 3:
				GetterIssuer.DeleteInitializer();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 != 0)
				{
					num2 = 1;
				}
				break;
			default:
				eventBase = new Dictionary<string, string>();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c == 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				facadeBase = new HashSet<ParamBase>();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
				{
					num2 = 0;
				}
				break;
			case 4:
				return;
			}
		}
	}

	public ParamBase(string name)
	{
		GetterIssuer.DeleteInitializer();
		clientBase = true;
		_BridgeBase = new List<ZRpc>();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba != 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 2:
				facadeBase.Add(this);
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 != 0)
				{
					num = 0;
				}
				break;
			case 1:
				_InstanceBase = name;
				num = 3;
				break;
			case 0:
				return;
			case 3:
				clientBase = true;
				num = 2;
				break;
			}
		}
	}

	public ParamBase(RepositoryPublisher configSync)
	{
		GetterIssuer.DeleteInitializer();
		clientBase = true;
		_BridgeBase = new List<ZRpc>();
		base._002Ector();
		int num = 2;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 3:
				return;
			default:
				facadeBase.Add(this);
				num = 3;
				break;
			case 2:
				_ParameterBase = configSync;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
				{
					num = 0;
				}
				break;
			case 1:
				_InstanceBase = _ParameterBase._VisitorPublisher;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public void Initialize()
	{
		int num = 9;
		bool flag = default(bool);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 7:
					DisplayName = _ParameterBase._StubPublisher;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
					{
						num2 = 11;
					}
					continue;
				case 11:
					CurrentVersion = _ParameterBase.policyPublisher;
					num2 = 4;
					continue;
				case 0:
					return;
				case 10:
					return;
				case 2:
				case 5:
					_InstanceBase = _ParameterBase._VisitorPublisher;
					num2 = 7;
					continue;
				case 4:
					MinimumRequiredVersion = _ParameterBase.strategyPublisher;
					num = 6;
					break;
				case 3:
					flag = _ParameterBase == null;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
					{
						num2 = 1;
					}
					continue;
				case 6:
					clientBase = _ParameterBase.m_ProcessorPublisher;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
					{
						num2 = 0;
					}
					continue;
				case 1:
					if (flag)
					{
						return;
					}
					num2 = 5;
					continue;
				case 9:
					recordBase = null;
					num2 = 8;
					continue;
				case 8:
					serviceBase = null;
					num = 3;
					break;
				}
				break;
			}
		}
	}

	private bool IsVersionOk()
	{
		int num = 1;
		bool result = default(bool);
		bool flag3 = default(bool);
		bool flag = default(bool);
		bool flag2 = default(bool);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				int num3;
				switch (num2)
				{
				case 1:
					if (serviceBase != null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
						{
							num2 = 0;
						}
						continue;
					}
					num3 = 1;
					break;
				default:
					num3 = ((recordBase == null) ? 1 : 0);
					break;
				case 5:
				case 7:
				case 8:
					return result;
				case 6:
					if (!flag3)
					{
						num2 = 10;
						continue;
					}
					goto case 2;
				case 2:
					result = !clientBase;
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
					{
						num2 = 8;
					}
					continue;
				case 4:
				case 10:
					flag = new Version(CurrentVersion) >= new Version(serviceBase);
					num2 = 9;
					continue;
				case 3:
					result = flag && flag2;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
					{
						num2 = 1;
					}
					continue;
				case 9:
					goto end_IL_0012;
				}
				flag3 = (byte)num3 != 0;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
				{
					num2 = 6;
				}
				continue;
				end_IL_0012:
				break;
			}
			flag2 = new Version(recordBase) >= new Version(MinimumRequiredVersion);
			num = 3;
		}
	}

	private string ErrorClient()
	{
		int num = 4;
		int num2 = num;
		bool flag = default(bool);
		bool flag2 = default(bool);
		string result = default(string);
		while (true)
		{
			string text;
			switch (num2)
			{
			case 3:
				if (!flag)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd != 0)
					{
						num2 = 0;
					}
					continue;
				}
				goto case 2;
			case 1:
			case 8:
				flag2 = new Version(CurrentVersion) >= new Version(serviceBase);
				num2 = 6;
				continue;
			case 2:
				result = DisplayName + DicSingleton.gE3WbyDVW(0xC23E82C ^ 0xC23A69C);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
				{
					num2 = 5;
				}
				continue;
			default:
				return result;
			case 7:
				text = DisplayName + DicSingleton.gE3WbyDVW(-2075300707 ^ -2075319703) + serviceBase + DicSingleton.gE3WbyDVW(0x3353457 ^ 0x3357B63) + CurrentVersion + DicSingleton.gE3WbyDVW(-475093377 ^ -475076319);
				break;
			case 6:
				if (!flag2)
				{
					num2 = 7;
					continue;
				}
				text = DisplayName + DicSingleton.gE3WbyDVW(-948533799 ^ -948516163) + recordBase + DicSingleton.gE3WbyDVW(-1461449777 ^ -1461435141) + CurrentVersion + DicSingleton.gE3WbyDVW(-545065612 ^ -545080790);
				break;
			case 4:
				flag = serviceBase == null;
				num2 = 3;
				continue;
			}
			result = text;
			num2 = 9;
		}
	}

	private string ErrorServer(ZRpc rpc)
	{
		int num = 1;
		int num2 = num;
		string result = default(string);
		while (true)
		{
			switch (num2)
			{
			case 1:
				result = DicSingleton.gE3WbyDVW(0x166FBD ^ 0x162015) + rpc.GetSocket().GetHostName() + DicSingleton.gE3WbyDVW(0x3A437A88 ^ 0x3A433554) + DisplayName + DicSingleton.gE3WbyDVW(-1863475926 ^ -1863463620) + MinimumRequiredVersion;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return result;
			}
		}
	}

	private string Error([_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)] ZRpc rpc = null)
	{
		int num = 1;
		int num2 = num;
		string result = default(string);
		while (true)
		{
			string text;
			switch (num2)
			{
			case 4:
				text = ErrorServer(rpc);
				break;
			case 1:
				if (rpc == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
					{
						num2 = 0;
					}
					continue;
				}
				goto case 4;
			case 2:
			case 3:
				return result;
			default:
				text = ErrorClient();
				break;
			}
			result = text;
			num2 = 3;
		}
	}

	private static ParamBase[] GetFailedClient()
	{
		int num = 1;
		int num2 = num;
		ParamBase[] result = default(ParamBase[]);
		while (true)
		{
			switch (num2)
			{
			default:
				return result;
			case 1:
				result = facadeBase.Where([_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)] (ParamBase check) => !check.IsVersionOk()).ToArray();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private static ParamBase[] GetFailedServer(ZRpc rpc)
	{
		int num = 3;
		int num2 = num;
		ParamBase[] result = default(ParamBase[]);
		_003C_003Ec__DisplayClass30_0 _003C_003Ec__DisplayClass30_ = default(_003C_003Ec__DisplayClass30_0);
		while (true)
		{
			switch (num2)
			{
			case 1:
			case 4:
				return result;
			case 3:
				_003C_003Ec__DisplayClass30_ = new _003C_003Ec__DisplayClass30_0();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
				{
					num2 = 1;
				}
				break;
			default:
				result = facadeBase.Where(_003C_003Ec__DisplayClass30_._003CGetFailedServer_003Eb__0).ToArray();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 != 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				_003C_003Ec__DisplayClass30_.m_ConfigBase = rpc;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private static void Logout()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				Game.instance.Logout();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				return;
			default:
				AccessTools.DeclaredField(typeof(ZNet), DicSingleton.gE3WbyDVW(0x5A8BEE ^ 0x5ADBC2)).SetValue(null, ZNet.ConnectionStatus.ErrorVersion);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	private static void DisconnectClient(ZRpc rpc)
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
				rpc.Invoke(DicSingleton.gE3WbyDVW(0x4BDBCDC0 ^ 0x4BDBE5E8), 3);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private static void CheckVersion(ZRpc rpc, ZPackage pkg)
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
				CheckVersion(rpc, pkg, null);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	private static void CheckVersion(ZRpc rpc, ZPackage pkg, [_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(new byte[] { 2, 1, 1 })] Action<ZRpc, ZPackage> original)
	{
		string text = pkg.ReadString();
		string text2 = pkg.ReadString();
		string text3 = pkg.ReadString();
		bool flag = false;
		foreach (ParamBase item in facadeBase)
		{
			if (!(text != item._InstanceBase))
			{
				Debug.Log(DicSingleton.gE3WbyDVW(0xB967DC8 ^ 0xB962D9C) + item.DisplayName + DicSingleton.gE3WbyDVW(0x7742C60 ^ 0x7747C76) + text3 + DicSingleton.gE3WbyDVW(0x2BC53863 ^ 0x2BC56809) + text2 + DicSingleton.gE3WbyDVW(0x567B7B7F ^ 0x567B2BE7) + (ZNet.instance.IsServer() ? DicSingleton.gE3WbyDVW(-1244021215 ^ -1244008735) : DicSingleton.gE3WbyDVW(0x33F6A245 ^ 0x33F6F2F5)) + DicSingleton.gE3WbyDVW(-1385030784 ^ -1385016098));
				item.serviceBase = text2;
				item.recordBase = text3;
				if (ZNet.instance.IsServer() && item.IsVersionOk())
				{
					item._BridgeBase.Add(rpc);
				}
				flag = true;
			}
		}
		if (flag)
		{
			return;
		}
		pkg.SetPos(0);
		if (original != null)
		{
			original(rpc, pkg);
			if (pkg.GetPos() == 0)
			{
				eventBase.Add(text, text3);
			}
		}
	}

	[HarmonyPatch(typeof(ZNet), "RPC_PeerInfo")]
	[HarmonyPrefix]
	private static bool RPC_PeerInfo(ZRpc rpc, ZNet __instance)
	{
		int num = 15;
		bool result = default(bool);
		int num3 = default(int);
		ParamBase paramBase = default(ParamBase);
		ParamBase[] array2 = default(ParamBase[]);
		bool flag2 = default(bool);
		bool flag = default(bool);
		ParamBase[] array3 = default(ParamBase[]);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				ParamBase[] array;
				switch (num2)
				{
				case 17:
				case 23:
					result = false;
					num2 = 16;
					continue;
				case 4:
					array = GetFailedClient();
					break;
				case 21:
					num3 = 0;
					num2 = 19;
					continue;
				case 22:
					goto end_IL_0012;
				case 15:
					if (__instance.IsServer())
					{
						num2 = 14;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 4;
				case 3:
					Debug.LogWarning(paramBase.Error(rpc));
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 != 0)
					{
						num2 = 12;
					}
					continue;
				default:
					return result;
				case 19:
				case 20:
					if (num3 < array2.Length)
					{
						num2 = 8;
						continue;
					}
					goto case 18;
				case 7:
					Logout();
					num2 = 17;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
					{
						num2 = 9;
					}
					continue;
				case 12:
					num3++;
					num2 = 20;
					continue;
				case 1:
					if (flag2)
					{
						num2 = 2;
						continue;
					}
					goto case 7;
				case 13:
					if (!flag)
					{
						num2 = 11;
						continue;
					}
					goto end_IL_0012;
				case 2:
					DisconnectClient(rpc);
					num2 = 23;
					continue;
				case 6:
					flag = array3.Length == 0;
					num2 = 13;
					continue;
				case 5:
				case 11:
					array2 = array3;
					num2 = 21;
					continue;
				case 8:
				case 10:
					paramBase = array2[num3];
					num2 = 3;
					continue;
				case 18:
					flag2 = __instance.IsServer();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
					{
						num2 = 0;
					}
					continue;
				case 14:
					array = GetFailedServer(rpc);
					break;
				}
				array3 = array;
				num2 = 6;
				continue;
				end_IL_0012:
				break;
			}
			result = true;
			num = 9;
		}
	}

	[HarmonyPrefix]
	[HarmonyPatch(typeof(ZNet), "OnNewConnection")]
	private static void RegisterAndCheckVersion(ZNetPeer peer, ZNet __instance)
	{
		int num = 13;
		bool flag = default(bool);
		IDictionary dictionary = default(IDictionary);
		HashSet<ParamBase>.Enumerator enumerator = default(HashSet<ParamBase>.Enumerator);
		_003C_003Ec__DisplayClass36_0 _003C_003Ec__DisplayClass36_ = default(_003C_003Ec__DisplayClass36_0);
		object obj = default(object);
		ParamBase current = default(ParamBase);
		ZPackage zPackage = default(ZPackage);
		bool flag2 = default(bool);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 13:
					break;
				case 8:
					flag = dictionary.Contains(DicSingleton.gE3WbyDVW(-1741204886 ^ -1741225344).GetStableHashCode());
					num2 = 11;
					continue;
				case 12:
					dictionary = (IDictionary)typeof(ZRpc).GetField(DicSingleton.gE3WbyDVW(-1075938037 ^ -1075958309), BindingFlags.Instance | BindingFlags.NonPublic).GetValue(peer.m_rpc);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
					{
						num2 = 8;
					}
					continue;
				case 11:
					if (!flag)
					{
						num2 = 9;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba != 0)
						{
							num2 = 6;
						}
						continue;
					}
					goto case 3;
				default:
					enumerator = facadeBase.GetEnumerator();
					num2 = 6;
					continue;
				case 2:
					_003C_003Ec__DisplayClass36_.m_WrapperBase = (Action<ZRpc, ZPackage>)obj.GetType().GetField(DicSingleton.gE3WbyDVW(-2103041941 ^ -2103021193), BindingFlags.Instance | BindingFlags.NonPublic).GetValue(obj);
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
					{
						num2 = 5;
					}
					continue;
				case 3:
					_003C_003Ec__DisplayClass36_ = new _003C_003Ec__DisplayClass36_0();
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 != 0)
					{
						num2 = 4;
					}
					continue;
				case 5:
					peer.m_rpc.Register<ZPackage>(DicSingleton.gE3WbyDVW(-1735703950 ^ -1735716200), _003C_003Ec__DisplayClass36_._003CRegisterAndCheckVersion_003Eb__0);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
					{
						num2 = 0;
					}
					continue;
				case 6:
					try
					{
						while (true)
						{
							IL_02fb:
							int num3;
							if (!enumerator.MoveNext())
							{
								num3 = 4;
								goto IL_01fb;
							}
							goto IL_02e2;
							IL_0328:
							current.Initialize();
							int num4 = 8;
							goto IL_01f7;
							IL_02e2:
							current = enumerator.Current;
							num4 = 3;
							goto IL_01f7;
							IL_01f7:
							num3 = num4;
							goto IL_01fb;
							IL_01fb:
							while (true)
							{
								int num5;
								switch (num3)
								{
								case 10:
									peer.m_rpc.Invoke(DicSingleton.gE3WbyDVW(-948533799 ^ -948513485), zPackage);
									num3 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
									{
										num3 = 1;
									}
									continue;
								case 2:
									zPackage.Write(current.MinimumRequiredVersion);
									num3 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
									{
										num3 = 0;
									}
									continue;
								case 13:
									zPackage.Write(current._InstanceBase);
									num3 = 2;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
									{
										num3 = 2;
									}
									continue;
								case 7:
									break;
								case 1:
								case 14:
									goto IL_02fb;
								case 8:
									if (current.clientBase)
									{
										num3 = 12;
										continue;
									}
									goto case 9;
								case 3:
									goto IL_0328;
								case 6:
									zPackage = new ZPackage();
									num3 = 3;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 != 0)
									{
										num3 = 13;
									}
									continue;
								case 9:
									num5 = ((!__instance.IsServer()) ? 1 : 0);
									goto IL_03be;
								case 5:
									if (flag2)
									{
										num3 = 8;
										if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a != 0)
										{
											num3 = 14;
										}
										continue;
									}
									goto case 11;
								default:
									zPackage.Write(current.CurrentVersion);
									num3 = 10;
									continue;
								case 12:
									num5 = 0;
									goto IL_03be;
								case 11:
									Debug.Log(DicSingleton.gE3WbyDVW(-1611872559 ^ -1611884575) + current.DisplayName + DicSingleton.gE3WbyDVW(-736996892 ^ -737017358) + current.CurrentVersion + DicSingleton.gE3WbyDVW(-490894496 ^ -490874102) + current.MinimumRequiredVersion + DicSingleton.gE3WbyDVW(0xB026CF2 ^ 0xB023DB6) + (__instance.IsServer() ? DicSingleton.gE3WbyDVW(-379532028 ^ -379544124) : DicSingleton.gE3WbyDVW(0x166FBD ^ 0x163F0D)) + DicSingleton.gE3WbyDVW(-2133864647 ^ -2133884825));
									num3 = 6;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
									{
										num3 = 4;
									}
									continue;
								case 4:
									return;
									IL_03be:
									flag2 = (byte)num5 != 0;
									num3 = 1;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db != 0)
									{
										num3 = 5;
									}
									continue;
								}
								break;
							}
							goto IL_02e2;
						}
					}
					finally
					{
						((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						int num6 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
						{
							num6 = 0;
						}
						switch (num6)
						{
						case 0:
							break;
						}
					}
				case 10:
					return;
				case 7:
					obj = dictionary[DicSingleton.gE3WbyDVW(-1483531944 ^ -1483519566).GetStableHashCode()];
					num2 = 2;
					continue;
				case 1:
				case 9:
					peer.m_rpc.Register<ZPackage>(DicSingleton.gE3WbyDVW(0x602C149E ^ 0x602C4474), CheckVersion);
					num2 = 4;
					continue;
				}
				break;
			}
			eventBase.Clear();
			num = 12;
		}
	}

	[HarmonyPrefix]
	[HarmonyPatch(typeof(ZNet), "Disconnect")]
	private static void RemoveDisconnected(ZNetPeer peer, ZNet __instance)
	{
		if (!__instance.IsServer())
		{
			return;
		}
		foreach (ParamBase item in facadeBase)
		{
			item._BridgeBase.Remove(peer.m_rpc);
		}
	}

	[HarmonyPostfix]
	[HarmonyPatch(typeof(FejdStartup), "ShowConnectError")]
	private static void ShowConnectionError(FejdStartup __instance)
	{
		int num = 16;
		bool flag3 = default(bool);
		IEnumerator<KeyValuePair<string, string>> enumerator = default(IEnumerator<KeyValuePair<string, string>>);
		TMP_Text connectionFailedError2 = default(TMP_Text);
		KeyValuePair<string, string> current = default(KeyValuePair<string, string>);
		bool flag5 = default(bool);
		bool flag = default(bool);
		float num4 = default(float);
		string text = default(string);
		bool flag2 = default(bool);
		ParamBase[] failedClient = default(ParamBase[]);
		RectTransform component2 = default(RectTransform);
		bool flag4 = default(bool);
		RectTransform component = default(RectTransform);
		while (true)
		{
			int num2 = num;
			Vector2 sizeDelta;
			while (true)
			{
				int num3;
				switch (num2)
				{
				case 16:
					if (!__instance.m_connectionFailedPanel.activeSelf)
					{
						num2 = 15;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 != 0)
						{
							num2 = 6;
						}
						continue;
					}
					goto default;
				case 2:
					if (flag3)
					{
						num2 = 12;
						continue;
					}
					goto case 3;
				case 12:
					return;
				case 24:
					try
					{
						while (true)
						{
							IL_01fd:
							int num5;
							if (!enumerator.MoveNext())
							{
								num5 = 3;
								goto IL_00e0;
							}
							goto IL_01d9;
							IL_00e0:
							while (true)
							{
								int num6;
								switch (num5)
								{
								case 5:
									connectionFailedError2.text = connectionFailedError2.text + DicSingleton.gE3WbyDVW(0x44072FB7 ^ 0x44077EEF) + current.Key + DicSingleton.gE3WbyDVW(0x120E76C ^ 0x120B6F8) + current.Value + DicSingleton.gE3WbyDVW(0x567B7B7F ^ 0x567B2AD1);
									num6 = 2;
									goto IL_00dc;
								case 7:
									flag5 = !__instance.m_connectionFailedError.text.Contains(current.Key);
									num5 = 6;
									continue;
								case 6:
									if (!flag5)
									{
										num5 = 0;
										if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb != 0)
										{
											num5 = 1;
										}
										continue;
									}
									goto case 4;
								case 8:
									break;
								default:
									goto IL_01fd;
								case 4:
									connectionFailedError2 = __instance.m_connectionFailedError;
									num6 = 5;
									goto IL_00dc;
								case 2:
									flag = true;
									num5 = 0;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
									{
										num5 = 0;
									}
									continue;
								case 3:
									goto end_IL_01fd;
									IL_00dc:
									num5 = num6;
									continue;
								}
								break;
							}
							goto IL_01d9;
							IL_01d9:
							current = enumerator.Current;
							num5 = 7;
							goto IL_00e0;
							continue;
							end_IL_01fd:
							break;
						}
					}
					finally
					{
						int num7;
						if (enumerator == null)
						{
							num7 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
							{
								num7 = 1;
							}
							goto IL_0272;
						}
						goto IL_02a7;
						IL_0272:
						switch (num7)
						{
						default:
							goto end_IL_024d;
						case 1:
							goto end_IL_024d;
						case 2:
							break;
						case 0:
							goto end_IL_024d;
						}
						goto IL_02a7;
						IL_02a7:
						enumerator.Dispose();
						num7 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
						{
							num7 = 0;
						}
						goto IL_0272;
						end_IL_024d:;
					}
					goto case 4;
				case 22:
					num4 = __instance.m_connectionFailedError.renderedHeight + 105f;
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
					{
						num2 = 2;
					}
					continue;
				default:
					num3 = ((ZNet.GetConnectionStatus() != ZNet.ConnectionStatus.ErrorVersion) ? 1 : 0);
					goto IL_05a2;
				case 6:
					return;
				case 19:
					return;
				case 11:
				{
					TMP_Text connectionFailedError = __instance.m_connectionFailedError;
					connectionFailedError.text = connectionFailedError.text + DicSingleton.gE3WbyDVW(-614239580 ^ -614243118) + text;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 != 0)
					{
						num2 = 2;
					}
					continue;
				}
				case 9:
					if (flag2)
					{
						num2 = 21;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 != 0)
						{
							num2 = 10;
						}
						continue;
					}
					break;
				case 23:
					goto end_IL_0012;
				case 5:
					flag = true;
					num2 = 13;
					continue;
				case 3:
					flag = false;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 == 0)
					{
						num2 = 20;
					}
					continue;
				case 20:
					failedClient = GetFailedClient();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
					{
						num2 = 0;
					}
					continue;
				case 18:
					component2 = __instance.m_connectionFailedPanel.transform.Find(DicSingleton.gE3WbyDVW(-545065612 ^ -545075552)).GetComponent<RectTransform>();
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 != 0)
					{
						num2 = 3;
					}
					continue;
				case 7:
					if (!flag4)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 == 0)
						{
							num2 = 6;
						}
						continue;
					}
					goto case 18;
				case 17:
					__instance.m_connectionFailedError.ForceMeshUpdate();
					num2 = 22;
					continue;
				case 10:
				{
					RectTransform rectTransform = component2;
					sizeDelta = component2.sizeDelta;
					sizeDelta.x = 675f;
					rectTransform.sizeDelta = sizeDelta;
					num2 = 16;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
					{
						num2 = 17;
					}
					continue;
				}
				case 8:
					component.anchoredPosition = new Vector2(component.anchoredPosition.x, component.anchoredPosition.y - (num4 - component2.sizeDelta.y) / 2f);
					num2 = 23;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc == 0)
					{
						num2 = 12;
					}
					continue;
				case 1:
					flag2 = failedClient.Length != 0;
					num2 = 9;
					continue;
				case 14:
					component = component2.transform.Find(DicSingleton.gE3WbyDVW(0x9000142 ^ 0x9005088)).GetComponent<RectTransform>();
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
					{
						num2 = 8;
					}
					continue;
				case 4:
					flag4 = flag;
					num2 = 7;
					continue;
				case 15:
					num3 = 1;
					goto IL_05a2;
				case 21:
					text = string.Join(DicSingleton.gE3WbyDVW(-1614185587 ^ -1614189061), failedClient.Select([_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)] (ParamBase check) => check.Error()));
					num2 = 11;
					continue;
				case 13:
					break;
					IL_05a2:
					flag3 = (byte)num3 != 0;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c == 0)
					{
						num2 = 2;
					}
					continue;
				}
				enumerator = eventBase.OrderBy([_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(0)] (KeyValuePair<string, string> kv) => kv.Key).GetEnumerator();
				num2 = 24;
				continue;
				end_IL_0012:
				break;
			}
			RectTransform rectTransform2 = component2;
			sizeDelta = component2.sizeDelta;
			sizeDelta.y = num4;
			rectTransform2.sizeDelta = sizeDelta;
			num = 19;
		}
	}

	internal static bool RemoveCustomer()
	{
		return StartCustomer == null;
	}

	internal static ParamBase ResolveCustomer()
	{
		return StartCustomer;
	}
}
