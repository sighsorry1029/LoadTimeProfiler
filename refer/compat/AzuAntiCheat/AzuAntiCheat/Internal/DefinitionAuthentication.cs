using System;

namespace AzuAnticheat.Internal;

internal sealed class DefinitionAuthentication : GlobalAuthentication
{
	private readonly Func<Type, object> m_ComposerAuthentication;

	private static DefinitionAuthentication SetImporter;

	public DefinitionAuthentication(Func<Type, object> factory)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		m_ComposerAuthentication = factory ?? throw new ArgumentNullException(DicSingleton.gE3WbyDVW(0x6BAF1854 ^ 0x6BAF7236));
	}

	public override object Create(Type type)
	{
		return m_ComposerAuthentication(type);
	}

	internal static bool PushImporter()
	{
		return SetImporter == null;
	}

	internal static DefinitionAuthentication ValidateImporter()
	{
		return SetImporter;
	}
}
