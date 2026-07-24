using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[Serializable]
internal struct Dispatcher
{
	[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(2)]
	public string m_List;

	[CompilerGenerated]
	private bool? m_Queue;

	[CompilerGenerated]
	private bool? collection;

	[CompilerGenerated]
	private bool? listener;

	[CompilerGenerated]
	private bool? m_Account;

	[CompilerGenerated]
	private bool? thread;

	[CompilerGenerated]
	private bool? m_Mapping;

	[CompilerGenerated]
	private bool? m_Struct;

	private static object InstantiateExpression;

	[FilterInvocation(Alias = "ExploreMap Bypass", ApplyNamingConventions = false)]
	public bool? ExploreMapBypass
	{
		[CompilerGenerated]
		readonly get
		{
			return m_Queue;
		}
		[CompilerGenerated]
		set
		{
			m_Queue = value;
		}
	}

	[FilterInvocation(Alias = "Damage Bypass", ApplyNamingConventions = false)]
	public bool? DamageBypass
	{
		[CompilerGenerated]
		readonly get
		{
			return collection;
		}
		[CompilerGenerated]
		set
		{
			collection = value;
		}
	}

	[FilterInvocation(Alias = "Flight Bypass", ApplyNamingConventions = false)]
	public bool? FlightBypass { get; set; }

	[FilterInvocation(Alias = "NoCostCheat Bypass", ApplyNamingConventions = false)]
	public bool? NoCostCheatBypass { get; set; }

	[FilterInvocation(Alias = "GhostMode Bypass", ApplyNamingConventions = false)]
	public bool? GhostModeBypass
	{
		[CompilerGenerated]
		readonly get
		{
			return listener;
		}
		[CompilerGenerated]
		set
		{
			listener = value;
		}
	}

	[FilterInvocation(Alias = "FreeFlyCam Bypass", ApplyNamingConventions = false)]
	public bool? FreeFlyCamBypass
	{
		[CompilerGenerated]
		readonly get
		{
			return m_Account;
		}
		[CompilerGenerated]
		set
		{
			m_Account = value;
		}
	}

	[FilterInvocation(Alias = "GodMode Bypass", ApplyNamingConventions = false)]
	public bool? GodModeBypass
	{
		[CompilerGenerated]
		readonly get
		{
			return thread;
		}
		[CompilerGenerated]
		set
		{
			thread = value;
		}
	}

	[FilterInvocation(Alias = "ConsoleUse Bypass", ApplyNamingConventions = false)]
	public bool? ConsoleUseBypass
	{
		[CompilerGenerated]
		readonly get
		{
			return m_Mapping;
		}
		[CompilerGenerated]
		set
		{
			m_Mapping = value;
		}
	}

	[FilterInvocation(Alias = "WeightLimit Bypass", ApplyNamingConventions = false)]
	public bool? WeightLimitBypass { get; set; }

	[FilterInvocation(Alias = "Health Bypass", ApplyNamingConventions = false)]
	public bool? HealthBypass
	{
		[CompilerGenerated]
		readonly get
		{
			return m_Struct;
		}
		[CompilerGenerated]
		set
		{
			m_Struct = value;
		}
	}

	public Dispatcher()
	{
		GetterIssuer.DeleteInitializer();
		m_List = null;
		ExploreMapBypass = null;
		DamageBypass = null;
		FlightBypass = null;
		NoCostCheatBypass = null;
		GhostModeBypass = null;
		FreeFlyCamBypass = null;
		GodModeBypass = null;
		ConsoleUseBypass = null;
		WeightLimitBypass = null;
		HealthBypass = null;
	}

	internal static bool LoginExpression()
	{
		return InstantiateExpression == null;
	}

	internal static object ConnectExpression()
	{
		return InstantiateExpression;
	}
}
