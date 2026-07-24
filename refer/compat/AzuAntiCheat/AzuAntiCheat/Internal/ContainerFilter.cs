using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class ContainerFilter : WorkerPrototype
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public Type clientFilter;

		private static _003C_003Ec__DisplayClass2_0 PublishAnnotation;

		public _003C_003Ec__DisplayClass2_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)]
		internal bool _003CYamlDotNet_002ESerialization_002EINodeDeserializer_002EDeserialize_003Eb__0(StatusPrototype c)
		{
			return c.Accepts(clientFilter);
		}

		internal static bool RegisterAnnotation()
		{
			return PublishAnnotation == null;
		}

		internal static _003C_003Ec__DisplayClass2_0 SetupAnnotation()
		{
			return PublishAnnotation;
		}
	}

	private readonly IEnumerable<StatusPrototype> iteratorFilter;

	public ContainerFilter(IEnumerable<StatusPrototype> converters)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		iteratorFilter = converters ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-220409977 ^ -220421159));
	}

	bool WorkerPrototype.Deserialize(StubReader parser, Type expectedType, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 1, 1, 2 })] Func<StubReader, Type, object> nestedObjectDeserializer, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] out object value)
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals3.clientFilter = expectedType;
		StatusPrototype statusPrototype = iteratorFilter.FirstOrDefault([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (StatusPrototype c) => c.Accepts(CS_0024_003C_003E8__locals3.clientFilter));
		if (statusPrototype == null)
		{
			value = null;
			return false;
		}
		value = statusPrototype.ReadYaml(parser, CS_0024_003C_003E8__locals3.clientFilter);
		return true;
	}
}
