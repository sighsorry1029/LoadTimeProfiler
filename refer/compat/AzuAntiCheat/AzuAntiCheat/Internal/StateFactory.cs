using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 0, 1, 1 })]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class StateFactory : KeyedCollection<string, ErrorFactory>
{
	private static StateFactory RateError;

	public StateFactory()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public StateFactory(IEnumerable<ErrorFactory> tagDirectives)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		foreach (ErrorFactory tagDirective in tagDirectives)
		{
			Add(tagDirective);
		}
	}

	protected override string GetKeyForItem(ErrorFactory item)
	{
		return item.Handle;
	}

	public new bool Contains(ErrorFactory directive)
	{
		return Contains(GetKeyForItem(directive));
	}

	internal static bool ResetError()
	{
		return RateError == null;
	}

	internal static StateFactory CustomizeError()
	{
		return RateError;
	}
}
