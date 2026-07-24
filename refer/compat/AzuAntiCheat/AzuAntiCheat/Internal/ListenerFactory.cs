using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal abstract class ListenerFactory : MappingFactory
{
	[CompilerGenerated]
	private readonly HelperReader accountFactory;

	[CompilerGenerated]
	private readonly ValueFactory threadFactory;

	private static ListenerFactory ListObject;

	public HelperReader Anchor
	{
		[CompilerGenerated]
		get
		{
			return accountFactory;
		}
	}

	public ValueFactory Tag
	{
		[CompilerGenerated]
		get
		{
			return threadFactory;
		}
	}

	public abstract bool IsCanonical { get; }

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	protected ListenerFactory(HelperReader anchor, ValueFactory tag, QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end);
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
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
			case 2:
				threadFactory = tag;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 == 0)
				{
					num = 0;
				}
				break;
			case 1:
				accountFactory = anchor;
				num = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
				{
					num = 2;
				}
				break;
			}
		}
	}

	protected ListenerFactory(HelperReader anchor, ValueFactory tag)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(anchor, tag, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool CalcObject()
	{
		return ListObject == null;
	}

	internal static ListenerFactory LogoutObject()
	{
		return ListObject;
	}
}
