using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal abstract class MappingFactory
{
	[CompilerGenerated]
	private readonly QueueReader schemaFactory;

	[CompilerGenerated]
	private readonly QueueReader m_StructFactory;

	private static MappingFactory CountObject;

	public virtual int NestingIncrease => 0;

	internal abstract SchemaCompareFilterSetting Type { get; }

	public QueueReader Start
	{
		[CompilerGenerated]
		get
		{
			return schemaFactory;
		}
	}

	public QueueReader End
	{
		[CompilerGenerated]
		get
		{
			return m_StructFactory;
		}
	}

	public abstract void Accept(DispatcherFactory visitor);

	internal MappingFactory(QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			default:
				schemaFactory = start ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x4995986C ^ 0x499532F8));
				num = 2;
				break;
			case 2:
				m_StructFactory = end ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x1679942F ^ 0x16793E8D));
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool SetObject()
	{
		return CountObject == null;
	}

	internal static MappingFactory PushObject()
	{
		return CountObject;
	}
}
