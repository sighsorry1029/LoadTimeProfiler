namespace AzuAnticheat.Internal;

internal interface AlgoSetter
{
	void Set(string name, object target, object value);

	object? Read(string name, object target);
}
