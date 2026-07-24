using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class ComposerPrototype
{
	[CompilerGenerated]
	private DecoratorPrototype _MapPrototype;

	[CompilerGenerated]
	private BridgePrototype helperPrototype;

	[CompilerGenerated]
	private IEnumerable<StatusPrototype> m_ExceptionPrototype;

	private readonly IEnumerable<ParserPrototype<RegPrototype>> m_ItemPrototype;

	private static ComposerPrototype QueryConfiguration;

	public ParserPrototype<ModelReader> InnerVisitor { get; private set; }

	public DecoratorPrototype EventEmitter
	{
		[CompilerGenerated]
		get
		{
			return _MapPrototype;
		}
		[CompilerGenerated]
		private set
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
					_MapPrototype = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}
	}

	public BridgePrototype NestedObjectSerializer
	{
		[CompilerGenerated]
		get
		{
			return helperPrototype;
		}
		[CompilerGenerated]
		private set
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
					helperPrototype = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public IEnumerable<StatusPrototype> TypeConverters
	{
		[CompilerGenerated]
		get
		{
			return m_ExceptionPrototype;
		}
		[CompilerGenerated]
		private set
		{
			m_ExceptionPrototype = value;
		}
	}

	public ComposerPrototype(ParserPrototype<ModelReader> innerVisitor, DecoratorPrototype eventEmitter, IEnumerable<ParserPrototype<RegPrototype>> preProcessingPhaseVisitors, IEnumerable<StatusPrototype> typeConverters, BridgePrototype nestedObjectSerializer)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		InnerVisitor = innerVisitor ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0xFB046CE ^ 0xFB01FEE));
		EventEmitter = eventEmitter ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x5901407C ^ 0x59011940));
		m_ItemPrototype = preProcessingPhaseVisitors ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x408F2744 ^ 0x408F7E1C));
		TypeConverters = typeConverters ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1064640644 ^ -1064663316));
		NestedObjectSerializer = nestedObjectSerializer ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x69B67B3A ^ 0x69B6228A));
	}

	public T GetPreProcessingPhaseObjectGraphVisitor<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] T>() where T : ParserPrototype<RegPrototype>
	{
		return m_ItemPrototype.OfType<T>().Single();
	}

	internal static bool AwakeConfiguration()
	{
		return QueryConfiguration == null;
	}

	internal static ComposerPrototype InstantiateConfiguration()
	{
		return QueryConfiguration;
	}
}
