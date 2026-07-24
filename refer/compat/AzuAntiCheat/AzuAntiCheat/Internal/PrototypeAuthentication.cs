using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AzuAnticheat.Internal;

internal class PrototypeAuthentication : DatabaseSetter
{
	protected struct WriterAuthentication
	{
		public readonly object invocationAuthentication;

		public readonly ImporterSetter authenticationAuthentication;

		private static object AddImporter;

		public WriterAuthentication(object name, ImporterSetter value)
		{
			GetterIssuer.DeleteInitializer();
			invocationAuthentication = name;
			authenticationAuthentication = value;
		}

		internal static bool PrepareImporter()
		{
			return AddImporter == null;
		}

		internal static object WriteImporter()
		{
			return AddImporter;
		}
	}

	private readonly int interceptorAuthentication;

	private readonly AdvisorSetter filterAuthentication;

	private readonly ConnectionSetter readerAuthentication;

	private readonly ConfigSetter factoryAuthentication;

	private readonly PrinterSetter m_SetterAuthentication;

	internal static PrototypeAuthentication ConcatImporter;

	public PrototypeAuthentication(AdvisorSetter typeDescriptor, ConnectionSetter typeResolver, int maxRecursion, ConfigSetter namingConvention, PrinterSetter objectFactory)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 4;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 6:
				interceptorAuthentication = maxRecursion;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
				{
					num = 2;
				}
				break;
			case 7:
				return;
			case 4:
				if (maxRecursion > 0)
				{
					num = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 != 0)
					{
						num = 5;
					}
					break;
				}
				goto default;
			default:
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-475093377 ^ -475086713), maxRecursion, DicSingleton.gE3WbyDVW(-1180565667 ^ -1180592055));
			case 5:
				filterAuthentication = typeDescriptor ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x1C779450 ^ 0x1C77F30E));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 != 0)
				{
					num = 1;
				}
				break;
			case 1:
				readerAuthentication = typeResolver ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(--1182565251 ^ 0x467CD6E5));
				num = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
				{
					num = 6;
				}
				break;
			case 2:
				factoryAuthentication = namingConvention ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1461449777 ^ -1461428659));
				num = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b != 0)
				{
					num = 2;
				}
				break;
			case 3:
				m_SetterAuthentication = objectFactory ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1133601918 ^ -1133589206));
				num = 7;
				break;
			}
		}
	}

	void DatabaseSetter.Traverse<TContext>(ImporterSetter graph, ErrorSetter<TContext> visitor, TContext context)
	{
		Traverse(DicSingleton.gE3WbyDVW(0x3A437A88 ^ 0x3A431DF6), graph, visitor, context, new Stack<WriterAuthentication>(interceptorAuthentication));
	}

	protected virtual void Traverse<TContext>(object name, ImporterSetter value, ErrorSetter<TContext> visitor, TContext context, Stack<WriterAuthentication> path)
	{
		if (path.Count >= interceptorAuthentication)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(DicSingleton.gE3WbyDVW(-940539791 ^ -940513281));
			stringBuilder.AppendLine(DicSingleton.gE3WbyDVW(-1977574774 ^ -1977549456));
			Stack<KeyValuePair<string, string>> stack = new Stack<KeyValuePair<string, string>>(path.Count);
			int num = 0;
			foreach (WriterAuthentication item in path)
			{
				string text = item.invocationAuthentication?.ToString() ?? string.Empty;
				num = Math.Max(num, text.Length);
				stack.Push(new KeyValuePair<string, string>(text, item.authenticationAuthentication.Type.FullName));
			}
			foreach (KeyValuePair<string, string> item2 in stack)
			{
				stringBuilder.Append(DicSingleton.gE3WbyDVW(-1773869960 ^ -1773892560)).Append(item2.Key.PadRight(num)).Append(DicSingleton.gE3WbyDVW(-525002617 ^ -524980013))
					.Append(item2.Value)
					.AppendLine(DicSingleton.gE3WbyDVW(-2075300707 ^ -2075327293));
			}
			throw new ParamInterpreter(stringBuilder.ToString());
		}
		if (!visitor.Enter(value, context))
		{
			return;
		}
		path.Push(new WriterAuthentication(name, value));
		try
		{
			TypeCode typeCode = InterceptorSetter.GetTypeCode(value.Type);
			switch (typeCode)
			{
			case TypeCode.Boolean:
			case TypeCode.Char:
			case TypeCode.SByte:
			case TypeCode.Byte:
			case TypeCode.Int16:
			case TypeCode.UInt16:
			case TypeCode.Int32:
			case TypeCode.UInt32:
			case TypeCode.Int64:
			case TypeCode.UInt64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
			case TypeCode.DateTime:
			case TypeCode.String:
				visitor.VisitScalar(value, context);
				return;
			case TypeCode.Empty:
				throw new NotSupportedException(string.Format(DicSingleton.gE3WbyDVW(0x4C73F208 ^ 0x4C739A6C), typeCode));
			}
			if (InterceptorSetter.IsDbNull(value))
			{
				visitor.VisitScalar(new SchemaSetter(null, typeof(object), typeof(object)), context);
			}
			if (value.Value == null || value.Type == typeof(TimeSpan))
			{
				visitor.VisitScalar(value, context);
				return;
			}
			Type underlyingType = Nullable.GetUnderlyingType(value.Type);
			if (underlyingType != null)
			{
				Traverse(DicSingleton.gE3WbyDVW(-2103041941 ^ -2103031601), new SchemaSetter(value.Value, underlyingType, value.Type, value.ScalarStyle), visitor, context, path);
			}
			else
			{
				TraverseObject(value, visitor, context, path);
			}
		}
		finally
		{
			path.Pop();
		}
	}

	protected virtual void TraverseObject<TContext>(ImporterSetter value, ErrorSetter<TContext> visitor, TContext context, Stack<WriterAuthentication> path)
	{
		IDictionary dictionary;
		Type[] genericArguments;
		if (typeof(IDictionary).IsAssignableFrom(value.Type))
		{
			TraverseDictionary(value, visitor, typeof(object), typeof(object), context, path);
		}
		else if (m_SetterAuthentication.GetDictionary(value, out dictionary, out genericArguments))
		{
			TraverseDictionary(new SchemaSetter(dictionary, value.Type, value.StaticType, value.ScalarStyle), visitor, genericArguments[0], genericArguments[1], context, path);
		}
		else if (typeof(IEnumerable).IsAssignableFrom(value.Type))
		{
			TraverseList(value, visitor, context, path);
		}
		else
		{
			TraverseProperties(value, visitor, context, path);
		}
	}

	protected virtual void TraverseDictionary<TContext>(ImporterSetter dictionary, ErrorSetter<TContext> visitor, Type keyType, Type valueType, TContext context, Stack<WriterAuthentication> path)
	{
		visitor.VisitMappingStart(dictionary, keyType, valueType, context);
		bool flag = dictionary.Type.FullName.Equals(DicSingleton.gE3WbyDVW(-2075300707 ^ -2075327441));
		foreach (DictionaryEntry? item in (IDictionary)dictionary.NonNullValue())
		{
			DictionaryEntry value = item.Value;
			object obj = (flag ? factoryAuthentication.Apply(value.Key.ToString()) : value.Key);
			ImporterSetter objectDescriptor = GetObjectDescriptor(obj, keyType);
			ImporterSetter objectDescriptor2 = GetObjectDescriptor(value.Value, valueType);
			if (visitor.EnterMapping(objectDescriptor, objectDescriptor2, context))
			{
				Traverse(obj, objectDescriptor, visitor, context, path);
				Traverse(obj, objectDescriptor2, visitor, context, path);
			}
		}
		visitor.VisitMappingEnd(dictionary, context);
	}

	private void TraverseList<TContext>(ImporterSetter value, ErrorSetter<TContext> visitor, TContext context, Stack<WriterAuthentication> path)
	{
		Type valueType = m_SetterAuthentication.GetValueType(value.Type);
		visitor.VisitSequenceStart(value, valueType, context);
		int num = 0;
		foreach (object item in (IEnumerable)value.NonNullValue())
		{
			Traverse(num, GetObjectDescriptor(item, valueType), visitor, context, path);
			num++;
		}
		visitor.VisitSequenceEnd(value, context);
	}

	protected virtual void TraverseProperties<TContext>(ImporterSetter value, ErrorSetter<TContext> visitor, TContext context, Stack<WriterAuthentication> path)
	{
		if (context.GetType() != typeof(MappingSetter))
		{
			m_SetterAuthentication.ExecuteOnSerializing(value.Value);
		}
		visitor.VisitMappingStart(value, typeof(string), typeof(object), context);
		object obj = value.NonNullValue();
		foreach (RegSetter property in filterAuthentication.GetProperties(value.Type, obj))
		{
			ImporterSetter value2 = property.Read(obj);
			if (visitor.EnterMapping(property, value2, context))
			{
				Traverse(property.Name, new SchemaSetter(property.Name, typeof(string), typeof(string), (ConnectionInterpreter)1), visitor, context, path);
				Traverse(property.Name, value2, visitor, context, path);
			}
		}
		visitor.VisitMappingEnd(value, context);
		if (context.GetType() != typeof(MappingSetter))
		{
			m_SetterAuthentication.ExecuteOnSerialized(value.Value);
		}
	}

	private ImporterSetter GetObjectDescriptor(object? value, Type staticType)
	{
		return new SchemaSetter(value, readerAuthentication.Resolve(staticType, value), staticType);
	}

	internal static bool MapImporter()
	{
		return ConcatImporter == null;
	}

	internal static PrototypeAuthentication NewImporter()
	{
		return ConcatImporter;
	}
}
