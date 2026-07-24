using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class RecordSetter : ParamSetter
{
	[CompilerGenerated]
	private bool _ServiceSetter;

	[CompilerGenerated]
	private Level bridgeSetter;

	private static RecordSetter CollectParameter;

	public bool IsImplicit
	{
		[CompilerGenerated]
		get
		{
			return _ServiceSetter;
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
					_ServiceSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public Level Style
	{
		[CompilerGenerated]
		get
		{
			return bridgeSetter;
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
					bridgeSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public RecordSetter(ImporterSetter source)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(source);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ManageParameter()
	{
		return CollectParameter == null;
	}

	internal static RecordSetter ForgotParameter()
	{
		return CollectParameter;
	}
}
