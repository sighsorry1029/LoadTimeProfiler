using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal sealed class PrototypeFilter : RoleFilter
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
		public UtilsPrototype _ReaderFilter;

		private static _003C_003Ec__DisplayClass3_0 DeleteProcess;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f7c2b99249d64b1ca6be49030839e971 != 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(0)]
		internal bool _003CEnter_003Eb__0(StatusPrototype t)
		{
			return t.Accepts(_ReaderFilter.Type);
		}

		internal static bool FillProcess()
		{
			return DeleteProcess == null;
		}

		internal static _003C_003Ec__DisplayClass3_0 FlushProcess()
		{
			return DeleteProcess;
		}
	}

	private readonly IEnumerable<StatusPrototype> interceptorFilter;

	private readonly BridgePrototype _FilterFilter;

	internal static PrototypeFilter StopProcess;

	public PrototypeFilter(ParserPrototype<ModelReader> nextVisitor, IEnumerable<StatusPrototype> typeConverters, BridgePrototype nestedObjectSerializer)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(nextVisitor);
		IEnumerable<StatusPrototype> enumerable;
		if (typeConverters == null)
		{
			enumerable = Enumerable.Empty<StatusPrototype>();
		}
		else
		{
			IEnumerable<StatusPrototype> enumerable2 = typeConverters.ToList();
			enumerable = enumerable2;
		}
		interceptorFilter = enumerable;
		_FilterFilter = nestedObjectSerializer;
	}

	public override bool Enter(UtilsPrototype value, ModelReader context)
	{
		int num = 12;
		RecordPrototype recordPrototype = default(RecordPrototype);
		StatusPrototype statusPrototype = default(StatusPrototype);
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = default(_003C_003Ec__DisplayClass3_0);
		ParameterPrototype parameterPrototype = default(ParameterPrototype);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				default:
					recordPrototype.Write(context, _FilterFilter);
					num2 = 10;
					continue;
				case 9:
					statusPrototype = interceptorFilter.FirstOrDefault(_003C_003Ec__DisplayClass3_._003CEnter_003Eb__0);
					num = 5;
					break;
				case 11:
					_003C_003Ec__DisplayClass3_._ReaderFilter = value;
					num2 = 9;
					continue;
				case 4:
					if (parameterPrototype != null)
					{
						num2 = 2;
						continue;
					}
					return base.Enter(_003C_003Ec__DisplayClass3_._ReaderFilter, context);
				case 5:
					if (statusPrototype == null)
					{
						num2 = 8;
						continue;
					}
					goto case 1;
				case 1:
					statusPrototype.WriteYaml(context, _003C_003Ec__DisplayClass3_._ReaderFilter.Value, _003C_003Ec__DisplayClass3_._ReaderFilter.Type);
					num2 = 13;
					continue;
				case 13:
					return false;
				case 8:
					recordPrototype = _003C_003Ec__DisplayClass3_._ReaderFilter.Value as RecordPrototype;
					num2 = 7;
					continue;
				case 2:
					parameterPrototype.WriteYaml(context);
					num = 6;
					break;
				case 7:
					if (recordPrototype == null)
					{
						num2 = 3;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_f00c03d4800148fb8c3d7b3e01410aa7 == 0)
						{
							num2 = 2;
						}
						continue;
					}
					goto default;
				case 6:
					return false;
				case 10:
					return false;
				case 3:
					parameterPrototype = _003C_003Ec__DisplayClass3_._ReaderFilter.Value as ParameterPrototype;
					num2 = 4;
					continue;
				case 12:
					_003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
					num2 = 11;
					continue;
				}
				break;
			}
		}
	}

	internal static bool ExcludeProcess()
	{
		return StopProcess == null;
	}

	internal static PrototypeFilter InterruptProcess()
	{
		return StopProcess;
	}
}
