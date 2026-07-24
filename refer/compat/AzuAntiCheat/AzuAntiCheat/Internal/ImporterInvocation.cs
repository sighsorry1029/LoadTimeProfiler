using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ImporterInvocation : ConfigInvocation
{
	private sealed class DatabaseInvocation : RegSetter
	{
		private readonly PropertyInfo m_ErrorInvocation;

		private readonly ConnectionSetter _RegInvocation;

		[CompilerGenerated]
		private Type? m_ReponseInvocation;

		[CompilerGenerated]
		private int proxyInvocation;

		[CompilerGenerated]
		private ConnectionInterpreter _ModelInvocation;

		private static DatabaseInvocation PatchReg;

		public string Name => m_ErrorInvocation.Name;

		public Type Type => m_ErrorInvocation.PropertyType;

		public Type? TypeOverride
		{
			[CompilerGenerated]
			get
			{
				return m_ReponseInvocation;
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
						m_ReponseInvocation = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec == 0)
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
				return proxyInvocation;
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
						proxyInvocation = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 != 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			}
		}

		public bool CanWrite => m_ErrorInvocation.CanWrite;

		public ConnectionInterpreter ScalarStyle
		{
			[CompilerGenerated]
			get
			{
				return _ModelInvocation;
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
						_ModelInvocation = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c != 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			}
		}

		public DatabaseInvocation(PropertyInfo propertyInfo, ConnectionSetter typeResolver)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 2;
			while (true)
			{
				switch (num)
				{
				default:
					ScalarStyle = (ConnectionInterpreter)0;
					num = 3;
					break;
				case 3:
					return;
				case 2:
					m_ErrorInvocation = propertyInfo ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-948533799 ^ -948509111));
					num = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba != 0)
					{
						num = 0;
					}
					break;
				case 1:
					_RegInvocation = typeResolver ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-380885952 ^ -380866266));
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
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
				case 0:
					return;
				case 1:
					m_ErrorInvocation.SetValue(target, value, null);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae50b6e347494ff2973fbc64d1fc9236 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		public T? GetCustomAttribute<T>() where T : Attribute
		{
			return (T)InterceptorSetter.GetAllCustomAttributes<T>(m_ErrorInvocation).FirstOrDefault();
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
				case 1:
					type = TypeOverride;
					if ((object)type == null)
					{
						num2 = 3;
						continue;
					}
					break;
				default:
					return new SchemaSetter(obj, type2, Type, ScalarStyle);
				case 2:
					obj = FactorySetter.ReadValue(m_ErrorInvocation, target);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
					{
						num2 = 1;
					}
					continue;
				case 3:
					type = _RegInvocation.Resolve(Type, obj);
					break;
				}
				type2 = type;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
				{
					num2 = 0;
				}
			}
		}

		internal static bool AssetReg()
		{
			return PatchReg == null;
		}

		internal static DatabaseInvocation ListReg()
		{
			return PatchReg;
		}
	}

	private readonly ConnectionSetter m_CreatorInvocation;

	private readonly bool printerInvocation;

	internal static ImporterInvocation ReadReg;

	public ImporterInvocation(ConnectionSetter typeResolver)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(typeResolver, includeNonPublicProperties: false);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ImporterInvocation(ConnectionSetter typeResolver, bool includeNonPublicProperties)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				printerInvocation = includeNonPublicProperties;
				num = 2;
				continue;
			case 2:
				return;
			}
			m_CreatorInvocation = typeResolver ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1880453928 ^ -1880434242));
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 != 0)
			{
				num = 0;
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
			default:
				return property.GetSetMethod(nonPublic: true).GetParameters().Length == 1;
			case 1:
				if (!property.CanWrite)
				{
					return false;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public override IEnumerable<RegSetter> GetProperties(Type type, object? container)
	{
		return InterceptorSetter.GetProperties(type, printerInvocation).Where(IsValidProperty).Select<PropertyInfo, RegSetter>((Func<PropertyInfo, RegSetter>)((PropertyInfo p) => new DatabaseInvocation(p, m_CreatorInvocation)))
			.ToArray();
	}

	internal static bool ViewReg()
	{
		return ReadReg == null;
	}

	internal static ImporterInvocation InitReg()
	{
		return ReadReg;
	}
}
