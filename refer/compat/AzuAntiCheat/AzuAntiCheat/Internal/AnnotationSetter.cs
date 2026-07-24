using System;

namespace AzuAnticheat.Internal;

internal interface AnnotationSetter
{
	object? DeserializeValue(CandidateInterpreter parser, Type expectedType, MethodInvocation state, AnnotationSetter nestedObjectDeserializer);
}
