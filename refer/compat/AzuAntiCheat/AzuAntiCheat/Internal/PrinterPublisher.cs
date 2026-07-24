using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace AzuAnticheat.Internal;

[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(2)]
internal abstract class PrinterPublisher
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action databasePublisher;

	public object _ErrorPublisher;

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(1)]
	public readonly string _RegPublisher;

	[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(1)]
	public readonly Type _ReponsePublisher;

	private object proxyPublisher;

	protected bool _ModelPublisher;

	public readonly int m_AdvisorPublisher;

	internal static PrinterPublisher SearchWrapper;

	public object BoxedValue
	{
		get
		{
			return proxyPublisher;
		}
		set
		{
			int num = 2;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 0:
					return;
				case 3:
					return;
				case 1:
				{
					Action action = databasePublisher;
					if (action == null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef != 0)
						{
							num2 = 0;
						}
					}
					else
					{
						action();
						num2 = 3;
					}
					break;
				}
				case 2:
					proxyPublisher = value;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	public void CalcRole(Action value)
	{
		int num = 1;
		int num2 = num;
		Action action2 = default(Action);
		Action action = default(Action);
		Action value2 = default(Action);
		while (true)
		{
			switch (num2)
			{
			case 1:
				action2 = databasePublisher;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
				{
					num2 = 0;
				}
				break;
			default:
				action = action2;
				num2 = 3;
				break;
			case 5:
				if ((object)action2 == action)
				{
					num2 = 4;
					break;
				}
				goto default;
			case 2:
				action2 = Interlocked.CompareExchange(ref databasePublisher, value2, action);
				num2 = 5;
				break;
			case 4:
				return;
			case 3:
				value2 = (Action)Delegate.Combine(action, value);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 == 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	public void ViewRole(Action value)
	{
		int num = 1;
		int num2 = num;
		Action action2 = default(Action);
		Action action = default(Action);
		Action value2 = default(Action);
		while (true)
		{
			switch (num2)
			{
			case 5:
				return;
			default:
				action2 = action;
				num2 = 3;
				break;
			case 2:
				if ((object)action == action2)
				{
					num2 = 5;
					break;
				}
				goto default;
			case 3:
				value2 = (Action)Delegate.Remove(action2, value);
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				action = databasePublisher;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
				{
					num2 = 0;
				}
				break;
			case 4:
				action = Interlocked.CompareExchange(ref databasePublisher, value2, action2);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(1)]
	protected PrinterPublisher(RepositoryPublisher configSync, string identifier, Type type, int priority)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 5;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			default:
				_RegPublisher = identifier;
				num = 4;
				break;
			case 3:
				configSync.AddCustomValue(this);
				num = 6;
				break;
			case 2:
				configSync.QueryRole += delegate(bool truth)
				{
					int num2 = 1;
					int num3 = num2;
					while (true)
					{
						switch (num3)
						{
						default:
							return;
						case 1:
							_ModelPublisher = truth;
							num3 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
							{
								num3 = 0;
							}
							break;
						case 0:
							return;
						}
					}
				};
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
				{
					num = 0;
				}
				break;
			case 6:
				_ModelPublisher = configSync.IsSourceOfTruth;
				num = 2;
				break;
			case 4:
				_ReponsePublisher = type;
				num = 3;
				break;
			case 5:
				m_AdvisorPublisher = priority;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool StopWrapper()
	{
		return SearchWrapper == null;
	}

	internal static PrinterPublisher ExcludeWrapper()
	{
		return SearchWrapper;
	}
}
