using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal static class ErrorPrototype
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0<TArgument, TComponent>
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public Func<TComponent, TArgument> argumentBuilder;

		private static object PushRole;

		public _003C_003Ec__DisplayClass1_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
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
		internal TComponent _003CBuildComponentChain_003Eb__0(TComponent inner, Func<TArgument, TComponent> factory)
		{
			return factory(argumentBuilder(inner));
		}

		internal static bool ValidateRole()
		{
			return PushRole == null;
		}

		internal static object SortRole()
		{
			return PushRole;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0<TArgument, TComponent>
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public TArgument argument;

		internal static object OrderRole;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a == 0)
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
		internal TComponent _003CBuildComponentList_003Eb__0(Func<TArgument, TComponent> factory)
		{
			return factory(argument);
		}

		internal static bool UpdateRole()
		{
			return OrderRole == null;
		}

		internal static object SearchRole()
		{
			return OrderRole;
		}
	}

	public static TComponent BuildComponentChain<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TComponent>(this MerchantPrototype<TComponent, TComponent> registrations, TComponent innerComponent)
	{
		return registrations.InReverseOrder.Aggregate(innerComponent, [_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (TComponent inner, Func<TComponent, TComponent> factory) => factory(inner));
	}

	public static TComponent BuildComponentChain<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TArgument, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TComponent>(this MerchantPrototype<TArgument, TComponent> registrations, TComponent innerComponent, Func<TComponent, TArgument> argumentBuilder)
	{
		_003C_003Ec__DisplayClass1_0<TArgument, TComponent> CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass1_0<TArgument, TComponent>();
		CS_0024_003C_003E8__locals2.argumentBuilder = argumentBuilder;
		return registrations.InReverseOrder.Aggregate(innerComponent, [_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (TComponent inner, Func<TArgument, TComponent> factory) => factory(CS_0024_003C_003E8__locals2.argumentBuilder(inner)));
	}

	public static List<TComponent> BuildComponentList<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TComponent>(this MerchantPrototype<RegPrototype, TComponent> registrations)
	{
		return registrations.Select([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (Func<RegPrototype, TComponent> factory) => factory(default(RegPrototype))).ToList();
	}

	public static List<TComponent> BuildComponentList<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TArgument, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TComponent>(this MerchantPrototype<TArgument, TComponent> registrations, TArgument argument)
	{
		_003C_003Ec__DisplayClass3_0<TArgument, TComponent> CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass3_0<TArgument, TComponent>();
		CS_0024_003C_003E8__locals2.argument = argument;
		return registrations.Select([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (Func<TArgument, TComponent> factory) => factory(CS_0024_003C_003E8__locals2.argument)).ToList();
	}
}
