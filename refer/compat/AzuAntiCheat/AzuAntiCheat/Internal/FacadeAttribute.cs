using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace AzuAnticheat.Internal;

internal class FacadeAttribute : IEnumerable<TemplateAttribute>, IEnumerable
{
	private readonly IList<TemplateAttribute> m_EventAttribute;

	private static FacadeAttribute CancelToken;

	public IList<TemplateAttribute> Documents => m_EventAttribute;

	public FacadeAttribute()
	{
		GetterIssuer.DeleteInitializer();
		m_EventAttribute = new List<TemplateAttribute>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public FacadeAttribute(params TemplateAttribute[] documents)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector((IEnumerable<TemplateAttribute>)documents);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public FacadeAttribute(IEnumerable<TemplateAttribute> documents)
	{
		GetterIssuer.DeleteInitializer();
		m_EventAttribute = new List<TemplateAttribute>();
		base._002Ector();
		foreach (TemplateAttribute document in documents)
		{
			m_EventAttribute.Add(document);
		}
	}

	public void Add(TemplateAttribute document)
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
				m_EventAttribute.Add(document);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public void Load(TextReader input)
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
				Load(new ExporterInterpreter(input));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public void Load(CandidateInterpreter parser)
	{
		int num = 4;
		int num2 = num;
		TemplateAttribute item = default(TemplateAttribute);
		while (true)
		{
			switch (num2)
			{
			case 2:
				item = new TemplateAttribute(parser);
				num2 = 5;
				break;
			default:
			{
				if (parser.TryConsume<WrapperSingleton>(out var _))
				{
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
					{
						num2 = 4;
					}
					break;
				}
				goto case 2;
			}
			case 5:
				m_EventAttribute.Add(item);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
				{
					num2 = 0;
				}
				break;
			case 6:
				return;
			case 3:
				parser.Consume<ServerSingleton>();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b == 0)
				{
					num2 = 0;
				}
				break;
			case 4:
				m_EventAttribute.Clear();
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 == 0)
				{
					num2 = 3;
				}
				break;
			}
		}
	}

	public void Save(TextWriter output)
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
				Save(output, assignAnchors: true);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public void Save(TextWriter output, bool assignAnchors)
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
				Save(new CollectionAttribute(output), assignAnchors);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public void Save(MockInterpreter emitter, bool assignAnchors)
	{
		emitter.Emit(new ServerSingleton());
		foreach (TemplateAttribute item in m_EventAttribute)
		{
			item.Save(emitter, assignAnchors);
		}
		emitter.Emit(new WrapperSingleton());
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
			case 1:
				visitor.Visit(this);
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

	public IEnumerator<TemplateAttribute> GetEnumerator()
	{
		return m_EventAttribute.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	internal static bool ReflectToken()
	{
		return CancelToken == null;
	}

	internal static FacadeAttribute CollectToken()
	{
		return CancelToken;
	}
}
