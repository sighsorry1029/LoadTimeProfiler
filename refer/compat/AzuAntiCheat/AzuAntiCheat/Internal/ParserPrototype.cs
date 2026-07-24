using System;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal interface ParserPrototype<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)] T>
{
	bool Enter(UtilsPrototype value, T context);

	bool EnterMapping(UtilsPrototype key, UtilsPrototype value, T context);

	bool EnterMapping(RequestPrototype key, UtilsPrototype value, T context);

	void VisitScalar(UtilsPrototype scalar, T context);

	void VisitMappingStart(UtilsPrototype mapping, Type keyType, Type valueType, T context);

	void VisitMappingEnd(UtilsPrototype mapping, T context);

	void VisitSequenceStart(UtilsPrototype sequence, Type elementType, T context);

	void VisitSequenceEnd(UtilsPrototype sequence, T context);
}
