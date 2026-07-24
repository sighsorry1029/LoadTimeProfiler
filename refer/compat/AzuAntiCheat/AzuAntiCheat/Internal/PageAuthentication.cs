using System;
using System.Collections;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal class PageAuthentication : RegistryAuthentication, WrapperSetter
{
	private readonly PrinterSetter m_ParserAuthentication;

	private static PageAuthentication PatchMock;

	public PageAuthentication(PrinterSetter objectFactory, bool duplicateKeyChecking)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(duplicateKeyChecking);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c != 0)
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
			m_ParserAuthentication = objectFactory ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x21AFFB2B ^ 0x21AFAD83));
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec != 0)
			{
				num = 1;
			}
		}
	}

	public bool Deserialize(CandidateInterpreter parser, Type expectedType, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, out object? value)
	{
		Type implementedGenericInterface = MockInvocation.GetImplementedGenericInterface(expectedType, typeof(IDictionary<, >));
		Type type;
		Type type2;
		IDictionary dictionary;
		if (implementedGenericInterface != null)
		{
			Type[] genericArguments = implementedGenericInterface.GetGenericArguments();
			type = genericArguments[0];
			type2 = genericArguments[1];
			value = m_ParserAuthentication.Create(expectedType);
			dictionary = value as IDictionary;
			if (dictionary == null)
			{
				dictionary = (IDictionary)Activator.CreateInstance(typeof(AttrAttribute<, >).MakeGenericType(type, type2), value);
			}
		}
		else
		{
			if (!typeof(IDictionary).IsAssignableFrom(expectedType))
			{
				value = null;
				return false;
			}
			type = typeof(object);
			type2 = typeof(object);
			value = m_ParserAuthentication.Create(expectedType);
			dictionary = (IDictionary)value;
		}
		Deserialize(type, type2, parser, nestedObjectDeserializer, dictionary);
		return true;
	}

	internal static bool AssetMock()
	{
		return PatchMock == null;
	}

	internal static PageAuthentication ListMock()
	{
		return PatchMock;
	}
}
