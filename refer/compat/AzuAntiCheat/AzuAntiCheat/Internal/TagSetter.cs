using System;

namespace AzuAnticheat.Internal;

internal interface TagSetter
{
	void Read(CandidateInterpreter parser, Type expectedType, VisitorSetter nestedObjectDeserializer);

	void Write(MockInterpreter emitter, StubSetter nestedObjectSerializer);
}
