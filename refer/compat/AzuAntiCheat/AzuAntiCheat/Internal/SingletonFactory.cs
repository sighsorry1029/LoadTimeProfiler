using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class SingletonFactory
{
	private int issuerFactory;

	[CompilerGenerated]
	private readonly int m_FieldFactory;

	private static SingletonFactory SearchError;

	public int Maximum
	{
		[CompilerGenerated]
		get
		{
			return m_FieldFactory;
		}
	}

	public SingletonFactory(int maximum)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 != 0)
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
			m_FieldFactory = maximum;
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
			{
				num = 1;
			}
		}
	}

	public void Increment()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				throw new AccountReader(DicSingleton.gE3WbyDVW(0x567B7B7F ^ 0x567BF6FB));
			case 1:
				return;
			case 2:
				if (TryIncrement())
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto default;
			}
		}
	}

	public bool TryIncrement()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (issuerFactory < Maximum)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
					{
						num2 = 0;
					}
					break;
				}
				return false;
			case 2:
				return true;
			default:
				issuerFactory++;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	public void Decrement()
	{
		int num = 2;
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
				throw new InvalidOperationException(DicSingleton.gE3WbyDVW(-65056140 ^ -65019976));
			case 2:
				if (issuerFactory != 0)
				{
					issuerFactory--;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 != 0)
					{
						num2 = 0;
					}
				}
				else
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 == 0)
					{
						num2 = 1;
					}
				}
				break;
			}
		}
	}

	internal static bool StopError()
	{
		return SearchError == null;
	}

	internal static SingletonFactory ExcludeError()
	{
		return SearchError;
	}
}
