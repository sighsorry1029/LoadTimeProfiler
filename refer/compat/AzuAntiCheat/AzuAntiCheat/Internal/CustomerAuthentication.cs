using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class CustomerAuthentication : WrapperSetter
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public IList _ResolverAuthentication;

		public Type _CandidateAuthentication;

		private static _003C_003Ec__DisplayClass3_0 TestMock;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool RunMock()
		{
			return TestMock == null;
		}

		internal static _003C_003Ec__DisplayClass3_0 VerifyMock()
		{
			return TestMock;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_1
	{
		public int _ExpressionAuthentication;

		public _003C_003Ec__DisplayClass3_0 m_ProductAuthentication;

		private static _003C_003Ec__DisplayClass3_1 PopMock;

		public _003C_003Ec__DisplayClass3_1()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
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
				case 0:
					return;
				case 1:
					m_ProductAuthentication._ResolverAuthentication[_ExpressionAuthentication] = ResolverInvocation.ChangeType(v, m_ProductAuthentication._CandidateAuthentication);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		internal static bool PostMock()
		{
			return PopMock == null;
		}

		internal static _003C_003Ec__DisplayClass3_1 CallMock()
		{
			return PopMock;
		}
	}

	private readonly PrinterSetter systemAuthentication;

	internal static CustomerAuthentication SelectMock;

	public CustomerAuthentication(PrinterSetter objectFactory)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			}
			systemAuthentication = objectFactory ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-381685266 ^ -381704378));
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c != 0)
			{
				num = 0;
			}
		}
	}

	public bool Deserialize(CandidateInterpreter parser, Type expectedType, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, out object? value)
	{
		bool canUpdate = true;
		Type implementedGenericInterface = MockInvocation.GetImplementedGenericInterface(expectedType, typeof(ICollection<>));
		Type type;
		IList list;
		if (implementedGenericInterface != null)
		{
			type = implementedGenericInterface.GetGenericArguments()[0];
			value = systemAuthentication.Create(expectedType);
			list = value as IList;
			if (list == null)
			{
				canUpdate = MockInvocation.GetImplementedGenericInterface(expectedType, typeof(IList<>)) != null;
				list = (IList)Activator.CreateInstance(typeof(MerchantAttribute<>).MakeGenericType(type), value);
			}
		}
		else
		{
			if (!typeof(IList).IsAssignableFrom(expectedType))
			{
				value = null;
				return false;
			}
			type = typeof(object);
			value = systemAuthentication.Create(expectedType);
			list = (IList)value;
		}
		DeserializeHelper(type, parser, nestedObjectDeserializer, list, canUpdate);
		return true;
	}

	internal static void DeserializeHelper(Type tItem, CandidateInterpreter parser, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, IList result, bool canUpdate)
	{
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
		_003C_003Ec__DisplayClass3_._ResolverAuthentication = result;
		_003C_003Ec__DisplayClass3_._CandidateAuthentication = tItem;
		parser.Consume<ExporterSingleton>();
		MessageSingleton @event;
		while (!parser.TryConsume<MessageSingleton>(out @event))
		{
			ClientSingleton current = parser.Current;
			object obj = nestedObjectDeserializer(parser, _003C_003Ec__DisplayClass3_._CandidateAuthentication);
			if (obj is ProcessSetter processSetter)
			{
				if (!canUpdate)
				{
					throw new CodeInterpreter(current?.Start ?? TestsInterpreter._InitializerInterpreter, current?.End ?? TestsInterpreter._InitializerInterpreter, DicSingleton.gE3WbyDVW(-1335677307 ^ -1335671703));
				}
				_003C_003Ec__DisplayClass3_1 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass3_1();
				CS_0024_003C_003E8__locals8.m_ProductAuthentication = _003C_003Ec__DisplayClass3_;
				CS_0024_003C_003E8__locals8._ExpressionAuthentication = CS_0024_003C_003E8__locals8.m_ProductAuthentication._ResolverAuthentication.Add(InterceptorSetter.IsValueType(CS_0024_003C_003E8__locals8.m_ProductAuthentication._CandidateAuthentication) ? Activator.CreateInstance(CS_0024_003C_003E8__locals8.m_ProductAuthentication._CandidateAuthentication) : null);
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
						case 0:
							return;
						case 1:
							CS_0024_003C_003E8__locals8.m_ProductAuthentication._ResolverAuthentication[CS_0024_003C_003E8__locals8._ExpressionAuthentication] = ResolverInvocation.ChangeType(v, CS_0024_003C_003E8__locals8.m_ProductAuthentication._CandidateAuthentication);
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
							{
								num2 = 0;
							}
							break;
						}
					}
				};
			}
			else
			{
				_003C_003Ec__DisplayClass3_._ResolverAuthentication.Add(ResolverInvocation.ChangeType(obj, _003C_003Ec__DisplayClass3_._CandidateAuthentication));
			}
		}
	}

	internal static bool ChangeMock()
	{
		return SelectMock == null;
	}

	internal static CustomerAuthentication CreateMock()
	{
		return SelectMock;
	}
}
