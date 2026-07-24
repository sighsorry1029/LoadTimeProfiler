using System;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal class ComparatorAttribute : InvocationAttribute
{
	internal readonly List<ComposerAttribute> m_DefinitionAttribute;

	internal static ComparatorAttribute RevertIssuer;

	public void AddTypeDiscriminator(ComposerAttribute discriminator)
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
				m_DefinitionAttribute.Add(discriminator);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public void AddKeyValueTypeDiscriminator<T>(string discriminatorKey, IDictionary<string, Type> valueTypeMapping)
	{
		m_DefinitionAttribute.Add(new GlobalAttribute(typeof(T), discriminatorKey, valueTypeMapping));
	}

	public void AddUniqueKeyTypeDiscriminator<T>(IDictionary<string, Type> uniqueKeyTypeMapping)
	{
		m_DefinitionAttribute.Add(new ItemAttribute(typeof(T), uniqueKeyTypeMapping));
	}

	public ComparatorAttribute()
	{
		GetterIssuer.DeleteInitializer();
		m_DefinitionAttribute = new List<ComposerAttribute>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool InvokeToken()
	{
		return RevertIssuer == null;
	}

	internal static ComparatorAttribute PublishToken()
	{
		return RevertIssuer;
	}
}
