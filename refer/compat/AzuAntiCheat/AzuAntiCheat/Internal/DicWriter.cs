using System;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal sealed class DicWriter : TagSetter
{
	private readonly List<ClientSingleton> paramsWriter;

	internal static DicWriter PatchOrder;

	public IList<ClientSingleton> Events => paramsWriter;

	void TagSetter.Read(CandidateInterpreter parser, Type expectedType, VisitorSetter nestedObjectDeserializer)
	{
		int num = 2;
		ClientSingleton current = default(ClientSingleton);
		int num3 = default(int);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					break;
				case 4:
					return;
				case 5:
				case 7:
					if (!parser.MoveNext())
					{
						num2 = 3;
						continue;
					}
					current = parser.Current;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
					{
						num2 = 8;
					}
					continue;
				case 8:
					paramsWriter.Add(current);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
					{
						num2 = 0;
					}
					continue;
				default:
					num3 += current.NestingIncrease;
					num2 = 6;
					continue;
				case 6:
					if (num3 <= 0)
					{
						return;
					}
					num2 = 5;
					continue;
				case 3:
					throw new InvalidOperationException(DicSingleton.gE3WbyDVW(0x2BB207E4 ^ 0x2BB258EA));
				case 2:
					paramsWriter.Clear();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			}
			num3 = 0;
			num = 7;
		}
	}

	void TagSetter.Write(MockInterpreter emitter, StubSetter nestedObjectSerializer)
	{
		foreach (ClientSingleton item in paramsWriter)
		{
			emitter.Emit(item);
		}
	}

	public DicWriter()
	{
		GetterIssuer.DeleteInitializer();
		paramsWriter = new List<ClientSingleton>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool AssetOrder()
	{
		return PatchOrder == null;
	}

	internal static DicWriter ListOrder()
	{
		return PatchOrder;
	}
}
