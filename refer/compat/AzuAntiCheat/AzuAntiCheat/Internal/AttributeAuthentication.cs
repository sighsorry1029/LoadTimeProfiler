using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal class AttributeAuthentication : PrototypeAuthentication
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0<TContext> where TContext : notnull
	{
		public ImporterSetter value;

		private static object ReadImporter;

		public _003C_003Ec__DisplayClass3_0()
		{
			GetterIssuer.DeleteInitializer();
			base._002Ector();
			int num = 0;
			if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_72642816f2be486b9130eafb9ea0281e == 0)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				break;
			}
		}

		internal bool _003CTraverseProperties_003Eb__0(StrategySetter c)
		{
			return c.Accepts(value.Type);
		}

		internal static bool ViewImporter()
		{
			return ReadImporter == null;
		}

		internal static object InitImporter()
		{
			return ReadImporter;
		}
	}

	private readonly IEnumerable<StrategySetter> m_InterpreterAuthentication;

	private readonly CodeWriter singletonAuthentication;

	public AttributeAuthentication(IEnumerable<StrategySetter> converters, AdvisorSetter typeDescriptor, ConnectionSetter typeResolver, int maxRecursion, ConfigSetter namingConvention, CodeWriter settings, PrinterSetter factory)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(typeDescriptor, typeResolver, maxRecursion, namingConvention, factory);
		m_InterpreterAuthentication = converters;
		singletonAuthentication = settings;
	}

	protected override void TraverseProperties<TContext>(ImporterSetter value, ErrorSetter<TContext> visitor, TContext context, Stack<WriterAuthentication> path)
	{
		_003C_003Ec__DisplayClass3_0<TContext> CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass3_0<TContext>();
		CS_0024_003C_003E8__locals5.value = value;
		if (!CS_0024_003C_003E8__locals5.value.Type.HasDefaultConstructor(singletonAuthentication.AllowPrivateConstructors) && !m_InterpreterAuthentication.Any((StrategySetter c) => c.Accepts(CS_0024_003C_003E8__locals5.value.Type)))
		{
			throw new InvalidOperationException(string.Format(DicSingleton.gE3WbyDVW(-948533799 ^ -948507337), CS_0024_003C_003E8__locals5.value.Type));
		}
		base.TraverseProperties(CS_0024_003C_003E8__locals5.value, visitor, context, path);
	}
}
