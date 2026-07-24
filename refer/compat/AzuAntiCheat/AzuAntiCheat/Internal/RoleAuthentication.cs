using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal abstract class RoleAuthentication : ErrorSetter<MappingSetter>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public ImporterSetter baseAuthentication;

		internal static _003C_003Ec__DisplayClass2_0 PopImporter;

		public _003C_003Ec__DisplayClass2_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal bool _003CYamlDotNet_002ESerialization_002EIObjectGraphVisitor_003CYamlDotNet_002ESerialization_002ENothing_003E_002EEnter_003Eb__0(StrategySetter t)
		{
			return t.Accepts(baseAuthentication.Type);
		}

		internal static bool PostImporter()
		{
			return PopImporter == null;
		}

		internal static _003C_003Ec__DisplayClass2_0 CallImporter()
		{
			return PopImporter;
		}
	}

	protected readonly IEnumerable<StrategySetter> _PublisherAuthentication;

	internal static RoleAuthentication TestImporter;

	public RoleAuthentication(IEnumerable<StrategySetter> typeConverters)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		IEnumerable<StrategySetter> publisherAuthentication;
		if (typeConverters == null)
		{
			publisherAuthentication = Enumerable.Empty<StrategySetter>();
		}
		else
		{
			IEnumerable<StrategySetter> enumerable = typeConverters.ToList();
			publisherAuthentication = enumerable;
		}
		_PublisherAuthentication = publisherAuthentication;
	}

	bool ErrorSetter<MappingSetter>.Enter(ImporterSetter value, MappingSetter context)
	{
		int num = 4;
		_003C_003Ec__DisplayClass2_0 _003C_003Ec__DisplayClass2_ = default(_003C_003Ec__DisplayClass2_0);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 5:
					return false;
				default:
					return false;
				case 1:
					if (!(_003C_003Ec__DisplayClass2_.baseAuthentication.Value is PolicySetter))
					{
						goto end_IL_0012;
					}
					goto case 7;
				case 4:
					_003C_003Ec__DisplayClass2_ = new _003C_003Ec__DisplayClass2_0();
					num2 = 3;
					break;
				case 3:
					_003C_003Ec__DisplayClass2_.baseAuthentication = value;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
					{
						num2 = 2;
					}
					break;
				case 2:
					if (_PublisherAuthentication.FirstOrDefault(_003C_003Ec__DisplayClass2_._003CYamlDotNet_002ESerialization_002EIObjectGraphVisitor_003CYamlDotNet_002ESerialization_002ENothing_003E_002EEnter_003Eb__0) == null)
					{
						if (!(_003C_003Ec__DisplayClass2_.baseAuthentication.Value is TagSetter))
						{
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
							{
								num2 = 1;
							}
							break;
						}
						goto default;
					}
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
					{
						num2 = 0;
					}
					break;
				case 7:
					return false;
				case 6:
					return Enter(_003C_003Ec__DisplayClass2_.baseAuthentication);
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 6;
		}
	}

	bool ErrorSetter<MappingSetter>.EnterMapping(RegSetter key, ImporterSetter value, MappingSetter context)
	{
		return EnterMapping(key, value);
	}

	bool ErrorSetter<MappingSetter>.EnterMapping(ImporterSetter key, ImporterSetter value, MappingSetter context)
	{
		return EnterMapping(key, value);
	}

	void ErrorSetter<MappingSetter>.VisitMappingEnd(ImporterSetter mapping, MappingSetter context)
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
				VisitMappingEnd(mapping);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void ErrorSetter<MappingSetter>.VisitMappingStart(ImporterSetter mapping, Type keyType, Type valueType, MappingSetter context)
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
				VisitMappingStart(mapping, keyType, valueType);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	void ErrorSetter<MappingSetter>.VisitScalar(ImporterSetter scalar, MappingSetter context)
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
				VisitScalar(scalar);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void ErrorSetter<MappingSetter>.VisitSequenceEnd(ImporterSetter sequence, MappingSetter context)
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
				VisitSequenceEnd(sequence);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void ErrorSetter<MappingSetter>.VisitSequenceStart(ImporterSetter sequence, Type elementType, MappingSetter context)
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
				VisitSequenceStart(sequence, elementType);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	protected abstract bool Enter(ImporterSetter value);

	protected abstract bool EnterMapping(RegSetter key, ImporterSetter value);

	protected abstract bool EnterMapping(ImporterSetter key, ImporterSetter value);

	protected abstract void VisitMappingEnd(ImporterSetter mapping);

	protected abstract void VisitMappingStart(ImporterSetter mapping, Type keyType, Type valueType);

	protected abstract void VisitScalar(ImporterSetter scalar);

	protected abstract void VisitSequenceEnd(ImporterSetter sequence);

	protected abstract void VisitSequenceStart(ImporterSetter sequence, Type elementType);

	internal static bool RunImporter()
	{
		return TestImporter == null;
	}

	internal static RoleAuthentication VerifyImporter()
	{
		return TestImporter;
	}
}
