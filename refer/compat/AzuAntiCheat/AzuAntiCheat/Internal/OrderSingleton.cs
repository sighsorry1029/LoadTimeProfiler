using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal abstract class OrderSingleton : ClientSingleton
{
	[CompilerGenerated]
	private readonly RoleSingleton iteratorSingleton;

	internal static OrderSingleton PublishGetter;

	public VisitorAttribute Anchor { get; }

	public RoleSingleton Tag
	{
		[CompilerGenerated]
		get
		{
			return iteratorSingleton;
		}
	}

	public abstract bool IsCanonical { get; }

	protected OrderSingleton(VisitorAttribute anchor, RoleSingleton tag, TestsInterpreter start, TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				_ContainerSingleton = anchor;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
				{
					num = 0;
				}
				break;
			default:
				iteratorSingleton = tag;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
				{
					num = 2;
				}
				break;
			case 2:
				return;
			}
		}
	}

	protected OrderSingleton(VisitorAttribute anchor, RoleSingleton tag)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(anchor, tag, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool RegisterGetter()
	{
		return PublishGetter == null;
	}

	internal static OrderSingleton SetupGetter()
	{
		return PublishGetter;
	}
}
