using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class RefInterceptor : RoleFilter
{
	private readonly DecoratorPrototype m_ObserverInterceptor;

	private readonly StatePrototype m_AdapterInterceptor;

	private readonly HashSet<HelperReader> procInterceptor;

	internal static RefInterceptor ValidateProcess;

	public RefInterceptor(ParserPrototype<ModelReader> nextVisitor, DecoratorPrototype eventEmitter, StatePrototype aliasProvider)
	{
		GetterIssuer.DeleteInitializer();
		procInterceptor = new HashSet<HelperReader>();
		base._002Ector(nextVisitor);
		m_ObserverInterceptor = eventEmitter;
		m_AdapterInterceptor = aliasProvider;
	}

	public override bool Enter(UtilsPrototype value, ModelReader context)
	{
		int num = 3;
		int num2 = num;
		IdentifierPrototype identifierPrototype = default(IdentifierPrototype);
		HelperReader alias = default(HelperReader);
		while (true)
		{
			switch (num2)
			{
			case 1:
				return identifierPrototype.NeedsExpansion;
			case 5:
				if (!alias.IsEmpty)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto IL_0040;
			default:
				if (!procInterceptor.Add(alias))
				{
					num2 = 4;
					break;
				}
				goto IL_0040;
			case 4:
				identifierPrototype = new IdentifierPrototype(value, alias);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec != 0)
				{
					num2 = 6;
				}
				break;
			case 2:
				alias = m_AdapterInterceptor.GetAlias(value.Value);
				num2 = 5;
				break;
			case 3:
				if (value.Value != null)
				{
					num2 = 2;
					break;
				}
				goto IL_0040;
			case 6:
				{
					m_ObserverInterceptor.Emit(identifierPrototype, context);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
					{
						num2 = 0;
					}
					break;
				}
				IL_0040:
				return base.Enter(value, context);
			}
		}
	}

	public override void VisitMappingStart(UtilsPrototype mapping, Type keyType, Type valueType, ModelReader context)
	{
		int num = 2;
		int num2 = num;
		HelperReader alias = default(HelperReader);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				m_ObserverInterceptor.Emit(new WatcherPrototype(mapping)
				{
					Anchor = alias
				}, context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				alias = m_AdapterInterceptor.GetAlias(mapping.NonNullValue());
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 == 0)
				{
					num2 = 1;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public override void VisitSequenceStart(UtilsPrototype sequence, Type elementType, ModelReader context)
	{
		int num = 2;
		int num2 = num;
		HelperReader alias = default(HelperReader);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				m_ObserverInterceptor.Emit(new CandidatePrototype(sequence)
				{
					Anchor = alias
				}, context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb != 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				alias = m_AdapterInterceptor.GetAlias(sequence.NonNullValue());
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public override void VisitScalar(UtilsPrototype scalar, ModelReader context)
	{
		int num = 4;
		IndexerPrototype indexerPrototype = default(IndexerPrototype);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 5:
					return;
				case 4:
					indexerPrototype = new IndexerPrototype(scalar);
					num2 = 3;
					continue;
				case 1:
					indexerPrototype.Anchor = m_AdapterInterceptor.GetAlias(scalar.Value);
					num = 2;
					break;
				case 3:
					if (scalar.Value == null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 1;
				default:
					m_ObserverInterceptor.Emit(indexerPrototype, context);
					num = 5;
					break;
				}
				break;
			}
		}
	}

	internal static bool EnableProcess()
	{
		return ValidateProcess == null;
	}

	internal static RefInterceptor SortProcess()
	{
		return ValidateProcess;
	}
}
