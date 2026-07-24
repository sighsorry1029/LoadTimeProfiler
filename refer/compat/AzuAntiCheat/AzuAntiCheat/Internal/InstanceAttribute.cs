using System;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

[Obsolete("Use YamlVisitorBase")]
internal abstract class InstanceAttribute : CodeAttribute
{
	internal static InstanceAttribute ManageToken;

	protected virtual void Visit(FacadeAttribute stream)
	{
	}

	protected virtual void Visited(FacadeAttribute stream)
	{
	}

	protected virtual void Visit(TemplateAttribute document)
	{
	}

	protected virtual void Visited(TemplateAttribute document)
	{
	}

	protected virtual void Visit(UtilsAttribute scalar)
	{
	}

	protected virtual void Visited(UtilsAttribute scalar)
	{
	}

	protected virtual void Visit(ParserAttribute sequence)
	{
	}

	protected virtual void Visited(ParserAttribute sequence)
	{
	}

	protected virtual void Visit(ResolverAttribute mapping)
	{
	}

	protected virtual void Visited(ResolverAttribute mapping)
	{
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
			default:
				return;
			case 0:
				return;
			case 2:
				return;
			case 3:
				document.RootNode.Accept(this);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 == 0)
				{
					num2 = 2;
				}
				break;
			case 1:
				if (document.RootNode == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 3;
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
		int num = 1;
		int num2 = num;
		IEnumerator<KeyValuePair<ProductAttribute, ProductAttribute>> enumerator = default(IEnumerator<KeyValuePair<ProductAttribute, ProductAttribute>>);
		KeyValuePair<ProductAttribute, ProductAttribute> current = default(KeyValuePair<ProductAttribute, ProductAttribute>);
		while (true)
		{
			switch (num2)
			{
			case 1:
				enumerator = mapping.Children.GetEnumerator();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
				{
					num2 = 0;
				}
				continue;
			case 2:
				return;
			}
			try
			{
				while (true)
				{
					int num3;
					if (!enumerator.MoveNext())
					{
						num3 = 2;
						goto IL_0074;
					}
					goto IL_00e6;
					IL_0074:
					while (true)
					{
						switch (num3)
						{
						case 2:
							return;
						case 4:
							current.Key.Accept(this);
							num3 = 3;
							continue;
						case 3:
							current.Value.Accept(this);
							num3 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
							{
								num3 = 0;
							}
							continue;
						case 1:
							goto IL_00e6;
						}
						break;
					}
					continue;
					IL_00e6:
					current = enumerator.Current;
					int num4 = 4;
					num3 = num4;
					goto IL_0074;
				}
			}
			finally
			{
				if (enumerator != null)
				{
					int num5 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
					{
						num5 = 1;
					}
					while (true)
					{
						switch (num5)
						{
						case 1:
							enumerator.Dispose();
							num5 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
							{
								num5 = 0;
							}
							continue;
						case 0:
							break;
						}
						break;
					}
				}
			}
		}
	}

	void CodeAttribute.Visit(FacadeAttribute stream)
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				VisitChildren(stream);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 != 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				return;
			case 3:
				Visit(stream);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
				{
					num2 = 2;
				}
				break;
			default:
				Visited(stream);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 != 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	void CodeAttribute.Visit(TemplateAttribute document)
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
				Visit(document);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				VisitChildren(document);
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d == 0)
				{
					num2 = 1;
				}
				break;
			case 3:
				Visited(document);
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

	void CodeAttribute.Visit(UtilsAttribute scalar)
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
			case 2:
				Visit(scalar);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 != 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				Visited(scalar);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void CodeAttribute.Visit(ParserAttribute sequence)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				VisitChildren(sequence);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				Visit(sequence);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 == 0)
				{
					num2 = 1;
				}
				break;
			default:
				Visited(sequence);
				num2 = 3;
				break;
			case 3:
				return;
			}
		}
	}

	void CodeAttribute.Visit(ResolverAttribute mapping)
	{
		int num = 3;
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
				Visit(mapping);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				Visited(mapping);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				VisitChildren(mapping);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	protected InstanceAttribute()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ForgotToken()
	{
		return ManageToken == null;
	}

	internal static InstanceAttribute RestartToken()
	{
		return ManageToken;
	}
}
