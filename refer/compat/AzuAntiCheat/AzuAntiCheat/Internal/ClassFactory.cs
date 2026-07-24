using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class ClassFactory : ListenerFactory
{
	[CompilerGenerated]
	private readonly RuleFactory consumerFactory;

	[CompilerGenerated]
	private readonly bool configurationFactory;

	internal static ClassFactory ValidateObject;

	internal override SchemaCompareFilterSetting Type => (SchemaCompareFilterSetting)6;

	public string Value { get; }

	public RuleFactory Style
	{
		[CompilerGenerated]
		get
		{
			return consumerFactory;
		}
	}

	public bool IsPlainImplicit { get; }

	public bool IsQuotedImplicit
	{
		[CompilerGenerated]
		get
		{
			return configurationFactory;
		}
	}

	public override bool IsCanonical
	{
		get
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					if (!IsPlainImplicit)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
						{
							num2 = 0;
						}
						break;
					}
					return false;
				default:
					return !IsQuotedImplicit;
				}
			}
		}
	}

	public ClassFactory(HelperReader anchor, ValueFactory tag, string value, RuleFactory style, bool isPlainImplicit, bool isQuotedImplicit, QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(anchor, tag, start, end);
		_ObjectFactory = value;
		consumerFactory = style;
		_PropertyFactory = isPlainImplicit;
		configurationFactory = isQuotedImplicit;
	}

	public ClassFactory(HelperReader anchor, ValueFactory tag, string value, RuleFactory style, bool isPlainImplicit, bool isQuotedImplicit)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(anchor, tag, value, style, isPlainImplicit, isQuotedImplicit, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ClassFactory(string value)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(HelperReader._ExceptionReader, ValueFactory._DecoratorFactory, value, (RuleFactory)0, isPlainImplicit: true, isQuotedImplicit: true, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ClassFactory(ValueFactory tag, string value)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(HelperReader._ExceptionReader, tag, value, (RuleFactory)0, isPlainImplicit: true, isQuotedImplicit: true, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ClassFactory(HelperReader anchor, ValueFactory tag, string value)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(anchor, tag, value, (RuleFactory)0, isPlainImplicit: true, isQuotedImplicit: true, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
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
		return string.Format(DicSingleton.gE3WbyDVW(-381685266 ^ -381723282), base.Anchor, base.Tag, Value, Style, IsPlainImplicit, IsQuotedImplicit);
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool EnableObject()
	{
		return ValidateObject == null;
	}

	internal static ClassFactory SortObject()
	{
		return ValidateObject;
	}
}
