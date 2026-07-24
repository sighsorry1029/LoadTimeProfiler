using System;
using System.IO;

namespace AzuAnticheat.Internal;

internal sealed class AdapterSetter : ModelSetter
{
	private readonly RepositorySetter procSetter;

	private readonly ExceptionInterpreter _RoleWriter;

	internal static AdapterSetter ComputeStatus;

	public AdapterSetter()
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(new PublisherWriter().BuildValueSerializer(), ExceptionInterpreter.m_GetterInterpreter);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	private AdapterSetter(RepositorySetter valueSerializer, ExceptionInterpreter emitterSettings)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
		{
			num = 0;
		}
		while (true)
		{
			switch (num)
			{
			case 2:
				return;
			default:
				procSetter = valueSerializer ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x120E76C ^ 0x120BB3A));
				num = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
				{
					num = 1;
				}
				break;
			case 1:
				_RoleWriter = emitterSettings ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x4F8CB66E ^ 0x4F8CEA16));
				num = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
				{
					num = 2;
				}
				break;
			}
		}
	}

	public static AdapterSetter FromValueSerializer(RepositorySetter valueSerializer, ExceptionInterpreter emitterSettings)
	{
		return new AdapterSetter(valueSerializer, emitterSettings);
	}

	public string Serialize(object? graph)
	{
		int num = 1;
		int num2 = num;
		StringWriter stringWriter = default(StringWriter);
		string result = default(string);
		while (true)
		{
			switch (num2)
			{
			case 1:
				stringWriter = new StringWriter();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
				{
					num2 = 0;
				}
				continue;
			default:
				try
				{
					Serialize(stringWriter, graph);
					int num3 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
					{
						num3 = 0;
					}
					while (true)
					{
						switch (num3)
						{
						default:
							result = stringWriter.ToString();
							num3 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 != 0)
							{
								num3 = 0;
							}
							continue;
						case 1:
							break;
						}
						break;
					}
				}
				finally
				{
					int num4;
					if (stringWriter == null)
					{
						num4 = 2;
						goto IL_00c0;
					}
					goto IL_00d6;
					IL_00d6:
					((IDisposable)stringWriter).Dispose();
					num4 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
					{
						num4 = 1;
					}
					goto IL_00c0;
					IL_00c0:
					switch (num4)
					{
					case 2:
						goto end_IL_00ab;
					case 1:
						goto end_IL_00ab;
					}
					goto IL_00d6;
					end_IL_00ab:;
				}
				break;
			case 2:
				break;
			}
			break;
		}
		return result;
	}

	public string Serialize(object? graph, Type type)
	{
		int num = 1;
		int num2 = num;
		StringWriter stringWriter = default(StringWriter);
		string result = default(string);
		while (true)
		{
			switch (num2)
			{
			case 1:
				stringWriter = new StringWriter();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 == 0)
				{
					num2 = 0;
				}
				continue;
			default:
				try
				{
					Serialize(stringWriter, graph, type);
					int num3 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
					{
						num3 = 0;
					}
					while (true)
					{
						switch (num3)
						{
						default:
							result = stringWriter.ToString();
							num3 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba != 0)
							{
								num3 = 0;
							}
							continue;
						case 1:
							break;
						}
						break;
					}
				}
				finally
				{
					int num4;
					if (stringWriter == null)
					{
						num4 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 != 0)
						{
							num4 = 2;
						}
						goto IL_00d1;
					}
					goto IL_00e7;
					IL_00d1:
					switch (num4)
					{
					default:
						goto end_IL_00ac;
					case 1:
						break;
					case 2:
						goto end_IL_00ac;
					case 0:
						goto end_IL_00ac;
					}
					goto IL_00e7;
					IL_00e7:
					((IDisposable)stringWriter).Dispose();
					num4 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 != 0)
					{
						num4 = 0;
					}
					goto IL_00d1;
					end_IL_00ac:;
				}
				break;
			case 2:
				break;
			}
			break;
		}
		return result;
	}

	public void Serialize(TextWriter writer, object? graph)
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
				Serialize(new CollectionAttribute(writer, _RoleWriter), graph);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public void Serialize(TextWriter writer, object? graph, Type type)
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
				Serialize(new CollectionAttribute(writer, _RoleWriter), graph, type);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	public void Serialize(MockInterpreter emitter, object? graph)
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 3:
				if (emitter != null)
				{
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
					{
						num2 = 2;
					}
					break;
				}
				goto case 1;
			case 0:
				return;
			case 1:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1064640644 ^ -1064664090));
			case 2:
				EmitDocument(emitter, graph, null);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public void Serialize(MockInterpreter emitter, object? graph, Type type)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 4:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1549341817 ^ -1549353701));
			case 2:
				EmitDocument(emitter, graph, type);
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
				{
					num2 = 0;
				}
				break;
			case 3:
				return;
			default:
				throw new ArgumentNullException(DicSingleton.gE3WbyDVW(-1123846595 ^ -1123865945));
			case 1:
				if (emitter != null)
				{
					if (!(type == null))
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 == 0)
						{
							num2 = 1;
						}
						break;
					}
					goto case 4;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private void EmitDocument(MockInterpreter emitter, object? graph, Type? type)
	{
		int num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				return;
			case 2:
				procSetter.SerializeValue(emitter, graph, type);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				emitter.Emit(new TaskSingleton(isImplicit: true));
				num2 = 5;
				break;
			case 4:
				emitter.Emit(new ServerSingleton());
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
				{
					num2 = 3;
				}
				break;
			case 3:
				emitter.Emit(new TestsSingleton());
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
				{
					num2 = 2;
				}
				break;
			case 5:
				emitter.Emit(new WrapperSingleton());
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 != 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	internal static bool DisableStatus()
	{
		return ComputeStatus == null;
	}

	internal static AdapterSetter QueryStatus()
	{
		return ComputeStatus;
	}
}
