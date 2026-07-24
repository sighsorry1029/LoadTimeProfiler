using System;
using System.Collections;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal abstract class GlobalAuthentication : PrinterSetter
{
	internal static GlobalAuthentication EnableImporter;

	public abstract object Create(Type type);

	public virtual object? CreatePrimitive(Type type)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (InterceptorSetter.IsValueType(type))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 != 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			case 2:
				return null;
			default:
				return Activator.CreateInstance(type);
			}
		}
	}

	public virtual void ExecuteOnDeserialized(object value)
	{
	}

	public virtual void ExecuteOnDeserializing(object value)
	{
	}

	public virtual void ExecuteOnSerialized(object value)
	{
	}

	public virtual void ExecuteOnSerializing(object value)
	{
	}

	public virtual bool GetDictionary(ImporterSetter descriptor, out IDictionary? dictionary, out Type[]? genericArguments)
	{
		int num = 3;
		int num2 = num;
		object obj = default(object);
		Type implementedGenericInterface = default(Type);
		while (true)
		{
			switch (num2)
			{
			case 7:
				dictionary = obj as IDictionary;
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 != 0)
				{
					num2 = 3;
				}
				break;
			case 4:
				return true;
			case 2:
				if (!(implementedGenericInterface != null))
				{
					genericArguments = null;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
					{
						num2 = 0;
					}
				}
				else
				{
					num2 = 5;
				}
				break;
			case 3:
				implementedGenericInterface = MockInvocation.GetImplementedGenericInterface(descriptor.Type, typeof(IDictionary<, >));
				num2 = 2;
				break;
			case 5:
				genericArguments = implementedGenericInterface.GetGenericArguments();
				num2 = 6;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
				{
					num2 = 3;
				}
				break;
			case 1:
				return false;
			default:
				dictionary = null;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
				{
					num2 = 1;
				}
				break;
			case 6:
				obj = Activator.CreateInstance(typeof(AttrAttribute<, >).MakeGenericType(genericArguments), descriptor.Value);
				num2 = 7;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	public virtual Type GetValueType(Type type)
	{
		int num = 2;
		int num2 = num;
		Type implementedGenericInterface = default(Type);
		while (true)
		{
			switch (num2)
			{
			case 2:
				implementedGenericInterface = MockInvocation.GetImplementedGenericInterface(type, typeof(IEnumerable<>));
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec != 0)
				{
					num2 = 0;
				}
				break;
			default:
				return typeof(object);
			case 1:
				if (implementedGenericInterface != null)
				{
					return implementedGenericInterface.GetGenericArguments()[0];
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	protected GlobalAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool SortImporter()
	{
		return EnableImporter == null;
	}

	internal static GlobalAuthentication InsertImporter()
	{
		return EnableImporter;
	}
}
