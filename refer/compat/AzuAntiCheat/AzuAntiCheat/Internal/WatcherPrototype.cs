using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class WatcherPrototype : RulesPrototype
{
	[CompilerGenerated]
	private bool _CustomerPrototype;

	[CompilerGenerated]
	private TokenizerFactory systemPrototype;

	private static WatcherPrototype ReflectConfiguration;

	public bool IsImplicit
	{
		[CompilerGenerated]
		get
		{
			return _CustomerPrototype;
		}
		[CompilerGenerated]
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
					_CustomerPrototype = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
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

	public TokenizerFactory Style
	{
		[CompilerGenerated]
		get
		{
			return systemPrototype;
		}
		[CompilerGenerated]
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
					systemPrototype = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public WatcherPrototype(UtilsPrototype source)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(source);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool CollectConfiguration()
	{
		return ReflectConfiguration == null;
	}

	internal static WatcherPrototype ManageConfiguration()
	{
		return ReflectConfiguration;
	}
}
