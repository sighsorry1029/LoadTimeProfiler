using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using HarmonyLib;

namespace AzuAnticheat.Internal;

[Serializable]
[_003Ce9a22226_002Dacef_002D47d6_002D84be_002Db7e4ef6c1629_003ENullable(0)]
[_003C413bc804_002D6a31_002D48d8_002D9ff1_002Df244f71657f5_003ENullableContext(1)]
[HarmonyPatch]
internal class ItemPublisher
{
	[CompilerGenerated]
	private string contextPublisher;

	[CompilerGenerated]
	private string mapperPublisher;

	[CompilerGenerated]
	private string identifierPublisher;

	[CompilerGenerated]
	private string _TokenPublisher;

	[CompilerGenerated]
	private int m_CallbackPublisher;

	[CompilerGenerated]
	private CandidatePublisher m_RulesPublisher;

	[CompilerGenerated]
	private StatePublisher m_GetterPublisher;

	[CompilerGenerated]
	private InitializerPublisher _CodePublisher;

	[CompilerGenerated]
	private FacadePublisher _IndexerPublisher;

	[CompilerGenerated]
	private TaskPublisher m_MockPublisher;

	[CompilerGenerated]
	private InterpreterPublisher _MethodPublisher;

	[CompilerGenerated]
	private List<WatcherPublisher> templatePublisher;

	[CompilerGenerated]
	private SerializerPublisher _PredicatePublisher;

	private static ItemPublisher VisitVisitor;

	[FilterInvocation(Alias = "title")]
	public string Title
	{
		[CompilerGenerated]
		get
		{
			return contextPublisher;
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
					contextPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b == 0)
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

	[FilterInvocation(Alias = "description")]
	public string Description
	{
		[CompilerGenerated]
		get
		{
			return mapperPublisher;
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
					mapperPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
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

	[FilterInvocation(Alias = "url")]
	public string Url
	{
		[CompilerGenerated]
		get
		{
			return identifierPublisher;
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
					identifierPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
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

	[FilterInvocation(Alias = "timestamp")]
	public string Timestamp
	{
		[CompilerGenerated]
		get
		{
			return _TokenPublisher;
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
					_TokenPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	[FilterInvocation(Alias = "color")]
	public int Color
	{
		[CompilerGenerated]
		get
		{
			return m_CallbackPublisher;
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
					m_CallbackPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	[FilterInvocation(Alias = "footer")]
	public CandidatePublisher Footer
	{
		[CompilerGenerated]
		get
		{
			return m_RulesPublisher;
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
					m_RulesPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
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

	[FilterInvocation(Alias = "image")]
	public StatePublisher Image
	{
		[CompilerGenerated]
		get
		{
			return m_GetterPublisher;
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
					m_GetterPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
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

	[FilterInvocation(Alias = "thumbnail")]
	public InitializerPublisher Thumbnail
	{
		[CompilerGenerated]
		get
		{
			return _CodePublisher;
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
					_CodePublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	[FilterInvocation(Alias = "video")]
	public FacadePublisher Video
	{
		[CompilerGenerated]
		get
		{
			return _IndexerPublisher;
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
					_IndexerPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 == 0)
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

	[FilterInvocation(Alias = "provider")]
	public TaskPublisher Provider
	{
		[CompilerGenerated]
		get
		{
			return m_MockPublisher;
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
					m_MockPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	[FilterInvocation(Alias = "author")]
	public InterpreterPublisher Author
	{
		[CompilerGenerated]
		get
		{
			return _MethodPublisher;
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
					_MethodPublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
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

	[FilterInvocation(Alias = "fields")]
	public List<WatcherPublisher> Fields
	{
		[CompilerGenerated]
		get
		{
			return templatePublisher;
		}
		[CompilerGenerated]
		set
		{
			templatePublisher = value;
		}
	}

	[InterceptorInvocation]
	private SerializerPublisher MessageInstance
	{
		[CompilerGenerated]
		get
		{
			return _PredicatePublisher;
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
					_PredicatePublisher = value;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 != 0)
					{
						num2 = 0;
					}
					break;
				}
			}
		}
	}

	public ItemPublisher()
	{
		GetterIssuer.DeleteInitializer();
		templatePublisher = new List<WatcherPublisher>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public ItemPublisher(SerializerPublisher messageInstance)
	{
		GetterIssuer.DeleteInitializer();
		templatePublisher = new List<WatcherPublisher>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
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
			MessageInstance = messageInstance;
			num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d != 0)
			{
				num = 1;
			}
		}
	}

	public ItemPublisher SetTitle(string title)
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
				Title = title;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public ItemPublisher SetDescription(string description)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				Description = description;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public ItemPublisher SetUrl(string url)
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
				Url = url;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public ItemPublisher SetTimestamp(DateTime time)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				Timestamp = time.ToString(DicSingleton.gE3WbyDVW(0x9000142 ^ 0x9003FAC));
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public ItemPublisher SetColor(int color)
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
				Color = color;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public ItemPublisher SetFooter(string text, string icon = null, string proxyIcon = null)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				Footer = new CandidatePublisher
				{
					Text = text,
					Icon = icon,
					ProxyIcon = proxyIcon
				};
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public ItemPublisher SetImage(string url, string height = null, string width = null, string proxyIcon = null)
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
				Image = new StatePublisher
				{
					Url = url,
					Height = height,
					Width = width,
					ProxyIcon = proxyIcon
				};
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public ItemPublisher SetThumbnail(string url, string height = null, string width = null, string proxyIcon = null)
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
				Thumbnail = new InitializerPublisher
				{
					Url = url,
					Height = height,
					Width = width,
					ProxyIcon = proxyIcon
				};
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public ItemPublisher SetVideo(string url, string height = null, string width = null, string proxyVideo = null)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				Video = new FacadePublisher
				{
					Url = url,
					Height = height,
					Width = width,
					ProxyVideo = proxyVideo
				};
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 != 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public ItemPublisher SetProvider(string name, string url = null)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				Provider = new TaskPublisher
				{
					Name = name,
					Url = url
				};
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public ItemPublisher SetAuthor(string name, string url = null, string icon = null, string proxyIcon = null)
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
				Author = new InterpreterPublisher
				{
					Name = name,
					Icon = icon,
					ProxyIcon = proxyIcon,
					Url = url
				};
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public ItemPublisher AddField(string key, string value, bool inline = false)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				Fields.Add(new WatcherPublisher
				{
					Key = key,
					Value = value,
					Inline = inline
				});
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
				{
					num2 = 0;
				}
				break;
			default:
				return this;
			}
		}
	}

	public SerializerPublisher Build()
	{
		return MessageInstance;
	}

	internal static bool OrderVisitor()
	{
		return VisitVisitor == null;
	}

	internal static ItemPublisher UpdateVisitor()
	{
		return VisitVisitor;
	}
}
