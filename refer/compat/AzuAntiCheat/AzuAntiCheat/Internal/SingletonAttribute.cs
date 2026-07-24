using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class SingletonAttribute : WrapperSetter
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public Type _ProducerAttribute;

		private static _003C_003Ec__DisplayClass5_0 GetIssuer;

		public _003C_003Ec__DisplayClass5_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal bool _003CDeserialize_003Eb__0(ComposerAttribute t)
		{
			return t.BaseType.IsAssignableFrom(_ProducerAttribute);
		}

		internal static bool CalculateIssuer()
		{
			return GetIssuer == null;
		}

		internal static _003C_003Ec__DisplayClass5_0 MoveIssuer()
		{
			return GetIssuer;
		}
	}

	private readonly IList<WrapperSetter> issuerAttribute;

	private readonly IList<ComposerAttribute> fieldAttribute;

	private readonly int _RuleAttribute;

	private readonly int m_SerializerAttribute;

	public SingletonAttribute(IList<WrapperSetter> innerDeserializers, IList<ComposerAttribute> typeDiscriminators, int maxDepthToBuffer, int maxLengthToBuffer)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		issuerAttribute = innerDeserializers;
		fieldAttribute = typeDiscriminators;
		_RuleAttribute = maxDepthToBuffer;
		m_SerializerAttribute = maxLengthToBuffer;
	}

	public bool Deserialize(CandidateInterpreter reader, Type expectedType, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, out object? value)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals3._ProducerAttribute = expectedType;
		if (!reader.Accept<FacadeSingleton>(out var _))
		{
			value = null;
			return false;
		}
		IEnumerable<ComposerAttribute> enumerable = fieldAttribute.Where((ComposerAttribute t) => t.BaseType.IsAssignableFrom(CS_0024_003C_003E8__locals3._ProducerAttribute));
		if (!enumerable.Any())
		{
			value = null;
			return false;
		}
		TestsInterpreter start = reader.Current.Start;
		Type expectedType2 = CS_0024_003C_003E8__locals3._ProducerAttribute;
		AuthenticationAttribute authenticationAttribute;
		try
		{
			authenticationAttribute = new AuthenticationAttribute(reader, _RuleAttribute, m_SerializerAttribute);
		}
		catch (Exception innerException)
		{
			throw new ReaderSingleton(in start, reader.Current.End, DicSingleton.gE3WbyDVW(-1880453928 ^ -1880475140), innerException);
		}
		try
		{
			foreach (ComposerAttribute item in enumerable)
			{
				authenticationAttribute.Reset();
				if (item.TryDiscriminate(authenticationAttribute, out Type suggestedType))
				{
					expectedType2 = suggestedType;
					break;
				}
			}
		}
		catch (Exception innerException2)
		{
			throw new ReaderSingleton(in start, reader.Current.End, DicSingleton.gE3WbyDVW(0x1A7A0414 ^ 0x1A7AB148), innerException2);
		}
		authenticationAttribute.Reset();
		foreach (WrapperSetter item2 in issuerAttribute)
		{
			if (item2.Deserialize(authenticationAttribute, expectedType2, nestedObjectDeserializer, out value))
			{
				return true;
			}
		}
		value = null;
		return false;
	}
}
