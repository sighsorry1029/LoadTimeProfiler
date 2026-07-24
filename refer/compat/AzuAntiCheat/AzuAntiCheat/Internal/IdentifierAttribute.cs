using System;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal class IdentifierAttribute
{
	private readonly IDictionary<VisitorAttribute, ProductAttribute> m_TokenAttribute;

	private readonly IList<ProductAttribute> m_CallbackAttribute;

	internal static IdentifierAttribute PostToken;

	public void AddAnchor(ProductAttribute node)
	{
		int num = 6;
		int num2 = num;
		VisitorAttribute anchor = default(VisitorAttribute);
		while (true)
		{
			switch (num2)
			{
			case 3:
				m_TokenAttribute[node.Anchor] = node;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 == 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(-1735703950 ^ -1735709540));
			case 6:
				anchor = node.Anchor;
				num2 = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
				{
					num2 = 3;
				}
				break;
			case 1:
				return;
			default:
				m_TokenAttribute.Add(node.Anchor, node);
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
				{
					num2 = 2;
				}
				break;
			case 4:
				return;
			case 5:
				if (!anchor.IsEmpty)
				{
					if (!m_TokenAttribute.ContainsKey(node.Anchor))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 != 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 3;
				}
				num2 = 2;
				break;
			}
		}
	}

	public ProductAttribute GetNode(VisitorAttribute anchor, TestsInterpreter start, TestsInterpreter end)
	{
		int num = 1;
		int num2 = num;
		ProductAttribute value = default(ProductAttribute);
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (!m_TokenAttribute.TryGetValue(anchor, out value))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			case 2:
				return value;
			default:
				throw new ProcessorAttribute(in start, in end, string.Format(DicSingleton.gE3WbyDVW(0x5A8BEE ^ 0x5AE4A8), anchor));
			}
		}
	}

	public bool TryGetNode(VisitorAttribute anchor, [StubSingleton(true)] out ProductAttribute? node)
	{
		return m_TokenAttribute.TryGetValue(anchor, out node);
	}

	public void AddNodeWithUnresolvedAliases(ProductAttribute node)
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
				m_CallbackAttribute.Add(node);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public void ResolveAliases()
	{
		foreach (ProductAttribute item in m_CallbackAttribute)
		{
			item.ResolveAliases(this);
		}
	}

	public IdentifierAttribute()
	{
		GetterIssuer.DeleteInitializer();
		m_TokenAttribute = new Dictionary<VisitorAttribute, ProductAttribute>();
		m_CallbackAttribute = new List<ProductAttribute>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool CallToken()
	{
		return PostToken == null;
	}

	internal static IdentifierAttribute ConcatToken()
	{
		return PostToken;
	}
}
