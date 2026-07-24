using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class QueueFactory : ListenerFactory
{
	[CompilerGenerated]
	private readonly bool collectionFactory;

	private static QueueFactory CloneObject;

	public override int NestingIncrease => 1;

	internal override SchemaCompareFilterSetting Type => (SchemaCompareFilterSetting)9;

	public bool IsImplicit
	{
		[CompilerGenerated]
		get
		{
			return collectionFactory;
		}
	}

	public override bool IsCanonical => !IsImplicit;

	public TokenizerFactory Style { get; }

	public QueueFactory(HelperReader anchor, ValueFactory tag, bool isImplicit, TokenizerFactory style, QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(anchor, tag, start, end);
		int num = 2;
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 0:
				return;
			case 2:
				collectionFactory = isImplicit;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 != 0)
				{
					num = 1;
				}
				break;
			case 1:
				_ManagerFactory = style;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public QueueFactory(HelperReader anchor, ValueFactory tag, bool isImplicit, TokenizerFactory style)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(anchor, tag, isImplicit, style, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public QueueFactory()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(HelperReader._ExceptionReader, ValueFactory._DecoratorFactory, isImplicit: true, (TokenizerFactory)0, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
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
		return string.Format(DicSingleton.gE3WbyDVW(-1398029315 ^ -1398052851), base.Anchor, base.Tag, IsImplicit, Style);
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool ReadObject()
	{
		return CloneObject == null;
	}

	internal static QueueFactory ViewObject()
	{
		return CloneObject;
	}
}
