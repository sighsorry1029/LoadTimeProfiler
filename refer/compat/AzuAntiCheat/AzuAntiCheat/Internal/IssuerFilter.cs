using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal class IssuerFilter : PagePrototype
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	protected struct ComparatorFilter
	{
		public readonly object _DefinitionFilter;

		public readonly UtilsPrototype _ComposerFilter;

		internal static object ReflectProcess;

		public ComparatorFilter(object name, UtilsPrototype value)
		{
			GetterIssuer.DeleteInitializer();
			_DefinitionFilter = name;
			_ComposerFilter = value;
		}

		internal static bool CollectProcess()
		{
			return ReflectProcess == null;
		}

		internal static object ManageProcess()
		{
			return ReflectProcess;
		}
	}

	private readonly int m_FieldFilter;

	private readonly InstancePrototype m_RuleFilter;

	private readonly OrderPrototype serializerFilter;

	private readonly BroadcasterPrototype producerFilter;

	internal static IssuerFilter ResetProcess;

	public IssuerFilter(InstancePrototype typeDescriptor, OrderPrototype typeResolver, int maxRecursion, BroadcasterPrototype namingConvention)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 5:
				m_FieldFilter = maxRecursion;
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
				{
					num = 1;
				}
				continue;
			case 2:
				return;
			case 3:
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-1075938037 ^ -1075962893), maxRecursion, DicSingleton.gE3WbyDVW(0x7FAAD78F ^ 0x7FAAB09B));
			case 4:
				serializerFilter = typeResolver ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-823738529 ^ -823727559));
				num = 5;
				continue;
			case 1:
				producerFilter = namingConvention ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-830028630 ^ -830041816));
				num = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
				{
					num = 2;
				}
				continue;
			}
			if (maxRecursion <= 0)
			{
				num = 3;
				continue;
			}
			m_RuleFilter = typeDescriptor ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-833481355 ^ -833457621));
			num = 4;
		}
	}

	void PagePrototype.Traverse<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TContext>(UtilsPrototype graph, ParserPrototype<TContext> visitor, TContext context)
	{
		Traverse(DicSingleton.gE3WbyDVW(-948533799 ^ -948510041), graph, visitor, context, new Stack<ComparatorFilter>(m_FieldFilter));
	}

	protected virtual void Traverse<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TContext>(object name, UtilsPrototype value, ParserPrototype<TContext> visitor, TContext context, Stack<ComparatorFilter> path)
	{
		if (path.Count >= m_FieldFilter)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(DicSingleton.gE3WbyDVW(0x602C149E ^ 0x602C7310));
			stringBuilder.AppendLine(DicSingleton.gE3WbyDVW(0x4C73F208 ^ 0x4C7395F2));
			Stack<KeyValuePair<string, string>> stack = new Stack<KeyValuePair<string, string>>(path.Count);
			int num = 0;
			foreach (ComparatorFilter item in path)
			{
				string text = ContainerInterceptor.ChangeType<string>(item._DefinitionFilter);
				num = Math.Max(num, text.Length);
				stack.Push(new KeyValuePair<string, string>(text, item._ComposerFilter.Type.FullName));
			}
			foreach (KeyValuePair<string, string> item2 in stack)
			{
				stringBuilder.Append(DicSingleton.gE3WbyDVW(0x30B55457 ^ 0x30B53C1F)).Append(item2.Key.PadRight(num)).Append(DicSingleton.gE3WbyDVW(-1977574774 ^ -1977552162))
					.Append(item2.Value)
					.AppendLine(DicSingleton.gE3WbyDVW(-25744665 ^ -25738567));
			}
			throw new AccountReader(stringBuilder.ToString());
		}
		if (!visitor.Enter(value, context))
		{
			return;
		}
		path.Push(new ComparatorFilter(name, value));
		try
		{
			TypeCode typeCode = CollectionBase.GetTypeCode(value.Type);
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
				throw new NotSupportedException(string.Format(DicSingleton.gE3WbyDVW(-359091888 ^ -359081676), typeCode));
			}
			if (CollectionBase.IsDbNull(value))
			{
				visitor.VisitScalar(new ReponsePrototype(null, typeof(object), typeof(object)), context);
			}
			if (value.Value == null || value.Type == typeof(TimeSpan))
			{
				visitor.VisitScalar(value, context);
				return;
			}
			Type underlyingType = Nullable.GetUnderlyingType(value.Type);
			if (underlyingType != null)
			{
				Traverse(DicSingleton.gE3WbyDVW(-1954645236 ^ -1954671704), new ReponsePrototype(value.Value, underlyingType, value.Type, value.ScalarStyle), visitor, context, path);
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

	protected virtual void TraverseObject<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TContext>(UtilsPrototype value, ParserPrototype<TContext> visitor, TContext context, Stack<ComparatorFilter> path)
	{
		if (typeof(IDictionary).IsAssignableFrom(value.Type))
		{
			TraverseDictionary(value, visitor, typeof(object), typeof(object), context, path);
			return;
		}
		Type implementedGenericInterface = ParserInterceptor.GetImplementedGenericInterface(value.Type, typeof(IDictionary<, >));
		if (implementedGenericInterface != null)
		{
			Type[] genericArguments = implementedGenericInterface.GetGenericArguments();
			object value2 = Activator.CreateInstance(typeof(WriterReader<, >).MakeGenericType(genericArguments), value.Value);
			TraverseDictionary(new ReponsePrototype(value2, value.Type, value.StaticType, value.ScalarStyle), visitor, genericArguments[0], genericArguments[1], context, path);
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

	protected virtual void TraverseDictionary<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TContext>(UtilsPrototype dictionary, ParserPrototype<TContext> visitor, Type keyType, Type valueType, TContext context, Stack<ComparatorFilter> path)
	{
		visitor.VisitMappingStart(dictionary, keyType, valueType, context);
		bool flag = dictionary.Type.FullName.Equals(DicSingleton.gE3WbyDVW(-1398029315 ^ -1398035633));
		foreach (DictionaryEntry? item in (IDictionary)dictionary.NonNullValue())
		{
			DictionaryEntry value = item.Value;
			object obj = (flag ? producerFilter.Apply(value.Key.ToString()) : value.Key);
			UtilsPrototype objectDescriptor = GetObjectDescriptor(obj, keyType);
			UtilsPrototype objectDescriptor2 = GetObjectDescriptor(value.Value, valueType);
			if (visitor.EnterMapping(objectDescriptor, objectDescriptor2, context))
			{
				Traverse(obj, objectDescriptor, visitor, context, path);
				Traverse(obj, objectDescriptor2, visitor, context, path);
			}
		}
		visitor.VisitMappingEnd(dictionary, context);
	}

	private void TraverseList<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TContext>(UtilsPrototype value, ParserPrototype<TContext> visitor, TContext context, Stack<ComparatorFilter> path)
	{
		Type implementedGenericInterface = ParserInterceptor.GetImplementedGenericInterface(value.Type, typeof(IEnumerable<>));
		Type type = ((implementedGenericInterface != null) ? implementedGenericInterface.GetGenericArguments()[0] : typeof(object));
		visitor.VisitSequenceStart(value, type, context);
		int num = 0;
		foreach (object item in (IEnumerable)value.NonNullValue())
		{
			Traverse(num, GetObjectDescriptor(item, type), visitor, context, path);
			num++;
		}
		visitor.VisitSequenceEnd(value, context);
	}

	protected virtual void TraverseProperties<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] TContext>(UtilsPrototype value, ParserPrototype<TContext> visitor, TContext context, Stack<ComparatorFilter> path)
	{
		visitor.VisitMappingStart(value, typeof(string), typeof(object), context);
		object obj = value.NonNullValue();
		foreach (RequestPrototype property in m_RuleFilter.GetProperties(value.Type, obj))
		{
			UtilsPrototype value2 = property.Read(obj);
			if (visitor.EnterMapping(property, value2, context))
			{
				Traverse(property.Name, new ReponsePrototype(property.Name, typeof(string), typeof(string)), visitor, context, path);
				Traverse(property.Name, value2, visitor, context, path);
			}
		}
		visitor.VisitMappingEnd(value, context);
	}

	private UtilsPrototype GetObjectDescriptor([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] object value, Type staticType)
	{
		return new ReponsePrototype(value, serializerFilter.Resolve(staticType, value), staticType);
	}

	internal static bool CustomizeProcess()
	{
		return ResetProcess == null;
	}

	internal static IssuerFilter CancelProcess()
	{
		return ResetProcess;
	}
}
