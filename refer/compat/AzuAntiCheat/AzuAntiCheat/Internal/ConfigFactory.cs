using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class ConfigFactory : ModelFactory
{
	[CompilerGenerated]
	private readonly string m_WrapperFactory;

	[CompilerGenerated]
	private readonly RuleFactory m_ServerFactory;

	internal static ConfigFactory QueryReader;

	public string Value
	{
		[CompilerGenerated]
		get
		{
			return m_WrapperFactory;
		}
	}

	public RuleFactory Style
	{
		[CompilerGenerated]
		get
		{
			return m_ServerFactory;
		}
	}

	public ConfigFactory(string value)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(value, (RuleFactory)0);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ConfigFactory(string value, RuleFactory style)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(value, style, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ConfigFactory(string value, RuleFactory style, QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 2:
				return;
			case 1:
				m_ServerFactory = style;
				num = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
				{
					num = 2;
				}
				break;
			default:
				m_WrapperFactory = value ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x4F8CB66E ^ 0x4F8CFDC6));
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool AwakeReader()
	{
		return QueryReader == null;
	}

	internal static ConfigFactory InstantiateReader()
	{
		return QueryReader;
	}
}
