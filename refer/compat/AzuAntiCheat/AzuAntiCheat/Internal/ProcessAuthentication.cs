using System;

namespace AzuAnticheat.Internal;

internal sealed class ProcessAuthentication : WrapperSetter
{
	private readonly PrinterSetter repositoryAuthentication;

	internal static ProcessAuthentication SelectIssuer;

	public ProcessAuthentication(PrinterSetter objectFactory)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c != 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			}
			repositoryAuthentication = objectFactory;
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
			{
				num = 1;
			}
		}
	}

	public bool Deserialize(CandidateInterpreter parser, Type expectedType, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, out object? value)
	{
		if (typeof(PolicySetter).IsAssignableFrom(expectedType))
		{
			PolicySetter policySetter = (PolicySetter)repositoryAuthentication.Create(expectedType);
			policySetter.ReadYaml(parser);
			value = policySetter;
			return true;
		}
		value = null;
		return false;
	}

	internal static bool ChangeIssuer()
	{
		return SelectIssuer == null;
	}

	internal static ProcessAuthentication CreateIssuer()
	{
		return SelectIssuer;
	}
}
