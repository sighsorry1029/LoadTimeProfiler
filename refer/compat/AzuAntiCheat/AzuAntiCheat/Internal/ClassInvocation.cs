using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ClassInvocation : MappingInvocation
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public ImporterSetter _PropertyInvocation;

		internal static _003C_003Ec__DisplayClass3_0 RestartReg;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal bool _003CEnter_003Eb__0(StrategySetter t)
		{
			return t.Accepts(_PropertyInvocation.Type);
		}

		internal static bool GetReg()
		{
			return RestartReg == null;
		}

		internal static _003C_003Ec__DisplayClass3_0 CalculateReg()
		{
			return RestartReg;
		}
	}

	private readonly IEnumerable<StrategySetter> m_ObjectInvocation;

	private readonly StubSetter consumerInvocation;

	internal static ClassInvocation CollectReg;

	public ClassInvocation(ErrorSetter<MockInterpreter> nextVisitor, IEnumerable<StrategySetter> typeConverters, StubSetter nestedObjectSerializer)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(nextVisitor);
		IEnumerable<StrategySetter> objectInvocation;
		if (typeConverters == null)
		{
			objectInvocation = Enumerable.Empty<StrategySetter>();
		}
		else
		{
			IEnumerable<StrategySetter> enumerable = typeConverters.ToList();
			objectInvocation = enumerable;
		}
		m_ObjectInvocation = objectInvocation;
		consumerInvocation = nestedObjectSerializer;
	}

	public override bool Enter(ImporterSetter value, MockInterpreter context)
	{
		int num = 9;
		int num2 = num;
		TagSetter tagSetter = default(TagSetter);
		PolicySetter policySetter = default(PolicySetter);
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = default(_003C_003Ec__DisplayClass3_0);
		StrategySetter strategySetter = default(StrategySetter);
		while (true)
		{
			switch (num2)
			{
			case 4:
				tagSetter.Write(context, consumerInvocation);
				num2 = 5;
				break;
			case 11:
				return false;
			case 2:
				if (policySetter == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 != 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 7;
			case 12:
				return false;
			case 1:
				return base.Enter(_003C_003Ec__DisplayClass3_._PropertyInvocation, context);
			default:
				if (strategySetter == null)
				{
					tagSetter = _003C_003Ec__DisplayClass3_._PropertyInvocation.Value as TagSetter;
					num2 = 10;
					break;
				}
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
				{
					num2 = 6;
				}
				break;
			case 9:
				_003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
				num2 = 8;
				break;
			case 5:
				return false;
			case 7:
				policySetter.WriteYaml(context);
				num2 = 12;
				break;
			case 8:
				_003C_003Ec__DisplayClass3_._PropertyInvocation = value;
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb != 0)
				{
					num2 = 1;
				}
				break;
			case 10:
				if (tagSetter == null)
				{
					policySetter = _003C_003Ec__DisplayClass3_._PropertyInvocation.Value as PolicySetter;
					num2 = 2;
					break;
				}
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 == 0)
				{
					num2 = 4;
				}
				break;
			case 3:
				strategySetter = m_ObjectInvocation.FirstOrDefault(_003C_003Ec__DisplayClass3_._003CEnter_003Eb__0);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
				{
					num2 = 0;
				}
				break;
			case 6:
				strategySetter.WriteYaml(context, _003C_003Ec__DisplayClass3_._PropertyInvocation.Value, _003C_003Ec__DisplayClass3_._PropertyInvocation.Type);
				num2 = 11;
				break;
			}
		}
	}

	internal static bool ManageReg()
	{
		return CollectReg == null;
	}

	internal static ClassInvocation ForgotReg()
	{
		return CollectReg;
	}
}
