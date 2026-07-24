using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class SchemaSetter : ImporterSetter
{
	[CompilerGenerated]
	private object? m_StructSetter;

	[CompilerGenerated]
	private Type _ClassSetter;

	[CompilerGenerated]
	private Type m_ObjectSetter;

	[CompilerGenerated]
	private ConnectionInterpreter m_ConsumerSetter;

	internal static SchemaSetter ExcludeStatus;

	public object? Value
	{
		[CompilerGenerated]
		get
		{
			return m_StructSetter;
		}
		[CompilerGenerated]
		private set
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
					m_StructSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public Type Type
	{
		[CompilerGenerated]
		get
		{
			return _ClassSetter;
		}
		[CompilerGenerated]
		private set
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
					_ClassSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public Type StaticType
	{
		[CompilerGenerated]
		get
		{
			return m_ObjectSetter;
		}
		[CompilerGenerated]
		private set
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
					m_ObjectSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public ConnectionInterpreter ScalarStyle
	{
		[CompilerGenerated]
		get
		{
			return m_ConsumerSetter;
		}
		[CompilerGenerated]
		private set
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
					m_ConsumerSetter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public SchemaSetter(object? value, Type type, Type staticType)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(value, type, staticType, (ConnectionInterpreter)0);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public SchemaSetter(object? value, Type type, Type staticType, ConnectionInterpreter scalarStyle)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 4;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			case 2:
				ScalarStyle = scalarStyle;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 != 0)
				{
					num = 0;
				}
				break;
			case 4:
				Value = value;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
				{
					num = 0;
				}
				break;
			default:
				Type = type ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-379532028 ^ -379544680));
				num = 3;
				break;
			case 3:
				StaticType = staticType ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x3FCF6129 ^ 0x3FCF3D17));
				num = 2;
				break;
			}
		}
	}

	internal static bool InterruptStatus()
	{
		return ExcludeStatus == null;
	}

	internal static SchemaSetter DeleteStatus()
	{
		return ExcludeStatus;
	}
}
