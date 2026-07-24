using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
internal sealed class DicFactory : MappingFactory
{
	[CompilerGenerated]
	private readonly StateFactory m_ParamsFactory;

	[CompilerGenerated]
	private readonly ProcessFactory poolFactory;

	[CompilerGenerated]
	private readonly bool m_DescriptorFactory;

	internal static DicFactory VerifyObject;

	public override int NestingIncrease => 1;

	internal override SchemaCompareFilterSetting Type => (SchemaCompareFilterSetting)3;

	public StateFactory Tags
	{
		[CompilerGenerated]
		get
		{
			return m_ParamsFactory;
		}
	}

	public ProcessFactory Version
	{
		[CompilerGenerated]
		get
		{
			return poolFactory;
		}
	}

	public bool IsImplicit
	{
		[CompilerGenerated]
		get
		{
			return m_DescriptorFactory;
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public DicFactory([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] ProcessFactory version, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] StateFactory tags, bool isImplicit, QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end);
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 != 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				poolFactory = version;
				num = 3;
				break;
			default:
				m_DescriptorFactory = isImplicit;
				num = 2;
				break;
			case 2:
				return;
			case 3:
				m_ParamsFactory = tags;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public DicFactory(ProcessFactory version, StateFactory tags, bool isImplicit)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(version, tags, isImplicit, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public DicFactory(QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(null, null, isImplicit: true, start, end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public DicFactory()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(null, null, isImplicit: true, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public override string ToString()
	{
		return string.Format(DicSingleton.gE3WbyDVW(0x4C23C86A ^ 0x4C2363FA), IsImplicit);
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool PopObject()
	{
		return VerifyObject == null;
	}

	internal static DicFactory PostObject()
	{
		return VerifyObject;
	}
}
