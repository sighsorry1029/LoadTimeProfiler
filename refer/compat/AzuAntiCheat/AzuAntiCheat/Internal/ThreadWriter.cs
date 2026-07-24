using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class ThreadWriter : ConfigInvocation
{
	public sealed class StructWriter : RegSetter
	{
		private readonly RegSetter _ClassWriter;

		private readonly DispatcherWriter objectWriter;

		private readonly Type _ConsumerWriter;

		private static StructWriter ExcludeOrder;

		public string Name => _ClassWriter.Name;

		public bool CanWrite => _ClassWriter.CanWrite;

		public Type Type => _ClassWriter.Type;

		public Type? TypeOverride
		{
			get
			{
				return _ClassWriter.TypeOverride;
			}
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
						_ClassWriter.TypeOverride = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
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
			get
			{
				return _ClassWriter.Order;
			}
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
						_ClassWriter.Order = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
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

		public ConnectionInterpreter ScalarStyle
		{
			get
			{
				return _ClassWriter.ScalarStyle;
			}
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
						_ClassWriter.ScalarStyle = value;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b == 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			}
		}

		public StructWriter(RegSetter baseDescriptor, DispatcherWriter overrides, Type classType)
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 2;
			while (true)
			{
				switch (num)
				{
				default:
					return;
				case 2:
					_ClassWriter = baseDescriptor;
					num = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
					{
						num = 1;
					}
					break;
				case 0:
					return;
				case 1:
					objectWriter = overrides;
					num = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 != 0)
					{
						num = 3;
					}
					break;
				case 3:
					_ConsumerWriter = classType;
					num = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc == 0)
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
					_ClassWriter.Write(target, value);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
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
			return objectWriter.GetAttribute<T>(_ConsumerWriter, Name) ?? _ClassWriter.GetCustomAttribute<T>();
		}

		public ImporterSetter Read(object target)
		{
			return _ClassWriter.Read(target);
		}

		internal static bool InterruptOrder()
		{
			return ExcludeOrder == null;
		}

		internal static StructWriter DeleteOrder()
		{
			return ExcludeOrder;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public ThreadWriter m_PropertyWriter;

		public Type configurationWriter;

		private static _003C_003Ec__DisplayClass3_0 FillOrder;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal RegSetter _003CGetProperties_003Eb__0(RegSetter p)
		{
			return new StructWriter(p, m_PropertyWriter.m_SchemaWriter, configurationWriter);
		}

		internal static bool FlushOrder()
		{
			return FillOrder == null;
		}

		internal static _003C_003Ec__DisplayClass3_0 DestroyOrder()
		{
			return FillOrder;
		}
	}

	private readonly AdvisorSetter m_MappingWriter;

	private readonly DispatcherWriter m_SchemaWriter;

	private static ThreadWriter UpdateOrder;

	public ThreadWriter(AdvisorSetter innerTypeDescriptor, DispatcherWriter overrides)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 != 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			default:
				return;
			case 2:
				m_SchemaWriter = overrides;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba == 0)
				{
					num = 0;
				}
				break;
			case 0:
				return;
			case 1:
				m_MappingWriter = innerTypeDescriptor;
				num = 2;
				break;
			}
		}
	}

	public override IEnumerable<RegSetter> GetProperties(Type type, object? container)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals5.m_PropertyWriter = this;
		CS_0024_003C_003E8__locals5.configurationWriter = type;
		IEnumerable<RegSetter> enumerable = m_MappingWriter.GetProperties(CS_0024_003C_003E8__locals5.configurationWriter, container);
		if (m_SchemaWriter != null)
		{
			enumerable = enumerable.Select((Func<RegSetter, RegSetter>)((RegSetter p) => new StructWriter(p, CS_0024_003C_003E8__locals5.m_PropertyWriter.m_SchemaWriter, CS_0024_003C_003E8__locals5.configurationWriter)));
		}
		return enumerable;
	}

	internal static bool SearchOrder()
	{
		return UpdateOrder == null;
	}

	internal static ThreadWriter StopOrder()
	{
		return UpdateOrder;
	}
}
