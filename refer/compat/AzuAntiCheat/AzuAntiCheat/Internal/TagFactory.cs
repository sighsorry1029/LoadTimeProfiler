using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class TagFactory : MappingFactory
{
	internal static TagFactory InvokeObject;

	internal override SchemaCompareFilterSetting Type => (SchemaCompareFilterSetting)5;

	public HelperReader Value { get; }

	public TagFactory(HelperReader value, QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end);
		if (value.IsEmpty)
		{
			throw new TestsFactory(start, end, DicSingleton.gE3WbyDVW(-948533799 ^ -948555915));
		}
		_VisitorFactory = value;
	}

	public TagFactory(HelperReader value)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(value, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
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
		return string.Format(DicSingleton.gE3WbyDVW(-830028630 ^ -830050748), Value);
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
			case 0:
				return;
			case 1:
				visitor.Visit(this);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool PublishObject()
	{
		return InvokeObject == null;
	}

	internal static TagFactory RegisterObject()
	{
		return InvokeObject;
	}
}
