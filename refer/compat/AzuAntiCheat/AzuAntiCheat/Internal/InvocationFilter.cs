using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class InvocationFilter : ParserPrototype<ModelReader>
{
	private readonly DecoratorPrototype authenticationFilter;

	private static InvocationFilter LoginProcess;

	public InvocationFilter(DecoratorPrototype eventEmitter)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 1:
				authenticationFilter = eventEmitter;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	bool ParserPrototype<ModelReader>.Enter(UtilsPrototype value, ModelReader context)
	{
		return true;
	}

	bool ParserPrototype<ModelReader>.EnterMapping(UtilsPrototype key, UtilsPrototype value, ModelReader context)
	{
		return true;
	}

	bool ParserPrototype<ModelReader>.EnterMapping(RequestPrototype key, UtilsPrototype value, ModelReader context)
	{
		return true;
	}

	void ParserPrototype<ModelReader>.VisitScalar(UtilsPrototype scalar, ModelReader context)
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
				authenticationFilter.Emit(new IndexerPrototype(scalar), context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	void ParserPrototype<ModelReader>.VisitMappingStart(UtilsPrototype mapping, Type keyType, Type valueType, ModelReader context)
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
				authenticationFilter.Emit(new WatcherPrototype(mapping), context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void ParserPrototype<ModelReader>.VisitMappingEnd(UtilsPrototype mapping, ModelReader context)
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
				authenticationFilter.Emit(new ResolverPrototype(mapping), context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void ParserPrototype<ModelReader>.VisitSequenceStart(UtilsPrototype sequence, Type elementType, ModelReader context)
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
				authenticationFilter.Emit(new CandidatePrototype(sequence), context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	void ParserPrototype<ModelReader>.VisitSequenceEnd(UtilsPrototype sequence, ModelReader context)
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
				authenticationFilter.Emit(new RegistryPrototype(sequence), context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool ConnectProcess()
	{
		return LoginProcess == null;
	}

	internal static InvocationFilter StartProcess()
	{
		return LoginProcess;
	}
}
