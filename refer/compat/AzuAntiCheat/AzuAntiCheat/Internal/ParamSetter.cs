using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class ParamSetter : TestsSetter
{
	[CompilerGenerated]
	private VisitorAttribute _FacadeSetter;

	[CompilerGenerated]
	private RoleSingleton eventSetter;

	internal static ParamSetter CheckParameter;

	public VisitorAttribute Anchor
	{
		[CompilerGenerated]
		get
		{
			return _FacadeSetter;
		}
		[CompilerGenerated]
		set
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
					_FacadeSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public RoleSingleton Tag
	{
		[CompilerGenerated]
		get
		{
			return eventSetter;
		}
		[CompilerGenerated]
		set
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 1:
					eventSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}
	}

	protected ParamSetter(ImporterSetter source)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(source);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool RateParameter()
	{
		return CheckParameter == null;
	}

	internal static ParamSetter ResetParameter()
	{
		return CheckParameter;
	}
}
