using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace AzuAnticheat.Internal;

[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(0)]
[_003C3d152e1a_002D2c0c_002D4cda_002D865b_002D5c5b9db121a2_003ENullableContext(1)]
[PublicAPI]
internal sealed class ConnectionPublisher<[_003Cd077dc23_002D595a_002D4f05_002D95b0_002De511f7b9ea25_003ENullable(2)] T> : PrinterPublisher
{
	public T Value
	{
		get
		{
			return (T)base.BoxedValue;
		}
		set
		{
			base.BoxedValue = value;
		}
	}

	public ConnectionPublisher(RepositoryPublisher configSync, string identifier, T value = default(T), int priority = 0)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector(configSync, identifier, typeof(T), priority);
		Value = value;
	}

	public void AssignLocalValue(T value)
	{
		if (_ModelPublisher)
		{
			Value = value;
		}
		else
		{
			_ErrorPublisher = value;
		}
	}
}
