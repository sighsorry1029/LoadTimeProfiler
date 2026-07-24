using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal abstract class MappingFilter
{
	[CompilerGenerated]
	private HelperReader m_SchemaFilter;

	[CompilerGenerated]
	private ValueFactory m_StructFilter;

	[CompilerGenerated]
	private QueueReader m_ClassFilter;

	[CompilerGenerated]
	private QueueReader objectFilter;

	internal static MappingFilter RunAuthentication;

	public HelperReader Anchor
	{
		[CompilerGenerated]
		get
		{
			return m_SchemaFilter;
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
					m_SchemaFilter = value;
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

	public ValueFactory Tag
	{
		[CompilerGenerated]
		get
		{
			return m_StructFilter;
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
				case 0:
					return;
				case 1:
					m_StructFilter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public QueueReader Start
	{
		[CompilerGenerated]
		get
		{
			return m_ClassFilter;
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
					m_ClassFilter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc == 0)
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

	public QueueReader End
	{
		[CompilerGenerated]
		get
		{
			return objectFilter;
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
					objectFilter = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
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

	public IEnumerable<MappingFilter> AllNodes
	{
		get
		{
			SingletonFactory level = new SingletonFactory(1000);
			return SafeAllNodes(level);
		}
	}

	public abstract SpecificationFilter NodeType { get; }

	public MappingFilter this[int index]
	{
		get
		{
			int num = 3;
			int num2 = num;
			ProcFilter procFilter = default(ProcFilter);
			while (true)
			{
				switch (num2)
				{
				default:
					throw new ArgumentException(string.Format(DicSingleton.gE3WbyDVW(0x3A437A88 ^ 0x3A430F9E), NodeType, index));
				case 1:
					return procFilter.Children[index];
				case 2:
					if (procFilter != null)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
						{
							num2 = 0;
						}
						break;
					}
					goto default;
				case 3:
					procFilter = this as ProcFilter;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
					{
						num2 = 1;
					}
					break;
				}
			}
		}
	}

	public MappingFilter this[MappingFilter key]
	{
		get
		{
			int num = 3;
			int num2 = num;
			ListenerFilter listenerFilter = default(ListenerFilter);
			while (true)
			{
				switch (num2)
				{
				case 1:
					throw new ArgumentException(string.Format(DicSingleton.gE3WbyDVW(0x44072FB7 ^ 0x44075A77), NodeType, key));
				default:
					return listenerFilter.Children[key];
				case 3:
					listenerFilter = this as ListenerFilter;
					num2 = 2;
					break;
				case 2:
					if (listenerFilter != null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 1;
				}
			}
		}
	}

	internal void Load(ListenerFactory yamlEvent, PolicyFilter state)
	{
		int num = 6;
		int num2 = num;
		HelperReader anchor = default(HelperReader);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 4:
				End = yamlEvent.End;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db != 0)
				{
					num2 = 0;
				}
				break;
			case 8:
				state.AddAnchor(this);
				num2 = 7;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb != 0)
				{
					num2 = 5;
				}
				break;
			case 2:
				Anchor = yamlEvent.Anchor;
				num2 = 8;
				break;
			case 3:
			case 7:
				Start = yamlEvent.Start;
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				if (anchor.IsEmpty)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 != 0)
					{
						num2 = 3;
					}
					break;
				}
				goto case 2;
			case 5:
				anchor = yamlEvent.Anchor;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 != 0)
				{
					num2 = 1;
				}
				break;
			case 6:
				Tag = yamlEvent.Tag;
				num2 = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc == 0)
				{
					num2 = 4;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static MappingFilter ParseNode(StubReader parser, PolicyFilter state)
	{
		int num = 7;
		TagFactory @event = default(TagFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return new DispatcherFilter(@event.Value);
				case 3:
					return new ProcFilter(parser, state);
				case 4:
				{
					if (!parser.Accept<QueueFactory>(out var _))
					{
						num2 = 5;
						break;
					}
					goto case 1;
				}
				case 1:
					return new ListenerFilter(parser, state);
				case 5:
					if (!parser.TryConsume<TagFactory>(out @event))
					{
						throw new ArgumentException(DicSingleton.gE3WbyDVW(0x1606DF07 ^ 0x1606AB15), DicSingleton.gE3WbyDVW(0x5A1F7167 ^ 0x5A1F27EB));
					}
					num2 = 2;
					break;
				case 6:
					return new RefFilter(parser, state);
				case 7:
				{
					if (!parser.Accept<ClassFactory>(out var _))
					{
						if (!parser.Accept<RefFactory>(out var _))
						{
							goto end_IL_0012;
						}
						goto case 3;
					}
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 != 0)
					{
						num2 = 1;
					}
					break;
				}
				case 2:
				{
					if (state.TryGetNode(@event.Value, out var node))
					{
						return node;
					}
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 != 0)
					{
						num2 = 0;
					}
					break;
				}
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 4;
		}
	}

	internal abstract void ResolveAliases(PolicyFilter state);

	internal void Save(ModelReader emitter, InfoFilter state)
	{
		int num = 1;
		int num2 = num;
		HelperReader anchor = default(HelperReader);
		while (true)
		{
			switch (num2)
			{
			case 4:
				return;
			case 3:
			case 5:
				Emit(emitter, state);
				num2 = 6;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
				{
					num2 = 2;
				}
				break;
			case 2:
				emitter.Emit(new TagFactory(Anchor));
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
				{
					num2 = 4;
				}
				break;
			case 1:
				anchor = Anchor;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
				{
					num2 = 0;
				}
				break;
			default:
				if (anchor.IsEmpty)
				{
					num2 = 3;
					break;
				}
				goto case 7;
			case 7:
				if (state.EmittedAnchors.Add(Anchor))
				{
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
					{
						num2 = 2;
					}
					break;
				}
				goto case 2;
			case 6:
				return;
			}
		}
	}

	internal abstract void Emit(ModelReader emitter, InfoFilter state);

	public abstract void Accept(ParamsFilter visitor);

	public override string ToString()
	{
		int num = 1;
		int num2 = num;
		SingletonFactory singletonFactory = default(SingletonFactory);
		while (true)
		{
			switch (num2)
			{
			default:
				return ToString(singletonFactory);
			case 1:
				singletonFactory = new SingletonFactory(1000);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal abstract string ToString(SingletonFactory level);

	internal abstract IEnumerable<MappingFilter> SafeAllNodes(SingletonFactory level);

	public static implicit operator MappingFilter(string value)
	{
		return new RefFilter(value);
	}

	public static implicit operator MappingFilter(string[] sequence)
	{
		return new ProcFilter(((IEnumerable<string>)sequence).Select((Func<string, MappingFilter>)([_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] (string i) => i)));
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	public static explicit operator string(MappingFilter node)
	{
		int num = 2;
		int num2 = num;
		RefFilter refFilter = default(RefFilter);
		while (true)
		{
			switch (num2)
			{
			default:
				throw new ArgumentException(string.Format(DicSingleton.gE3WbyDVW(0x69B67B3A ^ 0x69B60F54), node.NodeType));
			case 1:
				if (refFilter != null)
				{
					return refFilter.Value;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				refFilter = node as RefFilter;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	protected MappingFilter()
	{
		GetterIssuer.DeleteInitializer();
		m_ClassFilter = QueueReader.m_CollectionReader;
		objectFilter = QueueReader.m_CollectionReader;
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool VerifyAuthentication()
	{
		return RunAuthentication == null;
	}

	internal static MappingFilter PopAuthentication()
	{
		return RunAuthentication;
	}
}
