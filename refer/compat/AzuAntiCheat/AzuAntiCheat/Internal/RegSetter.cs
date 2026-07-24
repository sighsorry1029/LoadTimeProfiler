using System;

namespace AzuAnticheat.Internal;

internal interface RegSetter
{
	string Name { get; }

	bool CanWrite { get; }

	Type Type { get; }

	Type? TypeOverride { get; set; }

	int Order { get; set; }

	ConnectionInterpreter ScalarStyle { get; set; }

	T? GetCustomAttribute<T>() where T : Attribute;

	ImporterSetter Read(object target);

	void Write(object target, object? value);
}
