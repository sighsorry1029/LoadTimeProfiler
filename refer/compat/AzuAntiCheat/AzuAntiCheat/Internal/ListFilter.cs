using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal class ListFilter
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	private class CollectionFilter : FilterReader
	{
		private readonly HashSet<HelperReader> _ManagerFilter;

		private readonly Dictionary<MappingFilter, bool> _TokenizerFilter;

		private static CollectionFilter MoveAnnotation;

		public void AssignAnchors(ListFilter document)
		{
			int num = 5;
			int num2 = num;
			Random random = default(Random);
			Dictionary<MappingFilter, bool>.Enumerator enumerator = default(Dictionary<MappingFilter, bool>.Enumerator);
			HelperReader helperReader = default(HelperReader);
			KeyValuePair<MappingFilter, bool> current = default(KeyValuePair<MappingFilter, bool>);
			HelperReader anchor = default(HelperReader);
			while (true)
			{
				switch (num2)
				{
				default:
					random = new Random();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
					{
						num2 = 1;
					}
					break;
				case 1:
					enumerator = _TokenizerFilter.GetEnumerator();
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
					{
						num2 = 3;
					}
					break;
				case 6:
					try
					{
						while (true)
						{
							IL_015a:
							int num3;
							if (!enumerator.MoveNext())
							{
								num3 = 6;
								goto IL_0094;
							}
							goto IL_011b;
							IL_0094:
							while (true)
							{
								switch (num3)
								{
								case 14:
									break;
								case 1:
								case 7:
									_ManagerFilter.Add(helperReader);
									num3 = 1;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af != 0)
									{
										num3 = 5;
									}
									continue;
								case 8:
								case 13:
									goto IL_015a;
								case 5:
									current.Key.Anchor = helperReader;
									num3 = 13;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba != 0)
									{
										num3 = 1;
									}
									continue;
								case 2:
									if (_ManagerFilter.Contains(helperReader))
									{
										num3 = 15;
										if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
										{
											num3 = 11;
										}
										continue;
									}
									goto case 1;
								case 4:
									helperReader = current.Key.Anchor;
									num3 = 1;
									if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
									{
										num3 = 1;
									}
									continue;
								case 10:
									anchor = current.Key.Anchor;
									num3 = 11;
									continue;
								case 11:
									if (!anchor.IsEmpty)
									{
										num3 = 0;
										if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
										{
											num3 = 0;
										}
										continue;
									}
									goto case 9;
								case 9:
								case 12:
								case 15:
									helperReader = new HelperReader(random.Next().ToString(CultureInfo.InvariantCulture));
									num3 = 2;
									continue;
								default:
									if (_ManagerFilter.Contains(current.Key.Anchor))
									{
										num3 = 12;
										continue;
									}
									goto case 4;
								case 3:
									if (!current.Value)
									{
										num3 = 8;
										if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
										{
											num3 = 7;
										}
										continue;
									}
									goto case 10;
								case 6:
									return;
								}
								break;
							}
							goto IL_011b;
							IL_011b:
							current = enumerator.Current;
							int num4 = 3;
							num3 = num4;
							goto IL_0094;
						}
					}
					finally
					{
						((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						int num5 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
						{
							num5 = 0;
						}
						switch (num5)
						{
						case 0:
							break;
						}
					}
				case 5:
					_ManagerFilter.Clear();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 != 0)
					{
						num2 = 4;
					}
					break;
				case 4:
					_TokenizerFilter.Clear();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
					{
						num2 = 2;
					}
					break;
				case 2:
					document.Accept(this);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
					{
						num2 = 0;
					}
					break;
				case 3:
					return;
				}
			}
		}

		private bool VisitNodeAndFindDuplicates(MappingFilter node)
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
					case 3:
						if (_TokenizerFilter.TryGetValue(node, out value))
						{
							num2 = 2;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
							{
								num2 = 0;
							}
							continue;
						}
						goto end_IL_0012;
					case 2:
						if (!value)
						{
							num2 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d != 0)
							{
								num2 = 1;
							}
							continue;
						}
						break;
					case 4:
						return false;
					case 1:
						_TokenizerFilter[node] = true;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					return !value;
					continue;
					end_IL_0012:
					break;
				}
				_TokenizerFilter.Add(node, value: false);
				num = 4;
			}
		}

		public override void Visit(RefFilter scalar)
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
					VisitNodeAndFindDuplicates(scalar);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		public override void Visit(ListenerFilter mapping)
		{
			int num = 2;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 3:
					base.Visit(mapping);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				case 1:
					return;
				case 2:
					if (VisitNodeAndFindDuplicates(mapping))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
						{
							num2 = 1;
						}
						break;
					}
					goto case 3;
				}
			}
		}

		public override void Visit(ProcFilter sequence)
		{
			int num = 2;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 2:
					if (!VisitNodeAndFindDuplicates(sequence))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
						{
							num2 = 0;
						}
						break;
					}
					return;
				case 0:
					return;
				case 1:
					base.Visit(sequence);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		public CollectionFilter()
		{
			GetterIssuer.DeleteInitializer();
			_ManagerFilter = new HashSet<HelperReader>();
			_TokenizerFilter = new Dictionary<MappingFilter, bool>();
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

		internal static bool RevertAnnotation()
		{
			return MoveAnnotation == null;
		}

		internal static CollectionFilter InvokeAuthentication()
		{
			return MoveAnnotation;
		}
	}

	[CompilerGenerated]
	private MappingFilter m_QueueFilter;

	private static ListFilter RestartAnnotation;

	public MappingFilter RootNode
	{
		[CompilerGenerated]
		get
		{
			return m_QueueFilter;
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
					m_QueueFilter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public IEnumerable<MappingFilter> AllNodes => RootNode.AllNodes;

	public ListFilter(MappingFilter rootNode)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 == 0)
		{
			num = 0;
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public ListFilter(string rootNode)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 != 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 1:
				RootNode = new RefFilter(rootNode);
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal ListFilter(StubReader parser)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 6;
		PolicyFilter policyFilter = default(PolicyFilter);
		while (true)
		{
			switch (num)
			{
			case 4:
				if (RootNode is DispatcherFilter)
				{
					num = 2;
					continue;
				}
				goto case 3;
			case 2:
				throw new TestsFactory(DicSingleton.gE3WbyDVW(0x47C77AB8 ^ 0x47C70892));
			case 3:
			{
				if (parser.TryConsume<ProcessorFactory>(out var _))
				{
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 != 0)
					{
						num = 0;
					}
					continue;
				}
				break;
			}
			case 8:
				throw new ArgumentException(DicSingleton.gE3WbyDVW(-316028230 ^ -316032826));
			case 7:
				if (RootNode != null)
				{
					return;
				}
				num = 8;
				continue;
			case 5:
				parser.Consume<DicFactory>();
				num = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 != 0)
				{
					num = 3;
				}
				continue;
			case 6:
				policyFilter = new PolicyFilter();
				num = 5;
				continue;
			default:
				policyFilter.ResolveAliases();
				num = 7;
				continue;
			case 1:
				break;
			}
			RootNode = MappingFilter.ParseNode(parser, policyFilter);
			num = 4;
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
				new CollectionFilter().AssignAnchors(this);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal void Save(ModelReader emitter, bool assignAnchors = true)
	{
		int num = 2;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					AssignAnchors();
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 == 0)
					{
						num2 = 2;
					}
					continue;
				case 2:
					if (!assignAnchors)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto default;
				case 6:
					RootNode.Save(emitter, new InfoFilter());
					num2 = 3;
					continue;
				case 5:
					return;
				case 1:
				case 4:
					emitter.Emit(new DicFactory());
					num2 = 6;
					continue;
				case 3:
					break;
				}
				break;
			}
			emitter.Emit(new ProcessorFactory(isImplicit: false));
			num = 5;
		}
	}

	public void Accept(ParamsFilter visitor)
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
				visitor.Visit(this);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool GetAnnotation()
	{
		return RestartAnnotation == null;
	}

	internal static ListFilter CalculateAnnotation()
	{
		return RestartAnnotation;
	}
}
