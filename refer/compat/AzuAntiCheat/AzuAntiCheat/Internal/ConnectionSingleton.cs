using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
internal sealed class ConnectionSingleton : Attribute
{
	[CompilerGenerated]
	private readonly bool m_AnnotationSingleton;

	[CompilerGenerated]
	private readonly string[] m_ProcessSingleton;

	private static ConnectionSingleton ComputeGetter;

	public bool ReturnValue
	{
		[CompilerGenerated]
		get
		{
			return m_AnnotationSingleton;
		}
	}

	public string[] Members
	{
		[CompilerGenerated]
		get
		{
			return m_ProcessSingleton;
		}
	}

	public ConnectionSingleton(bool returnValue, string member)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		m_AnnotationSingleton = returnValue;
		m_ProcessSingleton = new string[1] { member };
	}

	public ConnectionSingleton(bool returnValue, params string[] members)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				m_ProcessSingleton = members;
				num = 2;
				break;
			case 2:
				return;
			case 1:
				m_AnnotationSingleton = returnValue;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	internal static bool DisableGetter()
	{
		return ComputeGetter == null;
	}

	internal static ConnectionSingleton QueryGetter()
	{
		return ComputeGetter;
	}
}
