using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class EventInvocation : ConfigInvocation
{
	private sealed class OrderInvocation : RegSetter
	{
		private readonly FieldInfo m_ContainerInvocation;

		private readonly ConnectionSetter m_IteratorInvocation;

		[CompilerGenerated]
		private Type? _ClientInvocation;

		[CompilerGenerated]
		private int recordInvocation;

		[CompilerGenerated]
		private ConnectionInterpreter m_ServiceInvocation;

		private static OrderInvocation SelectReg;

		public string Name => m_ContainerInvocation.Name;

		public Type Type => m_ContainerInvocation.FieldType;

		public Type? TypeOverride
		{
			[CompilerGenerated]
			get
			{
				return _ClientInvocation;
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
					case 1:
						_ClientInvocation = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 != 0)
						{
							num2 = 0;
						}
						break;
					case 0:
						return;
					}
				}
			}
		}

		public int Order
		{
			[CompilerGenerated]
			get
			{
				return recordInvocation;
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
					case 1:
						recordInvocation = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
						{
							num2 = 0;
						}
						break;
					case 0:
						return;
					}
				}
			}
		}

		public bool CanWrite => !m_ContainerInvocation.IsInitOnly;

		public ConnectionInterpreter ScalarStyle
		{
			[CompilerGenerated]
			get
			{
				return m_ServiceInvocation;
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
					case 1:
						m_ServiceInvocation = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb == 0)
						{
							num2 = 0;
						}
						break;
					case 0:
						return;
					}
				}
			}
		}

		public OrderInvocation(FieldInfo fieldInfo, ConnectionSetter typeResolver)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			m_ContainerInvocation = fieldInfo;
			m_IteratorInvocation = typeResolver;
			ScalarStyle = (ConnectionInterpreter)0;
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
					m_ContainerInvocation.SetValue(target, value);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		public T? GetCustomAttribute<T>() where T : Attribute
		{
			return (T)m_ContainerInvocation.GetCustomAttributes(typeof(T), inherit: true).FirstOrDefault();
		}

		public ImporterSetter Read(object target)
		{
			int num = 3;
			object value = default(object);
			Type type2 = default(Type);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					Type type;
					switch (num2)
					{
					case 1:
						return new SchemaSetter(value, type2, Type, ScalarStyle);
					case 3:
						goto end_IL_0012;
					case 2:
						type = TypeOverride;
						if ((object)type != null)
						{
							break;
						}
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
						{
							num2 = 0;
						}
						continue;
					default:
						type = m_IteratorInvocation.Resolve(Type, value);
						break;
					}
					type2 = type;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 == 0)
					{
						num2 = 0;
					}
					continue;
					end_IL_0012:
					break;
				}
				value = m_ContainerInvocation.GetValue(target);
				num = 2;
			}
		}

		internal static bool ChangeReg()
		{
			return SelectReg == null;
		}

		internal static OrderInvocation CreateReg()
		{
			return SelectReg;
		}
	}

	private readonly ConnectionSetter m_InstanceInvocation;

	private static EventInvocation PublishReg;

	public EventInvocation(ConnectionSetter typeResolver)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
		{
			num = 0;
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
				m_InstanceInvocation = typeResolver ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x47C77AB8 ^ 0x47C72FDE));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public override IEnumerable<RegSetter> GetProperties(Type type, object? container)
	{
		return InterceptorSetter.GetPublicFields(type).Select<FieldInfo, RegSetter>((Func<FieldInfo, RegSetter>)((FieldInfo p) => new OrderInvocation(p, m_InstanceInvocation)));
	}

	internal static bool RegisterReg()
	{
		return PublishReg == null;
	}

	internal static EventInvocation SetupReg()
	{
		return PublishReg;
	}
}
