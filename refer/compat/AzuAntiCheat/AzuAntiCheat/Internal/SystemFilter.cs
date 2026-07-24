using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class SystemFilter : WorkerPrototype
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public IList m_CandidateFilter;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public Type m_ExpressionFilter;

		private static _003C_003Ec__DisplayClass3_0 UpdateInstance;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool SearchInstance()
		{
			return UpdateInstance == null;
		}

		internal static _003C_003Ec__DisplayClass3_0 StopInstance()
		{
			return UpdateInstance;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_1
	{
		public int m_ProductFilter;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public _003C_003Ec__DisplayClass3_0 registryFilter;

		internal static _003C_003Ec__DisplayClass3_1 ExcludeInstance;

		public _003C_003Ec__DisplayClass3_1()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
		internal void _003CDeserializeHelper_003Eb__0(object v)
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
					registryFilter.m_CandidateFilter[m_ProductFilter] = ContainerInterceptor.ChangeType(v, registryFilter.m_ExpressionFilter);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		internal static bool InterruptInstance()
		{
			return ExcludeInstance == null;
		}

		internal static _003C_003Ec__DisplayClass3_1 DeleteInstance()
		{
			return ExcludeInstance;
		}
	}

	private readonly InitializerPrototype _ResolverFilter;

	internal static SystemFilter FindInstance;

	public SystemFilter(InitializerPrototype objectFactory)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af != 0)
		{
			num = 1;
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
				_ResolverFilter = objectFactory ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x1A7A0414 ^ 0x1A7A52BC));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add != 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	bool WorkerPrototype.Deserialize(StubReader parser, Type expectedType, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 1, 1, 2 })] Func<StubReader, Type, object> nestedObjectDeserializer, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] out object value)
	{
		bool canUpdate = true;
		Type implementedGenericInterface = ParserInterceptor.GetImplementedGenericInterface(expectedType, typeof(ICollection<>));
		Type type;
		IList list;
		if (implementedGenericInterface != null)
		{
			type = implementedGenericInterface.GetGenericArguments()[0];
			value = _ResolverFilter.Create(expectedType);
			list = value as IList;
			if (list == null)
			{
				canUpdate = ParserInterceptor.GetImplementedGenericInterface(expectedType, typeof(IList<>)) != null;
				list = (IList)Activator.CreateInstance(typeof(FactoryReader<>).MakeGenericType(type), value);
			}
		}
		else
		{
			if (!typeof(IList).IsAssignableFrom(expectedType))
			{
				value = null;
				return false;
			}
			type = typeof(object);
			value = _ResolverFilter.Create(expectedType);
			list = (IList)value;
		}
		DeserializeHelper(type, parser, nestedObjectDeserializer, list, canUpdate);
		return true;
	}

	internal static void DeserializeHelper(Type tItem, StubReader parser, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 1, 1, 2 })] Func<StubReader, Type, object> nestedObjectDeserializer, IList result, bool canUpdate)
	{
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
		_003C_003Ec__DisplayClass3_.m_CandidateFilter = result;
		_003C_003Ec__DisplayClass3_.m_ExpressionFilter = tItem;
		parser.Consume<RefFactory>();
		SpecificationFactory @event;
		while (!parser.TryConsume<SpecificationFactory>(out @event))
		{
			MappingFactory current = parser.Current;
			object obj = nestedObjectDeserializer(parser, _003C_003Ec__DisplayClass3_.m_ExpressionFilter);
			if (obj is IteratorPrototype iteratorPrototype)
			{
				if (!canUpdate)
				{
					throw new ReponseReader(current?.Start ?? QueueReader.m_CollectionReader, current?.End ?? QueueReader.m_CollectionReader, DicSingleton.gE3WbyDVW(-1059662249 ^ -1059668805));
				}
				_003C_003Ec__DisplayClass3_1 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass3_1();
				CS_0024_003C_003E8__locals8.registryFilter = _003C_003Ec__DisplayClass3_;
				CS_0024_003C_003E8__locals8.m_ProductFilter = CS_0024_003C_003E8__locals8.registryFilter.m_CandidateFilter.Add(CollectionBase.IsValueType(CS_0024_003C_003E8__locals8.registryFilter.m_ExpressionFilter) ? Activator.CreateInstance(CS_0024_003C_003E8__locals8.registryFilter.m_ExpressionFilter) : null);
				iteratorPrototype.ValueAvailable += [_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)] (object v) =>
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
							CS_0024_003C_003E8__locals8.registryFilter.m_CandidateFilter[CS_0024_003C_003E8__locals8.m_ProductFilter] = ContainerInterceptor.ChangeType(v, CS_0024_003C_003E8__locals8.registryFilter.m_ExpressionFilter);
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
							{
								num2 = 0;
							}
							break;
						}
					}
				};
			}
			else
			{
				_003C_003Ec__DisplayClass3_.m_CandidateFilter.Add(ContainerInterceptor.ChangeType(obj, _003C_003Ec__DisplayClass3_.m_ExpressionFilter));
			}
		}
	}

	internal static bool VisitInstance()
	{
		return FindInstance == null;
	}

	internal static SystemFilter OrderInstance()
	{
		return FindInstance;
	}
}
