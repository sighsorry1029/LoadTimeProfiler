using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal abstract class RegistryAuthentication
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public IDictionary _ValueAuthentication;

		public RegistryAuthentication _DecoratorAuthentication;

		public FacadeSingleton _BroadcasterAuthentication;

		internal static _003C_003Ec__DisplayClass3_0 AddMock;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool PrepareMock()
		{
			return AddMock == null;
		}

		internal static _003C_003Ec__DisplayClass3_0 WriteMock()
		{
			return AddMock;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_1
	{
		public object m_WorkerAuthentication;

		public object m_TaskAuthentication;

		public _003C_003Ec__DisplayClass3_0 m_UtilsAuthentication;

		internal static _003C_003Ec__DisplayClass3_1 PrintMock;

		public _003C_003Ec__DisplayClass3_1()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal void _003CDeserialize_003Eb__0(object? v)
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
					m_UtilsAuthentication._ValueAuthentication[v] = m_WorkerAuthentication;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		internal void _003CDeserialize_003Eb__1(object? v)
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
					m_UtilsAuthentication._ValueAuthentication[m_TaskAuthentication] = v;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		internal static bool CompareMock()
		{
			return PrintMock == null;
		}

		internal static _003C_003Ec__DisplayClass3_1 CloneMock()
		{
			return PrintMock;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_2
	{
		public bool testsAuthentication;

		public _003C_003Ec__DisplayClass3_1 initializerAuthentication;

		internal static _003C_003Ec__DisplayClass3_2 ReadMock;

		public _003C_003Ec__DisplayClass3_2()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal void _003CDeserialize_003Eb__2(object? v)
		{
			int num = 3;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 3:
					if (!testsAuthentication)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
						{
							num2 = 1;
						}
						break;
					}
					goto case 1;
				case 1:
					initializerAuthentication.m_UtilsAuthentication._DecoratorAuthentication.TryAssign(initializerAuthentication.m_UtilsAuthentication._ValueAuthentication, v, initializerAuthentication.m_WorkerAuthentication, initializerAuthentication.m_UtilsAuthentication._BroadcasterAuthentication);
					num2 = 5;
					break;
				case 4:
					testsAuthentication = true;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 != 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				case 5:
					return;
				case 2:
					initializerAuthentication.m_TaskAuthentication = v;
					num2 = 4;
					break;
				}
			}
		}

		internal void _003CDeserialize_003Eb__3(object? v)
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 2:
					testsAuthentication = true;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
					{
						num2 = 3;
					}
					break;
				case 1:
					if (!testsAuthentication)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 != 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 4;
				case 4:
					initializerAuthentication.m_UtilsAuthentication._DecoratorAuthentication.TryAssign(initializerAuthentication.m_UtilsAuthentication._ValueAuthentication, initializerAuthentication.m_TaskAuthentication, v, initializerAuthentication.m_UtilsAuthentication._BroadcasterAuthentication);
					num2 = 5;
					break;
				case 5:
					return;
				default:
					initializerAuthentication.m_WorkerAuthentication = v;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 == 0)
					{
						num2 = 2;
					}
					break;
				case 3:
					return;
				}
			}
		}

		internal static bool ViewMock()
		{
			return ReadMock == null;
		}

		internal static _003C_003Ec__DisplayClass3_2 InitMock()
		{
			return ReadMock;
		}
	}

	private readonly bool m_StateAuthentication;

	internal static RegistryAuthentication ConcatMock;

	public RegistryAuthentication(bool duplicateKeyChecking)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 != 0)
		{
			num = 1;
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
				m_StateAuthentication = duplicateKeyChecking;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	private void TryAssign(IDictionary result, object key, object value, FacadeSingleton propertyName)
	{
		int num = 4;
		int num2 = num;
		TestsInterpreter start = default(TestsInterpreter);
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			case 1:
				start = propertyName.Start;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
				{
					num2 = 0;
				}
				break;
			case 4:
				if (!m_StateAuthentication)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 != 0)
					{
						num2 = 3;
					}
					break;
				}
				goto case 5;
			default:
				throw new ReaderSingleton(in start, propertyName.End, string.Format(DicSingleton.gE3WbyDVW(-1614185587 ^ -1614162493), key));
			case 3:
				result[key] = value;
				num2 = 2;
				break;
			case 5:
				if (result.Contains(key))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 3;
			}
		}
	}

	protected virtual void Deserialize(Type tKey, Type tValue, CandidateInterpreter parser, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, IDictionary result)
	{
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
		_003C_003Ec__DisplayClass3_._ValueAuthentication = result;
		_003C_003Ec__DisplayClass3_._DecoratorAuthentication = this;
		_003C_003Ec__DisplayClass3_._BroadcasterAuthentication = parser.Consume<FacadeSingleton>();
		ParamSingleton @event;
		while (!parser.TryConsume<ParamSingleton>(out @event))
		{
			_003C_003Ec__DisplayClass3_1 CS_0024_003C_003E8__locals32 = new _003C_003Ec__DisplayClass3_1();
			CS_0024_003C_003E8__locals32.m_UtilsAuthentication = _003C_003Ec__DisplayClass3_;
			CS_0024_003C_003E8__locals32.m_TaskAuthentication = nestedObjectDeserializer(parser, tKey);
			CS_0024_003C_003E8__locals32.m_WorkerAuthentication = nestedObjectDeserializer(parser, tValue);
			ProcessSetter processSetter = CS_0024_003C_003E8__locals32.m_WorkerAuthentication as ProcessSetter;
			if (CS_0024_003C_003E8__locals32.m_TaskAuthentication is ProcessSetter processSetter2)
			{
				if (processSetter == null)
				{
					processSetter2.ValueAvailable += delegate(object? v)
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
								CS_0024_003C_003E8__locals32.m_UtilsAuthentication._ValueAuthentication[v] = CS_0024_003C_003E8__locals32.m_WorkerAuthentication;
								num2 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
								{
									num2 = 0;
								}
								break;
							case 0:
								return;
							}
						}
					};
					continue;
				}
				_003C_003Ec__DisplayClass3_2 CS_0024_003C_003E8__locals30 = new _003C_003Ec__DisplayClass3_2();
				CS_0024_003C_003E8__locals30.initializerAuthentication = CS_0024_003C_003E8__locals32;
				CS_0024_003C_003E8__locals30.testsAuthentication = false;
				processSetter2.ValueAvailable += delegate(object? v)
				{
					int num = 3;
					int num2 = num;
					while (true)
					{
						switch (num2)
						{
						default:
							return;
						case 3:
							if (!CS_0024_003C_003E8__locals30.testsAuthentication)
							{
								num2 = 2;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
								{
									num2 = 1;
								}
								break;
							}
							goto case 1;
						case 1:
							CS_0024_003C_003E8__locals30.initializerAuthentication.m_UtilsAuthentication._DecoratorAuthentication.TryAssign(CS_0024_003C_003E8__locals30.initializerAuthentication.m_UtilsAuthentication._ValueAuthentication, v, CS_0024_003C_003E8__locals30.initializerAuthentication.m_WorkerAuthentication, CS_0024_003C_003E8__locals30.initializerAuthentication.m_UtilsAuthentication._BroadcasterAuthentication);
							num2 = 5;
							break;
						case 4:
							CS_0024_003C_003E8__locals30.testsAuthentication = true;
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 != 0)
							{
								num2 = 0;
							}
							break;
						case 0:
							return;
						case 5:
							return;
						case 2:
							CS_0024_003C_003E8__locals30.initializerAuthentication.m_TaskAuthentication = v;
							num2 = 4;
							break;
						}
					}
				};
				processSetter.ValueAvailable += delegate(object? v)
				{
					int num = 1;
					int num2 = num;
					while (true)
					{
						switch (num2)
						{
						case 2:
							CS_0024_003C_003E8__locals30.testsAuthentication = true;
							num2 = 3;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
							{
								num2 = 3;
							}
							break;
						case 1:
							if (!CS_0024_003C_003E8__locals30.testsAuthentication)
							{
								num2 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 != 0)
								{
									num2 = 0;
								}
								break;
							}
							goto case 4;
						case 4:
							CS_0024_003C_003E8__locals30.initializerAuthentication.m_UtilsAuthentication._DecoratorAuthentication.TryAssign(CS_0024_003C_003E8__locals30.initializerAuthentication.m_UtilsAuthentication._ValueAuthentication, CS_0024_003C_003E8__locals30.initializerAuthentication.m_TaskAuthentication, v, CS_0024_003C_003E8__locals30.initializerAuthentication.m_UtilsAuthentication._BroadcasterAuthentication);
							num2 = 5;
							break;
						case 5:
							return;
						default:
							CS_0024_003C_003E8__locals30.initializerAuthentication.m_WorkerAuthentication = v;
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 == 0)
							{
								num2 = 2;
							}
							break;
						case 3:
							return;
						}
					}
				};
				continue;
			}
			if (CS_0024_003C_003E8__locals32.m_TaskAuthentication == null)
			{
				throw new ArgumentException(DicSingleton.gE3WbyDVW(-1059662249 ^ -1059686181), DicSingleton.gE3WbyDVW(-1829625923 ^ -1829612509));
			}
			if (processSetter == null)
			{
				TryAssign(CS_0024_003C_003E8__locals32.m_UtilsAuthentication._ValueAuthentication, CS_0024_003C_003E8__locals32.m_TaskAuthentication, CS_0024_003C_003E8__locals32.m_WorkerAuthentication, CS_0024_003C_003E8__locals32.m_UtilsAuthentication._BroadcasterAuthentication);
				continue;
			}
			processSetter.ValueAvailable += delegate(object? v)
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
						CS_0024_003C_003E8__locals32.m_UtilsAuthentication._ValueAuthentication[CS_0024_003C_003E8__locals32.m_TaskAuthentication] = v;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c != 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			};
		}
	}

	internal static bool MapMock()
	{
		return ConcatMock == null;
	}

	internal static RegistryAuthentication NewMock()
	{
		return ConcatMock;
	}
}
