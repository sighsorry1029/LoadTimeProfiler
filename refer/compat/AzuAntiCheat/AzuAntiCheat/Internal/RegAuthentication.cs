using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class RegAuthentication : WrapperSetter
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public Type _ProxyAuthentication;

		private static _003C_003Ec__DisplayClass2_0 RestartMock;

		public _003C_003Ec__DisplayClass2_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal bool _003CDeserialize_003Eb__0(StrategySetter c)
		{
			return c.Accepts(_ProxyAuthentication);
		}

		internal static bool GetMock()
		{
			return RestartMock == null;
		}

		internal static _003C_003Ec__DisplayClass2_0 CalculateMock()
		{
			return RestartMock;
		}
	}

	private readonly IEnumerable<StrategySetter> _ReponseAuthentication;

	public RegAuthentication(IEnumerable<StrategySetter> converters)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		_ReponseAuthentication = converters ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x602C149E ^ 0x602C78C0));
	}

	public bool Deserialize(CandidateInterpreter parser, Type expectedType, Func<CandidateInterpreter, Type, object?> nestedObjectDeserializer, out object? value)
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals3._ProxyAuthentication = expectedType;
		StrategySetter strategySetter = _ReponseAuthentication.FirstOrDefault((StrategySetter c) => c.Accepts(CS_0024_003C_003E8__locals3._ProxyAuthentication));
		if (strategySetter == null)
		{
			value = null;
			return false;
		}
		value = strategySetter.ReadYaml(parser, CS_0024_003C_003E8__locals3._ProxyAuthentication);
		return true;
	}
}
