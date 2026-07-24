using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal abstract class FilterReader : ParamsFilter
{
	internal static FilterReader SearchAuthentication;

	public virtual void Visit(BaseReader stream)
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
				VisitChildren(stream);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public virtual void Visit(ListFilter document)
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
				VisitChildren(document);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public virtual void Visit(RefFilter scalar)
	{
	}

	public virtual void Visit(ProcFilter sequence)
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
				VisitChildren(sequence);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public virtual void Visit(ListenerFilter mapping)
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
				VisitChildren(mapping);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	protected virtual void VisitPair(MappingFilter key, MappingFilter value)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				value.Accept(this);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 != 0)
				{
					num2 = 2;
				}
				break;
			case 1:
				key.Accept(this);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				return;
			}
		}
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
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				document.RootNode.Accept(this);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 == 0)
				{
					num2 = 2;
				}
				break;
			case 1:
				if (document.RootNode != null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
					{
						num2 = 0;
					}
					break;
				}
				return;
			case 2:
				return;
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
			VisitPair(child.Key, child.Value);
		}
	}

	protected FilterReader()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool StopAuthentication()
	{
		return SearchAuthentication == null;
	}

	internal static FilterReader ExcludeAuthentication()
	{
		return SearchAuthentication;
	}
}
