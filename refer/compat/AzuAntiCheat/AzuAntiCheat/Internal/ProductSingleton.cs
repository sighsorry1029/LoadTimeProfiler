using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ProductSingleton : SystemSingleton
{
	[CompilerGenerated]
	private readonly PrototypeSingleton registrySingleton;

	internal static ProductSingleton FillStub;

	public PrototypeSingleton Version
	{
		[CompilerGenerated]
		get
		{
			return registrySingleton;
		}
	}

	public ProductSingleton(PrototypeSingleton version)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(version, TestsInterpreter._InitializerInterpreter, TestsInterpreter._InitializerInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ProductSingleton(PrototypeSingleton version, TestsInterpreter start, TestsInterpreter end)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(in start, in end);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
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
			registrySingleton = version;
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
			{
				num = 0;
			}
		}
	}

	public override bool Equals(object? obj)
	{
		int num = 3;
		int num2 = num;
		ProductSingleton productSingleton = default(ProductSingleton);
		while (true)
		{
			switch (num2)
			{
			case 3:
				productSingleton = obj as ProductSingleton;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 == 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				if (productSingleton == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
					{
						num2 = 1;
					}
					break;
				}
				goto default;
			default:
				return Version.Equals(productSingleton.Version);
			case 1:
				return false;
			}
		}
	}

	public override int GetHashCode()
	{
		return Version.GetHashCode();
	}

	internal static bool FlushStub()
	{
		return FillStub == null;
	}

	internal static ProductSingleton DestroyStub()
	{
		return FillStub;
	}
}
