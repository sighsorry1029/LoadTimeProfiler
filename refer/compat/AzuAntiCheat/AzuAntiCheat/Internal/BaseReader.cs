using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal class BaseReader : IEnumerable<ListFilter>, IEnumerable
{
	private readonly IList<ListFilter> _PrototypeReader;

	private static BaseReader EnableAuthentication;

	public IList<ListFilter> Documents => _PrototypeReader;

	public BaseReader()
	{
		GetterIssuer.DeleteInitializer();
		_PrototypeReader = new List<ListFilter>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public BaseReader(params ListFilter[] documents)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector((IEnumerable<ListFilter>)documents);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public BaseReader(IEnumerable<ListFilter> documents)
	{
		GetterIssuer.DeleteInitializer();
		_PrototypeReader = new List<ListFilter>();
		base._002Ector();
		foreach (ListFilter document in documents)
		{
			_PrototypeReader.Add(document);
		}
	}

	public void Add(ListFilter document)
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
				_PrototypeReader.Add(document);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
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
			case 0:
				return;
			case 1:
				Load(new PublisherFactory(input));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public void Load(StubReader parser)
	{
		int num = 4;
		int num2 = num;
		ListFilter item = default(ListFilter);
		while (true)
		{
			switch (num2)
			{
			case 4:
				_PrototypeReader.Clear();
				num2 = 3;
				break;
			case 1:
				_PrototypeReader.Add(item);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
				{
					num2 = 0;
				}
				break;
			case 3:
				parser.Consume<PublisherSetter>();
				num2 = 6;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
				{
					num2 = 6;
				}
				break;
			case 2:
				item = new ListFilter(parser);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 != 0)
				{
					num2 = 1;
				}
				break;
			case 5:
				return;
			default:
			{
				if (parser.TryConsume<RoleSetter>(out var _))
				{
					num2 = 5;
					break;
				}
				goto case 2;
			}
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
			case 1:
				Save(output, assignAnchors: true);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
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
			case 1:
				Save(new MethodReader(output), assignAnchors);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public void Save(ModelReader emitter, bool assignAnchors)
	{
		emitter.Emit(new PublisherSetter());
		foreach (ListFilter item in _PrototypeReader)
		{
			item.Save(emitter, assignAnchors);
		}
		emitter.Emit(new RoleSetter());
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public IEnumerator<ListFilter> GetEnumerator()
	{
		return _PrototypeReader.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	internal static bool SortAuthentication()
	{
		return EnableAuthentication == null;
	}

	internal static BaseReader InsertAuthentication()
	{
		return EnableAuthentication;
	}
}
