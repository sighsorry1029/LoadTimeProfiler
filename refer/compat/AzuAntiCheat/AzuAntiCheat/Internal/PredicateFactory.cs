using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class PredicateFactory
{
	private readonly GetterReader m_WatcherFactory;

	[CompilerGenerated]
	private bool customerFactory;

	[CompilerGenerated]
	private readonly bool m_SystemFactory;

	[CompilerGenerated]
	private readonly int resolverFactory;

	private static PredicateFactory InstantiateError;

	public bool IsPossible
	{
		[CompilerGenerated]
		get
		{
			return customerFactory;
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
				case 1:
					customerFactory = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 != 0)
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

	public bool IsRequired
	{
		[CompilerGenerated]
		get
		{
			return m_SystemFactory;
		}
	}

	public int TokenNumber
	{
		[CompilerGenerated]
		get
		{
			return resolverFactory;
		}
	}

	public int Index => m_WatcherFactory.Index;

	public int Line => m_WatcherFactory.Line;

	public int LineOffset => m_WatcherFactory.LineOffset;

	public QueueReader Mark => m_WatcherFactory.Mark();

	public void MarkAsImpossible()
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
				IsPossible = false;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public PredicateFactory()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 != 0)
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
				m_WatcherFactory = new GetterReader();
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public PredicateFactory(bool isRequired, int tokenNumber, GetterReader cursor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa != 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			default:
				IsPossible = true;
				num = 2;
				break;
			case 2:
				m_SystemFactory = isRequired;
				num = 4;
				break;
			case 1:
				return;
			case 3:
				m_WatcherFactory = new GetterReader(cursor);
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
				{
					num = 1;
				}
				break;
			case 4:
				resolverFactory = tokenNumber;
				num = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 == 0)
				{
					num = 3;
				}
				break;
			}
		}
	}

	internal static bool LoginError()
	{
		return InstantiateError == null;
	}

	internal static PredicateFactory ConnectError()
	{
		return InstantiateError;
	}
}
