using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ClassInterpreter
{
	private readonly DescriptorAttribute objectInterpreter;

	[CompilerGenerated]
	private bool m_ConsumerInterpreter;

	[CompilerGenerated]
	private readonly bool propertyInterpreter;

	[CompilerGenerated]
	private readonly int m_ConfigurationInterpreter;

	private static ClassInterpreter SetProducer;

	public bool IsPossible
	{
		[CompilerGenerated]
		get
		{
			return m_ConsumerInterpreter;
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
				case 1:
					m_ConsumerInterpreter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
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

	public bool IsRequired
	{
		[CompilerGenerated]
		get
		{
			return propertyInterpreter;
		}
	}

	public int TokenNumber
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigurationInterpreter;
		}
	}

	public int Index => objectInterpreter.Index;

	public int Line => objectInterpreter.Line;

	public int LineOffset => objectInterpreter.LineOffset;

	public TestsInterpreter Mark => objectInterpreter.Mark();

	public void MarkAsImpossible()
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
				IsPossible = false;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public ClassInterpreter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			}
			objectInterpreter = new DescriptorAttribute();
			num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
			{
				num = 1;
			}
		}
	}

	public ClassInterpreter(bool isRequired, int tokenNumber, DescriptorAttribute cursor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 2;
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			case 4:
				m_ConfigurationInterpreter = tokenNumber;
				num = 3;
				break;
			case 2:
				IsPossible = true;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 != 0)
				{
					num = 0;
				}
				break;
			case 3:
				objectInterpreter = new DescriptorAttribute(cursor);
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
				{
					num = 1;
				}
				break;
			default:
				propertyInterpreter = isRequired;
				num = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
				{
					num = 4;
				}
				break;
			}
		}
	}

	internal static bool PushProducer()
	{
		return SetProducer == null;
	}

	internal static ClassInterpreter ValidateProducer()
	{
		return SetProducer;
	}
}
