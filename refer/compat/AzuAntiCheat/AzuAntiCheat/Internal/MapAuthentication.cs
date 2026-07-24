using System;
using System.Collections;

namespace AzuAnticheat.Internal;

internal abstract class MapAuthentication : PrinterSetter
{
	internal static MapAuthentication FindImporter;

	public abstract object Create(Type type);

	public abstract Array CreateArray(Type type, int count);

	public abstract bool IsDictionary(Type type);

	public abstract bool IsArray(Type type);

	public abstract bool IsList(Type type);

	public abstract Type GetKeyType(Type type);

	public abstract Type GetValueType(Type type);

	public virtual object? CreatePrimitive(Type type)
	{
		int num = 3;
		TypeCode typeCode = default(TypeCode);
		DateTime dateTime = default(DateTime);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 2:
					switch (typeCode)
					{
					default:
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
						{
							num2 = 1;
						}
						goto end_IL_0012;
					case TypeCode.Boolean:
						break;
					case TypeCode.Byte:
						return (byte)0;
					case TypeCode.Int16:
						return (short)0;
					case TypeCode.Int32:
						return 0;
					case TypeCode.Int64:
						return 0L;
					case TypeCode.SByte:
						return (sbyte)0;
					case TypeCode.UInt16:
						return (ushort)0;
					case TypeCode.UInt32:
						return 0u;
					case TypeCode.UInt64:
						return 0uL;
					case TypeCode.Single:
						return 0f;
					case TypeCode.Double:
						return 0.0;
					case TypeCode.Decimal:
						return 0m;
					case TypeCode.Char:
						return '\0';
					case TypeCode.DateTime:
						goto end_IL_0012_2;
					}
					goto default;
				default:
					return false;
				case 4:
					return dateTime;
				case 1:
					return null;
				case 3:
					{
						typeCode = Type.GetTypeCode(type);
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db == 0)
						{
							num2 = 2;
						}
						break;
					}
					end_IL_0012:
					break;
				}
				continue;
				end_IL_0012_2:
				break;
			}
			dateTime = default(DateTime);
			num = 4;
		}
	}

	public bool GetDictionary(ImporterSetter descriptor, out IDictionary? dictionary, out Type[]? genericArguments)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				genericArguments = null;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				dictionary = null;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb != 0)
				{
					num2 = 1;
				}
				break;
			default:
				return false;
			}
		}
	}

	public abstract void ExecuteOnDeserializing(object value);

	public abstract void ExecuteOnDeserialized(object value);

	public abstract void ExecuteOnSerializing(object value);

	public abstract void ExecuteOnSerialized(object value);

	protected MapAuthentication()
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool VisitImporter()
	{
		return FindImporter == null;
	}

	internal static MapAuthentication OrderImporter()
	{
		return FindImporter;
	}
}
