namespace AzuAnticheat.Internal;

internal interface ProxySetter<T>
{
	void InsteadOf<TRegistrationType>() where TRegistrationType : T;
}
