using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class StateFilter : WorkerPrototype
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public IDictionary decoratorFilter;

		internal static _003C_003Ec__DisplayClass3_0 ComputeInstance;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool DisableInstance()
		{
			return ComputeInstance == null;
		}

		internal static _003C_003Ec__DisplayClass3_0 QueryInstance()
		{
			return ComputeInstance;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_1
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public object broadcasterFilter;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public object _WorkerFilter;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public _003C_003Ec__DisplayClass3_0 taskFilter;

		internal static _003C_003Ec__DisplayClass3_1 AwakeInstance;

		public _003C_003Ec__DisplayClass3_1()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
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
				case 1:
					taskFilter.decoratorFilter[v] = broadcasterFilter;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc == 0)
					{
						num2 = 0;
					}
					break;
				case 0:
					return;
				}
			}
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
		internal void _003CDeserializeHelper_003Eb__1(object v)
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
					taskFilter.decoratorFilter[_WorkerFilter] = v;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		internal static bool InstantiateInstance()
		{
			return AwakeInstance == null;
		}

		internal static _003C_003Ec__DisplayClass3_1 LoginInstance()
		{
			return AwakeInstance;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_2
	{
		public bool m_UtilsFilter;

		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public _003C_003Ec__DisplayClass3_1 _TestsFilter;

		private static _003C_003Ec__DisplayClass3_2 ConnectInstance;

		public _003C_003Ec__DisplayClass3_2()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 != 0)
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
		internal void _003CDeserializeHelper_003Eb__2(object v)
		{
			int num = 2;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 4:
					return;
				case 1:
					_TestsFilter._WorkerFilter = v;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 != 0)
					{
						num2 = 5;
					}
					break;
				case 3:
					_TestsFilter.taskFilter.decoratorFilter[v] = _TestsFilter.broadcasterFilter;
					num2 = 4;
					break;
				case 0:
					return;
				case 5:
					m_UtilsFilter = true;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
					{
						num2 = 0;
					}
					break;
				case 2:
					if (!m_UtilsFilter)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
						{
							num2 = 1;
						}
						break;
					}
					goto case 3;
				}
			}
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
		internal void _003CDeserializeHelper_003Eb__3(object v)
		{
			int num = 4;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 3:
					_TestsFilter.taskFilter.decoratorFilter[_TestsFilter._WorkerFilter] = v;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
					{
						num2 = 2;
					}
					break;
				case 2:
					return;
				case 1:
					return;
				case 4:
					if (!m_UtilsFilter)
					{
						_TestsFilter.broadcasterFilter = v;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
						{
							num2 = 0;
						}
					}
					else
					{
						num2 = 3;
					}
					break;
				default:
					m_UtilsFilter = true;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}

		internal static bool StartInstance()
		{
			return ConnectInstance == null;
		}

		internal static _003C_003Ec__DisplayClass3_2 RemoveInstance()
		{
			return ConnectInstance;
		}
	}

	private readonly InitializerPrototype m_ValueFilter;

	internal static StateFilter FillInstance;

	public StateFilter(InitializerPrototype objectFactory)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 != 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 1:
				return;
			}
			m_ValueFilter = objectFactory ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x15823EC4 ^ 0x1582686C));
			num = 1;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
			{
				num = 0;
			}
		}
	}

	bool WorkerPrototype.Deserialize(StubReader parser, Type expectedType, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 1, 1, 2 })] Func<StubReader, Type, object> nestedObjectDeserializer, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] out object value)
	{
		Type implementedGenericInterface = ParserInterceptor.GetImplementedGenericInterface(expectedType, typeof(IDictionary<, >));
		Type type;
		Type type2;
		IDictionary dictionary;
		if (implementedGenericInterface != null)
		{
			Type[] genericArguments = implementedGenericInterface.GetGenericArguments();
			type = genericArguments[0];
			type2 = genericArguments[1];
			value = m_ValueFilter.Create(expectedType);
			dictionary = value as IDictionary;
			if (dictionary == null)
			{
				dictionary = (IDictionary)Activator.CreateInstance(typeof(WriterReader<, >).MakeGenericType(type, type2), value);
			}
		}
		else
		{
			if (!typeof(IDictionary).IsAssignableFrom(expectedType))
			{
				value = null;
				return false;
			}
			type = typeof(object);
			type2 = typeof(object);
			value = m_ValueFilter.Create(expectedType);
			dictionary = (IDictionary)value;
		}
		DeserializeHelper(type, type2, parser, nestedObjectDeserializer, dictionary);
		return true;
	}

	private static void DeserializeHelper(Type tKey, Type tValue, StubReader parser, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 1, 1, 1, 2 })] Func<StubReader, Type, object> nestedObjectDeserializer, IDictionary result)
	{
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
		_003C_003Ec__DisplayClass3_.decoratorFilter = result;
		parser.Consume<QueueFactory>();
		ListFactory @event;
		while (!parser.TryConsume<ListFactory>(out @event))
		{
			_003C_003Ec__DisplayClass3_1 CS_0024_003C_003E8__locals26 = new _003C_003Ec__DisplayClass3_1();
			CS_0024_003C_003E8__locals26.taskFilter = _003C_003Ec__DisplayClass3_;
			CS_0024_003C_003E8__locals26._WorkerFilter = nestedObjectDeserializer(parser, tKey);
			CS_0024_003C_003E8__locals26.broadcasterFilter = nestedObjectDeserializer(parser, tValue);
			IteratorPrototype iteratorPrototype = CS_0024_003C_003E8__locals26.broadcasterFilter as IteratorPrototype;
			if (CS_0024_003C_003E8__locals26._WorkerFilter is IteratorPrototype iteratorPrototype2)
			{
				if (iteratorPrototype == null)
				{
					iteratorPrototype2.ValueAvailable += [_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)] (object v) =>
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
								CS_0024_003C_003E8__locals26.taskFilter.decoratorFilter[v] = CS_0024_003C_003E8__locals26.broadcasterFilter;
								num2 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc == 0)
								{
									num2 = 0;
								}
								break;
							case 0:
								return;
							}
						}
					};
					continue;
				}
				_003C_003Ec__DisplayClass3_2 CS_0024_003C_003E8__locals24 = new _003C_003Ec__DisplayClass3_2();
				CS_0024_003C_003E8__locals24._TestsFilter = CS_0024_003C_003E8__locals26;
				CS_0024_003C_003E8__locals24.m_UtilsFilter = false;
				iteratorPrototype2.ValueAvailable += [_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)] (object v) =>
				{
					int num = 2;
					int num2 = num;
					while (true)
					{
						switch (num2)
						{
						default:
							return;
						case 4:
							return;
						case 1:
							CS_0024_003C_003E8__locals24._TestsFilter._WorkerFilter = v;
							num2 = 5;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 != 0)
							{
								num2 = 5;
							}
							break;
						case 3:
							CS_0024_003C_003E8__locals24._TestsFilter.taskFilter.decoratorFilter[v] = CS_0024_003C_003E8__locals24._TestsFilter.broadcasterFilter;
							num2 = 4;
							break;
						case 0:
							return;
						case 5:
							CS_0024_003C_003E8__locals24.m_UtilsFilter = true;
							num2 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
							{
								num2 = 0;
							}
							break;
						case 2:
							if (!CS_0024_003C_003E8__locals24.m_UtilsFilter)
							{
								num2 = 1;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
								{
									num2 = 1;
								}
								break;
							}
							goto case 3;
						}
					}
				};
				iteratorPrototype.ValueAvailable += [_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)] (object v) =>
				{
					int num = 4;
					int num2 = num;
					while (true)
					{
						switch (num2)
						{
						case 3:
							CS_0024_003C_003E8__locals24._TestsFilter.taskFilter.decoratorFilter[CS_0024_003C_003E8__locals24._TestsFilter._WorkerFilter] = v;
							num2 = 2;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
							{
								num2 = 2;
							}
							break;
						case 2:
							return;
						case 1:
							return;
						case 4:
							if (!CS_0024_003C_003E8__locals24.m_UtilsFilter)
							{
								CS_0024_003C_003E8__locals24._TestsFilter.broadcasterFilter = v;
								num2 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
								{
									num2 = 0;
								}
							}
							else
							{
								num2 = 3;
							}
							break;
						default:
							CS_0024_003C_003E8__locals24.m_UtilsFilter = true;
							num2 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e != 0)
							{
								num2 = 0;
							}
							break;
						}
					}
				};
				continue;
			}
			if (iteratorPrototype == null)
			{
				CS_0024_003C_003E8__locals26.taskFilter.decoratorFilter[CS_0024_003C_003E8__locals26._WorkerFilter] = CS_0024_003C_003E8__locals26.broadcasterFilter;
				continue;
			}
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
						CS_0024_003C_003E8__locals26.taskFilter.decoratorFilter[CS_0024_003C_003E8__locals26._WorkerFilter] = v;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
						{
							num2 = 0;
						}
						break;
					}
				}
			};
		}
	}

	internal static bool FlushInstance()
	{
		return FillInstance == null;
	}

	internal static StateFilter DestroyInstance()
	{
		return FillInstance;
	}
}
