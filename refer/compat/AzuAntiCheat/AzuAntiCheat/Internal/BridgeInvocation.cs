using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class BridgeInvocation : ConfigInvocation
{
	private sealed class MerchantInvocation : RegSetter
	{
		private readonly PropertyInfo m_TestInvocation;

		private readonly ConnectionSetter m_AttrInvocation;

		[CompilerGenerated]
		private Type? messageInvocation;

		[CompilerGenerated]
		private int m_ExporterInvocation;

		[CompilerGenerated]
		private ConnectionInterpreter valInvocation;

		private static MerchantInvocation PopReg;

		public string Name => m_TestInvocation.Name;

		public Type Type => m_TestInvocation.PropertyType;

		public Type? TypeOverride
		{
			[CompilerGenerated]
			get
			{
				return messageInvocation;
			}
			[CompilerGenerated]
			set
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
						messageInvocation = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			}
		}

		public int Order
		{
			[CompilerGenerated]
			get
			{
				return m_ExporterInvocation;
			}
			[CompilerGenerated]
			set
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
						m_ExporterInvocation = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 == 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			}
		}

		public bool CanWrite => m_TestInvocation.CanWrite;

		public ConnectionInterpreter ScalarStyle
		{
			[CompilerGenerated]
			get
			{
				return valInvocation;
			}
			[CompilerGenerated]
			set
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
						valInvocation = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a579dea83d2144838086d2d400bd0222 != 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			}
		}

		public MerchantInvocation(PropertyInfo propertyInfo, ConnectionSetter typeResolver)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 3;
			while (true)
			{
				switch (num)
				{
				case 2:
					return;
				default:
					ScalarStyle = (ConnectionInterpreter)0;
					num = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
					{
						num = 2;
					}
					break;
				case 3:
					m_TestInvocation = propertyInfo ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x7A125A0E ^ 0x7A12399E));
					num = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec != 0)
					{
						num = 1;
					}
					break;
				case 1:
					m_AttrInvocation = typeResolver ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x602C149E ^ 0x602C41F8));
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
					{
						num = 0;
					}
					break;
				}
			}
		}

		public void Write(object target, object? value)
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 1:
					m_TestInvocation.SetValue(target, value, null);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		public T? GetCustomAttribute<T>() where T : Attribute
		{
			return (T)InterceptorSetter.GetAllCustomAttributes<T>(m_TestInvocation).FirstOrDefault();
		}

		public ImporterSetter Read(object target)
		{
			int num = 2;
			int num2 = num;
			object obj = default(object);
			Type type2 = default(Type);
			while (true)
			{
				Type type;
				switch (num2)
				{
				case 2:
					obj = FactorySetter.ReadValue(m_TestInvocation, target);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 != 0)
					{
						num2 = 1;
					}
					continue;
				case 3:
					return new SchemaSetter(obj, type2, Type, ScalarStyle);
				case 1:
					type = TypeOverride;
					if ((object)type != null)
					{
						break;
					}
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
					{
						num2 = 0;
					}
					continue;
				default:
					type = m_AttrInvocation.Resolve(Type, obj);
					break;
				}
				type2 = type;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d != 0)
				{
					num2 = 3;
				}
			}
		}

		internal static bool PostReg()
		{
			return PopReg == null;
		}

		internal static MerchantInvocation CallReg()
		{
			return PopReg;
		}
	}

	private readonly ConnectionSetter parameterInvocation;

	private readonly bool _StatusInvocation;

	private static BridgeInvocation TestReg;

	public BridgeInvocation(ConnectionSetter typeResolver)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(typeResolver, includeNonPublicProperties: false);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public BridgeInvocation(ConnectionSetter typeResolver, bool includeNonPublicProperties)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 2:
				_StatusInvocation = includeNonPublicProperties;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			case 1:
				parameterInvocation = typeResolver ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1335677307 ^ -1335657501));
				num = 2;
				break;
			}
		}
	}

	private static bool IsValidProperty(PropertyInfo property)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (property.CanRead)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 != 0)
					{
						num2 = 0;
					}
					break;
				}
				return false;
			default:
				return property.GetGetMethod(nonPublic: true).GetParameters().Length == 0;
			}
		}
	}

	public override IEnumerable<RegSetter> GetProperties(Type type, object? container)
	{
		return InterceptorSetter.GetProperties(type, _StatusInvocation).Where(IsValidProperty).Select<PropertyInfo, RegSetter>((Func<PropertyInfo, RegSetter>)((PropertyInfo p) => new MerchantInvocation(p, parameterInvocation)));
	}

	internal static bool RunReg()
	{
		return TestReg == null;
	}

	internal static BridgeInvocation VerifyReg()
	{
		return TestReg;
	}
}
