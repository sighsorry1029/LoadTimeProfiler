using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal interface EventPrototype
{
	void Serialize(TextWriter writer, object graph);

	string Serialize(object graph);

	void Serialize(TextWriter writer, object graph, Type type);

	void Serialize(ModelReader emitter, object graph);

	void Serialize(ModelReader emitter, object graph, Type type);
}
