using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class GlobalInvocation : AnnotationSetter
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public AnnotationSetter itemInvocation;

		public MethodInvocation contextInvocation;

		public Func<CandidateInterpreter, Type, object?> m_MapperInvocation;

		internal static _003C_003Ec__DisplayClass4_0 TestProxy;

		public _003C_003Ec__DisplayClass4_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal object? _003CDeserializeValue_003Eb__0(CandidateInterpreter r, Type t)
		{
			return itemInvocation.DeserializeValue(r, t, contextInvocation, itemInvocation);
		}

		internal static bool RunProxy()
		{
			return TestProxy == null;
		}

		internal static _003C_003Ec__DisplayClass4_0 VerifyProxy()
		{
			return TestProxy;
		}
	}

	private readonly IList<WrapperSetter> _MapInvocation;

	private readonly IList<ServerSetter> m_HelperInvocation;

	private readonly TokenInvocation _ExceptionInvocation;

	private static GlobalInvocation SelectProxy;

	public GlobalInvocation(IList<WrapperSetter> deserializers, IList<ServerSetter> typeResolvers, TokenInvocation typeConverter)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		_MapInvocation = deserializers ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x548F02D9 ^ 0x548F6387));
		m_HelperInvocation = typeResolvers ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1123846595 ^ -1123870911));
		_ExceptionInvocation = typeConverter ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1735703950 ^ -1735714860));
	}

	public object? DeserializeValue(CandidateInterpreter parser, Type expectedType, MethodInvocation state, AnnotationSetter nestedObjectDeserializer)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals5.itemInvocation = nestedObjectDeserializer;
		CS_0024_003C_003E8__locals5.contextInvocation = state;
		parser.Accept<OrderSingleton>(out var @event);
		Type typeFromEvent = GetTypeFromEvent(@event, expectedType);
		try
		{
			foreach (WrapperSetter item in _MapInvocation)
			{
				if (item.Deserialize(parser, typeFromEvent, (CandidateInterpreter r, Type t) => CS_0024_003C_003E8__locals5.itemInvocation.DeserializeValue(r, t, CS_0024_003C_003E8__locals5.contextInvocation, CS_0024_003C_003E8__locals5.itemInvocation), out object value))
				{
					return _ExceptionInvocation.ChangeType(value, expectedType);
				}
			}
		}
		catch (ReaderSingleton)
		{
			throw;
		}
		catch (Exception innerException)
		{
			throw new ReaderSingleton(@event?.Start ?? TestsInterpreter._InitializerInterpreter, @event?.End ?? TestsInterpreter._InitializerInterpreter, DicSingleton.gE3WbyDVW(--1509395337 ^ 0x59F7EA13), innerException);
		}
		throw new ReaderSingleton(@event?.Start ?? TestsInterpreter._InitializerInterpreter, @event?.End ?? TestsInterpreter._InitializerInterpreter, DicSingleton.gE3WbyDVW(0x940D407 ^ 0x940B5D9) + expectedType.AssemblyQualifiedName);
	}

	private Type GetTypeFromEvent(OrderSingleton? nodeEvent, Type currentType)
	{
		using (IEnumerator<ServerSetter> enumerator = m_HelperInvocation.GetEnumerator())
		{
			while (enumerator.MoveNext() && !enumerator.Current.Resolve(nodeEvent, ref currentType))
			{
			}
		}
		return currentType;
	}

	internal static bool ChangeProxy()
	{
		return SelectProxy == null;
	}

	internal static GlobalInvocation CreateProxy()
	{
		return SelectProxy;
	}
}
