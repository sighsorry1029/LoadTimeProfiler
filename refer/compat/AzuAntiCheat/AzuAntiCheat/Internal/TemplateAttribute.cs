using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class TemplateAttribute
{
	private class WatcherAttribute : OrderAttribute
	{
		private readonly HashSet<VisitorAttribute> customerAttribute;

		private readonly Dictionary<ProductAttribute, bool> m_SystemAttribute;

		private static WatcherAttribute PushToken;

		public void AssignAnchors(TemplateAttribute document)
		{
			int num = 5;
			int num2 = num;
			Dictionary<ProductAttribute, bool>.Enumerator enumerator = default(Dictionary<ProductAttribute, bool>.Enumerator);
			Random random = default(Random);
			KeyValuePair<ProductAttribute, bool> current = default(KeyValuePair<ProductAttribute, bool>);
			VisitorAttribute anchor = default(VisitorAttribute);
			VisitorAttribute visitorAttribute = default(VisitorAttribute);
			while (true)
			{
				switch (num2)
				{
				case 5:
					customerAttribute.Clear();
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec == 0)
					{
						num2 = 4;
					}
					break;
				case 1:
					return;
				case 4:
					m_SystemAttribute.Clear();
					num2 = 6;
					break;
				case 2:
					enumerator = m_SystemAttribute.GetEnumerator();
					num2 = 3;
					break;
				case 6:
					document.Accept(this);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
					{
						num2 = 0;
					}
					break;
				default:
					random = new Random();
					num2 = 2;
					break;
				case 3:
					try
					{
						while (true)
						{
							int num3;
							if (!enumerator.MoveNext())
							{
								num3 = 4;
								goto IL_00e0;
							}
							goto IL_023f;
							IL_00e0:
							while (true)
							{
								int num4;
								switch (num3)
								{
								case 4:
									return;
								case 5:
									if (current.Value)
									{
										num3 = 2;
										continue;
									}
									break;
								case 7:
									if (!customerAttribute.Contains(current.Key.Anchor))
									{
										num4 = 10;
										goto IL_00dc;
									}
									goto case 8;
								case 13:
									if (anchor.IsEmpty)
									{
										num3 = 7;
										if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f != 0)
										{
											num3 = 8;
										}
										continue;
									}
									goto case 7;
								case 1:
									break;
								case 9:
									current.Key.Anchor = visitorAttribute;
									num3 = 1;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
									{
										num3 = 0;
									}
									continue;
								case 10:
									visitorAttribute = current.Key.Anchor;
									num4 = 3;
									goto IL_00dc;
								default:
									customerAttribute.Add(visitorAttribute);
									num3 = 9;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba != 0)
									{
										num3 = 8;
									}
									continue;
								case 8:
								case 11:
									visitorAttribute = new VisitorAttribute(random.Next().ToString(CultureInfo.InvariantCulture));
									num3 = 12;
									continue;
								case 6:
									goto IL_023f;
								case 2:
									anchor = current.Key.Anchor;
									num3 = 13;
									continue;
								case 12:
									{
										if (!customerAttribute.Contains(visitorAttribute))
										{
											num3 = 0;
											if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
											{
												num3 = 0;
											}
											continue;
										}
										goto case 8;
									}
									IL_00dc:
									num3 = num4;
									continue;
								}
								break;
							}
							continue;
							IL_023f:
							current = enumerator.Current;
							num3 = 5;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
							{
								num3 = 2;
							}
							goto IL_00e0;
						}
					}
					finally
					{
						((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						int num5 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
						{
							num5 = 0;
						}
						switch (num5)
						{
						case 0:
							break;
						}
					}
				}
			}
		}

		private bool VisitNodeAndFindDuplicates(ProductAttribute node)
		{
			int num = 3;
			bool value = default(bool);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					default:
						return false;
					case 5:
						if (!value)
						{
							num2 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b == 0)
							{
								num2 = 4;
							}
							break;
						}
						goto case 1;
					case 4:
						m_SystemAttribute[node] = true;
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 != 0)
						{
							num2 = 0;
						}
						break;
					case 3:
						if (!m_SystemAttribute.TryGetValue(node, out value))
						{
							goto end_IL_0012;
						}
						goto case 5;
					case 1:
						return !value;
					case 2:
						m_SystemAttribute.Add(node, value: false);
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
						{
							num2 = 0;
						}
						break;
					}
					continue;
					end_IL_0012:
					break;
				}
				num = 2;
			}
		}

		public override void Visit(UtilsAttribute scalar)
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
					VisitNodeAndFindDuplicates(scalar);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		public override void Visit(ResolverAttribute mapping)
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					if (!VisitNodeAndFindDuplicates(mapping))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb != 0)
						{
							num2 = 0;
						}
						break;
					}
					return;
				case 2:
					return;
				default:
					base.Visit(mapping);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
					{
						num2 = 2;
					}
					break;
				}
			}
		}

		public override void Visit(ParserAttribute sequence)
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 2:
					base.Visit(sequence);
					num2 = 3;
					break;
				case 0:
					return;
				case 3:
					return;
				case 1:
					if (VisitNodeAndFindDuplicates(sequence))
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 == 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 2;
				}
			}
		}

		public WatcherAttribute()
		{
			GetterIssuer.DeleteInitializer();
			customerAttribute = new HashSet<VisitorAttribute>();
			m_SystemAttribute = new Dictionary<ProductAttribute, bool>();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool ValidateToken()
		{
			return PushToken == null;
		}

		internal static WatcherAttribute EnableToken()
		{
			return PushToken;
		}
	}

	[CompilerGenerated]
	private ProductAttribute m_PredicateAttribute;

	private static TemplateAttribute LogoutToken;

	public ProductAttribute RootNode
	{
		[CompilerGenerated]
		get
		{
			return m_PredicateAttribute;
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
					m_PredicateAttribute = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public IEnumerable<ProductAttribute> AllNodes => RootNode.AllNodes;

	public TemplateAttribute(ProductAttribute rootNode)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 != 0)
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
				RootNode = rootNode;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public TemplateAttribute(string rootNode)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
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
			RootNode = new UtilsAttribute(rootNode);
			num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af != 0)
			{
				num = 1;
			}
		}
	}

	internal TemplateAttribute(CandidateInterpreter parser)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 3;
		IdentifierAttribute identifierAttribute = default(IdentifierAttribute);
		while (true)
		{
			switch (num)
			{
			case 10:
				if (!(RootNode is MethodAttribute))
				{
					num = 6;
					continue;
				}
				goto default;
			case 9:
				parser.Consume<TestsSingleton>();
				num = 5;
				continue;
			default:
				throw new ReaderSingleton(DicSingleton.gE3WbyDVW(--708144185 ^ 0x2A351E13));
			case 5:
			case 6:
			{
				if (!parser.TryConsume<TaskSingleton>(out var _))
				{
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
					{
						num = 1;
					}
					continue;
				}
				break;
			}
			case 3:
				identifierAttribute = new IdentifierAttribute();
				num = 9;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba != 0)
				{
					num = 0;
				}
				continue;
			case 1:
			case 11:
				RootNode = ProductAttribute.ParseNode(parser, identifierAttribute);
				num = 10;
				continue;
			case 2:
				if (RootNode != null)
				{
					num = 8;
					continue;
				}
				goto case 4;
			case 8:
				return;
			case 4:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(0x4E8C8248 ^ 0x4E8CF034));
			case 7:
				break;
			}
			identifierAttribute.ResolveAliases();
			num = 2;
		}
	}

	private void AssignAnchors()
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
				new WatcherAttribute().AssignAnchors(this);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal void Save(MockInterpreter emitter, bool assignAnchors = true)
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 2:
				AssignAnchors();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
				{
					num2 = 1;
				}
				break;
			case 3:
				if (assignAnchors)
				{
					num2 = 2;
					break;
				}
				goto case 1;
			case 1:
				emitter.Emit(new TestsSingleton());
				num2 = 4;
				break;
			case 5:
				emitter.Emit(new TaskSingleton(isImplicit: false));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
				{
					num2 = 0;
				}
				break;
			case 4:
				RootNode.Save(emitter, new RulesAttribute());
				num2 = 5;
				break;
			case 0:
				return;
			}
		}
	}

	public void Accept(CodeAttribute visitor)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool CountToken()
	{
		return LogoutToken == null;
	}

	internal static TemplateAttribute SetToken()
	{
		return LogoutToken;
	}
}
