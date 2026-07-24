using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal static class InterpreterFactory
{
	internal static InterpreterFactory SortError;

	public static T Consume<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] T>(this StubReader parser) where T : MappingFactory
	{
		T result = parser.Require<T>();
		parser.MoveNext();
		return result;
	}

	public static bool TryConsume<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] T>(this StubReader parser, [StrategyBase(false)] out T @event) where T : MappingFactory
	{
		if (parser.Accept<T>(out @event))
		{
			parser.MoveNext();
			return true;
		}
		return false;
	}

	public static T Require<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] T>(this StubReader parser) where T : MappingFactory
	{
		if (!parser.Accept<T>(out var @event))
		{
			MappingFactory current = parser.Current;
			if (current == null)
			{
				throw new TestsFactory(DicSingleton.gE3WbyDVW(0x6BAF1854 ^ 0x6BAF9554) + typeof(T).Name + DicSingleton.gE3WbyDVW(0x6729A6D ^ 0x6721775));
			}
			throw new TestsFactory(current.Start, current.End, string.Format(DicSingleton.gE3WbyDVW(-1447578472 ^ -1447609950), typeof(T).Name, current.GetType().Name, current.Start));
		}
		return @event;
	}

	public static bool Accept<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] T>(this StubReader parser, [StrategyBase(false)] out T @event) where T : MappingFactory
	{
		if (parser.Current == null && !parser.MoveNext())
		{
			throw new EndOfStreamException();
		}
		if (parser.Current is T val)
		{
			@event = val;
			return true;
		}
		@event = null;
		return false;
	}

	public static void SkipThisAndNestedEvents(this StubReader parser)
	{
		int num = 2;
		int num2 = num;
		MappingFactory mappingFactory = default(MappingFactory);
		int num3 = default(int);
		while (true)
		{
			switch (num2)
			{
			case 1:
			case 4:
				mappingFactory = parser.Consume<MappingFactory>();
				num2 = 3;
				break;
			case 5:
				return;
			case 2:
				num3 = 0;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
				{
					num2 = 1;
				}
				break;
			default:
				if (num3 <= 0)
				{
					return;
				}
				num2 = 4;
				break;
			case 3:
				num3 += mappingFactory.NestingIncrease;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	[Obsolete("Please use Consume<T>() instead")]
	public static T Expect<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] T>(this StubReader parser) where T : MappingFactory
	{
		return parser.Consume<T>();
	}

	[Obsolete("Please use TryConsume<T>(out var evt) instead")]
	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public static T Allow<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] T>(this StubReader parser) where T : MappingFactory
	{
		if (!parser.TryConsume<T>(out var @event))
		{
			return null;
		}
		return @event;
	}

	[Obsolete("Please use Accept<T>(out var evt) instead")]
	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public static T Peek<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] T>(this StubReader parser) where T : MappingFactory
	{
		if (!parser.Accept<T>(out var @event))
		{
			return null;
		}
		return @event;
	}

	[Obsolete("Please use TryConsume<T>(out var evt) or Accept<T>(out var evt) instead")]
	public static bool Accept<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] T>(this StubReader parser) where T : MappingFactory
	{
		T @event;
		return parser.Accept<T>(out @event);
	}

	internal static bool InsertError()
	{
		return SortError == null;
	}

	internal static InterpreterFactory FindError()
	{
		return SortError;
	}
}
