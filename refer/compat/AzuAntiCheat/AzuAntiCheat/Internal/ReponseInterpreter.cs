using System;
using System.IO;

namespace AzuAnticheat.Internal;

internal static class ReponseInterpreter
{
	internal static ReponseInterpreter ConcatProducer;

	public static T Consume<T>(this CandidateInterpreter parser) where T : ClientSingleton
	{
		T result = parser.Require<T>();
		parser.MoveNext();
		return result;
	}

	public static bool TryConsume<T>(this CandidateInterpreter parser, [ReponseSingleton(false)] out T @event) where T : ClientSingleton
	{
		if (parser.Accept<T>(out @event))
		{
			parser.MoveNext();
			return true;
		}
		return false;
	}

	public static T Require<T>(this CandidateInterpreter parser) where T : ClientSingleton
	{
		if (!parser.Accept<T>(out var @event))
		{
			ClientSingleton current = parser.Current;
			if (current == null)
			{
				throw new ReaderSingleton(DicSingleton.gE3WbyDVW(0x270E0638 ^ 0x270E8B38) + typeof(T).Name + DicSingleton.gE3WbyDVW(-1398029315 ^ -1398059291));
			}
			throw new ReaderSingleton(current.Start, current.End, string.Format(DicSingleton.gE3WbyDVW(-1611872559 ^ -1611904021), typeof(T).Name, current.GetType().Name, current.Start));
		}
		return @event;
	}

	public static bool Accept<T>(this CandidateInterpreter parser, [ReponseSingleton(false)] out T @event) where T : ClientSingleton
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

	public static void SkipThisAndNestedEvents(this CandidateInterpreter parser)
	{
		int num = 2;
		int num2 = num;
		int num3 = default(int);
		ClientSingleton clientSingleton = default(ClientSingleton);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 4:
				num3 += clientSingleton.NestingIncrease;
				num2 = 3;
				continue;
			case 2:
				num3 = 0;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
				{
					num2 = 0;
				}
				continue;
			case 0:
				return;
			case 3:
				if (num3 <= 0)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			case 1:
				break;
			}
			clientSingleton = parser.Consume<ClientSingleton>();
			num2 = 4;
		}
	}

	[Obsolete("Please use Consume<T>() instead")]
	public static T Expect<T>(this CandidateInterpreter parser) where T : ClientSingleton
	{
		return parser.Consume<T>();
	}

	[Obsolete("Please use TryConsume<T>(out var evt) instead")]
	[return: RegSingleton]
	public static T? Allow<T>(this CandidateInterpreter parser) where T : ClientSingleton
	{
		if (!parser.TryConsume<T>(out var @event))
		{
			return null;
		}
		return @event;
	}

	[Obsolete("Please use Accept<T>(out var evt) instead")]
	[return: RegSingleton]
	public static T? Peek<T>(this CandidateInterpreter parser) where T : ClientSingleton
	{
		if (!parser.Accept<T>(out var @event))
		{
			return null;
		}
		return @event;
	}

	[Obsolete("Please use TryConsume<T>(out var evt) or Accept<T>(out var evt) instead")]
	public static bool Accept<T>(this CandidateInterpreter parser) where T : ClientSingleton
	{
		T @event;
		return parser.Accept<T>(out @event);
	}

	public static bool TryFindMappingEntry(this CandidateInterpreter parser, Func<BridgeSingleton, bool> selector, [ReponseSingleton(false)] out BridgeSingleton? key, [ReponseSingleton(false)] out ClientSingleton? value)
	{
		if (parser.TryConsume<FacadeSingleton>(out var _))
		{
			while (parser.Current != null)
			{
				ClientSingleton current = parser.Current;
				if (!(current is BridgeSingleton bridgeSingleton))
				{
					if (current is FacadeSingleton || current is ExporterSingleton)
					{
						parser.SkipThisAndNestedEvents();
					}
					else
					{
						parser.MoveNext();
					}
					continue;
				}
				bool num = selector(bridgeSingleton);
				parser.MoveNext();
				if (num)
				{
					value = parser.Current;
					key = bridgeSingleton;
					return true;
				}
				parser.SkipThisAndNestedEvents();
			}
		}
		key = null;
		value = null;
		return false;
	}

	internal static bool MapProducer()
	{
		return ConcatProducer == null;
	}

	internal static ReponseInterpreter NewProducer()
	{
		return ConcatProducer;
	}
}
