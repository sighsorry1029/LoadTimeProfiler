using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal sealed class ObjectInterceptor : AttributeFilter, StatePrototype
{
	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)]
	private class ConfigurationInterceptor
	{
		public HelperReader specificationInterceptor;

		private static ConfigurationInterceptor CountProcess;

		public ConfigurationInterceptor()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool SetProcess()
		{
			return CountProcess == null;
		}

		internal static ConfigurationInterceptor PushProcess()
		{
			return CountProcess;
		}
	}

	private readonly IDictionary<object, ConfigurationInterceptor> consumerInterceptor;

	private uint _PropertyInterceptor;

	internal static ObjectInterceptor ListProcess;

	public ObjectInterceptor(IEnumerable<StatusPrototype> typeConverters)
	{
		GetterIssuer.DeleteInitializer();
		consumerInterceptor = new Dictionary<object, ConfigurationInterceptor>();
		base._002Ector(typeConverters);
	}

	protected override bool Enter(UtilsPrototype value)
	{
		int num = 5;
		int num2 = num;
		ConfigurationInterceptor value2 = default(ConfigurationInterceptor);
		while (true)
		{
			switch (num2)
			{
			default:
				return false;
			case 4:
			case 7:
				return true;
			case 2:
				_PropertyInterceptor++;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
				{
					num2 = 0;
				}
				break;
			case 3:
				if (!consumerInterceptor.TryGetValue(value.Value, out value2))
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
					{
						num2 = 7;
					}
					break;
				}
				goto case 1;
			case 6:
				value2.specificationInterceptor = new HelperReader(DicSingleton.gE3WbyDVW(-823738529 ^ -823730307) + _PropertyInterceptor.ToString(CultureInfo.InvariantCulture));
				num2 = 2;
				break;
			case 1:
				if (value2.specificationInterceptor.IsEmpty)
				{
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
					{
						num2 = 6;
					}
					break;
				}
				goto default;
			case 5:
				if (value.Value == null)
				{
					num2 = 4;
					break;
				}
				goto case 3;
			}
		}
	}

	protected override bool EnterMapping(UtilsPrototype key, UtilsPrototype value)
	{
		return true;
	}

	protected override bool EnterMapping(RequestPrototype key, UtilsPrototype value)
	{
		return true;
	}

	protected override void VisitScalar(UtilsPrototype scalar)
	{
	}

	protected override void VisitMappingStart(UtilsPrototype mapping, Type keyType, Type valueType)
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
				VisitObject(mapping);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	protected override void VisitMappingEnd(UtilsPrototype mapping)
	{
	}

	protected override void VisitSequenceStart(UtilsPrototype sequence, Type elementType)
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
				VisitObject(sequence);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	protected override void VisitSequenceEnd(UtilsPrototype sequence)
	{
	}

	private void VisitObject(UtilsPrototype value)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 2:
				if (value.Value != null)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 != 0)
					{
						num2 = 1;
					}
					break;
				}
				return;
			case 0:
				return;
			case 1:
				consumerInterceptor.Add(value.Value, new ConfigurationInterceptor());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	HelperReader StatePrototype.GetAlias(object target)
	{
		int num = 1;
		int num2 = num;
		ConfigurationInterceptor value = default(ConfigurationInterceptor);
		while (true)
		{
			switch (num2)
			{
			case 3:
				return value.specificationInterceptor;
			default:
				return HelperReader._ExceptionReader;
			case 1:
				if (target == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			case 2:
				if (consumerInterceptor.TryGetValue(target, out value))
				{
					num2 = 3;
					break;
				}
				goto default;
			}
		}
	}

	internal static bool CalcProcess()
	{
		return ListProcess == null;
	}

	internal static ObjectInterceptor LogoutProcess()
	{
		return ListProcess;
	}
}
