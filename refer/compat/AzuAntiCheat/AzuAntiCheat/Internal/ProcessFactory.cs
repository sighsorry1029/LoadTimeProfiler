using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class ProcessFactory : ModelFactory
{
	internal static ProcessFactory CalculateReader;

	public WorkerFactory Version { get; }

	public ProcessFactory(WorkerFactory version)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(version, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ProcessFactory(WorkerFactory version, QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end);
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c != 0)
		{
			num = 0;
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
				_RepositoryFactory = version;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
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
		int num = 3;
		int num2 = num;
		ProcessFactory processFactory = default(ProcessFactory);
		while (true)
		{
			switch (num2)
			{
			case 3:
				processFactory = obj as ProcessFactory;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
				{
					num2 = 2;
				}
				break;
			default:
				return Version.Equals(processFactory.Version);
			case 1:
				return false;
			case 2:
				if (processFactory == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 != 0)
					{
						num2 = 1;
					}
					break;
				}
				goto default;
			}
		}
	}

	public override int GetHashCode()
	{
		return Version.GetHashCode();
	}

	internal static bool MoveReader()
	{
		return CalculateReader == null;
	}

	internal static ProcessFactory RevertReader()
	{
		return CalculateReader;
	}
}
