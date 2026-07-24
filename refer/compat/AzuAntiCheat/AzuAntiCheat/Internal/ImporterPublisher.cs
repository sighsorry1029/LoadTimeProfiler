using System.Runtime.CompilerServices;
using BepInEx.Configuration;
using JetBrains.Annotations;

namespace AzuAnticheat.Internal;

[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(1)]
[PublicAPI]
[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
internal class ImporterPublisher<[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)] T> : WrapperPublisher
{
	public readonly ConfigEntry<T> _CreatorPublisher;

	public override ConfigEntryBase BaseConfig => _CreatorPublisher;

	public T Value
	{
		get
		{
			return _CreatorPublisher.Value;
		}
		set
		{
			_CreatorPublisher.Value = value;
		}
	}

	public ImporterPublisher(ConfigEntry<T> sourceConfig)
	{
		GetterIssuer.DeleteInitializer();
		_CreatorPublisher = sourceConfig;
		base._002Ector();
	}

	public void AssignLocalValue(T value)
	{
		if (serverPublisher == null)
		{
			Value = value;
		}
		else
		{
			serverPublisher = value;
		}
	}
}
