using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal class PolicyFilter
{
	private readonly IDictionary<HelperReader, MappingFilter> _StrategyFilter;

	private readonly IList<MappingFilter> m_ProcessorFilter;

	private static PolicyFilter AwakeAnnotation;

	public void AddAnchor(MappingFilter node)
	{
		int num = 4;
		int num2 = num;
		HelperReader anchor = default(HelperReader);
		while (true)
		{
			switch (num2)
			{
			default:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(0xDA293E6 ^ 0xDA2FD08));
			case 3:
				if (!anchor.IsEmpty)
				{
					if (!_StrategyFilter.ContainsKey(node.Anchor))
					{
						num2 = 6;
						break;
					}
					goto case 5;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				return;
			case 6:
				_StrategyFilter.Add(node.Anchor, node);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
				{
					num2 = 1;
				}
				break;
			case 5:
				_StrategyFilter[node.Anchor] = node;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f != 0)
				{
					num2 = 2;
				}
				break;
			case 1:
				return;
			case 4:
				anchor = node.Anchor;
				num2 = 3;
				break;
			}
		}
	}

	public MappingFilter GetNode(HelperReader anchor, QueueReader start, QueueReader end)
	{
		int num = 1;
		int num2 = num;
		MappingFilter value = default(MappingFilter);
		while (true)
		{
			switch (num2)
			{
			default:
				return value;
			case 1:
				if (!_StrategyFilter.TryGetValue(anchor, out value))
				{
					throw new MapperReader(start, end, string.Format(DicSingleton.gE3WbyDVW(0x7A125A0E ^ 0x7A123548), anchor));
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	public bool TryGetNode(HelperReader anchor, [PoolBase(true)] out MappingFilter node)
	{
		return _StrategyFilter.TryGetValue(anchor, out node);
	}

	public void AddNodeWithUnresolvedAliases(MappingFilter node)
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
				m_ProcessorFilter.Add(node);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public void ResolveAliases()
	{
		foreach (MappingFilter item in m_ProcessorFilter)
		{
			item.ResolveAliases(this);
		}
	}

	public PolicyFilter()
	{
		GetterIssuer.DeleteInitializer();
		_StrategyFilter = new Dictionary<HelperReader, MappingFilter>();
		m_ProcessorFilter = new List<MappingFilter>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool InstantiateAnnotation()
	{
		return AwakeAnnotation == null;
	}

	internal static PolicyFilter LoginAnnotation()
	{
		return AwakeAnnotation;
	}
}
