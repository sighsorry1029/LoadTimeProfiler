using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal abstract class ProductAttribute
{
	[CompilerGenerated]
	private VisitorAttribute registryAttribute;

	[CompilerGenerated]
	private RoleSingleton stateAttribute;

	[CompilerGenerated]
	private TestsInterpreter valueAttribute;

	[CompilerGenerated]
	private TestsInterpreter decoratorAttribute;

	internal static ProductAttribute SearchToken;

	public VisitorAttribute Anchor
	{
		[CompilerGenerated]
		get
		{
			return registryAttribute;
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
					registryAttribute = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 != 0)
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

	public RoleSingleton Tag
	{
		[CompilerGenerated]
		get
		{
			return stateAttribute;
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
					stateAttribute = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
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

	public TestsInterpreter Start
	{
		[CompilerGenerated]
		get
		{
			return valueAttribute;
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
					valueAttribute = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c != 0)
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

	public TestsInterpreter End
	{
		[CompilerGenerated]
		get
		{
			return decoratorAttribute;
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
					decoratorAttribute = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
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

	public IEnumerable<ProductAttribute> AllNodes
	{
		get
		{
			ProxyInterpreter level = new ProxyInterpreter(1000);
			return SafeAllNodes(level);
		}
	}

	public abstract ActivityTemplateFactoryBuilderWriterStates NodeType { get; }

	public ProductAttribute this[int index]
	{
		get
		{
			int num = 2;
			int num2 = num;
			ParserAttribute parserAttribute = default(ParserAttribute);
			while (true)
			{
				switch (num2)
				{
				case 1:
					if (parserAttribute != null)
					{
						num2 = 3;
						break;
					}
					goto default;
				default:
					throw new ArgumentException(string.Format(DicSingleton.gE3WbyDVW(0x120E76C ^ 0x120927A), NodeType, index));
				case 3:
					return parserAttribute.Children[index];
				case 2:
					parserAttribute = this as ParserAttribute;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
					{
						num2 = 1;
					}
					break;
				}
			}
		}
	}

	public ProductAttribute this[ProductAttribute key]
	{
		get
		{
			int num = 2;
			int num2 = num;
			ResolverAttribute resolverAttribute = default(ResolverAttribute);
			while (true)
			{
				switch (num2)
				{
				case 3:
					throw new ArgumentException(string.Format(DicSingleton.gE3WbyDVW(0x3FCF6129 ^ 0x3FCF14E9), NodeType, key));
				default:
					return resolverAttribute.Children[key];
				case 2:
					resolverAttribute = this as ResolverAttribute;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c == 0)
					{
						num2 = 1;
					}
					break;
				case 1:
					if (resolverAttribute != null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac != 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 3;
				}
			}
		}
	}

	internal void Load(OrderSingleton yamlEvent, IdentifierAttribute state)
	{
		int num = 3;
		VisitorAttribute anchor = default(VisitorAttribute);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 4:
				case 6:
					Start = yamlEvent.Start;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 == 0)
					{
						num2 = 1;
					}
					continue;
				case 2:
					anchor = yamlEvent.Anchor;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 == 0)
					{
						num2 = 7;
					}
					continue;
				case 0:
					return;
				case 1:
					End = yamlEvent.End;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
					{
						num2 = 0;
					}
					continue;
				case 8:
					break;
				case 7:
					if (anchor.IsEmpty)
					{
						num2 = 4;
						continue;
					}
					goto case 5;
				case 5:
					Anchor = yamlEvent.Anchor;
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 != 0)
					{
						num2 = 4;
					}
					continue;
				case 3:
					Tag = yamlEvent.Tag;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e != 0)
					{
						num2 = 2;
					}
					continue;
				}
				break;
			}
			state.AddAnchor(this);
			num = 6;
		}
	}

	internal static ProductAttribute ParseNode(CandidateInterpreter parser, IdentifierAttribute state)
	{
		int num = 7;
		int num2 = num;
		StateSingleton event4 = default(StateSingleton);
		ProductAttribute node = default(ProductAttribute);
		while (true)
		{
			switch (num2)
			{
			case 3:
				return new MethodAttribute(event4.Value);
			case 9:
				return node;
			case 2:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(0x44072FB7 ^ 0x44075BA5), DicSingleton.gE3WbyDVW(-228218718 ^ -228196818));
			case 4:
				if (state.TryGetNode(event4.Value, out node))
				{
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
					{
						num2 = 6;
					}
					break;
				}
				goto case 3;
			case 5:
				return new ParserAttribute(parser, state);
			case 8:
				return new ResolverAttribute(parser, state);
			case 1:
				if (!parser.TryConsume<StateSingleton>(out event4))
				{
					num2 = 2;
					break;
				}
				goto case 4;
			default:
				return new UtilsAttribute(parser, state);
			case 6:
			{
				if (!parser.Accept<ExporterSingleton>(out var _))
				{
					if (!parser.Accept<FacadeSingleton>(out var _))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
						{
							num2 = 1;
						}
						break;
					}
					goto case 8;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 != 0)
				{
					num2 = 5;
				}
				break;
			}
			case 7:
			{
				if (!parser.Accept<BridgeSingleton>(out var _))
				{
					num2 = 6;
					break;
				}
				goto default;
			}
			}
		}
	}

	internal abstract void ResolveAliases(IdentifierAttribute state);

	internal void Save(MockInterpreter emitter, RulesAttribute state)
	{
		int num = 5;
		VisitorAttribute anchor = default(VisitorAttribute);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 4:
					if (anchor.IsEmpty)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 == 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto default;
				case 5:
					anchor = Anchor;
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
					{
						num2 = 4;
					}
					continue;
				case 2:
					return;
				case 6:
					emitter.Emit(new StateSingleton(Anchor));
					num2 = 3;
					continue;
				case 3:
					return;
				case 1:
					break;
				default:
					if (!state.EmittedAnchors.Add(Anchor))
					{
						num2 = 6;
						continue;
					}
					break;
				}
				break;
			}
			Emit(emitter, state);
			num = 2;
		}
	}

	internal abstract void Emit(MockInterpreter emitter, RulesAttribute state);

	public abstract void Accept(CodeAttribute visitor);

	public override string ToString()
	{
		int num = 1;
		int num2 = num;
		ProxyInterpreter proxyInterpreter = default(ProxyInterpreter);
		while (true)
		{
			switch (num2)
			{
			case 1:
				proxyInterpreter = new ProxyInterpreter(1000);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return ToString(proxyInterpreter);
			}
		}
	}

	internal abstract string ToString(ProxyInterpreter level);

	internal abstract IEnumerable<ProductAttribute> SafeAllNodes(ProxyInterpreter level);

	public static implicit operator ProductAttribute(string value)
	{
		return new UtilsAttribute(value);
	}

	public static implicit operator ProductAttribute(string[] sequence)
	{
		return new ParserAttribute(((IEnumerable<string>)sequence).Select((Func<string, ProductAttribute>)((string i) => i)));
	}

	public static explicit operator string?(ProductAttribute node)
	{
		int num = 3;
		int num2 = num;
		UtilsAttribute utilsAttribute = default(UtilsAttribute);
		while (true)
		{
			switch (num2)
			{
			case 2:
				if (utilsAttribute != null)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto default;
			default:
				throw new ArgumentException(string.Format(DicSingleton.gE3WbyDVW(-1977574774 ^ -1977553180), node.NodeType));
			case 1:
				return utilsAttribute.Value;
			case 3:
				utilsAttribute = node as UtilsAttribute;
				num2 = 2;
				break;
			}
		}
	}

	protected ProductAttribute()
	{
		GetterIssuer.DeleteInitializer();
		valueAttribute = TestsInterpreter._InitializerInterpreter;
		decoratorAttribute = TestsInterpreter._InitializerInterpreter;
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool StopToken()
	{
		return SearchToken == null;
	}

	internal static ProductAttribute ExcludeToken()
	{
		return SearchToken;
	}
}
