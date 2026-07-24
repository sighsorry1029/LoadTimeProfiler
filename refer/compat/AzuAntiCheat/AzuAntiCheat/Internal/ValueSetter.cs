using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ValueSetter
{
	[CompilerGenerated]
	private ErrorSetter<MockInterpreter> decoratorSetter;

	[CompilerGenerated]
	private ValSetter broadcasterSetter;

	[CompilerGenerated]
	private StubSetter _WorkerSetter;

	[CompilerGenerated]
	private IEnumerable<StrategySetter> taskSetter;

	private readonly IEnumerable<ErrorSetter<MappingSetter>> _UtilsSetter;

	private static ValueSetter AwakeParameter;

	public ErrorSetter<MockInterpreter> InnerVisitor
	{
		[CompilerGenerated]
		get
		{
			return decoratorSetter;
		}
		[CompilerGenerated]
		private set
		{
			decoratorSetter = value;
		}
	}

	public ValSetter EventEmitter
	{
		[CompilerGenerated]
		get
		{
			return broadcasterSetter;
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
					broadcasterSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
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

	public StubSetter NestedObjectSerializer
	{
		[CompilerGenerated]
		get
		{
			return _WorkerSetter;
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
					_WorkerSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 == 0)
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

	public IEnumerable<StrategySetter> TypeConverters
	{
		[CompilerGenerated]
		get
		{
			return taskSetter;
		}
		[CompilerGenerated]
		private set
		{
			taskSetter = value;
		}
	}

	public ValueSetter(ErrorSetter<MockInterpreter> innerVisitor, ValSetter eventEmitter, IEnumerable<ErrorSetter<MappingSetter>> preProcessingPhaseVisitors, IEnumerable<StrategySetter> typeConverters, StubSetter nestedObjectSerializer)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		InnerVisitor = innerVisitor ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-614239580 ^ -614257788));
		EventEmitter = eventEmitter ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x765D303 ^ 0x7658A3F));
		_UtilsSetter = preProcessingPhaseVisitors ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-475093377 ^ -475070681));
		TypeConverters = typeConverters ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0xFB046CE ^ 0xFB01F5E));
		NestedObjectSerializer = nestedObjectSerializer ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x7B291245 ^ 0x7B294BF5));
	}

	public T GetPreProcessingPhaseObjectGraphVisitor<T>() where T : ErrorSetter<MappingSetter>
	{
		return _UtilsSetter.OfType<T>().Single();
	}

	internal static bool InstantiateParameter()
	{
		return AwakeParameter == null;
	}

	internal static ValueSetter LoginParameter()
	{
		return AwakeParameter;
	}
}
