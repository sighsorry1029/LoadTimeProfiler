using System;
using System.IO;

namespace AzuAnticheat.Internal;

internal interface ModelSetter
{
	string Serialize(object? graph);

	string Serialize(object? graph, Type type);

	void Serialize(TextWriter writer, object? graph);

	void Serialize(TextWriter writer, object? graph, Type type);

	void Serialize(MockInterpreter emitter, object? graph);

	void Serialize(MockInterpreter emitter, object? graph, Type type);
}
