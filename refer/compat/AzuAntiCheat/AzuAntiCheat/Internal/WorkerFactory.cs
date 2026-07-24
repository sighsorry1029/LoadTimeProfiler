using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class WorkerFactory
{
	private static WorkerFactory ManageError;

	public int Major { get; }

	public int Minor { get; }

	public WorkerFactory(int major, int minor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 2;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
		{
			num = 2;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 0:
				return;
			case 2:
				if (major < 0)
				{
					throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-940539791 ^ -940562199), string.Format(DicSingleton.gE3WbyDVW(0x74FC52AF ^ 0x74FCFA09), major));
				}
				_TaskFactory = major;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
				{
					num = 1;
				}
				break;
			case 1:
				if (minor < 0)
				{
					throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-220409977 ^ -220436663), string.Format(DicSingleton.gE3WbyDVW(0x15823EC4 ^ 0x15829662), minor));
				}
				_UtilsFactory = minor;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	public override bool Equals(object obj)
	{
		int num = 1;
		int num2 = num;
		WorkerFactory workerFactory = default(WorkerFactory);
		while (true)
		{
			switch (num2)
			{
			case 2:
				if (Major == workerFactory.Major)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
					{
						num2 = 3;
					}
					continue;
				}
				break;
			case 1:
				workerFactory = obj as WorkerFactory;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
				{
					num2 = 0;
				}
				continue;
			default:
				if (workerFactory != null)
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 != 0)
					{
						num2 = 2;
					}
					continue;
				}
				break;
			case 3:
				return Minor == workerFactory.Minor;
			}
			break;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = 1;
		int num2 = num;
		int major = default(int);
		while (true)
		{
			switch (num2)
			{
			case 1:
				major = Major;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return ProxyReader.CombineHashCodes(major.GetHashCode(), Minor.GetHashCode());
			}
		}
	}

	internal static bool ForgotError()
	{
		return ManageError == null;
	}

	internal static WorkerFactory RestartError()
	{
		return ManageError;
	}
}
