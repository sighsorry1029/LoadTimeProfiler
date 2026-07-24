using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal static class ThreadSetter
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0<TArgument, TComponent> where TArgument : notnull where TComponent : notnull
	{
		public Func<TComponent, TArgument> argumentBuilder;

		internal static object EnableStatus;

		public _003C_003Ec__DisplayClass1_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal TComponent _003CBuildComponentChain_003Eb__0(TComponent inner, Func<TArgument, TComponent> factory)
		{
			return factory(argumentBuilder(inner));
		}

		internal static bool SortStatus()
		{
			return EnableStatus == null;
		}

		internal static object InsertStatus()
		{
			return EnableStatus;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0<TArgument, TComponent> where TArgument : notnull where TComponent : notnull
	{
		public TArgument argument;

		internal static object FindStatus;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal TComponent _003CBuildComponentList_003Eb__0(Func<TArgument, TComponent> factory)
		{
			return factory(argument);
		}

		internal static bool VisitStatus()
		{
			return FindStatus == null;
		}

		internal static object OrderStatus()
		{
			return FindStatus;
		}
	}

	public static TComponent BuildComponentChain<TComponent>(this ProcessorSetter<TComponent, TComponent> registrations, TComponent innerComponent)
	{
		return registrations.InReverseOrder.Aggregate(innerComponent, (TComponent inner, Func<TComponent, TComponent> factory) => factory(inner));
	}

	public static TComponent BuildComponentChain<TArgument, TComponent>(this ProcessorSetter<TArgument, TComponent> registrations, TComponent innerComponent, Func<TComponent, TArgument> argumentBuilder)
	{
		_003C_003Ec__DisplayClass1_0<TArgument, TComponent> CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass1_0<TArgument, TComponent>();
		CS_0024_003C_003E8__locals2.argumentBuilder = argumentBuilder;
		return registrations.InReverseOrder.Aggregate(innerComponent, (TComponent inner, Func<TArgument, TComponent> factory) => factory(CS_0024_003C_003E8__locals2.argumentBuilder(inner)));
	}

	public static List<TComponent> BuildComponentList<TComponent>(this ProcessorSetter<MappingSetter, TComponent> registrations)
	{
		return registrations.Select((Func<MappingSetter, TComponent> factory) => factory(default(MappingSetter))).ToList();
	}

	public static List<TComponent> BuildComponentList<TArgument, TComponent>(this ProcessorSetter<TArgument, TComponent> registrations, TArgument argument)
	{
		_003C_003Ec__DisplayClass3_0<TArgument, TComponent> CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass3_0<TArgument, TComponent>();
		CS_0024_003C_003E8__locals2.argument = argument;
		return registrations.Select((Func<TArgument, TComponent> factory) => factory(CS_0024_003C_003E8__locals2.argument)).ToList();
	}
}
