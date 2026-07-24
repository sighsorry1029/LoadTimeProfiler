using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class StubPrototype : EventPrototype
{
	private readonly ClientPrototype m_PolicyPrototype;

	private readonly WrapperReader _StrategyPrototype;

	internal static StubPrototype InstantiateRole;

	public StubPrototype()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(new ProcessorPrototype().BuildValueSerializer(), WrapperReader._ErrorReader);
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

	private StubPrototype(ClientPrototype valueSerializer, WrapperReader emitterSettings)
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
			case 0:
				return;
			case 2:
				m_PolicyPrototype = valueSerializer ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1863475926 ^ -1863466628));
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
				{
					num = 1;
				}
				break;
			case 1:
				_StrategyPrototype = emitterSettings ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x59C84793 ^ 0x59C81BEB));
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
				{
					num = 0;
				}
				break;
			}
		}
	}

	public static StubPrototype FromValueSerializer(ClientPrototype valueSerializer, WrapperReader emitterSettings)
	{
		return new StubPrototype(valueSerializer, emitterSettings);
	}

	public void Serialize(TextWriter writer, object graph)
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
				Serialize(new MethodReader(writer, _StrategyPrototype), graph);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public string Serialize(object graph)
	{
		int num = 2;
		int num2 = num;
		StringWriter stringWriter = default(StringWriter);
		string result = default(string);
		while (true)
		{
			switch (num2)
			{
			case 1:
				try
				{
					Serialize(stringWriter, graph);
					int num3 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
					{
						num3 = 1;
					}
					while (true)
					{
						switch (num3)
						{
						case 1:
							result = stringWriter.ToString();
							num3 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
							{
								num3 = 0;
							}
							continue;
						case 0:
							break;
						}
						break;
					}
				}
				finally
				{
					if (stringWriter != null)
					{
						int num4 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
						{
							num4 = 0;
						}
						while (true)
						{
							switch (num4)
							{
							case 1:
								((IDisposable)stringWriter).Dispose();
								num4 = 0;
								if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 != 0)
								{
									num4 = 0;
								}
								continue;
							case 0:
								break;
							}
							break;
						}
					}
				}
				goto default;
			default:
				return result;
			case 2:
				stringWriter = new StringWriter();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	public void Serialize(TextWriter writer, object graph, Type type)
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
				Serialize(new MethodReader(writer, _StrategyPrototype), graph, type);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public void Serialize(ModelReader emitter, object graph)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				return;
			default:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1614185587 ^ -1614207209));
			case 1:
				if (emitter != null)
				{
					EmitDocument(emitter, graph, null);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 != 0)
					{
						num2 = 2;
					}
				}
				else
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
					{
						num2 = 0;
					}
				}
				break;
			}
		}
	}

	public void Serialize(ModelReader emitter, object graph, Type type)
	{
		int num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				return;
			case 4:
				if (emitter != null)
				{
					num2 = 3;
					break;
				}
				goto case 2;
			case 2:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1273961441 ^ -1273972603));
			case 3:
				if (type == null)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec != 0)
					{
						num2 = 0;
					}
					break;
				}
				EmitDocument(emitter, graph, type);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 != 0)
				{
					num2 = 1;
				}
				break;
			default:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x4097B854 ^ 0x4097EEC8));
			}
		}
	}

	private void EmitDocument(ModelReader emitter, object graph, [_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] Type type)
	{
		int num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 4:
				emitter.Emit(new PublisherSetter());
				num2 = 3;
				break;
			case 1:
				m_PolicyPrototype.SerializeValue(emitter, graph, type);
				num2 = 5;
				break;
			case 5:
				emitter.Emit(new ProcessorFactory(isImplicit: true));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af != 0)
				{
					num2 = 0;
				}
				break;
			case 3:
				emitter.Emit(new DicFactory());
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 == 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				return;
			default:
				emitter.Emit(new RoleSetter());
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 == 0)
				{
					num2 = 2;
				}
				break;
			}
		}
	}

	internal static bool LoginRole()
	{
		return InstantiateRole == null;
	}

	internal static StubPrototype ConnectRole()
	{
		return InstantiateRole;
	}
}
