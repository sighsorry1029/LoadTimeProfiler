using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class ProcessorFactory : MappingFactory
{
	[CompilerGenerated]
	private readonly bool infoFactory;

	private static ProcessorFactory CreateObject;

	public override int NestingIncrease => -1;

	internal override SchemaCompareFilterSetting Type => (SchemaCompareFilterSetting)4;

	public bool IsImplicit
	{
		[CompilerGenerated]
		get
		{
			return infoFactory;
		}
	}

	public ProcessorFactory(bool isImplicit, QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end);
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 1:
				infoFactory = isImplicit;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a != 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public ProcessorFactory(bool isImplicit)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(isImplicit, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 == 0)
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
		return string.Format(DicSingleton.gE3WbyDVW(0x7FAAD78F ^ 0x7FAA7CC1), IsImplicit);
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool TestObject()
	{
		return CreateObject == null;
	}

	internal static ProcessorFactory RunObject()
	{
		return CreateObject;
	}
}
