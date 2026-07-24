using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal interface ParamPrototype<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] T>
{
	void InsteadOf<TRegistrationType>() where TRegistrationType : T;

	void Before<TRegistrationType>() where TRegistrationType : T;

	void After<TRegistrationType>() where TRegistrationType : T;

	void OnTop();

	void OnBottom();
}
