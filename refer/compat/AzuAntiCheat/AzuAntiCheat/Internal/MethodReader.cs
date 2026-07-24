using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
internal class MethodReader : ModelReader
{
	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)]
	private class InstanceReader
	{
		public HelperReader m_OrderReader;

		public bool _ContainerReader;

		private static InstanceReader SortService;

		public InstanceReader()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool InsertService()
		{
			return SortService == null;
		}

		internal static InstanceReader FindService()
		{
			return SortService;
		}
	}

	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	private class IteratorReader
	{
		public string _ClientReader;

		public string m_RecordReader;

		internal static IteratorReader VisitService;

		public IteratorReader()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool OrderService()
		{
			return VisitService == null;
		}

		internal static IteratorReader UpdateService()
		{
			return VisitService;
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)]
	private class ServiceReader
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)]
		public string _BridgeReader;

		public bool _ParameterReader;

		public bool m_StatusReader;

		public bool merchantReader;

		public bool testReader;

		public bool m_AttrReader;

		public bool _MessageReader;

		public RuleFactory _ExporterReader;

		internal static ServiceReader SearchService;

		public ServiceReader()
		{
			GetterIssuer.DeleteInitializer();
			_BridgeReader = string.Empty;
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal static bool StopService()
		{
			return SearchService == null;
		}

		internal static ServiceReader ExcludeService()
		{
			return SearchService;
		}
	}

	private static readonly Regex m_TemplateReader;

	private readonly TextWriter _PredicateReader;

	private readonly bool watcherReader;

	private readonly int _CustomerReader;

	private readonly bool systemReader;

	private readonly bool resolverReader;

	private readonly int _CandidateReader;

	private readonly int m_ExpressionReader;

	private RegReader m_ProductReader;

	private readonly Stack<RegReader> registryReader;

	private readonly Queue<MappingFactory> m_StateReader;

	private readonly Stack<int> valueReader;

	private readonly StateFactory m_DecoratorReader;

	private int broadcasterReader;

	private int m_WorkerReader;

	private bool taskReader;

	private bool m_UtilsReader;

	private int m_TestsReader;

	private bool _InitializerReader;

	private bool pageReader;

	private readonly bool _ParserReader;

	private bool _RequestReader;

	private readonly InstanceReader paramReader;

	private readonly IteratorReader _FacadeReader;

	private readonly ServiceReader eventReader;

	private static MethodReader PushService;

	public MethodReader(TextWriter output)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(output, WrapperReader._ErrorReader);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public MethodReader(TextWriter output, int bestIndent)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(output, bestIndent, int.MaxValue);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public MethodReader(TextWriter output, int bestIndent, int bestWidth)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(output, bestIndent, bestWidth, isCanonical: false);
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public MethodReader(TextWriter output, int bestIndent, int bestWidth, bool isCanonical)
	{
		GetterIssuer.DeleteInitializer();
		this._002Ector(output, new WrapperReader(bestIndent, bestWidth, isCanonical, 1024));
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	public MethodReader(TextWriter output, WrapperReader settings)
	{
		GetterIssuer.DeleteInitializer();
		registryReader = new Stack<RegReader>();
		m_StateReader = new Queue<MappingFactory>();
		valueReader = new Stack<int>();
		m_DecoratorReader = new StateFactory();
		paramReader = new InstanceReader();
		_FacadeReader = new IteratorReader();
		eventReader = new ServiceReader();
		base._002Ector();
		int num = 1;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c == 0)
		{
			num = 1;
		}
		while (true)
		{
			switch (num)
			{
			case 2:
				m_ExpressionReader = settings.BestWidth;
				num = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 != 0)
				{
					num = 3;
				}
				break;
			case 1:
				_CandidateReader = settings.BestIndent;
				num = 2;
				break;
			case 3:
				systemReader = settings.IsCanonical;
				num = 4;
				break;
			case 6:
				_ParserReader = !settings.IndentSequences;
				num = 7;
				break;
			case 7:
				_PredicateReader = output;
				num = 5;
				break;
			case 5:
				watcherReader = IsUnicode(output.Encoding);
				num = 8;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b != 0)
				{
					num = 8;
				}
				break;
			default:
				resolverReader = settings.SkipAnchorName;
				num = 6;
				break;
			case 4:
				_CustomerReader = settings.MaxSimpleKeyLength;
				num = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_fa00cea3f01e4495870203e04cba70c5 == 0)
				{
					num = 0;
				}
				break;
			case 8:
				return;
			}
		}
	}

	public void Emit(MappingFactory @event)
	{
		int num = 2;
		int num2 = num;
		MappingFactory evt = default(MappingFactory);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 0:
				return;
			case 4:
				try
				{
					AnalyzeEvent(evt);
					int num3 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 != 0)
					{
						num3 = 0;
					}
					while (true)
					{
						switch (num3)
						{
						default:
							StateMachine(evt);
							num3 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
							{
								num3 = 1;
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
					m_StateReader.Dequeue();
					int num4 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
					{
						num4 = 0;
					}
					switch (num4)
					{
					case 0:
						break;
					}
				}
				goto case 1;
			case 2:
				m_StateReader.Enqueue(@event);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 == 0)
				{
					num2 = 1;
				}
				continue;
			case 1:
			case 5:
				if (NeedMoreEvents())
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 != 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			case 3:
				break;
			}
			evt = m_StateReader.Peek();
			num2 = 4;
		}
	}

	private bool NeedMoreEvents()
	{
		if (m_StateReader.Count == 0)
		{
			return true;
		}
		int num;
		switch (m_StateReader.Peek().Type)
		{
		case (SchemaCompareFilterSetting)3:
			num = 1;
			break;
		case (SchemaCompareFilterSetting)7:
			num = 2;
			break;
		case (SchemaCompareFilterSetting)9:
			num = 3;
			break;
		default:
			return false;
		}
		if (m_StateReader.Count > num)
		{
			return false;
		}
		int num2 = 0;
		using (Queue<MappingFactory>.Enumerator enumerator = m_StateReader.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				switch (enumerator.Current.Type)
				{
				case (SchemaCompareFilterSetting)3:
				case (SchemaCompareFilterSetting)7:
				case (SchemaCompareFilterSetting)9:
					num2++;
					break;
				case (SchemaCompareFilterSetting)4:
				case (SchemaCompareFilterSetting)8:
				case (SchemaCompareFilterSetting)10:
					num2--;
					break;
				}
				if (num2 != 0)
				{
					continue;
				}
				return false;
			}
		}
		return true;
	}

	private void AnalyzeEvent(MappingFactory evt)
	{
		int num = 10;
		ClassFactory classFactory = default(ClassFactory);
		ListenerFactory listenerFactory = default(ListenerFactory);
		TagFactory tagFactory = default(TagFactory);
		ValueFactory tag = default(ValueFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 10:
					paramReader.m_OrderReader = HelperReader._ExceptionReader;
					num2 = 9;
					continue;
				case 11:
					if (!systemReader)
					{
						num2 = 14;
						continue;
					}
					break;
				case 21:
					AnalyzeScalar(classFactory);
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d != 0)
					{
						num2 = 4;
					}
					continue;
				case 5:
					if (listenerFactory == null)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
						{
							num2 = 3;
						}
						continue;
					}
					goto case 15;
				case 2:
					if (classFactory == null)
					{
						num2 = 18;
						continue;
					}
					goto case 21;
				case 0:
					return;
				case 3:
					return;
				case 17:
					return;
				case 19:
					return;
				case 7:
					AnalyzeAnchor(tagFactory.Value, isAlias: true);
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
					{
						num2 = 13;
					}
					continue;
				case 4:
				case 18:
					AnalyzeAnchor(listenerFactory.Anchor, isAlias: false);
					num2 = 6;
					continue;
				case 9:
					_FacadeReader._ClientReader = null;
					num2 = 8;
					continue;
				case 15:
					classFactory = evt as ClassFactory;
					num2 = 2;
					continue;
				case 22:
					if (tagFactory == null)
					{
						num2 = 12;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
						{
							num2 = 10;
						}
						continue;
					}
					goto case 7;
				case 20:
					if (tag.IsEmpty)
					{
						num2 = 16;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 != 0)
						{
							num2 = 17;
						}
						continue;
					}
					goto case 11;
				case 8:
					_FacadeReader.m_RecordReader = null;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 != 0)
					{
						num2 = 16;
					}
					continue;
				case 1:
					break;
				case 13:
					return;
				case 12:
					listenerFactory = evt as ListenerFactory;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
					{
						num2 = 1;
					}
					continue;
				case 6:
					tag = listenerFactory.Tag;
					num2 = 20;
					continue;
				case 14:
					if (!listenerFactory.IsCanonical)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					break;
				case 16:
					tagFactory = evt as TagFactory;
					num2 = 22;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4fda3adbb4ec45bdb14fe2ef97e570a8 == 0)
					{
						num2 = 5;
					}
					continue;
				}
				break;
			}
			AnalyzeTag(listenerFactory.Tag);
			num = 19;
		}
	}

	private void AnalyzeAnchor(HelperReader anchor, bool isAlias)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				paramReader._ContainerReader = isAlias;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 2:
				paramReader.m_OrderReader = anchor;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	private void AnalyzeScalar(ClassFactory scalar)
	{
		int num = 10;
		bool flag = default(bool);
		bool flag4 = default(bool);
		IdentifierReader<CandidateFactory> identifierReader = default(IdentifierReader<CandidateFactory>);
		bool flag14 = default(bool);
		bool flag7 = default(bool);
		bool flag16 = default(bool);
		bool flag10 = default(bool);
		string value = default(string);
		bool flag15 = default(bool);
		bool flag13 = default(bool);
		bool flag5 = default(bool);
		bool flag11 = default(bool);
		bool flag8 = default(bool);
		bool flag19 = default(bool);
		bool flag12 = default(bool);
		bool flag18 = default(bool);
		bool flag9 = default(bool);
		bool flag6 = default(bool);
		bool flag2 = default(bool);
		bool flag17 = default(bool);
		bool flag3 = default(bool);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					flag = false;
					num2 = 46;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a == 0)
					{
						num2 = 8;
					}
					continue;
				case 36:
				case 100:
				case 138:
					flag4 = identifierReader.IsWhiteBreakOrZero();
					num2 = 137;
					continue;
				case 137:
					identifierReader.Skip(1);
					num2 = 79;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
					{
						num2 = 31;
					}
					continue;
				case 63:
					flag14 = true;
					num2 = 29;
					continue;
				case 34:
					eventReader.m_AttrReader = true;
					num2 = 91;
					continue;
				case 31:
					flag7 = false;
					num2 = 19;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
					{
						num2 = 97;
					}
					continue;
				case 5:
					flag16 = false;
					num2 = 68;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
					{
						num2 = 109;
					}
					continue;
				case 24:
					if (flag10)
					{
						num2 = 70;
						continue;
					}
					goto case 108;
				case 71:
					if (!value.StartsWith(DicSingleton.gE3WbyDVW(0x1A7A0414 ^ 0x1A7A7D4C), StringComparison.Ordinal))
					{
						num2 = 53;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
						{
							num2 = 59;
						}
						continue;
					}
					goto case 12;
				case 38:
					flag15 = true;
					num2 = 111;
					continue;
				case 88:
					eventReader._ParameterReader = false;
					num2 = 81;
					continue;
				case 108:
					if (flag13)
					{
						num2 = 38;
						continue;
					}
					goto case 111;
				case 106:
					flag7 = true;
					num2 = 41;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_059dca8918734d0cba05b11d6ff17db4 != 0)
					{
						num2 = 65;
					}
					continue;
				case 113:
					flag5 = true;
					num2 = 49;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 != 0)
					{
						num2 = 69;
					}
					continue;
				case 10:
					value = scalar.Value;
					num2 = 9;
					continue;
				case 116:
					if (identifierReader.Check(DicSingleton.gE3WbyDVW(-1273961441 ^ -1273979523)))
					{
						num2 = 103;
						continue;
					}
					goto case 47;
				case 18:
					flag11 = true;
					num2 = 61;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 != 0)
					{
						num2 = 41;
					}
					continue;
				case 58:
					eventReader.merchantReader = false;
					num2 = 107;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c != 0)
					{
						num2 = 11;
					}
					continue;
				case 124:
					if (flag15)
					{
						num2 = 93;
						continue;
					}
					goto case 136;
				case 28:
					if (flag8)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
						{
							num2 = 84;
						}
						continue;
					}
					goto case 37;
				case 133:
					if (!flag14)
					{
						num2 = 135;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 != 0)
						{
							num2 = 120;
						}
						continue;
					}
					goto case 104;
				case 112:
					return;
				case 53:
					flag19 = false;
					num2 = 129;
					continue;
				case 13:
					flag10 = true;
					num2 = 126;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
					{
						num2 = 114;
					}
					continue;
				case 25:
					eventReader.m_StatusReader = false;
					num2 = 58;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
					{
						num2 = 58;
					}
					continue;
				case 32:
					flag12 = true;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
					{
						num2 = 22;
					}
					continue;
				case 62:
					flag12 = false;
					num2 = 19;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 != 0)
					{
						num2 = 115;
					}
					continue;
				case 129:
					flag18 = false;
					num2 = 24;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
					{
						num2 = 127;
					}
					continue;
				case 128:
					eventReader.merchantReader = false;
					num2 = 49;
					continue;
				case 47:
					if (identifierReader.Check(DicSingleton.gE3WbyDVW(-1580624393 ^ -1580602241)))
					{
						num2 = 30;
						continue;
					}
					goto case 37;
				case 73:
					if (identifierReader.IsPrintable())
					{
						num2 = 28;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
						{
							num2 = 40;
						}
						continue;
					}
					goto case 18;
				case 42:
					flag13 = false;
					num2 = 62;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7c090e91676a43d3a96c5ddb10e58b83 != 0)
					{
						num2 = 27;
					}
					continue;
				case 139:
					eventReader.m_StatusReader = false;
					num2 = 74;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
					{
						num2 = 28;
					}
					continue;
				case 79:
					if (!identifierReader.EndOfInput)
					{
						num2 = 27;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_20051c2b0677443ab62610b7fdb1fa17 != 0)
						{
							num2 = 95;
						}
						continue;
					}
					goto case 54;
				case 44:
					if (identifierReader.Check(DicSingleton.gE3WbyDVW(-1466472923 ^ -1466490955)))
					{
						num2 = 113;
						continue;
					}
					goto case 69;
				case 56:
					flag9 = true;
					num2 = 78;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 == 0)
					{
						num2 = 90;
					}
					continue;
				case 68:
					flag4 = true;
					num = 45;
					break;
				case 78:
					flag7 = true;
					num2 = 33;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
					{
						num2 = 114;
					}
					continue;
				case 110:
					eventReader.merchantReader = true;
					num2 = 43;
					continue;
				case 119:
					if (!(scalar.Tag == DicSingleton.gE3WbyDVW(0x6CF51E1A ^ 0x6CF57BE4)))
					{
						eventReader._ParameterReader = false;
						num2 = 11;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
						{
							num2 = 8;
						}
					}
					else
					{
						num2 = 88;
					}
					continue;
				case 96:
				case 117:
					if (!flag18)
					{
						num2 = 57;
						continue;
					}
					goto case 21;
				case 109:
					flag10 = false;
					num2 = 24;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f == 0)
					{
						num2 = 27;
					}
					continue;
				case 75:
					flag5 = true;
					num2 = 76;
					continue;
				case 87:
					flag6 = true;
					num2 = 20;
					continue;
				case 8:
				case 26:
					if (flag16 || flag11)
					{
						num2 = 125;
						continue;
					}
					goto case 124;
				case 66:
				case 67:
					if (flag11)
					{
						num = 134;
						break;
					}
					goto case 73;
				case 35:
					eventReader.testReader = false;
					num2 = 124;
					continue;
				case 49:
					eventReader.testReader = true;
					num2 = 99;
					continue;
				case 77:
					flag7 = true;
					num2 = 21;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af != 0)
					{
						num2 = 33;
					}
					continue;
				case 45:
					flag8 = identifierReader.IsWhiteBreakOrZero(1);
					num2 = 52;
					continue;
				case 40:
				case 61:
				case 134:
					if (!identifierReader.IsBreak())
					{
						num2 = 105;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 != 0)
						{
							num2 = 123;
						}
						continue;
					}
					goto case 32;
				case 136:
					eventReader._ParameterReader = flag12;
					num2 = 41;
					continue;
				case 82:
					eventReader._MessageReader = flag2;
					num2 = 39;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db == 0)
					{
						num2 = 4;
					}
					continue;
				case 93:
					eventReader.m_AttrReader = false;
					num2 = 136;
					continue;
				case 12:
					flag5 = true;
					num2 = 78;
					continue;
				case 118:
					if (flag8)
					{
						num2 = 77;
						continue;
					}
					goto case 33;
				case 91:
					if (!(flag6 || flag19 || flag18 || flag17 || flag))
					{
						num2 = 96;
						continue;
					}
					goto case 3;
				case 17:
					flag5 = true;
					num2 = 72;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba != 0)
					{
						num2 = 28;
					}
					continue;
				case 115:
					flag11 = !ValueIsRepresentableInOutputEncoding(value);
					num2 = 23;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb == 0)
					{
						num2 = 17;
					}
					continue;
				case 14:
					flag18 = true;
					num2 = 80;
					continue;
				case 121:
					if (flag14)
					{
						num2 = 70;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 == 0)
						{
							num2 = 87;
						}
						continue;
					}
					goto case 20;
				case 107:
					if (flag5)
					{
						num2 = 139;
						continue;
					}
					goto case 74;
				case 9:
					eventReader._BridgeReader = value;
					num2 = 4;
					continue;
				case 84:
					flag7 = true;
					num2 = 37;
					continue;
				case 92:
					eventReader.merchantReader = false;
					num2 = 35;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ae6607a3b39a41f69b80f2c625a717a2 != 0)
					{
						num2 = 20;
					}
					continue;
				case 29:
				case 60:
					if (identifierReader.EndOfInput)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 6;
				case 39:
					return;
				case 85:
					eventReader.merchantReader = true;
					num2 = 102;
					continue;
				case 127:
					flag17 = false;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af == 0)
					{
						num2 = 1;
					}
					continue;
				case 19:
					flag17 = true;
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 == 0)
					{
						num2 = 24;
					}
					continue;
				case 70:
					flag16 = true;
					num2 = 108;
					continue;
				case 37:
					if (identifierReader.Check('-') && flag8)
					{
						num2 = 75;
						continue;
					}
					goto case 66;
				case 33:
					if (identifierReader.Check('#') && flag4)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
						{
							num2 = 17;
						}
						continue;
					}
					goto case 55;
				case 90:
					flag13 = true;
					num2 = 13;
					continue;
				case 125:
					eventReader.m_StatusReader = false;
					num2 = 92;
					continue;
				case 46:
					flag9 = false;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
					{
						num2 = 5;
					}
					continue;
				case 51:
					eventReader.m_StatusReader = false;
					num2 = 131;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
					{
						num2 = 4;
					}
					continue;
				case 6:
					if (flag14)
					{
						num2 = 116;
						continue;
					}
					goto case 44;
				case 7:
					flag15 = false;
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 != 0)
					{
						num2 = 63;
					}
					continue;
				case 30:
					flag5 = true;
					num2 = 28;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 == 0)
					{
						num2 = 12;
					}
					continue;
				case 54:
					flag14 = false;
					num = 60;
					break;
				case 69:
					if (identifierReader.Check(':'))
					{
						num2 = 64;
						continue;
					}
					goto case 33;
				case 2:
				case 105:
					if (!identifierReader.IsBreak())
					{
						num = 130;
						break;
					}
					goto case 133;
				case 74:
					if (flag7)
					{
						num2 = 16;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 != 0)
						{
							num2 = 16;
						}
						continue;
					}
					goto case 82;
				case 122:
					flag13 = false;
					num2 = 100;
					continue;
				case 98:
					return;
				case 50:
					eventReader.m_AttrReader = false;
					num2 = 112;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 == 0)
					{
						num2 = 77;
					}
					continue;
				case 94:
					eventReader.testReader = false;
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 == 0)
					{
						num2 = 4;
					}
					continue;
				case 41:
					if (flag12)
					{
						num2 = 25;
						continue;
					}
					goto case 107;
				case 3:
					eventReader.m_StatusReader = false;
					num2 = 83;
					continue;
				default:
					eventReader.m_StatusReader = true;
					num2 = 85;
					continue;
				case 86:
				case 130:
					flag10 = false;
					num2 = 89;
					continue;
				case 27:
					flag3 = false;
					num2 = 42;
					continue;
				case 97:
					if (!value.StartsWith(DicSingleton.gE3WbyDVW(0x4C23C86A ^ 0x4C23B124), StringComparison.Ordinal))
					{
						num2 = 71;
						continue;
					}
					goto case 12;
				case 21:
					eventReader.m_AttrReader = false;
					num2 = 101;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 != 0)
					{
						num2 = 68;
					}
					continue;
				case 76:
					flag7 = true;
					num2 = 67;
					continue;
				case 22:
				case 123:
					if (!identifierReader.IsSpace())
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2eefc971c250433cadc4a8fe13afd044 == 0)
						{
							num2 = 2;
						}
						continue;
					}
					goto case 121;
				case 15:
					flag3 = true;
					num2 = 36;
					continue;
				case 102:
					eventReader.testReader = true;
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 == 0)
					{
						num2 = 34;
					}
					continue;
				case 4:
					if (value.Length != 0)
					{
						flag5 = false;
						num = 31;
					}
					else
					{
						num = 119;
					}
					break;
				case 57:
				case 101:
					if (!flag9)
					{
						num2 = 16;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4a2885c39dcc4cf1a32db39a2ed578f0 == 0)
						{
							num2 = 26;
						}
						continue;
					}
					goto case 51;
				case 80:
				case 120:
					if (flag3)
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f == 0)
						{
							num2 = 56;
						}
						continue;
					}
					goto case 13;
				case 103:
					flag5 = true;
					num2 = 106;
					continue;
				case 104:
					flag19 = true;
					num2 = 48;
					continue;
				case 95:
					flag8 = identifierReader.IsWhiteBreakOrZero(1);
					num2 = 36;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f != 0)
					{
						num2 = 54;
					}
					continue;
				case 43:
					eventReader.testReader = false;
					num2 = 50;
					continue;
				case 126:
					flag3 = false;
					num2 = 138;
					continue;
				case 55:
					flag2 |= identifierReader.Check('\'');
					num2 = 66;
					continue;
				case 72:
					flag7 = true;
					num = 55;
					break;
				case 59:
				case 114:
					identifierReader = new IdentifierReader<CandidateFactory>(new CandidateFactory(value));
					num2 = 18;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 != 0)
					{
						num2 = 68;
					}
					continue;
				case 131:
					eventReader.merchantReader = false;
					num2 = 94;
					continue;
				case 99:
					eventReader.m_AttrReader = false;
					num2 = 83;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac == 0)
					{
						num2 = 98;
					}
					continue;
				case 52:
					flag6 = false;
					num2 = 53;
					continue;
				case 83:
					eventReader.merchantReader = false;
					num2 = 117;
					continue;
				case 81:
					eventReader.m_StatusReader = false;
					num2 = 8;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2aaca7da964541af9780eb37df39c3db != 0)
					{
						num2 = 110;
					}
					continue;
				case 64:
					flag5 = true;
					num2 = 118;
					continue;
				case 20:
					if (identifierReader.Buffer.Position < identifierReader.Buffer.Length - 1)
					{
						num2 = 109;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
						{
							num2 = 120;
						}
						continue;
					}
					goto case 14;
				case 48:
				case 135:
					if (identifierReader.Buffer.Position >= identifierReader.Buffer.Length - 1)
					{
						num2 = 19;
						continue;
					}
					goto case 24;
				case 132:
					flag2 |= identifierReader.Check('\'');
					num2 = 32;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
					{
						num2 = 47;
					}
					continue;
				case 89:
					flag3 = false;
					num2 = 122;
					continue;
				case 16:
					eventReader.merchantReader = false;
					num2 = 45;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e != 0)
					{
						num2 = 82;
					}
					continue;
				case 23:
					flag2 = false;
					num2 = 7;
					continue;
				case 11:
					eventReader.m_StatusReader = false;
					num2 = 90;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 != 0)
					{
						num2 = 128;
					}
					continue;
				case 65:
					flag = identifierReader.Check('\'');
					num2 = 132;
					continue;
				case 111:
					flag10 = false;
					num2 = 15;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
					{
						num2 = 3;
					}
					continue;
				}
				break;
			}
		}
	}

	private bool ValueIsRepresentableInOutputEncoding(string value)
	{
		int num = 3;
		int num2 = num;
		bool result = default(bool);
		while (true)
		{
			switch (num2)
			{
			case 3:
				if (watcherReader)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb != 0)
					{
						num2 = 2;
					}
				}
				else
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 != 0)
					{
						num2 = 0;
					}
				}
				break;
			case 1:
				return result;
			case 2:
				return true;
			default:
				try
				{
					byte[] bytes = _PredicateReader.Encoding.GetBytes(value);
					int num3 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
					{
						num3 = 0;
					}
					while (true)
					{
						switch (num3)
						{
						default:
							result = _PredicateReader.Encoding.GetString(bytes, 0, bytes.Length).Equals(value);
							num3 = 1;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d != 0)
							{
								num3 = 1;
							}
							continue;
						case 1:
							break;
						}
						break;
					}
				}
				catch (EncoderFallbackException)
				{
					int num4 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
					{
						num4 = 1;
					}
					while (true)
					{
						switch (num4)
						{
						case 1:
							result = false;
							num4 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 == 0)
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
				catch (ArgumentOutOfRangeException)
				{
					int num5 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
					{
						num5 = 1;
					}
					while (true)
					{
						switch (num5)
						{
						case 1:
							result = false;
							num5 = 0;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
							{
								num5 = 0;
							}
							continue;
						case 0:
							break;
						}
						break;
					}
				}
				goto case 1;
			}
		}
	}

	private bool IsUnicode(Encoding encoding)
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (!(encoding is UnicodeEncoding))
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 2;
			default:
				return encoding is UTF7Encoding;
			case 2:
				return true;
			case 3:
				if (encoding is UTF8Encoding)
				{
					num2 = 2;
					break;
				}
				goto case 1;
			}
		}
	}

	private void AnalyzeTag(ValueFactory tag)
	{
		_FacadeReader._ClientReader = tag.Value;
		foreach (ErrorFactory item in m_DecoratorReader)
		{
			if (!tag.Value.StartsWith(item.Prefix, StringComparison.Ordinal))
			{
				continue;
			}
			_FacadeReader._ClientReader = item.Handle;
			_FacadeReader.m_RecordReader = tag.Value.Substring(item.Prefix.Length);
			break;
		}
	}

	private void StateMachine(MappingFactory evt)
	{
		int num = 12;
		int num2 = num;
		RegReader productReader = default(RegReader);
		StubFactory stubFactory = default(StubFactory);
		while (true)
		{
			switch (num2)
			{
			case 6:
				return;
			case 8:
				return;
			case 22:
				return;
			case 4:
				switch (productReader)
				{
				case (RegReader)11:
					EmitFlowMappingValue(evt, isSimple: false);
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 == 0)
					{
						num2 = 10;
					}
					goto end_IL_0012;
				case (RegReader)3:
					EmitDocumentStart(evt, isFirst: false);
					num2 = 7;
					goto end_IL_0012;
				case (RegReader)2:
					EmitDocumentStart(evt, isFirst: true);
					num2 = 8;
					goto end_IL_0012;
				default:
					num2 = 19;
					goto end_IL_0012;
				case (RegReader)13:
					EmitBlockSequenceItem(evt, isFirst: false);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 == 0)
					{
						num2 = 1;
					}
					goto end_IL_0012;
				case (RegReader)6:
					EmitFlowSequenceItem(evt, isFirst: true);
					num2 = 2;
					goto end_IL_0012;
				case (RegReader)1:
					throw new TestsFactory(DicSingleton.gE3WbyDVW(-359091888 ^ -359085840));
				case (RegReader)0:
					break;
				case (RegReader)12:
					EmitBlockSequenceItem(evt, isFirst: true);
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e == 0)
					{
						num2 = 1;
					}
					goto end_IL_0012;
				case (RegReader)5:
					EmitDocumentEnd(evt);
					num2 = 9;
					goto end_IL_0012;
				case (RegReader)8:
					EmitFlowMappingKey(evt, isFirst: true);
					num2 = 14;
					goto end_IL_0012;
				case (RegReader)16:
					EmitBlockMappingValue(evt, isSimple: true);
					num2 = 13;
					goto end_IL_0012;
				case (RegReader)9:
					EmitFlowMappingKey(evt, isFirst: false);
					num2 = 15;
					goto end_IL_0012;
				case (RegReader)14:
					EmitBlockMappingKey(evt, isFirst: true);
					num2 = 21;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 != 0)
					{
						num2 = 21;
					}
					goto end_IL_0012;
				case (RegReader)4:
					EmitDocumentContent(evt);
					num2 = 5;
					goto end_IL_0012;
				case (RegReader)17:
					EmitBlockMappingValue(evt, isSimple: false);
					num2 = 16;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd != 0)
					{
						num2 = 9;
					}
					goto end_IL_0012;
				case (RegReader)15:
					EmitBlockMappingKey(evt, isFirst: false);
					num2 = 17;
					goto end_IL_0012;
				case (RegReader)10:
					EmitFlowMappingValue(evt, isSimple: true);
					num2 = 6;
					goto end_IL_0012;
				case (RegReader)7:
					EmitFlowSequenceItem(evt, isFirst: false);
					num2 = 18;
					goto end_IL_0012;
				}
				goto default;
			case 3:
				return;
			case 9:
				return;
			case 16:
				return;
			case 19:
				throw new InvalidOperationException();
			default:
				EmitStreamStart(evt);
				num2 = 22;
				break;
			case 10:
				return;
			case 20:
				return;
			case 5:
				return;
			case 18:
				return;
			case 17:
				return;
			case 14:
				return;
			case 1:
				return;
			case 11:
				if (stubFactory == null)
				{
					productReader = m_ProductReader;
					num2 = 4;
				}
				else
				{
					num2 = 23;
				}
				break;
			case 7:
				return;
			case 23:
				EmitComment(stubFactory);
				num2 = 20;
				break;
			case 12:
				stubFactory = evt as StubFactory;
				num2 = 11;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d3a8d35e37ef470b87db5d77fb69b82c != 0)
				{
					num2 = 8;
				}
				break;
			case 13:
				return;
			case 21:
				return;
			case 15:
				return;
			case 2:
				return;
				end_IL_0012:
				break;
			}
		}
	}

	private void EmitComment(StubFactory comment)
	{
		int num = 8;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 8:
					if (comment.IsInline)
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 != 0)
						{
							num2 = 7;
						}
						continue;
					}
					goto default;
				case 7:
					break;
				case 1:
				case 5:
					Write(DicSingleton.gE3WbyDVW(-1580624393 ^ -1580602351));
					num2 = 3;
					continue;
				default:
					WriteIndent();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76529687cc5b4cb68eed6d9a17f15d44 == 0)
					{
						num2 = 0;
					}
					continue;
				case 3:
					Write(comment.Value);
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_883ead5706334c63a3ee4dc5f638ccb2 != 0)
					{
						num2 = 4;
					}
					continue;
				case 4:
					WriteBreak();
					num2 = 6;
					continue;
				case 2:
					return;
				case 6:
					pageReader = true;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 != 0)
					{
						num2 = 2;
					}
					continue;
				}
				break;
			}
			Write(' ');
			num = 5;
		}
	}

	private void EmitStreamStart(MappingFactory evt)
	{
		int num = 6;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					_InitializerReader = true;
					num2 = 2;
					break;
				case 6:
					if (evt is PublisherSetter)
					{
						broadcasterReader = -1;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
						{
							num2 = 0;
						}
						break;
					}
					goto end_IL_0012;
				case 2:
					pageReader = true;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
					{
						num2 = 2;
					}
					break;
				default:
					m_TestsReader = 0;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
					{
						num2 = 1;
					}
					break;
				case 3:
					m_ProductReader = (RegReader)2;
					num2 = 4;
					break;
				case 4:
					return;
				case 5:
					throw new ArgumentException(DicSingleton.gE3WbyDVW(0x4995986C ^ 0x4995E182), DicSingleton.gE3WbyDVW(-379532028 ^ -379537638));
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 5;
		}
	}

	private void EmitDocumentStart(MappingFactory evt, bool isFirst)
	{
		if (evt is DicFactory dicFactory)
		{
			bool flag = dicFactory.IsImplicit && isFirst && !systemReader;
			StateFactory stateFactory = NonDefaultTagsAmong(dicFactory.Tags);
			if (!isFirst && !_RequestReader && (dicFactory.Version != null || stateFactory.Count > 0))
			{
				_RequestReader = false;
				WriteIndicator(DicSingleton.gE3WbyDVW(0x1679942F ^ 0x1679ED77), needWhitespace: true, whitespace: false, indentation: false);
				WriteIndent();
			}
			if (dicFactory.Version != null)
			{
				AnalyzeVersionDirective(dicFactory.Version);
				WorkerFactory version = dicFactory.Version.Version;
				flag = false;
				WriteIndicator(DicSingleton.gE3WbyDVW(-1447578472 ^ -1447571792), needWhitespace: true, whitespace: false, indentation: false);
				WriteIndicator(string.Format(CultureInfo.InvariantCulture, DicSingleton.gE3WbyDVW(0x40385DA3 ^ 0x40382795), new object[2] { version.Major, version.Minor }), needWhitespace: true, whitespace: false, indentation: false);
				WriteIndent();
			}
			foreach (ErrorFactory item in stateFactory)
			{
				AppendTagDirectiveTo(item, allowDuplicates: false, m_DecoratorReader);
			}
			ErrorFactory[] rulesReader = CallbackReader.rulesReader;
			for (int i = 0; i < rulesReader.Length; i++)
			{
				AppendTagDirectiveTo(rulesReader[i], allowDuplicates: true, m_DecoratorReader);
			}
			if (stateFactory.Count > 0)
			{
				flag = false;
				rulesReader = CallbackReader.rulesReader;
				for (int i = 0; i < rulesReader.Length; i++)
				{
					AppendTagDirectiveTo(rulesReader[i], allowDuplicates: true, stateFactory);
				}
				foreach (ErrorFactory item2 in stateFactory)
				{
					WriteIndicator(DicSingleton.gE3WbyDVW(-1891833728 ^ -1891855672), needWhitespace: true, whitespace: false, indentation: false);
					WriteTagHandle(item2.Handle);
					WriteTagContent(item2.Prefix, needsWhitespace: true);
					WriteIndent();
				}
			}
			if (CheckEmptyDocument())
			{
				flag = false;
			}
			if (!flag)
			{
				WriteIndent();
				WriteIndicator(DicSingleton.gE3WbyDVW(0xDA293E6 ^ 0xDA2EAA8), needWhitespace: true, whitespace: false, indentation: false);
				if (systemReader)
				{
					WriteIndent();
				}
			}
			m_ProductReader = (RegReader)4;
		}
		else
		{
			if (!(evt is RoleSetter))
			{
				throw new TestsFactory(DicSingleton.gE3WbyDVW(0x5A8BEE ^ 0x5AF1BA));
			}
			m_ProductReader = (RegReader)1;
		}
	}

	private StateFactory NonDefaultTagsAmong([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(new byte[] { 2, 1 })] IEnumerable<ErrorFactory> tagCollection)
	{
		StateFactory stateFactory = new StateFactory();
		if (tagCollection == null)
		{
			return stateFactory;
		}
		foreach (ErrorFactory item2 in tagCollection)
		{
			AppendTagDirectiveTo(item2, allowDuplicates: false, stateFactory);
		}
		ErrorFactory[] rulesReader = CallbackReader.rulesReader;
		foreach (ErrorFactory item in rulesReader)
		{
			stateFactory.Remove(item);
		}
		return stateFactory;
	}

	private void AnalyzeVersionDirective(ProcessFactory versionDirective)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				throw new TestsFactory(DicSingleton.gE3WbyDVW(-823738529 ^ -823736835));
			case 1:
				if (versionDirective.Version.Minor <= 3)
				{
					return;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				if (versionDirective.Version.Major == 1)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto default;
			}
		}
	}

	private static void AppendTagDirectiveTo(ErrorFactory value, bool allowDuplicates, StateFactory tagDirectives)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 3:
				throw new TestsFactory(DicSingleton.gE3WbyDVW(0x7A125A0E ^ 0x7A1220D0));
			case 1:
				tagDirectives.Add(value);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
				{
					num2 = 0;
				}
				break;
			case 4:
				return;
			case 0:
				return;
			case 5:
				if (allowDuplicates)
				{
					num2 = 4;
					break;
				}
				goto case 3;
			case 2:
				if (!tagDirectives.Contains(value))
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9c47a25d924946efb9e023473a095794 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 5;
			}
		}
	}

	private void EmitDocumentContent(MappingFactory evt)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 0:
				return;
			case 2:
				registryReader.Push((RegReader)5);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e != 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				EmitNode(evt, isMapping: false, isSimpleKey: false);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private void EmitNode(MappingFactory evt, bool isMapping, bool isSimpleKey)
	{
		int num = 4;
		int num2 = num;
		SchemaCompareFilterSetting type = default(SchemaCompareFilterSetting);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 9:
				switch (type)
				{
				case (SchemaCompareFilterSetting)6:
					goto IL_007c;
				case (SchemaCompareFilterSetting)9:
					goto IL_00af;
				case (SchemaCompareFilterSetting)7:
					goto IL_00f2;
				case (SchemaCompareFilterSetting)8:
					goto IL_0114;
				case (SchemaCompareFilterSetting)5:
					goto IL_0140;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
				{
					num2 = 1;
				}
				break;
			case 5:
				return;
			case 4:
				taskReader = isMapping;
				num2 = 3;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
				{
					num2 = 2;
				}
				break;
			case 7:
				return;
			case 8:
				type = evt.Type;
				num2 = 9;
				break;
			case 2:
				return;
			case 0:
				return;
			case 1:
				goto IL_0114;
			case 6:
				goto IL_0140;
			case 3:
				{
					m_UtilsReader = isSimpleKey;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
					{
						num2 = 8;
					}
					break;
				}
				IL_00f2:
				EmitSequenceStart(evt);
				num2 = 7;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 != 0)
				{
					num2 = 2;
				}
				break;
				IL_007c:
				EmitScalar(evt);
				num2 = 2;
				break;
				IL_0140:
				EmitAlias();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2cfc19e1f1214b3b86aeda1e50dd370e == 0)
				{
					num2 = 5;
				}
				break;
				IL_00af:
				EmitMappingStart(evt);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
				{
					num2 = 0;
				}
				break;
				IL_0114:
				throw new TestsFactory(string.Format(DicSingleton.gE3WbyDVW(0x9000142 ^ 0x9007A56), evt.Type));
			}
		}
	}

	private void EmitAlias()
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				m_ProductReader = registryReader.Pop();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 2:
				ProcessAnchor();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 != 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	private void EmitScalar(MappingFactory evt)
	{
		int num = 3;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 6:
					m_ProductReader = registryReader.Pop();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 != 0)
					{
						num2 = 0;
					}
					continue;
				case 4:
					IncreaseIndent(isFlow: true, isIndentless: false);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
					{
						num2 = 1;
					}
					continue;
				case 1:
					ProcessScalar();
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 == 0)
					{
						num2 = 5;
					}
					continue;
				case 7:
					break;
				case 5:
					broadcasterReader = valueReader.Pop();
					num2 = 6;
					continue;
				case 3:
					SelectScalarStyle(evt);
					num2 = 2;
					continue;
				case 2:
					ProcessAnchor();
					num2 = 7;
					continue;
				case 0:
					return;
				}
				break;
			}
			ProcessTag();
			num = 4;
		}
	}

	private void SelectScalarStyle(MappingFactory evt)
	{
		int num = 53;
		RuleFactory ruleFactory = default(RuleFactory);
		ClassFactory classFactory = default(ClassFactory);
		bool flag = default(bool);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				int num4;
				int num5;
				int num3;
				switch (num2)
				{
				case 49:
					num4 = 1;
					goto IL_06a5;
				case 23:
				case 46:
				case 54:
					if (ruleFactory == (RuleFactory)2)
					{
						num2 = 33;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
						{
							num2 = 14;
						}
						continue;
					}
					goto case 15;
				case 53:
					classFactory = (ClassFactory)evt;
					num2 = 52;
					continue;
				case 41:
					if (_FacadeReader._ClientReader != null)
					{
						num2 = 2;
						continue;
					}
					goto case 47;
				case 32:
					if (m_UtilsReader)
					{
						num2 = 11;
						continue;
					}
					goto case 7;
				case 8:
				case 38:
					ruleFactory = (RuleFactory)3;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 == 0)
					{
						num2 = 0;
					}
					continue;
				case 12:
					return;
				case 9:
					if (!string.IsNullOrEmpty(eventReader._BridgeReader))
					{
						num2 = 5;
						continue;
					}
					goto case 14;
				case 4:
					if (!eventReader.merchantReader)
					{
						num2 = 13;
						continue;
					}
					goto case 9;
				case 52:
					ruleFactory = classFactory.Style;
					num2 = 41;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 != 0)
					{
						num2 = 18;
					}
					continue;
				case 16:
					ruleFactory = (RuleFactory)2;
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 != 0)
					{
						num2 = 54;
					}
					continue;
				case 43:
					if (ruleFactory == (RuleFactory)5)
					{
						num = 26;
						break;
					}
					goto default;
				default:
					eventReader._ExporterReader = ruleFactory;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
					{
						num2 = 12;
					}
					continue;
				case 13:
				case 48:
					if (!eventReader.testReader)
					{
						num2 = 19;
						continue;
					}
					goto case 18;
				case 51:
					ruleFactory = (RuleFactory)3;
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
					{
						num2 = 15;
					}
					continue;
				case 5:
				case 22:
				case 30:
					if (!flag)
					{
						num2 = 46;
						continue;
					}
					goto case 34;
				case 10:
					if (classFactory.IsPlainImplicit)
					{
						num2 = 37;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
						{
							num2 = 42;
						}
						continue;
					}
					goto case 40;
				case 7:
				case 36:
					if (ruleFactory == (RuleFactory)1)
					{
						num2 = 50;
						continue;
					}
					goto case 23;
				case 27:
					ruleFactory = (RuleFactory)3;
					num2 = 36;
					continue;
				case 14:
					if (m_WorkerReader == 0)
					{
						num2 = 3;
						continue;
					}
					goto case 28;
				case 24:
					if (!m_UtilsReader)
					{
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 != 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 8;
				case 37:
					if (!eventReader.m_StatusReader)
					{
						num2 = 48;
						continue;
					}
					goto case 35;
				case 17:
					if (systemReader)
					{
						num2 = 39;
						continue;
					}
					goto case 32;
				case 29:
					throw new TestsFactory(DicSingleton.gE3WbyDVW(0x3FCF6129 ^ 0x3FCF1AB3));
				case 31:
				case 42:
					if (ruleFactory == (RuleFactory)0)
					{
						num2 = 17;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 != 0)
						{
							num2 = 21;
						}
						continue;
					}
					goto case 17;
				case 50:
					if (m_WorkerReader == 0)
					{
						num2 = 35;
						continue;
					}
					goto case 37;
				case 39:
					ruleFactory = (RuleFactory)3;
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 != 0)
					{
						num2 = 32;
					}
					continue;
				case 19:
				case 25:
					num5 = 3;
					goto IL_06c2;
				case 21:
					if (!eventReader._ParameterReader)
					{
						num2 = 43;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4405eab451294c899641c58928fa37bb == 0)
						{
							num2 = 49;
						}
						continue;
					}
					num4 = 5;
					goto IL_06a5;
				case 18:
					if (eventReader._MessageReader)
					{
						num2 = 25;
						continue;
					}
					num5 = 2;
					goto IL_06c2;
				case 11:
					if (!eventReader._ParameterReader)
					{
						num2 = 7;
						continue;
					}
					goto case 27;
				case 47:
					num3 = ((_FacadeReader.m_RecordReader == null) ? 1 : 0);
					goto IL_0688;
				case 45:
					if (m_WorkerReader != 0)
					{
						num2 = 13;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a != 0)
						{
							num2 = 38;
						}
						continue;
					}
					goto case 24;
				case 3:
					if (!m_UtilsReader)
					{
						num2 = 30;
						continue;
					}
					goto case 28;
				case 1:
					if (!flag)
					{
						num2 = 19;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 != 0)
						{
							num2 = 31;
						}
						continue;
					}
					goto case 10;
				case 15:
				case 20:
					if (ruleFactory != (RuleFactory)4)
					{
						num2 = 43;
						continue;
					}
					goto case 26;
				case 26:
					if (eventReader.m_AttrReader)
					{
						num2 = 36;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 != 0)
						{
							num2 = 45;
						}
						continue;
					}
					goto case 8;
				case 28:
					ruleFactory = (RuleFactory)2;
					num2 = 22;
					continue;
				case 40:
					if (!classFactory.IsQuotedImplicit)
					{
						num = 29;
						break;
					}
					goto case 31;
				case 35:
				case 44:
					if (m_WorkerReader == 0)
					{
						num2 = 4;
						continue;
					}
					goto case 9;
				case 34:
					if (classFactory.IsPlainImplicit)
					{
						num = 23;
						break;
					}
					goto case 16;
				case 33:
					if (eventReader.testReader)
					{
						num2 = 20;
						continue;
					}
					goto case 51;
				case 2:
					{
						num3 = 0;
						goto IL_0688;
					}
					IL_06c2:
					ruleFactory = (RuleFactory)num5;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f898a5a72854b839aa1b1d80c3919ab == 0)
					{
						num2 = 9;
					}
					continue;
					IL_0688:
					flag = (byte)num3 != 0;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac != 0)
					{
						num2 = 0;
					}
					continue;
					IL_06a5:
					ruleFactory = (RuleFactory)num4;
					num2 = 17;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_76ef03fb57cc4d9d9751e0efbc2e73e4 == 0)
					{
						num2 = 17;
					}
					continue;
				}
				break;
			}
		}
	}

	private void ProcessScalar()
	{
		int num = 4;
		RuleFactory exporterReader = default(RuleFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					return;
				case 3:
					switch (exporterReader)
					{
					default:
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
						{
							num2 = 2;
						}
						goto end_IL_0012;
					case (RuleFactory)4:
						goto end_IL_0012_2;
					case (RuleFactory)3:
						WriteDoubleQuotedScalar(eventReader._BridgeReader, !m_UtilsReader);
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 == 0)
						{
							num2 = 2;
						}
						goto end_IL_0012;
					case (RuleFactory)1:
						break;
					case (RuleFactory)5:
						WriteFoldedScalar(eventReader._BridgeReader);
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
						{
							num2 = 1;
						}
						goto end_IL_0012;
					case (RuleFactory)2:
						WriteSingleQuotedScalar(eventReader._BridgeReader, !m_UtilsReader);
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
						{
							num2 = 0;
						}
						goto end_IL_0012;
					}
					goto case 7;
				case 2:
					return;
				case 0:
					return;
				case 7:
					WritePlainScalar(eventReader._BridgeReader, !m_UtilsReader);
					num2 = 6;
					break;
				case 4:
					exporterReader = eventReader._ExporterReader;
					num2 = 3;
					break;
				case 8:
					return;
				case 1:
					return;
				case 5:
					throw new InvalidOperationException();
				case 6:
					return;
					end_IL_0012:
					break;
				}
				continue;
				end_IL_0012_2:
				break;
			}
			WriteLiteralScalar(eventReader._BridgeReader);
			num = 8;
		}
	}

	private void WritePlainScalar(string value, bool allowBreaks)
	{
		int num = 34;
		int num3 = default(int);
		bool flag = default(bool);
		bool flag2 = default(bool);
		char c = default(char);
		char breakChar = default(char);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					num3++;
					num2 = 30;
					continue;
				case 4:
					flag = false;
					num2 = 37;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
					{
						num2 = 18;
					}
					continue;
				case 17:
					WriteIndent();
					num2 = 21;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 == 0)
					{
						num2 = 10;
					}
					continue;
				case 28:
					_InitializerReader = false;
					num2 = 3;
					continue;
				case 3:
					pageReader = false;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc303368258d412688c67cc783e94da6 == 0)
					{
						num2 = 1;
					}
					continue;
				case 27:
					WriteIndent();
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 == 0)
					{
						num2 = 10;
					}
					continue;
				case 5:
					if (!allowBreaks)
					{
						num = 6;
						break;
					}
					goto case 29;
				case 21:
				case 23:
					flag2 = true;
					num2 = 2;
					continue;
				case 25:
					if (IsBreak(c, out breakChar))
					{
						num2 = 7;
						continue;
					}
					goto case 20;
				case 22:
				case 30:
					if (num3 >= value.Length)
					{
						num = 28;
						break;
					}
					goto case 26;
				case 33:
					Write(' ');
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
					{
						num2 = 6;
					}
					continue;
				case 11:
					WriteBreak();
					num2 = 14;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea == 0)
					{
						num2 = 0;
					}
					continue;
				case 20:
					if (flag)
					{
						num2 = 27;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 != 0)
						{
							num2 = 20;
						}
						continue;
					}
					goto case 10;
				case 14:
				case 38:
					WriteBreak(breakChar);
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
					{
						num2 = 32;
					}
					continue;
				case 29:
					if (!flag2)
					{
						num = 19;
						break;
					}
					goto case 6;
				case 6:
				case 36:
					Write(c);
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
					{
						num2 = 23;
					}
					continue;
				case 19:
					if (m_TestsReader > m_ExpressionReader)
					{
						num2 = 8;
						continue;
					}
					goto case 6;
				case 15:
					pageReader = false;
					num2 = 12;
					continue;
				case 12:
					flag2 = false;
					num2 = 24;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6ac337effa104715bccdb6ac0dc1edfc == 0)
					{
						num2 = 11;
					}
					continue;
				case 8:
					if (num3 + 1 < value.Length)
					{
						num2 = 8;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
						{
							num2 = 35;
						}
						continue;
					}
					goto case 6;
				case 10:
					Write(c);
					num2 = 15;
					continue;
				case 7:
					if (flag)
					{
						num = 38;
						break;
					}
					goto case 16;
				case 1:
					return;
				case 35:
					if (value[num3 + 1] != ' ')
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d48dd4fddf45498286a18ba2f462c221 != 0)
						{
							num2 = 17;
						}
						continue;
					}
					goto case 6;
				case 9:
					flag2 = false;
					num2 = 4;
					continue;
				case 32:
					pageReader = true;
					num2 = 13;
					continue;
				case 31:
					if (IsSpace(c))
					{
						num2 = 5;
						continue;
					}
					goto case 25;
				case 34:
					if (!_InitializerReader)
					{
						num2 = 8;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
						{
							num2 = 33;
						}
						continue;
					}
					goto case 9;
				case 16:
					if (c == '\n')
					{
						num2 = 11;
						continue;
					}
					goto case 14;
				case 37:
					num3 = 0;
					num2 = 13;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af != 0)
					{
						num2 = 22;
					}
					continue;
				case 26:
					c = value[num3];
					num2 = 31;
					continue;
				case 13:
					flag = true;
					num = 18;
					break;
				case 24:
					flag = false;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			}
		}
	}

	private void WriteSingleQuotedScalar(string value, bool allowBreaks)
	{
		int num = 5;
		char c = default(char);
		bool flag = default(bool);
		bool flag2 = default(bool);
		int num3 = default(int);
		char breakChar = default(char);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 25:
					return;
				case 11:
				case 37:
				case 39:
					Write(c);
					num2 = 9;
					continue;
				case 40:
					if (!flag)
					{
						num2 = 18;
						continue;
					}
					goto case 11;
				case 24:
					WriteIndent();
					num2 = 22;
					continue;
				case 7:
					if (flag2)
					{
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3aab303a2946368dda3deef055dc93 == 0)
						{
							num2 = 43;
						}
						continue;
					}
					goto case 17;
				case 9:
				case 22:
					flag = true;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
					{
						num2 = 0;
					}
					continue;
				case 28:
					if (num3 == 0)
					{
						num = 37;
						break;
					}
					goto case 8;
				default:
					if (num3 < value.Length)
					{
						num2 = 27;
						continue;
					}
					goto case 21;
				case 15:
					flag2 = true;
					num2 = 23;
					continue;
				case 29:
					num3 = 0;
					num2 = 16;
					continue;
				case 17:
					if (c == '\n')
					{
						num2 = 30;
						continue;
					}
					goto case 13;
				case 20:
					if (allowBreaks)
					{
						num2 = 40;
						continue;
					}
					goto case 11;
				case 34:
					if (IsBreak(c, out breakChar))
					{
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_64e52be5a9394f5794a98e3318f6ccef != 0)
						{
							num2 = 6;
						}
						continue;
					}
					goto case 19;
				case 42:
					flag = false;
					num2 = 38;
					continue;
				case 26:
					if (c == ' ')
					{
						num = 20;
						break;
					}
					goto case 34;
				case 5:
					WriteIndicator(DicSingleton.gE3WbyDVW(0x33F6A245 ^ 0x33F6D9B9), needWhitespace: true, whitespace: false, indentation: false);
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec == 0)
					{
						num2 = 4;
					}
					continue;
				case 27:
				case 35:
					c = value[num3];
					num2 = 18;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_718beabd70354aacbcd27a64156e29d0 == 0)
					{
						num2 = 26;
					}
					continue;
				case 14:
					if (value[num3 + 1] != ' ')
					{
						num2 = 15;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a387277299064fedb958208e949ee30a != 0)
						{
							num2 = 24;
						}
						continue;
					}
					goto case 11;
				case 41:
					flag2 = false;
					num2 = 29;
					continue;
				case 21:
					WriteIndicator(DicSingleton.gE3WbyDVW(-34102588 ^ -34088648), needWhitespace: false, whitespace: false, indentation: false);
					num2 = 33;
					continue;
				case 13:
				case 43:
					WriteBreak(breakChar);
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 != 0)
					{
						num2 = 3;
					}
					continue;
				case 18:
					if (m_TestsReader <= m_ExpressionReader)
					{
						num2 = 10;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 != 0)
						{
							num2 = 11;
						}
						continue;
					}
					goto case 28;
				case 30:
					WriteBreak();
					num2 = 13;
					continue;
				case 12:
					pageReader = false;
					num2 = 25;
					continue;
				case 33:
					_InitializerReader = false;
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b != 0)
					{
						num2 = 8;
					}
					continue;
				case 3:
					pageReader = true;
					num2 = 15;
					continue;
				case 8:
					if (num3 + 1 < value.Length)
					{
						num2 = 14;
						continue;
					}
					goto case 11;
				case 38:
					flag2 = false;
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3ac5d604ebd547e7ac5b1603a0e85187 != 0)
					{
						num2 = 2;
					}
					continue;
				case 32:
					WriteIndent();
					num2 = 10;
					continue;
				case 2:
				case 6:
				case 23:
					num3++;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
					{
						num2 = 0;
					}
					continue;
				case 1:
					Write(c);
					num2 = 36;
					continue;
				case 4:
					flag = false;
					num2 = 41;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_35cf05af90cc4195a86c9ffc19bf78eb == 0)
					{
						num2 = 41;
					}
					continue;
				case 19:
					if (flag2)
					{
						num2 = 32;
						continue;
					}
					goto case 10;
				case 31:
					pageReader = false;
					num2 = 42;
					continue;
				case 10:
					if (c == '\'')
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 36;
				case 36:
					Write(c);
					num2 = 31;
					continue;
				}
				break;
			}
		}
	}

	private void WriteDoubleQuotedScalar(string value, bool allowBreaks)
	{
		int num = 31;
		int num3 = default(int);
		char c = default(char);
		ushort num4 = default(ushort);
		bool flag = default(bool);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 69:
				case 77:
					throw new RegistryFactory(DicSingleton.gE3WbyDVW(0x55F5513C ^ 0x55F52D20));
				case 5:
					Write('u');
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 != 0)
					{
						num2 = 3;
					}
					continue;
				case 3:
					if (num3 + 1 < value.Length)
					{
						num2 = 46;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_61723150636f4e27a0f2c9e507a933dd == 0)
						{
							num2 = 89;
						}
						continue;
					}
					goto case 69;
				case 22:
					Write('"');
					num2 = 78;
					continue;
				case 75:
					if (c == ' ')
					{
						num2 = 48;
						continue;
					}
					goto case 67;
				case 49:
					if (!IsHighSurrogate(c))
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
						{
							num2 = 5;
						}
						continue;
					}
					goto case 3;
				case 7:
					Write(num4.ToString(DicSingleton.gE3WbyDVW(0x5A1F7167 ^ 0x5A1F0DC7), CultureInfo.InvariantCulture));
					num2 = 58;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_50658baf3b124aaf9b4173937698fdf4 == 0)
					{
						num2 = 95;
					}
					continue;
				case 68:
					Write('\\');
					num2 = 28;
					continue;
				case 20:
					if (c != '"')
					{
						num2 = 47;
						continue;
					}
					goto case 25;
				case 27:
					num3 = 0;
					num2 = 66;
					continue;
				case 35:
					Write('a');
					num2 = 48;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 != 0)
					{
						num2 = 61;
					}
					continue;
				case 10:
				case 88:
					if ((uint)c > 160u)
					{
						num2 = 79;
						continue;
					}
					goto case 92;
				case 97:
					if (c != '\\')
					{
						num2 = 37;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
						{
							num2 = 34;
						}
						continue;
					}
					goto case 62;
				case 34:
					goto IL_03df;
				case 33:
				case 79:
					if (c != '\u2028')
					{
						num2 = 22;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 != 0)
						{
							num2 = 54;
						}
						continue;
					}
					goto case 72;
				case 90:
					Write('U');
					num2 = 8;
					continue;
				case 59:
					goto IL_0429;
				case 18:
					switch (c)
					{
					case '\a':
						break;
					case '\b':
						goto IL_03df;
					case '\r':
						goto IL_0429;
					default:
						goto IL_04b8;
					case '\u0001':
					case '\u0002':
					case '\u0003':
					case '\u0004':
					case '\u0005':
					case '\u0006':
						goto IL_0516;
					case '\v':
						goto IL_055a;
					case '\f':
						goto IL_061b;
					case '\n':
						goto IL_08a6;
					case '\t':
						goto IL_096f;
					case '\0':
						goto IL_0bd2;
					}
					goto case 35;
				case 6:
					Write('N');
					num2 = 37;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c != 0)
					{
						num2 = 85;
					}
					continue;
				case 70:
					Write('P');
					num2 = 82;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5ac12fecc2604083b1208e1a52a1c4e6 == 0)
					{
						num2 = 37;
					}
					continue;
				case 26:
				case 37:
				case 45:
				case 71:
				case 94:
					goto IL_0516;
				case 9:
				case 23:
				case 80:
					num3++;
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 == 0)
					{
						num2 = 57;
					}
					continue;
				case 83:
					if (num4 <= 255)
					{
						num2 = 55;
						continue;
					}
					goto case 49;
				case 81:
					goto IL_055a;
				case 93:
					if (m_TestsReader <= m_ExpressionReader)
					{
						num2 = 43;
						continue;
					}
					goto case 87;
				case 8:
					Write(char.ConvertToUtf32(c, value[num3 + 1]).ToString(DicSingleton.gE3WbyDVW(-220409977 ^ -220417131), CultureInfo.InvariantCulture));
					num2 = 60;
					continue;
				case 1:
					if (num3 + 1 >= value.Length)
					{
						num2 = 73;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 != 0)
						{
							num2 = 68;
						}
						continue;
					}
					goto case 46;
				case 98:
					flag = false;
					num2 = 23;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7e7ae6cc25e34646baea4e1c2c087e7a == 0)
					{
						num2 = 18;
					}
					continue;
				case 24:
					goto IL_061b;
				case 87:
					if (num3 <= 0)
					{
						num2 = 21;
						continue;
					}
					goto case 1;
				case 50:
					WriteIndicator(DicSingleton.gE3WbyDVW(--708144185 ^ 0x2A35103B), needWhitespace: false, whitespace: false, indentation: false);
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
					{
						num2 = 51;
					}
					continue;
				case 30:
					flag = false;
					num2 = 19;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e71c29c2bdd4e3db38733e612d5673d != 0)
					{
						num2 = 27;
					}
					continue;
				case 96:
					if (c != '\u001b')
					{
						num2 = 26;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
						{
							num2 = 18;
						}
						continue;
					}
					goto case 36;
				case 65:
					if (c != '\u00a0')
					{
						num2 = 27;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
						{
							num2 = 45;
						}
						continue;
					}
					goto case 53;
				case 67:
					Write(c);
					num2 = 98;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 != 0)
					{
						num2 = 42;
					}
					continue;
				case 36:
					Write('e');
					num2 = 12;
					continue;
				case 29:
				case 41:
					if (c != '"')
					{
						num2 = 97;
						continue;
					}
					goto case 22;
				case 62:
					Write('\\');
					num2 = 40;
					continue;
				case 57:
				case 66:
					if (num3 >= value.Length)
					{
						num2 = 50;
						continue;
					}
					goto case 52;
				case 2:
					Write(num4.ToString(DicSingleton.gE3WbyDVW(0x548F02D9 ^ 0x548F7ED1), CultureInfo.InvariantCulture));
					num = 91;
					break;
				case 72:
					Write('L');
					num2 = 99;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_259acdc10a3c4fba8a4f129ba5346de2 != 0)
					{
						num2 = 71;
					}
					continue;
				case 25:
					Write('\\');
					num2 = 17;
					continue;
				case 53:
					Write('_');
					num2 = 84;
					continue;
				case 55:
					Write('x');
					num2 = 2;
					continue;
				case 14:
					goto IL_08a6;
				case 47:
					if (c == '\\')
					{
						num2 = 25;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
						{
							num2 = 10;
						}
						continue;
					}
					goto case 75;
				case 48:
					if (allowBreaks)
					{
						num2 = 16;
						continue;
					}
					goto case 21;
				case 17:
					if ((uint)c > 92u)
					{
						num2 = 2;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_b8198fd23a7d4010af107216f51de4ec == 0)
						{
							num2 = 88;
						}
						continue;
					}
					goto case 74;
				case 21:
				case 43:
				case 58:
				case 73:
					Write(c);
					num = 56;
					break;
				case 28:
				case 56:
					flag = true;
					num2 = 80;
					continue;
				case 76:
					goto IL_096f;
				case 54:
					if (c != '\u2029')
					{
						num2 = 94;
						continue;
					}
					goto case 70;
				default:
					flag = false;
					num2 = 9;
					continue;
				case 89:
					if (!IsLowSurrogate(value[num3 + 1]))
					{
						num2 = 77;
						continue;
					}
					goto case 90;
				case 52:
					c = value[num3];
					num2 = 4;
					continue;
				case 15:
				{
					if (!IsBreak(c, out var _))
					{
						num2 = 20;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
						{
							num2 = 3;
						}
						continue;
					}
					goto case 25;
				}
				case 74:
					if ((uint)c > 27u)
					{
						num2 = 41;
						continue;
					}
					goto case 18;
				case 46:
					WriteIndent();
					num2 = 28;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb != 0)
					{
						num2 = 38;
					}
					continue;
				case 38:
					if (value[num3 + 1] == ' ')
					{
						num2 = 68;
						continue;
					}
					goto case 28;
				case 92:
					if (c != '\u0085')
					{
						num2 = 41;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 == 0)
						{
							num2 = 65;
						}
						continue;
					}
					goto case 6;
				case 16:
					if (!flag)
					{
						num2 = 93;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
						{
							num2 = 82;
						}
						continue;
					}
					goto case 21;
				case 39:
					pageReader = false;
					num2 = 86;
					continue;
				case 60:
					num3++;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7f8575df6390454a8d8d306d4c9745b3 == 0)
					{
						num2 = 19;
					}
					continue;
				case 4:
					if (IsPrintable(c))
					{
						num2 = 15;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
						{
							num2 = 8;
						}
						continue;
					}
					goto case 25;
				case 86:
					return;
				case 42:
					goto IL_0bd2;
				case 51:
					_InitializerReader = false;
					num2 = 39;
					continue;
				case 31:
					{
						WriteIndicator(DicSingleton.gE3WbyDVW(-1773869960 ^ -1773889414), needWhitespace: true, whitespace: false, indentation: false);
						num2 = 30;
						continue;
					}
					IL_0bd2:
					Write('0');
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
					{
						num2 = 0;
					}
					continue;
					IL_096f:
					Write('t');
					num2 = 44;
					continue;
					IL_08a6:
					Write('n');
					num2 = 64;
					continue;
					IL_061b:
					Write('f');
					num2 = 32;
					continue;
					IL_055a:
					Write('v');
					num2 = 11;
					continue;
					IL_0516:
					num4 = c;
					num2 = 83;
					continue;
					IL_04b8:
					num2 = 96;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec != 0)
					{
						num2 = 21;
					}
					continue;
					IL_0429:
					Write('r');
					num2 = 62;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d4526e80d57249648a09d68c09383c72 == 0)
					{
						num2 = 63;
					}
					continue;
					IL_03df:
					Write('b');
					num2 = 13;
					continue;
				}
				break;
			}
		}
	}

	private void WriteLiteralScalar(string value)
	{
		int num = 16;
		bool flag = default(bool);
		char breakChar = default(char);
		int num3 = default(int);
		char c = default(char);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 21:
					WriteBlockScalarHints(value);
					num = 11;
					break;
				case 3:
				case 18:
					if (!flag)
					{
						num2 = 12;
						continue;
					}
					goto case 25;
				case 10:
					_InitializerReader = true;
					num2 = 24;
					continue;
				case 26:
					pageReader = true;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_051a77b7adc247648288e15ce722ff61 == 0)
					{
						num2 = 9;
					}
					continue;
				case 8:
					WriteBreak(breakChar);
					num2 = 26;
					continue;
				case 5:
					if (num3 + 1 < value.Length)
					{
						num2 = 4;
						continue;
					}
					goto case 19;
				case 25:
					WriteIndent();
					num2 = 17;
					continue;
				case 12:
				case 17:
					Write(c);
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 != 0)
					{
						num2 = 7;
					}
					continue;
				default:
					if (num3 >= value.Length)
					{
						num = 22;
						break;
					}
					goto case 2;
				case 1:
					flag = false;
					num2 = 20;
					continue;
				case 9:
					flag = true;
					num2 = 23;
					continue;
				case 15:
					WriteIndicator(DicSingleton.gE3WbyDVW(-360128320 ^ -360145814), needWhitespace: true, whitespace: false, indentation: false);
					num2 = 21;
					continue;
				case 22:
					return;
				case 20:
				case 23:
					num3++;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
					{
						num2 = 0;
					}
					continue;
				case 11:
					WriteBreak();
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ee4d3fc4026d4c129a24d79452c64e91 == 0)
					{
						num2 = 6;
					}
					continue;
				case 14:
					if (c == '\r')
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
						{
							num2 = 5;
						}
						continue;
					}
					goto case 19;
				case 7:
					pageReader = false;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 == 0)
					{
						num2 = 1;
					}
					continue;
				case 6:
					pageReader = true;
					num2 = 10;
					continue;
				case 2:
					c = value[num3];
					num2 = 14;
					continue;
				case 19:
					if (!IsBreak(c, out breakChar))
					{
						num2 = 18;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_665e7817cf9b46a2974749992ca51c3f == 0)
						{
							num2 = 18;
						}
						continue;
					}
					goto case 8;
				case 16:
					flag = true;
					num2 = 15;
					continue;
				case 4:
					if (value[num3 + 1] != '\n')
					{
						num2 = 19;
						continue;
					}
					goto case 20;
				case 24:
					num3 = 0;
					num = 13;
					break;
				}
				break;
			}
		}
	}

	private void WriteFoldedScalar(string value)
	{
		int num = 41;
		char c = default(char);
		bool flag2 = default(bool);
		bool flag = default(bool);
		char breakChar2 = default(char);
		int num4 = default(int);
		int num3 = default(int);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				char breakChar;
				switch (num2)
				{
				case 36:
					WriteBreak();
					num = 44;
					break;
				default:
					if (c == '\n')
					{
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cb5caf5e947a4fb4b45ac04ad3e8c2e2 != 0)
						{
							num2 = 46;
						}
						continue;
					}
					goto case 4;
				case 40:
					flag2 = true;
					num2 = 8;
					continue;
				case 14:
					if (!flag2)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 4;
				case 27:
				case 45:
					Write(c);
					num = 39;
					break;
				case 42:
					WriteBreak();
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
					{
						num2 = 6;
					}
					continue;
				case 23:
					flag = true;
					num2 = 26;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba != 0)
					{
						num2 = 25;
					}
					continue;
				case 44:
					pageReader = true;
					num2 = 12;
					continue;
				case 5:
					WriteBlockScalarHints(value);
					num2 = 36;
					continue;
				case 19:
					if (!IsBreak(c, out breakChar2))
					{
						num2 = 15;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 == 0)
						{
							num2 = 10;
						}
						continue;
					}
					goto case 7;
				case 21:
				case 34:
					num4++;
					num2 = 2;
					continue;
				case 2:
				case 22:
					if (num3 + num4 < value.Length)
					{
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_62c552f8f90c4740853f4e2aab358973 == 0)
						{
							num2 = 0;
						}
						continue;
					}
					goto case 31;
				case 7:
					if (flag)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4b4a77ae9ecd49f797aef5594c888a78 == 0)
						{
							num2 = 16;
						}
						continue;
					}
					goto case 14;
				case 26:
				case 37:
					num3++;
					num2 = 49;
					continue;
				case 6:
					if (IsBreak(value[num3 + num4], out breakChar))
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
						{
							num2 = 21;
						}
						continue;
					}
					goto case 31;
				case 12:
					_InitializerReader = true;
					num = 20;
					break;
				case 32:
				case 33:
					c = value[num3];
					num2 = 19;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
					{
						num2 = 11;
					}
					continue;
				case 3:
					if (c == ' ')
					{
						num2 = 11;
						continue;
					}
					goto case 27;
				case 35:
					if (IsBlank(value[num3 + num4]))
					{
						num2 = 28;
						continue;
					}
					goto case 51;
				case 15:
				case 50:
					if (!flag)
					{
						num = 18;
						break;
					}
					goto case 29;
				case 1:
					flag = false;
					num2 = 37;
					continue;
				case 41:
					flag = true;
					num2 = 11;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
					{
						num2 = 40;
					}
					continue;
				case 11:
					if (num3 + 1 >= value.Length)
					{
						num2 = 45;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
						{
							num2 = 5;
						}
						continue;
					}
					goto case 17;
				case 38:
					if (m_TestsReader > m_ExpressionReader)
					{
						num2 = 25;
						continue;
					}
					goto case 27;
				case 8:
					WriteIndicator(DicSingleton.gE3WbyDVW(0x55F5513C ^ 0x55F521B4), needWhitespace: true, whitespace: false, indentation: false);
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6d5e0e859ce64925914e2556bfaca564 != 0)
					{
						num2 = 5;
					}
					continue;
				case 31:
					if (num3 + num4 >= value.Length)
					{
						num2 = 43;
						continue;
					}
					goto case 35;
				case 13:
					flag2 = IsBlank(c);
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c == 0)
					{
						num2 = 47;
					}
					continue;
				case 9:
				case 39:
					pageReader = false;
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
					{
						num2 = 1;
					}
					continue;
				case 29:
					WriteIndent();
					num2 = 13;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
					{
						num2 = 4;
					}
					continue;
				case 20:
					num3 = 0;
					num2 = 48;
					continue;
				case 48:
				case 49:
					if (num3 < value.Length)
					{
						num2 = 29;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ea4c8b68ad954c0fb4df33d6e06bd4a3 == 0)
						{
							num2 = 32;
						}
						continue;
					}
					return;
				case 46:
					num4 = 0;
					num2 = 22;
					continue;
				case 24:
					return;
				case 18:
				case 47:
					if (!flag)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 == 0)
						{
							num2 = 3;
						}
						continue;
					}
					goto case 27;
				case 51:
					if (IsBreak(value[num3 + num4], out breakChar))
					{
						num = 4;
						break;
					}
					goto case 42;
				case 30:
					pageReader = true;
					num = 23;
					break;
				case 25:
					WriteIndent();
					num2 = 9;
					continue;
				case 4:
				case 10:
				case 16:
				case 28:
				case 43:
					WriteBreak(breakChar2);
					num = 30;
					break;
				case 17:
					if (value[num3 + 1] != ' ')
					{
						num2 = 38;
						continue;
					}
					goto case 27;
				}
				break;
			}
		}
	}

	private static bool IsSpace(char character)
	{
		return character == ' ';
	}

	private static bool IsBreak(char character, out char breakChar)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 4:
				if (character != '\u2029')
				{
					num2 = 7;
					break;
				}
				goto IL_00c5;
			case 9:
				breakChar = '\n';
				num2 = 4;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
				{
					num2 = 6;
				}
				break;
			default:
				if (character != '\r')
				{
					num2 = 10;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_782b9fd57e5044f7b71c173d397be537 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 9;
			case 2:
				if ((uint)character <= 13u)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_21ebac92c1964d17a2f1691323f7e749 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 5;
			case 6:
				return true;
			case 11:
				if (character != '\u2028')
				{
					num2 = 4;
					break;
				}
				goto IL_00c5;
			case 1:
				if (character != '\n')
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7df7171f7aa0465bbe9166ed73563ac8 == 0)
					{
						num2 = 0;
					}
					break;
				}
				goto case 9;
			case 8:
				return true;
			case 7:
			case 10:
				breakChar = '\0';
				num2 = 3;
				break;
			case 3:
				return false;
			case 5:
				{
					if (character != '\u0085')
					{
						num2 = 11;
						break;
					}
					goto case 9;
				}
				IL_00c5:
				breakChar = character;
				num2 = 8;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
				{
					num2 = 8;
				}
				break;
			}
		}
	}

	private static bool IsBlank(char character)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				if (character != ' ')
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_8475f1e725794f71a927e7259d43b9e8 == 0)
					{
						num2 = 0;
					}
					break;
				}
				return true;
			default:
				return character == '\t';
			}
		}
	}

	private static bool IsPrintable(char character)
	{
		int num = 5;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 4:
					if (character != '\n')
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_575e6bd686b54d028cdc3fc324b58a39 != 0)
						{
							num2 = 1;
						}
						break;
					}
					goto case 8;
				case 9:
					if (character < '\u00a0')
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
						{
							num2 = 7;
						}
						break;
					}
					goto case 10;
				case 11:
					if (character != '\u0085')
					{
						goto end_IL_0012;
					}
					goto case 8;
				case 3:
				case 7:
					if (character < '\ue000')
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 2;
				case 6:
					if (character >= ' ')
					{
						num2 = 12;
						break;
					}
					goto case 11;
				case 1:
					if (character != '\r')
					{
						num2 = 6;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 != 0)
						{
							num2 = 3;
						}
						break;
					}
					goto case 8;
				case 2:
					return character <= '\ufffd';
				default:
					return false;
				case 8:
					return true;
				case 12:
					if (character > '~')
					{
						num2 = 11;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 != 0)
						{
							num2 = 8;
						}
						break;
					}
					goto case 8;
				case 10:
					if (character <= '\ud7ff')
					{
						num2 = 8;
						break;
					}
					goto case 3;
				case 5:
					if (character != '\t')
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
						{
							num2 = 1;
						}
						break;
					}
					goto case 8;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 9;
		}
	}

	private static bool IsHighSurrogate(char c)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return c <= '\udbff';
			case 1:
				if ('\ud800' > c)
				{
					return false;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9f27e43a462d4950aeddffb5e1eef618 == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private static bool IsLowSurrogate(char c)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return c <= '\udfff';
			case 1:
				if ('\udc00' > c)
				{
					return false;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa91062d6d7d466bb06a8f1fef522aac != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private void EmitSequenceStart(MappingFactory evt)
	{
		int num = 4;
		RefFactory refFactory = default(RefFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 9:
					if (refFactory.Style != (ProcFactory)2)
					{
						num2 = 8;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cc3a460cd74a4c809e0f755964f2077b != 0)
						{
							num2 = 7;
						}
						break;
					}
					goto case 1;
				case 7:
					return;
				default:
					refFactory = (RefFactory)evt;
					num2 = 2;
					break;
				case 2:
					if (m_WorkerReader != 0)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_338a00fcd04147c5958075dff97c66d2 == 0)
						{
							num2 = 1;
						}
						break;
					}
					goto case 5;
				case 6:
					return;
				case 8:
					if (!CheckEmptySequence())
					{
						m_ProductReader = (RegReader)12;
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0fe0029f89e1416c8230ba370305f0af != 0)
						{
							num2 = 6;
						}
					}
					else
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7052159e85be4943b70f0f7170796633 == 0)
						{
							num2 = 10;
						}
					}
					break;
				case 4:
					ProcessAnchor();
					num2 = 3;
					break;
				case 5:
					if (!systemReader)
					{
						goto end_IL_0012;
					}
					goto case 1;
				case 1:
				case 10:
					m_ProductReader = (RegReader)6;
					num2 = 7;
					break;
				case 3:
					ProcessTag();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
					{
						num2 = 0;
					}
					break;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 9;
		}
	}

	private void EmitMappingStart(MappingFactory evt)
	{
		int num = 4;
		QueueFactory queueFactory = default(QueueFactory);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 4:
					ProcessAnchor();
					num2 = 3;
					break;
				case 1:
				case 5:
					m_ProductReader = (RegReader)8;
					num2 = 10;
					break;
				case 7:
					if (!CheckEmptyMapping())
					{
						goto end_IL_0012;
					}
					goto case 1;
				case 8:
					if (m_WorkerReader == 0)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
						{
							num2 = 2;
						}
						break;
					}
					goto case 1;
				case 6:
					if (queueFactory.Style != (TokenizerFactory)2)
					{
						num2 = 7;
						break;
					}
					goto case 1;
				default:
					queueFactory = (QueueFactory)evt;
					num2 = 8;
					break;
				case 2:
					if (systemReader)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 == 0)
						{
							num2 = 1;
						}
						break;
					}
					goto case 6;
				case 3:
					ProcessTag();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
					{
						num2 = 0;
					}
					break;
				case 9:
					return;
				case 10:
					return;
				case 11:
					m_ProductReader = (RegReader)14;
					num2 = 9;
					break;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 11;
		}
	}

	private void ProcessAnchor()
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 3:
				if (!paramReader.m_OrderReader.IsEmpty)
				{
					num2 = 2;
					continue;
				}
				return;
			case 2:
				if (resolverReader)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a3107ce40e048d8bbbd5e1ebcb0dbe7 == 0)
					{
						num2 = 0;
					}
					continue;
				}
				break;
			case 1:
				return;
			case 4:
				return;
			case 5:
				WriteAnchor(paramReader.m_OrderReader);
				num2 = 4;
				continue;
			}
			WriteIndicator(paramReader._ContainerReader ? DicSingleton.gE3WbyDVW(-475093377 ^ -475081637) : DicSingleton.gE3WbyDVW(0x44072FB7 ^ 0x44075307), needWhitespace: true, whitespace: false, indentation: false);
			num2 = 5;
		}
	}

	private void ProcessTag()
	{
		int num = 2;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 5:
					return;
				case 9:
					WriteTagHandle(_FacadeReader._ClientReader);
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_deca1a60960f4d6fa54e941b8d117935 != 0)
					{
						num2 = 7;
					}
					continue;
				case 8:
					return;
				case 1:
				case 6:
					if (_FacadeReader._ClientReader == null)
					{
						num2 = 4;
						continue;
					}
					goto case 9;
				default:
					WriteTagContent(_FacadeReader.m_RecordReader, needsWhitespace: false);
					num = 11;
					break;
				case 11:
					return;
				case 4:
					WriteIndicator(DicSingleton.gE3WbyDVW(0x3C33E48 ^ 0x3C342FE), needWhitespace: true, whitespace: false, indentation: false);
					num2 = 10;
					continue;
				case 2:
					if (_FacadeReader._ClientReader != null)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec != 0)
						{
							num2 = 1;
						}
						continue;
					}
					goto case 12;
				case 3:
					WriteIndicator(DicSingleton.gE3WbyDVW(0x14AB6F1E ^ 0x14AB1F96), needWhitespace: false, whitespace: false, indentation: false);
					num = 5;
					break;
				case 12:
					if (_FacadeReader.m_RecordReader == null)
					{
						return;
					}
					num2 = 6;
					continue;
				case 7:
					if (_FacadeReader.m_RecordReader == null)
					{
						return;
					}
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 != 0)
					{
						num2 = 0;
					}
					continue;
				case 10:
					WriteTagContent(_FacadeReader.m_RecordReader, needsWhitespace: false);
					num2 = 3;
					continue;
				}
				break;
			}
		}
	}

	private void EmitDocumentEnd(MappingFactory evt)
	{
		int num = 6;
		int num2 = num;
		ProcessorFactory processorFactory = default(ProcessorFactory);
		while (true)
		{
			switch (num2)
			{
			case 4:
				WriteIndicator(DicSingleton.gE3WbyDVW(0x1679942F ^ 0x1679ED77), needWhitespace: true, whitespace: false, indentation: false);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_40c050a7d99c4c41902fac6f9983048c != 0)
				{
					num2 = 0;
				}
				break;
			case 8:
				_RequestReader = true;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
				{
					num2 = 0;
				}
				break;
			case 9:
				return;
			case 3:
				m_DecoratorReader.Clear();
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ac3bb60767a4458f85c02b64903d90f7 == 0)
				{
					num2 = 9;
				}
				break;
			case 5:
				if (processorFactory == null)
				{
					throw new TestsFactory(DicSingleton.gE3WbyDVW(-1180565667 ^ -1180597277));
				}
				num2 = 10;
				break;
			case 6:
				processorFactory = evt as ProcessorFactory;
				num2 = 5;
				break;
			default:
				m_ProductReader = (RegReader)3;
				num2 = 3;
				break;
			case 10:
				WriteIndent();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
				{
					num2 = 1;
				}
				break;
			case 2:
				if (processorFactory.IsImplicit)
				{
					num2 = 7;
					break;
				}
				goto case 4;
			case 1:
				WriteIndent();
				num2 = 8;
				break;
			}
		}
	}

	private void EmitFlowSequenceItem(MappingFactory evt, bool isFirst)
	{
		int num = 19;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 10:
					EmitNode(evt, isMapping: false, isSimpleKey: false);
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ababfc7332d7499ea3bf8bbde1ffbfa4 == 0)
					{
						num2 = 16;
					}
					break;
				case 8:
					IncreaseIndent(isFlow: true, isIndentless: false);
					num2 = 21;
					break;
				case 6:
					if (systemReader)
					{
						goto end_IL_0012;
					}
					goto case 1;
				case 22:
					return;
				case 1:
					WriteIndicator(DicSingleton.gE3WbyDVW(0x2D27936 ^ 0x2D21168), needWhitespace: false, whitespace: false, indentation: false);
					num2 = 13;
					break;
				case 3:
				case 18:
					if (!(evt is SpecificationFactory))
					{
						if (!isFirst)
						{
							num2 = 15;
							if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb == 0)
							{
								num2 = 15;
							}
							break;
						}
						goto case 20;
					}
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_620ff519cd5146db8cb328ea29573dba != 0)
					{
						num2 = 5;
					}
					break;
				case 17:
					broadcasterReader = valueReader.Pop();
					num2 = 6;
					break;
				case 16:
					return;
				case 2:
					WriteIndicator(DicSingleton.gE3WbyDVW(0x1606DF07 ^ 0x1606A3F3), needWhitespace: false, whitespace: false, indentation: false);
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_49107028423047bfbf9c33e5a2ab8cf8 == 0)
					{
						num2 = 0;
					}
					break;
				case 20:
					if (!systemReader)
					{
						num2 = 11;
						break;
					}
					goto case 4;
				case 19:
					if (!isFirst)
					{
						num2 = 18;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_676e4d1e88614f209c4f0f709fb1b889 == 0)
						{
							num2 = 8;
						}
						break;
					}
					goto default;
				case 7:
					m_WorkerReader--;
					num2 = 17;
					break;
				case 4:
					WriteIndent();
					num2 = 9;
					break;
				default:
					WriteIndicator(DicSingleton.gE3WbyDVW(-428135557 ^ -428124267), needWhitespace: true, whitespace: true, indentation: false);
					num2 = 8;
					break;
				case 9:
				case 14:
					registryReader.Push((RegReader)7);
					num2 = 10;
					break;
				case 12:
					if (!isFirst)
					{
						num2 = 2;
						break;
					}
					goto case 1;
				case 13:
					m_ProductReader = registryReader.Pop();
					num2 = 22;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4e61b266153f422fa6c595cfef4d40d3 != 0)
					{
						num2 = 2;
					}
					break;
				case 21:
					m_WorkerReader++;
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_abde506ba2014ea4bed535a350def284 == 0)
					{
						num2 = 0;
					}
					break;
				case 11:
					if (m_TestsReader <= m_ExpressionReader)
					{
						num2 = 14;
						break;
					}
					goto case 4;
				case 15:
					WriteIndicator(DicSingleton.gE3WbyDVW(0x166FBD ^ 0x161349), needWhitespace: false, whitespace: false, indentation: false);
					num2 = 20;
					break;
				case 5:
					WriteIndent();
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_991b0c59dea646d1b25598070985b795 == 0)
					{
						num2 = 1;
					}
					break;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 12;
		}
	}

	private void EmitFlowMappingKey(MappingFactory evt, bool isFirst)
	{
		int num = 28;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 28:
					if (!isFirst)
					{
						num2 = 27;
						break;
					}
					goto case 16;
				case 31:
					WriteIndicator(DicSingleton.gE3WbyDVW(-1064640644 ^ -1064655992), needWhitespace: false, whitespace: false, indentation: false);
					num2 = 23;
					break;
				case 23:
					WriteIndent();
					num2 = 19;
					break;
				case 18:
					if (!systemReader)
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 == 0)
						{
							num2 = 3;
						}
						break;
					}
					goto case 30;
				case 3:
				case 19:
					WriteIndicator(DicSingleton.gE3WbyDVW(-1385030784 ^ -1385017528), needWhitespace: false, whitespace: false, indentation: false);
					num2 = 26;
					break;
				case 17:
					m_WorkerReader--;
					num2 = 11;
					break;
				case 8:
					return;
				case 13:
					if (isFirst)
					{
						num2 = 15;
						break;
					}
					goto case 7;
				case 22:
					return;
				case 20:
				case 27:
					if (!(evt is ListFactory))
					{
						num2 = 13;
						break;
					}
					goto case 17;
				case 29:
					if (m_TestsReader > m_ExpressionReader)
					{
						num2 = 7;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f == 0)
						{
							num2 = 25;
						}
						break;
					}
					goto case 21;
				case 4:
					m_WorkerReader++;
					num2 = 20;
					break;
				case 6:
					return;
				case 5:
					WriteIndicator(DicSingleton.gE3WbyDVW(0x408F2744 ^ 0x408F5BBE), needWhitespace: true, whitespace: false, indentation: false);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 == 0)
					{
						num2 = 0;
					}
					break;
				case 1:
				case 15:
					if (systemReader)
					{
						num2 = 24;
						break;
					}
					goto case 29;
				case 11:
					broadcasterReader = valueReader.Pop();
					num2 = 16;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c != 0)
					{
						num2 = 18;
					}
					break;
				case 12:
					if (CheckSimpleKey())
					{
						goto end_IL_0012;
					}
					goto case 5;
				case 21:
					if (systemReader)
					{
						num2 = 5;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
						{
							num2 = 2;
						}
						break;
					}
					goto case 12;
				case 9:
					registryReader.Push((RegReader)10);
					num2 = 10;
					break;
				case 26:
					m_ProductReader = registryReader.Pop();
					num2 = 8;
					break;
				case 2:
					IncreaseIndent(isFlow: true, isIndentless: false);
					num2 = 4;
					break;
				case 16:
					WriteIndicator(DicSingleton.gE3WbyDVW(-1335677307 ^ -1335657913), needWhitespace: true, whitespace: true, indentation: false);
					num2 = 2;
					break;
				case 7:
					WriteIndicator(DicSingleton.gE3WbyDVW(0x33F6A245 ^ 0x33F6DEB1), needWhitespace: false, whitespace: false, indentation: false);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9dd9debb4bc4309ae599e924cc6f015 != 0)
					{
						num2 = 1;
					}
					break;
				case 10:
					EmitNode(evt, isMapping: true, isSimpleKey: true);
					num2 = 6;
					break;
				default:
					registryReader.Push((RegReader)11);
					num2 = 14;
					break;
				case 24:
				case 25:
					WriteIndent();
					num2 = 21;
					break;
				case 14:
					EmitNode(evt, isMapping: true, isSimpleKey: false);
					num2 = 22;
					break;
				case 30:
					if (!isFirst)
					{
						num2 = 31;
						break;
					}
					goto case 3;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 9;
		}
	}

	private void EmitFlowMappingValue(MappingFactory evt, bool isSimple)
	{
		int num = 7;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 9:
				EmitNode(evt, isMapping: true, isSimpleKey: false);
				num2 = 4;
				continue;
			case 10:
				WriteIndicator(DicSingleton.gE3WbyDVW(0x6CF51E1A ^ 0x6CF5631A), needWhitespace: false, whitespace: false, indentation: false);
				num2 = 8;
				continue;
			case 3:
			case 6:
				if (!systemReader)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_30b23035746d474c85a0d608a8cd84ba == 0)
					{
						num2 = 1;
					}
					continue;
				}
				break;
			case 4:
				return;
			case 5:
			case 8:
				registryReader.Push((RegReader)9);
				num2 = 9;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a49741025f5b4ff49da218b7e9061a4d == 0)
				{
					num2 = 1;
				}
				continue;
			case 7:
				if (!isSimple)
				{
					num2 = 6;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_daf96aa7ab3f4220a03af22608e2cb34 != 0)
					{
						num2 = 2;
					}
					continue;
				}
				goto case 10;
			case 2:
				WriteIndicator(DicSingleton.gE3WbyDVW(-1075938037 ^ -1075970037), needWhitespace: true, whitespace: false, indentation: false);
				num2 = 5;
				continue;
			case 1:
				if (m_TestsReader > m_ExpressionReader)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec == 0)
					{
						num2 = 0;
					}
					continue;
				}
				goto case 2;
			}
			WriteIndent();
			num2 = 2;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e9ac33b6e51a4410b06e83a511cb6136 != 0)
			{
				num2 = 2;
			}
		}
	}

	private void EmitBlockSequenceItem(MappingFactory evt, bool isFirst)
	{
		int num = 6;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					registryReader.Push((RegReader)13);
					num2 = 10;
					continue;
				case 10:
					EmitNode(evt, isMapping: false, isSimpleKey: false);
					num2 = 7;
					continue;
				case 5:
				case 8:
					if (!(evt is SpecificationFactory))
					{
						num2 = 3;
						continue;
					}
					goto case 1;
				case 4:
					m_ProductReader = registryReader.Pop();
					num2 = 11;
					continue;
				case 11:
					return;
				case 3:
					WriteIndent();
					num2 = 9;
					continue;
				case 9:
					WriteIndicator(DicSingleton.gE3WbyDVW(0x1A7A0414 ^ 0x1A7A0888), needWhitespace: true, whitespace: false, indentation: true);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 == 0)
					{
						num2 = 0;
					}
					continue;
				case 6:
					if (!isFirst)
					{
						num2 = 5;
						continue;
					}
					break;
				case 7:
					return;
				case 1:
					broadcasterReader = valueReader.Pop();
					num2 = 4;
					continue;
				case 2:
					break;
				}
				break;
			}
			IncreaseIndent(isFlow: false, taskReader && !pageReader);
			num = 8;
		}
	}

	private void EmitBlockMappingKey(MappingFactory evt, bool isFirst)
	{
		int num = 9;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 6:
				return;
			case 3:
				broadcasterReader = valueReader.Pop();
				num2 = 13;
				break;
			case 7:
				return;
			case 11:
				EmitNode(evt, isMapping: true, isSimpleKey: false);
				num2 = 7;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_23f9d18f43004f488662f38dd306f6ec != 0)
				{
					num2 = 4;
				}
				break;
			case 5:
				return;
			case 12:
				WriteIndicator(DicSingleton.gE3WbyDVW(-1385030784 ^ -1385011334), needWhitespace: true, whitespace: false, indentation: true);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_5378272de30c4038a7e6ab47ae16d4cf == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				if (!CheckSimpleKey())
				{
					num2 = 12;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 == 0)
					{
						num2 = 7;
					}
					break;
				}
				goto case 1;
			case 1:
				registryReader.Push((RegReader)16);
				num2 = 4;
				break;
			case 13:
				m_ProductReader = registryReader.Pop();
				num2 = 6;
				break;
			case 10:
				if (!(evt is ListFactory))
				{
					WriteIndent();
					num2 = 2;
				}
				else
				{
					num2 = 3;
				}
				break;
			case 4:
				EmitNode(evt, isMapping: true, isSimpleKey: true);
				num2 = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_aa5edaa577bf42ec99869c7002268a63 == 0)
				{
					num2 = 3;
				}
				break;
			case 9:
				if (isFirst)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a != 0)
					{
						num2 = 8;
					}
					break;
				}
				goto case 10;
			default:
				registryReader.Push((RegReader)17);
				num2 = 11;
				break;
			case 8:
				IncreaseIndent(isFlow: false, isIndentless: false);
				num2 = 10;
				break;
			}
		}
	}

	private void EmitBlockMappingValue(MappingFactory evt, bool isSimple)
	{
		int num = 7;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					WriteIndicator(DicSingleton.gE3WbyDVW(-940539791 ^ -940507791), needWhitespace: false, whitespace: false, indentation: false);
					num2 = 3;
					break;
				case 7:
					if (!isSimple)
					{
						goto end_IL_0012;
					}
					goto case 1;
				case 5:
					return;
				case 2:
				case 6:
					WriteIndent();
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d5c0c185d7b1430b897cb64adc93b81c != 0)
					{
						num2 = 0;
					}
					break;
				default:
					WriteIndicator(DicSingleton.gE3WbyDVW(0x3C33E48 ^ 0x3C34348), needWhitespace: true, whitespace: false, indentation: true);
					num2 = 8;
					break;
				case 3:
				case 8:
					registryReader.Push((RegReader)15);
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c2b9915913b8461884afdca5d98855ec != 0)
					{
						num2 = 4;
					}
					break;
				case 4:
					EmitNode(evt, isMapping: true, isSimpleKey: false);
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3b117c4a3ac14a7981c7985bf3a1dedb == 0)
					{
						num2 = 0;
					}
					break;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 6;
		}
	}

	private void IncreaseIndent(bool isFlow, bool isIndentless)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 6:
				return;
			case 4:
				if (_ParserReader)
				{
					return;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_e18a410c8e474c77a7009b853bfa5fd3 != 0)
				{
					num2 = 0;
				}
				break;
			case 3:
				return;
			case 2:
				valueReader.Push(broadcasterReader);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
				{
					num2 = 1;
				}
				break;
			case 1:
				if (broadcasterReader >= 0)
				{
					if (isIndentless)
					{
						num2 = 4;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a81b4e9adc64452f9d5879a46030258f != 0)
						{
							num2 = 0;
						}
						break;
					}
					goto default;
				}
				num2 = 5;
				break;
			default:
				broadcasterReader += _CandidateReader;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f92fb16082174ff29c1cf0085d4a3cb9 == 0)
				{
					num2 = 6;
				}
				break;
			case 5:
				broadcasterReader = (isFlow ? _CandidateReader : 0);
				num2 = 3;
				break;
			}
		}
	}

	private bool CheckEmptyDocument()
	{
		int num = 0;
		foreach (MappingFactory item in m_StateReader)
		{
			num++;
			if (num == 2)
			{
				if (!(item is ClassFactory classFactory))
				{
					break;
				}
				return string.IsNullOrEmpty(classFactory.Value);
			}
		}
		return false;
	}

	private bool CheckSimpleKey()
	{
		int num = 13;
		int num3 = default(int);
		SchemaCompareFilterSetting type = default(SchemaCompareFilterSetting);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 13:
					if (m_StateReader.Count >= 1)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6b6a357cf2b54e6ab6bdc50bb8bca510 != 0)
						{
							num2 = 12;
						}
						continue;
					}
					goto case 2;
				case 11:
					return false;
				case 8:
					return false;
				case 4:
					num3 = AnchorNameLength(paramReader.m_OrderReader) + SafeStringLength(_FacadeReader._ClientReader) + SafeStringLength(_FacadeReader.m_RecordReader) + SafeStringLength(eventReader._BridgeReader);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 == 0)
					{
						num2 = 1;
					}
					continue;
				case 18:
					if (!eventReader._ParameterReader)
					{
						num2 = 4;
						continue;
					}
					goto case 8;
				case 5:
					switch (type)
					{
					case (SchemaCompareFilterSetting)6:
						break;
					default:
						goto IL_01bf;
					case (SchemaCompareFilterSetting)9:
						goto IL_01c9;
					case (SchemaCompareFilterSetting)5:
						goto IL_0225;
					case (SchemaCompareFilterSetting)8:
						goto IL_0252;
					case (SchemaCompareFilterSetting)7:
						goto IL_02fb;
					}
					goto case 18;
				case 3:
					goto IL_01c9;
				case 15:
					return false;
				case 9:
					break;
				case 7:
					goto IL_0225;
				case 6:
				case 10:
					goto IL_0252;
				default:
					return num3 <= _CustomerReader;
				case 2:
					return false;
				case 12:
					type = m_StateReader.Peek().Type;
					num2 = 5;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3710a105bc4344a1ad87815e3f4589bb == 0)
					{
						num2 = 1;
					}
					continue;
				case 17:
					goto IL_02fb;
					IL_02fb:
					if (CheckEmptySequence())
					{
						num2 = 9;
						continue;
					}
					goto case 15;
					IL_0252:
					return false;
					IL_0225:
					num3 = AnchorNameLength(paramReader.m_OrderReader);
					num2 = 16;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_dc078397889c462089e05ffb02190f41 == 0)
					{
						num2 = 9;
					}
					continue;
					IL_01c9:
					if (CheckEmptySequence())
					{
						num3 = AnchorNameLength(paramReader.m_OrderReader) + SafeStringLength(_FacadeReader._ClientReader) + SafeStringLength(_FacadeReader.m_RecordReader);
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7a22e2c8e9a416e890a8117f7355351 != 0)
						{
							num2 = 0;
						}
					}
					else
					{
						num2 = 11;
					}
					continue;
					IL_01bf:
					num2 = 10;
					continue;
				}
				break;
			}
			num3 = AnchorNameLength(paramReader.m_OrderReader) + SafeStringLength(_FacadeReader._ClientReader) + SafeStringLength(_FacadeReader.m_RecordReader);
			num = 14;
		}
	}

	private int AnchorNameLength(HelperReader value)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				if (value.IsEmpty)
				{
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 == 0)
					{
						num2 = 1;
					}
					break;
				}
				goto default;
			default:
				return value.Value.Length;
			case 1:
				return 0;
			}
		}
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(2)]
	private int SafeStringLength(string value)
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return value.Length;
			case 1:
				if (value == null)
				{
					return 0;
				}
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_45304743781e412aadc853024bd59c0a == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private bool CheckEmptySequence()
	{
		return CheckEmptyStructure<RefFactory, SpecificationFactory>();
	}

	private bool CheckEmptyMapping()
	{
		return CheckEmptyStructure<QueueFactory, ListFactory>();
	}

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)]
	private bool CheckEmptyStructure<TStart, TEnd>() where TStart : ListenerFactory where TEnd : MappingFactory
	{
		if (m_StateReader.Count < 2)
		{
			return false;
		}
		using Queue<MappingFactory>.Enumerator enumerator = m_StateReader.GetEnumerator();
		return enumerator.MoveNext() && enumerator.Current is TStart && enumerator.MoveNext() && enumerator.Current is TEnd;
	}

	private void WriteBlockScalarHints(string value)
	{
		int num = 5;
		int candidateReader = default(int);
		string text = default(string);
		IdentifierReader<CandidateFactory> identifierReader = default(IdentifierReader<CandidateFactory>);
		string indicator = default(string);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 8:
				case 13:
					candidateReader = _CandidateReader;
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 != 0)
					{
						num2 = 2;
					}
					break;
				case 12:
				case 20:
					text = null;
					num2 = 11;
					break;
				case 3:
				case 19:
					if (value.Length >= 2)
					{
						num2 = 15;
						break;
					}
					goto case 7;
				case 11:
					if (value.Length == 0)
					{
						num2 = 16;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f5e55970949c4f5fbf619e58da059357 != 0)
						{
							num2 = 1;
						}
						break;
					}
					goto case 9;
				case 7:
				case 17:
					if (text != null)
					{
						num2 = 14;
						break;
					}
					return;
				case 9:
					if (identifierReader.IsBreak(value.Length - 1))
					{
						num2 = 3;
						break;
					}
					goto case 6;
				case 1:
					text = DicSingleton.gE3WbyDVW(0x6CF51E1A ^ 0x6CF5631C);
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1a57b3f2a96349888c6d127aa1caecc1 != 0)
					{
						num2 = 2;
					}
					break;
				case 18:
					return;
				case 4:
					if (identifierReader.IsSpace())
					{
						goto end_IL_0012;
					}
					goto default;
				case 6:
				case 16:
					text = DicSingleton.gE3WbyDVW(0x2BB207E4 ^ 0x2BB20B78);
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_6931aa1fe7d848f2a3129c471825c2d3 != 0)
					{
						num2 = 17;
					}
					break;
				case 5:
					identifierReader = new IdentifierReader<CandidateFactory>(new CandidateFactory(value));
					num2 = 4;
					break;
				default:
					if (!identifierReader.IsBreak())
					{
						num2 = 12;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb != 0)
						{
							num2 = 1;
						}
						break;
					}
					goto case 8;
				case 10:
					WriteIndicator(indicator, needWhitespace: false, whitespace: false, indentation: false);
					num2 = 20;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e == 0)
					{
						num2 = 20;
					}
					break;
				case 2:
					indicator = candidateReader.ToString(CultureInfo.InvariantCulture);
					num2 = 10;
					break;
				case 15:
					if (identifierReader.IsBreak(value.Length - 2))
					{
						num2 = 1;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3c1fe9b6a68947f8b523fe70a4b436be == 0)
						{
							num2 = 0;
						}
						break;
					}
					goto case 7;
				case 14:
					WriteIndicator(text, needWhitespace: false, whitespace: false, indentation: false);
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7532a5ce33234725866e639f0bf59ff6 == 0)
					{
						num2 = 18;
					}
					break;
				}
				continue;
				end_IL_0012:
				break;
			}
			num = 13;
		}
	}

	private void WriteIndicator(string indicator, bool needWhitespace, bool whitespace, bool indentation)
	{
		int num = 6;
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					pageReader &= indentation;
					num2 = 7;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_0a707bb791e14c9e9a3ee77696a896b0 == 0)
					{
						num2 = 6;
					}
					continue;
				case 7:
					return;
				case 3:
					Write(' ');
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 != 0)
					{
						num2 = 0;
					}
					continue;
				case 6:
					if (!needWhitespace)
					{
						break;
					}
					goto end_IL_0012;
				case 5:
					if (_InitializerReader)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d712280152f14548999b544b0a5dfb00 != 0)
						{
							num2 = 4;
						}
						continue;
					}
					goto case 3;
				case 2:
					_InitializerReader = whitespace;
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f2eb374183b9434594b1e98f9246f69f == 0)
					{
						num2 = 1;
					}
					continue;
				}
				Write(indicator);
				num2 = 2;
				continue;
				end_IL_0012:
				break;
			}
			num = 5;
		}
	}

	private void WriteIndent()
	{
		int num = 12;
		int num2 = num;
		int num3 = default(int);
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 10:
				pageReader = true;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ff73a69674ef4cc6bb5c8f874d514910 != 0)
				{
					num2 = 0;
				}
				continue;
			case 9:
				if (m_TestsReader == num3)
				{
					num2 = 5;
					continue;
				}
				goto case 1;
			case 11:
				if (pageReader)
				{
					num2 = 3;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_cff967a4a3db4480a0028dad7fb81f91 != 0)
					{
						num2 = 2;
					}
					continue;
				}
				break;
			case 3:
				if (m_TestsReader <= num3)
				{
					num2 = 9;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4bb83e88c88e4ec58a43c7cbc53db121 != 0)
					{
						num2 = 9;
					}
					continue;
				}
				break;
			case 6:
			case 8:
				Write(' ');
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_2e429cabf9f148399f35cad41560f74e != 0)
				{
					num2 = 1;
				}
				continue;
			case 4:
				WriteBreak();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
				{
					num2 = 1;
				}
				continue;
			case 1:
			case 2:
				if (m_TestsReader < num3)
				{
					num2 = 6;
					continue;
				}
				goto case 7;
			case 5:
				if (!_InitializerReader)
				{
					break;
				}
				goto case 1;
			case 7:
				_InitializerReader = true;
				num2 = 7;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_d894c7c5e74b44b4b513e4b709fb9f21 != 0)
				{
					num2 = 10;
				}
				continue;
			case 0:
				return;
			case 12:
				num3 = Math.Max(broadcasterReader, 0);
				num2 = 9;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_ca6968c83fd143389aa31c3d640204a8 == 0)
				{
					num2 = 11;
				}
				continue;
			}
			num2 = 4;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
			{
				num2 = 3;
			}
		}
	}

	private void WriteAnchor(HelperReader value)
	{
		int num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 2:
				_InitializerReader = false;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_975d5ae980504c978a6f27812bd2ed9c != 0)
				{
					num2 = 0;
				}
				break;
			case 1:
				pageReader = false;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_9b938a4d873a4c7bb5a5d42be3dd62fb != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 3:
				Write(value.Value);
				num2 = 2;
				break;
			}
		}
	}

	private void WriteTagHandle(string value)
	{
		int num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 4:
				if (!_InitializerReader)
				{
					num2 = 3;
					break;
				}
				goto case 2;
			case 2:
				Write(value);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_bb8926b8e9654997b296b0a630e011ec != 0)
				{
					num2 = 5;
				}
				break;
			case 5:
				_InitializerReader = false;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_430ddf5d121e45c8921724f6b7cdd124 == 0)
				{
					num2 = 0;
				}
				break;
			case 3:
				Write(' ');
				num2 = 2;
				break;
			case 1:
				return;
			default:
				pageReader = false;
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f011663d64054593978962dcc3a5ec1a != 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	private void WriteTagContent(string value, bool needsWhitespace)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				if (!needsWhitespace)
				{
					num2 = 0;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_68a2101d989348bfa76860a813cfb4bb != 0)
					{
						num2 = 1;
					}
					break;
				}
				goto case 6;
			case 1:
			case 7:
				Write(UrlEncode(value));
				num2 = 5;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f8051b1f027d4e93b2cc7547518e86b6 == 0)
				{
					num2 = 2;
				}
				break;
			case 5:
				_InitializerReader = false;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_7dc8be5db9384bb8aa167c326cd69ac2 != 0)
				{
					num2 = 0;
				}
				break;
			case 4:
				Write(' ');
				num2 = 7;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_37c2d620823d45e38e581339cfe15645 != 0)
				{
					num2 = 6;
				}
				break;
			default:
				pageReader = false;
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa == 0)
				{
					num2 = 3;
				}
				break;
			case 3:
				return;
			case 6:
				if (!_InitializerReader)
				{
					num2 = 4;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a741be94fd5347298dea6bbe8b5ead09 == 0)
					{
						num2 = 2;
					}
					break;
				}
				goto case 1;
			}
		}
	}

	private string UrlEncode(string text)
	{
		return m_TemplateReader.Replace(text, [_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)] ([_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)] Match match) =>
		{
			int num = 8;
			int num2 = num;
			StringBuilder stringBuilder = default(StringBuilder);
			int num3 = default(int);
			byte b = default(byte);
			byte[] bytes = default(byte[]);
			while (true)
			{
				switch (num2)
				{
				case 8:
					stringBuilder = new StringBuilder();
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_00e21191ffc442beb0bc62e17aff6c8e != 0)
					{
						num2 = 7;
					}
					continue;
				case 6:
					num3++;
					num2 = 4;
					continue;
				case 5:
				case 9:
					b = bytes[num3];
					num2 = 2;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
					{
						num2 = 2;
					}
					continue;
				case 7:
					bytes = Encoding.UTF8.GetBytes(match.Value);
					num2 = 1;
					if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_acf2f14303a4419bb530d6de5b664827 == 0)
					{
						num2 = 1;
					}
					continue;
				case 2:
					stringBuilder.AppendFormat(DicSingleton.gE3WbyDVW(0x4097B854 ^ 0x4097C536), b);
					num2 = 6;
					continue;
				case 3:
				case 4:
					if (num3 < bytes.Length)
					{
						num2 = 5;
						continue;
					}
					break;
				case 1:
					num3 = 0;
					num2 = 3;
					continue;
				}
				break;
			}
			return stringBuilder.ToString();
		});
	}

	private void Write(char value)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				m_TestsReader++;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_383e4b8401014987888f5201fff85bdd == 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 2:
				_PredicateReader.Write(value);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_c3d5ee0aa11847ffb6fce3b973d933ea != 0)
				{
					num2 = 1;
				}
				break;
			}
		}
	}

	private void Write(string value)
	{
		int num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				m_TestsReader += value.Length;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_a37af0b8310a4c419c9ac28d7411aec0 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			case 2:
				_PredicateReader.Write(value);
				num2 = 1;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_3749ca7f260e4459a8bf0c3522f98640 != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	private void WriteBreak(char breakCharacter = '\n')
	{
		int num = 5;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 4:
				_PredicateReader.WriteLine();
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_649731255cf946b595d0e7d03b5e10f7 != 0)
				{
					num2 = 0;
				}
				break;
			default:
				m_TestsReader = 0;
				num2 = 3;
				break;
			case 1:
				_PredicateReader.Write(breakCharacter);
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_1f7f42740cf4492881809381c35d4aba == 0)
				{
					num2 = 0;
				}
				break;
			case 5:
				if (breakCharacter == '\n')
				{
					num2 = 4;
					break;
				}
				goto case 1;
			case 3:
				return;
			}
		}
	}

	static MethodReader()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				GetterIssuer.DeleteInitializer();
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_05afd1e4002b492d9192d4fa1ff54957 == 0)
				{
					num2 = 0;
				}
				break;
			case 2:
				return;
			default:
				m_TemplateReader = new Regex(DicSingleton.gE3WbyDVW(0x7FAAD78F ^ 0x7FAAAA83), RegexOptions.Compiled | RegexOptions.Singleline);
				num2 = 2;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f9528329b4684fa587c9d76768891f6f != 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	internal static bool ValidateService()
	{
		return PushService == null;
	}

	internal static MethodReader EnableService()
	{
		return PushService;
	}
}
