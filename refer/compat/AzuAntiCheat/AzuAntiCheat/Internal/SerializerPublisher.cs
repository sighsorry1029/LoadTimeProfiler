using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AzuAntiCheat;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[Serializable]
[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
[HarmonyPatch]
internal class SerializerPublisher
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public string m_MapPublisher;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public WebRequest _HelperPublisher;

		[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
		public Func<Task, Task<WebResponse>> exceptionPublisher;

		internal static _003C_003Ec__DisplayClass27_0 SortVisitor;

		public _003C_003Ec__DisplayClass27_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)]
		internal void _003CPostToDiscord_003Eb__0(Task<Stream> t)
		{
			using StreamWriter streamWriter = new StreamWriter(t.Result);
			streamWriter.WriteAsync(m_MapPublisher).ContinueWith([_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)] (Task _) => _HelperPublisher.GetResponseAsync());
		}

		[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(0)]
		internal Task<WebResponse> _003CPostToDiscord_003Eb__1(Task _)
		{
			return _HelperPublisher.GetResponseAsync();
		}

		internal static bool InsertVisitor()
		{
			return SortVisitor == null;
		}

		internal static _003C_003Ec__DisplayClass27_0 FindVisitor()
		{
			return SortVisitor;
		}
	}

	[CompilerGenerated]
	private string producerPublisher;

	[CompilerGenerated]
	private string _ComparatorPublisher;

	[CompilerGenerated]
	private string m_DefinitionPublisher;

	[CompilerGenerated]
	private bool _ComposerPublisher;

	[CompilerGenerated]
	private List<ItemPublisher> globalPublisher;

	internal static SerializerPublisher PushVisitor;

	[FilterInvocation(Alias = "username")]
	public string Username
	{
		[CompilerGenerated]
		get
		{
			return producerPublisher;
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
				case 0:
					return;
				case 1:
					producerPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	[FilterInvocation(Alias = "avatar_url", ApplyNamingConventions = false)]
	public string AvatarUrl
	{
		[CompilerGenerated]
		get
		{
			return _ComparatorPublisher;
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
					_ComparatorPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 == 0)
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

	[FilterInvocation(Alias = "content")]
	public string Content
	{
		[CompilerGenerated]
		get
		{
			return m_DefinitionPublisher;
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
				case 0:
					return;
				case 1:
					m_DefinitionPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	[FilterInvocation(Alias = "tts")]
	public bool TTS
	{
		[CompilerGenerated]
		get
		{
			return _ComposerPublisher;
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
					_ComposerPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
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

	[FilterInvocation(Alias = "embeds")]
	public List<ItemPublisher> Embeds
	{
		[CompilerGenerated]
		get
		{
			return globalPublisher;
		}
		[CompilerGenerated]
		set
		{
			globalPublisher = value;
		}
	}

	public SerializerPublisher SetUsername(string username)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				Username = username;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 != 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public SerializerPublisher SetAvatar(string avatar)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return this;
			case 1:
				AvatarUrl = avatar;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public SerializerPublisher SetContent(string content)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				Content = content;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 != 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public SerializerPublisher SetTTS(bool tts)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				TTS = tts;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public ItemPublisher AddEmbed()
	{
		int num = 1;
		int num2 = num;
		ItemPublisher itemPublisher = default(ItemPublisher);
		while (true)
		{
			switch (num2)
			{
			default:
				Embeds.Add(itemPublisher);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec == 0)
				{
					num2 = 2;
				}
				break;
			case 1:
				itemPublisher = new ItemPublisher(this);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				return itemPublisher;
			}
		}
	}

	public void SendMessage(string url)
	{
		int num = 5;
		ModelSetter modelSetter = default(ModelSetter);
		object obj = default(object);
		StringReader input = default(StringReader);
		WebClient webClient = default(WebClient);
		string graph = default(string);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					break;
				case 3:
					modelSetter = new PublisherWriter().JsonCompatible().Build();
					num2 = 7;
					continue;
				default:
					obj = new GlobalSetter().Build().Deserialize(input);
					num2 = 3;
					continue;
				case 6:
					input = new StringReader(new PublisherWriter().WithNamingConvention(TagAuthentication.m_VisitorAuthentication).Build().Serialize(this));
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 != 0)
					{
						num2 = 0;
					}
					continue;
				case 5:
					webClient = new WebClient();
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
					{
						num2 = 4;
					}
					continue;
				case 4:
					webClient.Headers.Add(HttpRequestHeader.ContentType, DicSingleton.gE3WbyDVW(0x55F5513C ^ 0x55F56F40));
					num2 = 6;
					continue;
				case 7:
					if (obj != null)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_720885fe3aa142759e2adaa0a180d842 != 0)
						{
							num2 = 1;
						}
						continue;
					}
					throw new Exception(DicSingleton.gE3WbyDVW(-32257720 ^ -32245784));
				case 2:
					webClient.UploadString(url, modelSetter.Serialize(graph));
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
					{
						num2 = 6;
					}
					continue;
				case 8:
					return;
				}
				break;
			}
			graph = modelSetter.Serialize(obj);
			num = 2;
		}
	}

	public void SendMessageAsync(string url)
	{
		int num = 2;
		int num2 = num;
		StringReader input = default(StringReader);
		object obj = default(object);
		ModelSetter modelSetter = default(ModelSetter);
		while (true)
		{
			switch (num2)
			{
			case 2:
				input = new StringReader(new PublisherWriter().WithNamingConvention(TagAuthentication.m_VisitorAuthentication).Build().Serialize(this));
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 != 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				obj = new GlobalSetter().Build().Deserialize(input);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
				{
					num2 = 6;
				}
				break;
			case 3:
				return;
			case 7:
				return;
			case 4:
				AzuAnticheatPlugin.AcLogger.LogError(DicSingleton.gE3WbyDVW(0x7742C60 ^ 0x77412C0));
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
				{
					num2 = 3;
				}
				break;
			case 6:
				modelSetter = new PublisherWriter().JsonCompatible().Build();
				num2 = 5;
				break;
			default:
				PostToDiscord(modelSetter.Serialize(obj), url);
				num2 = 7;
				break;
			case 5:
				if (obj == null)
				{
					num2 = 4;
					break;
				}
				goto default;
			}
		}
	}

	public static void PostToDiscord(string content, string url)
	{
		int num = 5;
		int num2 = num;
		_003C_003Ec__DisplayClass27_0 _003C_003Ec__DisplayClass27_ = default(_003C_003Ec__DisplayClass27_0);
		while (true)
		{
			switch (num2)
			{
			case 6:
				if (!(url == ""))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
					{
						num2 = 0;
					}
					break;
				}
				return;
			case 5:
				_003C_003Ec__DisplayClass27_ = new _003C_003Ec__DisplayClass27_0();
				num2 = 4;
				break;
			case 1:
				return;
			case 10:
				return;
			default:
				_003C_003Ec__DisplayClass27_._HelperPublisher = WebRequest.Create(url);
				num2 = 9;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
				{
					num2 = 1;
				}
				break;
			case 7:
				_003C_003Ec__DisplayClass27_._HelperPublisher.GetRequestStreamAsync().ContinueWith(_003C_003Ec__DisplayClass27_._003CPostToDiscord_003Eb__0);
				num2 = 2;
				break;
			case 4:
				_003C_003Ec__DisplayClass27_.m_MapPublisher = content;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
				{
					num2 = 3;
				}
				break;
			case 2:
				return;
			case 8:
				_003C_003Ec__DisplayClass27_._HelperPublisher.ContentType = DicSingleton.gE3WbyDVW(0x3C33E48 ^ 0x3C30034);
				num2 = 7;
				break;
			case 3:
				if (_003C_003Ec__DisplayClass27_.m_MapPublisher == "")
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
					{
						num2 = 10;
					}
					break;
				}
				goto case 6;
			case 9:
				_003C_003Ec__DisplayClass27_._HelperPublisher.Method = DicSingleton.gE3WbyDVW(0x602C149E ^ 0x602C2A7C);
				num2 = 8;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef != 0)
				{
					num2 = 3;
				}
				break;
			}
		}
	}

	public SerializerPublisher()
	{
		GetterIssuer.DeleteInitializer();
		globalPublisher = new List<ItemPublisher>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ValidateVisitor()
	{
		return PushVisitor == null;
	}

	internal static SerializerPublisher EnableVisitor()
	{
		return PushVisitor;
	}
}
