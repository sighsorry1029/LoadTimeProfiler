using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal abstract class RoleFilter : ParserPrototype<ModelReader>
{
	private readonly ParserPrototype<ModelReader> _PublisherFilter;

	private static RoleFilter InsertProcess;

	protected RoleFilter(ParserPrototype<ModelReader> nextVisitor)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		_PublisherFilter = nextVisitor;
	}

	public virtual bool Enter(UtilsPrototype value, ModelReader context)
	{
		return _PublisherFilter.Enter(value, context);
	}

	public virtual bool EnterMapping(UtilsPrototype key, UtilsPrototype value, ModelReader context)
	{
		return _PublisherFilter.EnterMapping(key, value, context);
	}

	public virtual bool EnterMapping(RequestPrototype key, UtilsPrototype value, ModelReader context)
	{
		return _PublisherFilter.EnterMapping(key, value, context);
	}

	public virtual void VisitScalar(UtilsPrototype scalar, ModelReader context)
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
				_PublisherFilter.VisitScalar(scalar, context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public virtual void VisitMappingStart(UtilsPrototype mapping, Type keyType, Type valueType, ModelReader context)
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
				_PublisherFilter.VisitMappingStart(mapping, keyType, valueType, context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public virtual void VisitMappingEnd(UtilsPrototype mapping, ModelReader context)
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
				_PublisherFilter.VisitMappingEnd(mapping, context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public virtual void VisitSequenceStart(UtilsPrototype sequence, Type elementType, ModelReader context)
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
				_PublisherFilter.VisitSequenceStart(sequence, elementType, context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public virtual void VisitSequenceEnd(UtilsPrototype sequence, ModelReader context)
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
				_PublisherFilter.VisitSequenceEnd(sequence, context);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool FindProcess()
	{
		return InsertProcess == null;
	}

	internal static RoleFilter VisitProcess()
	{
		return InsertProcess;
	}
}
