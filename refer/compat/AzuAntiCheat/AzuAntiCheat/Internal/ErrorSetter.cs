using System;

namespace AzuAnticheat.Internal;

internal interface ErrorSetter<T>
{
	bool Enter(ImporterSetter value, T context);

	bool EnterMapping(ImporterSetter key, ImporterSetter value, T context);

	bool EnterMapping(RegSetter key, ImporterSetter value, T context);

	void VisitScalar(ImporterSetter scalar, T context);

	void VisitMappingStart(ImporterSetter mapping, Type keyType, Type valueType, T context);

	void VisitMappingEnd(ImporterSetter mapping, T context);

	void VisitSequenceStart(ImporterSetter sequence, Type elementType, T context);

	void VisitSequenceEnd(ImporterSetter sequence, T context);
}
