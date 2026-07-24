using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal abstract class OrderAttribute : CodeAttribute
{
	internal static OrderAttribute GetToken;

	public virtual void Visit(FacadeAttribute stream)
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
				VisitChildren(stream);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public virtual void Visit(TemplateAttribute document)
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
				VisitChildren(document);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public virtual void Visit(UtilsAttribute scalar)
	{
	}

	public virtual void Visit(ParserAttribute sequence)
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
				VisitChildren(sequence);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public virtual void Visit(ResolverAttribute mapping)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	protected virtual void VisitPair(ProductAttribute key, ProductAttribute value)
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
				key.Accept(this);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				value.Accept(this);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	protected virtual void VisitChildren(FacadeAttribute stream)
	{
		foreach (TemplateAttribute document in stream.Documents)
		{
			document.Accept(this);
		}
	}

	protected virtual void VisitChildren(TemplateAttribute document)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			default:
				document.RootNode.Accept(this);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				if (document.RootNode == null)
				{
					return;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	protected virtual void VisitChildren(ParserAttribute sequence)
	{
		foreach (ProductAttribute child in sequence.Children)
		{
			child.Accept(this);
		}
	}

	protected virtual void VisitChildren(ResolverAttribute mapping)
	{
		foreach (KeyValuePair<ProductAttribute, ProductAttribute> child in mapping.Children)
		{
			VisitPair(child.Key, child.Value);
		}
	}

	protected OrderAttribute()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool CalculateToken()
	{
		return GetToken == null;
	}

	internal static OrderAttribute MoveToken()
	{
		return GetToken;
	}
}
