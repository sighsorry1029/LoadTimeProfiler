using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal abstract class AttributeFilter : ParserPrototype<RegPrototype>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public UtilsPrototype m_SingletonFilter;

		internal static _003C_003Ec__DisplayClass2_0 IncludeProcess;

		public _003C_003Ec__DisplayClass2_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)]
		internal bool _003CYamlDotNet_002ESerialization_002EIObjectGraphVisitor_003CYamlDotNet_002ESerialization_002ENothing_003E_002EEnter_003Eb__0(StatusPrototype t)
		{
			return t.Accepts(m_SingletonFilter.Type);
		}

		internal static bool CheckProcess()
		{
			return IncludeProcess == null;
		}

		internal static _003C_003Ec__DisplayClass2_0 RateProcess()
		{
			return IncludeProcess;
		}
	}

	protected readonly IEnumerable<StatusPrototype> interpreterFilter;

	private static AttributeFilter RemoveProcess;

	public AttributeFilter(IEnumerable<StatusPrototype> typeConverters)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		IEnumerable<StatusPrototype> enumerable;
		if (typeConverters == null)
		{
			enumerable = Enumerable.Empty<StatusPrototype>();
		}
		else
		{
			IEnumerable<StatusPrototype> enumerable2 = typeConverters.ToList();
			enumerable = enumerable2;
		}
		interpreterFilter = enumerable;
	}

	bool ParserPrototype<RegPrototype>.Enter(UtilsPrototype value, RegPrototype context)
	{
		int num = 1;
		int num2 = num;
		_003C_003Ec__DisplayClass2_0 _003C_003Ec__DisplayClass2_ = default(_003C_003Ec__DisplayClass2_0);
		while (true)
		{
			switch (num2)
			{
			case 5:
				return false;
			case 4:
				return Enter(_003C_003Ec__DisplayClass2_.m_SingletonFilter);
			case 6:
				if (interpreterFilter.FirstOrDefault(_003C_003Ec__DisplayClass2_._003CYamlDotNet_002ESerialization_002EIObjectGraphVisitor_003CYamlDotNet_002ESerialization_002ENothing_003E_002EEnter_003Eb__0) != null)
				{
					num2 = 3;
					break;
				}
				if (!(_003C_003Ec__DisplayClass2_.m_SingletonFilter.Value is RecordPrototype))
				{
					if (!(_003C_003Ec__DisplayClass2_.m_SingletonFilter.Value is ParameterPrototype))
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
						{
							num2 = 2;
						}
						break;
					}
					goto case 5;
				}
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
				{
					num2 = 2;
				}
				break;
			case 2:
				return false;
			case 3:
				return false;
			case 1:
				_003C_003Ec__DisplayClass2_ = new _003C_003Ec__DisplayClass2_0();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 != 0)
				{
					num2 = 0;
				}
				break;
			default:
				_003C_003Ec__DisplayClass2_.m_SingletonFilter = value;
				num2 = 6;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	bool ParserPrototype<RegPrototype>.EnterMapping(RequestPrototype key, UtilsPrototype value, RegPrototype context)
	{
		return EnterMapping(key, value);
	}

	bool ParserPrototype<RegPrototype>.EnterMapping(UtilsPrototype key, UtilsPrototype value, RegPrototype context)
	{
		return EnterMapping(key, value);
	}

	void ParserPrototype<RegPrototype>.VisitMappingEnd(UtilsPrototype mapping, RegPrototype context)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void ParserPrototype<RegPrototype>.VisitMappingStart(UtilsPrototype mapping, Type keyType, Type valueType, RegPrototype context)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	void ParserPrototype<RegPrototype>.VisitScalar(UtilsPrototype scalar, RegPrototype context)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void ParserPrototype<RegPrototype>.VisitSequenceEnd(UtilsPrototype sequence, RegPrototype context)
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
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void ParserPrototype<RegPrototype>.VisitSequenceStart(UtilsPrototype sequence, Type elementType, RegPrototype context)
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
				VisitSequenceStart(sequence, elementType);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	protected abstract bool Enter(UtilsPrototype value);

	protected abstract bool EnterMapping(RequestPrototype key, UtilsPrototype value);

	protected abstract bool EnterMapping(UtilsPrototype key, UtilsPrototype value);

	protected abstract void VisitMappingEnd(UtilsPrototype mapping);

	protected abstract void VisitMappingStart(UtilsPrototype mapping, Type keyType, Type valueType);

	protected abstract void VisitScalar(UtilsPrototype scalar);

	protected abstract void VisitSequenceEnd(UtilsPrototype sequence);

	protected abstract void VisitSequenceStart(UtilsPrototype sequence, Type elementType);

	internal static bool ResolveProcess()
	{
		return RemoveProcess == null;
	}

	internal static AttributeFilter DefineProcess()
	{
		return RemoveProcess;
	}
}
