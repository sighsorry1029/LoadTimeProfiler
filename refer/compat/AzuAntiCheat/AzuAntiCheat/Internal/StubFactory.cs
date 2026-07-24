using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class StubFactory : MappingFactory
{
	[CompilerGenerated]
	private readonly string policyFactory;

	internal static StubFactory SetupObject;

	public string Value
	{
		[CompilerGenerated]
		get
		{
			return policyFactory;
		}
	}

	public bool IsInline { get; }

	internal override SchemaCompareFilterSetting Type => (SchemaCompareFilterSetting)11;

	public StubFactory(string value, bool isInline)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(value, isInline, QueueReader.m_CollectionReader, QueueReader.m_CollectionReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public StubFactory(string value, bool isInline, QueueReader start, QueueReader end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(start, end);
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 == 0)
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
			case 1:
				policyFactory = value;
				num = 2;
				break;
			case 2:
				_StrategyFactory = isInline;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public override void Accept(DispatcherFactory visitor)
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
				visitor.Visit(this);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public override string ToString()
	{
		int num = 1;
		int num2 = num;
		string text;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (IsInline)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 != 0)
					{
						num2 = 0;
					}
					continue;
				}
				goto case 2;
			case 2:
				text = DicSingleton.gE3WbyDVW(-823738529 ^ -823782329);
				break;
			default:
				text = DicSingleton.gE3WbyDVW(-475093377 ^ -475132583);
				break;
			}
			break;
		}
		return text + DicSingleton.gE3WbyDVW(-1064640644 ^ -1064668086) + Value + DicSingleton.gE3WbyDVW(--798431903 ^ 0x2F9772C1);
	}

	internal static bool SelectObject()
	{
		return SetupObject == null;
	}

	internal static StubFactory ChangeObject()
	{
		return SetupObject;
	}
}
