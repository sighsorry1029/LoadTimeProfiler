namespace AzuAnticheat.Internal;

internal interface ReponseSetter<T>
{
	void InsteadOf<TRegistrationType>() where TRegistrationType : T;

	void Before<TRegistrationType>() where TRegistrationType : T;

	void After<TRegistrationType>() where TRegistrationType : T;

	void OnTop();

	void OnBottom();
}
