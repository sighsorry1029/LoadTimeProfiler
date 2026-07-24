using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ServerAuthentication : WrapperSetter
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public IList importerAuthentication;

		private static _003C_003Ec__DisplayClass3_0 ResolveMock;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool DefineMock()
		{
			return ResolveMock == null;
		}

		internal static _003C_003Ec__DisplayClass3_0 IncludeMock()
		{
			return ResolveMock;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_1
	{
		public int creatorAuthentication;

		public _003C_003Ec__DisplayClass3_0 _PrinterAuthentication;

		internal static _003C_003Ec__DisplayClass3_1 CheckMock;

		public _003C_003Ec__DisplayClass3_1()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
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
					_PrinterAuthentication.importerAuthentication[creatorAuthentication] = v;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		internal static bool RateMock()
		{
			return CheckMock == null;
		}

		internal static _003C_003Ec__DisplayClass3_1 ResetMock()
		{
			return CheckMock;
		}
	}

	private readonly MapAuthentication m_AlgoAuthentication;

	internal static ServerAuthentication ConnectMock;

	public ServerAuthentication(MapAuthentication factory)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 0:
				return;
			case 1:
				m_AlgoAuthentication = factory ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1389846755 ^ -1389824641));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public bool Deserialize(CandidateInterpreter parser, Type expectedType, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, out object? value)
	{
		if (!m_AlgoAuthentication.IsList(expectedType))
		{
			value = null;
			return false;
		}
		DeserializeHelper(result: (IList)(value = m_AlgoAuthentication.Create(expectedType) as IList), tItem: m_AlgoAuthentication.GetValueType(expectedType), parser: parser, nestedObjectDeserializer: nestedObjectDeserializer, factory: m_AlgoAuthentication);
		return true;
	}

	internal static void DeserializeHelper(Type tItem, CandidateInterpreter parser, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, IList result, PrinterSetter factory)
	{
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
		_003C_003Ec__DisplayClass3_.importerAuthentication = result;
		parser.Consume<ExporterSingleton>();
		MessageSingleton @event;
		while (!parser.TryConsume<MessageSingleton>(out @event))
		{
			_ = parser.Current;
			object obj = nestedObjectDeserializer(parser, tItem);
			if (obj is ProcessSetter processSetter)
			{
				_003C_003Ec__DisplayClass3_1 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass3_1();
				CS_0024_003C_003E8__locals5._PrinterAuthentication = _003C_003Ec__DisplayClass3_;
				CS_0024_003C_003E8__locals5.creatorAuthentication = CS_0024_003C_003E8__locals5._PrinterAuthentication.importerAuthentication.Add(factory.CreatePrimitive(tItem));
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
							CS_0024_003C_003E8__locals5._PrinterAuthentication.importerAuthentication[CS_0024_003C_003E8__locals5.creatorAuthentication] = v;
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
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
				_003C_003Ec__DisplayClass3_.importerAuthentication.Add(obj);
			}
		}
	}

	internal static bool StartMock()
	{
		return ConnectMock == null;
	}

	internal static ServerAuthentication RemoveMock()
	{
		return ConnectMock;
	}
}
