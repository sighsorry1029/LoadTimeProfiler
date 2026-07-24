using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class RecordFilter : WorkerPrototype
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1, 2 })]
		public Func<StubReader, Type, object> _BridgeFilter;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public StubReader m_ParameterFilter;

		private static _003C_003Ec__DisplayClass2_0 TestAnnotation;

		public _003C_003Ec__DisplayClass2_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
		internal object _003CDeserialize_003Eb__0(Type type)
		{
			return _BridgeFilter(m_ParameterFilter, type);
		}

		internal static bool RunAnnotation()
		{
			return TestAnnotation == null;
		}

		internal static _003C_003Ec__DisplayClass2_0 VerifyAnnotation()
		{
			return TestAnnotation;
		}
	}

	private readonly InitializerPrototype serviceFilter;

	internal static RecordFilter SelectAnnotation;

	public RecordFilter(InitializerPrototype objectFactory)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
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
			serviceFilter = objectFactory;
			num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc != 0)
			{
				num = 1;
			}
		}
	}

	public bool Deserialize(StubReader parser, Type expectedType, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 1, 1, 2 })] Func<StubReader, Type, object> nestedObjectDeserializer, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] out object value)
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals5._BridgeFilter = nestedObjectDeserializer;
		CS_0024_003C_003E8__locals5.m_ParameterFilter = parser;
		if (typeof(RecordPrototype).IsAssignableFrom(expectedType))
		{
			RecordPrototype recordPrototype = (RecordPrototype)serviceFilter.Create(expectedType);
			recordPrototype.Read(CS_0024_003C_003E8__locals5.m_ParameterFilter, expectedType, [return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] (Type type) => CS_0024_003C_003E8__locals5._BridgeFilter(CS_0024_003C_003E8__locals5.m_ParameterFilter, type));
			value = recordPrototype;
			return true;
		}
		value = null;
		return false;
	}

	internal static bool ChangeAnnotation()
	{
		return SelectAnnotation == null;
	}

	internal static RecordFilter CreateAnnotation()
	{
		return SelectAnnotation;
	}
}
