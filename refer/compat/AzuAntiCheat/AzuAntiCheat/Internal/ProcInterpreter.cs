using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AzuAnticheat.Internal;

internal sealed class ProcInterpreter : KeyedCollection<string, TemplateSingleton>
{
	private static ProcInterpreter UpdateProducer;

	public ProcInterpreter()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
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

	public ProcInterpreter(IEnumerable<TemplateSingleton> tagDirectives)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		foreach (TemplateSingleton tagDirective in tagDirectives)
		{
			Add(tagDirective);
		}
	}

	protected override string GetKeyForItem(TemplateSingleton item)
	{
		return item.Handle;
	}

	public new bool Contains(TemplateSingleton directive)
	{
		return Contains(GetKeyForItem(directive));
	}

	internal static bool SearchProducer()
	{
		return UpdateProducer == null;
	}

	internal static ProcInterpreter StopProducer()
	{
		return UpdateProducer;
	}
}
