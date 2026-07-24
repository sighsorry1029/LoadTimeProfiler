using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[Obsolete("Use YamlVisitorBase")]
internal abstract class InterceptorReader : ParamsFilter
{
	internal static InterceptorReader FindAuthentication;

	protected virtual void Visit(BaseReader stream)
	{
	}

	protected virtual void Visited(BaseReader stream)
	{
	}

	protected virtual void Visit(ListFilter document)
	{
	}

	protected virtual void Visited(ListFilter document)
	{
	}

	protected virtual void Visit(RefFilter scalar)
	{
	}

	protected virtual void Visited(RefFilter scalar)
	{
	}

	protected virtual void Visit(ProcFilter sequence)
	{
	}

	protected virtual void Visited(ProcFilter sequence)
	{
	}

	protected virtual void Visit(ListenerFilter mapping)
	{
	}

	protected virtual void Visited(ListenerFilter mapping)
	{
	}

	protected virtual void VisitChildren(BaseReader stream)
	{
		foreach (ListFilter document in stream.Documents)
		{
			document.Accept(this);
		}
	}

	protected virtual void VisitChildren(ListFilter document)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				document.RootNode.Accept(this);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 2:
				if (document.RootNode == null)
				{
					return;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	protected virtual void VisitChildren(ProcFilter sequence)
	{
		foreach (MappingFilter child in sequence.Children)
		{
			child.Accept(this);
		}
	}

	protected virtual void VisitChildren(ListenerFilter mapping)
	{
		foreach (KeyValuePair<MappingFilter, MappingFilter> child in mapping.Children)
		{
			child.Key.Accept(this);
			child.Value.Accept(this);
		}
	}

	void ParamsFilter.Visit(BaseReader stream)
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 3:
				Visit(stream);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af != 0)
				{
					num2 = 2;
				}
				break;
			case 0:
				return;
			case 1:
				Visited(stream);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				VisitChildren(stream);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 != 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	void ParamsFilter.Visit(ListFilter document)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				VisitChildren(document);
				num2 = 3;
				break;
			case 3:
				Visited(document);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 2:
				Visit(document);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb != 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	void ParamsFilter.Visit(RefFilter scalar)
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
				Visit(scalar);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 1:
				Visited(scalar);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void ParamsFilter.Visit(ProcFilter sequence)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 0:
				return;
			case 3:
				Visited(sequence);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				Visit(sequence);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa != 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				VisitChildren(sequence);
				num2 = 3;
				break;
			}
		}
	}

	void ParamsFilter.Visit(ListenerFilter mapping)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 3:
				return;
			case 2:
				Visit(mapping);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
				{
					num2 = 1;
				}
				break;
			default:
				Visited(mapping);
				num2 = 3;
				break;
			case 1:
				VisitChildren(mapping);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	protected InterceptorReader()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool VisitAuthentication()
	{
		return FindAuthentication == null;
	}

	internal static InterceptorReader UpdateAuthentication()
	{
		return FindAuthentication;
	}
}
