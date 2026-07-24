using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace AzuAnticheat.Internal;

internal abstract class StrategyInterceptor : InstancePrototype
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public string processorInterceptor;

		private static _003C_003Ec__DisplayClass1_0 CalculateUtils;

		public _003C_003Ec__DisplayClass1_0()
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

		internal bool _003CGetProperty_003Eb__0(RequestPrototype p)
		{
			return p.Name == processorInterceptor;
		}

		internal static bool MoveUtils()
		{
			return CalculateUtils == null;
		}

		internal static _003C_003Ec__DisplayClass1_0 RevertUtils()
		{
			return CalculateUtils;
		}
	}

	private static StrategyInterceptor ForgotUtils;

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public abstract IEnumerable<RequestPrototype> GetProperties(Type type, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object container);

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public RequestPrototype GetProperty(Type type, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object container, string name, [StrategyBase(true)] bool ignoreUnmatched)
	{
		int num = 1;
		int num2 = num;
		IEnumerator<RequestPrototype> enumerator = default(IEnumerator<RequestPrototype>);
		IEnumerable<RequestPrototype> enumerable = default(IEnumerable<RequestPrototype>);
		_003C_003Ec__DisplayClass1_0 _003C_003Ec__DisplayClass1_ = default(_003C_003Ec__DisplayClass1_0);
		RequestPrototype result = default(RequestPrototype);
		RequestPrototype current = default(RequestPrototype);
		while (true)
		{
			switch (num2)
			{
			case 5:
				enumerator = enumerable.GetEnumerator();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 != 0)
				{
					num2 = 2;
				}
				break;
			case 1:
				_003C_003Ec__DisplayClass1_ = new _003C_003Ec__DisplayClass1_0();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
				{
					num2 = 0;
				}
				break;
			case 4:
				return result;
			case 2:
				try
				{
					int num3;
					if (enumerator.MoveNext())
					{
						num3 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 == 0)
						{
							num3 = 1;
						}
						goto IL_00a6;
					}
					goto IL_01c5;
					IL_01c5:
					if (!ignoreUnmatched)
					{
						num3 = 4;
						goto IL_00a6;
					}
					goto IL_0151;
					IL_0151:
					result = null;
					num3 = 5;
					goto IL_00a6;
					IL_00a6:
					while (true)
					{
						switch (num3)
						{
						case 2:
						case 4:
							throw new SerializationException(DicSingleton.gE3WbyDVW(-108820061 ^ -108795377) + _003C_003Ec__DisplayClass1_.processorInterceptor + DicSingleton.gE3WbyDVW(-1611872559 ^ -1611881195) + type.FullName + DicSingleton.gE3WbyDVW(-1735703950 ^ -1735714986));
						case 1:
							current = enumerator.Current;
							num3 = 7;
							continue;
						case 8:
							break;
						case 7:
							goto IL_019c;
						case 5:
							goto end_IL_007c;
						default:
							goto IL_01c5;
						case 3:
							throw new SerializationException(DicSingleton.gE3WbyDVW(0x2BC53863 ^ 0x2BC55B91) + _003C_003Ec__DisplayClass1_.processorInterceptor + DicSingleton.gE3WbyDVW(0x7FAAD78F ^ 0x7FAAB3C7) + type.FullName + DicSingleton.gE3WbyDVW(-2103041941 ^ -2103032597) + string.Join(DicSingleton.gE3WbyDVW(0x408F2744 ^ 0x408F4228), enumerable.Select((RequestPrototype p) => p.Name).ToArray()));
						case 6:
							goto end_IL_007c;
						}
						break;
						IL_019c:
						if (enumerator.MoveNext())
						{
							num3 = 3;
							continue;
						}
						result = current;
						num3 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 != 0)
						{
							num3 = 6;
						}
					}
					goto IL_0151;
					end_IL_007c:;
				}
				finally
				{
					if (enumerator != null)
					{
						int num4 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
						{
							num4 = 1;
						}
						while (true)
						{
							switch (num4)
							{
							case 1:
								enumerator.Dispose();
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 != 0)
								{
									num4 = 0;
								}
								continue;
							case 0:
								break;
							}
							break;
						}
					}
				}
				goto case 4;
			default:
				_003C_003Ec__DisplayClass1_.processorInterceptor = name;
				num2 = 3;
				break;
			case 3:
				enumerable = GetProperties(type, container).Where(_003C_003Ec__DisplayClass1_._003CGetProperty_003Eb__0);
				num2 = 5;
				break;
			}
		}
	}

	protected StrategyInterceptor()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool RestartUtils()
	{
		return ForgotUtils == null;
	}

	internal static StrategyInterceptor GetUtils()
	{
		return ForgotUtils;
	}
}
