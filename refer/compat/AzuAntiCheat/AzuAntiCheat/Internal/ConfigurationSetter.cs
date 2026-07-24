using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ConfigurationSetter : RegSetter
{
	private readonly RegSetter _SpecificationSetter;

	[CompilerGenerated]
	private string m_RefSetter;

	[CompilerGenerated]
	private int observerSetter;

	internal static ConfigurationSetter FillStatus;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return m_RefSetter;
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
					m_RefSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 != 0)
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

	public Type Type => _SpecificationSetter.Type;

	public Type? TypeOverride
	{
		get
		{
			return _SpecificationSetter.TypeOverride;
		}
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
					_SpecificationSetter.TypeOverride = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public int Order
	{
		[CompilerGenerated]
		get
		{
			return observerSetter;
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
					observerSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
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

	public ConnectionInterpreter ScalarStyle
	{
		get
		{
			return _SpecificationSetter.ScalarStyle;
		}
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
					_SpecificationSetter.ScalarStyle = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
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

	public bool CanWrite => _SpecificationSetter.CanWrite;

	public ConfigurationSetter(RegSetter baseDescriptor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 0:
				return;
			case 2:
				Name = baseDescriptor.Name;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 != 0)
				{
					num = 0;
				}
				break;
			case 1:
				_SpecificationSetter = baseDescriptor;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
				{
					num = 2;
				}
				break;
			}
		}
	}

	public void Write(object target, object? value)
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
				_SpecificationSetter.Write(target, value);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public T? GetCustomAttribute<T>() where T : Attribute
	{
		return _SpecificationSetter.GetCustomAttribute<T>();
	}

	public ImporterSetter Read(object target)
	{
		return _SpecificationSetter.Read(target);
	}

	internal static bool FlushStatus()
	{
		return FillStatus == null;
	}

	internal static ConfigurationSetter DestroyStatus()
	{
		return FillStatus;
	}
}
