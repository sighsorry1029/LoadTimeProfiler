using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class RefFactory : ListenerFactory
{
	[CompilerGenerated]
	private readonly bool observerFactory;

	[CompilerGenerated]
	private readonly ProcFactory m_AdapterFactory;

	internal static RefFactory UpdateObject;

	public override int NestingIncrease => 1;

	internal override SchemaCompareFilterSetting Type => (SchemaCompareFilterSetting)7;

	public bool IsImplicit
	{
		[CompilerGenerated]
		get
		{
			return observerFactory;
		}
	}

	public override bool IsCanonical => !IsImplicit;

	public ProcFactory Style
	{
		[CompilerGenerated]
		get
		{
			return m_AdapterFactory;
		}
	}

	public RefFactory(HelperReader anchor, ValueFactory tag, bool isImplicit, ProcFactory style, QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(anchor, tag, start, end);
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af != 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 2:
				m_AdapterFactory = style;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			case 1:
				observerFactory = isImplicit;
				num = 2;
				break;
			}
		}
	}

	public RefFactory(HelperReader anchor, ValueFactory tag, bool isImplicit, ProcFactory style)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(anchor, tag, isImplicit, style, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public override string ToString()
	{
		return string.Format(DicSingleton.gE3WbyDVW(-1954645236 ^ -1954621826), base.Anchor, base.Tag, IsImplicit, Style);
	}

	public override void Accept(DispatcherFactory visitor)
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
				visitor.Visit(this);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool SearchObject()
	{
		return UpdateObject == null;
	}

	internal static RefFactory StopObject()
	{
		return UpdateObject;
	}
}
