using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal abstract class MethodAuthentication
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public IList templateAuthentication;

		private static _003C_003Ec__DisplayClass0_0 MoveImporter;

		public _003C_003Ec__DisplayClass0_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool RevertImporter()
		{
			return MoveImporter == null;
		}

		internal static _003C_003Ec__DisplayClass0_0 InvokeMock()
		{
			return MoveImporter;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_1
	{
		public int _PredicateAuthentication;

		public _003C_003Ec__DisplayClass0_0 m_WatcherAuthentication;

		internal static _003C_003Ec__DisplayClass0_1 PublishMock;

		public _003C_003Ec__DisplayClass0_1()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal void _003CDeserializeHelper_003Eb__0(object? v)
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
					m_WatcherAuthentication.templateAuthentication[_PredicateAuthentication] = v;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		internal static bool RegisterMock()
		{
			return PublishMock == null;
		}

		internal static _003C_003Ec__DisplayClass0_1 SetupMock()
		{
			return PublishMock;
		}
	}

	private static MethodAuthentication RestartImporter;

	protected static void DeserializeHelper(Type tItem, CandidateInterpreter parser, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, IList result, bool canUpdate, PrinterSetter objectFactory)
	{
		_003C_003Ec__DisplayClass0_0 _003C_003Ec__DisplayClass0_ = new _003C_003Ec__DisplayClass0_0();
		_003C_003Ec__DisplayClass0_.templateAuthentication = result;
		parser.Consume<ExporterSingleton>();
		MessageSingleton @event;
		while (!parser.TryConsume<MessageSingleton>(out @event))
		{
			ClientSingleton current = parser.Current;
			object obj = nestedObjectDeserializer(parser, tItem);
			if (obj is ProcessSetter processSetter)
			{
				if (!canUpdate)
				{
					throw new CodeInterpreter(current?.Start ?? TestsInterpreter._InitializerInterpreter, current?.End ?? TestsInterpreter._InitializerInterpreter, DicSingleton.gE3WbyDVW(-1385030784 ^ -1385008788));
				}
				_003C_003Ec__DisplayClass0_1 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass0_1();
				CS_0024_003C_003E8__locals5.m_WatcherAuthentication = _003C_003Ec__DisplayClass0_;
				CS_0024_003C_003E8__locals5._PredicateAuthentication = CS_0024_003C_003E8__locals5.m_WatcherAuthentication.templateAuthentication.Add(objectFactory.CreatePrimitive(tItem));
				processSetter.ValueAvailable += delegate(object? v)
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
							CS_0024_003C_003E8__locals5.m_WatcherAuthentication.templateAuthentication[CS_0024_003C_003E8__locals5._PredicateAuthentication] = v;
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c == 0)
							{
								num2 = 0;
							}
							break;
						case 0:
							return;
						}
					}
				};
			}
			else
			{
				_003C_003Ec__DisplayClass0_.templateAuthentication.Add(obj);
			}
		}
	}

	protected MethodAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool GetImporter()
	{
		return RestartImporter == null;
	}

	internal static MethodAuthentication CalculateImporter()
	{
		return RestartImporter;
	}
}
