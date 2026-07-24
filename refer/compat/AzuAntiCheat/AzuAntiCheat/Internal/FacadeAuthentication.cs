using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace AzuAnticheat.Internal;

internal sealed class FacadeAuthentication : WrapperSetter
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public RegSetter _ClientAuthentication;

		public object m_RecordAuthentication;

		public FacadeAuthentication m_ServiceAuthentication;

		internal static _003C_003Ec__DisplayClass6_0 FindMock;

		public _003C_003Ec__DisplayClass6_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal void _003CDeserialize_003Eb__0(object? v)
		{
			int num = 2;
			int num2 = num;
			object value = default(object);
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 1:
					_ClientAuthentication.Write(m_RecordAuthentication, value);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
					{
						num2 = 0;
					}
					break;
				case 2:
					value = m_ServiceAuthentication._IteratorAuthentication.ChangeType(v, _ClientAuthentication.Type);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		internal static bool VisitMock()
		{
			return FindMock == null;
		}

		internal static _003C_003Ec__DisplayClass6_0 OrderMock()
		{
			return FindMock;
		}
	}

	private readonly PrinterSetter m_EventAuthentication;

	private readonly AdvisorSetter m_InstanceAuthentication;

	private readonly bool orderAuthentication;

	private readonly bool _ContainerAuthentication;

	private readonly TokenInvocation _IteratorAuthentication;

	private static FacadeAuthentication EnableMock;

	public FacadeAuthentication(PrinterSetter objectFactory, AdvisorSetter typeDescriptor, bool ignoreUnmatched, bool duplicateKeyChecking, TokenInvocation typeConverter)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 2;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
		{
			num = 2;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 1:
				_ContainerAuthentication = duplicateKeyChecking;
				num = 5;
				break;
			case 3:
				orderAuthentication = ignoreUnmatched;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			case 2:
				m_EventAuthentication = objectFactory ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-2103041941 ^ -2103019837));
				num = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e != 0)
				{
					num = 1;
				}
				break;
			case 4:
				m_InstanceAuthentication = typeDescriptor ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x540450D2 ^ 0x5404378C));
				num = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 != 0)
				{
					num = 3;
				}
				break;
			case 5:
				_IteratorAuthentication = typeConverter ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1891833728 ^ -1891844826));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public bool Deserialize(CandidateInterpreter parser, Type expectedType, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, out object? value)
	{
		if (!parser.TryConsume<FacadeSingleton>(out var _))
		{
			value = null;
			return false;
		}
		Type type = Nullable.GetUnderlyingType(expectedType) ?? expectedType;
		value = m_EventAuthentication.Create(type);
		m_EventAuthentication.ExecuteOnDeserializing(value);
		HashSet<string> hashSet = new HashSet<string>(StringComparer.Ordinal);
		ParamSingleton event2;
		while (!parser.TryConsume<ParamSingleton>(out event2))
		{
			BridgeSingleton bridgeSingleton = parser.Consume<BridgeSingleton>();
			if (_ContainerAuthentication && !hashSet.Add(bridgeSingleton.Value))
			{
				throw new ReaderSingleton(bridgeSingleton.Start, bridgeSingleton.End, DicSingleton.gE3WbyDVW(-598551743 ^ -598573667) + bridgeSingleton.Value);
			}
			try
			{
				_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass6_0();
				CS_0024_003C_003E8__locals11.m_ServiceAuthentication = this;
				CS_0024_003C_003E8__locals11._ClientAuthentication = m_InstanceAuthentication.GetProperty(type, null, bridgeSingleton.Value, orderAuthentication);
				if (CS_0024_003C_003E8__locals11._ClientAuthentication == null)
				{
					parser.SkipThisAndNestedEvents();
					continue;
				}
				object obj = nestedObjectDeserializer(parser, CS_0024_003C_003E8__locals11._ClientAuthentication.Type);
				if (obj is ProcessSetter processSetter)
				{
					CS_0024_003C_003E8__locals11.m_RecordAuthentication = value;
					processSetter.ValueAvailable += delegate(object? v)
					{
						int num = 2;
						int num2 = num;
						object value3 = default(object);
						while (true)
						{
							switch (num2)
							{
							default:
								return;
							case 1:
								CS_0024_003C_003E8__locals11._ClientAuthentication.Write(CS_0024_003C_003E8__locals11.m_RecordAuthentication, value3);
								num2 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
								{
									num2 = 0;
								}
								break;
							case 2:
								value3 = CS_0024_003C_003E8__locals11.m_ServiceAuthentication._IteratorAuthentication.ChangeType(v, CS_0024_003C_003E8__locals11._ClientAuthentication.Type);
								num2 = 1;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
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
					object value2 = _IteratorAuthentication.ChangeType(obj, CS_0024_003C_003E8__locals11._ClientAuthentication.Type);
					CS_0024_003C_003E8__locals11._ClientAuthentication.Write(value, value2);
				}
			}
			catch (SerializationException ex)
			{
				throw new ReaderSingleton(bridgeSingleton.Start, bridgeSingleton.End, ex.Message);
			}
			catch (ReaderSingleton)
			{
				throw;
			}
			catch (Exception innerException)
			{
				throw new ReaderSingleton(bridgeSingleton.Start, bridgeSingleton.End, DicSingleton.gE3WbyDVW(--708144185 ^ 0x2A350DA3), innerException);
			}
		}
		m_EventAuthentication.ExecuteOnDeserialized(value);
		return true;
	}

	internal static bool SortMock()
	{
		return EnableMock == null;
	}

	internal static FacadeAuthentication InsertMock()
	{
		return EnableMock;
	}
}
