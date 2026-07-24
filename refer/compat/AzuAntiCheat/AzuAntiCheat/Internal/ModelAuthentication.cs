using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ModelAuthentication : WrapperSetter
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public Func<CandidateInterpreter, Type, object?> _ConnectionAuthentication;

		public CandidateInterpreter annotationAuthentication;

		private static _003C_003Ec__DisplayClass2_0 PublishIssuer;

		public _003C_003Ec__DisplayClass2_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal object? _003CDeserialize_003Eb__0(Type type)
		{
			return _ConnectionAuthentication(annotationAuthentication, type);
		}

		internal static bool RegisterIssuer()
		{
			return PublishIssuer == null;
		}

		internal static _003C_003Ec__DisplayClass2_0 SetupIssuer()
		{
			return PublishIssuer;
		}
	}

	private readonly PrinterSetter m_AdvisorAuthentication;

	private static ModelAuthentication MoveMock;

	public ModelAuthentication(PrinterSetter objectFactory)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 0:
				return;
			case 1:
				m_AdvisorAuthentication = objectFactory;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public bool Deserialize(CandidateInterpreter parser, Type expectedType, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, out object? value)
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals5._ConnectionAuthentication = nestedObjectDeserializer;
		CS_0024_003C_003E8__locals5.annotationAuthentication = parser;
		if (typeof(TagSetter).IsAssignableFrom(expectedType))
		{
			TagSetter tagSetter = (TagSetter)m_AdvisorAuthentication.Create(expectedType);
			tagSetter.Read(CS_0024_003C_003E8__locals5.annotationAuthentication, expectedType, (Type type) => CS_0024_003C_003E8__locals5._ConnectionAuthentication(CS_0024_003C_003E8__locals5.annotationAuthentication, type));
			value = tagSetter;
			return true;
		}
		value = null;
		return false;
	}

	internal static bool RevertMock()
	{
		return MoveMock == null;
	}

	internal static ModelAuthentication InvokeIssuer()
	{
		return MoveMock;
	}
}
