using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[Serializable]
[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
internal static class Class
{
	internal static Class StartExpression;

	public static IEnumerable<Dispatcher> Parse(string yaml)
	{
		return new GlobalSetter().IgnoreFields().Build().Deserialize<Dictionary<string, Dispatcher>>(yaml)
			.Select([_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)] (KeyValuePair<string, Dispatcher> kv) =>
			{
				Dispatcher value = kv.Value;
				value.m_List = kv.Key;
				return value;
			});
	}

	[return: _003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(2)]
	public static Dictionary<string, Params> ParseHook(string yaml)
	{
		return new GlobalSetter().WithNamingConvention(DescriptorAuthentication.m_DispatcherAuthentication).Build().Deserialize<Dictionary<string, Params>>(yaml);
	}

	public static string ToYAML(SortedDictionary<string, string> modDefaultList)
	{
		return new PublisherWriter().DisableAliases().WithNamingConvention(ParamsAuthentication._PoolAuthentication).Build()
			.Serialize(modDefaultList);
	}

	public static string ToYAML(this Dispatcher self)
	{
		return new PublisherWriter().DisableAliases().WithNamingConvention(ParamsAuthentication._PoolAuthentication).Build()
			.Serialize(self);
	}

	public static SortedDictionary<string, string> FromYAML(string yaml)
	{
		return new GlobalSetter().WithNamingConvention(DescriptorAuthentication.m_DispatcherAuthentication).Build().Deserialize<SortedDictionary<string, string>>(yaml);
	}

	internal static bool RemoveExpression()
	{
		return StartExpression == null;
	}

	internal static Class ResolveExpression()
	{
		return StartExpression;
	}
}
