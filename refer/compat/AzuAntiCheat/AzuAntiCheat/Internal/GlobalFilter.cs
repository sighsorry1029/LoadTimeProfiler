using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal class GlobalFilter : IssuerFilter
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0<TContext>
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public UtilsPrototype value;

		private static object CalculateProcess;

		public _003C_003Ec__DisplayClass2_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
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
		internal bool _003CTraverseProperties_003Eb__0(StatusPrototype c)
		{
			return c.Accepts(value.Type);
		}

		internal static bool MoveProcess()
		{
			return CalculateProcess == null;
		}

		internal static object RevertProcess()
		{
			return CalculateProcess;
		}
	}

	private readonly IEnumerable<StatusPrototype> _MapFilter;

	public GlobalFilter(IEnumerable<StatusPrototype> converters, InstancePrototype typeDescriptor, OrderPrototype typeResolver, int maxRecursion, BroadcasterPrototype namingConvention)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(typeDescriptor, typeResolver, maxRecursion, namingConvention);
		_MapFilter = converters;
	}

	protected override void TraverseProperties<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TContext>(UtilsPrototype value, ParserPrototype<TContext> visitor, TContext context, Stack<ComparatorFilter> path)
	{
		_003C_003Ec__DisplayClass2_0<TContext> CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass2_0<TContext>();
		CS_0024_003C_003E8__locals5.value = value;
		if (!CS_0024_003C_003E8__locals5.value.Type.HasDefaultConstructor() && !_MapFilter.Any([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (StatusPrototype c) => c.Accepts(CS_0024_003C_003E8__locals5.value.Type)))
		{
			throw new InvalidOperationException(string.Format(DicSingleton.gE3WbyDVW(-166253478 ^ -166247244), CS_0024_003C_003E8__locals5.value.Type));
		}
		base.TraverseProperties(CS_0024_003C_003E8__locals5.value, visitor, context, path);
	}
}
